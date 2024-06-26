// This temporary script is to be run just once for each clause after conversion.
// This is the only place where we do in-place changes to the clause.
// Recommendation is to commit the clause, run the script, check the changes, commit them.
// This script removes section numbers from the headings and adds links to all §-references.

open System
open System.IO
open System.Text.RegularExpressions

type LinkCreationError = IoFailure of string | LinkErrors of string list
type LinkCreationState = {targets: Map<string, string>; errors: string list; linkCount: int}
let initState targets = {targets = targets; errors = []; linkCount = 0}

let fullTextFile = "spec/2018-spec-autogenerated-from-pdf.md"

let readAllLines filename =
    try
        File.ReadAllLines(filename) |> Array.toList |> Ok
    with
        e -> Error (IoFailure e.Message)

let writeAllLines filename (lines: string list) =
    try
        File.WriteAllLines(filename, lines)
        printfn $"rewrote {filename}"
        Ok ()
    with
        e -> Error(IoFailure e.Message)

let referenceable (s: string) =
    String [|
        for c in s do
            if Char.IsAsciiLetterLower c || c = '-' || Char.IsAsciiDigit c then yield c
            if Char.IsAsciiLetterUpper c then yield Char.ToLower c
            if c = ' ' then yield '-'
    |]

let collectTargets lines =
    let tryGetTarget clause line =
        let m = Regex.Match(line, "^#+ +(\d+\.)([\.\d]*) +(.*)")
        if m.Success then
            let section1 = m.Groups[1].Value
            let sectionR = m.Groups[2].Value
            let section = section1 + sectionR
            let headerText = m.Groups[3].Value
            let refHeaderText = referenceable headerText
            let newClause = if sectionR.Length = 0 then refHeaderText else clause
            let target = $"{newClause}.md#{refHeaderText}"
            Some (section, target), newClause
        else None, clause
    let targets = ("", lines) ||> List.mapFold tryGetTarget |> fst |> List.choose id |> Map
    printfn $"{targets.Count} targets found"
    // targets |> Map.iter (fun s h -> printfn $"{s} {h}")
    Ok targets

let rec processLine state line =
    let m = Regex.Match(line, "^(#+) +(\d+\.[\.\d]*) +(.*)")
    if m.Success then
        // remove section number from headers
        let head, header = m.Groups[1].Value, m.Groups[3].Value
        $"{head} {header}", state
    else
        // add links to §-references
        let m = Regex.Match(line, "^([^§\[]*)§ ?(\d+(?:\.\d+)*)(.*)")
        if m.Success then
            let pre, section, post = m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value
            let sectionToSearch = if section.Contains "." then section else section + "."
            match Map.tryFind sectionToSearch state.targets with
            | Some target ->
                let post', state' = processLine state post
                $"{pre}[§{section}]({target}){post'}", {state' with linkCount = state'.linkCount + 1}
            | None ->
                let error = $"ERROR: section {section} not found: {line}"
                line, {state with errors = error::state.errors}
        else line, state

let processClause(state, lines) =
    let lines, state = (state, lines) ||> List.mapFold processLine
    if state.errors.IsEmpty then
        printfn $"{state.linkCount} links added"
        Ok lines
    else Error(LinkErrors (List.rev state.errors))


let addLinks clauseFile =
    let clauseFile = $"spec/{clauseFile}"
    let result =
        readAllLines fullTextFile
        |> Result.bind collectTargets
        |> Result.bind (fun targets -> readAllLines clauseFile |> Result.map (fun lines -> initState targets, lines))
        |> Result.bind processClause
        |> Result.bind (writeAllLines clauseFile)
    match result with
    | Ok _ -> 0
    | Error(IoFailure msg) -> printfn $"IO error: %s{msg}"; 1
    | Error(LinkErrors errors) -> errors |> List.iter (printfn "%s"); 2

if fsi.CommandLineArgs.Length < 2 then printfn $"usage: dotnet fsi CreateLinks.fsx filename"; 1
else addLinks fsi.CommandLineArgs[1]