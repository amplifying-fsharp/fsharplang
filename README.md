# Overview

This is an initiative to create a more accessible and complete F# spec.

We are following a hands-on, pragmatic approach to improve the current situation.

## Phase 1 - create an initial version

In this phase, we will convert the latest official spec `FSharpSpec-4.1-latest.pdf` to markdown, in order to enable proper version management and collaboration. We take the [C# standard repository](https://github.com/dotnet/csharpstandard) as inspiration and will follow their approach where possible, while staying pragmatic and mindful of our available resources.

While doing this, we will also create a more concrete plan for phases 2 and 3.

## Phase 2 - create a draft F# 9 spec

The goal of this phase is to integrate the post-4.1 [RFCs](https://github.com/fsharp/fslang-design/) into the spec to cover the language that is implemented by the current F# compiler.

During this phase, we should also
- approach the main stakeholders (BDFL, MS, FSSF) to enable phase 3
- define (in collaboration with the stakeholders) a suitable environment and process for further work on the spec
- make the initiative public and seek contributors

## Phase 3 - make it official

- have broad support for having the new spec as the official F# spec
- have suitable agreed governance and processes installed to keep the spec up to date

# Some Details for Phase 1

- To convert a chapter, copy the content of that chapter from "2018-spec-autogenerated-from-pdf.md" to a separate .md file. The filename is the standard conversion of the header text to a linkable name (e.g. "Program Structure" => "program-structure").
- Do the necessary manual conversion, specifically
    - Add indentations to code examples and to syntax
    - Add fsharp or fsgrammar info string to code block fences for code and syntax, resp.
Turn all blue items in text paragraphs (blue color in the pdf spec) into code spans (i.e. enclose them in back ticks). If they  - are in italics, enclose the code span by underlines.
    - Reconstruct tables (using GFM (github flavoured markdown))
    - Check for occasional problems in the auto-converted version (for example missing spaces around dashes)
    - Add spaces back to table like syntax definition (like in the operator lists in section 4.1)
    - Adjust heading levels (# 1. / ## 1.1 / ### 1.1.1)
        - Note that the section numbers are replaced in the build process. But there must be some section number. In the future, for new sections, you can add a `0` section number.
    - Revert headings back from all caps to normal capitalization (CONSTANTS -> Constants)
- Add the new filename (without the .md suffix) to `clauses.json`
- In the root directory, run `build`
- The new spec is written to the `artifacts` directory

(Note that the build script is not yet complete, WIP)

