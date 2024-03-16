# Patterns

Patterns are used to perform simultaneous case analysis and decomposition on values together with
the `match`, `try...with`, `function`, `fun`, and `let` expression and declaration constructs. Rules are
attempted in order from top to bottom and left to right. The syntactic forms of patterns are shown
in the subsequent table.

```
rule :=
    pat pattern-guardopt - > expr -- pattern, optional guard and action

pattern-guard := when expr

pat :=
    const -- constant pattern
    long-ident pat-paramopt patopt -- named pattern
    _ -- wildcard pattern
    pat as ident -- "as" pattern
    pat '|' pat -- disjunctive pattern
    pat '&' pat -- conjunctive pattern
    pat :: pat -- "cons" pattern
    pat : type -- pattern with type constraint
    pat ,..., pat -- tuple pattern
    ( pat ) -- parenthesized pattern
    list-pat -- list pattern
    array-pat -- array pattern
    record-pat -- record pattern
    :? atomic-type -- dynamic type test pattern
    :? atomic-type as ident -- dynamic type test pattern
    null -- null-test pattern
    attributes pat -- pattern with attributes

list-pat :=
    [ ]
    [ pat ; ... ; pat ]

array-pat :=
    [| |]
    [| pat ; ... ; pat |]

record-pat :=
    { field-pat ; ... ; field-pat }

atomic-pat :=
    pat : one of
            const long-ident list-pat record-pat array-pat ( pat )
            :? atomic-type
            null _

field-pat := long-ident = pat

pat-param :=
    | const
    | long-ident
    | [ pat-param ; ... ; pat-param ]
    | ( pat-param , ..., pat-param )
    | long-ident pat-param
    | pat-param : type
    | <@ expr @>
    | <@@ expr @@>
    | null

pats := pat , ... , pat
field-pats := field-pat ; ... ; field-pat
rules := '|' opt rule '|' ... '|' rule
```
Patterns are elaborated to expressions through a process called _pattern match compilation_. This
reduces pattern matching to _decision trees_ which operate on an input value, called the _pattern input_.
The decision tree is composed of the following constructs:

- Conditionals on integers and other constants
- Switches on union cases
- Conditionals on runtime types
- Null tests
- Value definitions
- An array of pattern-match targets referred to by index

## Simple Constant Patterns

The pattern _`const`_ is a _constant pattern_ which matches values equal to the given constant. For
example:

