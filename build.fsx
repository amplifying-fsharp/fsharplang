// For now just creating the full doc with freshly numbered section headers
// For now just a single script
// TODO: boilerplate, index with links, reference links ...

open System
open System.Text.RegularExpressions
open System.Text.Json
open System.IO

type Clause = {name: string; lines: string list}
type ClauseIndex = {MainBody: string list; Annexes: string list}
type BuildState = {section: int list; index: string list; errors: string list}

let indexHead = List.rev ["# Index"; $"WIP {DateTime.Now}"; ""]
let initialState = {section = []; index = indexHead; errors = []}

let specDir = "spec"
let specFilePath filename = $"{specDir}/{filename}"
let clauseFilePath clauseName = specFilePath clauseName + ".md"
let clausesFilePath = specFilePath "clauses.json"
let outFile = "artifacts/spec.md"

let readClauses() =
    try
        let clauseIndex = JsonSerializer.Deserialize<ClauseIndex>(File.OpenRead(clausesFilePath))
        let getClause name = {name = name; lines = File.ReadAllLines(clauseFilePath name) |> Array.toList}
        let clauses = clauseIndex.MainBody |> List.map getClause
        printfn $"read {clauses.Length} files with a total of {clauses |> List.sumBy (_.lines >> List.length)} lines"
        clauses
    with
        e -> failwith e.Message

let rec newSection level prevSection =
    match prevSection with
    | [] -> [1]
    | h::t when prevSection.Length = level -> (h + 1)::t
    | h::t when prevSection.Length > level -> newSection level t
    | h::t when prevSection.Length = level - 1 -> 1::prevSection
    | _ -> []

let referencable (s: string) =
    seq {
        for c in s do
            if Char.IsAsciiLetterLower c || c = '-' || Char.IsAsciiDigit c then yield c
            if Char.IsAsciiLetterUpper c then yield Char.ToLower c
            if c = ' ' then yield '-'
        }
    |> Seq.toArray |> String

let renumberIfHeaderLine clauseName state line =
    let m = Regex.Match(line, "^(#+) (\d.*)")
    if m.Success then
        let headerPrefix = m.Groups[1].Value
        let level = headerPrefix.Length
        let rest = m.Groups[2].Value
        let m = Regex.Match(rest, "([\.\d]*) ?(.*)")
        if m.Success then
            let section = newSection level state.section
            let state =
                if section.IsEmpty then
                    let error = $"The header level jump in {clauseName} from {state.section.Length} to {level}: {line}"
                    {state with errors = error::state.errors}
                else state
            let rSection = List.rev section
            let sText = $"""{rSection.Head}.{rSection.Tail |> List.map string |> String.concat "."}"""
            let headerText = m.Groups[2].Value
            let headerLine = $"{headerPrefix} {sText} {headerText}"
            let anchor = $"#{referencable sText}-{referencable headerText}"
            let indexLine = String.replicate (level - 1) "  " + $"- [{sText} {headerText}]({anchor})"
            headerLine, {state with section = section; index = indexLine::state.index}
        else failwith $"unexpected regex failure: {line}"
    else line, state

let renumberClause state clause =
    let outLines, state = (state, clause.lines) ||> List.mapFold (renumberIfHeaderLine clause.name)
    {clause with lines = outLines}, state

let build() =
    let clauses = readClauses()
    let (outClauses, state) = (initialState, clauses) ||> List.mapFold renumberClause
    if state.errors.Length > 0 then
        state.errors |> List.iter (printfn "%s")
    else
    let total = List.rev state.index @ List.collect (fun clause -> ""::clause.lines) outClauses
    if not <| Directory.Exists "artifacts" then Directory.CreateDirectory "artifacts" |> ignore
    File.WriteAllLines(outFile, total)
    printfn $"created {outFile}"

build()


