WIP 2024-03-23 17:29:12
# Table of Contents
- [1. Introduction](#1-introduction)
  - [1.1 A First Program](#11-a-first-program)
    - [1.1.1 Lightweight Syntax](#111-lightweight-syntax)
    - [1.1.2 Making Data Simple](#112-making-data-simple)
    - [1.1.3 Making Types Simple](#113-making-types-simple)
    - [1.1.4 Functional Programming](#114-functional-programming)
    - [1.1.5 Imperative Programming](#115-imperative-programming)
    - [1.1.6 .NET Interoperability and CLI Fidelity](#116-net-interoperability-and-cli-fidelity)
    - [1.1.7 Parallel and Asynchronous Programming](#117-parallel-and-asynchronous-programming)
    - [1.1.8 Strong Typing for Floating-Point Code](#118-strong-typing-for-floating-point-code)
    - [1.1.9 Object-Oriented Programming and Code Organization](#119-object-oriented-programming-and-code-organization)
    - [1.1.10 Information-rich Programming](#1110-information-rich-programming)
  - [1.2 Notational Conventions in This Specification](#12-notational-conventions-in-this-specification)
- [2. Program Structure](#2-program-structure)
- [3. Lexical Analysis](#3-lexical-analysis)
  - [3.1 Whitespace](#31-whitespace)
  - [3.2 Comments](#32-comments)
  - [3.3 Conditional Compilation](#33-conditional-compilation)
  - [3.4 Identifiers and Keywords](#34-identifiers-and-keywords)
  - [3.5 Strings and Characters](#35-strings-and-characters)
  - [3.6 Symbolic Keywords](#36-symbolic-keywords)
  - [3.7 Symbolic Operators](#37-symbolic-operators)
  - [3.8 Numeric Literals](#38-numeric-literals)
    - [3.8.1 Post-filtering of Adjacent Prefix Tokens](#381-post-filtering-of-adjacent-prefix-tokens)
    - [3.8.2 Post-filtering of Integers Followed by Adjacent “..”](#382-post-filtering-of-integers-followed-by-adjacent-)
    - [3.8.3 Reserved Numeric Literal Forms](#383-reserved-numeric-literal-forms)
    - [3.8.4 Shebang](#384-shebang)
  - [3.9 Line Directives](#39-line-directives)
  - [3.10 Hidden Tokens](#310-hidden-tokens)
  - [3.11 Identifier Replacements](#311-identifier-replacements)
- [4. Basic Grammar Elements](#4-basic-grammar-elements)
  - [4.1 Operator Names](#41-operator-names)
  - [4.2 Long Identifiers](#42-long-identifiers)
  - [4.3 Constants](#43-constants)
  - [4.4 Operators and Precedence](#44-operators-and-precedence)
    - [4.4.1 Categorization of Symbolic Operators](#441-categorization-of-symbolic-operators)
    - [4.4.2 Precedence of Symbolic Operators and Pattern/Expression Constructs](#442-precedence-of-symbolic-operators-and-patternexpression-constructs)
- [5. Types and Type Constraints](#5-types-and-type-constraints)
  - [5.1 Checking Syntactic Types](#51-checking-syntactic-types)
    - [5.1.1 Named Types](#511-named-types)
    - [5.1.2 Variable Types](#512-variable-types)
    - [5.1.3 Tuple Types](#513-tuple-types)
    - [5.1.4 Array Types](#514-array-types)
    - [5.1.5 Constrained Types](#515-constrained-types)
  - [5.2 Type Constraints](#52-type-constraints)
    - [5.2.1 Subtype Constraints](#521-subtype-constraints)
    - [5.2.2 Nullness Constraints](#522-nullness-constraints)
    - [5.2.3 Member Constraints](#523-member-constraints)
    - [5.2.4 Default Constructor Constraints](#524-default-constructor-constraints)
    - [5.2.5 Value Type Constraints](#525-value-type-constraints)
    - [5.2.6 Reference Type Constraints](#526-reference-type-constraints)
    - [5.2.7 Enumeration Constraints](#527-enumeration-constraints)
    - [5.2.8 Delegate Constraints](#528-delegate-constraints)
    - [5.2.9 Unmanaged Constraints](#529-unmanaged-constraints)
    - [5.2.10 Equality and Comparison Constraints](#5210-equality-and-comparison-constraints)
  - [5.3 Type Parameter Definitions](#53-type-parameter-definitions)
  - [5.4 Logical Properties of Types](#54-logical-properties-of-types)
    - [5.4.1 Characteristics of Type Definitions](#541-characteristics-of-type-definitions)
    - [5.4.2 Expanding Abbreviations and Inference Equations](#542-expanding-abbreviations-and-inference-equations)
    - [5.4.3 Type Variables and Definition Sites](#543-type-variables-and-definition-sites)
    - [5.4.4 Base Type of a Type](#544-base-type-of-a-type)
    - [5.4.5 Interfaces Types of a Type](#545-interfaces-types-of-a-type)
    - [5.4.6 Type Equivalence](#546-type-equivalence)
    - [5.4.7 Subtyping and Coercion](#547-subtyping-and-coercion)
    - [5.4.8 Nullness](#548-nullness)
    - [5.4.9 Default Initialization](#549-default-initialization)
    - [5.4.10 Dynamic Conversion Between Types](#5410-dynamic-conversion-between-types)
- [6. Expressions](#6-expressions)
  - [6.1 Some Checking and Inference Terminology](#61-some-checking-and-inference-terminology)
  - [6.2 Elaboration and Elaborated Expressions](#62-elaboration-and-elaborated-expressions)
  - [6.3 Data Expressions](#63-data-expressions)
    - [6.3.1 Simple Constant Expressions](#631-simple-constant-expressions)
    - [6.3.2 Tuple Expressions](#632-tuple-expressions)
    - [6.3.3 List Expressions](#633-list-expressions)
    - [6.3.4 Array Expressions](#634-array-expressions)
    - [6.3.5 Record Expressions](#635-record-expressions)
    - [6.3.6 Copy-and-update Record Expressions](#636-copy-and-update-record-expressions)
    - [6.3.7 Function Expressions](#637-function-expressions)
    - [6.3.8 Object Expressions](#638-object-expressions)
    - [6.3.9 Delayed Expressions](#639-delayed-expressions)
    - [6.3.10 Computation Expressions](#6310-computation-expressions)
    - [6.3.11 Sequence Expressions](#6311-sequence-expressions)
    - [6.3.12 Range Expressions](#6312-range-expressions)
    - [6.3.13 Lists via Sequence Expressions](#6313-lists-via-sequence-expressions)
    - [6.3.14 Arrays Sequence Expressions](#6314-arrays-sequence-expressions)
    - [6.3.15 Null Expressions](#6315-null-expressions)
    - [6.3.16 'printf' Formats](#6316-printf-formats)
  - [6.4 Application Expressions](#64-application-expressions)
    - [6.4.1 Basic Application Expressions](#641-basic-application-expressions)
    - [6.4.2 Object Construction Expressions](#642-object-construction-expressions)
    - [6.4.3 Operator Expressions](#643-operator-expressions)
    - [6.4.4 Dynamic Operator Expressions](#644-dynamic-operator-expressions)
    - [6.4.5 The AddressOf Operators](#645-the-addressof-operators)
    - [6.4.6 Lookup Expressions](#646-lookup-expressions)
    - [6.4.7 Slice Expressions](#647-slice-expressions)
    - [6.4.8 Member Constraint Invocation Expressions](#648-member-constraint-invocation-expressions)
    - [6.4.9 Assignment Expressions](#649-assignment-expressions)
  - [6.5 Control Flow Expressions](#65-control-flow-expressions)
    - [6.5.1 Parenthesized and Block Expressions](#651-parenthesized-and-block-expressions)
    - [6.5.2 Sequential Execution Expressions](#652-sequential-execution-expressions)
    - [6.5.3 Conditional Expressions](#653-conditional-expressions)
    - [6.5.4 Shortcut Operator Expressions](#654-shortcut-operator-expressions)
    - [6.5.5 Pattern-Matching Expressions and Functions](#655-pattern-matching-expressions-and-functions)
    - [6.5.6 Sequence Iteration Expressions](#656-sequence-iteration-expressions)
    - [6.5.7 Simple for-Loop Expressions](#657-simple-for-loop-expressions)
    - [6.5.8 While Expressions](#658-while-expressions)
    - [6.5.9 Try-with Expressions](#659-try-with-expressions)
    - [6.5.10 Reraise Expressions](#6510-reraise-expressions)
    - [6.5.11 Try-finally Expressions](#6511-try-finally-expressions)
    - [6.5.12 Assertion Expressions](#6512-assertion-expressions)
  - [6.6 Definition Expressions](#66-definition-expressions)
    - [6.6.1 Value Definition Expressions](#661-value-definition-expressions)
    - [6.6.2 Function Definition Expressions](#662-function-definition-expressions)
    - [6.6.3 Recursive Definition Expressions](#663-recursive-definition-expressions)
    - [6.6.4 Deterministic Disposal Expressions](#664-deterministic-disposal-expressions)
  - [6.7 Type-related Expressions](#67-type-related-expressions)
    - [6.7.1 Type-Annotated Expressions](#671-type-annotated-expressions)
    - [6.7.2 Static Coercion Expressions](#672-static-coercion-expressions)
    - [6.7.3 Dynamic Type-Test Expressions](#673-dynamic-type-test-expressions)
    - [6.7.4 Dynamic Coercion Expressions](#674-dynamic-coercion-expressions)
  - [6.8 Quoted Expressions](#68-quoted-expressions)
    - [6.8.1 Strongly Typed Quoted Expressions](#681-strongly-typed-quoted-expressions)
    - [6.8.2 Weakly Typed Quoted Expressions](#682-weakly-typed-quoted-expressions)
    - [6.8.3 Expression Splices](#683-expression-splices)
      - [6.8.3.1 Strongly Typed Expression Splices](#6831-strongly-typed-expression-splices)
  - [6.9 Evaluation of Elaborated Forms](#69-evaluation-of-elaborated-forms)
    - [6.9.1 Values and Execution Context](#691-values-and-execution-context)
    - [6.9.2 Parallel Execution and Memory Model](#692-parallel-execution-and-memory-model)
    - [6.9.3 Zero Values](#693-zero-values)
    - [6.9.4 Taking the Address of an Elaborated Expression](#694-taking-the-address-of-an-elaborated-expression)
    - [6.9.5 Evaluating Value References](#695-evaluating-value-references)
    - [6.9.6 Evaluating Function Applications](#696-evaluating-function-applications)
    - [6.9.7 Evaluating Method Applications](#697-evaluating-method-applications)
    - [6.9.8 Evaluating Union Cases](#698-evaluating-union-cases)
    - [6.9.9 Evaluating Field Lookups](#699-evaluating-field-lookups)
    - [6.9.10 Evaluating Array Expressions](#6910-evaluating-array-expressions)
    - [6.9.11 Evaluating Record Expressions](#6911-evaluating-record-expressions)
    - [6.9.12 Evaluating Function Expressions](#6912-evaluating-function-expressions)
    - [6.9.13 Evaluating Object Expressions](#6913-evaluating-object-expressions)
    - [6.9.14 Evaluating Definition Expressions](#6914-evaluating-definition-expressions)
    - [6.9.15 Evaluating Integer For Loops](#6915-evaluating-integer-for-loops)
    - [6.9.16 Evaluating While Loops](#6916-evaluating-while-loops)
    - [6.9.17 Evaluating Static Coercion Expressions](#6917-evaluating-static-coercion-expressions)
    - [6.9.18 Evaluating Dynamic Type-Test Expressions](#6918-evaluating-dynamic-type-test-expressions)
    - [6.9.19 Evaluating Dynamic Coercion Expressions](#6919-evaluating-dynamic-coercion-expressions)
    - [6.9.20 Evaluating Sequential Execution Expressions](#6920-evaluating-sequential-execution-expressions)
    - [6.9.21 Evaluating Try-with Expressions](#6921-evaluating-try-with-expressions)
    - [6.9.22 Evaluating Try-finally Expressions](#6922-evaluating-try-finally-expressions)
    - [6.9.23 Evaluating AddressOf Expressions](#6923-evaluating-addressof-expressions)
    - [6.9.24 Values with Underspecified Object Identity and Type Identity](#6924-values-with-underspecified-object-identity-and-type-identity)
- [7. Patterns](#7-patterns)
  - [7.1 Simple Constant Patterns](#71-simple-constant-patterns)
  - [7.2 Named Patterns](#72-named-patterns)
    - [7.2.1 Union Case Patterns](#721-union-case-patterns)
    - [7.2.2 Literal Patterns](#722-literal-patterns)
    - [7.2.3 Active Patterns](#723-active-patterns)
  - [7.3 “As” Patterns](#73-as-patterns)
  - [7.4 Wildcard Patterns](#74-wildcard-patterns)
  - [7.5 Disjunctive Patterns](#75-disjunctive-patterns)
  - [7.6 Conjunctive Patterns](#76-conjunctive-patterns)
  - [7.7 List Patterns](#77-list-patterns)
  - [7.8 Type-annotated Patterns](#78-type-annotated-patterns)
  - [7.9 Dynamic Type-test Patterns](#79-dynamic-type-test-patterns)
  - [7.10 Record Patterns](#710-record-patterns)
  - [7.11 Array Patterns](#711-array-patterns)
  - [7.12 Null Patterns](#712-null-patterns)
  - [7.13 Guarded Pattern Rules](#713-guarded-pattern-rules)
# 1. Introduction
F# is a scalable, succinct, type-safe, type-inferred, efficiently executing functional/imperative/object-oriented programming language. It aims to be the premier typed functional programming language for the .NET framework and other implementations of the Ecma 335 Common Language Infrastructure (CLI) specification. F# was partly inspired by the OCaml language and shares some common core constructs with it.

## 1.1 A First Program
Over the next few sections, we will look at some small F# programs, describing some important aspects of F# along the way. As an introduction to F#, consider the following program:

```fsharp
    let numbers = [ 1 .. 10 ]
    let square x = x * x
    let squares = List.map square numbers
    printfn "N^2 = %A" squares
```

To explore this program, you can:

- Compile it as a project in a development environment such as Visual Studio.
- Manually invoke the F# command line compiler fsc.exe.
- Use F# Interactive, the dynamic compiler that is part of the F# distribution.

### 1.1.1 Lightweight Syntax

The F# language uses simplified, indentation-aware syntactic constructs known as lightweight syntax. The lines of the sample program in the previous section form a sequence of declarations and are aligned on the same column. For example, the two lines in the following code are two separate declarations:

```fsharp
    let squares = List.map square numbers
    printfn "N^2 = %A" squares
```

Lightweight syntax applies to all the major constructs of the F# syntax. In the next example, the code is incorrectly aligned. The declaration starts in the first line and continues to the second and subsequent lines, so those lines must be indented to the same column under the first line:

```fsharp
    let computeDerivative f x =
        let p1 = f (x - 0.05)
      let p2 = f (x + 0.05)
           (p2 - p1) / 0.1
```

The following shows the correct alignment:

```fsharp
    let computeDerivative f x =
        let p1 = f (x - 0.05)
        let p2 = f (x + 0.05)
        (p2 - p1) / 0.1
```

The use of lightweight syntax is the default for all F# code in files with the extension .fs, .fsx, .fsi, or .fsscript.

### 1.1.2 Making Data Simple

The first line in our sample simply declares a list of numbers from one through ten.

```fsharp
    let numbers = [1 .. 10]
```

An F# list is an immutable linked list, which is a type of data used extensively in functional programming. Some operators that are related to lists include `::` to add an item to the front of a list and `@` to concatenate two lists. If we try these operators in F# Interactive, we see the following
results:

    > let vowels = ['e'; 'i'; 'o'; 'u'];;
    val vowels: char list = ['e'; 'i'; 'o'; 'u']

    > ['a'] @ vowels;;
    val it: char list = ['a'; 'e'; 'i'; 'o'; 'u']
    
    > vowels @ ['y'];;
    val it: char list = ['e'; 'i'; 'o'; 'u'; 'y']

Note that double semicolons delimit lines in F# Interactive, and that F# Interactive prefaces the result with val to indicate that the result is an immutable value, rather than a variable.

F# supports several other highly effective techniques to simplify the process of modeling and manipulating data such as tuples, options, records, unions, and sequence expressions. A tuple is an ordered collection of values that is treated as an atomic unit. In many languages, if you want to pass around a group of related values as a single entity, you need to create a named type, such as a class or record, to store these values. A tuple allows you to keep things organized by grouping related values together, without introducing a new type.

To define a tuple, you separate the individual components with commas.

    > let tuple = (1, false, "text");;
    val tuple : int * bool * string = (1, false, "text")

    > let getNumberInfo (x : int) = (x, x.ToString(), x * x);;
    val getNumberInfo : int -> int * string * int

    > getNumberInfo 42;;
    val it : int * string * int = (42, "42", 1764)

A key concept in F# is immutability. Tuples and lists are some of the many types in F# that are immutable, and indeed most things in F# are immutable by default. Immutability means that once a value is created and given a name, the value associated with the name cannot be changed. Immutability has several benefits. Most notably, it prevents many classes of bugs, and immutable data is inherently thread-safe, which makes the process of parallelizing code simpler.

### 1.1.3 Making Types Simple

The next line of the sample program defines a function called `square`, which squares its input.

```fsharp
    let square x = x * x
```

Most statically-typed languages require that you specify type information for a function declaration. However, F# typically infers this type information for you. This process is referred to as *type inference*.

From the function signature, F# knows that `square` takes a single parameter named `x` and that the function returns `x * x`. The last thing evaluated in an F# function body is the return value; hence there is no “return” keyword here. Many primitive types support the multiplication (*) operator (such as `byte`, `uint64`, and `double`); however, for arithmetic operations, F# infers the type `int` (a signed 32-bit integer) by default.

Although F# can typically infer types on your behalf, occasionally you must provide explicit type annotations in F# code. For example, the following code uses a type annotation for one of the parameters to tell the compiler the type of the input.

    > let concat (x : string) y = x + y;;
    val concat : string -> string -> string

Because x is stated to be of type `string`, and the only version of the `+` operator that accepts a left-hand argument of type `string` also takes a `string` as the right-hand argument, the F# compiler infers that the parameter `y` must also be a string. Thus, the result of `x + y` is the concatenation of the strings. Without the type annotation, the F# compiler would not have known which version of the `+` operator was intended and would have assumed `int` data by default.

The process of type inference also applies *automatic generalization* to declarations. This automatically makes code generic when possible, which means the code can be used on many types of data. For example, the following code defines a function that returns a new tuple in which the two values are swapped:

    > let swap (x, y) = (y, x);;
    val swap : 'a * 'b -> 'b * 'a

    > swap (1, 2);;
    val it : int * int = (2, 1)

    > swap ("you", true);;
    val it : bool * string = (true,"you")

Here the function `swap` is generic, and `'a` and `'b` represent type variables, which are placeholders for types in generic code. Type inference and automatic generalization greatly simplify the process of writing reusable code fragments.

### 1.1.4 Functional Programming

Continuing with the sample, we have a list of integers named `numbers`, and the `square` function, and we want to create a new list in which each item is the result of a call to our function. This is called *mapping* our function over each item in the list. The F# library function `List.map` does just that:

```fsharp
    let squares = List.map square numbers
```

Consider another example:

    > List.map (fun x -> x % 2 = 0) [1 .. 5];;
    val it : bool list = [false; true; false; true; false]

The code `(fun x -> x % 2 = 0)` defines an anonymous function, called a *function expression*, that takes a single parameter `x` and returns the result `x % 2 = 0`, which is a Boolean value that indicates whether `x` is even. The `->` symbol separates the argument list (`x`) from the function body (`x % 2 = 0`).

Both of these examples pass a function as a parameter to another function — the first parameter to `List.map` is itself another function. Using functions as function values is a hallmark of functional programming.

Another tool for data transformation and analysis is *pattern matching*. This powerful switch construct allows you to branch control flow and to bind new values. For example, we can match an F# list against a sequence of list elements.

```fsharp
    let checkList alist =
        match alist with
        | [] -> 0
        | [a] -> 1
        | [a; b] -> 2
        | [a; b; c] -> 3
        | _ -> failwith "List is too big!"
```

In this example, `alist` is compared with each potentially matching pattern of elements. When `alist` matches a pattern, the result expression is evaluated and is returned as the value of the match expression. Here, the `->` operator separates a pattern from the result that a match returns.

Pattern matching can also be used as a control construct — for example, by using a pattern that performs a dynamic type test:

```fsharp
    let getType (x : obj) =
        match x with
        | :? string -> "x is a string"
        | :? int -> "x is an int"
        | :? System.Exception -> "x is an exception"
```

The `:?` operator returns true if the value matches the specified type, so if `x` is a string, `getType` returns `"x is a string"`.

Function values can also be combined with the pipeline operator, `|>`. For example, given these functions:

```fsharp
    let square x = x * x
    let toStr (x : int) = x.ToString()
    let reverse (x : string) = new System.String(Array.rev (x.ToCharArray()))
```

We can use the functions as values in a pipeline:

    > let result = 32 |> square |> toStr |> reverse;;
    val it : string = "4201"

Pipelining demonstrates one way in which F# supports compositionality, a key concept in functional programming. The pipeline operator simplifies the process of writing compositional code where the result of one function is passed into the next.

### 1.1.5 Imperative Programming

The next line of the sample program prints text in the console window.

```fsharp
    printfn "N^2 = %A" squares
```

The F# library function `printfn` is a simple and type-safe way to print text in the console window. Consider this example, which prints an integer, a floating-point number, and a string:

    > printfn "%d * %f = %s" 5 0.75 ((5.0 * 0.75).ToString());;
    5 * 0.750000 = 3.75
    val it : unit = ()

The format specifiers `%d`, `%f`, and `%s` are placeholders for integers, floats, and strings. The `%A` format can be used to print arbitrary data types (including lists).

The `printfn` function is an example of *imperative programming*, which means calling functions for their side effects. Other commonly used imperative programming techniques include arrays and dictionaries (also called hash tables). F# programs typically use a mixture of functional and imperative techniques.

### 1.1.6 .NET Interoperability and CLI Fidelity

The Common Language Infrastructure (CLI) function `System.Console.ReadKey` to pause the program before the console window closes.

```fsharp
    System.Console.ReadKey(true)
```

Because F# is built on top of CLI implementations, you can call any CLI library from F#. Furthermore, other CLI languages can easily use any F# components.

### 1.1.7 Parallel and Asynchronous Programming

F# is both a parallel and a reactive language. During execution, F# programs can have multiple parallel active evaluations and multiple pending reactions, such as callbacks and agents that wait to react to events and messages.

One way to write parallel and reactive F# programs is to use F# async expressions. For example, the code below is similar to the original program in [§1.1](#11-a-first-program) except that it computes the Fibonacci function (using a technique that will take some time) and schedules the computation of the numbers in parallel:

```fsharp
    let rec fib x = if x < 2 then 1 else fib(x-1) + fib(x-2)

    let fibs =
        Async.Parallel [ for i in 0..40 -> async { return fib(i) } ]
        |> Async.RunSynchronously

    printfn "The Fibonacci numbers are %A" fibs

    System.Console.ReadKey(true)
```

The preceding code sample shows multiple, parallel, CPU-bound computations.

F# is also a reactive language. The following example requests multiple web pages in parallel, reacts to the responses for each request, and finally returns the collected results.

```fsharp
    open System
    open System.IO
    open System.Net

    let http url =
        async {
            let req = WebRequest.Create(Uri url)
            use! resp = req.AsyncGetResponse()
            use stream = resp.GetResponseStream()
            use reader = new StreamReader(stream)
            let contents = reader.ReadToEnd()
            return contents
            }

    let sites = [
        "http://www.bing.com"
        "http://www.google.com"
        "http://www.yahoo.com"
        "http://www.search.com"
        ]

    let htmlOfSites =
        Async.Parallel [for site in sites -> http site ]
        |> Async.RunSynchronously
```

By using asynchronous workflows together with other CLI libraries, F# programs can implement parallel tasks, parallel I/O operations, and message-receiving agents.

### 1.1.8 Strong Typing for Floating-Point Code

F# applies type checking and type inference to floating-point-intensive domains through units of measure inference and checking. This feature allows you to type-check programs that manipulate floating-point numbers that represent physical and abstract quantities in a stronger way than other typed languages, without losing any performance in your compiled code. You can think of this feature as providing a type system for floating-point code.

Consider the following example:

```fsharp
    [<Measure>] type kg
    [<Measure>] type m
    [<Measure>] type s

    let gravityOnEarth = 9.81<m/s^2>
    let heightOfTowerOfPisa = 55.86<m>
    let speedOfImpact = sqrt(2.0 * gravityOnEarth * heightOfTowerOfPisa)
```

The `Measure` attribute tells F# that `kg`, `s`, and `m` are not really types in the usual sense of the word, but are used to build units of measure. Here `speedOfImpact` is inferred to have type `float<m/s>`.

### 1.1.9 Object-Oriented Programming and Code Organization

The sample program shown at the start of this chapter is a _script_. Although scripts are excellent for rapid prototyping, they are not suitable for larger software components. F# supports the transition from scripting to structured code through several techniques.

The most important of these is *object-oriented programming* through the use of *class type definitions*, *interface type definitions*, and *object expressions*. Object-oriented programming is a primary application programming interface (API) design technique for controlling the complexity of large software projects. For example, here is a class definition for an encoder/decoder object.

```fsharp
    open System

    /// Build an encoder/decoder object that maps characters to an
    /// encoding and back. The encoding is specified by a sequence
    /// of character pairs, for example, [('a','Z'); ('Z','a')]
    type CharMapEncoder(symbols: seq<char*char>) =
        let swap (x, y) = (y, x)

        /// An immutable tree map for the encoding
        let fwd = symbols |> Map.ofSeq

        /// An immutable tree map for the decoding
        let bwd = symbols |> Seq.map swap |> Map.ofSeq
        let encode (s:string) =
            String [| for c in s -> if fwd.ContainsKey(c) then fwd.[c] else c |]

        let decode (s:string) =
            String [| for c in s -> if bwd.ContainsKey(c) then bwd.[c] else c |]

        /// Encode the input string
        member x.Encode(s) = encode s

        /// Decode the given string
        member x.Decode(s) = decode s
```

You can instantiate an object of this type as follows:

```fsharp
    let rot13 (c:char) =
        char(int 'a' + ((int c - int 'a' + 13) % 26))
    let encoder =
        CharMapEncoder( [for c in 'a'..'z' -> (c, rot13 c)])
```

And use the object as follows:

    > "F# is fun!" |> encoder.Encode ;;
    val it : string = "F# vf sha!"

    > "F# is fun!" |> encoder.Encode |> encoder.Decode ;;
    val it : String = "F# is fun!"

An interface type can encapsulate a family of object types:

```fsharp
    open System

    type IEncoding =
        abstract Encode : string -> string
        abstract Decode : string -> string
```

In this example, `IEncoding` is an interface type that includes both `Encode` and `Decode` object types.

Both object expressions and type definitions can implement interface types. For example, here is an object expression that implements the `IEncoding` interface type:

```fsharp
    let nullEncoder =
        { new IEncoding with
            member x.Encode(s) = s
            member x.Decode(s) = s }
```

*Modules* are a simple way to encapsulate code during rapid prototyping when you do not want to spend the time to design a strict object-oriented type hierarchy. In the following example, we place a portion of our original script in a module.

```fsharp
    module ApplicationLogic =
        let numbers n = [1 .. n]
        let square x = x * x
        let squares n = numbers n |> List.map square

    printfn "Squares up to 5 = %A" (ApplicationLogic.squares 5)
    printfn "Squares up to 10 = %A" (ApplicationLogic.squares 10)
    System.Console.ReadKey(true)
```

Modules are also used in the F# library design to associate extra functionality with types. For example, `List.map` is a function in a module.

Other mechanisms aimed at supporting software engineering include *signatures*, which can be used to give explicit types to components, and namespaces, which serve as a way of organizing the name hierarchies for larger APIs.

### 1.1.10 Information-rich Programming

F# Information-rich programming addresses the trend toward greater availability of data, services, and information. The key to information-rich programming is to eliminate barriers to working with diverse information sources that are available on the Internet and in modern enterprise environments. Type providers and query expressions are a significant part of F# support for information-rich programming.

The F# Type Provider mechanism allows you to seamlessly incorporate, in a strongly typed manner, data and services from external sources. A type provider presents your program with new types and methods that are typically based on the schemas of external information sources. For example, an F# type provider for Structured Query Language (SQL) supplies types and methods that allow programmers to work directly with the tables of any SQL database:

```fsharp
    // Add References to FSharp.Data.TypeProviders, System.Data, and System.Data.   Linq
    type schema = SqlDataConnection<"Data Source=localhost;Integrated   Security=SSPI;">

    let db = schema.GetDataContext()
```

The type provider connects to the database automatically and uses this for IntelliSense and type information.

Query expressions (added in F# 3.0) add the established power of query-based programming against SQL, Open Data Protocol (OData), and other structured or relational data sources. Query expressions provide support for language-Integrated Query (LINQ) in F#, and several query operators enable you to construct more complex queries. For example, we can create a query to filter the customers in the data source:

```fsharp
    let countOfCustomers =
        query {
            for customer in db.Customers do
                where (customer.LastName.StartsWith("N"))
                select (customer.FirstName, customer.LastName)
            }
```

Now it is easier than ever to access many important data sources—including enterprise, web, and cloud—by using a set of built-in type providers for SQL databases and web data protocols. Where necessary, you can create your own custom type providers or reference type providers that others have created. For example, assume your organization has a data service that provides a large and growing number of named data sets, each with its own stable data schema. You may choose to create a type provider that reads the schemas and presents the latest available data sets to the programmer in a strongly typed way.

## 1.2 Notational Conventions in This Specification

This specification describes the F# language by using a mixture of informal and semiformal techniques. All examples in this specification use lightweight syntax, unless otherwise specified.

Regular expressions are given in the usual notation, as shown in the table:

| Notation | Meaning |
| --- | --- |
| regexp+ | One or more occurrences |
| regexp* | Zero or more occurrences |
| regexp? | Zero or one occurrences |
| [ char - char ] | Range of ASCII characters |
| [ ^ char - char ] | Any characters except those in the range |

Unicode character classes are referred to by their abbreviation as used in CLI libraries for regular expressions—for example, `\Lu` refers to any uppercase letter. The following characters are referred to using the indicated notation:

| Character | Name | Notation |
| --- | --- | --- |
| \b | backspace | ASCII/UTF-8/UTF-16/UTF-32 code 08 |
| \n | newline | ASCII/UTF-8/UTF-16/UTF-32 code 10 |
| \r | return | ASCII/UTF-8/UTF-16/UTF-32 code 13 |
| \t | tab | ASCII/UTF-8/UTF-16/UTF-32 code 09 |

Strings of characters that are clearly not a regular expression are written verbatim. Therefore, the following string

    abstract

matches precisely the characters `abstract`.

Where appropriate, apostrophes and quotation marks enclose symbols that are used in the specification of the grammar itself, such as `'<'` and `'|'`. For example, the following regular expression matches `(+)` or `(-)`:

    '(' (+|-) ')'

This regular expression matches precisely the characters `#if`:

    "#if"

Regular expressions are typically used to specify tokens.

    token token-name = regexp

In the grammar rules, the notation `element-name~opt` indicates an optional element. The notation `...` indicates repetition of the preceding non-terminal construct and the separator token. For example, `expr ',' ... ',' expr` means a sequence of one or more `expr` elements separated by commas.
# 2. Program Structure

The inputs to the F# compiler or the F# Interactive dynamic compiler consist of:

- Source code files, with extensions `.fs`, `.fsi`, `.fsx`, or `.fsscript`.
    - Files with extension `.fs` must conform to grammar element `implementation-file` in [§12.1](program-structure-and-execution.md#implementation-files).
    - Files with extension `.fsi` must conform to grammar element `signature-file` in [§12.2](program-structure-and-execution.md#signature-files).
    - Files with extension `.fsx` or `.fsscript` must conform to grammar element `script-file` in
      [§12.3](program-structure-and-execution.md#script-files).
- Script fragments (for F# Interactive). These must conform to grammar element `script-fragment`.
  Script fragments can be separated by `;;` tokens.
- Assembly references that are specified by command line arguments or interactive directives.
- Compilation parameters that are specified by command line arguments or interactive directives.
- Compiler directives such as `#time`.

The `COMPILED` compilation symbol is defined for input that the F# compiler has processed. The
`INTERACTIVE` compilation symbol is defined for input that F# Interactive has processed.

Processing the source code portions of these inputs consists of the following steps:

1. **Decoding**. Each file and source code fragment is decoded into a stream of Unicode characters, as
   described in the C# specification, sections 2.3 and 2.4. The command-line options may specify a
   code page for this process.
2. **Tokenization**. The stream of Unicode characters is broken into a token stream by the lexical
   analysis described in [§3.](#3-lexical-analysis)
3. **Lexical Filtering**. The token stream is filtered by a state machine that implements the rules
   described in [§15.](lexical-filtering.md#lexical-filtering) Those rules describe how additional (artificial) tokens are inserted into the
   token stream and how some existing tokens are replaced with others to create an augmented
   token stream.
4. **Parsing**. The augmented token stream is parsed according to the grammar specification in this
   document.
5. **Importing**. The imported assembly references are resolved to F# or CLI assembly specifications,
   which are then imported. From the F# perspective, this results in the pre-definition of numerous
   namespace declaration groups ([§12.1](program-structure-and-execution.md#implementation-files)), types and type provider instances. The namespace
   declaration groups are then combined to form an initial name resolution environment ([§14.1](inference-procedures.md#name-resolution)).
6. **Checking**. The results of parsing are checked one by one. Checking involves such procedures as
   Name Resolution (§14.1), Constraint Solving (§14.5), and Generalization ([§14.6.7](inference-procedures.md#generalization)), as well as the
   application of other rules described in this specification.
   
   Type inference uses variables to represent unknowns in the type inference problem. The various
   checking processes maintain tables of context information including a name resolution
   environment and a set of current inference constraints. After the processing of a file or program
   fragment is complete, all such variables have been either generalized or resolved and the type
   inference environment is discarded.
7. **Elaboration**. One result of checking is an elaborated program fragment that contains elaborated
   declarations, expressions, and types. For most constructs, such as constants, control flow, and
   data expressions, the elaborated form is simple. Elaborated forms are used for evaluation, CLI
   reflection, and the F# expression trees that are returned by quoted expressions ([§6.8](#68-quoted-expressions)).
8. **Execution**. Elaborated program fragments that are successfully checked are added to a
   collection of available program fragments. Each fragment has a static initializer. Static initializers
   are executed as described in ([§12.5](program-structure-and-execution.md#program-execution)).
# 3. Lexical Analysis

Lexical analysis converts an input stream of Unicode characters into a stream of tokens by iteratively
processing the stream. If more than one token can match a sequence of characters in the source file,
lexical processing always forms the longest possible lexical element. Some tokens, such as `block-comment-start`, are discarded after processing as described later in this section.

## 3.1 Whitespace

Whitespace consists of spaces and newline characters.

```fsgrammar
regexp whitespace = ' '+
regexp newline = '\n' | '\r' '\n'
token whitespace-or-newline = whitespace | newline
```
Whitespace tokens `whitespace-or-newline` are discarded from the returned token stream.

## 3.2 Comments

Block comments are delimited by `(*` and `*)` and may be nested. Single-line comments begin with
two backslashes (`//`) and extend to the end of the line.

```fsgrammar
token block-comment-start = "(*"
token block-comment-end = "*)"
token end-of-line-comment = "//" [^'\n' '\r']*
```
When the input stream matches a `block-comment-start` token, the subsequent text is tokenized
recursively against the tokens that are described in §3 until a `block-comment-end` token is found. The
intermediate tokens are discarded.

For example, comments can be nested, and strings that are embedded within comments are
tokenized by the rules for `string`, `verbatim-string` , and `triple-quoted string`. In particular, strings
that are embedded in comments are tokenized in their entirety, without considering closing `*)`
marks. As a result of this rule, the following is a valid comment:

```fsharp
(* Here's a code snippet: let s = "*)" *)
```
However, the following construct, which was valid in F# 2.0, now produces a syntax error because a
closing comment token *) followed by a triple-quoted mark is parsed as part of a string:

```fsharp
(* """ *)
```
For the purposes of this specification, comment tokens are discarded from the returned lexical
stream. In practice, XML documentation tokens are `end-of-line-comments` that begin with ///. The
delimiters are retained and are associated with the remaining elements to generate XML
documentation.


## 3.3 Conditional Compilation

The lexical preprocessing directives `#if ident /#else/#endif` delimit conditional compilation
sections. The following describes the grammar for such sections:

```fsgrammar
token if-directive = "#if" whitespace if-expression-text
token else-directive = "#else"
token endif-directive = "#endif"

if-expression-term =
    ident-text
    '(' if-expression ')'

if-expression-neg =
    if-expression-term
    '!' if-expression-term

if-expression-and =
    if-expression-neg
    if-expression-and && if-expression-and

if-expression-or =
    if-expression-and
    if-expression-or || if-expression-or

if-expression = if-expression-or
```
A preprocessing directive always occupies a separate line of source code and always begins with a #
character followed immediately by a preprocessing directive name, with no intervening whitespace.
However, whitespace can appear before the # character. A source line that contains the `#if`, `#else`,
or `#endif` directive can end with whitespace and a single-line comment. Multiple-line comments are
not permitted on source lines that contain preprocessing directives.

If an `if-directive` token is matched during tokenization, text is recursively tokenized until a
corresponding `else-directive` or `endif-directive`. If the evaluation of the associated
`if-expression-text` when parsed as an _if-expression_ is true in the compilation environment defines
(where each `ident-text` is evaluataed according to the values given by command line options such
as `–define`), the token stream includes the tokens between the `if-directive` and the corresponding
`else-directive` or `endif-directive`. Otherwise, the tokens are discarded. The converse applies to
the text between any corresponding `else-directive` and the `endif-directive`.

- In skipped text, `#if ident /#else/#endif` sections can be nested.
- Strings and comments are not treated as special

## 3.4 Identifiers and Keywords

Identifiers follow the specification in this section.

```fsgrammar
regexp digit-char = [0-9]
regexp letter-char = '\Lu' | '\Ll' | '\Lt' | '\Lm' | '\Lo' | '\Nl'
regexp connecting-char = '\Pc'
regexp combining-char = '\Mn' | '\Mc'
regexp formatting-char = '\Cf'

regexp ident-start-char =
    | letter-char
    | _

regexp ident-char =
    | letter-char
    | digit-char
    | connecting-char
    | combining-char
    | formatting-char
    | '
    | _

regexp ident-text = ident-start-char ident-char *
token ident =
    | ident-text For example, myName1
    | `` ( [^'`' '\n' '\r' '\t'] | '`' [^ '`' '\n' '\r' '\t'] )+ ``
         example, ``value.with odd#name``
```
Any sequence of characters that is enclosed in double-backtick marks (` `` `` `), excluding newlines,
tabs, and double-backtick pairs themselves, is treated as an identifier. Note that when an identifier is
used for the name of a types, union type case, module, or namespace, the following characters are
not allowed even inside double-backtick marks:

```fsgrammar
‘.', '+', '$', '&', '[', ']', '/', '\\', '*', '\"', '`'
```
All input files are currently assumed to be encoded as UTF-8. See the C# specification for a list of the
Unicode characters that are accepted for the Unicode character classes \Lu, \Li, \Lt, \Lm, \Lo, \Nl,
\Pc, \Mn, \Mc, and \Cf.

The following identifiers are treated as keywords of the F# language:

```fsgrammar
token ident-keyword =
    abstract and as assert base begin class default delegate do done
    downcast downto elif else end exception extern false finally for
    fun function global if in inherit inline interface internal lazy let
    match member module mutable namespace new null of open or
    override private public rec return sig static struct then to
    true try type upcast use val void when while with yield
```
The following identifiers are reserved for future use:

```fsgrammar
token reserved-ident-keyword =
    atomic break checked component const constraint constructor
    continue eager fixed fori functor include
    measure method mixin object parallel params process protected pure
    recursive sealed tailcall trait virtual volatile
```
A future revision of the F# language may promote any of these identifiers to be full keywords.

The following token forms are reserved, except when they are part of a symbolic keyword ([§3.6](#36-symbolic-keywords)).

```fsgrammar
token reserved-ident-formats =
    | ident-text ( '!' | '#')
```
In the remainder of this specification, we refer to the token that is generated for a keyword simply
by using the text of the keyword itself.


## 3.5 Strings and Characters

String literals may be specified for two types:

- Unicode strings, type `string = System.String`
- Unsigned byte arrays, type `byte[] = bytearray`

Literals may also be specified by using C#-like verbatim forms that interpret `\` as a literal character
rather than an escape sequence. In a UTF-8-encoded file, you can directly embed the following in a
string in the same way as in C#:

- Unicode characters, such as “`\u0041bc`”
- Identifiers, as described in the previous section, such as “`abc`”
- Trigraph specifications of Unicode characters, such as “`\067`” which represents “`C`”

```fsgrammar
regexp escape-char = '\' ["\'ntbrafv]
regexp non-escape-chars = '\' [^"\'ntbrafv]
regexp simple-char-char =
    | (any char except '\n' '\t' '\r' '\b' '\a' '\f' '\v' ' \ ")

regexp unicodegraph-short = '\' 'u' hexdigit hexdigit hexdigit hexdigit
regexp unicodegraph-long =  '\' 'U' hexdigit hexdigit hexdigit hexdigit
                                    hexdigit hexdigit hexdigit hexdigit

regexp trigraph = '\' digit-char digit-char digit-char

regexp char-char =
    | simple-char-char
    | escape-char
    | trigraph
    | unicodegraph-short

regexp string-char =
    | simple-string-char
    | escape-char
    | non-escape-chars
    | trigraph
    | unicodegraph-short
    | unicodegraph-long
    | newline

regexp string-elem =
    | string-char
    | '\' newline whitespace * string-elem

token char = ' char-char '
token string = " string-char * "

regexp verbatim-string-char =
    | simple-string-char
    | non-escape-chars
    | newline
    | \
    | ""

token verbatim-string = @" verbatim-string-char * "

token bytechar = ' simple-or-escape-char 'B
token bytearray = " string-char * "B
token verbatim-bytearray = @" verbatim-string-char * "B
token simple-or-escape-char = escape-char | simple-char
token simple-char = any char except newline,return,tab,backspace,',\,"

token triple-quoted-string = """ simple-or-escape-char* """
```

To translate a string token to a string value, the F# parser concatenates all the Unicode characters
for the `string-char` elements within the string. Strings may include `\n` as a newline character.
However, if a line ends with `\`, the newline character and any leading whitespace elements on the
subsequent line are ignored. Thus, the following gives `s` the value `"abcdef"`:

```fsharp
let s = "abc\
    def"
```
Without the backslash, the resulting string includes the newline and whitespace characters. For
example:

```fsharp
let s = "abc
    def"
```
In this case, s has the value `abc\010    def` where `\010` is the embedded control character for `\n`,
which has Unicode UTF-16 value 10.

Verbatim strings may be specified by using the `@` symbol preceding the string as in C#. For example,
the following assigns the value `"abc\def"` to `s`.

```fsharp
let s = @"abc\def"
```
String-like and character-like literals can also be specified for unsigned byte arrays (type `byte[]`).
These tokens cannot contain Unicode characters that have surrogate-pair UTF-16 encodings or UTF-
16 encodings greater than 127.

A triple-quoted string is specified by using three quotation marks (`"""`) to ensure that a string that
includes one or more escaped strings is interpreted verbatim. For example, a triple-quoted string can
be used to embed XML blobs:

```fsharp
let catalog = """
<?xml version="1.0"?>
<catalog>
    <book id="book">
        <author>Author</author>
        <title>F#</title>
        <genre>Computer</genre>
        <price>44.95</price>
        <publish_date>2012- 10 - 01</publish_date>
        <description>An in-depth look at creating applications in F#</description>
    </book>
</catalog>
"""
```
## 3.6 Symbolic Keywords

The following symbolic or partially symbolic character sequences are treated as keywords:

```fsgrammar
token symbolic-keyword =
    let! use! do! yield! return!
    | -> <-. : ( ) [ ] [< >] [| |] { }
    ' # :?> :? :> .. :: := ;; ; =
    _? ?? (*) <@ @> <@@ @@>
```
The following symbols are reserved for future use:

```fsgrammar
token reserved-symbolic-sequence =
    ~ `
```
## 3.7 Symbolic Operators

User-defined and library-defined symbolic operators are sequences of characters as shown below,
except where the sequence of characters is a symbolic keyword ([§3.6](#36-symbolic-keywords)).

```fsgrammar
regexp first-op-char = !%&*+-./<=>@^|~
regexp op-char = first-op-char |?

token quote-op-left =
    | <@ <@@

token quote-op-right =
    | @> @@>

token symbolic-op =
    |?
    | ?<-
    | first-op-char op-char *
    | quote-op-left
    | quote-op-right
```
For example, `&&&` and `|||` are valid symbolic operators. Only the operators `?` and `?<-` may start with
`?`.

The `quote-op-left` and `quote-op-right` operators are used in quoted expressions ([§6.8](#68-quoted-expressions)).

For details about the associativity and precedence of symbolic operators in expression forms, see
§4.4.

## 3.8 Numeric Literals

The lexical specification of numeric literals is as follows:

```fsgrammar
regexp digit = [0-9]
regexp hexdigit = digit | [A-F] | [a-f]
regexp octaldigit = [0-7]
regexp bitdigit = [0-1]

regexp int =
    | digit + For example, 34

regexp xint =
    | 0 (x|X) hexdigit + For example, 0x22
    | 0 (o|O) octaldigit + For example, 0o42
    | 0 (b|B) bitdigit + For example, 0b10010

token sbyte = ( int | xint ) 'y' For example, 34y
token byte = ( int | xint ) ' uy' For example, 34uy
token int16 = ( int | xint ) ' s' For example, 34s
token uint16 = ( int | xint ) ' us' For example, 34us
token int32 = ( int | xint ) ' l' For example, 34l
token uint32 = ( int | xint ) ' ul' For example, 34ul
             | ( int | xint ) ' u' For example, 34u
token nativeint = ( int | xint ) ' n' For example, 34n
token unativeint = ( int | xint ) ' un' For example, 34un
token int64 = ( int | xint ) ' L' For example, 34L
token uint64 = ( int | xint ) ' UL' For example, 34UL
             | ( int | xint ) ' uL' For example, 34uL

token ieee32 =
    | float [Ff]        For example, 3.0F or 3.0f
    | xint 'lf'         For example, 0x00000000lf
token ieee64 =
    | float             For example, 3.0
    | xint 'LF'         For example, 0x0000000000000000LF

token bignum = int ('Q' | ' R' | 'Z' | 'I' | 'N' | 'G')
                        For example, 34742626263193832612536171N

token decimal = ( float | int ) [Mm]

token float =
    digit +. digit *
    digit + (. digit * )? (e|E) (+|-)? digit +
```
### 3.8.1 Post-filtering of Adjacent Prefix Tokens

Negative integers are specified using the `–` token; for example, `-3`. The token steam is post-filtered
according to the following rules:

- If the token stream contains the adjacent tokens `– token`:

  If `token` is a constant numeric literal, the pair of tokens is merged. For example, adjacent tokens
  `-` and `3` becomes the single token `-3`. Otherwise, the tokens remain separate. However the `-`
  token is marked as an `ADJACENT_PREFIX_OP` token.

  This rule does not apply to the sequence `token1 - token2`, if all three tokens are adjacent and
  `token1` is a terminating token from expression forms that have lower precedence than the
  grammar production `expr = MINUS expr`.

  For example, the `–` and `b` tokens in the following sequence are not merged if all three tokens
  are adjacent:

```fsharp
    a-b
```
- Otherwise, the usual grammar rules apply to the uses of `–` and `+`, with an addition for
  `ADJACENT_PREFIX_OP`:

```fsgrammar
  expr = expr MINUS expr
      | MINUS expr
      | ADJACENT_PREFIX_OP expr
```

### 3.8.2 Post-filtering of Integers Followed by Adjacent “..”

Tokens of the form

```fsgrammar
token intdotdot = int..
```
such as `34..` are post-filtered to two tokens: one `int` and one `symbolic-keyword` , “`..`”.

This rule allows “`..`” to immediately follow an integer. This construction is used in expressions of the
form `[for x in 1..2 -> x + x ]`. Without this rule, the longest-match rule would consider this
sequence to be a floating-point number followed by a “`.`”.

### 3.8.3 Reserved Numeric Literal Forms

The following token forms are reserved for future numeric literal formats:

```fsgrammar
token reserved-literal-formats =
    | (xint | ieee32 | ieee64) ident-char+
```
### 3.8.4 Shebang

A shebang (#!) directive may exist at the beginning of F# source files. Such a line is treated as a
comment. This allows F# scripts to be compatible with the Unix convention whereby a script
indicates the interpreter to use by providing the path to that interpreter on the first line, following
the #! directive.

```fsharp
#!/bin/usr/env fsharpi --exec
```
## 3.9 Line Directives

Line directives adjust the source code filenames and line numbers that are reported in error
messages, recorded in debugging symbols, and propagated to quoted expressions. F# supports the
following line directives:

```fsgrammar
token line-directive =
    # int
    # int string
    # int verbatim-string
    #line int
    #line int string
    #line int verbatim-string
```
A line directive applies to the line that immediately follows the directive. If no line directive is
present, the first line of a file is numbered 1.

## 3.10 Hidden Tokens

Some hidden tokens are inserted by lexical filtering (§ 15 ) or are used to replace existing tokens. See
§ 15 for a full specification and for the augmented grammar rules that take these into account.


## 3.11 Identifier Replacements

The following table lists identifiers that are automatically replaced by expressions.

| Identifier | Replacement |
| --- | --- |
| `__SOURCE_DIRECTORY__` | A literal verbatim string that specifies the name of the directory that contains the <br> current file. For example:<br>`C:\source`<br>The name of the current file is derived from the most recent line directive in the file. If no line directive has appeared, the name is derived from the name that was specificed to the command-line compiler in combination with<br> `System.IO.Path.GetFullPath`.<br> In F# Interactive, the name `stdin` is used. When F# Interactive is used from tools such as Visual Studio, a line directive is implicitly added before the interactive execution of each script fragment. |
| `__SOURCE_FILE__` | A literal verbatim string that contains the name of the current file. For example:<br>`file.fs` |
| `__LINE__`| A literal string that specifies the line number in the source file, after taking into account adjustments from line directives. |
# 4. Basic Grammar Elements

This section defines grammar elements that are used repeatedly in later sections.

## 4.1 Operator Names

Several places in the grammar refer to an `ident-or-op` rather than an `ident` :

```fsgrammar
ident-or-op :=
    | ident
    | ( op-name )
    | (*)
op-name :=
    | symbolic-op
    | range-op-name
    | active-pattern-op-name
range-op-name :=
    | ..
    | .. ..
active-pattern-op-name :=
    | | ident | ... | ident |
    | | ident | ... | ident | _ |
```
In operator definitions, the operator name is placed in parentheses. For example:

```fsgrammar
let (+++) x y = (x, y)
```
This example defines the binary operator `+++`. The text `(+++)` is an `ident-or-op` that acts as an
identifier with associated text `+++`. Likewise, for active pattern definitions (§ 7), the active pattern
case names are placed in parentheses, as in the following example:

```fsgrammar
let (|A|B|C|) x = if x < 0 then A elif x = 0 then B else C
```
Because an `ident-or-op` acts as an identifier, such names can be used in expressions. For example:

```fsgrammar
List.map ((+) 1) [ 1; 2; 3 ]
```
The three character token `(*)` defines the `*` operator:

```fsgrammar
let (*) x y = (x + y)
```
To define other operators that begin with `*`, whitespace must follow the opening parenthesis;
otherwise `(*` is interpreted as the start of a comment:

```fsgrammar
let ( *+* ) x y = (x + y)
```

Symbolic operators and some symbolic keywords have a compiled name that is visible in the
compiled form of F# programs. The compiled names are shown below.

```fsgrammar
[]    op_Nil
::    op_ColonColon
+     op_Addition
-     op_Subtraction
*     op_Multiply
/     op_Division
**    op_Exponentiation
@     op_Append
^     op_Concatenate
%     op_Modulus
&&&   op_BitwiseAnd
|||   op_BitwiseOr
^^^   op_ExclusiveOr
<<<   op_LeftShift
~~~   op_LogicalNot
>>>   op_RightShift
~+    op_UnaryPlus
~-    op_UnaryNegation
=     op_Equality
<>    op_Inequality
<=    op_LessThanOrEqual
>=    op_GreaterThanOrEqual
<     op_LessThan
>     op_GreaterThan
?     op_Dynamic
?<-   op_DynamicAssignment
|>    op_PipeRight
||>   op_PipeRight2
|||>  op_PipeRight3
<|    op_PipeLeft
<||   op_PipeLeft2
<|||  op_PipeLeft3
!     op_Dereference
>>    op_ComposeRight
<<    op_ComposeLeft
<@ @> op_Quotation
<@@ @@> op_QuotationUntyped
~%    op_Splice
~%%   op_SpliceUntyped
~&    op_AddressOf
~&&   op_IntegerAddressOf
||    op_BooleanOr
&&    op_BooleanAnd
+=    op_AdditionAssignment
- =   op_SubtractionAssignment
*=    op_MultiplyAssignment
/=    op_DivisionAssignment
..    op_Range
.. .. op_RangeStep
```

Compiled names for other symbolic operators are `op_N1` ... `Nn` where `N1` to `Nn` are the names for the
characters as shown in the table below. For example, the symbolic identifier `<*` has the compiled
name `op_LessMultiply`:

```fsgrammar
>   Greater
<   Less
+   Plus
-   Minus
*   Multiply
=   Equals
~   Twiddle
%   Percent
.   Dot
&   Amp
|   Bar
@   At
#   Hash
^   Hat
!   Bang
?   Qmark
/   Divide
.   Dot
:   Colon
(   LParen
,   Comma
)   RParen
[   LBrack
]   RBrack
```

## 4.2 Long Identifiers

Long identifiers `long-ident` are sequences of identifiers that are separated by ‘`.`’ and optional
whitespace. Long identifiers `long-ident-or-op` are long identifiers that may terminate with an
operator name.

```fsgrammar
long-ident := ident '.' ... '.' ident
long-ident-or-op :=
    | long-ident '.' ident-or-op
    | ident-or-op
```
## 4.3 Constants

The constants in the following table may be used in patterns and expressions. The individual lexical
formats for the different constants are defined in [§3.](#3-lexical-analysis)

```fsgrammar
const :=
    | sbyte
    | int16
    | int32
    | int64                 -- 8, 16, 32 and 64-bit signed integers
    | byte
    | uint16
    | uint32
    | int                   -- 32 - bit signed integer
    | uint64                -- 8, 16, 32 and 64-bit unsigned integers
    | ieee32                -- 32 - bit number of type "float32"
    | ieee64                -- 64 - bit number of type "float"
    | bignum                -- User or library-defined integral literal type
    | char                  -- Unicode character of type "char"
    | string v              -- String of type "string" (System.String)
    | verbatim-string       -- String of type "string" (System.String)
    | triple-quoted-string  -- String of type "string" (System.String)
    | bytestring            -- String of type "byte[]"
    | verbatim-bytearray    -- String of type "byte[]"
    | bytechar              -- Char of type "byte"
    | false | true          -- Boolean constant of type "bool"
    | '(' ')'               -- unit constant of type "unit"
```
## 4.4 Operators and Precedence

### 4.4.1 Categorization of Symbolic Operators

The following `symbolic-op` tokens can be used to form prefix and infix expressions. The marker `OP`
represents all `symbolic-op` tokens that begin with the indicated prefix, except for tokens that appear
elsewhere in the table.

```fsgrammar
infix-or-prefix-op :=
    +, -, +., -., %, &, &&
prefix-op :=
    infix-or-prefix-op
    ~ ~~ ~~~    (and any repetitions of ~)
    !OP         (except !=)
infix-op :=
    infix-or-prefix-op
    - OP +OP || <OP >OP = |OP &OP ^OP *OP /OP %OP !=
                (or any of these preceded by one or more ‘.’)
    :=
    ::
    $
    or
    ?
```

The operators `+`, `-`, `+.`, `-.`, `%`, `%%`, `&`, `&&` can be used as both prefix and infix operators. When these
operators are used as prefix operators, the tilde character is prepended internally to generate the
operator name so that the parser can distinguish such usage from an infix use of the operator. For
example, `-x` is parsed as an application of the operator `~-` to the identifier `x`. This generated name is
also used in definitions for these prefix operators. Consequently, the definitions of the following
prefix operators include the `~` character:

```fsgrammar
// To completely redefine the prefix + operator:
let (~+) x = x
```
```fsgrammar
// To completely redefine the infix + operator to be addition modulo- 7
let (+) a b = (a + b) % 7
```
```fsgrammar
// To define the operator on a type:
type C(n:int) =
let n = n % 7
    member x.N = n
    static member (~+) (x:C) = x
    static member (~-) (x:C) = C(-n)
    static member (+) (x1:C,x2:C) = C(x1.N+x2.N)
    static member (-) (x1:C,x2:C) = C(x1.N-x2.N)
```
The `::` operator is special. It represents the union case for the addition of an element to the head of
an immutable linked list, and cannot be redefined, although it may be used to form infix expressions.
It always accepts arguments in tupled form — as do all union cases — rather than in curried form.

### 4.4.2 Precedence of Symbolic Operators and Pattern/Expression Constructs

Rules of precedence control the order of evaluation for ambiguous expression and pattern
constructs. Higher precedence items are evaluated before lower precedence items.

The following table shows the order of precedence, from highest to lowest, and indicates whether
the operator or expression is associated with the token to its left or right. The `OP` marker represents
the `symbolic-op` tokens that begin with the specified prefix, except those listed elsewhere in the
table. For example, `+OP` represents any token that begins with a plus sign, unless the token appears
elsewhere in the table.

| Operator or expression | Associativity | Comments |
| --- | --- | --- |
| f<types> | Left | High-precedence type application; see [§15.3](lexical-filtering.md#lexical-analysis-of-type-applications)
| f(x) | Left | High-precedence application; see [§15.2](lexical-filtering.md#high-precedence-application)
| . | Left |
| _prefix-op_ | Left | Applies to prefix uses of these symbols |
| "| rule" | Right Pattern matching rules |
| "f x" <br> "lazy x" <br> "assert x" | Left | |
| **OP | Right | |
| *OP /OP %OP | Left |
| - OP +OP | Left | Applies to infix uses of these symbols |
| :? | Not associative
| :: | Right | |
| ^OP | Right | |
| !=OP \<OP \>OP = \|OP &OP $ | Left |
| :> :?> | Right |  |
| & && | Left |
| or \|\| | Left |
| , | Not associative
| := | Right |  |
| -> | Right |  |
| if | Not associative
| function, fun, match, try | Not associative
| let | Not associative
| ; | Right |  |
| \| | Left |
| when | Right |  |
| as | Right |  |

If ambiguous grammar rules (such as the rules from §6) involve tokens in the table, a construct that
appears earlier in the table has higher precedence than a construct that appears later in the table.

The associativity indicates whether the operator or construct applies to the item to the left or the
right of the operator.

For example, consider the following token stream:

```fsharp
a + b * c
```
In this expression, the `expr infix-op expr` rule for `b * c` takes precedence over the 
`expr infix-op expr` rule for `a + b`, because the `*` operator has higher precedence than the `+` operator. Thus, this
expression can be pictured as follows:

```fsharp
a + b * c
```
rather than

```fsharp
a + b * c
```
Likewise, given the tokens

```fsharp
a * b * c
```
the left associativity of `*` means we can picture the resolution of the ambiguity as:

```fsharp
a * b * c
```
In the preceding table, leading `.` characters are ignored when determining precedence for infix
operators. For example, `.*` has the same precedence as `*.` This rule ensures that operators such as
`.*`, which is frequently used for pointwise-operation on matrices, have the expected precedence.

The table entries marked as “High-precedence application” and “High-precedence type application”
are the result of the augmentation of the lexical token stream, as described in §15.2 and [§15.3](lexical-filtering.md#lexical-analysis-of-type-applications).
# 5. Types and Type Constraints

The notion of _type_ is central to both the static checking of F# programs and to dynamic type tests
and reflection at runtime. The word is used with four distinct but related meanings:

- **Type definitions,** such as the actual CLI or F# definitions of `System.String` or
  `FSharp.Collections.Map<_,_>`.
- **Syntactic types,** such as the text `option<_>` that might occur in a program text. Syntactic types
  are converted to static types during the process of type checking and inference.
- **Static types** , which result from type checking and inference, either by the translation of syntactic
  types that appear in the source text, or by the application of constraints that are related to
  particular language constructs. For example, `option<int>` is the fully processed static type that is
  inferred for an expression `Some(1+1)`. Static types may contain `type variables` as described later
  in this section.
- **Runtime types** , which are objects of type `System.Type` and represent some or all of the
  information that type definitions and static types convey at runtime. The `obj.GetType()` method,
  which is available on all F# values, provides access to the runtime type of an object. An object’s
  runtime type is related to the static type of the identifiers and expressions that correspond to
  the object. Runtime types may be tested by built-in language operators such as `:?` and `:?>`, the
  expression form downcast `expr` , and pattern matching type tests. Runtime types of objects do
  not contain type variables. Runtime types that `System.Reflection` reports may contain type
  variables that are represented by `System.Type` values.

The following describes the syntactic forms of types as they appear in programs:

```fsgrammar
type :=
    ( type )
    type - > type         -- function type
    type * ... * type     -- tuple type
    typar                 -- variable type
    long-ident            -- named type, such as int
    long-ident <type-args>        -- named type, such as list<int>
    long-ident < >        -- named type, such as IEnumerable< >
    type long-ident       -- named type, such as int list
    type [ , ... , ]      -- array type
    type typar-defns      -- type with constraints
    typar :> type         -- variable type with subtype constraint
    # type                -- anonymous type with subtype constraint

type-args := type-arg , ..., type-arg

type-arg :=
    type                  -- type argument
    measure               -- unit of measure argument
    static-parameter      -- static parameter

atomic-type :=
    type : one of
            #type typar ( type ) long-ident long-ident <type-args>

typar :=
    _                     -- anonymous variable type
    ' ident               -- type variable
    ^ ident               -- static head-type type variable

constraint :=
    typar :> type         -- coercion constraint
    typar : null          -- nullness constraint
    static-typars : ( member-sig ) -- member "trait" constraint
    typar : (new : unit -> 'T) -- CLI default constructor constraint
    typar : struct        -- CLI non-Nullable struct
    typar : not struct    -- CLI reference type
    typar : enum< type >  -- enum decomposition constraint
    typar : unmanaged     -- unmanaged constraint
    typar : delegate<type, type> -- delegate decomposition constraint
    typar : equality
    typar : comparison

typar-defn := attributes opt typar

typar-defns := < typar-defn, ..., typar-defn typar-constraints opt >

typar-constraints := when constraint and ... and constraint

static-typars :=
    ^ ident
    (^ ident or ... or ^ ident )

member-sig := <see Section 10>
```

In a type instantiation, the type name and the opening angle bracket must be syntactically adjacent
with no intervening whitespace, as determined by lexical filtering (15). Specifically:

```fsharp
array<int>
```

and not

```fsharp
array < int >
```

## 5.1 Checking Syntactic Types

Syntactic types are checked and converted to static types as they are encountered. Static types are a
specification device used to describe

- The process of type checking and inference.
- The connection between syntactic types and the execution of F# programs.

Every expression in an F# program is given a unique inferred static type, possibly involving one or
more explicit or implicit generic parameters.

For the remainder of this specification we use the same syntax to represent syntactic types and
static types. For example `int32 * int32` is used to represent the syntactic type that appears in
source code and the static type that is used during checking and type inference.

The conversion from syntactic types to static types happens in the context of a name resolution
environment (see [§14.1](inference-procedures.md#name-resolution)), a floating type variable environment, which is a mapping from names to type
variables, and a type inference environment (see [§14.5](inference-procedures.md#constraint-solving)).

The phrase “fresh type” means a static type that is formed from a `fresh type inference variable`. Type
inference variables are either solved or generalized by type inference ([§14.5](inference-procedures.md#constraint-solving)). During conversion and
throughout the checking of types, expressions, declarations, and entire files, a set of `current
inference constraints` is maintained. That is, each static type is processed under input constraints `Χ` ,
and results in output constraints `Χ’`. Type inference variables and constraints are progressively
`simplified` and `eliminated` based on these equations through `constraint solving` ([§14.5](inference-procedures.md#constraint-solving)).

### 5.1.1 Named Types

`Named types` have several forms, as listed in the following table.

| **Form**                   | **Description**                                                                                                                                                                                                      |
|----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `long-ident <ty1,...,tyn>` | Named type with one or more suffixed type arguments.                                                                                                                                                                 |
| `long-ident`               | Named type with no type arguments                                                                                                                                                                                    |
| `type long-ident`          | Named type with one type argument; processed the same as `long-ident<type>`                                                                                                                                          |
| `ty1 -> ty2`               | A function type, where: <br> ▪ ty1 is the domain of the function values associated with the type<br> ▪ ty2 is the range.<br>In compiled code it is represented by the named type<br>`FSharp.Core.FastFunc<ty1,ty2>`. |

Named types are converted to static types as follows:

- Name Resolution for Types (see [§14.1](inference-procedures.md#name-resolution)) resolves `long-ident` to a type definition with formal generic
  parameters `<typar1,...,typarn>` and formal constraints `C`. The number of type arguments `n` is
  used during the name resolution process to distinguish between similarly named types that take
  different numbers of type arguments.
- Fresh type inference variables `<ty'1,...,ty'n>` are generated for each formal type parameter. The
  formal constraints `C` are added to the current inference constraints for the new type inference
  variables; and constraints `tyi = ty'i` are added to the current inference constraints.

### 5.1.2 Variable Types

A type of the form `'ident` is a variable type. For example, the following are all variable types:

```fsharp
'a
'T
'Key
```

During checking, Name Resolution (see [§14.1](inference-procedures.md#name-resolution)) is applied to the identifier.

- If name resolution succeeds, the result is a variable type that refers to an existing declared type
  parameter.
- If name resolution fails, the current floating type variable environment is consulted, although
  only in the context of a syntactic type that is embedded in an expression or pattern. If the type
  variable name is assigned a type in that environment, F# uses that mapping. Otherwise, a fresh

type inference variable is created (see [§14.5](inference-procedures.md#constraint-solving)) and added to both the type inference environment
and the floating type variable environment.

A type of the form `_` is an anonymous variable type. A fresh type inference variable is created and
added to the type inference environment (see [§14.5](inference-procedures.md#constraint-solving)) for such a type.

A type of the form `^ident` is a `statically resolved type variable`. A fresh type inference variable is
created and added to the type inference environment (see [§14.5](inference-procedures.md#constraint-solving)). This type variable is tagged with
an attribute that indicates that it can be generalized only at `inline` definitions (see [§14.6.7](inference-procedures.md#generalization)). The
same restriction on generalization applies to any type variables that are contained in any type that is
equated with the `^ident` type in a type inference equation.

> Note: This specification generally uses uppercase identifiers such as `'T` or `'Key` for user-declared generic type parameters,
 and uses lowercase identifiers such as `'a` or `'b` for compiler-inferred generic parameters.

### 5.1.3 Tuple Types

A tuple type has the following form:

```fsgrammar
ty 1 * ... * tyn
```

The elaborated form of a tuple type is shorthand for a use of the family of F# library types
`System.Tuple<_,...,_>`. (see [§6.3.2](#632-tuple-expressions)) for the details of this encoding.

When considered as static types, tuple types are distinct from their encoded form. However, the
encoded form of tuple types is visible in the F# type system through runtime types. For example,
`typeof<int * int>` is equivalent to `typeof<System.Tuple<int,int>>`.

### 5.1.4 Array Types

Array types have the following forms:

```fsgrammar
ty []
ty [ , ... , ]
```

A type of the form `ty []` is a single-dimensional array type, and a type of the form `ty[ , ... , ]` is a
multidimensional array type. For example, `int[,,]` is an array of integers of rank 3.

Except where specified otherwise in this document, these array types are treated as named types, as
if they are an instantiation of a fictitious type definition `System.Arrayn<ty>` where `n` corresponds to
the rank of the array type.

> Note: The type `int[][,]` in F# is the same as the type `int[,][]` in C# although the
dimensions are swapped. This ensures consistency with other postfix type names in F# such as `int list list`.

F# supports multidimensional array types only up to rank 4.

### 5.1.5 Constrained Types

A type with constraints has the following form:

```fsgrammar
type when constraints
```

During checking, `type` is first checked and converted to a static type, then `constraints` are checked
and added to the current inference constraints. The various forms of constraints are described
in (see [§5.2](#52-type-constraints))

A type of the form `typar :> type` is a type variable with a subtype constraint and is equivalent to
`typar when typar :> type`.

A type of the form `#type` is an anonymous type with a subtype constraint and is equivalent to `'a
when 'a :> type` , where `'a` is a fresh type inference variable.

## 5.2 Type Constraints

A `type constraint `limits the types that can be used to create an instance of a type parameter or type
variable. F# supports the following type constraints:

- Subtype constraints
- Nullness constraints
- Member constraints
- Default constructor constraints
- Value type constraints
- Reference type constraints
- Enumeration constraints
- Delegate constraints
- Unmanaged constraints
- Equality and comparison constraints

### 5.2.1 Subtype Constraints

An `explicit subtype constraint` has the following form:

```fsgrammar
typar :> type
```

During checking, `typar` is first checked as a variable type, `type` is checked as a type, and the
constraint is added to the current inference constraints. Subtype constraints affect type coercion as
specified in (see [§5.4.7](#547-subtyping-and-coercion))

Note that subtype constraints also result implicitly from:

- Expressions of the form `expr :> type`.
- Patterns of the form `pattern :> type`.
- The use of generic values, types, and members with constraints.
- The implicit use of subsumption when using values and members (see [§14.4.3](inference-procedures.md#implicit-insertion-of-flexibility-for-uses-of-functions-and-members)).

A type variable cannot be constrained by two distinct instantiations of the same named type. If two
such constraints arise during constraint solving, the type instantiations are constrained to be equal.
For example, during type inference, if a type variable is constrained by both `IA<int>` and `IA<string>`,
an error occurs when the type instantiations are constrained to be equal. This limitation is
specifically necessary to simplify type inference, reduce the size of types shown to users, and help
ensure the reporting of useful error messages.

### 5.2.2 Nullness Constraints

An `explicit nullness constraint` has the following form:

```fsgrammar
typar : null
```

During checking, `typar` is checked as a variable type and the constraint is added to the current
inference constraints. The conditions that govern when a type satisfies a nullness constraint are
specified in (see [§5.4.8](#548-nullness))

In addition:

- The `typar` must be a statically resolved type variable of the form `^ident`. This limitation ensures
  that the constraint is resolved at compile time, and means that generic code may not use this
  constraint unless that code is marked inline (see [§14.6.7](inference-procedures.md#generalization)).

> Note: Nullness constraints are primarily for use during type checking and are used relatively rarely in F# code.
<br>
Nullness constraints also arise from expressions of the form null.

### 5.2.3 Member Constraints

An `explicit member constraint` has the following form:

```fsgrammar
( typar or ... or typar ) : ( member-sig )
```

For example, the F# library defines the + operator with the following signature:

```fsharp
val inline (+) : ^a -> ^b -> ^c
    when (^a or ^b) : (static member (+) : ^a * ^b -> ^c)
```

This definition indicates that each use of the `+` operator results in a constraint on the types that
correspond to parameters `^a`, `^b`, and `^c`. If these are named types, then either the named type for
`^a` or the named type for `^b` must support a static member called `+` that has the given signature.

In addition:

- Each `typar` must be a statically resolved type variable (see [§5.1.2](#512-variable-types)) in the form `^ident`. This ensures
  that the constraint is resolved at compile time against a corresponding named type. It also
  means that generic code cannot use this constraint unless that code is marked inline (see [§14.6.7](inference-procedures.md#generalization)).
- The `member-sig` cannot be generic; that is, it cannot include explicit type parameter definitions.
- The conditions that govern when a type satisfies a member constraint are specified in (see [§14.5.4](inference-procedures.md#solving-member-constraints)).

> Note: Member constraints are primarily used to define overloaded functions in the F# library and are used relatively rarely in F# code.<br>
Uses of overloaded operators do not result in generalized code unless definitions are marked as inline. For example, the function<br><br> `let f x = x + x`<br><br>
results in a function `f` that can be used only to add one type of value, such as `int` or `float`. The exact type is determined by later constraints.

A type variable may not be involved in the support set of more than one member constraint that has
the same name, staticness, argument arity, and support set (see [§14.5.4](inference-procedures.md#solving-member-constraints)). If it is, the argument and
return types in the two member constraints are themselves constrained to be equal. This limitation
is specifically necessary to simplify type inference, reduce the size of types shown to users, and
ensure the reporting of useful error messages.

### 5.2.4 Default Constructor Constraints

An `explicit default constructor constraint` has the following form:

```fsgrammar
typar : (new : unit -> 'T)
```

During constraint solving (see [§14.5](inference-procedures.md#constraint-solving)), the constraint `type : (new : unit -> 'T)` is met if `type` has a
parameterless object constructor.

> Note: This constraint form exists primarily to provide the full set of constraints that CLI implementations allow. It is rarely used in F# programming.

### 5.2.5 Value Type Constraints

An `explicit value type constraint` has the following form:

```fsgrammar
typar : struct
```

During constraint solving (see [§14.5](inference-procedures.md#constraint-solving)), the constraint `type` : struct is met if `type` is a value type other
than the CLI type `System.Nullable<_>`.

> Note: This constraint form exists primarily to provide the full set of constraints that CLI
implementations allow. It is rarely used in F# programming.<br><br>
The restriction on `System.Nullable` is inherited from C# and other CLI languages, which
give this type a special syntactic status. In F#, the type `option<_>` is similar to some uses
of `System.Nullable<_>`. For various technical reasons the two types cannot be equated,
notably because types such as `System.Nullable<System.Nullable<_>>` and `System.Nullable<string>` are not valid CLI types.

### 5.2.6 Reference Type Constraints

An `explicit reference type constraint` has the following form:

```fsgrammar
typar : not struct
```

During constraint solving (see [§14.5](inference-procedures.md#constraint-solving)), the constraint `type : not struct` is met if `type` is a reference type.

> Note: This constraint form exists primarily to provide the full set of constraints that CLI implementations allow. It is rarely used in F# programming.

### 5.2.7 Enumeration Constraints

An `explicit enumeration constraint` has the following form:

```fsgrammar
typar : enum<underlying-type>
```

During constraint solving (see [§14.5](inference-procedures.md#constraint-solving)), the constraint `type : enum<underlying-type>` is met if `type` is a CLI
or F# enumeration type that has constant literal values of type `underlying-type`.

> Note: This constraint form exists primarily to allow the definition of library functions such as `enum`. It is rarely used directly in F# programming.<br>
The `enum` constraint does not imply anything about subtypes. For example, an `enum` constraint does not imply that the type is a subtype of `System.Enum`.

### 5.2.8 Delegate Constraints

An `explicit delegate constraint` has the following form:

```fsgrammar
typar : delegate< tupled-arg-type , return-type>
```

During constraint solving (see [§14](inference-procedures.md#inference-procedures) .5), the constraint `type : delegate<tupled-arg-type, return-types>`
is met if `type` is a delegate type `D` with declaration `type D = delegate of object * arg1 * ... *
argN` and `tupled-arg-type = arg1 * ... * argN.` That is, the delegate must match the CLI design
pattern where the sender object is the first argument to the event.

> Note: This constraint form exists primarily to allow the definition of certain F# library
functions that are related to event programming. It is rarely used directly in F#
programming.<br><br>
The `delegate` constraint does not imply anything about subtypes. In particular, a
`delegate` constraint does not imply that the type is a subtype of `System.Delegate`.<br><br>
The `delegate` constraint applies only to delegate types that follow the usual form for CLI
event handlers, where the first argument is a `sender` object. The reason is that the
purpose of the constraint is to simplify the presentation of CLI event handlers to the F#
programmer.

### 5.2.9 Unmanaged Constraints

An `unmanaged constraint` has the following form:

```fsgrammar
typar : unmanaged
```

During constraint solving (see [§14.5](inference-procedures.md#constraint-solving)), the constraint `type : unmanaged` is met if `type` is unmanaged as
specified below:

- Types sbyte, `byte`, `char`, `nativeint`, `unativeint`, `float32`, `float`, `int16`, `uint16`, `int32`, `uint32`,
  `int64`, `uint64`, `decimal` are unmanaged.
- Type `nativeptr<type>` is unmanaged.
- A non-generic struct type whose fields are all unmanaged types is unmanaged.

### 5.2.10 Equality and Comparison Constraints

`Equality constraints` and `comparison constraints` have the following forms, respectively:

```fsgrammar
typar : equality
typar : comparison
```

During constraint solving (see [§14.5](inference-procedures.md#constraint-solving)), the constraint `type : equality` is met if both of the following
conditions are true:

- The type is a named type, and the type definition does not have, and is not inferred to have, the
  `NoEquality` attribute.
- The type has `equality` dependencies `ty1,..., tyn`, each of which satisfies `tyi: equality`.

The constraint `type : comparison` is a `comparison constraint`. Such a constraint is met if all the
following conditions hold:

- If the type is a named type, then the type definition does not have, and is not inferred to have,
  the `NoComparison` attribute, and the type definition implements `System.IComparable` or is an
  array type or is `System.IntPtr` or is `System.UIntPtr`.
- If the type has `comparison dependencies` `ty1, ..., tyn` , then each of these must satisfy `tyi :
  comparison`

An equality constraint is a relatively weak constraint, because with two exceptions, all CLI types
satisfy this constraint. The exceptions are F# types that are annotated with the `NoEquality` attribute
and structural types that are inferred to have the `NoEquality` attribute. The reason is that in other
CLI languages, such as C#, it possible to use reference equality on all reference types.

A comparison constraint is a stronger constraint, because it usually implies that a type must
implement `System.IComparable`.

## 5.3 Type Parameter Definitions

Type parameter definitions can occur in the following locations:

- Value definitions in modules
- Member definitions
- Type definitions
- Corresponding specifications in signatures

For example, the following defines the type parameter ‘T in a function definition:

```fsharp
let id<'T> (x:'T) = x
```

Likewise, in a type definition:

```fsharp
type Funcs<'T1,'T2> =
    { Forward: 'T1 -> 'T2
      Backward : 'T2 -> 'T2 }
```

Likewise, in a signature file:

```fsharp
val id<'T> : 'T -> 'T
```

Explicit type parameter definitions can include `explicit constraint declarations`. For example:

```fsharp
let dispose2<'T when 'T :> System.IDisposable> (x: 'T, y: 'T) =
x.Dispose()
y.Dispose()
```

The constraint in this example requires that `'T` be a type that supports the `IDisposable` interface.

However, in most circumstances, declarations that imply subtype constraints on arguments can be
written more concisely:

```fsharp
let throw (x: Exception) = raise x
```

Multiple explicit constraint declarations use and:

```fsharp
let multipleConstraints<'T when 'T :> System.IDisposable and
                                'T :> System.IComparable > (x: 'T, y: 'T) =
    if x.CompareTo(y) < 0 then x.Dispose() else y.Dispose()
```

Explicit type parameter definitions can declare custom attributes on type parameter definitions
(see [§13.1](custom-attributes-and-reflection.md#custom-attributes)).

## 5.4 Logical Properties of Types

During type checking and elaboration, syntactic types and constraints are processed into a reduced
form composed of:

- Named types `op<types>`, where each `op` consists of a specific type definition, an operator to form
  function types, an operator to form array types of a specific rank, or an operator to form specific
  `n-tuple` types.
- Type variables `'ident`.

### 5.4.1 Characteristics of Type Definitions

Type definitions include CLI type definitions such as `System.String` and types that are defined in F#
code (see [§8](type-definitions.md#type-definitions)). The following terms are used to describe type definitions:

- Type definitions may be `generic` , with one or more type parameters; for example,
  `System.Collections.Generic.Dictionary<'Key,'Value>`.
- The generic parameters of type definitions may have associated `formal type constraints`.
- Type definitions may have `custom attributes` (see [§13.1](custom-attributes-and-reflection.md#custom-attributes)), some of which are relevant to checking and
  inference.
- Type definitions may be `type abbreviations` (see [§8.3](type-definitions.md#type-abbreviations)). These are eliminated for the purposes of
  checking and inference (see [§5.4.2](#542-expanding-abbreviations-and-inference-equations)).

- Type definitions have a `kind` which is one of the following:
    - `Class`
    - `Interface`
    - `Delegate`
    - `Struct`
    - `Record`
    - `Union`
    - `Enum`
    - `Measure`
    - `Abstract`

The kind is determined at the point of declaration by Type Kind Inference (see [§8.2](type-definitions.md#type-kind-inference)) if it is not
specified explicitly as part of the type definition. The kind of a type refers to the kind of its
outermost named type definition, after expanding abbreviations. For example, a type is a class
type if it is a named type `C<types>` where `C` is of kind class. Thus,
`System.Collections.Generic.List<int>` is a class type.

- Type definitions may be `sealed`. `Record`, `union`, `function`, `tuple`, `struct`, `delegate`, `enum`, and `array`
  types are all sealed, as are class types that are marked with the `SealedAttribute` attribute.
- Type definitions may have zero or one `base type declarations`. Each base type declaration
  represents an additional type that is supported by any values that are formed using the type
  definition. Furthermore, some aspects of the base type are used to form the implementation of
  the type definition.
- Type definitions may have one or more `interface declarations`. These represent additional
  encapsulated types that are supported by values that are formed using the type.

Class, interface, delegate, function, tuple, record, and union types are all `reference` type definitions.
A type is a reference type if its outermost named type definition is a reference type, after expanding
type definitions.

Struct types are `value types`.

### 5.4.2 Expanding Abbreviations and Inference Equations

Two static types are considered equivalent and indistinguishable if they are equivalent after taking
into account both of the following:

- The inference equations that are inferred from the current inference constraints (see [§14.5](inference-procedures.md#constraint-solving)).
- The expansion of type abbreviations (see [§8.3](type-definitions.md#type-abbreviations)).

For example, static types may refer to type abbreviations such as `int`, which is an abbreviation for
`System.Int32` and is declared by the F# library:

```fsharp
type int = System.Int32
```

This means that the types `int32` and `System.Int32` are considered equivalent, as are `System.Int32 -> int` and `int -> System.Int32`.

Likewise, consider the process of checking this function:

```fsharp
let checkString (x:string) y =
    (x = y), y.Contains("Hello")
```

During checking, fresh type inference variables are created for values `x` and `y`; let’s call them `ty1` and
`ty2`. Checking imposes the constraints `ty1 = string` and `ty1 = ty2`. The second constraint results
from the use of the generic `=` operator. As a result of constraint solving, `ty2 = string` is inferred, and
thus the type of `y` is `string`.

All relations on static types are considered after the elimination of all equational inference
constraints and type abbreviations. For example, we say `int` is a struct type because `System.Int32` is
a struct type.

> Note: Implementations of F# should attempt to preserve type abbreviations when
reporting types and errors to users. This typically means that type abbreviations should
be preserved in the logical structure of types throughout the checking process.

### 5.4.3 Type Variables and Definition Sites

Static types may be type variables. During type inference, static types may be `partial`, in that they
contain type inference variables that have not been solved or generalized. Type variables may also
refer to explicit type parameter definitions, in which case the type variable is said to be `rigid` and
have a `definition site`.

For example, in the following, the definition site of the type parameter 'T is the type definition of C:

```fsharp
type C<'T> = 'T * 'T
```

Type variables that do not have a binding site are `inference variables`. If an expression is composed
of multiple sub-expressions, the resulting constraint set is normally the union of the constraints that
result from checking all the sub-expressions. However, for some constructs (notably function, value
and member definitions), the checking process applies `generalization` (see [§14.6.7](inference-procedures.md#generalization)). Consequently, some
intermediate inference variables and constraints are factored out of the intermediate constraint sets
and new implicit definition site(s) are assigned for these variables.

For example, given the following declaration, the type inference variable that is associated with the
value `x` is generalized and has an implicit definition site at the definition of function `id`:

```fsharp
let id x = x
```

Occasionally in this specification we use a more fully annotated representation of inferred and
generalized type information. For example:

```fsharp
let id<'a> x'a = x'a
```

Here, `'a` represents a generic type parameter that is inferred by applying type inference and
generalization to the original source code (see [§14.6.7](inference-procedures.md#generalization)), and the annotation represents the definition site
of the type variable.

### 5.4.4 Base Type of a Type

The base type for the static types is shown in the table. These types are defined in the CLI
specifications and corresponding implementation documentation.

| **Static Type** | **Base Type**                                                                                                                                                                                        |
|-----------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Abstract types  | `System.Object`                                                                                                                                                                                      |
| All array types | `System.Array`                                                                                                                                                                                       |
| Class types     | The declared base type of the type definition if the type has one; otherwise,<br> `System.Object`. For generic types `C<type-inst>`, substitute the formal generic parameters of `C` for `type-inst` |
| Delegate types  | `System.MulticastDelegate`                                                                                                                                                                           |
| Enum types      | `System.Enum`                                                                                                                                                                                        |
| Exception types | `System.Exception`                                                                                                                                                                                   |
| Interface types | `System.Object`                                                                                                                                                                                      |
| Record types    | `System.Object`                                                                                                                                                                                      |
| Struct types    | `System.ValueType`                                                                                                                                                                                   |
| Union types     | `System.Object`                                                                                                                                                                                      |
| Variable types  | `System.Object`                                                                                                                                                                                      |

### 5.4.5 Interfaces Types of a Type

The `interface types` of a named type `C<type-inst>` are defined by the transitive closure of the
interface declarations of `C` and the interface types of the base type of `C`, where formal generic
parameters are substituted for the actual type instantiation `type-inst`.

The interface types for single dimensional array types `ty[]` include the transitive closure that starts
from the interface `System.Collections.Generic.IList<ty>`, which includes
`System.Collections.Generic.ICollection<ty>` and `System.Collections.Generic.IEnumerable<ty>`.

### 5.4.6 Type Equivalence

Two static types `ty1` and `ty2` are definitely equivalent (with respect to a set of current inference
constraints) if either of the following is true:

- `ty1` has form `op<ty11, ..., ty1n>`, `ty2` has form `op<ty21, ..., ty2n>` and each `ty1i` is
  definitely equivalent to `ty2i` for all `1` <= `i` <= `n`.

**OR**

- `ty1` and `ty2` are both variable types, and they both refer to the same definition site or are the
  same type inference variable.

This means that the addition of new constraints may make types definitely equivalent where
previously they were not. For example, given `Χ = { 'a = int }`, we have `list<int>` = `list<'a>`.

Two static types `ty1` and `ty2` are feasibly equivalent if `ty1` and `ty2` may become definitely equivalent if
further constraints are added to the current inference constraints. Thus `list<int>` and `list<'a>` are
feasibly equivalent for the empty constraint set.

### 5.4.7 Subtyping and Coercion

A static type `ty2` coerces to static type `ty1` (with respect to a set of current inference constraints X), if
`ty1` is in the transitive closure of the base types and interface types of `ty2`. Static coercion is written
with the `:>` symbol:

```fsharp
ty2 :> ty1
```

Variable types `'T` coerce to all types `ty` if the current inference constraints include a constraint of the
form `'T :> ty2`, and `ty` is in the inclusive transitive closure of the base and interface types of `ty2`.

A static type `ty2` feasibly coerces to static type `ty1` if `ty2` coerces to `ty1` may hold through the addition
of further constraints to the current inference constraints. The result of adding constraints is defined
in `Constraint Solving` (see [§14.5](inference-procedures.md#constraint-solving)).

### 5.4.8 Nullness

The design of F# aims to greatly reduce the use of null literals in common programming tasks,
because they generally result in error-prone code. However:

- The use of some `null` literals is required for interoperation with CLI libraries.
- The appearance of `null` values during execution cannot be completely precluded for technical
  reasons related to the CLI and CLI libraries.

As a result, F# types differ in their treatment of the `null` literal and `null` values. All named types and
type definitions fall into one of the following categories:

- **Types with the `null` literal.** These types have `null` as an “extra” value. The following types are in
  this category:
    - All CLI reference types that are defined in other CLI languages.
    - All types that are defined in F# and annotated with the `AllowNullLiteral` attribute.

For example, `System.String` and other CLI reference types satisfy this constraint, and these types
permit the direct use of the `null` literal.

- **Types with `null` as an abnormal value.** These types do not permit the `null` literal, but do have
  `null` as an abnormal value. The following types are in this category:
    - All F# list, record, tuple, function, class, and interface types.
    - All F# union types except those that have `null` as a normal value, as discussed in the next
      bullet point.

For types in this category, the use of the `null` literal is not directly allowed. However, strictly
speaking, it is possible to generate a `null` value for these types by using certain functions such as
`Unchecked.defaultof<type>`. For these types, `null` is considered an abnormal value. Operations
differ in their use and treatment of `null` values; for details about evaluation of expressions that
might include `null` values, see (see [§6.9](#69-evaluation-of-elaborated-forms)).

- **Types with `null` as a representation value.** These types do not permit the `null` literal but use
  the `null` value as a representation.
  For these types, the use of the null literal is not directly permitted. However, one or all of the
  “normal” values of the type is represented by the null value. The following types are in this
  category:
    - The unit type. The `null` value is used to represent all values of this type.
    - Any union type that has the
      `FSharp.Core.CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueV
      alue)` attribute flag and a single null union case. The null value represents this case. In
      particular, `null` represents `None` in the F# `option<_>` type.
- **Types without `null`.** These types do not permit the `null` literal and do not have the null value.
  All value types are in this category, including primitive integers, floating-point numbers, and any
  value of a CLI or F# `struct` type.

A static type `ty` satisfies a nullness constraint `ty : null` if it:

- Has an outermost named type that has the `null` literal.
- Is a variable type with a `typar : null` constraint.

### 5.4.9 Default Initialization

Related to nullness is the `default initialization` of values of some types to `zero values`. This technique
is common in some programming languages, but the design of F# deliberately de-emphasizes it.
However, default initialization is allowed in some circumstances:

- Checked default initialization may be used when a type is known to have a valid and “safe”
  default zero value. For example, the types of fields that are labeled with `DefaultValue(true)` are
  checked to ensure that they allow default initialization.
- CLI libraries sometimes perform unchecked default initialization, as do the F# library primitives
  `Unchecked.defaultof<_>` and `Array.zeroCreate`.

The following types `permit default initialization` :

- Any type that satisfies the nullness constraint.
- Primitive value types.
- Struct types whose field types all permit default initialization.

### 5.4.10 Dynamic Conversion Between Types

A runtime type `vty` dynamically converts to a static type `ty` if any of the following are true:

- `vty` coerces to `ty`.
- `vty` is `int32[]` and `ty` is `uint32[]`(or conversely). Likewise for `sbyte[]`/`byte[]`, `int16[]`/`uint16[]`,
  `int64[]`/`uint64[]`, and `nativeint[]`/`unativeint[]`.
- `vty` is `enum[]` where `enum` has underlying type `underlying` , and `ty` is `underlying[]` (or conversely),
  or the (un)signed equivalent of `underlying[]` by the immediately preceding rule.
- `vty` is `elemty1[]`, `ty` is `elemty2[]`, `elemty1` is a reference type, and `elemty1` converts to `elemty2`.
- `ty` is `System.Nullable<vty>`.

Note that this specification does not define the full algebra of the conversions of runtime types to
static types because the information that is available in runtime types is implementation dependent.
However, the specification does state the conditions under which objects are guaranteed to have a
runtime type that is compatible with a particular static type.

> Note: This specification covers the additional rules of CLI dynamic conversions, all of
which apply to F# types. For example:

```fsharp
let x = box [| System.DayOfWeek.Monday |]
let y = x :? int32[]
printf "%b" y // true
```

In the previous code, the type `System.DayOfWeek.Monday[]` does not statically coerce to
`int32[]`, but the expression `x :? int32[]` evaluates to true.

```fsharp
let x = box [| 1 |]
let y = x :? uint32 []
printf "%b" y // true
```

In the previous code, the type `int32[]` does not statically coerce to `uint32[]`, but the
expression `x :? uint32 []` evaluates to true.

```fsharp
let x = box [| "" |]
let y = x :? obj []
printf "%b" y // true
```

In the previous code, the type `string[]` does not statically coerce to `obj[]`, but the
expression `x :? obj []` evaluates to true.

```fsharp
let x = box 1
let y = x :? System.Nullable<int32>
printf "%b" y // true
```

In the previous code, the type `int32` does not coerce to `System.Nullable<int32>`, but the
expression `x :? System.Nullable<int32>` evaluates to true.

# 6. Expressions

The expression forms and related elements are as follows:

```fsgrammar
expr :=
    const                               -- a constant value
    ( expr )                            -- block expression
    begin expr end                      -- block expression
    long-ident-or-op                    -- lookup expression
    expr '.' long-ident-or-op           -- dot lookup expression
    expr expr                           -- application expression
    expr ( expr )                       -- high precedence application
    expr < types >                      -- type application expression
    expr infix-op expr                  -- infix application expression
    prefix-op expr                      -- prefix application expression
    expr .[ expr ]                      -- indexed lookup expression
    expr .[ slice-ranges ]              -- slice expression
    expr <- expr                        -- assignment expression
    expr , ... , expr                   -- tuple expression
    new type expr                       -- simple object expression
    { new base-call object-members interface-impls } -- object expression
    { field-initializers }              -- record expression
    { expr with field-initializers }    -- record cloning expression
    [ expr ; ... ; expr ]               -- list expression
    [| expr ; ... ; expr |]             -- array expression
    expr { comp-or-range-expr }         -- computation expression
    [ comp-or-range-expr ]              -- computed list expression
    [| comp-or-range-expr |]            -- computed array expression
    lazy expr                           -- delayed expression
    null                                -- the "null" value for a reference type
    expr : type                         -- type annotation
    expr :> type                        -- static upcast coercion
    expr :? type                        -- dynamic type test
    expr :?> type                       -- dynamic downcast coercion
    upcast expr                         -- static upcast expression
    downcast expr                       -- dynamic downcast expression
    let function-defn in expr           -- function definition expression
    let value-defn in expr              -- value definition expression
    let rec function-or-value-defns in expr -- recursive definition expression
    use ident = expr in expr            -- deterministic disposal expression
    fun argument-pats - > expr          -- function expression
    function rules                      -- matching function expression
    expr ; expr                         -- sequential execution expression
    match expr with rules               -- match expression
    try expr with rules                 -- try/with expression
    try expr finally expr               -- try/finally expression
    if expr then expr elif-branches~opt else-branch opt -- conditional expression
    while expr do expr done             -- while loop
    for ident = expr to expr do expr done -- simple for loop
    for pat in expr - or-range-expr do expr done -- enumerable for loop
    assert expr                         -- assert expression
    <@ expr @>                          -- quoted expression
    <@@ expr @@>                        -- quoted expression

    %expr                              -- expression splice
    %%expr                              -- weakly typed expression splice

    (static-typars : (member-sig) expr) -– static member invocation
```

Expressions are defined in terms of patterns and other entities that are discussed later in this
specification. The following constructs are also used:

```fsgrammar
exprs := expr ',' ... ',' expr

expr-or-range-expr :=
    expr
    range-expr

elif-branches := elif-branch ... elif-branch

elif-branch := elif expr then expr

else-branch := else expr

function-or-value-defn :=
    function-defn
    value-defn

function-defn :=
    inline opt access~opt ident-or-op typar-defns~opt argument-pats return-type~opt = expr

value-defn :=
    mutable~opt access~opt pat typar-defns~opt return-type~opt = expr

return-type :=
    : type

function-or-value-defns :=
    function-or-value-defn and ... and function-or-value-defn

argument-pats := atomic-pat ... atomic-pat

field-initializer :=
    long-ident = expr -- field initialization

field-initializers := field-initializer ; ... ; field-initializer

object-construction :=
    type expr -- construction expression
    type      -- interface construction expression

base-call :=
    object-construction          -- anonymous base construction
    object-construction as ident -- named base construction

interface-impls := interface-impl ... interface-impl

interface-impl :=
    interface type object-members~opt -- interface implementation

object-members := with member-defns end

member-defns := member-defn ... member-defn
```

Computation and range expressions are defined in terms of the following productions:

```fsgrammar
comp-or-range-expr :=
    comp-expr
    short-comp-expr
    range-expr

comp-expr :=
    let! pat = expr in comp-expr    -- binding computation
    let pat = expr in comp-expr
    do! expr in comp-expr           -- sequential computation
    do expr in comp-expr
    use! pat = expr in comp-expr    -- auto cleanup computation
    use pat = expr in comp-expr
    yield! expr                     -- yield computation
    yield expr                      -- yield result
return! expr                        -- return computation
    return expr                     -- return result
    if expr then comp - expr        -- control flow or imperative action
    if expr then expr else comp-expr
    match expr with pat -> comp-expr | ... | pat -> comp-expr
    try comp - expr with pat -> comp-expr | ... | pat -> comp-expr
    try comp - expr finally expr
    while expr do comp - expr done
    for ident = expr to expr do comp - expr done
    for pat in expr - or-range-expr do comp - expr done
    comp - expr ; comp - expr
    expr

short-comp-expr :=
    for pat in expr-or-range-expr -> expr -- yield result

range-expr :=
    expr .. expr                    -- range sequence
    expr .. expr .. expr            -- range sequence with skip

slice-ranges := slice-range , ... , slice-range

slice-range :=
    expr                            -- slice of one element of dimension
    expr ..                         -- slice from index to end
    .. expr                         -- slice from start to index
    expr .. expr                    -- slice from index to index
    '*'                             -- slice from start to end
```
## 6.1 Some Checking and Inference Terminology

The rules applied to check individual expressions are described in the following subsections. Where
necessary, these sections reference specific inference procedures such as _Name Resolution_ ([§14.1](inference-procedures.md#name-resolution))
and _Constraint Solving_ ([§14.5](inference-procedures.md#constraint-solving)).

All expressions are assigned a static type through type checking and inference. During type checking,
each expression is checked with respect to an _initial type_. The initial type establishes some of the
information available to resolve method overloading and other language constructs. We also use the
following terminology:

- The phrase “the type `ty1` is asserted to be equal to the type `ty2`” or simply “`ty1 = ty2` is asserted”
    indicates that the constraint “`ty1 = ty2`” is added to the current inference constraints.


- The phrase “`ty1` is asserted to be a subtype of `ty2`” or simply “`ty1 :> ty2` is asserted” indicates
    that the constraint `ty1 :> ty2` is added to the current inference constraints.
- The phrase “type `ty` is known to ...” indicates that the initial type satisfies the given property
    given the current inference constraints.
- The phrase “the expression `expr` has type `ty` ” means the initial type of the expression is asserted
    to be equal to `ty`.

Additionally:

- The addition of constraints to the type inference constraint set fails if it causes an inconsistent
    set of constraints ([§14.5](inference-procedures.md#constraint-solving)). In this case either an error is reported or, if we are only attempting to
    _assert_ the condition, the state of the inference procedure is left unchanged and the test fails.

## 6.2 Elaboration and Elaborated Expressions

Checking an expression generates an _elaborated expression_ in a simpler, reduced language that
effectively contains a fully resolved and annotated form of the expression. The elaborated
expression provides more explicit information than the source form. For example, the elaborated
form of `System.Console.WriteLine("Hello")` indicates exactly which overloaded method definition
the call has resolved to.
<!-- Elaborated forms are underlined in this specification, for example, <u>let x = 1 in x + x</u>. -->

Except for this extra resolution information, elaborated forms are syntactically a subset of syntactic
expressions, and in some cases (such as constants) the elaborated form is the same as the source
form. This specification uses the following elaborated forms:

- Constants
- Resolved value references: `path`
- Lambda expressions: `(fun ident -> expr)`
- Primitive object expressions
- Data expressions (tuples, union cases, array creation, record creation)
- Default initialization expressions
- Local definitions of values: `let ident = expr in expr`
- Local definitions of functions:
    `let rec ident = expr and ... and ident = expr in expr`
- Applications of methods and functions (with static overloading resolved)
- Dynamic type coercions: `expr :?> type`
- Dynamic type tests: `expr :? type`
- For-loops: `for ident in ident to ident do expr done`
- While-loops: `while expr do expr done`
- Sequencing: `expr; expr`
- Try-with: `try expr with expr`
- Try-finally: `try expr finally expr`
- The constructs required for the elaboration of pattern matching ([§7](patterns.md#patterns)).
    - Null tests
    - Switches on integers and other types
    - Switches on union cases
    - Switches on the runtime types of objects

The following constructs are used in the elaborated forms of expressions that make direct
assignments to local variables and arrays and generate “byref” pointer values. The operations are
loosely named after their corresponding primitive constructs in the CLI.

- Assigning to a byref-pointer: `expr <-stobj expr`
- Generating a byref-pointer by taking the address of a mutable value: `&path`.
- Generating a byref-pointer by taking the address of a record field: `&(expr.field)`
- Generating a byref-pointer by taking the address of an array element: `&(expr.[expr])`

Elaborated expressions form the basis for evaluation (see [§6.9](#69-evaluation-of-elaborated-forms)) and for the expression trees that
_quoted expressions_ return (see [§6.8](#68-quoted-expressions)).

By convention, when describing the process of elaborating compound expressions, we omit the
process of recursively elaborating sub-expressions.

## 6.3 Data Expressions

This section describes the following data expressions:

- Simple constant expressions
- Tuple expressions
- List expressions
- Array expressions
- Record expressions
- Copy-and-update record expressions
- Function expressions
- Object expressions
- Delayed expressions
- Computation expressions
- Sequence expressions
- Range expressions
- Lists via sequence expressions
- Arrays via sequence expressions
- Null expressions
- 'printf' formats

### 6.3.1 Simple Constant Expressions

Simple constant expressions are numeric, string, Boolean and unit constants. For example:

```fsgrammar
3y              // sbyte
32uy            // byte
17s             // int16
18us            // uint16
86              // int/int32
99u             // uint32
99999999L       // int64
10328273UL      // uint64
1.              // float/double
1.01            // float/double
1.01e10         // float/double
1.0f            // float32/single
1.01f           // float32/single
1.01e10f        // float32/single
99999999n       // nativeint    (System.IntPtr)
10328273un      // unativeint   (System.UIntPtr)
99999999I       // bigint       (System.Numerics.BigInteger or user-specified)
'a'             // char         (System.Char)
"3"             // string       (String)
"c:\\home"      // string       (System.String)
@"c:\home"      // string       (Verbatim Unicode, System.String)
"ASCII"B        // byte[]
()              // unit         (FSharp.Core.Unit)
false           // bool         (System.Boolean)
true            // bool         (System.Boolean)
```

Simple constant expressions have the corresponding simple type and elaborate to the corresponding
simple constant value.

Integer literals with the suffixes `Q`, `R`, `Z`, `I`, `N`, `G` are processed using the following syntactic translation:

```fsgrammar
xxxx<suffix>
    For xxxx = 0                → NumericLiteral<suffix>.FromZero()
    For xxxx = 1                → NumericLiteral<suffix>.FromOne()
    For xxxx in the Int32 range → NumericLiteral<suffix>.FromInt32(xxxx)
    For xxxx in the Int64 range → NumericLiteral<suffix>.FromInt64(xxxx)
    For other numbers           → NumericLiteral<suffix>.FromString("xxxx")
```
For example, defining a module `NumericLiteralZ` as below enables the use of the literal form `32Z` to
generate a sequence of 32 ‘Z’ characters. No literal syntax is available for numbers outside the range
of 32-bit integers.

```fsharp
module NumericLiteralZ =
    let FromZero() = ""
    let FromOne() = "Z"
    let FromInt32 n = String.replicate n "Z"
```
F# compilers may optimize on the assumption that calls to numeric literal functions always
terminate, are idempotent, and do not have observable side effects.

### 6.3.2 Tuple Expressions

An expression of the form `expr1 , ..., exprn` is a _tuple expression_. For example:

```fsharp
let three = (1,2,"3")
let blastoff = (10,9,8,7,6,5,4,3,2,1,0)
```
The expression has the type `(ty1 * ... * tyn)` for fresh types `ty1 ... tyn` , and each individual
expression `expri` is checked using initial type `tyi`.

Tuple types and expressions are translated into applications of a family of F# library types named
System.Tuple. Tuple types `ty1 * ... * tyn` are translated as follows:

- For `n <= 7` the elaborated form is `Tuple<ty1 ,... , tyn>`.
- For larger `n` , tuple types are shorthand for applications of the additional F# library type
    System.Tuple<_> as follows:
    - For `n = 8` the elaborated form is `Tuple<ty1, ..., ty7, Tuple<ty8>>`.
    - For `9 <= n` the elaborated form is `Tuple<ty1, ..., ty7, tyB>` where `tyB` is the converted form of
       the type `(ty8 * ... * tyn)`.

Tuple expressions `(expr1, ..., exprn)` are translated as follows:

- For `n <= 7` the elaborated form `new Tuple<ty1, ..., tyn>(expr1, ..., exprn)`.
- For `n = 8` the elaborated form `new Tuple<ty1, ..., ty7, Tuple<ty8>>(expr1, ..., expr7, new Tuple<ty8>(expr8)`.
- For `9 <= n` the elaborated form `new Tuple<ty1, ... ty7, ty8n>(expr1, ..., expr7, new ty8n(e8n)`
    where `ty8n` is the type `(ty8 * ... * tyn)` and `expr8n` is the elaborated form of the expression
    `expr8, ..., exprn`.

When considered as static types, tuple types are distinct from their encoded form. However, the
encoded form of tuple values and types is visible in the F# type system through runtime types. For
example, `typeof<int * int>` is equivalent to `typeof<System.Tuple<int,int>>`, and `(1 ,2)` has the
runtime type `System.Tuple<int,int>`. Likewise, `(1,2,3,4,5,6,7,8,9)` has the runtime type
`Tuple<int,int,int,int,int,int,int,Tuple<int,int>>`.

> Note: The above encoding is invertible and the substitution of types for type variables
preserves this inversion. This means, among other things, that the F# reflection library
can correctly report tuple types based on runtime System.Type values. The inversion is
defined by:
<br>- For the runtime type `Tuple<ty1, ..., tyN>` when `n <= 7`, the corresponding F# tuple
    type is `ty1 * ... * tyN`
<br>- For the runtime type `Tuple<ty1, ..., Tuple<tyN>>` when `n = 8`, the corresponding F#
    tuple type is `ty1 * ... * ty8`
<br>- For the runtime type `Tuple<ty1, ..., ty7, ty8n>` , if `ty8n` corresponds to the F# tuple
    type `ty8 * ... * tyN`, then the corresponding runtime type is `ty1 * ... * tyN`.<br>Runtime types of other forms do not have a corresponding tuple type. In particular,
runtime types that are instantiations of the eight-tuple type `Tuple<_, _, _, _, _, _, _, _ >`
must always have `Tuple<_>` in the final position. Syntactic types that have some other
form of type in this position are not permitted, and if such an instantiation occurs in F#
code or CLI library metadata that is referenced by F# code, an F# implementation may
report an error.

### 6.3.3 List Expressions

An expression of the form `[expr1 ; ...; exprn]` is a _list expression_. The initial type of the expression is
asserted to be `FSharp.Collections.List<ty>` for a fresh type `ty`.

If `ty` is a named type, each expression `expri` is checked using a fresh type `ty'` as its initial type, with
the constraint `ty' :> ty`. Otherwise, each expression `expri` is checked using `ty` as its initial type.

List expressions elaborate to uses of `FSharp.Collections.List<_>` as
`op_Cons(expr1 ,(op_Cons(_expr2 ... op_Cons(exprn, op_Nil) ...)` where `op_Cons` and `op_Nil` are the
union cases with symbolic names `::` and `[]` respectively.

### 6.3.4 Array Expressions

An expression of the form `[|expr1; ...; exprn|]` is an _array expression_. The initial type of the
expression is asserted to be `ty[]` for a fresh type `ty`.

If this assertion determines that `ty` is a named type, each expression `expri` is checked using a fresh
type `ty'` as its initial type, with the constraint `ty' :> ty`. Otherwise, each expression `expri` is
checked using `ty` as its initial type.

Array expressions are a primitive elaborated form.

> Note: The F# implementation ensures that large arrays of constants of type `bool`, `char`,
`byte`, `sbyte`, `int16`, `uint16`, `int32`, `uint32`, `int64`, and `uint64` are compiled to an efficient
binary representation based on a call to
`System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray`.

### 6.3.5 Record Expressions

An expression of the form `{field-initializer1; ... ; field-initializern}` is a _record
construction expression_. For example:

```fsharp
type Data = { Count : int; Name : string }
let data1 = { Count = 3; Name = "Hello"; }
let data2 = { Name = "Hello"; Count= 3 }
```
In the following example, `data4` uses a long identifier to indicate the relevant field:

```fsharp
module M =
    type Data = { Age : int; Name : string; Height : float }

let data3 = { M.Age = 17; M.Name = "John"; M.Height = 186.0 }
let data4 = { data3 with M.Name = "Bill"; M.Height = 176.0 }
```
Fields may also be referenced by using the name of the containing type:

```fsharp
module M2 =
    type Data = { Age : int; Name : string; Height : float }

let data5 = { M2.Data.Age = 17; M2.Data.Name = "John"; M2.Data.Height = 186.0 }
let data6 = { data5 with M2.Data.Name = "Bill"; M2.Data.Height=176.0 }

open M2
let data7 = { Data.Age = 17; Data.Name = "John"; Data.Height = 186.0 }
let data8 = { data5 with Data.Name = "Bill"; Data.Height=176.0 }
```
Each `field-initializeri` has the form `field-labeli = expri`. Each `field-labeli` is a `long-ident`,
which must resolve to a field `F` i in a unique record type `R` as follows:

- If `field-labeli` is a single identifier `fld` and the initial type is known to be a record type
    `R<_, ..., _>` that has field `Fi` with name `fld`, then the field label resolves to `Fi`.
- If `field-labeli` is not a single identifier or if the initial type is a variable type, then the field label
    is resolved by performing _Field Label Resolution_ (see [§14.1](inference-procedures.md#name-resolution)) on `field-labeli`. This procedure
    results in a set of fields `FSeti`. Each element of this set has a corresponding record type, thus
    resulting in a set of record types `RSeti`. The intersection of all `RSeti` must yield a single record
    type `R`, and each field then resolves to the corresponding field in `R`.
    The set of fields must be complete. That is, each field in record type `R` must have exactly one
    field definition. Each referenced field must be accessible (see [§10.5](namespaces-and-modules.md#accessibility-annotations)), as must the type `R`.

After all field labels are resolved, the overall record expression is asserted to be of type
`R<ty1, ..., tyN>` for fresh types `ty1, ..., tyN`. Each `expri` is then checked in turn. The initial type is
determined as follows:

1. Assume the type of the corresponding field `Fi` in `R<ty1, ..., tyN>` is `ftyi`
2. If the type of `Fi` prior to taking into account the instantiation `<ty1, ..., tyN>` is a named type, then
    the initial type is a fresh type inference variable `fty'i` with a constraint `fty'i :> ftyi`.
3. Otherwise the initial type is `ftyi`.

Primitive record constructions are an elaborated form in which the fields appear in the same order
as in the record type definition. Record expressions themselves elaborate to a form that may
introduce local value definitions to ensure that expressions are evaluated in the same order that the
field definitions appear in the original expression. For example:

```fsharp
type R = {b : int; a : int }
{ a = 1 + 1; b = 2 }
```
The expression on the last line elaborates to `let v = 1 + 1 in { b = 2; a = v }`.


Records expressions are also used for object initializations in additional object constructor
definitions ([§8.6.3](type-definitions.md#additional-object-constructors-in-classes)). For example:

```fsharp
type C =
    val x : int
    val y : int
    new() = { x = 1; y = 2 }
```
> Note: The following record initialization form is deprecated:
<br>`{ new type with Field1 = expr1 and ... and Fieldn = exprn }`
<br>The F# implementation allows the use of this form only with uppercase identifiers.
<br>F# code should not use this expression form. A future version of the F# language will
issue a deprecation warning.

### 6.3.6 Copy-and-update Record Expressions

A _copy-and-update record expression_ has the following form:

```fsharp
{ expr with field-initializers }
```
where `field-initializers` is of the following form:

```fsgrammar
field-label1 = expr1; ...; field-labeln = exprn
```
Each `field-labeli` is a `long-ident`. In the following example, `data2` is defined by using such an
expression:

```fsharp
type Data = { Age : int; Name : string; Height : float }
let data1 = { Age = 17; Name = "John"; Height = 186.0 }
let data2 = { data1 with Name = "Bill"; Height = 176.0 }
```
The expression `expr` is first checked with the same initial type as the overall expression. Next, the
field definitions are resolved by using the same technique as for record expressions. Each field label
must resolve to a field `Fi` in a single record type `R` , all of whose fields are accessible. After all field
labels are resolved, the overall record expression is asserted to be of type `R<ty1, ..., tyN>` for fresh
types `ty1, ..., tyN`. Each `expri` is then checked in turn with initial type that results from the following
procedure:

1. Assume the type of the corresponding field `Fi` in `R<ty1, ..., tyN>` is `ftyi`.
2. If the type of `Fi` before considering the instantiation `<ty1, ..., tyN>` is a named type, then the
    initial type is a fresh type inference variable `fty'i` with a constraint `fty'i :> ftyi`.
3. Otherwise, the initial type is `ftyi`.

A copy-and-update record expression elaborates as if it were a record expression written as follows:

`let v = expr in { field-label1 = expr1; ...; field-labeln = exprn; F1 = v.F1; ...; FM = v.FM }`
where `F1 ... FM` are the fields of `R` that are not defined in `field-initializers` and `v` is a fresh
variable.


### 6.3.7 Function Expressions

An expression of the form `fun pat1 ... patn -> expr` is a _function expression_. For example:

```fsharp
(fun x -> x + 1)
(fun x y -> x + y)
(fun [x] -> x) // note, incomplete match
(fun (x,y) (z,w) -> x + y + z + w)
```
Function expressions that involve only variable patterns are a primitive elaborated form. Function
expressions that involve non-variable patterns elaborate as if they had been written as follows:

```fsharp
fun v1 ... vn ->
    let pat1 = v 1
    ...
    let patn = vn
    expr
```
No pattern matching is performed until all arguments have been received. For example, the
following does not raise a `MatchFailureException` exception:

```fsharp
let f = fun [x] y -> y
let g = f [] // ok
```
However, if a third line is added, a `MatchFailureException` exception is raised:

```fsharp
let z = g 3 // MatchFailureException is raised
```
### 6.3.8 Object Expressions

An expression of the following form is an _object expression_ :

```fsharp
{ new ty0 args-expr~opt object-members
  interface ty1 object-members1
  ...
  interface tyn object-membersn }
```
In the case of the interface declarations, the `object-members` are optional and are considered empty
if absent. Each set of `object-members` has the form:

```fsgrammar
with member-defns end~opt
```
Lexical filtering inserts simulated `$end` tokens when lightweight syntax is used.

Each member of an object expression members can use the keyword `member`, `override`, or `default`.
The keyword `member` can be used even when overriding a member or implementing an interface.

For example:

```fsharp
let obj1 =
    { new System.Collections.Generic.IComparer<int> with
        member x.Compare(a,b) = compare (a % 7) (b % 7) }

let obj2 =
    { new System.Object() with
        member x.ToString () = "Hello" }

let obj3 =
    { new System.Object() with
        member x.ToString () = "Hello, base.ToString() = " + base.ToString() }

let obj4 =
    { new System.Object() with
        member x.Finalize() = printfn "Finalize";
    interface System.IDisposable with
        member x.Dispose() = printfn "Dispose"; }
```
An object expression can specify additional interfaces beyond those required to fulfill the abstract
slots of the type being implemented. For example, `obj4` in the preceding examples has static type
`System.Object` but the object additionally implements the interface `System.IDisposable`. The
additional interfaces are not part of the static type of the overall expression, but can be revealed
through type tests.

Object expressions are statically checked as follows.

1. First, `ty0` to `tyn` are checked to verify that they are named types. The overall type of the
expression is `ty0` and is asserted to be equal to the initial type of the expression. However, if `ty0`
is type equivalent to `System.Object` and `ty1` exists, then the overall type is instead `ty1`.

2. The type `ty0` must be a class or interface type. The base construction argument `args-expr` must
    appear if and only if `ty0` is a class type. The type must have one or more accessible constructors;
    the call to these constructors is resolved and elaborated using _Method Application Resolution_
    (see [§14.4](inference-procedures.md#method-application-resolution)). Except for `ty0`, each `tyi` must be an interface type.
3. The F# compiler attempts to associate each member with a unique _dispatch slot_ by using
    _dispatch slot inference_ ([§14.7](inference-procedures.md#dispatch-slot-inference)). If a unique matching dispatch slot is found, then the argument
    types and return type of the member are constrained to be precisely those of the dispatch slot.
4. The arguments, patterns, and expressions that constitute the bodies of all implementing
    members are next checked one by one to verify the following:
    - For each member, the “this” value for the member is in scope and has type `ty0`.
    - Each member of an object expression can initially access the protected members of `ty0`.
    - If the variable `base-ident` appears, it must be named `base`, and in each member a base
       variable with this name is in scope. Base variables can be used only in the member
       implementations of an object expression, and are subject to the same limitations as byref
       values described in [§14.9](inference-procedures.md#byref-safety-analysis).

The object must satisfy _dispatch slot checking_ ([§14.8](inference-procedures.md#dispatch-slot-checking)) which ensures that a one-to-one mapping
exists between dispatch slots and their implementations.

Object expressions elaborate to a primitive form. At execution, each object expression creates an
object whose runtime type is compatible with all of the `tyi` that have a dispatch map that is the
result of _dispatch slot checking_ ([§14.8](inference-procedures.md#dispatch-slot-checking)).

The following example shows how to both implement an interface and override a method from
`System.Object`. The overall type of the expression is `INewIdentity`.


```fsharp
type public INewIdentity =
    abstract IsAnonymous : bool

let anon =
{ new System.Object() with
    member i.ToString() = "anonymous"
  interface INewIdentity with
    member i.IsAnonymous = true }
```
### 6.3.9 Delayed Expressions

An expression of the form `lazy expr` is a _delayed expression_. For example:

```fsharp
lazy (printfn "hello world")
```
is syntactic sugar for

```fsharp
new System.Lazy (fun () -> expr )
```
The behavior of the `System.Lazy` library type ensures that expression `expr` is evaluated on demand in
response to a `.Value` operation on the lazy value.

### 6.3.10 Computation Expressions

The following expression forms are all _computation expressions_ :

```fsgrammar
expr { for ... }
expr { let ... }
expr { let! ... }
expr { use ... }
expr { while ... }
expr { yield ... }
expr { yield! ... }
expr { try ... }
expr { return ... }
expr { return! ... }
```
More specifically, computation expressions have the following form:

```fsgrammar
builder-expr { cexpr }
```
where `cexpr` is, syntactically, the grammar of expressions with the additional constructs that are
defined in `comp-expr`. Computation expressions are used for sequences and other non-standard
interpretations of the F# expression syntax. For a fresh variable `b`, the expression

```fsgrammar
builder-expr { cexpr }
```
translates to

```fsgrammar
let b = builder-expr in {| cexpr |}C
```
The type of `b` must be a named type after the checking of builder-expr. The subscript indicates that
custom operations (`C`) are acceptable but are not required.

If the inferred type of `b` has one or more of the `Run`, `Delay`, or `Quote` methods when `builder-expr` is
checked, the translation involves those methods. For example, when all three methods exist, the
same expression translates to:


```fsgrammar
let b = builder-expr in b.Run (<@ b.Delay(fun () -> {| cexpr |}C) >@)
```
If a `Run` method does not exist on the inferred type of b, the call to `Run` is omitted. Likewise, if no
`Delay` method exists on the type of `b`, that call and the inner lambda are omitted, so the expression
translates to the following:

```fsgrammar
let b = builder-expr in b.Run (<@ {| cexpr |}C >@)
```
Similarly, if a `Quote` method exists on the inferred type of `b`, at-signs `<@ @>` are placed around `{| cexpr |}C` 
or `b.Delay(fun () -> {| cexpr |}C)` if a `Delay` method also exists.

The translation `{| cexpr |}C` , which rewrites computation expressions to core language expressions,
is defined recursively according to the following rules:

`{| cexpr |}C = T (cexpr, [], fun v -> v, true)`

During the translation, we use the helper function {| cexpr |}0 to denote a translation that does not
involve custom operations:

`{| cexpr |}0 = T (cexpr, [], fun v -> v, false)`

```fsgrammar
T (e, V , C , q) where e : the computation expression being translated
                       V : a set of scoped variables
                       C : continuation (or context where “e” occurs,
                           up to a hole to be filled by the result of translating “e”)
                       q : Boolean that indicates whether a custom operator is allowed
```

<!-- start of weird section -->

Then, T is defined for each computation expression e:

**T** (let p = e in ce, **V** , **C** , q) = **T** (ce, **V**  `var` (p), v. **C** (let p = e in v), q)

**T** (let! p = e in ce, **V** , **C** , q) = **T** (ce, **V**  `var` (p), v. **C** (b.Bind( `src` (e),fun p -> v), q)

**T** (yield e, **V** , **C** , q) = **C** (b.Yield(e))

**T** (yield! e, **V** , **C** , q) = **C** (b.YieldFrom( `src` (e)))

**T** (return e, **V** , **C** , q) = **C** (b.Return(e))

**T** (return! e, **V** , **C** , q) = **C** (b.ReturnFrom( `src` (e)))

**T** (use p = e in ce, **V** , **C** , q) = **C** (b.Using(e, fun p -> {| `ce` |} 0 ))

**T** (use! p = e in ce, **V** , **C** , q) = **C** (b.Bind( `src` (e), fun p -> b.Using(p, fun p -> {| `ce` |} 0 ))

**T** (match e with pi - > cei, **V** , **C** , q) = **C** (match e with pi - > {| `ce` i |} 0 )

**T** (while e do ce, **V** , **C** , q) = **T** (ce, **V** , v. **C** (b.While(fun () -> e, b.Delay(fun () -> v))), q)

**T** (try ce with pi - > cei, **V** , **C** , q) =
Assert(not q); **C** (b.TryWith(b.Delay(fun () -> {| `ce` |} 0 ), fun pi - > {| `ce` i |} 0 ))

**T** (try ce finally e, **V** , **C** , q) =
Assert(not q); **C** (b.TryFinally(b.Delay(fun () -> {| `ce` |} 0 ), fun () -> e))

**T** (if e then ce, **V** , **C** , q) = **T** (ce, **V** , v. **C** (if e then v else b.Zero()), q)


**T** (if e then ce1 else ce2 , **V** , **C** , q) = Assert(not q); **C** (if e then {| `ce` 1 |} 0 ) else {| `ce` 2 |} 0 )

**T** (for x = e1 to e2 do ce, **V** , **C** , q) = **T** (for x in e1 .. e2 do ce, **V** , **C** , q)

**T** (for p1 in e1 do joinOp p2 in e2 onWord (e3 `eop` e4 ) ce, **V** , **C** , q) =
Assert(q); **T** (for `pat` ( **V** ) in b.Join( `src` (e1 ), `src` (e2 ), p1 .e3 , p2 .e4 ,
p1. p2 .(p1 ,p2 )) do ce, **V** , **C** , q)

**T** (for p1 in e1 do groupJoinOp p2 in e2 onWord (e3 `eop` e4) into p3 ce, **V** , **C** , q) =
Assert(q); **T** (for `pat` ( **V** ) in b.GroupJoin( `src` (e1),
`src` (e2), p1.e3, p2.e4, p1. p3.(p1,p3)) do ce, **V** , **C** , q)

**T** (for x in e do ce, **V** , **C** , q) = **T** (ce, **V**  {x}, v. **C** (b.For( `src` (e), fun x -> v)), q)

**T** (do e in ce, **V** , **C** , q) = **T** (ce, **V** , v. **C** (e; v), q)

**T** (do! e in ce, **V** , **C** , q) = **T** (let! () = e in ce, **V** , **C** , q)

**T** (joinOp p2 in e2 on (e3 `eop` e4) ce, **V** , **C** , q) =
**T** (for `pat` ( **V** ) in **C** ({| yield `exp` ( **V** ) |}0) do join p2 in e2 onWord (e3 `eop` e4) ce, **V** , v.v, q)

**T** (groupJoinOp p2 in e2 onWord (e3 eop e4) into p3 ce, **V** , **C** , q) =
**T** (for `pat` ( **V** ) in **C** ({| yield `exp` ( **V** ) |}0) do groupJoin p2 in e2 on (e3 `eop` e4) into p3 ce,
**V** , v.v, q)

**T** ([<CustomOperator("Cop")>]cop arg, **V** , **C** , q) = Assert (q); [| cop arg, **C** (b.Yield `exp` ( **V** )) |] **V**

**T** ([<CustomOperator("Cop", MaintainsVarSpaceUsingBind=true)>]cop arg; e, **V** , **C** , q) =
Assert (q); **CL** (cop arg; e, **V** , **C** (b.Return `exp` ( **V** )), false)

**T** ([<CustomOperator("Cop")>]cop arg; e, **V** , **C** , q) =
Assert (q); **CL** (cop arg; e, **V** , **C** (b.Yield `exp` ( **V** )), false)

**T** (ce1; ce2, **V** , **C** , q) = **C** (b.Combine({| ce1 |}0, b.Delay(fun () -> {| ce2 |}0)))

**T** (do! e;, **V** , **C** , q) = **T** (let! () = `src` (e) in b.Return(), **V** , **C** , q)

**T** (e;, **V** , **C** , q) = **C** (e;b.Zero())

The following notes apply to the translations:

- The lambda expression (fun f x -> b) is represented by x.b.
- The auxiliary function var (p) denotes a set of variables that are introduced by a pattern p. For
    example:
    var(x) = {x}, var((x,y)) = {x,y} or var(S (x,y)) = {x,y}
    where S is a type constructor.
-  is an update operator for a set V to denote extended variable spaces. It updates the existing
    variables. For example, {x,y}  var((x,z)) becomes {x,y,z} where the second x replaces the
    first x.
- The auxiliary function pat ( **V** ) denotes a pattern tuple that represents a set of variables in **V**. For
    example, pat({x,y}) becomes (x,y), where x and y represent pattern expressions.
- The auxiliary function exp ( **V** ) denotes a tuple expression that represents a set of variables in **V**.
    For example, exp ({x,y}) becomes (x,y), where x and y represent variable expressions.


- The auxiliary function src (e) denotes b.Source(e) if the innermost ForEach is from the user
    code instead of generated by the translation, and a builder b contains a Source method.
    Otherwise, src (e) denotes e.
- Assert() checks whether a custom operator is allowed. If not, an error message is reported.
    Custom operators may not be used within try/with, try/finally, if/then/else, use, match, or
    sequential execution expressions such as (e1;e2). For example, you cannot use if/then/else in
    any computation expressions for which a builder defines any custom operators, even if the
    custom operators are not used.
- The operator eop denotes one of =, ?=, =? or ?=?.
- joinOp and onWord represent keywords for join-like operations that are declared in
    CustomOperationAttribute. For example, [<CustomOperator("join", IsLikeJoin=true,
    JoinConditionWord="on")>] declares “join” and “on”.
- Similarly, groupJoinOp represents a keyword for groupJoin-like operations, declared in
    CustomOperationAttribute. For example, [<CustomOperator("groupJoin",
    IsLikeGroupJoin=true, JoinConditionWord="on")>] declares “groupJoin” and “on”.
- The auxiliary translation **CL** is defined as follows:

```fsgrammar
CL (e1, V, e2, bind) where e1: the computation expression being translated
V : a set of scoped variables
e2 : the expression that will be translated after e1 is done
bind: indicator if it is for Bind (true) or iterator (false).
```

The following shows translations for the uses of CL in the preceding computation expressions:

```fsgrammar
CL (cop arg, V , e’, bind) = [| cop arg, e’ |] V
CL ([<MaintainsVariableSpaceUsingBind=true>]cop arg into p; e, V , e’, bind) =
T (let! p = e’ in e, [], v.v, true)
CL (cop arg into p; e, V , e’, bind) = T (for p in e’ do e, [], v.v, true)
CL ([<MaintainsVariableSpace=true>]cop arg; e, V , e’, bind) =
CL (e, V , [| cop arg, e’ |] V , true)
CL ([<MaintainsVariableSpaceUsingBind=true>]cop arg; e, V , e’, bind) =
CL (e, V , [| cop arg, e’ |] V , true)
CL (cop arg; e, V , e’, bind) = CL (e, [], [| cop arg, e’ |] V , false)
CL (e, V , e’, true) = T (let! pat ( V ) = e’ in e, V , v.v, true)
CL (e, V , e’, false) = T (for pat ( V ) in e’ do e, V , v.v, true)
```
- The auxiliary translation [| e1, e2 |]V is defined as follows:

[|[ e1, e2 |] **V** where e1: the custom operator available in a build
e2 : the context argument that will be passed to a custom operator
**V** : a list of bound variables

```fsgrammar
[|[<CustomOperator(" Cop")>] cop [<ProjectionParameter>] arg, e |] V =
b.Cop (e, fun pat ( V) - > arg)
[|[<CustomOperator("Cop")>] cop arg, e |] V = b.Cop (e, arg)
```
- The final two translation rules (for do! e; and do! e;) apply only for the final expression in the
    computation expression. The semicolon (;) can be omitted.

The following attributes specify custom operations:

- `CustomOperationAttribute` indicates that a member of a builder type implements a custom
    operation in a computation expression. The attribute has one parameter: the name of the
    custom operation. The operation can have the following properties:
    - `MaintainsVariableSpace` indicates that the custom operation maintains the variable space of
       a computation expression.
    - `MaintainsVariableSpaceUsingBind` indicates that the custom operation maintains the
       variable space of a computation expression through the use of a bind operation.
    - `AllowIntoPattern` indicates that the custom operation supports the use of ‘into’ immediately
       following the operation in a computation expression to consume the result of the operation.
    - `IsLikeJoin` indicates that the custom operation is similar to a join in a sequence
       computation, which supports two inputs and a correlation constraint.
    - `IsLikeGroupJoin` indicates that the custom operation is similar to a group join in a sequence
       computation, which support two inputs and a correlation constraint, and generates a group.
    - `JoinConditionWord` indicates the names used for the ‘on’ part of the custom operator for
       join-like operators.
- `ProjectionParameterAttribute` indicates that, when a custom operation is used in a
    computation expression, a parameter is automatically parameterized by the variable space of
    the computation expression.

<!-- end of weird section -->

The following examples show how the translation works. Assume the following simple sequence
builder:

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Yield (item:'a) : seq<'a> = seq { yield item }

let myseq = SimpleSequenceBuilder()
```
Then, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    yield i*i
    }
```
translates to

```fsharp
let b = myseq
b.For([1..10], fun i ->
    b.Yield(i*i))
```

`CustomOperationAttribute` allows us to define custom operations. For example, the simple sequence
builder can have a custom operator, “where”:

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Yield (item:'a) : seq<'a> = seq { yield item }
    [<CustomOperation("where")>]
    member __.Where (source : seq<'a>, f: 'a -> bool) : seq<'a> = Seq.filter f source

let myseq = SimpleSequenceBuilder()
```
Then, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    where (fun x -> x > 5)
    }
```
translates to

```fsharp
let b = myseq
    b.Where(
        b.For([1..10], fun i ->
            b.Yield (i)),
        fun x -> x > 5)
```
`ProjectionParameterAttribute` automatically adds a parameter from the variable space of the
computation expression. For example, `ProjectionParameterAttribute` can be attached to the second
argument of the `where` operator:

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Yield (item:'a) : seq<'a> = seq { yield item }
    [<CustomOperation("where")>]
    member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
        Seq.filter f source

let myseq = SimpleSequenceBuilder()
```
Then, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    where (i > 5)
    }
```
translates to

```fsharp
let b = myseq
b.Where(
    b.For([1..10], fun i ->
        b.Yield (i)),
    fun i -> i > 5)
```
`ProjectionParameterAttribute` is useful when a let binding appears between `ForEach` and the
custom operators. For example, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    let j = i * i
    where (i > 5 && j < 49)
    }
```
translates to

```fsharp
let b = myseq
b.Where(
    b.For([1..10], fun i ->
        let j = i * i
        b.Yield (i,j)),
    fun (i,j) -> i > 5 && j < 49)
```
Without `ProjectionParameterAttribute`, a user would be required to write “`fun (i,j) ->`” explicitly.

Now, assume that we want to write the condition “`where (i > 5 && j < 49)`” in the following
syntax:

```fsharp
where (i > 5)
where (j < 49)
```
To support this style, the `where` custom operator should produce a computation that has the same
variable space as the input computation. That is, `j` should be available in the second `where`. The
following example uses the `MaintainsVariableSpace` property on the custom operator to specify this
behavior:

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Yield (item:'a) : seq<'a> = seq { yield item }
    [<CustomOperation("where", MaintainsVariableSpace=true)>]
    member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
        Seq.filter f source

let myseq = SimpleSequenceBuilder()
```
Then, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    let j = i * i
    where (i > 5)
    where (j < 49)
    }
```
translates to

```fsharp
let b = myseq
b.Where(
    b.Where(
        b.For([1..10], fun i ->
            let j = i * i
            b.Yield (i,j)),
        fun (i,j) -> i > 5),
    fun (i,j) -> j < 49)
```
When we may not want to produce the variable space but rather want to explicitly express the chain
of the `where` operator, we can design this simple sequence builder in a slightly different way. For
example, we can express the same expression in the following way:

```fsharp
myseq {
    for i in 1 .. 10 do
    where (i > 5) into j
    where (j*j < 49)
    }
```
In this example, instead of having a let-binding (for `j` in the previous example) and passing variable
space (including `j`) down to the chain, we can introduce a special syntax that captures a value into a
pattern variable and passes only this variable down to the chain, which is arguably more readable.
For this case, `AllowIntoPattern` allows the custom operation to have an `into` syntax:

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Yield (item:'a) : seq<'a> = seq { yield item }

    [<CustomOperation("where", AllowIntoPattern=true)>]
    member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
        Seq.filter f source

let myseq = SimpleSequenceBuilder()
```
Then, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    where (i > 5) into j
    where (j*j < 49)
    }
```
translates to

```fsharp
let b = myseq
b.Where(
    b.For(
        b.Where(
            b.For([1..10], fun i -> b.Yield (i))
            fun i -> i>5),
        fun j -> b.Yield (j)),
    fun j -> j*j < 49)
```
Note that the `into` keyword is not customizable, unlike `join` and `on`.

In addition to `MaintainsVariableSpace`, `MaintainsVariableSpaceUsingBind` is provided to pass
variable space down to the chain in a different way. For example:

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Return (item:'a) : seq<'a> = seq { yield item }
    member __.Bind (value , cont) = cont value
    [<CustomOperation("where", MaintainsVariableSpaceUsingBind=true, AllowIntoPattern=true)>]
    member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
        Seq.filter f source

let myseq = SimpleSequenceBuilder()
```
The presence of `MaintainsVariableSpaceUsingBindAttribute` requires `Return` and `Bind` methods
during the translation.

Then, the expression

```fsharp
myseq {
    for i in 1 .. 10 do
    where (i > 5 && i*i < 49) into j
    return j
    }
```
translates to

```fsharp
let b = myseq
b.Bind(
    b.Where(B.For([1..10], fun i -> b.Return (i)),
        fun i -> i > 5 && i*i < 49),
    fun j -> b.Return (j))
```
where `Bind` is called to capture the pattern variable `j`. Note that `For` and `Yield` are called to capture
the pattern variable when `MaintainsVariableSpace` is used.

Certain properties on the `CustomOperationAttribute` introduce join-like operators. The following
example shows how to use the `IsLikeJoin` property.

```fsharp
type SimpleSequenceBuilder() =
    member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
        seq { for v in source do yield! body v }
    member __.Yield (item:'a) : seq<'a> = seq { yield item }
    [<CustomOperation("merge", IsLikeJoin=true, JoinConditionWord="whenever")>]
    member __.Merge (src1:seq<'a>, src2:seq<'a>, ks1, ks2, ret) =
        seq { for a in src1 do
            for b in src2 do
            if ks1 a = ks2 b then yield((ret a ) b)
        }   

let myseq = SimpleSequenceBuilder()
```
`IsLikeJoin` indicates that the custom operation is similar to a join in a sequence computation; that
is, it supports two inputs and a correlation constraint.

The expression

```fsharp
myseq {
    for i in 1 .. 10 do
    merge j in [5 .. 15] whenever (i = j)
    yield j
    }
```
translates to

```fsharp
let b = myseq
b.For(
    b.Merge([1..10], [5..15],
            fun i -> i, fun j -> j,
            fun i -> fun j -> (i,j)),
    fun j -> b.Yield (j))
```
This translation implicitly places type constraints on the expected form of the builder methods. For
example, for the `async` builder found in the `FSharp.Control` library, the translation phase
corresponds to implementing a builder of a type that has the following member signatures:

```fsharp
type AsyncBuilder with
    member For: seq<'T> * ('T -> Async<unit>) -> Async<unit>
    member Zero : unit -> Async<unit>
    member Combine : Async<unit> * Async<'T> -> Async<'T>
    member While : (unit -> bool) * Async<unit> -> Async<unit>
    member Return : 'T -> Async<'T>
    member Delay : (unit -> Async<'T>) -> Async<'T>
    member Using: 'T * ('T -> Async<'U>) -> Async<'U>
        when 'U :> System.IDisposable
    member Bind: Async<'T> * ('T -> Async<'U>) -> Async<'U>
    member TryFinally: Async<'T> * (unit -> unit) -> Async<'T>
    member TryWith: Async<'T> * (exn -> Async<'T>) -> Async<'T>
```
The following example shows a common approach to implementing a new computation expression
builder for a monad. The example uses computation expressions to define computations that can be
partially run by executing them step-by-step, for example, up to a time limit.

```fsharp
/// Computations that can cooperatively yield by returning a continuation
type Eventually<'T> =
    | Done of 'T
    | NotYetDone of (unit -> Eventually<'T>)

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Eventually =

    /// The bind for the computations. Stitch 'k' on to the end of the computation.
    /// Note combinators like this are usually written in the reverse way,
    /// for example,
    /// e |> bind k
    let rec bind k e =
        match e with
        | Done x -> NotYetDone (fun () -> k x)
        | NotYetDone work -> NotYetDone (fun () -> bind k (work()))

    /// The return for the computations.
    let result x = Done x

    type OkOrException<'T> =
        | Ok of 'T
        | Exception of System.Exception

    /// The catch for the computations. Stitch try/with throughout
    /// the computation and return the overall result as an OkOrException.
    let rec catch e =
        match e with
        | Done x -> result (Ok x)
        | NotYetDone work ->
            NotYetDone (fun () ->
                let res = try Ok(work()) with | e -> Exception e
                match res with
                | Ok cont -> catch cont // note, a tailcall
                | Exception e -> result (Exception e))

    /// The delay operator.
    let delay f = NotYetDone (fun () -> f())

    /// The stepping action for the computations.
    let step c =
        match c with
        | Done _ -> c
        | NotYetDone f -> f ()

    // The rest of the operations are boilerplate.

    /// The tryFinally operator.
    /// This is boilerplate in terms of "result", "catch" and "bind".
    let tryFinally e compensation =
        catch (e)
        |> bind (fun res ->
            compensation();
            match res with
            | Ok v -> result v
            | Exception e -> raise e)

    /// The tryWith operator.
    /// This is boilerplate in terms of "result", "catch" and "bind".
    let tryWith e handler =
        catch e
        |> bind (function Ok v -> result v | Exception e -> handler e)

    /// The whileLoop operator.
    /// This is boilerplate in terms of "result" and "bind".
    let rec whileLoop gd body =
        if gd() then body |> bind (fun v -> whileLoop gd body)
        else result ()

    /// The sequential composition operator
    /// This is boilerplate in terms of "result" and "bind".
    let combine e1 e2 =
        e1 |> bind (fun () -> e2)

    /// The using operator.
    let using (resource: #System.IDisposable) f =
        tryFinally (f resource) (fun () -> resource.Dispose())

    /// The forLoop operator.
    /// This is boilerplate in terms of "catch", "result" and "bind".
    let forLoop (e:seq<_>) f =
        let ie = e.GetEnumerator()
        tryFinally (whileLoop (fun () -> ie.MoveNext())
                              (delay (fun () -> let v = ie.Current in f v)))
                   (fun () -> ie.Dispose())

// Give the mapping for F# computation expressions.
type EventuallyBuilder() =
    member x.Bind(e,k) = Eventually.bind k e
    member x.Return(v) = Eventually.result v
    member x.ReturnFrom(v) = v
    member x.Combine(e1,e2) = Eventually.combine e1 e2
    member x.Delay(f) = Eventually.delay f
    member x.Zero() = Eventually.result ()
    member x.TryWith(e,handler) = Eventually.tryWith e handler
    member x.TryFinally(e,compensation) = Eventually.tryFinally e compensation
    member x.For(e:seq<_>,f) = Eventually.forLoop e f
    member x.Using(resource,e) = Eventually.using resource e

let eventually = new EventuallyBuilder()
```
After the computations are defined, they can be built by using eventually { ... }:

```fsharp
let comp =
    eventually {
        for x in 1 .. 2 do
            printfn " x = %d" x
        return 3 + 4 }
```
These computations can now be stepped. For example:

```fsharp
let step x = Eventually.step x
    comp |> step
// returns "NotYetDone <closure>"

comp |> step |> step
// prints "x = 1"
// returns "NotYetDone <closure>"

comp |> step |> step |> step |> step |> step |> step
// prints "x = 1"
// prints "x = 2"
// returns “NotYetDone <closure>”

comp |> step |> step |> step |> step |> step |> step |> step |> step
// prints "x = 1"
// prints "x = 2"
// returns "Done 7"
```
### 6.3.11 Sequence Expressions

An expression in one of the following forms is a _sequence expression_ :

```fsgrammar
seq { comp-expr }
seq { short-comp-expr }
```
For example:

```fsharp
seq { for x in [ 1; 2; 3 ] do for y in [5; 6] do yield x + y }
seq { for x in [ 1; 2; 3 ] do yield x + x }
seq { for x in [ 1; 2; 3 ] -> x + x }
```
Logically speaking, sequence expressions can be thought of as computation expressions with a
builder of type `FSharp.Collections.SeqBuilder`. This type can be considered to be defined as
follows:

```fsharp
type SeqBuilder() =
    member x.Yield (v) = Seq.singleton v
    member x.YieldFrom (s:seq<_>) = s
    member x.Return (():unit) = Seq.empty
    member x.Combine (xs1,xs2) = Seq.append xs1 xs2
    member x.For (xs,g) = Seq.collect f xs
    member x.While (guard,body) = SequenceExpressionHelpers.EnumerateWhile guard body
    member x.TryFinally (xs,compensation) =
        SequenceExpressionHelpers.EnumerateThenFinally xs compensation
    member x.Using (resource,xs) = SequenceExpressionHelpers.EnumerateUsing resource xs
```
> Note that this builder type is not actually defined in the F# library. Instead, sequence expressions are
elaborated directly. For details, see page 79 of the old pdf spec.

<!-- Text skipped during conversion -->

### 6.3.12 Range Expressions

Expressions of the following forms are _range expressions_.

```fsgrammar
{ e1 .. e2 }
{ e1 .. e2 .. e3 }
seq { e1 .. e2 }
seq { e1 .. e2 .. e3 }
```
Range expressions generate sequences over a specified range. For example:

```fsgrammar
seq { 1 .. 10 } // 1; 2; 3; 4; 5; 6; 7; 8; 9; 10
seq { 1 .. 2 .. 10 } // 1; 3; 5; 7; 9
```
Range expressions involving `expr1 .. expr2` are translated to uses of the `(..)` operator, and those
involving `expr1 .. expr1 .. expr3` are translated to uses of the `(.. ..)` operator:

```fsgrammar
seq { e1 .. e2 } → ( .. ) e1 e2
seq { e1 .. e2 .. e3 } → ( .. .. ) e1 e2 e3
```
The default definition of these operators is in `FSharp.Core.Operators`. The ( `..` ) operator generates
an `IEnumerable<_>` for the range of values between the start (`expr1`) and finish (`expr2`) values, using
an increment of 1 (as defined by `FSharp.Core.LanguagePrimitives.GenericOne`). The `(.. ..)`
operator generates an `IEnumerable<_>` for the range of values between the start (`expr1`) and finish
(`expr3`) values, using an increment of `expr2`.

The `seq` keyword, which denotes the type of computation expression, can be omitted for simple
range expressions, but this is not recommended and might be deprecated in a future release. It is
always preferable to explicitly mark the type of a computation expression.

Range expressions also occur as part of the translated form of expressions, including the following:

- `[ expr1 .. expr2 ]`
- `[| expr1 .. expr2 |]`
- `for var in expr1 .. expr2 do expr3`

A sequence iteration expression of the form `for var in expr1 .. expr2 do expr3 done` is sometimes
elaborated as a simple for loop-expression ([§6.5.7](#657-simple-for-loop-expressions)).

### 6.3.13 Lists via Sequence Expressions

A _list sequence expression_ is an expression in one of the following forms

```fsgrammar
[ comp-expr ]
[ short-comp-expr ]
[ range-expr ]
```
In all cases `[ cexpr ]` elaborates to `FSharp.Collections.Seq.toList(seq { cexpr })`.

For example:

```fsharp
let x2 = [ yield 1; yield 2 ]
```

```fsharp
let x3 = [ yield 1
           if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then
               yield 2]
```
### 6.3.14 Arrays Sequence Expressions

An expression in one of the following forms is an _array sequence expression_ :

```fsgrammar
[| comp-expr |]
[| short-comp-expr |]
[| range-expr |]
```
In all cases `[| cexpr |]` elaborates to `FSharp.Collections.Seq.toArray(seq { cexpr })`.

For example:

```fsharp
let x2 = [| yield 1; yield 2 |]
let x3 = [| yield 1
    if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then
        yield 2 |]
```
### 6.3.15 Null Expressions

An expression in the form `null` is a _null expression_. A null expression imposes a nullness constraint
([§5.2.2](types-and-type-constraints.md#nullness-constraints), [§5.4.8](#548-nullness)) on the initial type of the expression. The constraint ensures that the type directly
supports the value `null`.

Null expressions are a primitive elaborated form.

### 6.3.16 'printf' Formats

Format strings are strings with `%` markers as format placeholders. Format strings are analyzed at
compile time and annotated with static and runtime type information as a result of that analysis.
They are typically used with one of the functions `printf`, `fprintf`, `sprintf`, or `bprintf` in the
`FSharp.Core.Printf` module. Format strings receive special treatment in order to type check uses of
these functions more precisely.

More concretely, a constant string is interpreted as a printf-style format string if it is expected to
have the type `FSharp.Core.PrintfFormat<'Printer,'State,'Residue,'Result,'Tuple>`. The string is
statically analyzed to resolve the generic parameters of the `PrintfFormat type`, of which `'Printer`
and `'Tuple` are the most interesting:

- `'Printer` is the function type that is generated by applying a printf-like function to the format
    string.
- `'Tuple` is the type of the tuple of values that are generated by treating the string as a generator
    (for example, when the format string is used with a function similar to `scanf` in other
    languages).

A format placeholder has the following shape:

`%[flags][width][.precision][type]`

where:

`flags` are 0 , -, +, and the space character. The # flag is invalid and results in a compile-time error.

`width` is an integer that specifies the minimum number of characters in the result.

`precision` is the number of digits to the right of the decimal point for a floating-point type..

`type` is as shown in the following table.

| Placeholder string | Type |
| --- | --- |
| `%b` | `bool` |
| `%s` | `string` |
| `%c` | `char` |
| `%d, %i` | One of the basic integer types: `byte`, `sbyte`, `int16`, `uint16`, `int32`, `uint32`, `int64`, `uint64`, `nativeint`, or `unativeint` |
| `%u` | Basic integer type formatted as an unsigned integer |
| `%x` | Basic integer type formatted as an unsigned hexadecimal integer with lowercase letters a through f. |
| `%X` | Basic integer type formatted as an unsigned hexadecimal integer with uppercase letters A through F. |
| `%o` | Basic integer type formatted as an unsigned octal integer. |
| `%e, %E, %f, %F, %g, %G` | `float` or `float32` |
| `%M` | `System.Decimal` |
| `%O` | `System.Object` |
| `%A` | Fresh variable type `'T` |
| `%a` | Formatter of type `'State -> 'T -> 'Residue` for a fresh variable type `'T` |
| `%t` | Formatter of type `'State -> 'Residue` |

For example, the format string "`%s %d %s`" is given the type `PrintfFormat<(string -> int -> string -> 'd), 'b, 'c, 'd, (string * int * string)>` for fresh variable types `'b`, `'c`, `'d`. Applying `printf`
to it yields a function of type `string -> int -> string -> unit`.

## 6.4 Application Expressions

### 6.4.1 Basic Application Expressions

Application expressions involve variable names, dot-notation lookups, function applications, method
applications, type applications, and item lookups, as shown in the following table.

| Expression | Description |
| --- | --- |
| `long-ident-or-op` | Long-ident lookup expression |
| `expr '.' long-ident-or-op` | Dot lookup expression |
| `expr expr` | Function or member application expression |
| `expr(expr)` | High precedence function or member application expression |
| `expr<types>` | Type application expression |
| `expr< >` | Type application expression with an empty type list |
| `type expr` | Simple object expression |

The following are examples of application expressions:

```fsharp
System.Math.PI
System.Math.PI.ToString()
(3 + 4).ToString()
System.Environment.GetEnvironmentVariable("PATH").Length
System.Console.WriteLine("Hello World")
```
Application expressions may start with object construction expressions that do not include the `new`
keyword:
```fsharp
System.Object()
System.Collections.Generic.List<int>(10)
System.Collections.Generic.KeyValuePair(3,"Three")
System.Object().GetType()
System.Collections.Generic.Dictionary<int,int>(10).[1]
```
If the `long-ident-or-op` starts with the special pseudo-identifier keyword `global`, F# resolves the
identifier with respect to the global namespace — that is, ignoring all `open` directives (see [§14.2](inference-procedures.md#resolving-application-expressions)). For example:
```fsharp
global.System.Math.PI
```
is resolved to `System.Math.PI` ignoring all `open` directives.

The checking of application expressions is described in detail as an algorithm in [§14.2](inference-procedures.md#resolving-application-expressions). To check an
application expression, the expression form is repeatedly decomposed into a _lead_ expression `expr`
and a list of projections `projs` through the use of _Unqualified Lookup_ ([§14.2.1](inference-procedures.md#unqualified-lookup)). This in turn uses
procedures such as _Expression-Qualified Lookup_ and _Method Application Resolution_.

As described in [§14.2](inference-procedures.md#resolving-application-expressions), checking an application expression results in an elaborated expression that
contains a series of lookups and method calls. The elaborated expression may include:

- Uses of named values
- Uses of union cases
- Record constructions
- Applications of functions
- Applications of methods (including methods that access properties)
- Applications of object constructors
- Uses of fields, both static and instance
- Uses of active pattern result elements

Additional constructs may be inserted when resolving method calls into simpler primitives:


- The use of a method or value as a first-class function may result in a function expression.

    For example, `System.Environment.GetEnvironmentVariable` elaborates to:
    `(fun v -> System.Environment.GetEnvironmentVariable(v))`
    for some fresh variable `v`.

- The use of post-hoc property setters results in the insertion of additional assignment and
    sequential execution expressions in the elaborated expression.

    For example, `new System.Windows.Forms.Form(Text="Text")` elaborates to
    `let v = new System.Windows.Forms.Form() in v.set_Text("Text"); v`
    for some fresh variable `v`.

- The use of optional arguments results in the insertion of `Some(_)` and `None` data constructions in
    the elaborated expression.

For uses of active pattern results (see [§10.2.4](namespaces-and-modules.md#active-pattern-definitions-in-modules)), for result `i` in an active pattern that has `N` possible
results of types `types` , the elaborated expression form is a union case `ChoiceNOfi` of type
`FSharp.Core.Choice<types>`.

### 6.4.2 Object Construction Expressions

An expression of the following form is an _object construction expression_:

```fsgrammar
new ty ( e1 ... en )
```
An object construction expression constructs a new instance of a type, usually by calling a
constructor method on the type. For example:

```fsharp
new System.Object()
new System.Collections.Generic.List<int>()
new System.Windows.Forms.Form (Text="Hello World")
new 'T()
```
The initial type of the expression is first asserted to be equal to `ty`. The type `ty` must not be an array,
record, union or tuple type. If `ty` is a named class or struct type:

- `ty` must not be abstract.
- If `ty` is a struct type, `n` is 0 , and `ty` does not have a constructor method that takes zero
    arguments, the expression elaborates to the default “zero-bit pattern” value for `ty`.
- Otherwise, the type must have one or more accessible constructors. The overloading between
    these potential constructors is resolved and elaborated by using _Method Application Resolution_
    (see [§14.4](inference-procedures.md#method-application-resolution)).

If `ty` is a delegate type the expression is a _delegate implementation expression_.

- If the delegate type has an `Invoke` method that has the following signature

    `Invoke(ty1, ..., tyn) -> rtyA` ,

    then the overall expression must be in this form:

    `new ty(expr)` where `expr` has type `ty1 -> ... -> tyn -> rtyB`

    If type `rtyA` is a CLI void type, then `rtyB` is unit, otherwise it is `rtyA`.

- If any of the types `tyi` is a byref-type then an explicit function expression must be specified. That
    is, the overall expression must be of the form `new ty(fun pat1 ... patn -> exprbody)`.

If `ty` is a type variable:

- There must be no arguments (that is, `n = 0`).
- The type variable is constrained as follows:

    `ty : (new : unit -> ty )` -- CLI default constructor constraint

- The expression elaborates to a call to
    `FSharp.Core.LanguagePrimitives.IntrinsicFunctions.CreateInstance<ty>()`, which in turn calls
    `System.Activator.CreateInstance<ty>()`, which in turn uses CLI reflection to find and call the
    null object constructor method for type `ty`. On return from this function, any exceptions are
    wrapped by using `System.TargetInvocationException`.

### 6.4.3 Operator Expressions

Operator expressions are specified in terms of their shallow syntactic translation to other constructs.
The following translations are applied in order:

```fsgrammar
infix-or-prefix-op e1 → (~infix-or-prefix-op) e1
prefix-op e1 → (prefix-op) e1
e1 infix-op e2 → (infix-op) e1 e2
```

> Note: When an operator that may be used as either an infix or prefix operator is used in
prefix position, a tilde character ~ is added to the name of the operator during the
translation process.

These rules are applied after applying the rules for dynamic operators ([§6.4.4](#644-dynamic-operator-expressions)).

The parenthesized operator name is then treated as an identifier and the standard rules for
unqualified name resolution ([§14.1](inference-procedures.md#name-resolution)) in expressions are applied. The expression may resolve to a
specific definition of a user-defined or library-defined operator. For example:

```fsharp
let (+++) a b = (a,b)
3 +++ 4
```
In some cases, the operator name resolves to a standard definition of an operator from the F#
library. For example, in the absence of an explicit definition of (+),

```fsharp
3 + 4
```
resolves to a use of the infix operator FSharp.Core.Operators.(+).

Some operators that are defined in the F# library receive special treatment in this specification. In
particular:

- The `&expr` and `&&expr` address-of operators ([§6.4.5](#645-the-addressof-operators))
- The `expr && expr` and `expr || expr` shortcut control flow operators ([§6.5.4](#654-shortcut-operator-expressions))
- The `%expr` and `%%expr` expression splice operators in quotations ([§6.8.3](#683-expression-splices))
- The library-defined operators, such as `+`, `-`, `*`, `/`, `%`, `**`, `<<<`, `>>>`, `&&&`, `|||`, and `^^^` ([§18.2](the-f-library-fsharpcoredll.md#basic-operators-and-functions-fsharpcoreoperators)).


If the operator does not resolve to a user-defined or library-defined operator, the name resolution
rules ([§14.1](inference-procedures.md#name-resolution)) ensure that the operator resolves to an expression that implicitly uses a static member
invocation expression (§ ?) that involves the types of the operands. This means that the effective
behavior of an operator that is not defined in the F# library is to require a static member that has the
same name as the operator, on the type of one of the operands of the operator. In the following
code, the otherwise undefined operator `-->` resolves to the static member on the `Receiver` type,
based on a type-directed resolution:

```fsharp
type Receiver(latestMessage:string) =
    static member (<--) (receiver:Receiver,message:string) =
        Receiver(message)

    static member (-->) (message,receiver:Receiver) =
        Receiver(message)

let r = Receiver "no message"

r <-- "Message One"

"Message Two" --> r
```
### 6.4.4 Dynamic Operator Expressions

Expressions of the following forms are _dynamic operator expressions:_

```fsgrammar
expr1 ? expr2
expr1 ? expr2 <- expr3
```
These expressions are defined by their syntactic translation:

`expr ? ident` → `(?) expr "ident"`

`expr1 ? (expr2)` → `(?) expr1 expr2`

`expr1 ? ident <- expr2` → `(?<-) expr1 "ident" expr2`

`expr1 ? (expr2) <- expr3` → `(?<-) expr1 expr2 expr3`

Here `"ident"` is a string literal that contains the text of `ident`.

> Note: The F# core library `FSharp.Core.dll` does not define the `(?)` and `(?<-)` operators.
However, user code may define these operators. For example, it is common to define
the operators to perform a dynamic lookup on the properties of an object by using
reflection.

This syntactic translation applies regardless of the definition of the `(?)` and `(?<-)` operators.
However, it does not apply to uses of the parenthesized operator names, as in the following:

```fsharp
(?) x y
```
### 6.4.5 The AddressOf Operators

Under default definitions, expressions of the following forms are _address-of expressions,_ called
_byref-address-of expression_ and _nativeptr-address-of expression,_ respectively:

```fsgrammar
& expr
&& expr
```

Such expressions take the address of a mutable local variable, byref-valued argument, field, array
element, or static mutable global variable.

For `&expr` and `&&expr`, the initial type of the overall expression must be of the form `byref<ty>` and
`nativeptr<ty>` respectively, and the expression `expr` is checked with initial type `ty`.

The overall expression is elaborated recursively by taking the address of the elaborated form of `expr`,
written `AddressOf(expr, DefinitelyMutates)`, defined in [§6.9.4](#694-taking-the-address-of-an-elaborated-expression).

Use of these operators may result in unverifiable or invalid common intermediate language (CIL)
code; when possible, a warning or error is generated. In general, their use is recommended only:

- To pass addresses where `byref` or `nativeptr` parameters are expected.
- To pass a `byref` parameter on to a subsequent function.
- When required to interoperate with native code.

Addresses that are generated by the `&&` operator must not be passed to functions that are in tail call
position. The F# compiler does not check for this.

Direct uses of `byref` types, `nativeptr` types, or values in the `FSharp.NativeInterop` module may
result in invalid or unverifiable CIL code. In particular, `byref` and `nativeptr` types may NOT be used
within named types such as tuples or function types.

When calling an existing CLI signature that uses a CLI pointer type `ty*`, use a value of type
`nativeptr<ty>`.

> Note: The rules in this section apply to the following prefix operators, which are defined
in the F# core library for use with one argument.
<br>`FSharp.Core.LanguagePrimitives.IntrinsicOperators.(~&)`
<br>`FSharp.Core.LanguagePrimitives.IntrinsicOperators.(~&&)`
<br>Other uses of these operators are not permitted.

### 6.4.6 Lookup Expressions

Lookup expressions are specified by syntactic translation:

`e1.[eargs]` → `e1.get_Item(eargs)`

`e1.[eargs] <- e3` → `e .set_Item(eargs, e3)`

In addition, for the purposes of resolving expressions of this form, array types of rank 1, 2, 3, and 4
are assumed to support a type extension that defines an `Item` property that has the following
signatures:

```fsharp
type 'T[] with
    member arr.Item : int -> 'T

type 'T[,] with
    member arr.Item : int * int -> 'T

type 'T[,,] with
    member arr.Item : int * int * int -> 'T

type 'T[,,,] with
    member arr.Item : int * int * int * int -> 'T
```
In addition, if type checking determines that the type of `e1` is a named type that supports the
`DefaultMember` attribute, then the member name identified by the `DefaultMember` attribute is used
instead of Item.

### 6.4.7 Slice Expressions

Slice expressions are defined by syntactic translation:

`e1.[sliceArg1, ,,, sliceArgN]` → `e1.GetSlice(args1, ..., argsN)`

`e1.[sliceArg1, ,,, sliceArgN] <- expr` → `e1.SetSlice(args1, ...,argsN, expr)`

where each `sliceArgN` is one of the following and translated to `argsN` (giving one or two args) as
indicated

`*` → `None, None`

`e1..` → `Some e1, None`

`..e2` → `None, Some e2`

`e1..e2` → `Some e1, Some e2`

`idx` → `idx`

Because this is a shallow syntactic translation, the `GetSlice` and `SetSlice` name may be resolved by
any of the relevant _Name Resolution_ ([§14.1](inference-procedures.md#name-resolution)) techniques, including defining the method as a type
extension for an existing type.

For example, if a matrix type has the appropriate overloads of the GetSlice method (see below), it is
possible to do the following:

```fsharp
matrix.[1..,*] // get rows 1.. from a matrix (returning a matrix)
matrix.[1..3,*] // get rows 1..3 from a matrix (returning a matrix)
matrix.[*,1..3] // get columns 1..3from a matrix (returning a matrix)
matrix.[1..3,1,.3] // get a 3x3 sub-matrix (returning a matrix)
matrix.[3,*] // get row 3 from a matrix as a vector
matrix.[*,3] // get column 3 from a matrix as a vector
```
In addition, CIL array types of rank 1 to 4 are assumed to support a type extension that defines a
method `GetSlice` that has the following signature:

```fsharp
type 'T[] with
    member arr.GetSlice : ?start1:int * ?end1:int -> 'T[]
type 'T[,] with
    member arr.GetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int -> 'T[,]
    member arr.GetSlice : idx1:int * ?start2:int * ?end2:int -> 'T[]
    member arr.GetSlice : ?start1:int * ?end1:int * idx2:int - > 'T[]
type 'T[,,] with
    member arr.GetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int * 
                          ?start3:int * ?end3:int
                            -> 'T[,,]
type 'T[,,,] with
    member arr.GetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
                          ?start3:int * ?end3:int * ?start4:int * ?end4:int
                            -> 'T[,,,]
```
In addition, CIL array types of rank 1 to 4 are assumed to support a type extension that defines a
method `SetSlice` that has the following signature:

```fsharp
type 'T[] with
    member arr.SetSlice : ?start1:int * ?end1:int * values:T[] -> unit

type 'T[,] with
    member arr.SetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
                          values:T[,] -> unit
    member arr.SetSlice : idx1:int * ?start2:int * ?end2:int * values:T[] -> unit
    member arr.SetSlice : ?start1:int * ?end1:int * idx2:int * values:T[] -> unit

type 'T[,,] with
    member arr.SetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int * 
                          ?start3:int * ?end3:int *
                          values:T[,,] -> unit

type 'T[,,,] with
    member arr.SetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
                          ?start3:int * ?end3:int * ?start4:int * ?end4:int *
                          values:T[,,,] -> unit
```
### 6.4.8 Member Constraint Invocation Expressions

An expression of the following form is a member constraint invocation expression:

```fsgrammar
(static-typars : (member-sig) expr)
```
Type checking proceeds as follows:

1. The expression is checked with initial type `ty`.
2. A statically resolved member constraint is applied ([§5.2.3](#523-member-constraints)):
    <br>`static-typars: (member-sig)`
3. `ty` is asserted to be equal to the return type of the constraint.
4. `expr` is checked with an initial type that corresponds to the argument types of the constraint.

The elaborated form of the expression is a member invocation. For example:

```fsharp
let inline speak (a: ^a) =
    let x = (^a : (member Speak: unit -> string) (a))
    printfn "It said: %s" x
    let y = (^a : (member MakeNoise: unit -> string) (a))
    printfn "Then it went: %s" y

type Duck() =
    member x.Speak() = "I'm a duck"
    member x.MakeNoise() = "quack"
type Dog() =
    member x.Speak() = "I'm a dog"
    member x.MakeNoise() = "grrrr"

let x = new Duck()
let y = new Dog()
speak x
speak y
```

Outputs:

```fsother
It said: I'm a duck
Then it went: quack
It said: I'm a dog
Then it went: grrrr
```
### 6.4.9 Assignment Expressions

An expression of the following form is an _assignment expression_ :

```fsharp
expr1 <- expr2
```
A modified version of _Unqualified Lookup_ ([§14.2.1](inference-procedures.md#unqualified-lookup)) is applied to the expression `expr1` using a fresh
expected result type `ty` , thus producing an elaborate expression `expr1`. The last qualification for `expr1`
must resolve to one of the following constructs:

- An invocation of a property with a setter method. The property may be an indexer.

    Type checking incorporates `expr2` as the last argument in the method application resolution for
    the setter method. The overall elaborated expression is a method call to this setter property and
    includes the last argument.

- A mutable value `path` of type `ty`.

    Type checking of `expr2` uses the expected result type `ty` and generates an elaborated expression
    `expr2`. The overall elaborated expression is an assignment to a value reference `&path <-stobj expr2`.

- A reference to a value `path` of type `byref<ty>`.

    Type checking of `expr2` uses the expected result type `ty` and generates an elaborated expression
    `expr2`. The overall elaborated expression is an assignment to a value reference `path <-stobj expr2`.

- A reference to a mutable field `expr1a.field` with the actual result type `ty`.

    Type checking of `expr2` uses the expected result type `ty` and generates an elaborated expression
    `expr2`. The overall elaborated expression is an assignment to a field (see [§6.9.4](#694-taking-the-address-of-an-elaborated-expression)):

    `AddressOf(expr1a.field, DefinitelyMutates) <-stobj expr2`

- A array lookup `expr1a.[expr1b]` where `expr1a` has type `ty[]`.


    Type checking of expr2 uses the expected result type ty and generates thean elaborated
    expression expr2. The overall elaborated expression is an assignment to a field (see [§6.9.4](#694-taking-the-address-of-an-elaborated-expression)):

    `AddressOf(expr1a.[expr1b], DefinitelyMutates) <-stobj expr2`

    > Note: Because assignments have the preceding interpretations, local values must be
    mutable so that primitive field assignments and array lookups can mutate their
    immediate contents. In this context, “immediate” contents means the contents of a
    mutable value type. For example, given


    ```fsharp
    [<Struct>]
    type SA =
        new(v) = { x = v }
        val mutable x : int
    
    [<Struct>]
    type SB =
        new(v) = { sa = v }
        val mutable sa : SA
    
    let s1 = SA(0)
    let mutable s2 = SA(0)
    let s3 = SB(0)
    let mutable s4 = SB(0)
    ```

    > Then these are not permitted:

    ```fsharp
    s1.x <- 3
    s3.sa.x <- 3
    ```
    and these are:
    ```fsharp
    s2.x <- 3
    s4.sa.x <- 3
    s4.sa <- SA(2)
    ```

## 6.5 Control Flow Expressions

### 6.5.1 Parenthesized and Block Expressions

A _parenthesized expression_ has the following form:

```fsgrammar
(expr)
```
A _block expression_ has the following form:

```fsgrammar
begin expr end
```
The expression `expr` is checked with the same initial type as the overall expression.

The elaborated form of the expression is simply the elaborated form of `expr`.

### 6.5.2 Sequential Execution Expressions

A _sequential execution expression_ has the following form:

```fsgrammar
expr1 ; expr2
```
For example:

```fsharp
printfn "Hello"; printfn "World"; 3
```
The `;` token is optional when both of the following are true:

- The expression `expr2` occurs on a subsequent line that starts in the same column as `expr1`.

- The current pre-parse context that results from the syntax analysis of the program text is a
    `SeqBlock` ([§15](lexical-filtering.md#lexical-filtering)).

When the semicolon is optional, parsing inserts a `$sep` token automatically and applies an additional
syntax rule for lightweight syntax ([§15.1.1](lexical-filtering.md#basic-lightweight-syntax-rules-by-example)). In practice, this means that code can omit the `;` token
for sequential execution expressions that implement functions or immediately follow tokens such as
`begin` and `(`.

The expression `expr1` is checked with an arbitrary initial type `ty`. After checking `expr1`, `ty` is asserted
to be equal to `unit`. If the assertion fails, a warning rather than an error is reported. The expression
`expr2` is then checked with the same initial type as the overall expression.

Sequential execution expressions are a primitive elaborated form.

### 6.5.3 Conditional Expressions

A _conditional expression_ has the following forms

```fsgrammar
if expr1a then expr1b
elif expr3a then expr2b
...
elif exprna then exprnb
else exprlast
```
The `elif` and `else` branches may be omitted. For example:

```fsharp
if (1 + 1 = 2) then "ok" else "not ok"
if (1 + 1 = 2) then printfn "ok"
```
Conditional expressions are equivalent to pattern matching on Boolean values. For example, the
following expression forms are equivalent:

```fsgrammar
if expr1 then expr2 else expr3
match (expr1: bool) with true -> expr2 | false -> expr3
```
If the `else` branch is omitted, the expression is a _sequential conditional expression_ and is equivalent
to:

```fsgrammar
match (expr1: bool) with true -> expr2 | false -> ()
```
with the exception that the initial type of the overall expression is first asserted to be `unit`.

### 6.5.4 Shortcut Operator Expressions

Under default definitions, expressions of the following form are respectively an _shortcut and expression_ and a _shortcut or expression_ :

```fsgrammar
expr && expr
expr || expr
```
These expressions are defined by their syntactic translation:

```fsgrammar
expr1 && expr2 → if expr1 then expr2 else false
expr1 || expr2 → if expr1 then true else expr2
```

> Note: The rules in this section apply when the following operators, as defined in the F#
    core library, are applied to two arguments.
    <br>`FSharp.Core.LanguagePrimitives.IntrinsicOperators.(&&)`
    <br>`FSharp.Core.LanguagePrimitives.IntrinsicOperators.(||)`
    <br>
    If the operator is not immediately applied to two arguments, it is interpreted as a strict
    function that evaluates both its arguments before use.

### 6.5.5 Pattern-Matching Expressions and Functions

A _pattern-matching expression_ has the following form:

```fsgrammar
match expr with rules
```
Pattern matching is used to evaluate the given expression and select a rule ([§7](patterns.md#patterns)). For example:

```fsharp
match (3, 2) with
| 1, j -> printfn "j = %d" j
| i, 2 - > printfn "i = %d" i
| _ - > printfn "no match"
```
A _pattern-matching function_ is an expression of the following form:

```fsgrammar
function rules
```
A pattern-matching function is syntactic sugar for a single-argument function expression that is
followed by immediate matches on the argument. For example:

```fsharp
function
| 1, j -> printfn "j = %d" j
| _ - > printfn "no match"
```
is syntactic sugar for the following, where x is a fresh variable:

```fsharp
fun x ->
    match x with
    | 1, j -> printfn "j = %d" j
    | _ - > printfn "no match"
```

### 6.5.6 Sequence Iteration Expressions

An expression of the following form is a _sequence iteration expression_ :

```fsgrammar
for pat in expr1 do expr2 done
```
The done token is optional if `expr2` appears on a later line and is indented from the column position
of the for token. In this case, parsing inserts a `$done` token automatically and applies an additional
syntax rule for lightweight syntax ([§15.1.1](lexical-filtering.md#basic-lightweight-syntax-rules-by-example)).

For example:

```fsharp
for x, y in [(1, 2); (3, 4)] do
    printfn "x = %d, y = %d" x y
```

The expression `expr1` is checked with a fresh initial type `tyexpr`, which is then asserted to be a subtype
of type `IEnumerable<ty>`, for a fresh type `ty`. If the assertion succeeds, the expression elaborates to
the following, where `v` is of type `IEnumerator<ty>` and `pat` is a pattern of type `ty` :

```fsharp
let v = expr1.GetEnumerator()
try
    while (v.MoveNext()) do
        match v.Current with
        | pat - > expr2
        | _ -> ()
finally
    match box(v) with
    | :? System.IDisposable as d - > d .Dispose()
    | _ -> ()
```
If the assertion fails, the type `tyexpr` may also be of any static type that satisfies the “collection
pattern” of CLI libraries. If so, the _enumerable extraction_ process is used to enumerate the type. In
particular, `tyexpr` may be any type that has an accessible GetEnumerator method that accepts zero
arguments and returns a value that has accessible MoveNext and Current properties. The type of `pat`
is the same as the return type of the Current property on the enumerator value. However, if the
Current property has return type obj and the collection type `ty` has an Item property with a more
specific (non-object) return type `ty2` , type `ty2` is used instead, and a dynamic cast is inserted to
convert v.Current to `ty2`.

A sequence iteration of the form

```fsgrammar
for var in expr1 .. expr2 do expr3 done
```
where the type of `expr1` or `expr2` is equivalent to `int`, is elaborated as a simple for-loop expression
([§6.5.7](#657-simple-for-loop-expressions))

### 6.5.7 Simple for-Loop Expressions

An expression of the following form is a _simple for loop expression_ :

```fsgrammar
for var = expr1 to expr2 do expr3 done
```
The `done` token is optional when `e2` appears on a later line and is indented from the column position
of the `for` token. In this case, a `$done` token is automatically inserted, and an additional syntax rule
for lightweight syntax applies ([§15.1.1](lexical-filtering.md#basic-lightweight-syntax-rules-by-example)). For example:

```fsharp
for x = 1 to 30 do
    printfn "x = %d, x^2 = %d" x (x*x)
```
The bounds `expr1` and `expr2` are checked with initial type `int`. The overall type of the expression is
`unit`. A warning is reported if the body `expr3` of the `for` loop does not have static type `unit`.

The following shows the elaborated form of a simple for-loop expression for fresh variables `start`
and `finish`:

```fsharp
let start = expr1 in
let finish = expr2 in
for var = start to finish do expr3 done
```

For-loops over ranges that are specified by variables are a primitive elaborated form. When
executed, the iterated range includes both the starting and ending values in the range, with an
increment of 1.

An expression of the form

```fsgrammar
for var in expr1 .. expr2 do expr3 done
```
is always elaborated as a simple for-loop expression whenever the type of `expr1` or `expr2` is
equivalent to `int`.

### 6.5.8 While Expressions

A _while loop expression_ has the following form:

```fsgrammar
while expr1 do expr2 done
```
The `done` token is optional when `expr2` appears on a subsequent line and is indented from the
column position of the `while`. In this case, a `$done` token is automatically inserted, and an additional
syntax rule for lightweight syntax applies ([§15.1.1](lexical-filtering.md#basic-lightweight-syntax-rules-by-example)).

For example:

```fsharp
while System.DateTime.Today.DayOfWeek = System.DayOfWeek.Monday do
    printfn "I don't like Mondays"
```
The overall type of the expression is `unit`. The expression `expr1` is checked with initial type `bool`. A
warning is reported if the body `expr2` of the while loop cannot be asserted to have type `unit`.

### 6.5.9 Try-with Expressions

A _try-with expression_ has the following form:

```fsgrammar
try expr with rules
```
For example:

```fsharp
try "1" with _ -> "2"

try
    failwith "fail"
with
    | Failure msg -> "caught"
    | :? System.InvalidOperationException -> "unexpected"
```
Expression `expr` is checked with the same initial type as the overall expression. The pattern matching
clauses are then checked with the same initial type and with input type `System.Exception`.

Try-with expressions are a primitive elaborated form.

### 6.5.10 Reraise Expressions

A _reraise expression_ is an application of the `reraise` F# library function. This function must be
applied to an argument and can be used only on the immediate right-hand side of `rules` in a try-with
expression.

```fsharp
try
    failwith "fail"
with e -> printfn "Failing"; reraise()
```
> Note: The rules in this section apply to any use of the function
  `FSharp.Core.Operators.reraise`, which is defined in the F# core library.

When executed, `reraise()` continues exception processing with the original exception information.

### 6.5.11 Try-finally Expressions

A _try-finally expression_ has the following form:

```fsgrammar
try expr1 finally expr2
```
For example:

```fsharp
try "1" finally printfn "Finally!"

try
    failwith "fail"
finally
    printfn "Finally block"
```
Expression `expr1` is checked with the initial type of the overall expression. Expression `expr2` is
checked with arbitrary initial type, and a warning occurs if this type cannot then be asserted to be
equal to `unit`.

Try-finally expressions are a primitive elaborated form.

### 6.5.12 Assertion Expressions

An _assertion expression_ has the following form:

```fsgrammar
assert expr
```
The expression `assert expr` is syntactic sugar for `System.Diagnostics.Debug.Assert(expr)`

> Note: `System.Diagnostics.Debug.Assert` is a conditional method call. This means that
assertions are triggered only if the DEBUG conditional compilation symbol is defined.

## 6.6 Definition Expressions

A _definition expression_ has one of the following forms:

```fsgrammar
let function-defn in expr
let value-defn in expr
let rec function-or-value-defns in expr
use ident = expr1 in expr
```
Such an expression establishes a local function or value definition within the lexical scope of `expr`
and has the same overall type as `expr`.


In each case, the `in` token is optional if `expr` appears on a subsequent line and is aligned with the
token `let`. In this case, a `$in` token is automatically inserted, and an additional syntax rule for
lightweight syntax applies ([§15.1.1](lexical-filtering.md#basic-lightweight-syntax-rules-by-example))

For example:

```fsharp
let x = 1
x + x
```
and

```fsharp
let x, y = ("One", 1)
x.Length + y
```
and

```fsharp
let id x = x in (id 3, id "Three")
```
and

```fsharp
let swap (x, y) = (y,x)
List.map swap [ (1, 2); (3, 4) ]
```
and

```fsharp
let K x y = x in List.map (K 3) [ 1; 2; 3; 4 ]
```
Function and value definitions in expressions are similar to function and value definitions in class
definitions ([§8.6](type-definitions.md#class-type-definitions)), modules ([§10.2.1](namespaces-and-modules.md#function-and-value-definitions-in-modules)), and computation expressions ([§6.3.10](#6310-computation-expressions)), with the following
exceptions:

- Function and value definitions in expressions may not define explicit generic parameters ([§5.3](#53-type-parameter-definitions)).
    For example, the following expression is rejected:
       <br>`let f<'T> (x:'T) = x in f 3`
- Function and value definitions in expressions are not public and are not subject to arity analysis
    ([§14.10](inference-procedures.md#arity-inference)).
- Any custom attributes that are specified on the declaration, parameters, and/or return
    arguments are ignored and result in a warning. As a result, function and value definitions in
    expressions may not have the `ThreadStatic` or `ContextStatic` attribute.

### 6.6.1 Value Definition Expressions

A value definition expression has the following form:

```fsgrammar
let value-defn in expr
```
where _value-defn_ has the form:

```fsgrammar
mutable~opt access~opt pat typar-defns~opt return-type~opt = rhs-expr
```
Checking proceeds as follows:

1. Check the _value-defn_ ([§14.6](inference-procedures.md#checking-and-elaborating-function-value-and-member-definitions)), which defines a group of identifiers `identj` with inferred types `tyj`

2. Add the identifiers `identj` to the name resolution environment, each with corresponding type
    `tyj`.
3. Check the body `expr` against the initial type of the overall expression.

In this case, the following rules apply:

- If `pat` is a single value pattern `ident`, the resulting elaborated form of the entire expression is

    ```fsgrammar
    let ident1 <typars1> = expr1 in
    body-expr
    ```
    where ident1 , typars1 and expr1 are defined in [§14.6](inference-procedures.md#checking-and-elaborating-function-value-and-member-definitions).

- Otherwise, the resulting elaborated form of the entire expression is

    ```fsgrammar
    let tmp <typars1 ... typars n> = expr in
    let ident1 <typars1> = expr1 in
    ...
    let identn <typarsn> = exprn in
    body-expr
    ```
    where `tmp` is a fresh identifier and `identi`, `typarsi`, and `expri` all result from the compilation of
    the pattern `pat` ([§7](patterns.md#patterns)) against the input `tmp`.

Value definitions in expressions may be marked as `mutable`. For example:

```fsharp
let mutable v = 0
while v < 10 do
    v <- v + 1
    printfn "v = %d" v
```
Such variables are implicitly dereferenced each time they are used.

### 6.6.2 Function Definition Expressions

A function definition expression has the form:

```fsgrammar
let function-defn in expr
```
where `function-defn` has the form:

```fsgrammar
inline~opt access~opt ident-or-op typar-defns~opt pat1 ... patn return-type~opt = rhs-expr
```
Checking proceeds as follows:

1. Check the `function-defn` ([§14.6](inference-procedures.md#checking-and-elaborating-function-value-and-member-definitions)), which defines `ident1`, `ty1`, `typars1` and `expr1`
2. Add the identifier `ident1` to the name resolution environment, each with corresponding type `ty1`.
3. Check the body `expr` against the initial type of the overall expression.

The resulting elaborated form of the entire expression is

```fsgrammar
let ident1 < typars1 > = expr1 in
expr
```
where `ident1` , `typars1` and `expr1` are as defined in [§14.6](inference-procedures.md#checking-and-elaborating-function-value-and-member-definitions).


### 6.6.3 Recursive Definition Expressions

An expression of the following form is a _recursive definition expression_:

```fsgrammar
let rec function-or-value-defns in expr
```
The defined functions and values are available for use within their own definitions—that is can be
used within any of the expressions on the right-hand side of `function-or-value-defns`. Multiple
functions or values may be defined by using `let rec ... and ...`. For example:

```fsharp
let test() =
    let rec twoForward count =
        printfn "at %d, taking two steps forward" count
        if count = 1000 then "got there!"
        else oneBack (count + 2)
    and oneBack count =
        printfn "at %d, taking one step back " count
        twoForward (count - 1)

    twoForward 1

test()
```
In the example, the expression defines a set of recursive functions. If one or more recursive values
are defined, the recursive expressions are analyzed for safety ([§14.6.6](inference-procedures.md#recursive-safety-analysis)). This may result in warnings
(including some reported as compile-time errors) and runtime checks.

### 6.6.4 Deterministic Disposal Expressions

A _deterministic disposal expression_ has the form:

```fsgrammar
use ident = expr1 in expr2
```
For example:

```fsharp
use inStream = System.IO.File.OpenText "input.txt"
let line1 = inStream.ReadLine()
let line2 = inStream.ReadLine()
(line1,line2)
```
The expression is first checked as an expression of form `let ident = expr1 in expr2` ([§6.6.1](#661-value-definition-expressions)), which results in an elaborated expression of the following form:

```fsgrammar
let ident1 : ty1 = expr1 in expr2.
```
Only one value may be defined by a deterministic disposal expression, and the definition is not
generalized ([§14.6.7](inference-procedures.md#generalization)). The type `ty1` , is then asserted to be a subtype of `System.IDisposable`. If the
dynamic value of the expression after coercion to type `obj` is non-null, the `Dispose` method is called
on the value when the value goes out of scope. Thus the overall expression elaborates to this:

```fsgrammar
let ident1 : ty1 = expr1
try expr2
finally (match ( ident :> obj) with
         | null -> ()
         | _ -> (ident :> System.IDisposable).Dispose())
```

## 6.7 Type-related Expressions

### 6.7.1 Type-Annotated Expressions

A _type-annotated expression_ has the following form, where `ty` indicates the static type of `expr`:

```fsgrammar
expr : ty
```
For example:

```fsharp
(1 : int)
let f x = (x : string) + x
```
When checked, the initial type of the overall expression is asserted to be equal to `ty`. Expression `expr`
is then checked with initial type `ty`. The expression elaborates to the elaborated form of `expr`. This
ensures that information from the annotation is used during the analysis of `expr` itself.

### 6.7.2 Static Coercion Expressions

A _static coercion expression_ — also called a flexible type constraint — has the following form:

```fsgrammar
expr :> ty
```
The expression `upcast expr` is equivalent to `expr :> _`, so the target type is the same as the initial
type of the overall expression. For example:

```fsharp
(1 :> obj)
("Hello" :> obj)
([1;2;3] :> seq<int>).GetEnumerator()
(upcast 1 : obj)
```
The initial type of the overall expression is `ty`. Expression `expr` is checked using a fresh initial type
`tye`, with constraint `tye :> ty`. Static coercions are a primitive elaborated form.

### 6.7.3 Dynamic Type-Test Expressions

A dynamic type-test expression has the following form:

```fsgrammar
expr :? ty
```
For example:

```fsharp
((1 :> obj) :? int)
((1 :> obj) :? string)
```
The initial type of the overall expression is `bool`. Expression `expr` is checked using a fresh initial type
`tye`. After checking:

- The type `tye` must not be a variable type.
- A warning is given if the type test will always be true and therefore is unnecessary.
- The type `tye` must not be sealed.
- If type `ty` is sealed, or if `ty` is a variable type, or if type `tye` is not an interface type, then `ty :> tye`
    is asserted.

Dynamic type tests are a primitive elaborated form.

### 6.7.4 Dynamic Coercion Expressions

A dynamic coercion expression has the following form:

```fsgrammar
expr :?> ty
```
The expression downcast `e1` is equivalent to `expr :?> _` , so the target type is the same as the initial
type of the overall expression. For example:

```fsharp
let obj1 = (1 :> obj)
(obj1 :?> int)
(obj1 :?> string)
(downcast obj1 : int)
```
The initial type of the overall expression is `ty`. Expression `expr` is checked using a fresh initial type
`tye`. After these checks:

- The type `tye` must not be a variable type.
- A warning is given if the type test will always be true and therefore is unnecessary.
- The type `tye` must not be sealed.
- If type `ty` is sealed, or if `ty` is a variable type, or if type `tye` is not an interface type, then `ty :> tye`
    is asserted.

Dynamic coercions are a primitive elaborated form.

## 6.8 Quoted Expressions

An expression in one of these forms is a quoted expression:
```fsgrammar
<@ expr @>

<@@ expr @@>
```
The former is a _strongly typed quoted expression_ , and the latter is a _weakly typed quoted expression_.
In both cases, the expression forms capture the enclosed expression in the form of a typed abstract
syntax tree.

The exact nodes that appear in the expression tree are determined by the elaborated form of `expr`
that type checking produces.

For details about the nodes that may be encountered, see the documentation for the
`FSharp.Quotations.Expr` type in the F# core library. In particular, quotations may contain:

- References to module-bound functions and values, and to type-bound members. For example:

    ```fsharp
    let id x = x
    let f (x : int) = <@ id 1 @>
    ```

    In this case the value appears in the expression tree as a node of kind
    `FSharp.Quotations.Expr.Call`.

- A type, module, function, value, or member that is annotated with the `ReflectedDefinition`
    attribute. If so, the expression tree that forms its definition may be retrieved dynamically using
    the `FSharp.Quotations.Expr.TryGetReflectedDefinition`.

    If the `ReflectedDefinition` attribute is applied to a type or module, it will be recursively applied
    to all members, too.

- References to defined values, such as the following:

    ```fsharp
    let f (x : int) = <@ x + 1 @>
    ```

    Such a value appears in the expression tree as a node of kind FSharp.Quotations.Expr.Value.

- References to generic type parameters or uses of constructs whose type involves a generic
    parameter, such as the following:
    ```fsharp
           let f (x:'T) = <@ (x, x) : 'T * 'T @>
    ```

    In this case, the actual value of the type parameter is implicitly substituted throughout the type
    annotations and types in the generated expression tree.

As of F# 3. 1 , the following limitations apply to quoted expressions:

- Quotations may not use object expressions.
- Quotations may not define expression-bound functions that are themselves inferred to be
    generic. Instead, expression-bound functions should either include type annotations to refer to a
    specific type or should be written by using module-bound functions or class-bound members.

### 6.8.1 Strongly Typed Quoted Expressions

A strongly typed quoted expression has the following form:

```fsgrammar
<@ expr @>
```
For example:

```fsharp
<@ 1 + 1 @>

<@ (fun x -> x + 1) @>
```
In the first example, the type of the expression is `FSharp.Quotations.Expr<int>`. In the second
example, the type of the expression is `FSharp.Quotations.Expr<int -> int>`.

When checked, the initial type of a strongly typed quoted expression `<@ expr @>` is asserted to be of
the form `FSharp.Quotations.Expr<ty>` for a fresh type `ty`. The expression `expr` is checked with initial
type `ty`.

### 6.8.2 Weakly Typed Quoted Expressions

A _weakly typed quoted expression_ has the following form:

```fsgrammar
<@@ expr @@>
```
Weakly typed quoted expressions are similar to strongly quoted expressions but omit any type
annotation. For example:


```fsharp
<@@ 1 + 1 @@>

<@@ (fun x -> x + 1) @@>
```
In both these examples, the type of the expression is `FSharp.Quotations.Expr`.

When checked, the initial type of a weakly typed quoted expression `<@@ expr @@>` is asserted to be
of the form `FSharp.Quotations.Expr`. The expression `expr` is checked with fresh initial type `ty`.

### 6.8.3 Expression Splices

Both strongly typed and weakly typed quotations may contain expression splices in the following
forms:

```fsgrammar
%expr
%%expr
```
These are respectively strongly typed and weakly typed splicing operators.

#### 6.8.3.1 Strongly Typed Expression Splices
An expression of the following form is a _strongly typed expression splice_ :

```fsgrammar
%expr
```
For example, given

```fsharp
open FSharp.Quotations
let f1 (v:Expr<int>) = <@ %v + 1 @>
let expr = f1 <@ 3 @>
```
the identifier `expr` evaluates to the same expression tree as `<@ 3 + 1 @>`. The expression tree
for `<@ 3 @>` replaces the splice in the corresponding expression tree node.

A strongly typed expression splice may appear only in a quotation. Assuming that the splice
expression `%expr` is checked with initial type `ty` , the expression `expr` is checked with initial type
`FSharp.Quotations.Expr<ty>`.

> Note: The rules in this section apply to any use of the prefix operator
`FSharp.Core.ExtraTopLevelOperators.(~%)`. Uses of this operator must be applied to an
argument and may only appear in quoted expressions.

**6.8.3.2 Weakly Typed Expression Splices**
An expression of the following form is a _weakly typed expression splice_ :

```fsgrammar
%%expr
```
For example, given

```fsharp
open FSharp.Quotations
let f1 (v:Expr) = <@ %%v + 1 @>
let tree = f1 <@@ 3 @@>
```
the identifier `tree` evaluates to the same expression tree as `<@ 3 + 1 @>`. The expression tree
replaces the splice in the corresponding expression tree node.


A weakly typed expression splice may appear only in a quotation. Assuming that the splice
expression `%%expr` is checked with initial type `ty`, then the expression `expr` is checked with initial type
`FSharp.Quotations.Expr`. No additional constraint is placed on `ty`.

Additional type annotations are often required for successful use of this operator.

> Note: The rules in this section apply to any use of the prefix operator
`FSharp.Core.ExtraTopLevelOperators.(~%%)`, which is defined in the F# core library. Uses
of this operator must be applied to an argument and may only occur in quoted
expressions.

## 6.9 Evaluation of Elaborated Forms

At runtime, execution evaluates expressions to values. The evaluation semantics of each expression
form are specified in the subsections that follow.

### 6.9.1 Values and Execution Context

The execution of elaborated F# expressions results in values. Values include:

- Primitive constant values
- The special value `null`
- References to object values in the global heap of object values
- Values for value types, containing a value for each field in the value type
- Pointers to mutable locations (including static mutable locations, mutable fields and array
    elements)

Evaluation assumes the following evaluation context:

- A global heap of object values. Each object value contains:
    - A runtime type and dispatch map
    - A set of fields with associated values
    - For array objects, an array of values in index order
    - For function objects, an expression which is the body of the function
    - An optional _union case label_ , which is an identifier
    - A closure environment that assigns values to all variables that are referenced in the method
       bodies that are associated with the object
- A global environment that maps runtime-type/name pairs to values.Each name identifies a static
    field in a type definition or a value in a module.
- A local environment mapping names of variables to values.
- A local stack of active exception handlers, made up of a stack of try/with and try/finally handlers.

Evaluation may also raise an exception. In this case, the stack of active exception handlers is
processed until the exception is handled, in which case additional expressions may be executed (for


try/finally handlers), or an alternative expression may be evaluated (for try/with handlers), as
described below.

### 6.9.2 Parallel Execution and Memory Model

In a concurrent environment, evaluation may involve both multiple active computations (multiple
concurrent and parallel threads of execution) and multiple pending computations (pending
callbacks, such as those activated in response to an I/O event).

If multiple active computations concurrently access mutable locations in the global environment or
heap, the atomicity, read, and write guarantees of the underlying CLI implementation apply. The
guarantees are related to the logical sizes and characteristics of values, which in turn depend on
their type:

- F# reference types are guaranteed to map to CLI reference types. In the CLI memory model,
    reference types have atomic reads and writes.
- F# value types map to a corresponding CLI value type that has corresponding fields. Reads and
    writes of sizes less than or equal to one machine word are atomic.

The `VolatileField` attribute marks a mutable location as volatile in the compiled form of the code.

Ordering of reads and writes from mutable locations may be adjusted according to the limitations
specified by the CLI memory model. The following example shows situations in which changes to
read and write order can occur, with annotations about the order of reads:

```fsharp
type ClassContainingMutableData() =
    let value = (1, 2)
    let mutable mutableValue = (1, 2)

    [<VolatileField>]
    let mutable volatileMutableValue = (1, 2)

    member x.ReadValues() =
        // Two reads on an immutable value
        let (a1, b1) = value

        // One read on mutableValue, which may be duplicated according
        // to ECMA CLI spec.
        let (a2, b2) = mutableValue

        // One read on volatileMutableValue, which may not be duplicated.
        let (a3, b3) = volatileMutableValue

        a1, b1, a2, b2, a3, b3

    member x.WriteValues() =
        // One read on mutableValue, which may be duplicated according
        // to ECMA CLI spec.
        let (a2, b2) = mutableValue

        // One write on mutableValue.
        mutableValue <- (a2 + 1, b2 + 1)

        // One read on volatileMutableValue, which may not be duplicated.
        let (a3, b3) = volatileMutableValue

        // One write on volatileMutableValue.
        volatileMutableValue <- (a3 + 1, b3 + 1)

let obj = ClassContainingMutableData()
Async.Parallel [ async { return obj.WriteValues() };
                 async { return obj.WriteValues() };
                 async { return obj.ReadValues() };
                 async { return obj.ReadValues() } ]
```
### 6.9.3 Zero Values

Some types have a _zero value_. The zero value is the “default” value for the type in the CLI execution
environment. The following types have the following zero values:

- For reference types, the `null` value.
- For value types, the value with all fields set to the zero value for the type of the field. The zero
    value is also computed by the F# library function `Unchecked.defaultof<ty>`.

### 6.9.4 Taking the Address of an Elaborated Expression

When the F# compiler determines the elaborated forms of certain expressions, it must compute a
“reference” to an elaborated expression `expr` , written `AddressOf(expr, mutation)`. The `AddressOf`
operation is used internally within this specification to indicate the elaborated forms of address-of
expressions, assignment expressions, and method and property calls on objects of variable and value
types.

The `AddressOf` operation is computed as follows:

- If `expr` has form `path` where `path` is a reference to a value with type `byref<ty>`, the elaborated
    form is `&path`.
- If `expr` has form `expra.field` where `field` is a mutable, non-readonly CLI field, the elaborated
    form is `&(AddressOf(expra).field)`.
- If `expr` has form expra.[exprb] where the operation is an array lookup, the elaborated form is
    `&(AddressOf(expra).[exprb])`.
- If `expr` has any other form, the elaborated form is `&v` ,where `v` is a fresh mutable local value that
    is initialized by adding `let v = expr` to the overall elaborated form for the entire assignment
    expression. This initialization is known as a _defensive copy_ of an immutable value. If `expr` is a
    struct, `expr` is copied each time the `AddressOf` operation is applied, which results in a different
    address each time. To keep the struct in place, the field that contains it should be marked as
    mutable.

The `AddressOf` operation is computed with respect to `mutation`, which indicates whether the
relevant elaborated form uses the resulting pointer to change the contents of memory. This
assumption changes the errors and warnings reported.

- If `mutation` is `DefinitelyMutates`, then an error is given if a defensive copy must be created.
- If `mutation` is `PossiblyMutates`, then a warning is given if a defensive copy arises.


An F# compiler can optionally upgrade `PossiblyMutates` to `DefinitelyMutates` for calls to property
setters and methods named `MoveNext` and `GetNextArg`, which are the most common cases of struct-
mutators in CLI library design. This is done by the F# compiler.

> Note:In F#, the warning “copy due to possible mutation of value type” is a level 4
  warning and is not reported when using the default settings of the F# compiler. This is
  because the majority of value types in CLI libraries are immutable. This is warning
  number 52 in the F# implementation.
  <br> CLI libraries do not include metadata to indicate whether a particular value type is
  immutable. Unless a value is held in arrays or locations marked mutable, or a value type
  is known to be immutable to the F# compiler, F# inserts copies to ensure that
  inadvertent mutation does not occur.

### 6.9.5 Evaluating Value References

At runtime, an elaborated value reference `v` is evaluated by looking up the value of `v` in the local
environment.

### 6.9.6 Evaluating Function Applications

At runtime, an elaborated application of a function `f e1 ... en` is evaluated as follows:

- The expressions `f` and `e1 ... en`, are evaluated.
- If `f` evaluates to a function value with closure environment `E`, arguments `v1 ... vm`, and body `expr`,
    where `m <= n` , then `E` is extended by mapping `v1 ... vm` to the argument values for `e1 ... em`. The
    expression `expr` is then evaluated in this extended environment and any remaining arguments
    applied.
- If `f` evaluates to a function value with more than `n` arguments, then a new function value is
    returned with an extended closure mapping `n` additional formal argument names to the
    argument values for `e1 ... em`.

The result of calling the `obj.GetType()` method on the resulting object is under-specified (see
[§6.9.24](#6924-values-with-underspecified-object-identity-and-type-identity)).

### 6.9.7 Evaluating Method Applications

At runtime an elaborated application of a method is evaluated as follows:

- The elaborated form is `e0.M(e1 , ..., en)` for an instance method or `M(e, ..., en)` for a static method.
- The (optional) `e0` and `e1` ,..., _en_ are evaluated in order.
- If `e0` evaluates to `null`, a `NullReferenceException` is raised.
- If the method is declared `abstract` — that is, if it is a virtual dispatch slot — then the body of the
    member is chosen according to the dispatch maps of the value of `e0` ([§14.8](inference-procedures.md#dispatch-slot-checking)).
- The formal parameters of the method are mapped to corresponding argument values. The body
    of the method member is evaluated in the resulting environment.


### 6.9.8 Evaluating Union Cases

At runtime, an elaborated use of a union case `Case(e1 , ..., en)` for a union type `ty` is evaluated as
follows:

- The expressions `e1, ..., en` are evaluated in order.
- The result of evaluation is an object value with union case label `Case` and fields given by the
    values of `e1 , ..., en`.
- If the type `ty` uses null as a representation ([§5.4.8](#548-nullness)) and `Case` is the single union case without
    arguments, the generated value is `null`.
- The runtime type of the object is either `ty` or an internally generated type that is compatible
    with `ty`.

### 6.9.9 Evaluating Field Lookups

At runtime, an elaborated lookup of a CLI or F# fields is evaluated as follows:

- The elaborated form is `expr.F` for an instance field or `F` for a static field.
- The (optional) `expr` is evaluated.
- If `expr` evaluates to `null`, a `NullReferenceException` is raised.
- The value of the field is read from either the global field table or the local field table associated
    with the object.

### 6.9.10 Evaluating Array Expressions

At runtime, an elaborated array expression `[| e1; ...; en |]ty` is evaluated as follows:

- Each expression `e1 ... en` is evaluated in order.
- The result of evaluation is a new array of runtime type `ty[]` that contains the resulting values in
    order.

### 6.9.11 Evaluating Record Expressions

At runtime, an elaborated record construction `{ field1 = e1; ... ; fieldn = en }ty` is evaluated as
follows:

- Each expression `e1 ... en` is evaluated in order.
- The result of evaluation is an object of type `ty` with the given field values

### 6.9.12 Evaluating Function Expressions

At runtime, an elaborated function expression `(fun v1 ... vn -> expr)` is evaluated as follows:

- The expression evaluates to a function object with a closure that assigns values to all variables
    that are referenced in `expr` and a function body that is `expr`.
- The values in the closure are the current values of those variables in the execution environment.
- The result of calling the `obj.GetType()` method on the resulting object is under-specified (see
    [§6.9.24](#6924-values-with-underspecified-object-identity-and-type-identity)).


### 6.9.13 Evaluating Object Expressions

At runtime, elaborated object expressions

```fsgrammar
{ new ty0 args-expr~opt object-members
      interface ty1 object-members1
      interface tyn object-membersn }
```
is evaluated as follows:

- The expression evaluates to an object whose runtime type is compatible with all of the `tyi` and
    which has the corresponding dispatch map ([§14.8](inference-procedures.md#dispatch-slot-checking)). If present, the base construction expression
    `ty0 (args-expr)` is executed as the first step in the construction of the object.
- The object is given a closure that assigns values to all variables that are referenced in `expr`.
- The values in the closure are the current values of those variables in the execution environment.

The result of calling the `obj.GetType()` method on the resulting object is under-specified (see
[§6.9.24](#6924-values-with-underspecified-object-identity-and-type-identity)).

### 6.9.14 Evaluating Definition Expressions

At runtime, each elaborated definition `pat = expr` is evaluated as follows:

- The expression `expr` is evaluated.
- The expression is then matched against `pat` to produce a value for each variable pattern ([§7.2](#72-named-patterns))
    in `pat`.
- These mappings are added to the local environment.

### 6.9.15 Evaluating Integer For Loops

At runtime, an integer for loop `for var = expr1 to expr2 do expr3 done` is evaluated as follows:

- Expressions `expr1` and `expr2` are evaluated once to values `v1` and `v2`.
- The expression `expr3` is evaluated repeatedly with the variable `var` assigned successive values in
    the range of `v1` up to `v2`.
- If `v1` is greater than `v2` , then `expr3` is never evaluated.

### 6.9.16 Evaluating While Loops

As runtime, while-loops `while expr1 do expr2 done` are evaluated as follows:

- Expression `expr1` is evaluated to a value `v1`.
- If `v1` is true, expression `expr2` is evaluated, and the expression `while expr1 do expr2 done` is
    evaluated again.
- If `v1` is `false`, the loop terminates and the resulting value is `null` (the representation of the only
    value of type `unit`)

### 6.9.17 Evaluating Static Coercion Expressions

At runtime, elaborated static coercion expressions of the form `expr :> ty` are evaluated as follows:

- Expression `expr` is evaluated to a value `v`.
- If the static type of `e` is a value type, and `ty` is a reference type, `v` is _boxed_ ; that is, `v` is converted
    to an object on the heap with the same field assignments as the original value. The expression
    evaluates to a reference to this object.
- Otherwise, the expression evaluates to `v`.

### 6.9.18 Evaluating Dynamic Type-Test Expressions

At runtime, elaborated dynamic type test expressions `expr :? ty` are evaluated as follows:

1. Expression `expr` is evaluated to a value `v`.
2. If `v` is `null`, then:
    - If `tye` uses `null` as a representation ([§5.4.8](#548-nullness)), the result is `true`.
    - Otherwise the expression evaluates to `false`.
3. If `v` is not `null` and has runtime type `vty` which dynamically converts to `ty` ([§5.4.10](#5410-dynamic-conversion-between-types)), the
    expression evaluates to `true`. However, if `ty` is an enumeration type, the expression evaluates to
    `true` if and only if `ty` is precisely `vty`.

### 6.9.19 Evaluating Dynamic Coercion Expressions

At runtime, elaborated dynamic coercion expressions `expr :?> ty` are evaluated as follows:

1. Expression `expr` is evaluated to a value `v`.
2. If `v` is `null`:
    - If `tye` uses `null` as a representation ([§5.4.8](#548-nullness)), the result is the `null` value.
    - Otherwise a `NullReferenceException` is raised.
3. If `v` is not `null`:
    - If `v` has dynamic type `vty` which _dynamically converts_ to `ty` ([§5.4.10](#5410-dynamic-conversion-between-types)), the expression evaluates to the dynamic conversion of `v` to `ty`.
        - If `vty` is a reference type and `ty` is a value type, then `v` is _unboxed_ ; that is, `v` is
             converted from an object on the heap to a struct value with the same field
             assignments as the object. The expression evaluates to this value.
        - Otherwise, the expression evaluates to `v`.
    - Otherwise an `InvalidCastException` is raised.

Expressions of the form `expr :?> ty` evaluate in the same way as the F# library function
`unbox<ty>(expr)`.

>   Note: Some F# types — most notably the `option<_>` type — use `null` as a representation
    for efficiency reasons ([§5.4.8](#548-nullness)). For these  types, boxing and unboxing can lose type
    distinctions. For example, contrast the following two examples:

    ```fsharp
    > (box([]:string list) :?> int list);;
    System.InvalidCastException...
    > (box(None:string option) :?> int option);;
    val it : int option = None
    ```

>    In the first case, the conversion from an empty list of strings to an empty list of integers
    (after first boxing) fails. In the second case, the conversion from a string option to an
    integer option (after first boxing) succeeds.
    
    
### 6.9.20 Evaluating Sequential Execution Expressions

At runtime, elaborated sequential expressions `expr1 ; expr2` are evaluated as follows:

- The expression `expr1` is evaluated for its side effects and the result is discarded.
- The expression `expr2` is evaluated to a value `v2` and the result of the overall expression is `v2`.

### 6.9.21 Evaluating Try-with Expressions

At runtime, elaborated try-with expressions try `expr1 with rules` are evaluated as follows:

- The expression `expr1` is evaluated to a value `v1`.
- If no exception occurs, the result is the value `v1`.
- If an exception occurs, the pattern rules are executed against the resulting exception value.
    - If no rule matches, the exception is reraised.
    - If a rule `pat -> expr2` matches, the mapping `pat = v1` is added to the local environment,
       and `expr2` is evaluated.

### 6.9.22 Evaluating Try-finally Expressions

At runtime, elaborated try-finally expressions try `expr1 finally expr2` are evaluated as follows:

- The expression `expr1` is evaluated.
    - If the result of this evaluation is a value `v` , then `expr2` is evaluated.
       1) If this evaluation results in an exception, then the overall result is that exception.
       2) If this evaluation does not result in an exception, then the overall result is `v`.
    - If the result of this evaluation is an exception, then `expr2` is evaluated.
       3) If this evaluation results in an exception, then the overall result is that exception.
       4) If this evaluation does not result in an exception, then the original exception is re-
          raised.

### 6.9.23 Evaluating AddressOf Expressions

At runtime, an elaborated address-of expression is evaluated as follows. First, the expression has
one of the following forms:

- `&path` where `path` is a static field.
- `&(expr.field)`
- `&(expra.[exprb])`
- `&v` where `v` is a local mutable value.

The expression evaluates to the address of the referenced local mutable value, mutable field, or
mutable static field.

> Note: The underlying CIL execution machinery that F# uses supports covariant arrays, as
evidenced by the fact that the type `string[]` dynamically converts to `obj[]` (§5.4.10).
Although this feature is rarely used in F#, its existence means that array assignments and
taking the address of array elements may fail at runtime with a
`System.ArrayTypeMismatchException` if the runtime type of the target array does not
match the runtime type of the element being assigned. For example, the following code
fails at runtime:
```fsharp
let f (x: byref<obj>) = ()

let a = Array.zeroCreate<obj> 10
let b = Array.zeroCreate<string> 10
f (&a.[0])
let bb = ((b :> obj) :?> obj[])
// The next line raises a System.ArrayTypeMismatchException exception.
F (&bb.[1])
```
### 6.9.24 Values with Underspecified Object Identity and Type Identity

The CLI and F# support operations that detect object identity—that is, whether two object
references refer to the same “physical” object. For example, `System.Object.ReferenceEquals(obj1, obj2)` 
returns true if the two object references refer to the same object. Similarly,
`System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode()` returns a hash code that is partly
based on physical object identity, and the `AddHandler` and `RemoveHandler` operations (which register
and unregister event handlers) are based on the object identity of delegate values.

The results of these operations are underspecified when used with values of the following F# types:

- Function types
- Tuple types
- Immutable record types
- Union types
- Boxed immutable value types

For two values of such types, the results of `System.Object.ReferenceEquals` and
`System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode` are underspecified; however, the
operations terminate and do not raise exceptions. An implementation of F# is not required to define
the results of these operations for values of these types.

For function values and objects that are returned by object expressions, the results of the following
operations are underspecified in the same way:

- `Object.GetHashCode()`
- `Object.GetType()`

For union types the results of the following operations are underspecified in the same way:

- `Object.GetType()`
# 7. Patterns

Patterns are used to perform simultaneous case analysis and decomposition on values together with
the `match`, `try...with`, `function`, `fun`, and `let` expression and declaration constructs. Rules are
attempted in order from top to bottom and left to right. The syntactic forms of patterns are shown
in the subsequent table.

```fsgrammar
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

## 7.1 Simple Constant Patterns

The pattern `const` is a _constant pattern_ which matches values equal to the given constant. For
example:

```fsharp
let rotate3 x =
    match x with
    | 0 -> "two"
    | 1 -> "zero"
    | 2 -> "one"
    | _ -> failwith "rotate3"
```
In this example, the constant patterns are 0, 1, and 2. Any constant listed in [§6.3.1](#631-simple-constant-expressions) may be used as a
constant pattern except for integer literals that have the suffixes `Q`, `R`, `Z`, `I`, `N`, `G`.

Simple constant patterns have the corresponding simple type. Such patterns elaborate to a call to
the F# structural equality function `FSharp.Core.Operators.(=)` with the pattern input and the
constant as arguments. The match succeeds if this call returns `true`; otherwise, the match fails.


> **Note**: The use of `FSharp.Core.Operators.(=)` means that CLI floating-point equality is
used to match floating-point values, and CLI ordinal string equality is used to match
strings.

## 7.2 Named Patterns

Patterns in the following forms are _named patterns_ :

```fsgrammar
Long-ident
Long-ident pat
Long-ident pat-params pat
```

If `long-ident` is a single identifier that does not begin with an uppercase character, it is interpreted
as a _variable pattern_. During checking, the variable is assigned the same value and type as the
pattern input.

If `long-ident` is more than one-character long or begins with an uppercase character (that is, if
`System.Char.IsUpperInvariant` is `true` and `System.Char.IsLowerInvariant` is `false` on the first
character), it is resolved by using _Name Resolution in Patterns_ ([§14.1.6](inference-procedures.md#name-resolution-in-patterns)). This algorithm produces one
of the following:

- A union case
- An exception label
- An active pattern case name
- A literal value

Otherwise, `long-ident` must be a single uppercase identifier `ident`. In this case, `pat` is a variable
pattern. An F# implementation may optionally generate a warning if the identifier is uppercase. Such
a warning is recommended if the length of the identifier is greater than two.

After name resolution, the subsequent treatment of the named pattern is described in the following
sections.

### 7.2.1 Union Case Patterns

If `long-ident` from [§7.2](#72-named-patterns) resolves to a union case, the pattern is a union case pattern. If `long-ident`
resolves to a union case `Case` , then `long-ident` and `long-ident pat` are patterns that match pattern
inputs that have union case label `Case`. The `long-ident` form is used if the corresponding case takes
no arguments, and the `long-ident pat` form is used if it takes arguments.

At runtime, if the pattern input is an object that has the corresponding union case label, the data
values carried by the union are matched against the given argument patterns.

For example:

```fsharp
type Data =
    | Kind1 of int * int
    | Kind2 of string * string

let data = Kind1(3, 2)

let result =
    match data with
    | Kind1 (a, b) -> a + b
    | Kind2 (s1, s2) -> s1.Length + s2.Length
```
In this case, result is given the value 5.

When a union case has named fields, these names may be referenced in a union case pattem. When
using pattern matching with multiple fields, semicolons are used to delimit the named fields. For
example

```fsharp
type Shape =
    | Rectangle of width: float * height: float
    | Square of width: float

let getArea (s: Shape) =
    match s with
    | Rectangle (width = w; height = h) -> w*h
    | Square (width = w) -> w*w
```
### 7.2.2 Literal Patterns

If `long-ident` from [§7.2](#72-named-patterns) resolves to a literal value, the pattern is a literal pattern. The pattern is
equivalent to the corresponding constant pattern.

In the following example, the `Literal` attribute ([§10.2.2](namespaces-and-modules.md#literal-definitions-in-modules)) is first used to define two literals, and these
literals are used as identifiers in the match expression:

```fsharp
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
In this case, `result` is given the value `Case2`.

### 7.2.3 Active Patterns

If `long-ident` from [§7.2](#72-named-patterns) resolves to an _active pattern case name `CaseNamei`_ then the pattern is an
active pattern. The rules for name resolution in patterns ([§14.1.6](inference-procedures.md#name-resolution-in-patterns)) ensure that `CaseNamei` is
associated with an _active pattern function `f`_ in one of the following forms:

- `(| CaseName |) inp`

  Single case. The function accepts one argument (the value being matched) and can return any
type.

- `(| CaseName |_|) inp`

  Partial. The function accepts one argument (the value being matched) and must return a value
of type `FSharp.Core.option<_>`

- `(| CaseName1 | ...| CaseNamen |) inp`

  Multi-case. The function accepts one argument (the value being matched), and must return a
value of type `FSharp.Core.Choice<_,...,_>` based on the number of case names. In F#, the
limitation n ≤ 7 applies.

- `(| CaseName |) arg1 ... argn inp`

  Single case with parameters. The function accepts `n+1` arguments, where the last argument (`inp`)
is the value to match, and can return any type.


- `(| CaseName |_|) arg1 ... argn inp`

  Partial with parameters. The function accepts n +1 arguments, where the last argument (`inp`) is
the value to match, and must return a value of type `FSharp.Core.option<_>`.

Other active pattern functions are not permitted. In particular, multi-case, partial functions such as
the following are not permitted:

```fsharp
(|CaseName1| ... |CaseNamen|_|)
```

When an active pattern function takes arguments, the `pat-params` are interpreted as expressions
that are passed as arguments to the active pattern function. The `pat-params` are converted to the
syntactically identical corresponding expression forms and are passed as arguments to the active
pattern function `f`.

At runtime, the function `f` is applied to the pattern input, along with any parameters. The pattern
matches if the active pattern function returns `v` , `ChoicekOfN v` , or Some `v` , respectively, when applied
to the pattern input. If the pattern argument `pat` is present, it is then matched against `v`.

The following example shows how to define and use a partial active pattern function:

```fsharp
let (|Positive|_|) inp = if inp > 0 then Some(inp) else None
let (|Negative|_|) inp = if inp < 0 then Some(-inp) else None

match 3 with
| Positive n -> printfn "positive, n = %d" n
| Negative n -> printfn "negative, n = %d" n
| _ -> printfn "zero"
```
The following example shows how to define and use a multi-case active pattern function:

```fsharp
let (|A|B|C|) inp = if inp < 0 then A elif inp = 0 then B else C

match 3 with
| A -> "negative"
| B -> "zero"
| C - > "positive"
```
The following example shows how to define and use a parameterized active pattern function:

```fsharp
let (|MultipleOf|_|) n inp = if inp%n = 0 then Some (inp / n) else None

match 16 with
| MultipleOf 4 n -> printfn "x = 4*%d" n
| _ -> printfn "not a multiple of 4"
```
An active pattern function is executed only if a left-to-right, top-to-bottom reading of the entire
pattern indicates that execution is required. For example, consider the following active patterns:

```fsharp
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

```fsharp
f 0 // 0
f 1 // 1
f 2 // failwith "x is two"
f 3 // failwith "x is three"
f 4 // failwith "got to C"
```
An active pattern function may be executed multiple times against the same pattern input during
resolution of a single overall pattern match. The precise number of times that the active pattern
function is executed against a particular pattern input is implementation-dependent.

## 7.3 “As” Patterns

An “as” pattern is of the following form:

```fsgrammar
pat as ident
```
The “as” pattern defines `ident` to be equal to the pattern input and matches the pattern input
against `pat`. For example:

```fsharp
let t1 = (1, 2)
let (x, y) as t2 = t1
printfn "%d-%d-%A" x y t2 // 1- 2 - (1, 2)
```
This example binds the identifiers `x`, `y`, and `t1` to the values `1` , `2` , and `(1,2)`, respectively.

## 7.4 Wildcard Patterns

The pattern `_` is a wildcard pattern and matches any input. For example:

```fsharp
let categorize x =
    match x with
    | 1 - > 0
    | 0 -> 1
    | _ -> 0
```
In the example, if `x` is `0`, the match returns `1`. If `x` has any other value, the match returns `0`.


## 7.5 Disjunctive Patterns

A disjunctive pattern matches an input value against one or the other of two patterns:

```fsgrammar
pat | pat
```
At runtime, the patterm input is matched against the first pattern. If that fails, the pattern input is
matched against the second pattern. Both patterns must bind the same set of variables with the
same types. For example:

```fsharp
type Date = Date of int * int * int

let isYearLimit date =
    match date with
    | (Date (year, 1, 1) | Date (year, 12, 31)) -> Some year
    | _ -> None

let result = isYearLimit (Date (2010,12,31))
```
In this example, `result` is given the value `true`, because the pattern input matches the second
pattern.

## 7.6 Conjunctive Patterns

A conjunctive pattern matches the pattern input against two patterns.

```fsgrammar
pat1 & pat2
```
For example:

```fsharp
let (|MultipleOf|_|) n inp = if inp%n = 0 then Some (inp / n) else None

let result =
match 56 with
    | MultipleOf 4 m & MultipleOf 7 n -> m + n
    | _ -> false
```
In this example, `result` is given the value `22` (= 16 + 8), because the pattern input match matches
both patterns.

## 7.7 List Patterns

The pattern `pat :: pat` is a union case pattern that matches the “cons” union case of F# list values.

The pattern `[]` is a union case pattern that matches the “nil” union case of F# list values.

The pattern `[ pat1 ; ... ; patn ]` is shorthand for a series of `::` and empty list patterns
`pat1 :: ... :: patn :: []`.

For example:

```fsharp
let rec count x =
    match x with
    | [] -> 0
    | h :: t -> h + count t

let result1 = count [1;2;3]

let result2 =
    match [1;2;3] with
    | [a;b;c] -> a + b + c
    | _ -> 0
```
In this example, both `result1` and `result2` are given the value `6`.

## 7.8 Type-annotated Patterns

A _type-annotated pattern_ specifies the type of the value to match to a pattern.

```fsgrammar
pat : type
```
For example:

```fsharp
let rec sum xs =
    match xs with
    | [] -> 0
    | (h : int) :: t -> h + sum t
```
In this example, the initial type of `h` is asserted to be equal to `int` before the pattern `h` is checked.
Through type inference, this in turn implies that `xs` and `t` have static type `int list`, and `sum` has
static type
`int list -> int`.

## 7.9 Dynamic Type-test Patterns

_Dynamic type-test patterns_ have the following two forms:

```fsgrammar
:? type
:? type as ident
```
A dynamic type-test pattern matches any value whose runtime type is `type` or a subtype of `type`. For
example:

```fsharp
let message (x : System.Exception) =
    match x with
    | :? System.OperationCanceledException -> "cancelled"
    | :? System.ArgumentException -> "invalid argument"
    | _ -> "unknown error"
```
If the type-test pattern is of the form `:? type as ident`, then the value is coerced to the given type
and `ident` is bound to the result. For example:

```fsharp
let findLength (x : obj) =
match x with
    | :? string as s -> s.Length
    | _ -> 0
```

In the example, the identifier `s` is bound to the value `x` with type `string`.

If the pattern input has type `tyin`, pattern checking uses the same conditions as both a dynamic type-
test expression `e :? type` and a dynamic coercion expression `e :?> type` where `e` has type `tyin`. An
error occurs if `type` cannot be statically determined to be a subtype of the type of the pattern input.
A warning occurs if the type test will always succeed based on `type` and the static type of the pattern
input.

A warning is issued if an expression contains a redundant dynamic type-test pattern, after any
coercion is applied. For example:

```fsharp
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
expression `e :? ty` would return true where `e` is the pattern input. The value of the pattern is bound
to the results of a dynamic coercion expression `e :?> ty`.

## 7.10 Record Patterns

The following is a _record pattern_ :

```fsgrammar
{ long-ident1 = pat1 ; ... ; long-identn = patn }
```
For example:

```fsharp
type Data = { Header:string; Size: int; Names: string list }

let totalSize data =
    match data with
    | { Header = "TCP"; Size = size; Names = names } -> size + names.Length * 12
    | { Header = "UDP"; Size = size } -> size
    | _ -> failwith "unknown header"
```
The `long-identi` are resolved in the same way as field labels for record expressions and must
together identify a single, unique F# record type. Not all record fields for the type need to be
specified in the pattern.

## 7.11 Array Patterns

An _array pattern_ matches an array of a partciular length:

```fsgrammar
[| pat ; ... ; pat |]
```

For example:

```fsharp
let checkPackets data =
    match data with
    | [| "HeaderA"; data1; data2 |] -> (data1, data2)
    | [| "HeaderB"; data2; data1 |] -> (data1, data2)
    | _ -> failwith "unknown packet"
```
## 7.12 Null Patterns

The _null pattern_ null matches values that are represented by the CLI value null. For example:

```fsharp
let path =
    match System.Environment.GetEnvironmentVariable("PATH") with
    | null -> failwith "no path set!"
    | res -> res
```
Most F# types do not use `null` as a representation; consequently, the null pattern is generally used
to check values passed in by CLI method calls and properties. For a list of F# types that use `null` as a
representation, see [§5.4.8](#548-nullness).

## 7.13 Guarded Pattern Rules

_Guarded pattern rules_ have the following form:

```fsgrammar
pat when expr
```
For example:

```fsharp
let categorize x =
    match x with
    | _ when x < 0 -> - 1
    | _ when x < 0 -> 1
    | _ -> 0
```
The guards on a rule are executed only after the match value matches the corresponding pattern.
For example, the following evaluates to `2` with no output.

```fsharp
match (1, 2) with
| (3, x) when (printfn "not printed"; true) -> 0
| (_, y) -> y
```
