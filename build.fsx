// For now just creating the index
// For now just a single script

open System
open System.Text.RegularExpressions
open System.Text.Json
open System.IO

type Clause = {name: string; lines: string list}
type ClauseIndex = {MainBody: string list; Annexes: string list}
type BuildState = {section: int list; errors: string list}

let initialState = {section = []; errors = []}

let specDir = "spec"
let specFilePath filename = $"{specDir}/{filename}"
let clauseFilePath clauseName = specFilePath clauseName + ".md"
let clausesFilePath = specFilePath "clauses.json"

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
    let m = Regex.Match(line, "^(#+) (.*)")
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
            let s = $"""{section.Head}.{section |> List.rev |> List.tail |> List.map string |> String.concat "."}"""
            let headerText = m.Groups[2].Value
            $"{headerPrefix} {s} {headerText}", {state with section = section}
        else failwith $"unexpected regex failure: {line}"
    else line, state

let renumberClause state clause =
    let outLines, state = (state, clause.lines) ||> List.mapFold (renumberIfHeaderLine clause.name)
    {clause with lines = outLines}, state

let renumber() =
    let clauses = readClauses()
    let (outClauses: Clause list, _) = (initialState, clauses) ||> List.mapFold renumberClause
    outClauses |> List.iter (fun clause -> File.WriteAllLines(specFilePath $"{clause.name}-out.md", clause.lines))

renumber()


