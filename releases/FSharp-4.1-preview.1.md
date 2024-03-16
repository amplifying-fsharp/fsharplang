WIP 2024-03-16 09:57:50
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

An F# list is an immutable linked list, which is a type of data used extensively in functional programming. Some operators that are related to lists include :: to add an item to the front of a list and @ to concatenate two lists. If we try these operators in F# Interactive, we see the following
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

The F# library function printfn is a simple and type-safe way to print text in the console window. Consider this example, which prints an integer, a floating-point number, and a string:

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

The sample program shown at the start of this chapter is a `script`. Although scripts are excellent for rapid prototyping, they are not suitable for larger software components. F# supports the transition from scripting to structured code through several techniques.

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

Modules are also used in the F# library design to associate extra functionality with types. For example, `List.map´ is a function in a module.

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

In the grammar rules, the notation `element-nameopt` indicates an optional element. The notation `...` indicates repetition of the preceding non-terminal construct and the separator token. For example, `expr ',' ... ',' expr` means a sequence of one or more `expr` elements separated by commas.
# 2. Program Structure

The inputs to the F# compiler or the F# Interactive dynamic compiler consist of:

- Source code files, with extensions `.fs`, `.fsi`, `.fsx`, or `.fsscript`.
    - Files with extension `.fs` must conform to grammar element _`implementation-file`_ in [§12.1](program-structure-and-execution.md#implementation-files).
    - Files with extension `.fsi` must conform to grammar element _`signature-file`_ in [§12.2](program-structure-and-execution.md#signature-files).
    - Files with extension `.fsx` or `.fsscript` must conform to grammar element _`script-file`_ in
      [§12.3](program-structure-and-execution.md#script-files).
- Script fragments (for F# Interactive). These must conform to grammar element _`script-fragment`_.
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
   reflection, and the F# expression trees that are returned by quoted expressions ([§6.8](expressions.md#quoted-expressions)).
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

If an _`if-directive`_ token is matched during tokenization, text is recursively tokenized until a
corresponding _`else-directive`_ or _`endif-directive`_. If the evaluation of the associated
_`if-expression-text`_ when parsed as an _if-expression_ is true in the compilation environment defines
(where each _`ident-text`_ is evaluataed according to the values given by command line options such
as `–define`), the token stream includes the tokens between the _`if-directive`_ and the corresponding
_`else-directive`_ or _`endif-directive`_. Otherwise, the tokens are discarded. The converse applies to
the text between any corresponding _`else-directive`_ and the _`endif-directive`_.

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
- Identifiers, as described in the previous section, such as “abc”
- Trigraph specifications of Unicode characters, such as “`\067`” which represents “C”

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
for the _`string-char`_ elements within the string. Strings may include `\n` as a newline character.
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

The `quote-op-left` and `quote-op-right` operators are used in quoted expressions ([§6.8](expressions.md#quoted-expressions)).

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

Several places in the grammar refer to an _`ident-or-op`_ rather than an _`ident`_ :

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
This example defines the binary operator `+++`. The text `(+++)` is an _`ident-or-op`_ that acts as an
identifier with associated text `+++`. Likewise, for active pattern definitions (§ 7), the active pattern
case names are placed in parentheses, as in the following example:

```fsgrammar
let (|A|B|C|) x = if x < 0 then A elif x = 0 then B else C
```
Because an _`ident-or-op`_ acts as an identifier, such names can be used in expressions. For example:

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

Compiled names for other symbolic operators are `op_N1` ... `Nn` where N1 to Nn are the names for the
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

Long identifiers _`long-ident`_ are sequences of identifiers that are separated by ‘`.`’ and optional
whitespace. Long identifiers _`long-ident-or-op`_ are long identifiers that may terminate with an
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

The following _`symbolic-op`_ tokens can be used to form prefix and infix expressions. The marker `OP`
represents all _`symbolic-op`_ tokens that begin with the indicated prefix, except for tokens that appear
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
the _`symbolic-op`_ tokens that begin with the specified prefix, except those listed elsewhere in the
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
In this expression, the _`expr infix-op expr`_ rule for `b * c` takes precedence over the 
_`expr infix-op expr`_ rule for `a + b`, because the `*` operator has higher precedence than the `+` operator. Thus, this
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
