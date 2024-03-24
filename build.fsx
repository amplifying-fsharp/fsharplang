// This script creates the full spec doc with freshly numbered section headers, adjusted reference links and ToC.
// For now just a single script, at some point it should become a project with proper tests etc.
// TODO: boilerplate, annexes ...

open System
open System.Text.RegularExpressions
open System.Text.Json
open System.IO

type Clause = {name: string; lines: string list}
type ClauseCatalog = {MainBody: string list; Annexes: string list}
type BuildState = {
    clauseName: string
    lineNumber: int
    sectionNumber: int list
    inCodeBlock: bool
    toc: Map<int list, string>
    errors: string list
    warnings: string list
    }
type BuildError = IoFailure of string | DocumentErrors of string list

let warningsAsErrors = false   // set this to true once the baseline is complete
let docHead = [$"WIP {DateTime.Now}"; "# Table of Contents"]
let initialState = {
    clauseName = ""
    lineNumber = 0
    sectionNumber = []
    inCodeBlock = false
    toc = Map.empty
    errors = []
    warnings = []
    }

let specDir = "spec"
let outDir = "artifacts"
let specPath filename = $"{specDir}/{filename}"
let clausePath clauseName = specPath clauseName + ".md"
let clauseCatalogPath = specPath "Clauses.json"
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

let sectionText sectionNumber =
    $"""{List.head sectionNumber}.{List.tail sectionNumber |> List.map string |> String.concat "."}"""

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

let mkError state msg = $"{state.clauseName}.md({state.lineNumber}): {msg}"

let checkCodeBlock state line =
    let m = Regex.Match(line, " *```(.*)")
    if not m.Success then state else
        if state.inCodeBlock then {state with inCodeBlock = false} else
            let infoString = m.Groups[1].Value
            if not <| List.contains infoString ["fsgrammar"; "fsharp"; "csharp"; "fsother"] then
                let msg = "starting code block fences must be '```fsgrammar', '```fsharp', '```csharp' or 'fsother'"
                {state with inCodeBlock = true; errors = (mkError state msg)::state.errors}
            else {state with inCodeBlock = true}

let renumberIfHeaderLine state line =
    let state = {state with lineNumber = state.lineNumber + 1}
    let state = checkCodeBlock state line
    let m = Regex.Match(line, "^(#+) +(.*)")
    if state.inCodeBlock || not m.Success then line, state
    else
        let headerPrefix = m.Groups[1].Value
        let level = headerPrefix.Length
        let heading = m.Groups[2].Value
        let m = Regex.Match(heading, "^\d")
        if m.Success then
            let msg = "Headers must not start with digits"
            line, {state with errors = (mkError state msg)::state.errors}
        else
            let sectionNumber = newSection level state.sectionNumber
            if sectionNumber.IsEmpty then
                let msg = $"The header level jumps from {state.sectionNumber.Length} to {level}"
                line, {state with errors = (mkError state msg)::state.errors}
            else
                let headerLine = $"{headerPrefix} {sectionText sectionNumber} {heading}"
                headerLine, {state with sectionNumber = sectionNumber; toc = state.toc.Add(sectionNumber, heading)}

let renumberClause state clause =
    let state = {state with clauseName = clause.name; lineNumber = 0}
    let outLines, state = (state, clause.lines) ||> List.mapFold renumberIfHeaderLine
    {clause with lines = outLines}, state

let tocLines toc =
    let tocLine (number, heading) = 
        let sText = sectionText number
        let anchor = $"#{referenceable sText}-{referenceable heading}"
        String.replicate (number.Length - 1) "  " + $"- [{sText} {heading}]({anchor})"
    toc |> Map.toList |> List.map tocLine

let adjustLinks state line = 
    let state = {state with lineNumber = state.lineNumber + 1}
    let rec adjustLinks' state lineFragment =
        let m = Regex.Match(lineFragment, "(.*)\[§(\d+\.[\.\d]*)\]\(([^#)]+)#([^)]+)\)(.*)")
        if m.Success then
            let pre, sText, filename, anchor, post =
                m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, m.Groups[4].Value, m.Groups[5].Value
            match Map.tryPick (fun n heading -> if sectionText n = sText then Some heading else None) state.toc with
            | Some _ ->
                let post', state' = adjustLinks' state post
                $"{pre}[§{sText}](#{referenceable sText}-{anchor}){post'}", state'
            | None ->
                let msg = $"unknown link target {filename}#{anchor} ({sText})"
                if warningsAsErrors then
                    lineFragment, {state with errors = (mkError state msg)::state.errors}
                else
                    lineFragment, {state with warnings = (mkError state msg)::state.warnings}
        else lineFragment, state
    adjustLinks' state line

let processClauses clauses =
    // Add section numbers to the headers and collect the ToC information
    let (processedClauses, state) = (initialState, clauses) ||> List.mapFold renumberClause
    // Create the ToC and build the complete spec
    let lines = docHead @ tocLines state.toc @ List.collect _.lines processedClauses
    // Adjust the reference links to point to the correct header of the new spec
    let (lines, state) = ({state with clauseName = outFilePath; lineNumber = 0}, lines) ||> List.mapFold adjustLinks
    if not state.errors.IsEmpty then
        Error(DocumentErrors (List.rev state.errors))
    else
        state.warnings |> List.rev |> List.iter (printfn "Warning: %s")
        Ok lines

let build() =
    match readClauses() |> Result.bind processClauses |> Result.bind writeSpec with
    | Ok () -> 0
    | Error(IoFailure msg) -> printfn $"IO error: %s{msg}"; 1
    | Error(DocumentErrors errors) -> errors |> List.iter (printfn "Error: %s"); 2

build()


