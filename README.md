# Overview

This is an initiative to create a more complete and community-maintainable F# spec.

Currently, we are converting the latest official spec `FSharpSpec-4.1-latest.pdf` to markdown. We take the [C# standard repository](https://github.com/dotnet/csharpstandard) as inspiration and will follow their approach where possible, while staying pragmatic and mindful of our available resources.

The intention is to move the content to https://github.com/fsharp/fslang-spec once the necessary environment and processes have been set up in that repository.

# Conversion guideline

- To convert a clause (chapter), copy the content of that chapter from "2018-spec-autogenerated-from-pdf.md" to a separate .md file. The filename is the standard conversion of the header text to a linkable name (e.g. "Program Structure" => "program-structure").
- Do the necessary manual conversion, specifically
    - Add indentations to code examples and to syntax
    - Add `fsharp` or `fsgrammar` info string to code block fences for code and syntax, resp.
        <br> Add `csharp` for C# code and `fsother` for the few other cases.
    - Note that the auto-converter has turned the syntax blocks into code blocks and thus dropped the italics in the syntax. We keep it that way.
    - Turn all blue items in text paragraphs (blue color in the pdf spec) into code spans (i.e. enclose them in back ticks). Drop the italics also here.
    - Subscripts in the pdf (like in `expr₁`) are typically auto-converted to `expr 1`. We don't support subscripts and just remove the space (`expr1`). An exception is the "opt" suffix, which we convert into ~opt (e.g. `expr~opt`), so that we can later easily deal with it differently by using search-and-replace.
    - Also drop the underlining of "Elaborated Expressions".
    - Reconstruct tables (using GFM (github flavoured markdown)). In code spans inside tables, escape `|` like this `\|`.
    - Start notes with `> Note: `
    - Check for occasional problems in the auto-converted version (for example missing spaces around dashes), or extra spaces.
    - Add spaces back to table like syntax definitions (like in the operator lists in section 4.1)
    - Revert headings back from all caps to normal capitalization (CONSTANTS -> Constants)
    - Adjust heading levels (# 1. / ## 1.1 / ### 1.1.1)
    - Keep references as they are (like `(see §9.1)`), no space between the `§` and the number, as they will are automatically converted by the CreateLinks script (see below).
- Add the new filename (without the .md suffix) to `Clauses.json`
- In the root directory, run `dotnet fsi CreateLinks.fsx <yourChapter.md>`.
    > This needs to be done only once during baseline creation. It changes your source file. It removes the section numbers in the headings and add links to all §x.x references. The operation, however, is idempotent.
- In the root directory, run `build`, this will update `spec.md` in the `artifacts` directory, complete with ToC and reference links.

# Conversion status

| Clause | Owner | Status | Review | Remarks |
| --- | --- |--------| --- | --- |
| introduction | Martin521 | done   |
| program-structure | Martin521 | done   |
| lexical-analysis | Martin521 | done   |
| basic-grammar-elements | Martin521 | done   |
| types-and-type-constraints | edgarfgp | done   |
| expressions | Martin521 | done   |
| patterns | Martin521 | done   |
| type-definitions | Martin521 | done   |
| units-of-measure | Martin521 | done   |
| namespaces-and-modules | Martin521 | done   |
| namespace-and-module-signatures | Martin521 | done   |
| program-structure-and-execution | Martin521 | done   |
| custom-attributes-and-reflection | Martin521 | done   |
| inference-procedures | Martin521 | done   |
| lexical-filtering | Martin521 | done   |
| provided-types | edgarfgp | done  |
| special-attributes-and-types | Martin521 | done   |
| the-f-library-fsharpcoredll | Martin521 | wip |

