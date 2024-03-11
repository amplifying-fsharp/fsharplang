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

let initialState = {section = []; index = ["# Index"]; errors = []}

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
            let s = $"""{List.last section}.{section |> List.rev |> List.tail |> List.map string |> String.concat "."}"""
            let headerText = m.Groups[2].Value
            let headerLine = $"{headerPrefix} {s} {headerText}"
            let indexLine = String.replicate (level - 1) " " + $"{s} {headerText}"
            headerLine, {state with section = section; index = indexLine:: state.index}
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
    File.WriteAllLines(outFile, total)

build()


