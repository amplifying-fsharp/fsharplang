// For now just creating the full doc with freshly numbered section headers and ToC.
// For now just a single script, at some point it should become a project with proper tests etc.
// TODO: boilerplate, reference links, annexes ...

open System
open System.Text.RegularExpressions
open System.Text.Json
open System.IO

type Clause = {name: string; lines: string list}
type ClauseCatalog = {MainBody: string list; Annexes: string list}
type BuildState = {section: int list; toc: string list; errors: string list}
type BuildError = IoFailure of string | DocumentErrors of string list

let tocHead = List.rev ["# Index"; $"WIP {DateTime.Now}"; ""]
let initialState = {section = [0]; toc = tocHead; errors = []}

let specDir = "spec"
let outDir = "artifacts"
let specPath filename = $"{specDir}/{filename}"
let clausePath clauseName = specPath clauseName + ".md"
let clauseCatalogPath = specPath "clauses.json"
let outFilePath = $"{outDir}/spec.md"

let readClauses() =
    try
        use clauseStream = File.OpenRead clauseCatalogPath
        let clauseCatalog = JsonSerializer.Deserialize<ClauseCatalog> clauseStream
        let getClause name = {name = name; lines = File.ReadAllLines(clausePath name) |> Array.toList}
        let clauses = clauseCatalog.MainBody |> List.map getClause  // For now. TODO: Annexes etc.
        printfn $"read {clauses.Length} files with a total of {clauses |> List.sumBy (_.lines >> List.length)} lines"
        Ok clauses
    with
        e -> Error(IoFailure e.Message)

let writeSpec (lines: string list) =
    try
        if not <| Directory.Exists outDir then Directory.CreateDirectory outDir |> ignore
        File.WriteAllLines(outFilePath, lines)
        printfn $"created {outFilePath}"
        Ok ()
    with
        e -> Error(IoFailure e.Message)

let newSection level prevSection =
    let rec newSectionR prevSectionR =
        match prevSectionR with
            | [] -> [1]
            | h::t when prevSectionR.Length = level -> (h + 1)::t
            | _::t when prevSectionR.Length > level -> newSectionR t
            | _ when prevSectionR.Length = level - 1 -> 1::prevSectionR
            | _ -> []
    newSectionR (List.rev prevSection) |> List.rev

let referenceable (s: string) =
    String [|
        for c in s do
            if Char.IsAsciiLetterLower c || c = '-' || Char.IsAsciiDigit c then yield c
            if Char.IsAsciiLetterUpper c then yield Char.ToLower c
            if c = ' ' then yield '-'
    |]

let renumberIfHeaderLine clauseName state line =
    let m = Regex.Match(line, "^(#+) (\d[\.\d]+ .*)")
    if m.Success then
        let headerPrefix = m.Groups[1].Value
        let level = headerPrefix.Length
        let rest = m.Groups[2].Value
        let m = Regex.Match(rest, "(\d[\.\d]+) (.*)")
        if m.Success then
            let headerText = m.Groups[2].Value
            let section = newSection level state.section
            if section.IsEmpty then
                let error = $"The header level jumps in {clauseName} from {state.section.Length} to {level}: {line}"
                line, {state with errors = error::state.errors}
            else
                let sectionText = $"""{section.Head}.{section.Tail |> List.map string |> String.concat "."}"""
                let headerLine = $"{headerPrefix} {sectionText} {headerText}"
                let anchor = $"#{referenceable sectionText}-{referenceable headerText}"
                let tocLine = String.replicate (level - 1) "  " + $"- [{sectionText} {headerText}]({anchor})"
                headerLine, {state with section = section; toc = tocLine::state.toc}
        else failwith $"unexpected regex failure: {line}"
    else line, state

let renumberClause state clause =
    let outLines, state = (state, clause.lines) ||> List.mapFold (renumberIfHeaderLine clause.name)
    {clause with lines = outLines}, state

let processClauses clauses =
    let (processedClauses, state) =(initialState, clauses) ||> List.mapFold renumberClause
    if state.errors.IsEmpty then 
        let specLines = List.rev state.toc @ List.collect (fun clause -> ""::clause.lines) processedClauses
        Ok specLines
    else
        Error(DocumentErrors (List.rev state.errors))

let build() =
    match readClauses() |> Result.bind processClauses |> Result.bind writeSpec with
    | Ok () -> 0
    | Error(IoFailure msg) -> printfn $"IO error: %s{msg}"; 1
    | Error(DocumentErrors errors) -> errors |> List.iter (printfn "%s"); 2

build()