```
let rotate3 x =
    match x with
    | 0 -> "two"
    | 1 -> "zero"
    | 2 -> "one"
    | _ -> failwith "rotate3"
```
In this example, the constant patterns are 0, 1, and 2. Any constant listed in [§6.3.1](expressions.md#simple-constant-expressions) may be used as a
constant pattern except for integer literals that have the suffixes `Q`, `R`, `Z`, `I`, `N`, `G`.

Simple constant patterns have the corresponding simple type. Such patterns elaborate to a call to
the F# structural equality function `FSharp.Core.Operators.(=)` with the pattern input and the
constant as arguments. The match succeeds if this call returns true; otherwise, the match fails.


> **Note**: The use of `FSharp.Core.Operators.(=)` means that CLI floating-point equality is
used to match floating-point values, and CLI ordinal string equality is used to match
strings.

## Named Patterns

Patterns in the following forms are _named patterns_ :

```
Long-ident
Long-ident pat
Long-ident pat-params pat
```

If _`long-ident`_ is a single identifier that does not begin with an uppercase character, it is interpreted
as a _variable pattern_. During checking, the variable is assigned the same value and type as the
pattern input.

If _`long-ident`_ is more than one-character long or begins with an uppercase character (that is, if
`System.Char.IsUpperInvariant` is `true` and `System.Char.IsLowerInvariant` is `false` on the first
character), it is resolved by using _Name Resolution in Patterns_ ([§14.1.6](inference-procedures.md#name-resolution-in-patterns)). This algorithm produces one
of the following:

- A union case
- An exception label
- An active pattern case name
- A literal value

Otherwise, _`long-ident`_ must be a single uppercase identifier _`ident`_. In this case, _`pat`_ is a variable
pattern. An F# implementation may optionally generate a warning if the identifier is uppercase. Such
a warning is recommended if the length of the identifier is greater than two.

After name resolution, the subsequent treatment of the named pattern is described in the following
sections.

### Union Case Patterns

If _`long-ident`_ from [§7.2](patterns.md#named-patterns) resolves to a union case, the pattern is a union case pattern. If _`long-ident`_
resolves to a union case _`Case`_ , then _`long-ident`_ and _`long-ident pat`_ are patterns that match pattern
inputs that have union case label _`Case`_. The _`long-ident`_ form is used if the corresponding case takes
no arguments, and the _`long-ident pat`_ form is used if it takes arguments.

At runtime, if the pattern input is an object that has the corresponding union case label, the data
values carried by the union are matched against the given argument patterns.

For example:

```
type Data =
    | Kind1 of int * int
    | Kind2 of string * string
```
```
let data = Kind1(3, 2)
```
```
let result =
    match data with
    | Kind1 (a, b) -> a + b
    | Kind2 (s1, s2) -> s1.Length + s2.Length
```
In this case, result is given the value 5.

When a union case has named fields, these names may be referenced in a union case pattem. When
using pattern matching with multiple fields, semicolons are used to delimit the named fields. For
example

```
type Shape =
    | Rectangle of width: float * height: float
    | Square of width: float
```
```
let getArea (s: Shape) =
    match s with
    | Rectangle (width = w; height = h) -> w*h
    | Square (width = w) -> w*w
```
### Literal Patterns

If _`long-ident`_ from [§7.2](patterns.md#named-patterns) resolves to a literal value, the pattern is a literal pattern. The pattern is
equivalent to the corresponding constant pattern.

In the following example, the `Literal` attribute ([§10.2.2](namespaces-and-modules.md#literal-definitions-in-modules)) is first used to define two literals, and these
literals are used as identifiers in the match expression:

```
[<Literal>]
let Case1 = 1

[<Literal>]
let Case2 = 100

let result =
    match 1 00 with
    | Case1 -> "Case1"
    | Case2 -> "Case 2 "
    | _ -> "Some other case"
```
In this case, `result` is given the value `"Case2”`.

### Active Patterns

If _`long-ident`_ from [§7.2](patterns.md#named-patterns) resolves to an _active pattern case name `CaseNamei`_ then the pattern is an
active pattern. The rules for name resolution in patterns ([§14.1.6](inference-procedures.md#name-resolution-in-patterns)) ensure that _`CaseNamei`_ is
associated with an _active pattern function `f`_ in one of the following forms:

- `(| _CaseName_ |) _inp_`

  Single case. The function accepts one argument (the value being matched) and can return any
type.

- `(| _CaseName_ |_|) _inp_`

  Partial. The function accepts one argument (the value being matched) and must return a value
of type `FSharp.Core.option<_>`

- `(| _CaseName 1_ | ...| _CaseNamen_ |) _inp_`

  Multi-case. The function accepts one argument (the value being matched), and must return a
value of type `FSharp.Core.Choice<_,...,_>` based on the number of case names. In F#, the
limitation n ≤ 7 applies.

- `(| _CaseName_ |) _arg 1_ ... _argn inp_`

  Single case with parameters. The function accepts `n+1` arguments, where the last argument (`inp`)
is the value to match, and can return any type.


- `(| _CaseName_ |_|) _arg 1_ ... _argn inp_`

  Partial with parameters. The function accepts n +1 arguments, where the last argument (`inp`) is
the value to match, and must return a value of type `FSharp.Core.option<_>`.

Other active pattern functions are not permitted. In particular, multi-case, partial functions such as
the following are not permitted:

```
(|CaseName1| ... |CaseNamen|_|)
```

When an active pattern function takes arguments, the _`pat-params`_ are interpreted as expressions
that are passed as arguments to the active pattern function. The _`pat-params`_ are converted to the
syntactically identical corresponding expression forms and are passed as arguments to the active
pattern function _`f`_.

At runtime, the function _`f`_ is applied to the pattern input, along with any parameters. The pattern
matches if the active pattern function returns _`v`_ , _`ChoicekOfN v`_ , or Some _`v`_ , respectively, when applied
to the pattern input. If the pattern argument _`pat`_ is present, it is then matched against _`v`_.

The following example shows how to define and use a partial active pattern function:

```
let (|Positive|_|) inp = if inp > 0 then Some(inp) else None
let (|Negative|_|) inp = if inp < 0 then Some(-inp) else None

match 3 with
| Positive n -> printfn "positive, n = %d" n
| Negative n -> printfn "negative, n = %d" n
| _ -> printfn "zero"
```
The following example shows how to define and use a multi-case active pattern function:

```
let (|A|B|C|) inp = if inp < 0 then A elif inp = 0 then B else C

match 3 with
| A -> "negative"
| B -> "zero"
| C - > "positive"
```
The following example shows how to define and use a parameterized active pattern function:

```
let (|MultipleOf|_|) n inp = if inp%n = 0 then Some (inp / n) else None

match 16 with
| MultipleOf 4 n -> printfn "x = 4*%d" n
| _ -> printfn "not a multiple of 4"
```
An active pattern function is executed only if a left-to-right, top-to-bottom reading of the entire
pattern indicates that execution is required. For example, consider the following active patterns:

```
let (|A|_|) x =
    if x = 2 then failwith "x is two"
    elif x = 1 then Some()
    else None

let (|B|_|) x =
    if x=3 then failwith "x is three" else None

let (|C|) x = failwith "got to C"

let f x =
    match x with
    | 0 -> 0
    | A -> 1
    | B -> 2
    | C -> 3
    | _ -> 4
```
These patterns evaluate as follows:

```
f 0 // 0
f 1 // 1
f 2 // failwith "x is two"
f 3 // failwith "x is three"
f 4 // failwith "got to C"
```
An active pattern function may be executed multiple times against the same pattern input during
resolution of a single overall pattern match. The precise number of times that the active pattern
function is executed against a particular pattern input is implementation-dependent.

## “As” Patterns

An “as” pattern is of the following form:

```
pat as ident
```
The “as” pattern defines _`ident`_ to be equal to the pattern input and matches the pattern input
against _`pat`_. For example:

```
let t1 = (1, 2)
let (x, y) as t2 = t1
printfn "%d-%d-%A" x y t2 // 1- 2 - (1, 2)
```
This example binds the identifiers `x`, `y`, and `t1` to the values `1` , `2` , and `(1,2)`, respectively.

## Wildcard Patterns

The pattern `_` is a wildcard pattern and matches any input. For example:

```
let categorize x =
    match x with
    | 1 - > 0
    | 0 -> 1
    | _ -> 0
```
In the example, if `x` is `0`, the match returns `1`. If `x` has any other value, the match returns `0`.


## Disjunctive Patterns

A disjunctive pattern matches an input value against one or the other of two patterns:

```
pat | pat
```
At runtime, the patterm input is matched against the first pattern. If that fails, the pattern input is
matched against the second pattern. Both patterns must bind the same set of variables with the
same types. For example:

```
type Date = Date of int * int * int

let isYearLimit date =
    match date with
    | (Date (year, 1, 1) | Date (year, 12, 31)) -> Some year
    | _ -> None

let result = isYearLimit (Date (2010,12,31))
```
In this example, `result` is given the value `true`, because the pattern input matches the second
pattern.

## Conjunctive Patterns

A conjunctive pattern matches the pattern input against two patterns.

```
pat 1 & pat 2
```
For example:

```
let (|MultipleOf|_|) n inp = if inp%n = 0 then Some (inp / n) else None

let result =
match 56 with
    | MultipleOf 4 m & MultipleOf 7 n -> m + n
    | _ -> false
```
In this example, `result` is given the value `22` (= 16 + 8), because the pattern input match matches
both patterns.

## List Patterns

The pattern _`pat :: pat`_ is a union case pattern that matches the “cons” union case of F# list values.

The pattern `[]` is a union case pattern that matches the “nil” union case of F# list values.

The pattern `[ _pat 1 ; ... ; patn_ ]` is shorthand for a series of `::` and empty list patterns
`_pat 1 :: ... :: patn_ :: []`.

For example:

```
let rec count x =
    match x with
    | [] -> 0
    | h :: t -> h + count t

let result 1 = count [1;2;3]

let result2 =
    match [1;2;3] with
    | [a;b;c] -> a + b + c
    | _ -> 0
```
In this example, both `result1` and `result2` are given the value `6`.

## Type-annotated Patterns

A _type-annotated pattern_ specifies the type of the value to match to a pattern.

```
pat : type
```
For example:

```
let rec sum xs =
    match xs with
    | [] -> 0
    | (h : int) :: t -> h + sum t
```
In this example, the initial type of `h` is asserted to be equal to `int` before the pattern `h` is checked.
Through type inference, this in turn implies that `xs` and `t` have static type `int list`, and `sum` has
static type
`int list -> int`.

## Dynamic Type-test Patterns

_Dynamic type-test patterns_ have the following two forms:

```
:? type
:? type as ident
```
A dynamic type-test pattern matches any value whose runtime type is _`type`_ or a subtype of _`type`_. For
example:

```
let message (x : System.Exception) =
    match x with
    | :? System.OperationCanceledException -> "cancelled"
    | :? System.ArgumentException -> "invalid argument"
    | _ -> "unknown error"
```
If the type-test pattern is of the form `:? _type as ident_`, then the value is coerced to the given type
and _`ident`_ is bound to the result. For example:

```
let findLength (x : obj) =
match x with
    | :? string as s -> s.Length
    | _ -> 0
```

In the example, the identifier `s` is bound to the value `x` with type `string`.

If the pattern input has type _`tyin`_, pattern checking uses the same conditions as both a dynamic type-
test expression _`e :? type`_ and a dynamic coercion expression _`e :?> type`_ where _`e`_ has type _`tyin`_. An
error occurs if _`type`_ cannot be statically determined to be a subtype of the type of the pattern input.
A warning occurs if the type test will always succeed based on _`type`_ and the static type of the pattern
input.

A warning is issued if an expression contains a redundant dynamic type-test pattern, after any
coercion is applied. For example:

```
match box "3" with
| :? string -> 1
| :? string -> 1 // a warning is reported that this rule is "never matched"
| _ -> 2

match box "3" with
| :? System.IComparable -> 1
| :? string -> 1 // a warning is reported that this rule is "never matched"
| _ -> 2
```
At runtime, a dynamic type-test pattern succeeds if and only if the corresponding dynamic type-test
expression _`e :? ty`_ would return true where _`e`_ is the pattern input. The value of the pattern is bound
to the results of a dynamic coercion expression _`e :?> ty`_.

## Record Patterns

The following is a _record pattern_ :

```
{ long-ident 1 = pat 1 ; ... ; long-identn = patn }
```
For example:

```
type Data = { Header:string; Size: int; Names: string list }

let totalSize data =
    match data with
    | { Header = "TCP"; Size = size; Names = names } -> size + names.Length * 12
    | { Header = "UDP"; Size = size } -> size
    | _ -> failwith "unknown header"
```
The _`long-identi`_ are resolved in the same way as field labels for record expressions and must
together identify a single, unique F# record type. Not all record fields for the type need to be
specified in the pattern.

## Array Patterns

An _array pattern_ matches an array of a partciular length:

```
[| pat ; ... ; pat |]
```

For example:

```
let checkPackets data =
    match data with
    | [| "HeaderA"; data1; data2 |] -> (data1, data2)
    | [| "HeaderB"; data2; data1 |] -> (data1, data2)
    | _ -> failwith "unknown packet"
```
## Null Patterns

The _null pattern_ null matches values that are represented by the CLI value null. For example:

```
let path =
    match System.Environment.GetEnvironmentVariable("PATH") with
    | null -> failwith "no path set!"
    | res -> res
```
Most F# types do not use `null` as a representation; consequently, the null pattern is generally used
to check values passed in by CLI method calls and properties. For a list of F# types that use `null` as a
representation, see [§5.4.8](types-and-type-constraints.md#nullness).

## Guarded Pattern Rules

_Guarded pattern rules_ have the following form:

```
pat when expr
```
For example:

```
let categorize x =
    match x with
    | _ when x < 0 -> - 1
    | _ when x < 0 -> 1
    | _ -> 0
```
The guards on a rule are executed only after the match value matches the corresponding pattern.
For example, the following evaluates to `2` with no output.

```
match (1, 2) with
| (3, x) when (printfn "not printed"; true) -> 0
| (_, y) -> y
```
