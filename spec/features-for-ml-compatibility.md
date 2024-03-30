## 19. FEATURES FOR ML COMPATIBILITY

F# has its roots in the Caml family of programming languages and its core constructs are similar to
some other ML-family languages. As a result, F# supports some constructs for compatibility with
other implementations of ML-family languages.

### 19.1 CONDITIONAL COMPILATION FOR ML COMPATIBILITY

F# supports the following constructs for conditional compilation:

```
token start-fsharp-token = "(*IF-FSHARP" | "(*F#"
token end-fsharp-token = "ENDIF-FSHARP*)" | "F#*)"
token start-ml-token = "(*IF-OCAML*)"
token end-ml-token = "(*ENDIF-OCAML*)"
```
F# ignores the _start-fsharp-token_ and _end-fsharp-token_ tokens. This means that sections marked

```
(*IF-FSHARP ... ENDIF-FSHARP*)
```
—or—

```
(*F# ... F#*)
```
are included during tokenization when compiling with the F# compiler. The intervening text is
tokenized and returned in the token stream as normal.

In addition, the _start-ml-token_ token is discarded and the following text is tokenized as _string_ , ___
(any character), and _end-ml-token_ until an _end-ml-token_ is reached. Comments are not treated as
special during this process and are simply processed as “other text”. This means that text
surrounded by the following is excluded when compiling with the F# compiler:

```
(*IF-CAML*) ... (*ENDIF-CAML*)
or (*IF-OCAML*) ... (*ENDIF-OCAML*)
```
The intervening text is tokenized as “strings and other text” and the tokens are discarded until the
corresponding end token is reached. Comments are not treated as special during this process and
are simply processed as “other text.”

The converse holds when programs are compiled using a typical ML compiler.

### 19.2 EXTRA SYNTACTIC FORMS FOR ML COMPATIBILITY

The following identifiers are also keywords primarily because they are keywords in OCaml. Although
F# reserves several OCaml keywords for future use, the /mlcompatibility option enables the use of
these keywords as identifiers.

```
token ocaml-ident-keyword =
asr land lor lsl lsr lxor mod
```

```
Note: In F# the following alternatives are available. The precedence of these operators
differs from the precedence that OCaml uses.
asr >>> (on signed type)
land &&&
lor |||
lsl <<<
lsr >>> (on unsigned type)
lxor ^^^
mod %
sig begin (that is, begin/end may be used instead of sig/end)
```
F# includes the following additional syntactic forms for ML compatibility:

```
expr :=
| ...
| expr .( expr ) // array lookup
| expr .( expr ) <- expr // array assignment
```
```
type :=
| ...
| ( type ,..., type ) long-ident // generic type instantiation
module-implementation :=
| ...
| module ident = struct ... end
module-signature :=
| ...
| module ident : sig ... end
```
An ML compatibility warning occurs when these constructs are used.

Note that the for-expression form for _var_ = _expr_ 1 downto _expr_ 2 do _expr_ 3 is also permitted for ML
compatibility.

The following expression forms

```
expr :=
| ...
| expr.(expr) // array lookup
| expr.(expr) <- expr // array assignment
```
Are equivalent to the following uses of library-defined operators:

```
e 1 .( e 2 ) → (.()) e 1 e 2
e 1 .( e 2 ) <- e 3 → (.()<-) e 1 e 2 e 3
```
### 19.3 EXTRA OPERATORS

F# defines the following two additional shortcut operators:

```
e 1 or e 2 → (or) e 1 e 2
e 1 & e 2 → (&) e 1 e 2
```

### 19.4 FILE EXTENSIONS AND LEXICAL MATTERS

F# supports the use of the.ml and .mli extensions on the command line. The “indentation
awareness off” syntax option is implicitly enabled when using either of these filename extensions.

Lightweight syntax can be explicitly disabled in .fs, .fsi, .fsx, and .fsscript files by specifying
#indent "off" as the first declaration in a file:

```
#indent "off"
```
When lightweight syntax is disabled, whitespace can include tab characters:

```
regexp whitespace = [ ' ' '\t' ]+
```