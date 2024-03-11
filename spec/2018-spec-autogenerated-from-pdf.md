# The F# 4.1 Language Specification

Note: This documentation is the specification of version 4.1 of the F# language, released in 2015- 16.

Note: thi does not yet incorporate the RFCs for F# 4.1, see

https://github.com/fsharp/fslang-design/tree/master/FSharp-4.

https://github.com/fsharp/fslang-design/tree/master/FSharp-4.1b

Discrepancies may exist between this specification and the 4.1 implementation. Some of these are
noted as comments in this document. If you find further discrepancies please contact us and we will
gladly address the issue in future releases of this specification. The F# team is always grateful for
feedback on this specification, and on both the design and implementation of F#. You can submit
feedback by opening issues, comments and pull requests at
https://github.com/fsharp/fsfoundation/tree/gh-pages/specs/language-spec.

The latest version of this specification can be found at fsharp.org. Many thanks to the F# user
community for their helpful feedback on the document so far.

Certain parts of this specification refer to the C# 4.0, Unicode, and IEEE specifications.

**Authors:** Don Syme, with assistance from Anar Alimov, Keith Battocchi, Jomo Fisher, Michael Hale,
Jack Hu, Luke Hoban, Tao Liu, Dmitry Lomov, James Margetson, Brian McNamara, Joe Pamer, Penny
Orwick, Daniel Quirk, Kevin Ransom, Chris Smith, Matteo Taveggia, Donna Malayeri, Wonseok Chae,
Uladzimir Matsveyeu, Lincoln Atkinson, and others.

**Notice**

_© 2005 - 2016 various contributors. Made available under the_ Creative Commons CC-by 4.0 _licence._

_Product and company names mentioned herein may be the trademarks of their respective owners._

**Document Updates:**

- Initial updates for F# 4.1, May 2018
- Updates for F# 4.0, January 2016
- Updates for F# 3.1 and type providers, January 2016
- Edits to change version numbers for F# 3.1, May 2014
- Initial updates for F# 3.1, June 2013 (see online description of language updates)
- Updated to F# 3.0, September 2012
- Updated with formatting changes, April 2012
- Updated with grammar summary, December 2011


## Table of Contents









      - • Updated with glossary, index, and style corrections, February
      - • Updated with glossary, index, and style corrections, August
- 1. INTRODUCTION
    - 1.1 A FIRST PROGRAM
        - 1.1.1 Lightweight Syntax
        - 1.1.2 Making Data Simple
        - 1.1.3 Making Types Simple
        - 1.1.4 Functional Programming
        - 1.1.5 Imperative Programming
        - 1.1.6 .NET Interoperability and CLI Fidelity
        - 1.1.7 Parallel and Asynchronous Programming
        - 1.1.8 Strong Typing for Floating-Point Code
        - 1.1.9 Object-Oriented Programming and Code Organization
        - 1.1.10 Information-rich Programming
    - 1.2 NOTATIONAL CONVENTIONS IN THIS SPECIFICATION
- 2. PROGRAM STRUCTURE
- 3. LEXICAL ANALYSIS
    - 3.1 WHITESPACE
    - 3.2 COMMENTS
    - 3.3 CONDITIONAL COMPILATION
    - 3.4 IDENTIFIERS AND KEYWORDS
    - 3.5 STRINGS AND CHARACTERS
    - 3.6 SYMBOLIC KEYWORDS
    - 3.7 SYMBOLIC OPERATORS
    - 3.8 NUMERIC LITERALS
        - 3.8.1 Post-filtering of Adjacent Prefix Tokens
        - 3.8.2 Post-filtering of Integers Followed by Adjacent “..”
        - 3.8.3 Reserved Numeric Literal Forms
        - 3.8.4 Shebang
    - 3.9 LINE DIRECTIVES
    - 3.10 HIDDEN TOKENS
    - 3.11 IDENTIFIER REPLACEMENTS
- 4. BASIC GRAMMAR ELEMENTS..............................................................................................
    - 4.1 OPERATOR NAMES
    - 4.2 LONG IDENTIFIERS
    - 4.3 CONSTANTS
    - 4.4 OPERATORS AND PRECEDENCE
        - 4.4.1 Categorization of Symbolic Operators
        - 4.4.2 Precedence of Symbolic Operators and Pattern/Expression Constructs
- 5. TYPES AND TYPE CONSTRAINTS
    - 5.1 CHECKING SYNTACTIC TYPES
        - 5.1.1 Named Types
        - 5.1.2 Variable Types
        - 5.1.3 Tuple Types
        - 5.1.4 Array Types
        - 5.1.5 Constrained Types
    - 5.2 TYPE CONSTRAINTS
        - 5.2.1 Subtype Constraints
        - 5.2.2 Nullness Constraints
        - 5.2.3 Member Constraints
        - 5.2. 4 Default Constructor Constraints
        - 5.2.5 Value Type Constraints
        - 5.2.6 Reference Type Constraints
        - 5.2.7 Enumeration Constraints
        - 5.2.8 Delegate Constraints
        - 5.2.9 Unmanaged Constraints
        - 5.2.10 Equality and Comparison Constraints
    - 5.3 TYPE PARAMETER DEFINITIONS
    - 5.4 LOGICAL PROPERTIES OF TYPES
        - 5.4.1 Characteristics of Type Definitions
        - 5.4.2 Expanding Abbreviations and Inference Equations
        - 5.4.3 Type Variables and Definition Sites
        - 5.4.4 Base Type of a Type
        - 5.4.5 Interfaces Types of a Type
        - 5.4.6 Type Equivalence
        - 5.4.7 Subtyping and Coercion
        - 5.4.8 Nullness
        - 5.4.9 Default Initialization
        - 5.4.10 Dynamic Conversion Between Types
- 6. EXPRESSIONS
    - 6.1 SOME CHECKING AND INFERENCE TERMINOLOGY
    - 6.2 ELABORATION AND ELABORATED EXPRESSIONS
    - 6.3 DATA EXPRESSIONS
        - 6.3.1 Simple Constant Expressions
        - 6.3.2 Tuple Expressions
        - 6.3. 3 List Expressions
        - 6.3.4 Array Expressions
        - 6.3.5 Record Expressions
        - 6.3.6 Copy-and-update Record Expressions
        - 6.3.7 Function Expressions
        - 6.3.8 Object Expressions
        - 6.3.9 Delayed Expressions
        - 6.3.10 Computation Expressions
    - 6.3.11 Sequence Expressions
    - 6.3.12 Range Expressions
    - 6.3.13 Lists via Sequence Expressions
    - 6.3.14 Arrays Sequence Expressions
    - 6.3.15 Null Expressions
    - 6.3.16 'printf' Formats
- 6.4 APPLICATION EXPRESSIONS
    - 6.4.1 Basic Application Expressions
    - 6.4.2 Object Construction Expressions
    - 6.4.3 Operator Expressions
    - 6.4.4 Dynamic Operator Expressions
    - 6.4.5 The AddressOf Operators
    - 6.4.6 Lookup Expressions
    - 6.4.7 Slice Expressions
    - 6.4. 8 Member Constraint Invocation Expressions
    - 6.4.9 Assignment Expressions
- 6.5 CONTROL FLOW EXPRESSIONS
    - 6.5.1 Parenthesized and Block Expressions
    - 6.5.2 Sequential Execution Expressions
    - 6.5.3 Conditional Expressions
    - 6.5.4 Shortcut Operator Expressions
    - 6.5.5 Pattern-Matching Expressions and Functions
    - 6.5.6 Sequence Iteration Expressions
    - 6.5.7 Simple for-Loop Expressions
    - 6.5.8 While Expressions
    - 6.5. 9 Try-with Expressions
    - 6.5.10 Reraise Expressions
    - 6.5.11 Try-finally Expressions
    - 6.5.12 Assertion Expressions
- 6.6 DEFINITION EXPRESSIONS
    - 6.6.1 Value Definition Expressions
    - 6.6.2 Function Definition Expressions.......................................................................................
    - 6.6.3 Recursive Definition Expressions
    - 6.6.4 Deterministic Disposal Expressions
- 6.7 TYPE-RELATED EXPRESSIONS
    - 6.7.1 Type-Annotated Expressions
    - 6.7.2 Static Coercion Expressions
    - 6.7.3 Dynamic Type-Test Expressions
    - 6.7.4 Dynamic Coercion Expressions
- 6.8 QUOTED EXPRESSIONS
    - 6.8.1 Strongly Typed Quoted Expressions
    - 6.8.2 Weakly Typed Quoted Expressions
    - 6.8.3 Expression Splices
- 6.9 EVALUATION OF ELABORATED FORMS
    - 6.9.1 Values and Execution Context
        - 6.9.2 Parallel Execution and Memory Model
        - 6.9.3 Zero Values
        - 6.9.4 Taking the Address of an Elaborated Expression
        - 6.9.5 Evaluating Value References
        - 6.9.6 Evaluating Function Applications
        - 6.9.7 Evaluating Method Applications
        - 6.9.8 Evaluating Union Cases
        - 6.9.9 Evaluating Field Lookups
        - 6.9.10 Evaluating Array Expressions
        - 6.9.11 Evaluating Record Expressions
        - 6.9.12 Evaluating Function Expressions
        - 6.9.13 Evaluating Object Expressions
        - 6.9.14 Evaluating Definition Expressions
        - 6.9.15 Evaluating Integer For Loops
        - 6.9.16 Evaluating While Loops
        - 6.9.17 Evaluating Static Coercion Expressions
        - 6.9.18 Evaluating Dynamic Type-Test Expressions
        - 6.9.19 Evaluating Dynamic Coercion Expressions
        - 6.9.20 Evaluating Sequential Execution Expressions
        - 6.9.21 Evaluating Try-with Expressions
        - 6.9.22 Evaluating Try-finally Expressions
        - 6.9.23 Evaluating AddressOf Expressions
        - 6.9.24 Values with Underspecified Object Identity and Type Identity
- 7. PATTERNS
    - 7.1 SIMPLE CONSTANT PATTERNS
    - 7.2 NAMED PATTERNS
        - 7.2.1 Union Case Patterns
        - 7.2.2 Literal Patterns
        - 7.2.3 Active Patterns
    - 7.3 “AS” PATTERNS
    - 7.4 WILDCARD PATTERNS
    - 7.5 DISJUNCTIVE PATTERNS
    - 7.6 CONJUNCTIVE PATTERNS
    - 7. 7 LIST PATTERNS
    - 7.8 TYPE-ANNOTATED PATTERNS
    - 7.9 DYNAMIC TYPE-TEST PATTERNS
    - 7.10 RECORD PATTERNS
    - 7.11 ARRAY PATTERNS
    - 7.12 NULL PATTERNS
    - 7.13 GUARDED PATTERN RULES
- 8. TYPE DEFINITIONS
    - 8.1 TYPE DEFINITION GROUP CHECKING AND ELABORATION
    - 8.2 TYPE KIND INFERENCE
    - 8.3 TYPE ABBREVIATIONS
- 8.4 RECORD TYPE DEFINITIONS
    - 8.4.1 Members in Record Types
    - 8.4.2 Name Resolution and Record Field Labels
    - 8.4.3 Structural Hashing, Equality, and Comparison for Record Types
    - 8.4.4 With/End in Record Type Definitions
    - 8.4.5 CLIMutable Attributes
- 8.5 UNION TYPE DEFINITIONS
    - 8.5.1 Members in Union Types
    - 8.5.2 Structural Hashing, Equality, and Comparison for Union Types
    - 8.5.3 With/End in Union Type Definitions
    - 8.5.4 Compiled Form of Union Types for Use from Other CLI Languages
- 8.6 CLASS TYPE DEFINITIONS
    - 8.6.1 Primary Constructors in Classes
    - 8.6.2 Members in Classes
    - 8.6.3 Additional Object Constructors in Classes
    - 8.6.4 Additional Fields in Classes
- 8.7 INTERFACE TYPE DEFINITIONS...................................................................................................
- 8.8 STRUCT TYPE DEFINITIONS
- 8.9 ENUM TYPE DEFINITIONS
- 8.10 DELEGATE TYPE DEFINITIONS
- 8.11 EXCEPTION DEFINITIONS..........................................................................................................
- 8.12 TYPE EXTENSIONS
    - 8.12.1 Imported CLI C# Extensions Members
- 8.13 MEMBERS
    - 8.13.1 Property Members
    - 8.13.2 Auto-implemented Properties
    - 8.13.3 Method Members
    - 8.13.4 Curried Method Members
    - 8.13.5 Named Arguments to Method Members
    - 8.13.6 Optional Arguments to Method Members
    - 8.13.7 Type-directed Conversions at Member Invocations
    - 8.13.8 Overloading of Methods
    - 8.13.9 Naming Restrictions for Members
    - 8.13.10 Members Represented as Events
    - 8.13.11 Members Represented as Static Members
- 8.14 ABSTRACT MEMBERS AND INTERFACE IMPLEMENTATIONS
    - 8.14.1 Abstract Members
    - 8.14.2 Members that Implement Abstract Members
    - 8.14.3 Interface Implementations
- 8.15 EQUALITY, HASHING, AND COMPARISON
    - 8.15.1 Equality Attributes
    - 8.15.2 Comparison Attributes
    - 8.15.3 Behavior of the Generated Object.Equals Implementation
    - 8.15.4 Behavior of the Generated CompareTo Implementations
    - 8.15.5 Behavior of the Generated GetHashCode Implementations.....................................
        - 8.15.6 Behavior of Hash, =, and Compare
- 9. UNITS OF MEASURE
    - 9.1 MEASURES
    - 9.2 CONSTANTS ANNOTATED BY MEASURES
    - 9.3 RELATIONS ON MEASURES
        - 9.3.1 Constraint Solving
        - 9.3.2 Generalization of Measure Variables
    - 9.4 MEASURE DEFINITIONS
    - 9.5 MEASURE PARAMETER DEFINITIONS
    - 9.6 MEASURE PARAMETER ERASURE
    - 9.7 TYPE DEFINITIONS WITH MEASURES IN THE F# CORE LIBRARY
    - 9.8 RESTRICTIONS
- 10. NAMESPACES AND MODULES
    - 10.1 NAMESPACE DECLARATION GROUPS
    - 10.2 MODULE DEFINITIONS
        - 10.2.1 Function and Value Definitions in Modules
        - 10.2.2 Literal Definitions in Modules
        - 10.2.3 Type Function Definitions in Modules
        - 10.2.4 Active Pattern Definitions in Modules.......................................................................
        - 10.2.5 “do” statements in Modules
    - 10.3 IMPORT DECLARATIONS
    - 10.4 MODULE ABBREVIATIONS
    - 10 .5 ACCESSIBILITY ANNOTATIONS
- 11. NAMESPACE AND MODULE SIGNATURES
    - 11.1 SIGNATURE ELEMENTS
        - 11.1.1 Value Signatures
        - 11.1.2 Type Definition and Member Signatures
    - 11.2 SIGNATURE CONFORMANCE
        - 11.2.1 Signature Conformance for Functions and Values
        - 11.2.2 Signature Conformance for Members.......................................................................
- 12. PROGRAM STRUCTURE AND EXECUTION
    - 12.1 IMPLEMENTATION FILES
    - 12.2 SIGNATURE FILES
    - 12.3 SCRIPT FILES
    - 12.4 COMPILER DIRECTIVES
    - 12 .5 PROGRAM EXECUTION
        - 12.5.1 Execution of Static Initializers
        - 12.5.2 Explicit Entry Point
- 13. CUSTOM ATTRIBUTES AND REFLECTION
    - 13.1 CUSTOM ATTRIBUTES
        - 13.1.1 Custom Attributes and Signatures
    - 13.2 REFLECTED FORMS OF DECLARATION ELEMENTS
- 14. INFERENCE PROCEDURES
    - 14.1 NAME RESOLUTION
        - 14.1.1 Name Environments
        - 14.1.2 Name Resolution in Module and Namespace Paths
        - 14.1.3 Opening Modules and Namespace Declaration Groups
        - 14.1.4 Name Resolution in Expressions
        - 14.1.5 Name Resolution for Members
        - 14.1.6 Name Resolution in Patterns
        - 14.1.7 Name Resolution for Types
        - 14.1.8 Name Resolution for Type Variables
        - 14.1.9 Field Label Resolution
    - 14.2 RESOLVING APPLICATION EXPRESSIONS......................................................................................
        - 14.2.1 Unqualified Lookup
        - 14.2.2 Item-Qualified Lookup
        - 14.2.3 Expression-Qualified Lookup
    - 14.3 FUNCTION APPLICATION RESOLUTION
    - 14.4 METHOD APPLICATION RESOLUTION
        - 14.4.1 Additional Propagation of Known Type Information in F# 3.1
        - 14.4.2 Conditional Compilation of Member Calls
        - 14.4.3 Implicit Insertion of Flexibility for Uses of Functions and Members
    - 14.5 CONSTRAINT SOLVING
        - 14.5.1 Solving Equational Constraints
        - 14.5.2 Solving Subtype Constraints
        - 14.5.3 Solving Nullness, Struct, and Other Simple Constraints
        - 14.5.4 Solving Member Constraints
        - 14.5.5 Over-constrained User Type Annotations
    - 14.6 CHECKING AND ELABORATING FUNCTION, VALUE, AND MEMBER DEFINITIONS
        - 14.6.1 Ambiguities in Function and Value Definitions
        - 14.6.2 Mutable Value Definitions
        - 14.6.3 Processing Value Definitions
        - 14.6.4 Processing Function Definitions
        - 14.6.5 Processing Recursive Groups of Definitions
        - 14.6.6 Recursive Safety Analysis
        - 14.6.7 Generalization
        - 14.6.8 Condensation of Generalized Types
    - 14.7 DISPATCH SLOT INFERENCE
    - 14.8 DISPATCH SLOT CHECKING
    - 14.9 BYREF SAFETY ANALYSIS
    - 14.10 ARITY INFERENCE
    - 14.11 ADDITIONAL CONSTRAINTS ON CLI METHODS
- 15. LEXICAL FILTERING
    - 15.1 LIGHTWEIGHT SYNTAX
        - 15.1.1 Basic Lightweight Syntax Rules by Example
        - 15.1.2 Inserted Tokens
        - 15.1.3 Grammar Rules Including Inserted Tokens
        - 15.1.4 Offside Lines
        - 15.1.5 The Pre-Parse Stack...................................................................................................
        - 15.1.6 Full List of Offside Contexts
        - 15.1.7 Balancing Rules
        - 15.1.8 Offside Tokens, Token Insertions, and Closing Contexts
        - 15.1.9 Exceptions to the Offside Rules
        - 15.1.10 Permitted Undentations............................................................................................
    - 15.2 HIGH PRECEDENCE APPLICATION
    - 15.3 LEXICAL ANALYSIS OF TYPE APPLICATIONS
- 16. PROVIDED TYPES
    - 16.1 STATIC PARAMETERS
        - 16.1.1 Mangling of Static Parameter Values
    - 16.2 PROVIDED NAMESPACE
    - 16.3 PROVIDED TYPE DEFINITIONS
        - 16.3.1 Generated v. Erased Types
        - 16.3.2 Type References
        - 16.3.3 Static Parameters
        - 16.3.4 Kind
        - 16.3.5 Inheritance
        - 16.3.6 Members
        - 16.3.7 Attributes
        - 16.3.8 Accessibility
        - 16.3.9 Elaborated Code
        - 16.3.10 Further Restrictions
- 17. SPECIAL ATTRIBUTES AND TYPES
    - 17.1 CUSTOM ATTRIBUTES RECOGNIZED BY F#
    - 17.2 CUSTOM ATTRIBUTES EMITTED BY F#
    - 17.3 CUSTOM ATTRIBUTES NOT RECOGNIZED BY F#
    - 17.4 EXCEPTIONS THROWN BY F# LANGUAGE PRIMITIVES
- 18. THE F# LIBRARY FSHARP.CORE.DLL
    - 18.1 BASIC TYPES (FSHARP.CORE)
        - 18.1.1 Basic Type Abbreviations
        - 18.1.2 Basic Types that Accept Unit of Measure Annotations
        - 18.1.3 The nativeptr<_> Type
    - 18.2 BASIC OPERATORS AND FUNCTIONS (FSHARP.CORE.OPERATORS)
        - 18.2.1 Basic Arithmetic Operators
        - 18.2.2 Generic Equality and Comparison Operators
        - 18.2.3 Bitwise Operators......................................................................................................
        - 18.2.4 Math Operators
        - 18.2.5 Function Pipelining and Composition Operators
        - 18.2.6 Object Transformation Operators
        - 18.2.7 Pair Operators
        - 18.2.8 Exception Operators
        - 18.2.9 Input/Output Handles
        - 18.2.10 Overloaded Conversion Functions
    - 18.3 CHECKED ARITHMETIC OPERATORS
    - 18.4 LIST AND OPTION TYPES
        - 18.4.1 The List Type
        - 18.4.2 The Option Type
    - 18.5 LAZY COMPUTATIONS (LAZY)
    - 18.6 ASYNCHRONOUS COMPUTATIONS (ASYNC)
    - 18.7 QUERY EXPRESSIONS
    - 18.8 AGENTS (MAILBOXPROCESSOR)
    - 18.9 EVENT TYPES
    - 18.10 IMMUTABLE COLLECTION TYPES (MAP, SET)
    - 18.11 TEXT FORMATTING (PRINTF)
    - 18.12 REFLECTION
    - 18.13 QUOTATIONS
    - 18.14 NATIVE POINTER OPERATIONS
        - 18.14.1 Stack Allocation
- 19. FEATURES FOR ML COMPATIBILITY
    - 19.1 CONDITIONAL COMPILATION FOR ML COMPATIBILITY
    - 19.2 EXTRA SYNTACTIC FORMS FOR ML COMPATIBILITY
    - 19.3 EXTRA OPERATORS
    - 19.4 FILE EXTENSIONS AND LEXICAL MATTERS
- APPENDIX A: F# GRAMMAR SUMMARY
- REFERENCES
- GLOSSARY
- INDEX


## 1. INTRODUCTION

F# is a scalable, succinct, type-safe, type-inferred, efficiently executing functional/imperative/object-
oriented programming language. It aims to be the premier typed functional programming language
for the .NET framework and other implementations of the Ecma 335 Common Language
Infrastructure (CLI) specification. F# was partly inspired by the OCaml language and shares some
common core constructs with it.

### 1.1 A FIRST PROGRAM

Over the next few sections, we will look at some small F# programs, describing some important
aspects of F# along the way. As an introduction to F#, consider the following program:

```
let numbers = [ 1 .. 10 ]
```
```
let square x = x * x
```
```
let squares = List.map square numbers
```
```
printfn "N^2 = %A" squares
```
To explore this program, you can:

- Compile it as a project in a development environment such as Visual Studio.
- Manually invoke the F# command line compiler fsc.exe.
- Use F# Interactive, the dynamic compiler that is part of the F# distribution.

##### 1.1.1 Lightweight Syntax

The F# language uses simplified, indentation-aware syntactic constructs known as lightweight
syntax. The lines of the sample program in the previous section form a sequence of declarations and
are aligned on the same column. For example, the two lines in the following code are two separate
declarations:

```
let squares = List.map square numbers
```
```
printfn "N^2 = %A" squares
```
Lightweight syntax applies to all the major constructs of the F# syntax. In the next example, the code
is incorrectly aligned. The declaration starts in the first line and continues to the second and
subsequent lines, so those lines must be indented to the same column under the first line:

```
let computeDerivative f x =
let p1 = f (x - 0.05)
let p2 = f (x + 0.05)
(p2 - p1) / 0.
```
The following shows the correct alignment:


```
let computeDerivative f x =
let p1 = f (x - 0.05)
let p2 = f (x + 0.05)
(p2 - p1) / 0.
```
The use of lightweight syntax is the default for all F# code in files with the extension .fs, .fsx, .fsi,
or .fsscript.

##### 1.1.2 Making Data Simple

The first line in our sample simply declares a list of numbers from one through ten.

```
let numbers = [1 .. 10]
```
An F# list is an immutable linked list, which is a type of data used extensively in functional
programming. Some operators that are related to lists include :: to add an item to the front of a list
and @ to concatenate two lists. If we try these operators in F# Interactive, we see the following
results:

```
> let vowels = ['e'; 'i'; 'o'; 'u'];;
val vowels: char list = ['e'; 'i'; 'o'; 'u']
```
```
> ['a'] @ vowels;;
val it: char list = ['a'; 'e'; 'i'; 'o'; 'u']
```
```
> vowels @ ['y'];;
val it: char list = ['e'; 'i'; 'o'; 'u'; 'y']
```
Note that double semicolons delimit lines in F# Interactive, and that F# Interactive prefaces the
result with _val_ to indicate that the result is an immutable value, rather than a variable.

F# supports several other highly effective techniques to simplify the process of modeling and
manipulating data such as tuples, options, records, unions, and sequence expressions. A tuple is an
ordered collection of values that is treated as an atomic unit. In many languages, if you want to pass
around a group of related values as a single entity, you need to create a named type, such as a class
or record, to store these values. A tuple allows you to keep things organized by grouping related
values together, without introducing a new type.

To define a tuple, you separate the individual components with commas.

```
> let tuple = (1, false, "text");;
val tuple : int * bool * string = (1, false, "text")
```
```
> let getNumberInfo (x : int) = (x, x.ToString(), x * x);;
val getNumberInfo : int -> int * string * int
```
```
> getNumberInfo 42;;
val it : int * string * int = (42, "42", 1764)
```
A key concept in F# is _immutability_. Tuples and lists are some of the many types in F# that are
immutable, and indeed most things in F# are immutable by default. Immutability means that once a
value is created and given a name, the value associated with the name cannot be changed.
Immutability has several benefits. Most notably, it prevents many classes of bugs, and immutable
data is inherently thread-safe, which makes the process of parallelizing code simpler.


##### 1.1.3 Making Types Simple

The next line of the sample program defines a function called square, which squares its input.

```
let square x = x * x
```
Most statically-typed languages require that you specify type information for a function declaration.
However, F# typically infers this type information for you. This process is referred to as _type
inference_.

From the function signature, F# knows that square takes a single parameter named x and that the
function returns x * x. The last thing evaluated in an F# function body is the return value; hence
there is no “return” keyword here. Many primitive types support the multiplication (*) operator
(such as byte, uint64, and double); however, for arithmetic operations, F# infers the type int (a
signed 32-bit integer) by default.

Although F# can typically infer types on your behalf, occasionally you must provide explicit type
annotations in F# code. For example, the following code uses a type annotation for one of the
parameters to tell the compiler the type of the input.

```
> let concat (x : string) y = x + y;;
val concat : string -> string -> string
```
Because x is stated to be of type string, and the only version of the + operator that accepts a left-
hand argument of type string also takes a string as the right-hand argument, the F# compiler infers
that the parameter y must also be a string. Thus, the result of x + y is the concatenation of the
strings. Without the type annotation, the F# compiler would not have known which version of the +
operator was intended and would have assumed int data by default.

The process of type inference also applies _automatic generalization_ to declarations. This
automatically makes code _generic_ when possible, which means the code can be used on many types
of data. For example, the following code defines a function that returns a new tuple in which the
two values are swapped:

```
> let swap (x, y) = (y, x);;
val swap : 'a * 'b -> 'b * 'a
```
```
> swap (1, 2);;
val it : int * int = (2, 1)
```
```
> swap ("you", true);;
val it : bool * string = (true,"you")
```
Here the function swap is generic, and 'a and 'b represent _type variables_ , which are placeholders for
types in generic code. Type inference and automatic generalization greatly simplify the process of
writing reusable code fragments.

##### 1.1.4 Functional Programming

Continuing with the sample, we have a list of integers named numbers, and the square function, and
we want to create a new list in which each item is the result of a call to our function. This is called
_mapping_ our function over each item in the list. The F# library function List.map does just that:


```
let squares = List.map square numbers
```
Consider another example:

```
> List.map (fun x -> x % 2 = 0) [1 .. 5];;
```
```
val it : bool list
= [false; true; false; true; false]
```
The code (fun x -> x % 2 = 0) defines an anonymous function, called a _function expression_ , that
takes a single parameter x and returns the result x % 2 = 0, which is a Boolean value that indicates
whether x is even. The -> symbol separates the argument list (x) from the function body (x % 2 = 0).

Both of these examples pass a function as a parameter to another function—the first parameter to
List.map is itself another function. Using functions as _function values_ is a hallmark of functional
programming.

Another tool for data transformation and analysis is _pattern matching_. This powerful switch
construct allows you to branch control flow and to bind new values. For example, we can match an
F# list against a sequence of list elements.

```
let checkList alist =
match alist with
| [] -> 0
| [a] -> 1
| [a; b] -> 2
| [a; b; c] -> 3
| _ -> failwith "List is too big!"
```
In this example, alist is compared with each potentially matching pattern of elements. When alist
matches a pattern, the result expression is evaluated and is returned as the value of the match
expression. Here, the -> operator separates a pattern from the result that a match returns.

Pattern matching can also be used as a control construct—for example, by using a pattern that
performs a dynamic type test:

```
let getType (x : obj) =
match x with
| :? string -> "x is a string"
| :? int -> "x is an int"
| :? System.Exception -> "x is an exception"
```
The :? operator returns true if the value matches the specified type, so if x is a string, getType
returns “x is a string”.

Function values can also be combined with the _pipeline operator_ , |>. For example, given these
functions:

```
let square x = x * x
let toStr (x : int) = x.ToString()
let reverse (x : string) = new System.String(Array.rev (x.ToCharArray()))
```
We can use the functions as values in a pipeline:

```
> let result = 32 |> square |> toStr |> reverse;;
```

```
val it : string = "4201"
```
Pipelining demonstrates one way in which F# supports _compositionality_ , a key concept in functional
programming. The pipeline operator simplifies the process of writing compositional code where the
result of one function is passed into the next.

##### 1.1.5 Imperative Programming

The next line of the sample program prints text in the console window.

```
printfn "N^2 = %A" squares
```
The F# library function printfn is a simple and type-safe way to print text in the console window.
Consider this example, which prints an integer, a floating-point number, and a string:

```
> printfn "%d * %f = %s" 5 0.75 ((5.0 * 0.75).ToString());;
5 * 0.750000 = 3.
val it : unit = ()
```
The format specifiers %d, %f, and %s are placeholders for integers, floats, and strings. The %A format
can be used to print arbitrary data types (including lists).

The printfn function is an example of _imperative programming_ , which means calling functions for
their side effects. Other commonly used imperative programming techniques include arrays and
dictionaries (also called hash tables). F# programs typically use a mixture of functional and
imperative techniques.

##### 1.1.6 .NET Interoperability and CLI Fidelity

The Common Language Infrastructure (CLI) function System.Console.ReadKey to pause the program
before the console window closes.

```
System.Console.ReadKey(true)
```
Because F# is built on top of CLI implementations, you can call any CLI library from F#. Furthermore,
other CLI languages can easily use any F# components.

##### 1.1.7 Parallel and Asynchronous Programming

F# is both a _parallel_ and a _reactive_ language. During execution, F# programs can have multiple
parallel active evaluations and multiple pending reactions, such as callbacks and agents that wait to
react to events and messages.

One way to write parallel and reactive F# programs is to use F# _async_ expressions. For example, the
code below is similar to the original program in §1.1 except that it computes the Fibonacci function
(using a technique that will take some time) and schedules the computation of the numbers in
parallel:

```
let rec fib x = if x < 2 then 1 else fib(x-1) + fib(x-2)
```
```
let fibs =
Async.Parallel [ for i in 0..40 -> async { return fib(i) } ]
|> Async.RunSynchronously
```

```
printfn "The Fibonacci numbers are %A" fibs
```
```
System.Console.ReadKey(true)
```
The preceding code sample shows multiple, parallel, CPU-bound computations.

F# is also a reactive language. The following example requests multiple web pages in parallel, reacts
to the responses for each request, and finally returns the collected results.

```
open System
open System.IO
open System.Net
```
```
let http url =
async { let req = WebRequest.Create(Uri url)
use! resp = req.AsyncGetResponse()
use stream = resp.GetResponseStream()
use reader = new StreamReader(stream)
let contents = reader.ReadToEnd()
return contents }
```
```
let sites = ["http://www.bing.com"; "http://www.google.com";
"http://www.yahoo.com"; "http://www.search.com"]
```
```
let htmlOfSites =
Async.Parallel [for site in sites -> http site ]
|> Async.RunSynchronously
```
By using asynchronous workflows together with other CLI libraries, F# programs can implement
parallel tasks, parallel I/O operations, and message-receiving agents.

##### 1.1.8 Strong Typing for Floating-Point Code

F# applies type checking and type inference to floating-point-intensive domains through _units of
measure inference and checking_. This feature allows you to type-check programs that manipulate
floating-point numbers that represent physical and abstract quantities in a stronger way than other
typed languages, without losing any performance in your compiled code. You can think of this
feature as providing a type system for floating-point code.

Consider the following example:

```
[<Measure>] type kg
[<Measure>] type m
[<Measure>] type s
```
```
let gravityOnEarth = 9.81<m/s^2>
let heightOfTowerOfPisa = 55.86<m>
let speedOfImpact = sqrt(2.0 * gravityOnEarth * heightOfTowerOfPisa)
```
The Measure attribute tells F# that kg, s, and m are not really types in the usual sense of the word, but
are used to build units of measure. Here speedOfImpact is inferred to have type float<m/s>.


##### 1.1.9 Object-Oriented Programming and Code Organization

The sample program shown at the start of this chapter is a _script_. Although scripts are excellent for
rapid prototyping, they are not suitable for larger software components. F# supports the transition
from scripting to structured code through several techniques.

The most important of these is _object-oriented programming_ through the use of _class type
definitions_ , _interface type definitions_ , and _object expressions_. Object-oriented programming is a
primary application programming interface (API) design technique for controlling the complexity of
large software projects. For example, here is a class definition for an encoder/decoder object.

```
open System
```
```
/// Build an encoder/decoder object that maps characters to an
/// encoding and back. The encoding is specified by a sequence
/// of character pairs, for example, [('a','Z'); ('Z','a')]
type CharMapEncoder(symbols: seq<char*char>) =
let swap (x, y) = (y, x)
```
```
/// An immutable tree map for the encoding
let fwd = symbols |> Map.ofSeq
```
```
/// An immutable tree map for the decoding
let bwd = symbols |> Seq.map swap |> Map.ofSeq
```
```
let encode (s:string) =
String [| for c in s -> if fwd.ContainsKey(c) then fwd.[c] else c |]
let decode (s:string) =
String [| for c in s -> if bwd.ContainsKey(c) then bwd.[c] else c |]
```
```
/// Encode the input string
member x.Encode(s) = encode s
```
```
/// Decode the given string
member x.Decode(s) = decode s
```
You can instantiate an object of this type as follows:

```
let rot13 (c:char) =
char(int 'a' + ((int c - int 'a' + 13) % 26))
let encoder =
CharMapEncoder( [for c in 'a'..'z' -> (c, rot13 c)])
```
And use the object as follows:

```
> "F# is fun!" |> encoder.Encode ;;
val it : string = "F# vf sha!"
```
```
> "F# is fun!" |> encoder.Encode |> encoder.Decode ;;
val it : String = "F# is fun!"
```
An interface type can encapsulate a family of object types:

```
open System
```
```
type IEncoding =
abstract Encode : string -> string
abstract Decode : string -> string
```

In this example, IEncoding is an interface type that includes both Encode and Decode object types.

Both object expressions and type definitions can implement interface types. For example, here is an
object expression that implements the IEncoding interface type:

```
let nullEncoder =
{ new IEncoding with
member x.Encode(s) = s
member x.Decode(s) = s }
```
_Modules_ are a simple way to encapsulate code during rapid prototyping when you do not want to
spend the time to design a strict object-oriented type hierarchy. In the following example, we place a
portion of our original script in a module.

```
module ApplicationLogic =
let numbers n = [1 .. n]
let square x = x * x
let squares n = numbers n |> List.map square
```
```
printfn "Squares up to 5 = %A" (ApplicationLogic.squares 5)
printfn "Squares up to 10 = %A" (ApplicationLogic.squares 10)
System.Console.ReadKey(true)
```
Modules are also used in the F# library design to associate extra functionality with types. For
example, List.map is a function in a module.

Other mechanisms aimed at supporting software engineering include _signatures_ , which can be used
to give explicit types to components, and _namespaces_ , which serve as a way of organizing the name
hierarchies for larger APIs.

##### 1.1.10 Information-rich Programming

F# Information-rich programming addresses the trend toward greater availability of data, services,
and information. The key to information-rich programming is to eliminate barriers to working with
diverse information sources that are available on the Internet and in modern enterprise
environments. Type providers and query expressions are a significant part of F# support for
information-rich programming.

The F# Type Provider mechanism allows you to seamlessly incorporate, in a strongly typed manner,
data and services from external sources. A _type provider_ presents your program with new types and
methods that are typically based on the schemas of external information sources. For example, an
F# type provider for Structured Query Language (SQL) supplies types and methods that allow
programmers to work directly with the tables of any SQL database:

```
// Add References to FSharp.Data.TypeProviders, System.Data, and System.Data.Linq
type schema = SqlDataConnection<"Data Source=localhost;Integrated Security=SSPI;">
```
```
let db = schema.GetDataContext()
```
The type provider connects to the database automatically and uses this for IntelliSense and type
information.


Query expressions (added in F# 3.0) add the established power of query-based programming against
SQL, Open Data Protocol (OData), and other structured or relational data sources. Query expressions
provide support for Language-Integrated Query (LINQ) in F#, and several query operators enable you
to construct more complex queries. For example, we can create a query to filter the customers in the
data source:

```
let countOfCustomers =
query { for customer in db.Customers do
where (customer.LastName.StartsWith("N"))
select (customer.FirstName, customer.LastName) }
```
Now it is easier than ever to access many important data sources—including enterprise, web, and
cloud—by using a set of built-in type providers for SQL databases and web data protocols. Where
necessary, you can create your own custom type providers or reference type providers that others
have created. For example, assume your organization has a data service that provides a large and
growing number of named data sets, each with its own stable data schema. You may choose to
create a type provider that reads the schemas and presents the latest available data sets to the
programmer in a strongly typed way.

### 1.2 NOTATIONAL CONVENTIONS IN THIS SPECIFICATION

This specification describes the F# language by using a mixture of informal and semiformal
techniques. All examples in this specification use lightweight syntax, unless otherwise specified.

Regular expressions are given in the usual notation, as shown in the table:

**Notation Meaning**

regexp+ (^) _O_ ne or more occurrences
regexp* (^) Zero or more occurrences
regexp? (^) Zero or one occurrences
[ char - char ] (^) Range of ASCII characters
[ ^ char - char ] (^) Any characters except those in the range
Unicode character classes are referred to by their abbreviation as used in CLI libraries for regular
expressions—for example, \Lu refers to any uppercase letter. The following characters are referred
to using the indicated notation:
**Character Name Notation**
\b (^) backspace ASCII/UTF-8/UTF-16/UTF-32 code 08
\n (^) newline ASCII/UTF-8/UTF-16/UTF-32 code 10
\r (^) return ASCII/UTF-8/UTF-16/UTF-32 code 13
\t (^) tab ASCII/UTF-8/UTF-16/UTF-32 code 09
Strings of characters that are clearly not a regular expression are written verbatim. Therefore, the
following string
abstract
matches precisely the characters abstract.


Where appropriate, apostrophes and quotation marks enclose symbols that are used in the
specification of the grammar itself, such as '<' and '|'. For example, the following regular
expression matches (+) or (-):

```
'(' (+|-) ')'
```
This regular expression matches precisely the characters #if:

```
"#if"
```
Regular expressions are typically used to specify tokens.

```
token token-name = regexp
```
In the grammar rules, the notation _element-name_ opt indicates an optional element. The notation ...
indicates repetition of the preceding non-terminal construct and the separator token. For example,
_expr_ ',' ... ',' _expr_ means a sequence of one or more _expr_ elements separated by commas.


## 2. PROGRAM STRUCTURE

The inputs to the F# compiler or the F# Interactive dynamic compiler consist of:

- Source code files, with extensions .fs, .fsi, .fsx, or .fsscript.
    - Files with extension .fs must conform to grammar element _implementation-file_ in §12.1.
    - Files with extension .fsi must conform to grammar element _signature-file_ in §12.2.
    - Files with extension .fsx or .fsscript must conform to grammar element _script-file_ in
      §12.3.
- Script fragments (for F# Interactive). These must conform to grammar element _script-fragment_.
  Script fragments can be separated by ;; tokens.
- Assembly references that are specified by command line arguments or interactive directives.
- Compilation parameters that are specified by command line arguments or interactive directives.
- Compiler directives such as #time.

The COMPILED compilation symbol is defined for input that the F# compiler has processed. The
INTERACTIVE compilation symbol is defined for input that F# Interactive has processed.

Processing the source code portions of these inputs consists of the following steps:

1. **Decoding**. Each file and source code fragment is decoded into a stream of Unicode characters, as
   described in the C# specification, sections 2.3 and 2.4. The command-line options may specify a
   code page for this process.
2. **Tokenization**. The stream of Unicode characters is broken into a token stream by the lexical
   analysis described in § 3.
3. **Lexical Filtering**. The token stream is filtered by a state machine that implements the rules
   described in § 15. Those rules describe how additional (artificial) tokens are inserted into the
   token stream and how some existing tokens are replaced with others to create an augmented
   token stream.
4. **Parsing**. The augmented token stream is parsed according to the grammar specification in this
   document.
5. **Importing**. The imported assembly references are resolved to F# or CLI assembly specifications,
   which are then imported. From the F# perspective, this results in the pre-definition of numerous
   namespace declaration groups (§12.1), types and type provider instances. The namespace
   declaration groups are then combined to form an initial name resolution environment (§14.1).
6. **Checking**. The results of parsing are checked one by one. Checking involves such procedures as
   Name Resolution (§14.1), Constraint Solving (§14.5), and Generalization (§14.6.7), as well as the
   application of other rules described in this specification.


```
Type inference uses variables to represent unknowns in the type inference problem. The various
checking processes maintain tables of context information including a name resolution
environment and a set of current inference constraints. After the processing of a file or program
fragment is complete, all such variables have been either generalized or resolved and the type
inference environment is discarded.
```
7. **Elaboration**. One result of checking is an elaborated program fragment that contains elaborated
   declarations, expressions, and types. For most constructs, such as constants, control flow, and
   data expressions, the elaborated form is simple. Elaborated forms are used for evaluation, CLI
   reflection, and the F# expression trees that are returned by quoted expressions (§6.8).
8. **Execution**. Elaborated program fragments that are successfully checked are added to a
   collection of available program fragments. Each fragment has a static initializer. Static initializers
   are executed as described in (§12.5).


## 3. LEXICAL ANALYSIS

Lexical analysis converts an input stream of Unicode characters into a stream of tokens by iteratively
processing the stream. If more than one token can match a sequence of characters in the source file,
lexical processing always forms the longest possible lexical element. Some tokens, such as _block-
comment-start_ , are discarded after processing as described later in this section.

### 3.1 WHITESPACE

Whitespace consists of spaces and newline characters.

```
regexp whitespace = ' '+
regexp newline = '\n' | '\r' '\n'
token whitespace-or-newline = whitespace | newline
```
Whitespace tokens _whitespace-or-newline_ are discarded from the returned token stream.

### 3.2 COMMENTS

Block comments are delimited by (* and *) and may be nested. Single-line comments begin with
two backslashes (//) and extend to the end of the line.

```
token block-comment-start = "(*"
token block-comment-end = "*)"
token end-of-line-comment = "//" [^'\n' '\r']*
```
When the input stream matches a _block-comment-start_ token, the subsequent text is tokenized
recursively against the tokens that are described in §3 until a _block-comment-end_ token is found. The
intermediate tokens are discarded.

For example, comments can be nested, and strings that are embedded within comments are
tokenized by the rules for _string, verbatim-string_ , and _triple-quoted string_. In particular, strings
that are embedded in comments are tokenized in their entirety, without considering closing *)
marks. As a result of this rule, the following is a valid comment:

```
(* Here's a code snippet: let s = "*)" *)
```
However, the following construct, which was valid in F# 2.0, now produces a syntax error because a
closing comment token *) followed by a triple-quoted mark is parsed as part of a string:

```
(* """ *)
```
For the purposes of this specification, comment tokens are discarded from the returned lexical
stream. In practice, XML documentation tokens are _end-of-line-comments_ that begin with ///. The
delimiters are retained and are associated with the remaining elements to generate XML
documentation.


### 3.3 CONDITIONAL COMPILATION

The lexical preprocessing directives #if _ident_ /#else/#endif delimit conditional compilation
sections. The following describes the grammar for such sections:

```
token if-directive = "#if" whitespace if-expression-text
token else-directive = "#else"
token endif-directive = "#endif"
```
```
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
However, whitespace can appear before the # character. A source line that contains the #if, #else,
or #endif directive can end with whitespace and a single-line comment. Multiple-line comments are
not permitted on source lines that contain preprocessing directives.

If an _if-directive_ token is matched during tokenization, text is recursively tokenized until a
corresponding _else-directive_ or _endif-directive_. If the evaluation of the associated _if-
expression-text_ when parsed as an _if-expression_ is true in the compilation environment defines
(where each _ident-text_ is evaluataed according to the values given by command line options such
as – define), the token stream includes the tokens between the _if-directive_ and the corresponding
_else-directive_ or _endif-directive_. Otherwise, the tokens are discarded. The converse applies to
the text between any corresponding _else-directive_ and the _endif-directive_.

- In skipped text, #if _ident_ /#else/#endif sections can be nested.
- Strings and comments are not treated as special

### 3.4 IDENTIFIERS AND KEYWORDS

Identifiers follow the specification in this section.

```
regexp digit-char = [0-9]
regexp letter-char = '\Lu' | '\Ll' | '\Lt' | '\Lm' | '\Lo' | '\Nl'
regexp connecting-char = '\Pc'
regexp combining-char = '\Mn' | '\Mc'
regexp formatting-char = '\Cf'
```

```
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
For example, ``value.with odd#name``
```
Any sequence of characters that is enclosed in double-backtick marks (`` ``), excluding newlines,
tabs, and double-backtick pairs themselves, is treated as an identifier. Note that when an identifier is
used for the name of a types, union type case, module, or namespace, the following characters are
not allowed even inside double-backtick marks:

```
‘.', '+', '$', '&', '[', ']', '/', '\\', '*', '\"', '`'
```
All input files are currently assumed to be encoded as UTF-8. See the C# specification for a list of the
Unicode characters that are accepted for the Unicode character classes \Lu, \Li, \Lt, \Lm, \Lo, \Nl,
\Pc, \Mn, \Mc, and \Cf.

The following identifiers are treated as keywords of the F# language:

```
token ident-keyword =
abstract and as assert base begin class default delegate do done
downcast downto elif else end exception extern false finally for
fun function global if in inherit inline interface internal lazy let
match member module mutable namespace new null of open or
override private public rec return sig static struct then to
true try type upcast use val void when while with yield
```
The following identifiers are reserved for future use:

```
token reserved-ident-keyword =
atomic break checked component const constraint constructor
continue eager fixed fori functor include
measure method mixin object parallel params process protected pure
recursive sealed tailcall trait virtual volatile
```
A future revision of the F# language may promote any of these identifiers to be full keywords.

The following token forms are reserved, except when they are part of a symbolic keyword (§3.6).

```
token reserved-ident-formats =
| ident-text ( '!' | '#')
```
In the remainder of this specification, we refer to the token that is generated for a keyword simply
by using the text of the keyword itself.


### 3.5 STRINGS AND CHARACTERS

String literals may be specified for two types:

- Unicode strings, type string = System.String
- Unsigned byte arrays, type byte[] = bytearray

Literals may also be specified by using C#-like verbatim forms that interpret \ as a literal character
rather than an escape sequence. In a UTF- 8 - encoded file, you can directly embed the following in a
string in the same way as in C#:

- Unicode characters, such as “\u0041bc”
- Identifiers, as described in the previous section, such as “abc”
- Trigraph specifications of Unicode characters, such as “\ 067 ” which represents “C”

```
regexp escape-char = '\' ["\'ntbrafv]
regexp non-escape-chars = '\' [^"\'ntbrafv]
regexp simple-char-char =
| (any char except '\n' '\t' '\r' '\b' '\a' '\f' '\v' ' \ ")
regexp unicodegraph-short = '\' 'u' hexdigit hexdigit hexdigit hexdigit
regexp unicodegraph-long = '\' 'U' hexdigit hexdigit hexdigit hexdigit
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
```

```
token simple-char = any char except newline,return,tab,backspace,',\,"
```
```
token triple-quoted-string = """ simple-or-escape-char* """
```
To translate a string token to a string value, the F# parser concatenates all the Unicode characters
for the _string-char_ elements within the string. Strings may include \n as a newline character.
However, if a line ends with \, the newline character and any leading whitespace elements on the
subsequent line are ignored. Thus, the following gives s the value "abcdef":

```
let s = "abc\
def"
```
Without the backslash, the resulting string includes the newline and whitespace characters. For
example:

```
let s = "abc
def"
```
In this case, s has the value "abc _\ 010_ def" where _\ 010_ is the embedded control character for \n,
which has Unicode UTF- 16 value 10.

Verbatim strings may be specified by using the @ symbol preceding the string as in C#. For example,
the following assigns the value "abc\def" to s.

```
let s = @"abc\def"
```
String-like and character-like literals can also be specified for unsigned byte arrays (type byte[]).
These tokens cannot contain Unicode characters that have surrogate-pair UTF-16 encodings or UTF-
16 encodings greater than 127.

A triple-quoted string is specified by using three quotation marks (""") to ensure that a string that
includes one or more escaped strings is interpreted verbatim. For example, a triple-quoted string can
be used to embed XML blobs:

```
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
### 3.6 SYMBOLIC KEYWORDS

The following symbolic or partially symbolic character sequences are treated as keywords:


```
token symbolic-keyword =
let! use! do! yield! return!
| -> <-. : ( ) [ ] [< >] [| |] { }
' # :?> :? :> .. :: := ;; ; =
_? ?? (*) <@ @> <@@ @@>
```
The following symbols are reserved for future use:

```
token reserved-symbolic-sequence =
~ `
```
### 3.7 SYMBOLIC OPERATORS

User-defined and library-defined symbolic operators are sequences of characters as shown below,
except where the sequence of characters is a symbolic keyword (§3.6).

```
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
For example, &&& and ||| are valid symbolic operators. Only the operators? and ?<- may start with
?.

The _quote-op-left_ and _quote-op-right_ operators are used in quoted expressions (§6.8).

For details about the associativity and precedence of symbolic operators in expression forms, see
§4.4.

### 3.8 NUMERIC LITERALS

The lexical specification of numeric literals is as follows:

```
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
```

```
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
| float [Ff] For example, 3.0F or 3.0f
| xint 'lf' For example, 0x00000000lf
token ieee64 =
| float For example, 3.0
| xint 'LF' For example, 0x0000000000000000LF
token bignum = int ('Q' | ' R' | 'Z' | 'I' | 'N' | 'G')
For example, 34742626263193832612536171N
token decimal = ( float | int ) [Mm]
token float =
digit +. digit *
digit + (. digit * )? (e|E) (+|-)? digit +
```
##### 3.8.1 Post-filtering of Adjacent Prefix Tokens

Negative integers are specified using the – token; for example, - 3. The token steam is post-filtered
according to the following rules:

- If the token stream contains the adjacent tokens – _token_ :

```
If token is a constant numeric literal, the pair of tokens is merged. For example, adjacent tokens
```
- and 3 becomes the single token “- 3 ”. Otherwise, the tokens remain separate. However the “-”
  token is marked as an ADJACENT_PREFIX_OP token.

```
This rule does not apply to the sequence token1 - token2 , if all three tokens are adjacent and
token1 is a terminating token from expression forms that have lower precedence than the
grammar production expr = MINUS expr.
```
```
For example, the – and b tokens in the following sequence are not merged if all three tokens
are adjacent:
```
```
a-b
```
- Otherwise, the usual grammar rules apply to the uses of – and +, with an addition for
  ADJACENT_PREFIX_OP:
  expr = expr MINUS expr
  | MINUS expr
  | ADJACENT_PREFIX_OP expr


##### 3.8.2 Post-filtering of Integers Followed by Adjacent “..”

Tokens of the form

```
token intdotdot = int..
```
such as 34.. are post-filtered to two tokens: one _int_ and one _symbolic-keyword_ , “..”.

This rule allows “..” to immediately follow an integer. This construction is used in expressions of the
form [for x in 1..2 -> x + x ]. Without this rule, the longest-match rule would consider this
sequence to be a floating-point number followed by a “.”.

##### 3.8.3 Reserved Numeric Literal Forms

The following token forms are reserved for future numeric literal formats:

```
token reserved-literal-formats =
| (xint | ieee32 | ieee64) ident-char+
```
##### 3.8.4 Shebang

A shebang (#!) directive may exist at the beginning of F# source files. Such a line is treated as a
comment. This allows F# scripts to be compatible with the Unix convention whereby a script
indicates the interpreter to use by providing the path to that interpreter on the first line, following
the #! directive.

```
#!/bin/usr/env fsharpi --exec
```
### 3.9 LINE DIRECTIVES

Line directives adjust the source code filenames and line numbers that are reported in error
messages, recorded in debugging symbols, and propagated to quoted expressions. F# supports the
following line directives:

```
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

### 3.10 HIDDEN TOKENS

Some hidden tokens are inserted by lexical filtering (§ 15 ) or are used to replace existing tokens. See
§ 15 for a full specification and for the augmented grammar rules that take these into account.


### 3.11 IDENTIFIER REPLACEMENTS

The following table lists identifiers that are automatically replaced by expressions.

**Identifier Replacement**

__SOURCE_DIRECTORY__ (^) A literal verbatim string that specifies the name of the directory that contains the
current file. For example:
C:\source
The name of the current file is derived from the most recent line directive in the
file. If no line directive has appeared, the name is derived from the name that was
specificed to the command-line compiler in combination with
System.IO.Path.GetFullPath.
In F# Interactive, the name stdin is used. When F# Interactive is used from tools
such as Visual Studio, a line directive is implicitly added before the interactive
execution of each script fragment.
__SOURCE_FILE__ (^) A literal verbatim string that contains the name of the current file. For example:
file.fs
__LINE__ (^) A literal string that specifies the line number in the source file, after taking into
account adjustments from line directives.



## 4. BASIC GRAMMAR ELEMENTS..............................................................................................

This section defines grammar elements that are used repeatedly in later sections.

### 4.1 OPERATOR NAMES

Several places in the grammar refer to an _ident-or-op_ rather than an _ident_ :

```
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
a ctive-pattern-op-name :=
| | ident | ... | ident |
| | ident | ... | ident | _ |
```
In operator definitions, the operator name is placed in parentheses. For example:

```
let (+++) x y = (x, y)
```
This example defines the binary operator +++. The text (+++) is an _ident-or-op_ that acts as an
identifier with associated text +++. Likewise, for active pattern definitions (§ 7 ), the active pattern
case names are placed in parentheses, as in the following example:

```
let (|A|B|C|) x = if x < 0 then A elif x = 0 then B else C
```
Because an _ident-or-op_ acts as an identifier, such names can be used in expressions. For example:

```
List.map ((+) 1) [ 1; 2; 3 ]
```
The three character token (*)defines the * operator:

```
let (*) x y = (x + y)
```
To define other operators that begin with *, whitespace must follow the opening parenthesis;
otherwise (* is interpreted as the start of a comment:

```
let ( *+* ) x y = (x + y)
```

Symbolic operators and some symbolic keywords have a compiled name that is visible in the
compiled form of F# programs. The compiled names are shown below.

```
[] op_Nil
:: op_ColonColon
+ op_Addition
```
- op_Subtraction
* op_Multiply
  / op_Division
  ** op_Exponentiation
  @ op_Append
  ^ op_Concatenate
  % op_Modulus
  &&& op_BitwiseAnd
  ||| op_BitwiseOr
  ^^^ op_ExclusiveOr
  <<< op_LeftShift
~~~ op_LogicalNot
>>> op_RightShift
~+ op_UnaryPlus
~- op_UnaryNegation
= op_Equality
<> op_Inequality
<= op_LessThanOrEqual
>= op_GreaterThanOrEqual
< op_LessThan
> op_GreaterThan
? op_Dynamic
?<- op_DynamicAssignment
|> op_PipeRight
||> op_PipeRight2
|||> op_PipeRight3
<| op_PipeLeft
<|| op_PipeLeft2
<||| op_PipeLeft3
! op_Dereference
>> op_ComposeRight
<< op_ComposeLeft
<@ @> op_Quotation
<@@ @@> op_QuotationUntyped
~% op_Splice
~%% op_SpliceUntyped
~& op_AddressOf
~&& op_IntegerAddressOf
|| op_BooleanOr
&& op_BooleanAnd
+= op_AdditionAssignment
- = op_SubtractionAssignment
*= op_MultiplyAssignment
/= op_DivisionAssignment
.. op_Range
.. .. op_RangeStep


Compiled names for other symbolic operators are op_N 1 ...Nn where N 1 to Nn are the names for the
characters as shown in the table below. For example, the symbolic identifier <* has the compiled
name op_LessMultiply:

```
> Greater
< Less
+ Plus
```
- Minus
* Multiply
= Equals
~ Twiddle
% Percent
. Dot
& Amp
| Bar
@ At
# Hash
^ Hat
! Bang
? Qmark
/ Divide
. Dot
: Colon
( LParen
, Comma
) RParen
[ LBrack
] RBrack

### 4.2 LONG IDENTIFIERS

Long identifiers _long-ident_ are sequences of identifiers that are separated by ‘.’ and optional
whitespace. Long identifiers _long-ident-or-op_ are long identifiers that may terminate with an
operator name.

```
long-ident := ident '.' ... '.' ident
long-ident-or-op :=
| long-ident '.' ident-or-op
| ident-or-op
```
### 4.3 CONSTANTS

The constants in the following table may be used in patterns and expressions. The individual lexical
formats for the different constants are defined in § 3.

```
const :=
| sbyte
| int16
| int32
| int64 -- 8, 16, 32 and 64-bit signed integers
| byte
| uint16
| uint32
| int -- 32 - bit signed integer
| uint64 -- 8, 16, 32 and 64-bit unsigned integers
| ieee32 -- 32 - bit number of type "float32"
```

```
| ieee64 -- 64 - bit number of type "float"
| bignum -- User or library-defined integral literal type
| char -- Unicode character of type "char"
| string -- String of type "string" (System.String)
| verbatim-string -- String of type "string" (System.String)
| triple-quoted-string -- String of type "string" (System.String)
| bytestring -- String of type "byte[]"
| verbatim-bytearray -- String of type "byte[]"
| bytechar -- Char of type "byte"
| false | true -- Boolean constant of type "bool"
| '(' ')' -- unit constant of type "unit"
```
### 4.4 OPERATORS AND PRECEDENCE

##### 4.4.1 Categorization of Symbolic Operators

The following _symbolic-op_ tokens can be used to form prefix and infix expressions. The marker OP
represents all _symbolic-op_ tokens that begin with the indicated prefix, except for tokens that appear
elsewhere in the table.

```
infix-or-prefix-op :=
+, -, +., -., %, &, &&
prefix-op :=
infix-or-prefix-op
~ ~~ ~~~ (and any repetitions of ~)
!OP (except !=)
infix-op :=
infix-or-prefix-op
```
- OP +OP || <OP >OP = |OP &OP ^OP *OP /OP %OP !=
(or any of these preceded by one or more ‘.’)
:=
::
$
or
?

The operators +, -, +., -., %, %%, &, && can be used as both prefix and infix operators. When these
operators are used as prefix operators, the tilde character is prepended internally to generate the
operator name so that the parser can distinguish such usage from an infix use of the operator. For
example, -x is parsed as an application of the operator ~- to the identifier x. This generated name is
also used in definitions for these prefix operators. Consequently, the definitions of the following
prefix operators include the ~ character:

```
// To completely redefine the prefix + operator:
let (~+) x = x
```
```
// To completely redefine the infix + operator to be addition modulo- 7
let (+) a b = (a + b) % 7
```
```
// To define the operator on a type:
type C(n:int) =
let n = n % 7
member x.N = n
```

```
static member (~+) (x:C) = x
static member (~-) (x:C) = C(-n)
static member (+) (x1:C,x2:C) = C(x1.N+x2.N)
static member (-) (x1:C,x2:C) = C(x1.N-x2.N)
```
The:: operator is special. It represents the union case for the addition of an element to the head of
an immutable linked list, and cannot be redefined, although it may be used to form infix expressions.
It always accepts arguments in tupled form—as do all union cases—rather than in curried form.

##### 4.4.2 Precedence of Symbolic Operators and Pattern/Expression Constructs

Rules of precedence control the order of evaluation for ambiguous expression and pattern
constructs. Higher precedence items are evaluated before lower precedence items.

The following table shows the order of precedence, from highest to lowest, and indicates whether
the operator or expression is associated with the token to its left or right. The OP marker represents
the _symbolic-op_ tokens that begin with the specified prefix, except those listed elsewhere in the
table. For example, +OP represents any token that begins with a plus sign, unless the token appears
elsewhere in the table.

**Operator or expression Associativity Comments**

f<types> (^) Left High-precedence type application; see §15.3
f(x) (^) Left High-precedence application; see §15.2
. (^) Left
_prefix-op_ (^) Left Applies to prefix uses of these symbols
"| rule" (^) Right Pattern matching rules
"f x"
"lazy x"
"assert x"
Left
**OP (^) Right
*OP /OP %OP (^) Left
- OP +OP (^) Left Applies to infix uses of these symbols
:? (^) Not associative
:: (^) Right
^OP (^) Right
!=OP <OP >OP = |OP &OP $ (^) Left
:> :?> (^) Right
& && (^) Left
or || (^) Left
, (^) Not associative
:= (^) Right
- > (^) Right
if (^) Not associative
function, fun, match, try (^) Not associative
let (^) Not associative
; (^) Right
| (^) Left
when (^) Right
as (^) Right
If ambiguous grammar rules (such as the rules from § 6 ) involve tokens in the table, a construct that
appears earlier in the table has higher precedence than a construct that appears later in the table.


The associativity indicates whether the operator or construct applies to the item to the left or the
right of the operator.

For example, consider the following token stream:

```
a + b * c
```
In this expression, the _expr infix-op expr_ rule for b * c takes precedence over the _expr infix-op
expr_ rule for a + b, because the * operator has higher precedence than the + operator. Thus, this
expression can be pictured as follows:

```
a + b * c
```
rather than

```
a + b * c
```
Likewise, given the tokens

```
a * b * c
```
the left associativity of * means we can picture the resolution of the ambiguity as:

```
a * b * c
```
In the preceding table, leading. characters are ignored when determining precedence for infix
operators. For example, .* has the same precedence as *. This rule ensures that operators such as
.*, which is frequently used for pointwise-operation on matrices, have the expected precedence.

The table entries marked as “High-precedence application” and “High-precedence type application”
are the result of the augmentation of the lexical token stream, as described in §15.2 and §15.3.


## 5. TYPES AND TYPE CONSTRAINTS

The notion of _type_ is central to both the static checking of F# programs and to dynamic type tests
and reflection at runtime. The word is used with four distinct but related meanings:

- **Type definitions,** such as the actual CLI or F# definitions of System.String or
    FSharp.Collections.Map<_,_>.
- **Syntactic types,** such as the text option<_> that might occur in a program text. Syntactic types
    are converted to static types during the process of type checking and inference.
- **Static types** , which result from type checking and inference, either by the translation of syntactic
    types that appear in the source text, or by the application of constraints that are related to
    particular language constructs. For example, option<int> is the fully processed static type that is
    inferred for an expression Some(1+1). Static types may contain _type variables_ as described later
    in this section.
- **Runtime types** , which are objects of type System.Type and represent some or all of the
    information that type definitions and static types convey at runtime. The obj.GetType() method,
    which is available on all F# values, provides access to the runtime type of an object. An object’s
    runtime type is related to the static type of the identifiers and expressions that correspond to
    the object. Runtime types may be tested by built-in language operators such as :? and :?>, the
    expression form downcast _expr_ , and pattern matching type tests. Runtime types of objects do
    not contain type variables. Runtime types that System.Reflection reports may contain type
    variables that are represented by System.Type values.

The following describes the syntactic forms of types as they appear in programs:

```
type :=
( type )
type - > type -- function type
type * ... * type -- tuple type
typar -- variable type
long-ident -- named type, such as int
long-ident < type-args > -- named type, such as list<int>
long-ident < > -- named type, such as IEnumerable< >
type long-ident -- named type, such as int list
type [ , ... , ] -- array type
type typar-defns -- type with constraints
typar :> type -- variable type with subtype constraint
# type -- anonymous type with subtype constraint
type-args := type-arg , ..., type-arg
type-arg :=
type -- type argument
measure -- unit of measure argument
static-parameter -- static parameter
atomic-type :=
type : one of
#type typar ( type ) long-ident long-ident < type-args >
typar :=
_ -- anonymous variable type
```

```
' ident -- type variable
^ ident -- static head-type type variable
constraint :=
typar :> type -- coercion constraint
typar : null -- nullness constraint
static-typars : ( member-sig ) -- member "trait" constraint
typar : (new : unit -> 'T) -- CLI default constructor constraint
typar : struct -- CLI non-Nullable struct
typar : not struct -- CLI reference type
typar : enum< type > -- enum decomposition constraint
typar : unmanaged -- unmanaged constraint
typar : delegate< type, type > -- delegate decomposition constraint
typar : equality
typar : comparison
```
```
typar-defn := attributes opt typar
typar-defns := < typar-defn, ..., typar-defn typar-constraints opt >
typar-constraints := when constraint and ... and constraint
static-typars :=
^ ident
(^ ident or ... or ^ ident )
member-sig := <see Section 10>
```
In a type instantiation, the type name and the opening angle bracket must be syntactically adjacent
with no intervening whitespace, as determined by lexical filtering (§ 15 ). Specifically:

```
array<int>
```
and not

```
array < int >
```
### 5.1 CHECKING SYNTACTIC TYPES

Syntactic types are checked and converted to _static types_ as they are encountered. Static types are a
specification device used to describe

- The process of type checking and inference.
- The connection between syntactic types and the execution of F# programs.

Every expression in an F# program is given a unique inferred static type, possibly involving one or
more explicit or implicit generic parameters.

For the remainder of this specification we use the same syntax to represent syntactic types and
static types. For example int32 * int32 is used to represent the syntactic type that appears in
source code and the static type that is used during checking and type inference.


The conversion from syntactic types to static types happens in the context of a _name resolution
environment_ (§14.1), a _floating type variable environment_ , which is a mapping from names to type
variables, and a _type inference environment_ (§14.5).

The phrase “fresh type” means a static type that is formed from a _fresh type inference variable_. Type
inference variables are either solved or generalized by _type inference_ (§14.5). During conversion and
throughout the checking of types, expressions, declarations, and entire files, a set of _current
inference constraints_ is maintained. That is, each static type is processed under input constraints _Χ_ ,
and results in output constraints _Χ’_. Type inference variables and constraints are progressively
_simplified_ and _eliminated_ based on these equations through _constraint solving_ (§14.5).

#### 5.1.1 Named Types

_Named types_ have several forms, as listed in the following table.

Form Description

_long-ident_ < _ty 1 ,...,tyn_ > (^) Named type with one or more suffixed type arguments.
_long-ident_ (^) Named type with no type arguments
_type long-ident_ (^) Named type with one type argument; processed the same as _long-ident_ < _type_ >
_ty 1_ - > _ty 2_ (^) A function type, where:
▪ ty1 is the domain of the function values associated with the type
▪ ty2 is the range.
In compiled code it is represented by the named type
FSharp.Core.FastFunc< _ty_^1 , _ty_^2 >.^
Named types are converted to static types as follows:

- _Name Resolution for Types_ (§14.1) resolves _long-ident_ to a type definition with formal generic
    parameters < _typar 1_ ,..., _typarn_ > and formal constraints _C_. The number of type arguments _n_ is
    used during the name resolution process to distinguish between similarly named types that take
    different numbers of type arguments.
- Fresh type inference variables < _ty' 1 ,...,ty'n_ > are generated for each formal type parameter. The
    formal constraints _C_ are added to the current inference constraints for the new type inference
    variables; and constraints _tyi_ = _ty'i_ are added to the current inference constraints.

#### 5.1.2 Variable Types

A type of the form _'ident_ is a _variable type_. For example, the following are all variable types:

```
'a
'T
'Key
```
During checking, _Name Resolution_ (§14.1) is applied to the identifier.

- If name resolution succeeds, the result is a variable type that refers to an existing declared type
    parameter.
- If name resolution fails, the current _floating type variable environment_ is consulted, although
    only in the context of a syntactic type that is embedded in an expression or pattern. If the type
    variable name is assigned a type in that environment, F# uses that mapping. Otherwise, a fresh


```
type inference variable is created (see §14.5) and added to both the type inference environment
and the floating type variable environment.
```
A type of the form _ is an _anonymous variable type_. A fresh type inference variable is created and
added to the type inference environment (see §14.5) for such a type.

A type of the form ^ident is a _statically resolved type variable_. A fresh type inference variable is
created and added to the type inference environment (see §14.5). This type variable is tagged with
an attribute that indicates that it can be generalized only at inline definitions (see §14.6.7). The
same restriction on generalization applies to any type variables that are contained in any type that is
equated with the ^ident type in a type inference equation.

```
Note: this specification generally uses uppercase identifiers such as 'T or 'Key for user-
declared generic type parameters, and uses lowercase identifiers such as 'a or 'b for
compiler-inferred generic parameters.
```
#### 5.1.3 Tuple Types

A _tuple type_ has the following form:

```
ty 1 * ... * tyn
```
The elaborated form of a tuple type is shorthand for a use of the family of F# library types
System.Tuple<_,...,_>. See §6.3.2 for the details of this encoding.

When considered as static types, tuple types are distinct from their encoded form. However, the
encoded form of tuple types is visible in the F# type system through runtime types. For example,
typeof<int * int> is equivalent to typeof<System.Tuple<int,int>>.

#### 5.1.4 Array Types

Array types have the following forms:

```
ty []
ty [ , ... , ]
```
A type of the form _ty_ [] is a _single-dimensional array type_ , and a type of the form _ty_ [ , ... , ] is a
_multidimensional array type_. For example, int[,,] is an array of integers of rank 3.

Except where specified otherwise in this document, these array types are treated as named types, as
if they are an instantiation of a fictitious type definition System.Array _n_ < _ty_ > where _n_ corresponds to
the rank of the array type.

```
Note: The type int[][,] in F# is the same as the type int[,][] in C# although the
dimensions are swapped. This ensures consistency with other postfix type names in F#
such as int list list.
```
```
F# supports multidimensional array types only up to rank 4.
```
#### 5.1.5 Constrained Types

A _type with constraints_ has the following form:


```
type when constraints
```
During checking, _type_ is first checked and converted to a static type, then _constraints_ are checked
and added to the current inference constraints. The various forms of constraints are described
in§5.2.

A type of the form _typar_ :> _type_ is a _type variable with a subtype constraint_ and is equivalent to
_typar_ when _typar_ :> _type_.

A type of the form # _type_ is an _anonymous type with a subtype constraint_ and is equivalent to 'a
when 'a :> _type_ , where 'a is a fresh type inference variable.

### 5.2 TYPE CONSTRAINTS

A _type constraint_ limits the types that can be used to create an instance of a type parameter or type
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

#### 5.2.1 Subtype Constraints

An _explicit subtype constraint_ has the following form:

```
typar :> type
```
During checking, _typar_ is first checked as a variable type, _type_ is checked as a type, and the
constraint is added to the current inference constraints. Subtype constraints affect type coercion as
specified in §5.4.7.

Note that subtype constraints also result implicitly from:

- Expressions of the form expr :> type.

##### • Patterns of the form pattern :> type.

- The use of generic values, types, and members with constraints.
- The implicit use of subsumption when using values and members (§14.4.3).


A type variable cannot be constrained by two distinct instantiations of the same named type. If two
such constraints arise during constraint solving, the type instantiations are constrained to be equal.
For example, during type inference, if a type variable is constrained by both IA<int> and IA<string>,
an error occurs when the type instantiations are constrained to be equal. This limitation is
specifically necessary to simplify type inference, reduce the size of types shown to users, and help
ensure the reporting of useful error messages.

#### 5.2.2 Nullness Constraints

An _explicit nullness constraint_ has the following form:

```
typar : null
```
During checking, _typar_ is checked as a variable type and the constraint is added to the current
inference constraints. The conditions that govern when a type satisfies a nullness constraint are
specified in §5.4.8.

In addition:

- The _typar_ must be a statically resolved type variable of the form _^ident_. This limitation ensures
    that the constraint is resolved at compile time, and means that generic code may not use this
    constraint unless that code is marked inline (§14.6.7).

```
Note: Nullness constraints are primarily for use during type checking and are used
relatively rarely in F# code.
```
```
Nullness constraints also arise from expressions of the form null.
```
#### 5.2.3 Member Constraints

An _explicit member constraint_ has the following form:

```
( typar or ... or typar ) : ( member-sig )
```
For example, the F# library defines the + operator with the following signature:

```
val inline (+) : ^a -> ^b -> ^c
when (^a or ^b) : (static member (+) : ^a * ^b -> ^c)
```
This definition indicates that each use of the + operator results in a constraint on the types that
correspond to parameters ^a, ^b, and ^c. If these are named types, then either the named type for
^a or the named type for ^b must support a static member called + that has the given signature.

In addition:

- Each _typar_ must be a statically resolved type variable (§5.1.2) in the form _^ident_. This ensures
    that the constraint is resolved at compile time against a corresponding named type. It also
    means that generic code cannot use this constraint unless that code is marked inline (§14.6.7).
- The _member-sig_ cannot be generic; that is, it cannot include explicit type parameter definitions.
- The conditions that govern when a type satisfies a member constraint are specified in §14.5.4.


```
Note: Member constraints are primarily used to define overloaded functions in the F#
library and are used relatively rarely in F# code.
```
```
Uses of overloaded operators do not result in generalized code unless definitions are
marked as inline. For example, the function
let f x = x + x
```
```
results in a function f that can be used only to add one type of value, such as int or
float. The exact type is determined by later constraints.
```
A type variable may not be involved in the support set of more than one member constraint that has
the same name, staticness, argument arity, and support set (§14.5.4). If it is, the argument and
return types in the two member constraints are themselves constrained to be equal. This limitation
is specifically necessary to simplify type inference, reduce the size of types shown to users, and
ensure the reporting of useful error messages.

#### 5.2. 4 Default Constructor Constraints

An _explicit default constructor constraint_ has the following form:

```
typar : (new : unit -> 'T)
```
During constraint solving (§14.5), the constraint _type_ : (new : unit -> 'T) is met if _type_ has a
parameterless object constructor.

```
Note: This constraint form exists primarily to provide the full set of constraints that CLI
implementations allow. It is rarely used in F# programming.
```
#### 5.2.5 Value Type Constraints

An _explicit value type constraint_ has the following form:

```
typar : struct
```
During constraint solving (§14.5), the constraint _type_ : struct is met if _type_ is a value type other
than the CLI type System.Nullable<_>.

```
Note: This constraint form exists primarily to provide the full set of constraints that CLI
implementations allow. It is rarely used in F# programming.
```
```
The restriction on System.Nullable is inherited from C# and other CLI languages, which
give this type a special syntactic status. In F#, the type option<_> is similar to some uses
of System.Nullable<_>. For various technical reasons the two types cannot be equated,
notably because types such as System.Nullable<System.Nullable<_>> and
System.Nullable<string> are not valid CLI types.
```
#### 5.2.6 Reference Type Constraints

An _explicit reference type constraint_ has the following form:

```
typar : not struct
```
During constraint solving (§14.5), the constraint _type_ : not struct is met if _type_ is a reference type.


```
Note: This constraint form exists primarily to provide the full set of constraints that CLI
implementations allow. It is rarely used in F# programming.
```
#### 5.2.7 Enumeration Constraints

An _explicit enumeration constraint_ has the following form:

```
typar : enum< underlying-type >
```
During constraint solving (§14.5), the constraint _type_ : enum< _underlying-type_ > is met if type is a CLI
or F# enumeration type that has constant literal values of type _underlying-type_.

```
Note: This constraint form exists primarily to allow the definition of library functions
such as enum. It is rarely used directly in F# programming.
```
```
The enum constraint does not imply anything about subtypes. For example, an enum
constraint does not imply that the type is a subtype of System.Enum.
```
#### 5.2.8 Delegate Constraints

An _explicit delegate constraint_ has the following form:

```
typar : delegate< tupled-arg-type , return-type >
```
During constraint solving (§ 14 .5), the constraint _type_ : delegate< _tupled-arg-type_ , _return-types_ >
is met if _type_ is a delegate type _D_ with declaration type _D_ = delegate of object * arg1 * ... *
argN and _tupled-arg-type_ = _arg1_ * ... * _argN_. That is, the delegate must match the CLI design
pattern where the sender object is the first argument to the event.

```
Note : This constraint form exists primarily to allow the definition of certain F# library
functions that are related to event programming. It is rarely used directly in F#
programming.
```
```
The delegate constraint does not imply anything about subtypes. In particular, a
‘delegate’ constraint does not imply that the type is a subtype of System.Delegate.
```
```
The delegate constraint applies only to delegate types that follow the usual form for CLI
event handlers, where the first argument is a “sender” object. The reason is that the
purpose of the constraint is to simplify the presentation of CLI event handlers to the F#
programmer.
```
#### 5.2.9 Unmanaged Constraints

An _unmanaged constraint_ has the following form:

```
typar : unmanaged
```
During constraint solving (§14.5), the constraint _type_ : unmanaged is met if _type_ is unmanaged as
specified below:

- Types sbyte, byte, char, nativeint, unativeint, float32, float, int16, uint16, int32, uint32,
    int64, uint64, decimal are unmanaged_._
- Type nativeptr< _type_ > is unmanaged_._


- A non-generic struct type whose fields are all unmanaged types is unmanaged_._

#### 5.2.10 Equality and Comparison Constraints

_Equality constraints_ and _comparison constraints_ have the following forms, respectively:

```
typar : equality
typar : comparison
```
During constraint solving (§14.5), the constraint _type_ : equality is met if both of the following
conditions are true:

- The type is a named type, and the type definition does not have, and is not inferred to have, the
    NoEquality attribute.
- The type has _equality dependencies ty 1_ , ..., _tyn_ , each of which satisfies _tyi_ : equality.

The constraint _type_ : comparison is a _comparison constraint_. Such a constraint is met if all the
following conditions hold:

- If the type is a named type, then the type definition does not have, and is not inferred to have,
    the NoComparison attribute, and the type definition implements System.IComparable or is an
    array type or is System.IntPtr or is System.UIntPtr.
- If the type has _comparison dependencies ty 1_ , ..., _tyn_ , then each of these must satisfy _tyi_ :
    comparison

An equality constraint is a relatively weak constraint, because with two exceptions, all CLI types
satisfy this constraint. The exceptions are F# types that are annotated with the NoEquality attribute
and structural types that are inferred to have the NoEquality attribute. The reason is that in other
CLI languages, such as C#, it possible to use reference equality on all reference types.

A comparison constraint is a stronger constraint, because it usually implies that a type must
implement System.IComparable.

### 5.3 TYPE PARAMETER DEFINITIONS

Type parameter definitions can occur in the following locations:

- Value definitions in modules
- Member definitions
- Type definitions
- Corresponding specifications in signatures

For example, the following defines the type parameter ‘T in a function definition:

```
let id<'T> (x:'T) = x
```
Likewise, in a type definition:

```
type Funcs<'T1,'T2> =
{ Forward: 'T1 -> 'T2;
```

```
Backward : 'T2 -> 'T2 }
```
Likewise, in a signature file:

```
val id<'T> : 'T -> 'T
```
Explicit type parameter definitions can include _explicit constraint declarations_. For example:

```
let dispose2<'T when 'T :> System.IDisposable> (x: 'T, y: 'T) =
x.Dispose()
y.Dispose()
```
The constraint in this example requires that 'T be a type that supports the IDisposable interface.

However, in most circumstances, declarations that imply subtype constraints on arguments can be
written more concisely:

```
let throw (x: Exception) = raise x
```
Multiple explicit constraint declarations use and:

```
let multipleConstraints<'T when 'T :> System.IDisposable and
'T :> System.IComparable > (x: 'T, y: 'T) =
if x.CompareTo(y) < 0 then x.Dispose() else y.Dispose()
```
Explicit type parameter definitions can declare custom attributes on type parameter definitions
(§13.1).

### 5.4 LOGICAL PROPERTIES OF TYPES

During type checking and elaboration, syntactic types and constraints are processed into a reduced
form composed of:

- Named types _op_ < _types_ >, where each _op_ consists of a specific type definition, an operator to form
    function types, an operator to form array types of a specific rank, or an operator to form specific
    _n-_ tuple types.
- Type variables ' _ident_.

#### 5.4.1 Characteristics of Type Definitions

Type definitions include CLI type definitions such as System.String and types that are defined in F#
code (§ 8 ). The following terms are used to describe type definitions:

- Type definitions may be _generic_ , with one or more type parameters; for example,
    System.Collections.Generic.Dictionary<'Key,'Value>.
- The generic parameters of type definitions may have associated _formal type constraints_.
- Type definitions may have _custom attributes_ (§13.1), some of which are relevant to checking and
    inference.
- Type definitions may be _type abbreviations_ (§8.3). These are eliminated for the purposes of
    checking and inference (see §5.4.2).


- Type definitions have a _kind_ which is one of the following:
    - _Class_
    - _Interface_
    - _Delegate_
    - _Struct_
    - _Record_
    - _Union_
    - _Enum_
    - _Measure_
    - _Abstract_

```
The kind is determined at the point of declaration by Type Kind Inference (§8.2) if it is not
specified explicitly as part of the type definition. The kind of a type refers to the kind of its
outermost named type definition, after expanding abbreviations. For example, a type is a class
type if it is a named type C< types > where C is of kind class. Thus,
System.Collections.Generic.List<int> is a class type.
```
- Type definitions may be _sealed._ Record, union, function, tuple, struct, delegate, enum, and array
    types are all sealed, as are class types that are marked with the SealedAttribute attribute.
- Type definitions may have zero or one _base type declarations_. Each base type declaration
    represents an additional type that is supported by any values that are formed using the type
    definition. Furthermore, some aspects of the base type are used to form the implementation of
    the type definition.
- Type definitions may have one or more _interface declarations_. These represent additional
    encapsulated types that are supported by values that are formed using the type.

Class, interface, delegate, function, tuple, record, and union types are all _reference_ type definitions.
A type is a reference type if its outermost named type definition is a reference type, after expanding
type definitions.

Struct types are _value types_.

#### 5.4.2 Expanding Abbreviations and Inference Equations

Two static types are considered equivalent and indistinguishable if they are equivalent after taking
into account both of the following:

- The inference equations that are inferred from the current inference constraints (§14.5).
- The expansion of type abbreviations (§8.3).

For example, static types may refer to type abbreviations such as int, which is an abbreviation for
System.Int32and is declared by the F# library:


```
type int = System.Int32
```
This means that the types int32 and System.Int32 are considered equivalent, as are System.Int32 -
> int and int -> System.Int32.

Likewise, consider the process of checking this function:

```
let checkString (x:string) y =
(x = y), y.Contains("Hello")
```
During checking, fresh type inference variables are created for values x and y; let’s call them _ty_ 1 and
_ty_ 2. Checking imposes the constraints _ty_ 1 = string and _ty_ 1 = _ty_ 2. The second constraint results
from the use of the generic = operator. As a result of constraint solving, _ty_ 2 = string is inferred, and
thus the type of y is string.

All relations on static types are considered after the elimination of all equational inference
constraints and type abbreviations. For example, we say int is a struct type because System.Int32 is
a struct type.

```
Note: Implementations of F# should attempt to preserve type abbreviations when
reporting types and errors to users. This typically means that type abbreviations should
be preserved in the logical structure of types throughout the checking process.
```
#### 5.4.3 Type Variables and Definition Sites

Static types may be type variables. During type inference, static types may be _partial_ , in that they
contain type inference variables that have not been solved or generalized. Type variables may also
refer to explicit type parameter definitions, in which case the type variable is said to be _rigid_ and
have a _definition site_.

For example, in the following, the definition site of the type parameter 'T is the type definition of C:

```
type C<'T> = 'T * 'T
```
Type variables that do not have a binding site are _inference variables_. If an expression is composed
of multiple sub-expressions, the resulting constraint set is normally the union of the constraints that
result from checking all the sub-expressions. However, for some constructs (notably function, value
and member definitions), the checking process applies _generalization_ (§14.6.7). Consequently, some
intermediate inference variables and constraints are factored out of the intermediate constraint sets
and new implicit definition site(s) are assigned for these variables.

For example, given the following declaration, the type inference variable that is associated with the
value x is generalized and has an implicit definition site at the definition of function id:

```
let id x = x
```
Occasionally in this specification we use a more fully annotated representation of inferred and
generalized type information. For example:

```
let id <'a> x 'a = x 'a
```

Here, 'a represents a generic type parameter that is inferred by applying type inference and
generalization to the original source code (§14.6.7), and the annotation represents the definition site
of the type variable.

#### 5.4.4 Base Type of a Type

The _base type_ for the static types is shown in the table. These types are defined in the CLI
specifications and corresponding implementation documentation.

**Static Type Base Type**
Abstract types System.Object^
All array types System.Array^
Class types The declared base type of the type definition if the type has one; otherwise,
System.Object. For generic types C< _type-inst_ >, substitute the formal generic
parameters of C for _type-inst_.
Delegate types System.MulticastDelegate^
Enum types System.Enum^
Exception types System.Exception^
Interface types System.Object^
Record types System.Object^
Struct types System.ValueType^
Union types System.Object^
Variable types System.Object^

#### 5.4.5 Interfaces Types of a Type

The _interface types_ of a named type C< _type-inst_ > are defined by the transitive closure of the
interface declarations of C and the interface types of the base type of C, where formal generic
parameters are substituted for the actual type instantiation _type-inst_.

The interface types for single dimensional array types _ty_ [] include the transitive closure that starts
from the interface System.Collections.Generic.IList< _ty_ >, which includes
System.Collections.Generic.ICollection< _ty_ > and System.Collections.Generic.IEnumerable< _ty_ >.

#### 5.4.6 Type Equivalence

Two static types _ty_ 1 and _ty_ 2 are _definitely equivalent_ (with respect to a set of current inference
constraints) if either of the following is true:

- _ty_ 1 has form _op_ < _ty_ 11 _, ..., ty_ 1n>, _ty_ 2 has form _op_ < _ty_ 21 _, ..., ty_ 2n> and each _ty1i_ is definitely
    equivalent to _ty2i_ for all _1_ <= _i_ <= _n_.

—OR—

- _ty_ 1 and _ty_ 2 are both variable types, and they both refer to the same definition site or are the
    same type inference variable.

This means that the addition of new constraints may make types definitely equivalent where
previously they were not. For example, given Χ = { 'a = int }, we have list<int> = list<'a>.

Two static types _ty_ 1 and _ty_ 2 are _feasibly equivalent_ if _ty_ 1 and _ty_ 2 may become definitely equivalent if
further constraints are added to the current inference constraints. Thus list<int> and list<'a> are
feasibly equivalent for the empty constraint set.


#### 5.4.7 Subtyping and Coercion

A static type _ty_ 2 _coerces to_ static type _ty_ 1 (with respect to a set of current inference constraints X), if
_ty_ 1 is in the transitive closure of the base types and interface types of _ty_ 2. Static coercion is written
with the :> symbol:

```
ty 2 :> ty 1 ,
```
Variable types 'T coerce to all types _ty_ if the current inference constraints include a constraint of the
form 'T :> _ty_ 2 , and _ty_ is in the inclusive transitive closure of the base and interface types of _ty_ 2.

A static type _ty_ 2 _feasibly coerces to_ static type _ty_ 1 if _ty_ 2 _coerces to ty 1_ may hold through the addition
of further constraints to the current inference constraints. The result of adding constraints is defined
in _Constraint Solving_ (§14.5).

#### 5.4.8 Nullness

The design of F# aims to greatly reduce the use of null literals in common programming tasks,
because they generally result in error-prone code. However:

- The use of some null literals is required for interoperation with CLI libraries.
- The appearance of null values during execution cannot be completely precluded for technical
    reasons related to the CLI and CLI libraries.

As a result, F# types differ in their treatment of the null literal and null values. All named types and
type definitions fall into one of the following categories:

- **Types with the null literal.** These types have null as an “extra” value. The following types are in
    this category:
    - All CLI reference types that are defined in other CLI languages.
    - All types that are defined in F# and annotated with the AllowNullLiteral attribute.

```
For example, System.String and other CLI reference types satisfy this constraint, and these types
permit the direct use of the null literal.
```
- **Types with null as an abnormal value.** These types do not permit the null literal, but do have
    null as an abnormal value. The following types are in this category:
    - All F# list, record, tuple, function, class, and interface types.
    - All F# union types except those that have null as a normal value, as discussed in the next
       bullet point.

```
For types in this category, the use of the null literal is not directly allowed. However, strictly
speaking, it is possible to generate a null value for these types by using certain functions such as
Unchecked.defaultof< type >. For these types, null is considered an abnormal value. Operations
differ in their use and treatment of null values; for details about evaluation of expressions that
might include null values, see §6.9.
```

- **Types with null as a representation value.** These types do not permit the null literal but use
    the null value as a representation.
    For these types, the use of the null literal is not directly permitted. However, one or all of the
    “normal” values of the type is represented by the null value. The following types are in this
    category:
    - The unit type. The null value is used to represent all values of this type.
    - Any union type that has the
       FSharp.Core.CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueV
       alue) attribute flag and a single null union case. The null value represents this case. In
       particular, null represents None in the F# option<_> type.
- **Types without null.** These types do not permit the null literal and do not have the null value.
    All value types are in this category, including primitive integers, floating-point numbers, and any
    value of a CLI or F# struct type.

A static type _ty satisfies a nullness constraint ty_ : null if it:

- Has an outermost named type that has the null literal.
- Is a variable type with a _typar_ : null constraint.

#### 5.4.9 Default Initialization

Related to nullness is the _default initialization_ of values of some types to _zero values_. This technique
is common in some programming languages, but the design of F# deliberately de-emphasizes it.
However, default initialization is allowed in some circumstances:

- Checked default initialization may be used when a type is known to have a valid and “safe”
    default zero value. For example, the types of fields that are labeled with DefaultValue(true) are
    checked to ensure that they allow default initialization.
- CLI libraries sometimes perform unchecked default initialization, as do the F# library primitives
    Unchecked.defaultof<_> and Array.zeroCreate.

The following types _permit default initialization_ :

- Any type that satisfies the nullness constraint.
- Primitive value types.
- Struct types whose field types all permit default initialization.

#### 5.4.10 Dynamic Conversion Between Types

A runtime type _vty dynamically converts to_ a static type _ty_ if any of the following are true:

- _vty_ coerces to _ty_.
- _vty_ is int32[]and _ty_ is uint32[](or conversely). Likewise for sbyte[]/byte[], int16[]/uint16[],
    int64[]/uint64[], and nativeint[]/unativeint[].


- _vty_ is _enum_ [] where _enum_ has underlying type _underlying_ , and _ty_ is _underlying_ [] (or conversely),
    or the (un)signed equivalent of _underlying_ [] by the immediately preceding rule.
- _vty_ is _elemty 1_ [], _ty_ is _elemty 2_ [], _elemty 1_ is a reference type, and _elemty 1_ converts to _elemty 2_.
- _ty_ is System.Nullable< _vty_ >.

Note that this specification does not define the full algebra of the conversions of runtime types to
static types because the information that is available in runtime types is implementation dependent.
However, the specification does state the conditions under which objects are guaranteed to have a
runtime type that is compatible with a particular static type.

```
Note : This specification covers the additional rules of CLI dynamic conversions, all of
which apply to F# types. For example:
let x = box [| System.DayOfWeek.Monday |]
let y = x :? int32[]
printf "%b" y // true
```
```
In the previous code, the type System.DayOfWeek.Monday[] does not statically coerce to
int32[], but the expression x :? int32[] evaluates to true.
let x = box [| 1 |]
let y = x :? uint32 []
printf "%b" y // true
```
```
In the previous code, the type int32[] does not statically coerce to uint32[], but the
expression x :? uint32 [] evaluates to true.
let x = box [| "" |]
let y = x :? obj []
printf "%b" y // true
```
```
In the previous code, the type string[] does not statically coerce to obj[], but the
expression x :? obj []evaluates to true.
let x = box 1
let y = x :? System.Nullable<int32>
printf "%b" y // true
```
```
In the previous code, the type int32 does not coerce to System.Nullable<int32>, but the
expression x :? System.Nullable<int32> evaluates to true.
```

## 6. EXPRESSIONS

The expression forms and related elements are as follows:

```
expr :=
const -- a constant value
( expr ) -- block expression
begin expr end -- block expression
long-ident-or-op -- lookup expression
expr '.' long-ident-or-op -- dot lookup expression
expr expr -- application expression
expr ( expr ) -- high precedence application
expr < types > -- type application expression
expr infix-op expr -- infix application expression
prefix-op expr -- prefix application expression
expr .[ expr ] -- indexed lookup expression
expr .[ slice-ranges ] -- slice expression
expr <- expr -- assignment expression
expr , ... , expr -- tuple expression
new type expr -- simple object expression
{ new base-call object-members interface-impls } -- object expression
{ field-initializers } -- record expression
{ expr with field-initializers } -- record cloning expression
[ expr ; ... ; expr ] -- list expression
[| expr ; ... ; expr |] -- array expression
expr { comp-or-range-expr } -- computation expression
[ comp-or-range-expr ] -- computed list expression
[| comp-or-range-expr |] -- computed array expression
lazy expr -- delayed expression
null -- the "null" value for a reference type
expr : type -- type annotation
expr :> type -- static upcast coercion
expr :? type -- dynamic type test
expr :?> type -- dynamic downcast coercion
upcast expr -- static upcast expression
downcast expr -- dynamic downcast expression
let function-defn in expr – - function definition expression
let value-defn in expr – - value definition expression
let rec function-or-value-defns in expr -- recursive definition expression
use ident = expr in expr – - deterministic disposal expression
fun argument-pats - > expr -- function expression
function rules -- matching function expression
expr ; expr -- sequential execution expression
match expr with rules -- match expression
try expr with rules -- try/with expression
try expr finally expr -- try/finally expression
if expr then expr elif-branchesopt else-branch opt -- conditional expression
while expr do expr done -- while loop
for ident = expr to expr do expr done -- simple for loop
for pat in expr - or-range-expr do expr done -- enumerable for loop
assert expr -- assert expression
<@ expr @> -- quoted expression
<@@ expr @@> -- quoted expression
% expr -- expression splice
%%expr -- weakly typed expression splice
( static-typars : ( member-sig ) expr) - – static member invocation
```

Expressions are defined in terms of patterns and other entities that are discussed later in this
specification. The following constructs are also used:

```
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
inline opt accessopt ident-or-op typar-defnsopt argument-pats return-typeopt = expr
value-defn :=
mutable opt accessopt pat typar-defnsopt return-typeopt = expr
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
type -- interface construction expression
base-call :=
object-construction -- anonymous base construction
object-construction as ident -- named base construction
interface-impls := interface-impl ... interface-impl
interface-impl :=
interface type object-membersopt -- interface implementation
object-members := with member-defns end
member-defns := member-defn ... member-defn
```

Computation and range expressions are defined in terms of the following productions:

```
comp-or-range-expr :=
comp-expr
short-comp-expr
range-expr
comp-expr :=
let! pat = expr in comp-expr -- binding computation
let pat = expr in comp-expr
do! expr in comp-expr -- sequential computation
do expr in comp-expr
use! pat = expr in comp-expr -- auto cleanup computation
use pat = expr in comp-expr
yield! expr -- yield computation
yield expr -- yield result
return! expr -- return computation
return expr -- return result
if expr then comp - expr -- control flow or imperative action
if expr then expr else comp-expr
match expr with pat -> comp-expr | ... | pat - > comp-expr
try comp - expr with pat -> comp-expr | ... | pat - > comp-expr
try comp - expr finally expr
while expr do comp - expr done
for ident = expr to expr do comp - expr done
for pat in expr - or-range-expr do comp - expr done
comp - expr ; comp - expr
expr
short-comp-expr :=
for pat in expr-or-range-expr - > expr -- yield result
range-expr :=
expr .. expr -- range sequence
expr .. expr .. expr -- range sequence with skip
slice-ranges := slice-range , ... , slice-range
slice-range :=
expr -- slice of one element of dimension
expr .. -- slice from index to end
.. expr -- slice from start to index
expr .. expr -- slice from index to index
'*' -- slice from start to end
```
### 6.1 SOME CHECKING AND INFERENCE TERMINOLOGY

The rules applied to check individual expressions are described in the following subsections. Where
necessary, these sections reference specific inference procedures such as _Name Resolution_ (§14.1)
and _Constraint Solving_ (§14.5).

All expressions are assigned a static type through type checking and inference. During type checking,
each expression is checked with respect to an _initial type_. The initial type establishes some of the
information available to resolve method overloading and other language constructs. We also use the
following terminology:

- The phrase “the type _ty 1_ is asserted to be equal to the type _ty 2_ ” or simply “ _ty 1_ = _ty 2_ is asserted”
    indicates that the constraint “ _ty 1_ = _ty 2_ ” is added to the current inference constraints.


- The phrase “ _ty 1_ is asserted to be a subtype of _ty 2_ ” or simply “ _ty 1_ :> _ty 2_ is asserted” indicates
    that the constraint _ty 1_ :> _ty 2_ is added to the current inference constraints.
- The phrase “type _ty_ is known to ...” indicates that the initial type satisfies the given property
    given the current inference constraints.
- The phrase “the expression _expr_ has type _ty_ ” means the initial type of the expression is asserted
    to be equal to _ty_.

Additionally:

- The addition of constraints to the type inference constraint set fails if it causes an inconsistent
    set of constraints (§14.5). In this case either an error is reported or, if we are only attempting to
    _assert_ the condition, the state of the inference procedure is left unchanged and the test fails.

### 6.2 ELABORATION AND ELABORATED EXPRESSIONS

Checking an expression generates an _elaborated expression_ in a simpler, reduced language that
effectively contains a fully resolved and annotated form of the expression. The elaborated
expression provides more explicit information than the source form. For example, the elaborated
form of System.Console.WriteLine("Hello") indicates exactly which overloaded method definition
the call has resolved to. Elaborated forms are underlined in this specification, for example, let x = 1
in x + x.

Except for this extra resolution information, elaborated forms are syntactically a subset of syntactic
expressions, and in some cases (such as constants) the elaborated form is the same as the source
form. This specification uses the following elaborated forms:

- Constants
- Resolved value references: _path_
- Lambda expressions: (fun _ident_ - > _expr_ )
- Primitive object expressions
- Data expressions (tuples, union cases, array creation, record creation)
- Default initialization expressions
- Local definitions of values: let _ident_ = _expr_ in _expr_
- Local definitions of functions:
    let rec _ident_ = _expr_ and ... and _ident_ = _expr_ in _expr_
- Applications of methods and functions (with static overloading resolved)
- Dynamic type coercions: _expr_ :?> _type_
- Dynamic type tests: _expr_ :? _type_
- For-loops: for _ident_ in _ident_ to _ident_ do _expr_ done
- While-loops: while _expr_ do _expr_ done
- Sequencing: _expr_ ; _expr_


- Try-with: try _expr_ with _expr_
- Try-finally: try _expr_ finally _expr_
- The constructs required for the elaboration of pattern matching (§ 7 ).
    - Null tests
    - Switches on integers and other types
    - Switches on union cases
    - Switches on the runtime types of objects

The following constructs are used in the elaborated forms of expressions that make direct
assignments to local variables and arrays and generate “byref” pointer values. The operations are
loosely named after their corresponding primitive constructs in the CLI.

- Assigning to a byref-pointer: _expr_ <-stobj _expr_
- Generating a byref-pointer by taking the address of a mutable value: _&path_.
- Generating a byref-pointer by taking the address of a record field: _&_ ( _expr.field_ )
- Generating a byref-pointer by taking the address of an array element: _&_ ( _expr._ [ _expr_ ])

Elaborated expressions form the basis for evaluation (see §6.9) and for the expression trees that
_quoted expressions_ return(see §6.8).

By convention, when describing the process of elaborating compound expressions, we omit the
process of recursively elaborating sub-expressions.

### 6.3 DATA EXPRESSIONS

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

#### 6.3.1 Simple Constant Expressions

Simple constant expressions are numeric, string, Boolean and unit constants. For example:

```
3y // sbyte
32uy // byte
17s // int16
18us // uint16
86 // int/int32
99u // uint32
99999999L // int64
10328273UL // uint64
```
1. // float/double
1.01 // float/double
1.01e10 // float/double
1.0f // float32/single
1.01f // float32/single
1.01e10f // float32/single
99999999n // nativeint (System.IntPtr)
1032827 3un // unativeint (System.UIntPtr)
99999999I // bigint (System.Numerics.BigInteger or user-specified)
'a' // char (System.Char)
"3" // string (String)
"c:\\home" // string (System.String)
@"c:\home" // string (Verbatim Unicode, System.String)
"ASCII"B // byte[]
() // unit (FSharp.Core.Unit)
false // bool (System.Boolean)
true // bool (System.Boolean)

Simple constant expressions have the corresponding simple type and elaborate to the corresponding
simple constant value.

Integer literals with the suffixes Q, R, Z, I, N, G are processed using the following syntactic translation:

```
xxxx<suffix>
```
```
For xxxx = 0 → NumericLiteral<suffix>.FromZero()
```
```
For xxxx = 1 → NumericLiteral<suffix>.FromOne()
```
```
For xxxx in the Int32 range → NumericLiteral<suffix>.FromInt32(xxxx)
```
```
For xxxx in the Int64 range → NumericLiteral<suffix>.FromInt64(xxxx)
```
```
For other numbers → NumericLiteral<suffix>.FromString("xxxx")
```
For example, defining a module NumericLiteralZ as below enables the use of the literal form 32Z to
generate a sequence of 32 ‘Z’ characters. No literal syntax is available for numbers outside the range
of 32-bit integers.

```
module NumericLiteralZ =
```

```
let FromZero() = ""
let FromOne() = "Z"
let FromInt32 n = String.replicate n "Z"
```
F# compilers may optimize on the assumption that calls to numeric literal functions always
terminate, are idempotent, and do not have observable side effects.

#### 6.3.2 Tuple Expressions

An expression of the form _expr_ 1 , ..., _expr_ n is a _tuple expression_. For example:

```
let three = (1,2,"3")
let blastoff = (10,9,8,7,6,5,4,3,2,1,0)
```
The expression has the type ( _ty 1_ * ... * _tyn_ ) for fresh types _ty 1_ ... _tyn_ , and each individual
expression _e_ i is checked using initial type _ty_ i.

Tuple types and expressions are translated into applications of a family of F# library types named
System.Tuple. Tuple types _ty 1_ * ... * _tyn_ are translated as follows:

- For _n_ <= 7 the elaborated form is Tuple< _ty 1_ ,..., _tyn_ >.
- For larger _n_ , tuple types are shorthand for applications of the additional F# library type
    System.Tuple<_> as follows:
    - For _n_ = 8 the elaborated form is Tuple< _ty 1_ ,..., _ty 7_ ,Tuple< _ty 8_ >>.
    - For 9 <= _n_ the elaborated form is Tuple< _ty 1_ ,..., _ty 7_ , _tyB_ > where _tyB_ is the converted form of
       the type ( _ty 8_ *...* _tyn_ ).

Tuple expressions ( _expr_ 1 ,..., _exprn_ ) are translated as follows:

- For _n_ <= 7 the elaborated form new Tuple< _ty 1_ ,..., _tyn_ >( _expr_ 1 ,..., _exprn_ ).
- For _n_ = 8 the elaborated form new Tuple< _ty 1_ ,..., _ty 7_ ,Tuple< _ty 8_ >>( _expr_ 1 ,..., _expr_ 7 , new
    Tuple<ty 8 >( _expr_ 8 ).
- For 9 <= _n_ the elaborated form new Tuple< _ty 1_ ,... _ty 7_ , _ty_ **_8n_** >( _expr_ 1 ,..., _expr_ 7 , new _ty_ **8n** ( _e_ 8n)
    where _ty_ 8n is the type ( _ty_ 8 *...* _ty_ n) and _expr_ 8n is the elaborated form of the expression
    _expr_ 8 ,..., _expr_ n.

When considered as static types, tuple types are distinct from their encoded form. However, the
encoded form of tuple values and types is visible in the F# type system through runtime types. For
example, typeof<int * int> is equivalent to typeof<System.Tuple<int,int>>, and (1,2) has the
runtime type System.Tuple<int,int>. Likewise, (1,2,3,4,5,6,7,8,9) has the runtime type
Tuple<int,int,int,int,int,int,int,Tuple<int,int>>.

```
Note: The above encoding is invertible and the substitution of types for type variables
preserves this inversion. This means, among other things, that the F# reflection library
can correctly report tuple types based on runtime System.Type values. The inversion is
defined by:
```
- For the runtime type Tuple< _ty 1_ ,..., _tyN_ > when n <= 7, the corresponding F# tuple
    type is _ty 1_ * ... * _tyN_


- For the runtime type Tuple< _ty 1_ ,..., Tuple< _tyN_ >> when n = 8, the corresponding F#
    tuple type is _ty 1_ * ... * _ty 8_
- For the runtime type Tuple< _ty 1_ ,..., _ty 7_ , _tyBn_ > , if _tyBn_ corresponds to the F# tuple
    type _ty 8_ * ... * _tyN_ , then the corresponding runtime type is _ty 1_ * ... * _tyN_.

```
Runtime types of other forms do not have a corresponding tuple type. In particular,
runtime types that are instantiations of the eight-tuple type Tuple<_,_,_,_,_,_,_,_>
must always have Tuple<_> in the final position. Syntactic types that have some other
form of type in this position are not permitted, and if such an instantiation occurs in F#
code or CLI library metadata that is referenced by F# code, an F# implementation may
report an error.
```
#### 6.3. 3 List Expressions

An expression of the form [ _expr 1_ ;...; _exprn_ ] is a _list expression_. The initial type of the expression is
asserted to be FSharp.Collections.List< _ty_ > for a fresh type _ty_.

If _ty_ is a named type, each expression _expri_ is checked using a fresh type _ty'_ as its initial type, with
the constraint _ty'_ :> _ty_. Otherwise, each expression _expri_ is checked using _ty_ as its initial type.

List expressions elaborate to uses of FSharp.Collections.List<_> as
op_Cons( _expr 1_ ,(op_Cons( _expr 2_ ... op_Cons ( _exprn_ , op_Nil)...) where op_Cons and op_Nil are the
union cases with symbolic names :: and [] respectively.

#### 6.3.4 Array Expressions

An expression of the form [| _expr 1_ ;...; _exprn_ |] is an _array expression_. The initial type of the
expression is asserted to be _ty_ [] for a fresh type _ty_.

If this assertion determines that _ty_ is a named type, each expression _expri_ is checked using a fresh
type _ty'_ as its initial type, with the constraint _ty'_ :> _ty_. Otherwise, each expression _expri_ is
checked using _ty_ as its initial type.

Array expressions are a primitive elaborated form.

```
Note: The F# implementation ensures that large arrays of constants of type bool, char,
byte, sbyte, int16, uint16, int32, uint32, int64, and uint64 are compiled to an efficient
binary representation based on a call to
System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray.
```
#### 6.3.5 Record Expressions

An expression of the form { _field-initializer 1_ ; ... ; _field-initializern_ } is a _record
construction expression_. For example:

```
type Data = { Count : int; Name : string }
let data1 = { Count = 3; Name = "Hello"; }
let data2 = { Name = "Hello"; Count= 3 }
```
In the following example, data4 uses a long identifier to indicate the relevant field:

```
module M =
```

```
type Data = { Age : int; Name : string; Height : float }
```
```
let data3 = { M.Age = 17; M.Name = "John"; M.Height = 186.0 }
let data4 = { data3 with M.Name = "Bill"; M.Height = 176.0 }
```
Fields may also be referenced by using the name of the containing type:

```
module M2 =
type Data = { Age : int; Name : string; Height : float }
```
```
let data5 = { M2.Data.Age = 17; M2.Data.Name = "John"; M2.Data.Height = 186.0 }
let data6 = { data5 with M2.Data.Name = "Bill"; M2.Data.Height=176.0 }
```
```
open M2
let data7 = { Data.Age = 17; Data.Name = "John"; Data.Height = 186.0 }
let data8 = { data5 with Data.Name = "Bill"; Data.Height=176.0 }
```
Each _field-initializeri_ has the form _field-labeli_ = _expri_. Each _field-labeli_ is a _long-ident_ ,
which must resolve to a field _F_ i in a unique record type _R_ as follows:

- If _field-label_ i is a single identifier _fld_ and the initial type is known to be a record type
    _R_ <_,...,_> that has field Fi with name _fld_ , then the field label resolves to Fi.
- If _field-label_ i is not a single identifier or if the initial type is a variable type, then the field label
    is resolved by performing _Field Label Resolution_ (see §14.1) on _field-label_ i. This procedure
    results in a set of fields _FSet_ i. Each element of this set has a corresponding record type, thus
    resulting in a set of record types _RSet_ i. The intersection of all _RSet_ i must yield a single record
    type _R_ , and each field then resolves to the corresponding field in _R_.
    The set of fields must be complete. That is, each field in record type _R_ must have exactly one
    field definition. Each referenced field must be accessible (see §10.5), as must the type _R_.

After all field labels are resolved, the overall record expression is asserted to be of type
_R_ < _ty 1_ ,..., _tyN_ > for fresh types _ty 1_ ,..., _tyN_. Each _expri_ is then checked in turn. The initial type is
determined as follows:

1. Assume the type of the corresponding field Fi in _R_ < _ty 1_ ,..., _tyN_ > is ftyi
2. If the type of Fi prior to taking into account the instantiation < _ty 1_ ,..., _tyN_ > is a named type, then
    the initial type is a fresh type inference variable _fty'_ i with a constraint _fty'_ i :> _fty_ i.
3. Otherwise the initial type is _ftyi_.

Primitive record constructions are an elaborated form in which the fields appear in the same order
as in the record type definition. Record expressions themselves elaborate to a form that may
introduce local value definitions to ensure that expressions are evaluated in the same order that the
field definitions appear in the original expression. For example:

```
type R = {b : int; a : int }
{ a = 1 + 1; b = 2 }
```
The expression on the last line elaborates to let v = 1 + 1 in { b = 2; a = v }.


Records expressions are also used for object initializations in additional object constructor
definitions (§8.6.3). For example:

```
type C =
val x : int
val y : int
new() = { x = 1; y = 2 }
```
```
Note: The following record initialization form is deprecated:
{ new type with Field 1 = expr 1 and ... and Fieldn = exprn }
```
```
The F# implementation allows the use of this form only with uppercase identifiers.
```
```
F# code should not use this expression form. A future version of the F# language will
issue a deprecation warning.
```
#### 6.3.6 Copy-and-update Record Expressions

A _copy-and-update record expression_ has the following form:

```
{ expr with field-initializers }
```
where _field-initializers_ is of the following form:

```
field-label 1 = expr 1 ; ... ; field-labeln = exprn
```
Each _field-labeli_ is a _long-ident_. In the following example, data2 is defined by using such an
expression:

```
type Data = { Age : int; Name : string; Height : float }
let data1 = { Age = 17; Name = "John"; Height = 186.0 }
let data2 = { data1 with Name = "Bill"; Height = 176.0 }
```
The expression _expr_ is first checked with the same initial type as the overall expression. Next, the
field definitions are resolved by using the same technique as for record expressions. Each field label
must resolve to a field _F_ i in a single record type _R_ , all of whose fields are accessible. After all field
labels are resolved, the overall record expression is asserted to be of type _R_ < _ty 1_ ,..., _tyN_ > for fresh
types _ty 1_ ,..., _tyN_. Each expri is then checked in turn with initial type that results from the following
procedure:

1. Assume the type of the corresponding field Fi in _R_ < _ty 1_ ,..., _tyN_ > is ftyi.
2. If the type of Fi before considering the instantiation < _ty 1_ ,..., _tyN_ > is a named type, then the
    initial type is a fresh type inference variable _fty'_ i with a constraint _fty'_ i :> _fty_ i.
3. Otherwise, the initial type is _ftyi_.

A copy-and-update record expression elaborates as if it were a record expression written as follows:

let _v_ = _expr_ in { _field-label 1_ = _expr 1_ ; ... ; _field-labeln_ = _exprn; F 1 = v.F 1 ; ... ; FM = v.FM_ }
where _F_ 1 ... _F_ M are the fields of R that are not defined in _field-initializers_ and _v_ is a fresh
variable.


#### 6.3.7 Function Expressions

An expression of the form fun _pat 1_ ... _patn_ - > _expr_ is a _function expression_. For example:

```
(fun x -> x + 1)
(fun x y -> x + y)
(fun [x] -> x) // note, incomplete match
(fun (x,y) (z,w) -> x + y + z + w)
```
Function expressions that involve only variable patterns are a primitive elaborated form. Function
expressions that involve non-variable patterns elaborate as if they had been written as follows:

```
fun v 1 ... vn - >
let pat 1 = v 1
```
```
let patn = vn
expr
```
No pattern matching is performed until all arguments have been received. For example, the
following does not raise a MatchFailureException exception:

```
let f = fun [x] y -> y
let g = f [] // ok
```
However, if a third line is added, a MatchFailureException exception is raised:

```
let z = g 3 // MatchFailureException is raised
```
#### 6.3.8 Object Expressions

An expression of the following form is an _object expression_ :

```
{ new ty 0 args-expr opt object-members
interface ty 1 object-members 1
...
interface tyn object-membersn }
```
In the case of the interface declarations, the _object-members_ are optional and are considered empty
if absent. Each set of _object-members_ has the form:

```
with member-defns endopt
```
Lexical filtering inserts simulated $end tokens when lightweight syntax is used.

Each member of an object expression members can use the keyword member, override, or default.
The keyword member can be used even when overriding a member or implementing an interface.

For example:

```
let obj1 =
{ new System.Collections.Generic.IComparer<int> with
member x.Compare(a,b) = compare (a % 7) (b % 7) }
```
```
let obj2 =
{ new System.Object() with
member x.ToString () = "Hello" }
```
```
let obj3 =
```

```
{ new System.Object() with
member x.ToString () = "Hello, base.ToString() = " + base.ToString() }
```
```
let obj4 =
{ new System.Object() with
member x.Finalize() = printfn "Finalize";
interface System.IDisposable with
member x.Dispose() = printfn "Dispose"; }
```
An object expression can specify additional interfaces beyond those required to fulfill the abstract
slots of the type being implemented. For example, obj4 in the preceding examples has static type
System.Object but the object additionally implements the interface System.IDisposable. The
additional interfaces are not part of the static type of the overall expression, but can be revealed
through type tests.

Object expressions are statically checked as follows.

1. First, _ty 0_ to _tyn_ are checked to verify that they are named types. The overall type of the
expression is _ty 0_ and is asserted to be equal to the initial type of the expression. However, if _ty 0_
is type equivalent to System.Object and _ty 1_ exists, then the overall type is instead _ty 1_.

2. The type _ty 0_ must be a class or interface type. The base construction argument _args-expr_ must
    appear if and only if _ty 0_ is a class type. The type must have one or more accessible constructors;
    the call to these constructors is resolved and elaborated using _Method Application Resolution_
    (see §14.4). Except for _ty 0_ , each _tyi_ must be an interface type.
3. The F# compiler attempts to associate each member with a unique _dispatch slot_ by using
    _dispatch slot inference_ (§14.7). If a unique matching dispatch slot is found, then the argument
    types and return type of the member are constrained to be precisely those of the dispatch slot.
4. The arguments, patterns, and expressions that constitute the bodies of all implementing
    members are next checked one by one to verify the following:
    - For each member, the “this” value for the member is in scope and has type _ty_ 0.
    - Each member of an object expression can initially access the protected members of _ty_ 0.
    - If the variable _base-ident_ appears, it must be named base, and in each member a base
       variable with this name is in scope. Base variables can be used only in the member
       implementations of an object expression, and are subject to the same limitations as byref
       values described in §14.9.

The object must satisfy _dispatch slot checking_ (§14.8) which ensures that a one-to-one mapping
exists between dispatch slots and their implementations.

Object expressions elaborate to a primitive form. At execution, each object expression creates an
object whose runtime type is compatible with all of the _tyi_ that have a dispatch map that is the
result of _dispatch slot checking_ (§14.8).

The following example shows how to both implement an interface and override a method from
System.Object. The overall type of the expression is INewIdentity.


```
type public INewIdentity =
abstract IsAnonymous : bool
```
```
let anon =
{ new System.Object() with
member i.ToString() = "anonymous"
interface INewIdentity with
member i.IsAnonymous = true }
```
#### 6.3.9 Delayed Expressions

An expression of the form lazy _expr_ is a _delayed expression_. For example:

```
lazy (printfn "hello world")
```
is syntactic sugar for

```
new System.Lazy (fun () -> expr )
```
The behavior of the System.Lazy library type ensures that expression _expr_ is evaluated on demand in
response to a .Value operation on the lazy value.

#### 6.3.10 Computation Expressions

The following expression forms are all c _omputation expressions_ :

```
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

```
builder-expr { cexpr }
```
where cexpr is, syntactically, the grammar of expressions with the additional constructs that are
defined in comp-expr. Computation expressions are used for sequences and other non-standard
interpretations of the F# expression syntax. For a fresh variable b, the expression

```
builder-expr { cexpr }
```
translates to

```
let b = builder-expr in {| cexpr |}C
```
The type of b must be a named type after the checking of builder-expr. The subscript indicates that
custom operations (C) are acceptable but are not required.

If the inferred type of b has one or more of the Run, Delay, or Quote methods when builder-expr is
checked, the translation involves those methods. For example, when all three methods exist, the
same expression translates to:


```
let b = builder-expr in b.Run (<@ b.Delay(fun () -> {| cexpr |}C) >@)
```
If a **Run** method does not exist on the inferred type of b, the call to **Run** is omitted. Likewise, if no
**Delay** method exists on the type of b, that call and the inner lambda are omitted, so the expression
translates to the following:

```
let b = builder-expr in b.Run (<@ {| cexpr |}C >@)
```
Similarly, if a Quote method exists on the inferred type of b, at-signs <@ @> are placed around {| cexpr
|}C or b.Delay(fun () -> {| cexpr |}C) if a Delay method also exists.

The translation {| _cexpr_ |}C , which rewrites computation expressions to core language expressions,
is defined recursively according to the following rules:

{| _cexpr_ |}C ≡ **T** (cexpr, [], fun v -> v, true)

During the translation, we use the helper function {| cexpr |} 0 to denote a translation that does not
involve custom operations:

{| _cexpr_ |} 0 ≡ **T** (cexpr, [], fun v -> v, false)

```
T (e, V , C , q) where e : the computation expression being translated
V : a set of scoped variables
C : continuation (or context where “e” occurs,
up to a hole to be filled by the result of translating “e”)
q : Boolean that indicates whether a custom operator is allowed
```
Then, T is defined for each computation expression e:

**T** (let p = e in ce, **V** , **C** , q) = **T** (ce, **V**  _var_ (p), v. **C** (let p = e in v), q)

**T** (let! p = e in ce, **V** , **C** , q) = **T** (ce, **V**  _var_ (p), v. **C** (b.Bind( _src_ (e),fun p -> v), q)

**T** (yield e, **V** , **C** , q) = **C** (b.Yield(e))

**T** (yield! e, **V** , **C** , q) = **C** (b.YieldFrom( _src_ (e)))

**T** (return e, **V** , **C** , q) = **C** (b.Return(e))

**T** (return! e, **V** , **C** , q) = **C** (b.ReturnFrom( _src_ (e)))

**T** (use p = e in ce, **V** , **C** , q) = **C** (b.Using(e, fun p -> {| _ce_ |} 0 ))

**T** (use! p = e in ce, **V** , **C** , q) = **C** (b.Bind( _src_ (e), fun p -> b.Using(p, fun p -> {| _ce_ |} 0 ))

**T** (match e with pi - > cei, **V** , **C** , q) = **C** (match e with pi - > {| _ce_ i |} 0 )

**T** (while e do ce, **V** , **C** , q) = **T** (ce, **V** , v. **C** (b.While(fun () -> e, b.Delay(fun () -> v))), q)

**T** (try ce with pi - > cei, **V** , **C** , q) =
Assert(not q); **C** (b.TryWith(b.Delay(fun () -> {| _ce_ |} 0 ), fun pi - > {| _ce_ i |} 0 ))

**T** (try ce finally e, **V** , **C** , q) =
Assert(not q); **C** (b.TryFinally(b.Delay(fun () -> {| _ce_ |} 0 ), fun () -> e))

**T** (if e then ce, **V** , **C** , q) = **T** (ce, **V** , v. **C** (if e then v else b.Zero()), q)


**T** (if e then ce 1 else ce 2 , **V** , **C** , q) = Assert(not q); **C** (if e then {| _ce_ 1 |} 0 ) else {| _ce_ 2 |} 0 )

**T** (for x = e 1 to e 2 do ce, **V** , **C** , q) = **T** (for x in e 1 .. e 2 do ce, **V** , **C** , q)

**T** (for p 1 in e 1 do joinOp p 2 in e 2 onWord (e 3 _eop_ e 4 ) ce, **V** , **C** , q) =
Assert(q); **T** (for _pat_ ( **V** ) in b.Join( _src_ (e 1 ), _src_ (e 2 ), p 1 .e 3 , p 2 .e 4 ,
p 1. p 2 .(p 1 ,p 2 )) do ce, **V** , **C** , q)

**T** (for p 1 in e 1 do groupJoinOp p 2 in e 2 onWord (e 3 _eop_ e4) into p 3 ce, **V** , **C** , q) =
Assert(q); **T** (for _pat_ ( **V** ) in b.GroupJoin( _src_ (e1),
_src_ (e2), p1.e3, p2.e4, p1. p3.(p1,p3)) do ce, **V** , **C** , q)

**T** (for x in e do ce, **V** , **C** , q) = **T** (ce, **V**  {x}, v. **C** (b.For( _src_ (e), fun x -> v)), q)

**T** (do e in ce, **V** , **C** , q) = **T** (ce, **V** , v. **C** (e; v), q)

**T** (do! e in ce, **V** , **C** , q) = **T** (let! () = e in ce, **V** , **C** , q)

**T** (joinOp p 2 in e 2 on (e 3 _eop_ e4) ce, **V** , **C** , q) =
**T** (for _pat_ ( **V** ) in **C** ({| yield _exp_ ( **V** ) |}0) do join p 2 in e 2 onWord (e 3 _eop_ e4) ce, **V** , v.v, q)

**T** (groupJoinOp p 2 in e 2 onWord (e 3 eop e4) into p 3 ce, **V** , **C** , q) =
**T** (for _pat_ ( **V** ) in **C** ({| yield _exp_ ( **V** ) |}0) do groupJoin p 2 in e 2 on (e 3 _eop_ e4) into p 3 ce,
**V** , v.v, q)

**T** ([<CustomOperator("Cop")>]cop arg, **V** , **C** , q) = Assert (q); [| cop arg, **C** (b.Yield _exp_ ( **V** )) |] **V**

**T** ([<CustomOperator("Cop", MaintainsVarSpaceUsingBind=true)>]cop arg; e, **V** , **C** , q) =
Assert (q); **CL** (cop arg; e, **V** , **C** (b.Return _exp_ ( **V** )), false)

**T** ([<CustomOperator("Cop")>]cop arg; e, **V** , **C** , q) =
Assert (q); **CL** (cop arg; e, **V** , **C** (b.Yield _exp_ ( **V** )), false)

**T** (ce1; ce2, **V** , **C** , q) = **C** (b.Combine({| ce 1 |}0, b.Delay(fun () -> {| ce 2 |}0)))

**T** (do! e;, **V** , **C** , q) = **T** (let! () = _src_ (e) in b.Return(), **V** , **C** , q)

**T** (e;, **V** , **C** , q) = **C** (e;b.Zero())

The following notes apply to the translations:

- The lambda expression (fun f x -> b) is represented by x.b.
- The auxiliary function _var_ (p) denotes a set of variables that are introduced by a pattern p. For
    example:
    var(x) = {x}, var((x,y)) = {x,y} or var(S (x,y)) = {x,y}
    where S is a type constructor.
-  is an update operator for a set V to denote extended variable spaces. It updates the existing
    variables. For example, {x,y}  var((x,z)) becomes {x,y,z} where the second x replaces the
    first x.
- The auxiliary function _pat_ ( **V** ) denotes a pattern tuple that represents a set of variables in **V**. For
    example, pat({x,y}) becomes (x,y), where x and y represent pattern expressions.
- The auxiliary function _exp_ ( **V** ) denotes a tuple expression that represents a set of variables in **V**.
    For example, _exp_ ({x,y}) becomes (x,y), where x and y represent variable expressions.


- The auxiliary function _src_ (e) denotes b.Source(e) if the innermost ForEach is from the user
    code instead of generated by the translation, and a builder b contains a Source method.
    Otherwise, _src_ (e) denotes e.
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

```
CL (e1, V, e2, bind) where e1: the computation expression being translated
V : a set of scoped variables
e 2 : the expression that will be translated after e 1 is
done
bind: indicator if it is for Bind (true) or iterator
(false).
```
```
The following shows translations for the uses of CL in the preceding computation expressions:
```
```
CL (cop arg, V , e’, bind) = [| cop arg, e’ |] V
CL ([<MaintainsVariableSpaceUsingBind=true>]cop arg into p; e, V , e’, bind) =
T (let! p = e’ in e, [], v.v, true)
```
```
CL (cop arg into p; e, V , e’, bind) = T (for p in e’ do e, [], v.v, true)
```
```
CL ([<MaintainsVariableSpace=true>]cop arg; e, V , e’, bind) =
CL (e, V , [| cop arg, e’ |] V , true)
CL ([<MaintainsVariableSpaceUsingBind=true>]cop arg; e, V , e’, bind) =
CL (e, V , [| cop arg, e’ |] V , true)
CL (cop arg; e, V , e’, bind) = CL (e, [], [| cop arg, e’ |] V , false)
```
```
CL (e, V , e’, true) = T (let! pat ( V ) = e’ in e, V , v.v, true)
```
```
CL (e, V , e’, false) = T (for pat ( V ) in e’ do e, V , v.v, true)
```
- The auxiliary translation [| e1, e2 |]V is defined as follows:

[|[ e1, e2 |] **V** where e1: the custom operator available in a build
e 2 : the context argument that will be passed to a custom operator
**V** : a list of bound variables

```
[|[<CustomOperator(" Cop")>] cop [<ProjectionParameter>] arg, e |] V =
```

```
b.Cop (e, fun pat ( V) - > arg)
```
```
[|[<CustomOperator("Cop")>] cop arg, e |] V = b.Cop (e, arg)
```
- The final two translation rules (for do! e; and do! e;) apply only for the final expression in the
    computation expression. The semicolon (;) can be omitted.

The following attributes specify custom operations:

- CustomOperationAttribute indicates that a member of a builder type implements a custom
    operation in a computation expression. The attribute has one parameter: the name of the
    custom operation. The operation can have the following properties:
    - MaintainsVariableSpace indicates that the custom operation maintains the variable space of
       a computation expression.
    - MaintainsVariableSpaceUsingBind indicates that the custom operation maintains the
       variable space of a computation expression through the use of a bind operation.
    - AllowIntoPattern indicates that the custom operation supports the use of ‘into’ immediately
       following the operation in a computation expression to consume the result of the operation.
    - IsLikeJoin indicates that the custom operation is similar to a join in a sequence
       computation, which supports two inputs and a correlation constraint.
    - IsLikeGroupJoin indicates that the custom operation is similar to a group join in a sequence
       computation, which support two inputs and a correlation constraint, and generates a group.
    - JoinConditionWord indicates the names used for the ‘on’ part of the custom operator for
       join-like operators.
- ProjectionParameterAttribute indicates that, when a custom operation is used in a
    computation expression, a parameter is automatically parameterized by the variable space of
    the computation expression.

The following examples show how the translation works. Assume the following simple sequence
builder:

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
member __.Yield (item:'a) : seq<'a> = seq { yield item }
```
```
let myseq = SimpleSequenceBuilder()
```
Then, the expression

```
myseq {
for i in 1 .. 10 do
yield i*i
}
```
translates to

```
let b = myseq
b.For([1..10], fun i ->
b.Yield(i*i))
```

CustomOperationAttribute allows us to define custom operations. For example, the simple sequence
builder can have a custom operator, “where”:

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
member __.Yield (item:'a) : seq<'a> = seq { yield item }
[<CustomOperation("where")>]
member __.Where (source : seq<'a>, f: 'a -> bool) : seq<'a> = Seq.filter f source
```
```
let myseq = SimpleSequenceBuilder()
```
Then, the expression

```
myseq {
for i in 1 .. 10 do
where (fun x -> x > 5)
}
```
translates to

```
let b = myseq
b.Where(
b.For([1..10], fun i ->
b.Yield (i)),
fun x -> x > 5)
```
ProjectionParameterAttribute automatically adds a parameter from the variable space of the
computation expression. For example, ProjectionParameterAttribute can be attached to the second
argument of the where operator:

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
member __.Yield (item:'a) : seq<'a> = seq { yield item }
[<CustomOperation("where")>]
member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
Seq.filter f source
```
```
let myseq = SimpleSequenceBuilder()
```
Then, the expression

```
myseq {
for i in 1 .. 10 do
where (i > 5)
}
```
translates to

```
let b = myseq
b.Where(
```

```
b.For([1..10], fun i ->
b.Yield (i)),
fun i -> i > 5)
```
ProjectionParameterAttribute is useful when a let binding appears between ForEach and the
custom operators. For example, the expression

```
myseq {
for i in 1 .. 10 do
let j = i * i
where (i > 5 && j < 49)
}
```
translates to

```
let b = myseq
b.Where(
b.For([1..10], fun i ->
let j = i * i
b.Yield (i,j)),
fun (i,j) -> i > 5 && j < 49)
```
Without ProjectionParameterAttribute, a user would be required to write “fun (i,j) ->” explicitly.

Now, assume that we want to write the condition “where (i > 5 && j < 49)” in the following
syntax:

```
where (i > 5)
where (j < 49)
```
To support this style, the where custom operator should produce a computation that has the same
variable space as the input computation. That is, j should be available in the second where. The
following example uses the MaintainsVariableSpace property on the custom operator to specify this
behavior:

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
member __.Yield (item:'a) : seq<'a> = seq { yield item }
[<CustomOperation("where", MaintainsVariableSpace=true)>]
member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
Seq.filter f source
```
```
let myseq = SimpleSequenceBuilder()
```
Then, the expression

```
myseq {
for i in 1 .. 10 do
let j = i * i
where (i > 5)
where (j < 49)
```

```
}
```
translates to

```
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
of the where operator, we can design this simple sequence builder in a slightly different way. For
example, we can express the same expression in the following way:

```
myseq {
for i in 1 .. 10 do
where (i > 5) into j
where (j*j < 49)
}
```
In this example, instead of having a let-binding (for j in the previous example) and passing variable
space (including j) down to the chain, we can introduce a special syntax that captures a value into a
pattern variable and passes only this variable down to the chain, which is arguably more readable.
For this case, AllowIntoPattern allows the custom operation to have an into syntax:

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
member __.Yield (item:'a) : seq<'a> = seq { yield item }
```
```
[<CustomOperation("where", AllowIntoPattern=true)>]
member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
Seq.filter f source
```
```
let myseq = SimpleSequenceBuilder()
```
Then, the expression

```
myseq {
for i in 1 .. 10 do
where (i > 5) into j
where (j*j < 49)
}
```
translates to

```
let b = myseq
b.Where(
b.For(
```

```
b.Where(
b.For([1..10], fun i -> b.Yield (i))
fun i -> i>5),
fun j -> b.Yield (j)),
fun j -> j*j < 49)
```
Note that the into keyword is not customizable, unlike join and on.

In addition to MaintainsVariableSpace, MaintainsVariableSpaceUsingBind is provided to pass
variable space down to the chain in a different way. For example:

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
member __.Return (item:'a) : seq<'a> = seq { yield item }
member __.Bind (value , cont) = cont value
```
```
[<CustomOperation("where", MaintainsVariableSpaceUsingBind=true,
AllowIntoPattern=true)>]
member __.Where (source: seq<'a>, [<ProjectionParameter>]f: 'a -> bool) : seq<'a> =
Seq.filter f source
```
```
let myseq = SimpleSequenceBuilder()
```
The presence of MaintainsVariableSpaceUsingBindAttribute requires Return and Bind methods
during the translation.

Then, the expression

```
myseq {
for i in 1 .. 10 do
where (i > 5 && i*i < 49) into j
return j
}
```
translates to

```
let b = myseq
b.Bind(
b.Where(B.For([1..10], fun i -> b.Return (i)),
fun i -> i > 5 && i*i < 49),
fun j -> b.Return (j))
```
where Bind is called to capture the pattern variable j. Note that For and Yield are called to capture
the pattern variable when MaintainsVariableSpace is used.

Certain properties on the CustomOperationAttribute introduce join-like operators. The following
example shows how to use the IsLikeJoin property.

```
type SimpleSequenceBuilder() =
member __.For (source : seq<'a>, body : 'a -> seq<'b>) =
seq { for v in source do yield! body v }
```

```
member __.Yield (item:'a) : seq<'a> = seq { yield item }
```
```
[<CustomOperation("merge", IsLikeJoin=true, JoinConditionWord="whenever")>]
member __.Merge (src1:seq<'a>, src2:seq<'a>, ks1, ks2, ret) =
seq { for a in src1 do
for b in src2 do
if ks1 a = ks2 b then yield((ret a ) b)
}
```
```
let myseq = SimpleSequenceBuilder()
```
IsLikeJoin indicates that the custom operation is similar to a join in a sequence computation; that
is, it supports two inputs and a correlation constraint.

The expression

```
myseq {
for i in 1 .. 10 do
merge j in [5 .. 15] whenever (i = j)
yield j
}
```
translates to

```
let b = myseq
b.For(
b.Merge([1..10], [5..15],
fun i -> i, fun j -> j,
fun i -> fun j -> (i,j)),
fun j -> b.Yield (j))
```
This translation implicitly places type constraints on the expected form of the builder methods. For
example, for the async builder found in the FSharp.Control library, the translation phase
corresponds to implementing a builder of a type that has the following member signatures:

```
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

```
/// Computations that can cooperatively yield by returning a continuation
type Eventually<'T> =
| Done of 'T
```

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
|> bind (fun res -> compensation();
match res with
| Ok v -> result v
| Exception e -> raise e)

/// The tryWith operator.
/// This is boilerplate in terms of "result", "catch" and "bind".
let tryWith e handler =
catch e
|> bind (function Ok v -> result v | Exception e -> handler e)

/// The whileLoop operator.


```
/// This is boilerplate in terms of "result" and "bind".
let rec whileLoop gd body =
if gd() then body |> bind (fun v -> whileLoop gd body)
else result ()
```
```
/// The sequential composition operator
/// This is boilerplate in terms of "result" and "bind".
let combine e1 e2 =
e1 |> bind (fun () -> e2)
```
```
/// The using operator.
let using (resource: #System.IDisposable) f =
tryFinally (f resource) (fun () -> resource.Dispose())
```
```
/// The forLoop operator.
/// This is boilerplate in terms of "catch", "result" and "bind".
let forLoop (e:seq<_>) f =
let ie = e.GetEnumerator()
tryFinally (whileLoop (fun () -> ie.MoveNext())
(delay (fun () -> let v = ie.Current in f v)))
(fun () -> ie.Dispose())
```
```
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
```
```
let eventually = new EventuallyBuilder()
```
After the computations are defined, they can be built by using eventually { ... }:

```
let comp =
eventually { for x in 1 .. 2 do
printfn " x = %d" x
return 3 + 4 }
```
These computations can now be stepped. For example:

```
let step x = Eventually.step x
comp |> step
// returns "NotYetDone <closure>"
```
```
comp |> step |> step
// prints "x = 1"
// returns "NotYetDone <closure>"
```
```
comp |> step |> step |> step |> step |> step |> step
// prints "x = 1"
// prints "x = 2"
// returns “NotYetDone <closure>”
```

```
comp |> step |> step |> step |> step |> step |> step |> step |> step
// prints "x = 1"
// prints "x = 2"
// returns "Done 7"
```
### 6.3.11 Sequence Expressions

An expression in one of the following forms is a _sequence expression_ :

```
seq { comp-expr }
seq { short-comp-expr }
```
For example:

```
seq { for x in [ 1; 2; 3 ] do for y in [5; 6] do yield x + y }
seq { for x in [ 1; 2; 3 ] do yield x + x }
seq { for x in [ 1; 2; 3 ] -> x + x }
```
Logically speaking, sequence expressions can be thought of as computation expressions with a
builder of type FSharp.Collections.SeqBuilder. This type can be considered to be defined as
follows:

```
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
However, this builder type is not actually defined in the F# library. Instead, sequence expressions are
elaborated directly as follows:

```
{| yield expr |}  Seq.singleton expr
{| yield! expr |}  expr
{| expr 1 ; expr 2 |}  Seq.append {| expr 1 |} {| expr 2 |}
{| for pat in expr 1 - > expr 2 |}  Seq.map (fun pat - > {| expr 2 |}) expr 1
{| for pat in expr 1 do expr 2 |}  Seq.collect (fun pat - > {| expr 2 |}) expr 1
{| while expr 1 do expr 2 |}  RuntimeHelpers.EnumerateWhile
(fun () - > expr 1 )
{| expr 2 |})
{| try expr 1 finally expr 2 |}  RuntimeHelpers.EnumerateThenFinally
(| expr 1 |})
(fun () - > expr 2 )
{| use v = expr 1 in expr 2 |}  let v = expr 1 in
RuntimeHelpers.EnumerateUsing v {| expr 2 |}
{| let v = expr 1 in expr 2 |}  let v = expr 1 in {| expr 2 |}
{| match expr with pati - > expri |} .match expr with pati - > {| cexpri |}
{| expr 1 |}  expr 1 ; Seq.empty
{| if expr then expr 0 |}C  if expr then {| expr 0 |}C else Seq.empty
{| if expr then expr 0 else expr 1 |}  if expr then {| expr 0 |}C else {| expr 1 |}C
```
Here the use of Seq and RuntimeHelpers refers to the corresponding functions in
FSharp.Collections.Seq and FSharp.Core.CompilerServices.RuntimeHelpers respectively. This
means that a sequence expression generates an object of type
System.Collections.Generic.IEnumerable< _ty_ > for some type _ty_. Such an object has a GetEnumerator


method that returns a System.Collections.Generic.IEnumerator< _ty_ > whose MoveNext, Current and
Dispose methods implement an on-demand evaluation of the sequence expressions.

### 6.3.12 Range Expressions

Expressions of the following forms are _range expressions_.

```
{ e1 .. e2 }
{ e1 .. e2 .. e3 }
seq { e1 .. e2 }
seq { e1 .. e2 .. e3 }
```
Range expressions generate sequences over a specified range. For example:

```
seq { 1 .. 10 } // 1; 2; 3; 4; 5; 6; 7; 8; 9; 10
seq { 1 .. 2 .. 10 } // 1; 3; 5; 7; 9
```
Range expressions involving _expr 1_ .. _expr 2_ are translated to uses of the (..) operator, and those
involving _expr 1_ .. _expr 1_ .. _expr 3_ are translated to uses of the (.. ..) operator:

```
seq { e1 .. e2 } → ( .. ) e 1 e 2
seq { e1 .. e2 .. e3 } → ( .. .. ) e 1 e 2 e 3
```
The default definition of these operators is in FSharp.Core.Operators. The ( _.._ ) operator generates
an IEnumerable<_> for the range of values between the start ( _expr 1_ ) and finish ( _expr 2_ ) values, using
an increment of 1 (as defined by FSharp.Core.LanguagePrimitives.GenericOne). The ( _.. .._ )
operator generates an IEnumerable<_> for the range of values between the start ( _expr 1_ ) and finish
( _expr 3_ ) values, using an increment of _expr 2_.

The seq keyword, which denotes the type of computation expression, can be omitted for simple
range expressions, but this is not recommended and might be deprecated in a future release. It is
always preferable to explicitly mark the type of a computation expression.

Range expressions also occur as part of the translated form of expressions, including the following:

- [ _expr_ 1 .. _expr_ 2 ]
- [| _expr_ 1 .. _expr_ 2 |]
- for _var_ in _expr_ 1 .. _expr_ 2 do _expr_ 3

A sequence iteration expression of the form for _var_ in _expr_ 1 .. _expr_ 2 do _expr_ 3 done is sometimes
elaborated as a simple for loop-expression (§6.5.7).

### 6.3.13 Lists via Sequence Expressions

A _list sequence expression_ is an expression in one of the following forms

```
[ comp-expr ]
[ short-comp-expr ]
[ range-expr ]
```
In all cases [ _cexpr_ ] elaborates to FSharp.Collections.Seq.toList(seq { _cexpr_ }).

For example:

```
let x2 = [ yield 1; yield 2 ]
```

```
let x3 = [ yield 1
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then
yield 2]
```
### 6.3.14 Arrays Sequence Expressions

An expression in one of the following forms is an _array sequence expression_ :

```
[| comp-expr |]
[| short-comp-expr |]
[| range-expr |]
```
In all cases [| _cexpr_ |] elaborates to FSharp.Collections.Seq.toArray(seq { _cexpr }_ ).

For example:

```
let x2 = [| yield 1; yield 2 |]
let x3 = [| yield 1
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then
yield 2 |]
```
### 6.3.15 Null Expressions

An expression in the form null is a _null expression_. A null expression imposes a nullness constraint
(§5.2.2, §5.4.8) on the initial type of the expression. The constraint ensures that the type directly
supports the value null.

Null expressions are a primitive elaborated form.

### 6.3.16 'printf' Formats

Format strings are strings with % markers as format placeholders. Format strings are analyzed at
compile time and annotated with static and runtime type information as a result of that analysis.
They are typically used with one of the functions printf, fprintf, sprintf, or bprintf in the
FSharp.Core.Printf module. Format strings receive special treatment in order to type check uses of
these functions more precisely.

More concretely, a constant string is interpreted as a printf-style format string if it is expected to
have the type FSharp.Core.PrintfFormat<'Printer,'State,'Residue,'Result,'Tuple>. The string is
statically analyzed to resolve the generic parameters of the PrintfFormat type, of which 'Printer
and 'Tuple are the most interesting:

- 'Printer is the function type that is generated by applying a printf-like function to the format
    string.
- 'Tuple is the type of the tuple of values that are generated by treating the string as a generator
    (for example, when the format string is used with a function similar to scanf in other
    languages).

A format placeholder has the following shape:

%[flags][width][.precision][type]

where:


_flags_

```
Are 0 , -, +, and the space character. The # flag is invalid and results in a compile-time error.
```
_width_

```
Is an integer that specifies the minimum number of characters in the result.
```
_precision_

```
Is the number of digits to the right of the decimal point for a floating-point type..
```
_type_

```
Is as shown in the following table.
Placeholder string Type
%b bool
%s string
%c char
%d, %i One of the basic integer types:
byte, sbyte, int16, uint16, int32, uint32, int64, uint64, nativeint, or
unativeint
%u Basic integer type formatted as an unsigned integer
%x Basic integer type formatted as an unsigned hexadecimal integer with lowercase
letters a through f.
```
%X (^) Basic integer type formatted as an unsigned hexadecimal integer with uppercase
letters A through F.
%o Basic integer type formatted as an unsigned octal integer.
%e, %E, %f, %F, %g, %G float or float32
%M System.Decimal
%O System.Object
%A Fresh variable type 'T
%a Formatter of type 'State -> 'T -> 'Residue for a fresh variable type 'T
%t Formatter of type 'State -> 'Residue
For example, the format string "%s %d %s" is given the type PrintfFormat<(string -> int -> string

- > 'd), 'b, 'c, 'd,(string * int * string)> for fresh variable types 'b, 'c, 'd. Applying printf
to it yields a function of type string -> int -> string -> unit.

## 6.4 APPLICATION EXPRESSIONS

### 6.4.1 Basic Application Expressions

Application expressions involve variable names, dot-notation lookups, function applications, method
applications, type applications, and item lookups, as shown in the following table.

**Expression Description**

_long-ident-or-op_ (^) Long-ident lookup expression
_expr_ '.' _long-ident-or-op_ (^) Dot lookup expression
_expr expr_ (^) Function or member application expression


**Expression Description**

_expr(expr)_ (^) High precedence function or member application
expression
_expr_ < _types_ > (^) Type application expression
_expr_ < > (^) Type application expression with an empty type list
_type expr_ (^) Simple object expression
The following are examples of application expressions:
System.Math.PI
System.Math.PI.ToString()
(3 + 4).ToString()
System.Environment.GetEnvironmentVariable("PATH").Length
System.Console.WriteLine("Hello World")
Application expressions may start with object construction expressions that do not include the new
keyword:
System.Object()
System.Collections.Generic.List<int>(10)
System.Collections.Generic.KeyValuePair(3,"Three")
System.Object().GetType()
System.Collections.Generic.Dictionary<int,int>(10).[1]
If the _long-ident-or-op_ starts with the special pseudo-identifier keyword global, F# resolves the
identifier with respect to the global namespace—that is, ignoring all open directives (see §14.2). For
example:
global.System.Math.PI
is resolved to System.Math.PI ignoring all open directives.
The checking of application expressions is described in detail as an algorithm in §14.2. To check an
application expression, the expression form is repeatedly decomposed into a _lead_ expression _expr_
and a list of projections projs through the use of _Unqualified Lookup_ (§14.2.1). This in turn uses
procedures such as _Expression-Qualified Lookup_ and _Method Application Resolution_.
As described in §14.2, checking an application expression results in an elaborated expression that
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

```
For example, System.Environment.GetEnvironmentVariable elaborates to:
(fun v -> System.Environment.GetEnvironmentVariable(v))
for some fresh variable v.
```
- The use of post-hoc property setters results in the insertion of additional assignment and
    sequential execution expressions in the elaborated expression.
    For example, new System.Windows.Forms.Form(Text="Text") elaborates to
    let v = new System.Windows.Forms.Form() in v.set_Text("Text"); v
    for some fresh variable v.
- The use of optional arguments results in the insertion of Some(_) and None data constructions in
    the elaborated expression.

For uses of active pattern results (see §10.2.4), for result _i_ in an active pattern that has _N_ possible
results of types _types_ , the elaborated expression form is a union case Choice _N_ Of _i_ of type
FSharp.Core.Choice< _types_ >.

### 6.4.2 Object Construction Expressions

An expression of the following form is an _object construction expression_ :

```
new ty ( e 1 ... en )
```
An object construction expression constructs a new instance of a type, usually by calling a
constructor method on the type. For example:

```
new System.Object()
new System.Collections.Generic.List<int>()
new System.Windows.Forms.Form (Text="Hello World")
new 'T()
```
The initial type of the expression is first asserted to be equal to _ty_. The type ty must not be an array,
record, union or tuple type. If ty is a named class or struct type:

- _ty_ must not be abstract.
- If _ty_ is a struct type, _n_ is 0 , and _ty_ does not have a constructor method that takes zero
    arguments, the expression elaborates to the default “zero-bit pattern” value for _ty_.
- Otherwise, the type must have one or more accessible constructors. The overloading between
    these potential constructors is resolved and elaborated by using _Method Application Resolution_
    (see §14.4).

If _ty_ is a delegate type the expression is a _delegate implementation expression_.

- If the delegate type has an Invoke method that has the following signature
    Invoke( _ty 1_ ,..., _tyn_ ) -> _rtyA_ ,
    then the overall expression must be in this form:

```
new ty ( expr ) where expr has type ty 1 - > ... -> tyn - > rtyB
```
```
If type rtyA is a CLI void type, then rtyB is unit, otherwise it is rtyA.
```

- If any of the types _tyi_ is a byref-type then an explicit function expression must be specified. That
    is, the overall expression must be of the form new _ty_ (fun _pat1 ... patn_ - > _exprbody_ ).

If _ty_ is a type variable:

- There must be no arguments (that is, n = 0).
- The type variable is constrained as follows:

```
ty : (new : unit -> ty ) -- CLI default constructor constraint
```
- The expression elaborates to a call to
    FSharp.Core.LanguagePrimitives.IntrinsicFunctions.CreateInstance< _ty_ >(), which in turn calls
    System.Activator.CreateInstance< _ty_ >(), which in turn uses CLI reflection to find and call the
    null object constructor method for type _ty_. On return from this function, any exceptions are
    wrapped by using System.TargetInvocationException.

### 6.4.3 Operator Expressions

Operator expressions are specified in terms of their shallow syntactic translation to other constructs.
The following translations are applied in order:

```
infix-or-prefix-op e1 → (~ infix-or-prefix-op ) e1
prefix-op e1 → ( prefix-op ) e1
e1 infix-op e2 → ( infix-op ) e1 e2
```
```
Note: When an operator that may be used as either an infix or prefix operator is used in
prefix position, a tilde character ~ is added to the name of the operator during the
translation process.
```
These rules are applied after applying the rules for dynamic operators (§6.4.4).

The parenthesized operator name is then treated as an identifier and the standard rules for
unqualified name resolution (§14.1) in expressions are applied. The expression may resolve to a
specific definition of a user-defined or library-defined operator. For example:

```
let (+++) a b = (a,b)
3 +++ 4
```
In some cases, the operator name resolves to a standard definition of an operator from the F#
library. For example, in the absence of an explicit definition of (+),

```
3 + 4
```
resolves to a use of the infix operator FSharp.Core.Operators.(+).

Some operators that are defined in the F# library receive special treatment in this specification. In
particular:

- The & _expr_ and && _expr_ address-of operators (§6.4.5)
- The _expr_ && _expr_ and _expr_ || _expr_ shortcut control flow operators (§6.5.4)
- The % _expr_ and %% _expr_ expression splice operators in quotations (§6.8.3)
- The library-defined operators, such as +, -, *, /, %, **, <<<, >>>, &&&, |||, and ^^^ (§18.2).


If the operator does not resolve to a user-defined or library-defined operator, the name resolution
rules (§14.1) ensure that the operator resolves to an expression that implicitly uses a static member
invocation expression (§ 0 ) that involves the types of the operands. This means that the effective
behavior of an operator that is not defined in the F# library is to require a static member that has the
same name as the operator, on the type of one of the operands of the operator. In the following
code, the otherwise undefined operator --> resolves to the static member on the Receiver type,
based on a type-directed resolution:

```
type Receiver(latestMessage:string) =
static member (<--) (receiver:Receiver,message:string) =
Receiver(message)
```
```
static member (-->) (message,receiver:Receiver) =
Receiver(message)
```
```
let r = Receiver "no message"
```
```
r <-- "Message One"
```
```
"Message Two" --> r
```
### 6.4.4 Dynamic Operator Expressions

Expressions of the following forms are _dynamic operator expressions:_

```
expr 1? expr 2
expr 1? expr 2 <- expr 3
```
These expressions are defined by their syntactic translation:

```
expr? ident → (?) expr " ident "
expr 1? ( expr 2 ) → (?) expr 1 expr 2
expr 1? ident <- expr 2 → (?<-) expr 1 " ident " expr 2
expr 1? ( expr 2 ) <- expr 3 → (?<-) expr 1 expr 2 expr 3
```
Here " _ident_ " is a string literal that contains the text of _ident_.

```
Note: The F# core library FSharp.Core.dll does not define the (?) and (?<-) operators.
However, user code may define these operators. For example, it is common to define
the operators to perform a dynamic lookup on the properties of an object by using
reflection.
```
This syntactic translation applies regardless of the definition of the (?) and (?<-) operators.
However, it does not apply to uses of the parenthesized operator names, as in the following:

```
(?) x y
```
### 6.4.5 The AddressOf Operators

Under default definitions, expressions of the following forms are _address-of expressions,_ called
_byref-address-of expression_ and _nativeptr-address-of expression,_ respectively:

```
& expr
&& expr
```

Such expressions take the address of a mutable local variable, byref-valued argument, field, array
element, or static mutable global variable.

For & _expr_ and && _expr_ , the initial type of the overall expression must be of the form byref< _ty_ > and
nativeptr< _ty_ > respectively, and the expression _expr_ is checked with initial type _ty_.

The overall expression is elaborated recursively by taking the address of the elaborated form of _expr_ ,
written _AddressOf_ ( _expr_ , DefinitelyMutates), defined in §6.9.4.

Use of these operators may result in unverifiable or invalid common intermediate language (CIL)
code; when possible, a warning or error is generated. In general, their use is recommended only:

- To pass addresses where byref or nativeptr parameters are expected.
- To pass a byref parameter on to a subsequent function.
- When required to interoperate with native code.

Addresses that are generated by the && operator must not be passed to functions that are in tail call
position. The F# compiler does not check for this.

Direct uses of byref types, nativeptr types, or values in the FSharp.NativeInterop module may
result in invalid or unverifiable CIL code. In particular, byref and nativeptr types may NOT be used
within named types such as tuples or function types.

When calling an existing CLI signature that uses a CLI pointer type _ty*_ , use a value of type
nativeptr<ty>.

```
Note: The rules in this section apply to the following prefix operators, which are defined
in the F# core library for use with one argument.
FSharp.Core.LanguagePrimitives.IntrinsicOperators.(~&)
FSharp.Core.LanguagePrimitives.IntrinsicOperators.(~&&)
```
```
Other uses of these operators are not permitted.
```
### 6.4.6 Lookup Expressions

Lookup expressions are specified by syntactic translation:

```
e 1 .[ eargs ] → e 1 .get_Item( eargs )
e 1 .[ eargs ] <- e 3 → e 1 .set_Item( eargs , e 3 )
```
In addition, for the purposes of resolving expressions of this form, array types of rank 1, 2, 3, and 4
are assumed to support a type extension that defines an Item property that has the following
signatures:

```
type 'T[] with
member arr.Item : int -> 'T
type 'T[,] with
member arr.Item : int * int -> 'T
type 'T[,,] with
member arr.Item : int * int * int -> 'T
```

```
type 'T[,,,] with
member arr.Item : int * int * int * int -> 'T
```
In addition, if type checking determines that the type of _e 1_ is a named type that supports the
DefaultMember attribute, then the member name identified by the DefaultMember attribute is used
instead of Item.

### 6.4.7 Slice Expressions

Slice expressions are defined by syntactic translation:

```
e1.[sliceArg1, ,,, sliceArgN] → e1.GetSlice( args1,...,argsN)
e1.[sliceArg1, ,,, sliceArgN] <- expr → e1.SetSlice( args1,...,argsN, expr)
```
where each sliceArgN is one of the following and translated to argsN (giving one or two args) as
indicated

```
* → None, None
e1.. → Some e1, None
..e2 → None, Some e2
e1..e2 → Some e1, Some e2
idx → idx
```
Because this is a shallow syntactic translation, the GetSlice and SetSlice name may be resolved by
any of the relevant _Name Resolution_ (§14.1) techniques, including defining the method as a type
extension for an existing type.

For example, if a matrix type has the appropriate overloads of the GetSlice method (see below), it is
possible to do the following:

```
matrix.[1..,*] -- get rows 1.. from a matrix (returning a matrix)
matrix.[1..3,*] -- get rows 1..3 from a matrix (returning a matrix)
matrix.[*,1..3] -- get columns 1..3from a matrix (returning a matrix)
matrix.[1..3,1,.3] -- get a 3x3 sub-matrix (returning a matrix)
matrix.[3,*] -- get row 3 from a matrix as a vector
matrix.[*,3] -- get column 3 from a matrix as a vector
```
In addition, CIL array types of rank 1 to 4 are assumed to support a type extension that defines a
method GetSlice that has the following signature:

```
type 'T[] with
member arr.GetSlice : ?start1:int * ?end1:int -> 'T[]
type 'T[,] with
member arr.GetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int -> 'T[,]
member arr.GetSlice : idx1:int * ?start2:int * ?end2:int -> 'T[]
member arr.GetSlice : ?start1:int * ?end1:int * idx2:int - > 'T[]
type 'T[,,] with
member arr.GetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
?start3:int * ?end3:int
```
- > 'T[,,]
type 'T[,,,] with
member arr.GetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
?start3:int * ?end3:int * ?start4:int * ?end4:int


- > 'T[,,,]

In addition, CIL array types of rank 1 to 4 are assumed to support a type extension that defines a
method SetSlice that has the following signature:

```
type 'T[] with
member arr.SetSlice : ?start1:int * ?end1:int * values:T[] -> unit
type 'T[,] with
member arr.SetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
values:T[,] -> unit
member arr.SetSlice : idx1:int * ?start2:int * ?end2:int * values:T[] -> unit
member arr.SetSlice : ?start1:int * ?end1:int * idx2:int * values:T[] -> unit
type 'T[,,] with
member arr.SetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
?start3:int * ?end3:int * values:T[,,] -> unit
type 'T[,,,] with
member arr.SetSlice : ?start1:int * ?end1:int * ?start2:int * ?end2:int *
?start3:int * ?end3:int * ?start4:int * ?end4:int *
values:T[,,,] -> unit
```
### 6.4. 8 Member Constraint Invocation Expressions

An expression of the following form is a member constraint invocation expression:

```
( static-typars : ( member-sig ) expr )
```
Type checking proceeds as follows:

1. The expression is checked with initial type _ty_.
2. A statically resolved member constraint is applied (§5.2.3):
    _static-typars_ : ( _member-sig_ )
3. _ty_ is asserted to be equal to the return type of the constraint.
4. _expr_ is checked with an initial type that corresponds to the argument types of the constraint.

The elaborated form of the expression is a member invocation. For example:

```
let inline speak (a: ^a) =
let x = (^a : (member Speak: unit -> string) (a))
printfn "It said: %s" x
let y = (^a : (member MakeNoise: unit -> string) (a))
printfn "Then it went: %s" y
```
```
type Duck() =
member x.Speak() = "I'm a duck"
member x.MakeNoise() = "quack"
type Dog() =
member x.Speak() = "I'm a dog"
member x.MakeNoise() = "grrrr"
```
```
let x = new Duck()
let y = new Dog()
speak x
speak y
```

Outputs:

```
It said: I'm a duck
Then it went: quack
It said: I'm a dog
Then it went: grrrr
```
### 6.4.9 Assignment Expressions

An expression of the following form is an _assignment expression_ :

```
expr 1 <- expr 2
```
A modified version of _Unqualified Lookup_ (§14.2.1) is applied to the expression _expr_ 1 using a fresh
expected result type _ty_ , thus producing an elaborate expression _expr_ 1. The last qualification for _expr_ 1
must resolve to one of the following constructs:

- An invocation of a property with a setter method. The property may be an indexer.

```
Type checking incorporates expr 2 as the last argument in the method application resolution for
the setter method. The overall elaborated expression is a method call to this setter property and
includes the last argument.
```
- A mutable value _path_ of type _ty_.

```
Type checking of expr 2 uses the expected result type ty and generates an elaborated expression
expr 2. The overall elaborated expression is an assignment to a value reference &path <- stobj
expr 2.
```
- A reference to a value _path_ of type byref< _ty_ >.

```
Type checking of expr 2 uses the expected result type ty and generates an elaborated expression
expr 2. The overall elaborated expression is an assignment to a value reference path <- stobj expr 2.
```
- A reference to a mutable field _expr_ 1a. _field_ with the actual result type _ty_.

```
Type checking of expr 2 uses the expected result type ty and generatesan elaborated expression
expr 2. The overall elaborated expression is an assignment to a field (see §6.9.4):
```
```
AddressOf ( expr 1a. field , DefinitelyMutates) <- stobj expr 2
```
- A array lookup _expr_ 1a.[ _expr_ 1b] where _expr_ 1a has type _ty_ [].

```
Type checking of expr 2 uses the expected result type ty and generates thean elaborated
expression expr 2. The overall elaborated expression is an assignment to a field (see §6.9.4):
```
```
AddressOf ( expr 1a.[ expr 1b] , DefinitelyMutates) <- stobj expr 2
```
```
Note: Because assignments have the preceding interpretations, local values must be
mutable so that primitive field assignments and array lookups can mutate their
immediate contents. In this context, “immediate” contents means the contents of a
mutable value type. For example, given
```

```
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
```
Then these are not permitted:
s1.x <- 3
s3.sa.x <- 3
```
```
and these are:
s2.x <- 3
s4.sa.x <- 3
s4.sa <- SA(2)
```
## 6.5 CONTROL FLOW EXPRESSIONS

### 6.5.1 Parenthesized and Block Expressions

A _parenthesized expression_ has the following form:

```
( expr )
```
A _block expression_ has the following form:

```
begin expr end
```
The expression _expr_ is checked with the same initial type as the overall expression.

The elaborated form of the expression is simply the elaborated form of _expr_.

### 6.5.2 Sequential Execution Expressions

A _sequential execution expression_ has the following form:

```
expr 1 ; expr 2
```
For example:

```
printfn "Hello"; printfn "World"; 3
```
The ; token is optional when both of the following are true:

- The expression _expr_ 2 occurs on a subsequent line that starts in the same column as _expr_ 1.


- The current pre-parse context that results from the syntax analysis of the program text is a
    **SeqBlock** (§ 15 ).

When the semicolon is optional, parsing inserts a $sep token automatically and applies an additional
syntax rule for lightweight syntax (§15.1.1). In practice, this means that code can omit the ; token
for sequential execution expressions that implement functions or immediately follow tokens such as
begin and (.

The expression _expr_ 1 is checked with an arbitrary initial type _ty_. After checking _expr_ 1 , _ty_ is asserted
to be equal to unit. If the assertion fails, a warning rather than an error is reported. The expression
_expr_ 2 is then checked with the same initial type as the overall expression.

Sequential execution expressions are a primitive elaborated form.

### 6.5.3 Conditional Expressions

A _conditional expression_ has the following form:s

```
if expr 1 a then expr 1b
elif expr 3a then expr 2b
```
```
elif expr na then expr nb
else expr last
```
The _elif_ and _else_ branches may be omitted. For example:

```
if (1 + 1 = 2) then "ok" else "not ok"
if (1 + 1 = 2) then printfn "ok"
```
Conditional expressions are equivalent to pattern matching on Boolean values. For example, the
following expression forms are equivalent:

```
if expr 1 then expr 2 else expr 3
match ( expr 1 :bool) with true -> expr 2 | false -> expr 3
```
If the _else_ branch is omitted, the expression is a _sequential conditional expression_ and is equivalent
to:

```
match ( expr 1 :bool) with true -> expr 2 | false -> ()
```
with the exception that the initial type of the overall expression is first asserted to be unit.

### 6.5.4 Shortcut Operator Expressions

Under default definitions, expressions of the following form are respectively an _shortcut and
expression_ and a _shortcut or expression_ :

```
expr && expr
expr || expr
```
These expressions are defined by their syntactic translation:

```
expr 1 && expr 2 → if expr 1 then expr 2 else false
expr 1 || expr 2 → if expr 1 then true else expr 2
```

```
Note: The rules in this section apply when the following operators, as defined in the F#
core library, are applied to two arguments.
FSharp.Core.LanguagePrimitives.IntrinsicOperators.(&&)
FSharp.Core.LanguagePrimitives.IntrinsicOperators.(||)
```
```
If the operator is not immediately applied to two arguments, it is interpreted as a strict
function that evaluates both its arguments before use.
```
### 6.5.5 Pattern-Matching Expressions and Functions

A _pattern-matching expression_ has the following form:

```
match expr with rules
```
Pattern matching is used to evaluate the given expression and select a rule (§ 7 ). For example:

```
match (3, 2) with
| 1, j -> printfn "j = %d" j
| i, 2 - > printfn "i = %d" i
| _ - > printfn "no match"
```
A _pattern-matching function_ is an expression of the following form:

```
function rules
```
A pattern-matching function is syntactic sugar for a single-argument function expression that is
followed by immediate matches on the argument. For example:

```
function
| 1, j -> printfn "j = %d" j
| _ - > printfn "no match"
```
is syntactic sugar for the following, where x is a fresh variable:

```
fun x ->
match x with
| 1, j -> printfn "j = %d" j
| _ - > printfn "no match"
```
### 6.5.6 Sequence Iteration Expressions

An expression of the following form is a _sequence iteration expression_ :

```
for pat in expr 1 do expr 2 done
```
The done token is optional if _expr_ 2 appears on a later line and is indented from the column position
of the for token. In this case, parsing inserts a $done token automatically and applies an additional
syntax rule for lightweight syntax (§15.1.1).

For example:

```
for x, y in [(1, 2); (3, 4)] do
printfn "x = %d, y = %d" x y
```

The expression _expr_ 1 is checked with a fresh initial type _ty_ expr, which is then asserted to be a subtype
of type IEnumerable< _ty_ >, for a fresh type _ty_. If the assertion succeeds, the expression elaborates to
the following, where _v_ is of type IEnumerator< _ty_ > and _pat_ is a pattern of type _ty_ :

```
let v = expr 1 .GetEnumerator()
try
while ( v .MoveNext()) do
match v .Current with
| pat - > expr 2
| _ -> ()
finally
match box( v ) with
| :? System.IDisposable as d - > d .Dispose()
| _ -> ()
```
If the assertion fails, the type _ty_ expr may also be of any static type that satisfies the “collection
pattern” of CLI libraries. If so, the _enumerable extraction_ process is used to enumerate the type. In
particular, _ty_ expr may be any type that has an accessible GetEnumerator method that accepts zero
arguments and returns a value that has accessible MoveNext and Current properties. The type of _pat_
is the same as the return type of the Current property on the enumerator value. However, if the
Current property has return type obj and the collection type _ty_ has an Item property with a more
specific (non-object) return type _ty 2_ , type _ty 2_ is used instead, and a dynamic cast is inserted to
convert v.Current to _ty 2_.

A sequence iteration of the form

```
for var in expr 1 .. expr 2 do expr 3 done
```
where the type of _expr_ 1 or _expr_ 2 is equivalent to int, is elaborated as a simple for-loop expression
(§6.5.7)

### 6.5.7 Simple for-Loop Expressions

An expression of the following form is a _simple for loop expression_ :

```
for var = expr 1 to expr 2 do expr 3 done
```
The done token is optional when e2 appears on a later line and is indented from the column position
of the for token. In this case, a $done token is automatically inserted, and an additional syntax rule
for lightweight syntax applies (§15.1.1). For example:

```
for x = 1 to 30 do
printfn "x = %d, x^2 = %d" x (x*x)
```
The bounds _expr_ 1 and _expr_ 2 are checked with initial type int. The overall type of the expression is
unit. A warning is reported if the body _expr_ 3 of the for loop does not have static type unit.

The following shows the elaborated form of a simple for-loop expression for fresh variables start
and finish:

```
let start = expr 1 in
let finish = expr 2 in
for var = start to finish do expr 3 done
```

For-loops over ranges that are specified by variables are a primitive elaborated form. When
executed, the iterated range includes both the starting and ending values in the range, with an
increment of 1.

An expression of the form

```
for var in expr 1 .. expr 2 do expr 3 done
```
is always elaborated as a simple for-loop expression whenever the type of _expr_ 1 or _expr_ 2 is
equivalent to int.

### 6.5.8 While Expressions

A _while loop expression_ has the following form:

```
while expr 1 do expr 2 done
```
The done token is optional when _expr_ 2 appears on a subsequent line and is indented from the
column position of the while. In this case, a $done token is automatically inserted, and an additional
syntax rule for lightweight syntax applies (§15.1.1).

For example:

```
while System.DateTime.Today.DayOfWeek = System.DayOfWeek.Monday do
printfn "I don't like Mondays"
```
The overall type of the expression is unit. The expression _expr_ 1 is checked with initial type bool. A
warning is reported if the body _expr_ 2 of the while loop cannot be asserted to have type unit.

### 6.5. 9 Try-with Expressions

A _try-with expression_ has the following form:

```
try expr with rules
```
For example:

```
try "1" with _ -> "2"
```
```
try
failwith "fail"
with
| Failure msg -> "caught"
| :? System.InvalidOperationException -> "unexpected"
```
Expression _expr_ is checked with the same initial type as the overall expression. The pattern matching
clauses are then checked with the same initial type and with input type System.Exception.

Try-with expressions are a primitive elaborated form.

### 6.5.10 Reraise Expressions

A _reraise expression_ is an application of the reraise F# library function. This function must be
applied to an argument and can be used only on the immediate right-hand side of _rules_ in a try-with
expression.


```
try
failwith "fail"
with e -> printfn "Failing"; reraise()
```
```
Note: The rules in this section apply to any use of the function
FSharp.Core.Operators.reraise, which is defined in the F# core library.
```
When executed, reraise() continues exception processing with the original exception information.

### 6.5.11 Try-finally Expressions

A _try-finally expression_ has the following form:

```
try expr 1 finally expr 2
```
For example:

```
try "1" finally printfn "Finally!"
```
```
try
failwith "fail"
finally
printfn "Finally block"
```
Expression _expr_ 1 is checked with the initial type of the overall expression. Expression _expr_ 2 is
checked with arbitrary initial type, and a warning occurs if this type cannot then be asserted to be
equal to unit.

Try-finally expressions are a primitive elaborated form.

### 6.5.12 Assertion Expressions

An _assertion expression_ has the following form:

```
assert expr
```
The expression assert _expr_ is syntactic sugar for System.Diagnostics.Debug.Assert(expr)

```
Note: System.Diagnostics.Debug.Assert is a conditional method call. This means that
assertions are triggered only if the DEBUG conditional compilation symbol is defined.
```
## 6.6 DEFINITION EXPRESSIONS

A _definition expression_ has one of the following forms:

```
let function-defn in expr
let value-defn in expr
let rec function-or-value-defns in expr
use ident = expr 1 in expr
```
Such an expression establishes a local function or value definition within the lexical scope of _expr_
and has the same overall type as _expr_.


In each case, the in token is optional if _expr_ appears on a subsequent line and is aligned with the
token let. In this case, a $in token is automatically inserted, and an additional syntax rule for
lightweight syntax applies (§15.1.1)

For example:

```
let x = 1
x + x
```
and

```
let x, y = ("One", 1)
x.Length + y
```
and

```
let id x = x in (id 3, id "Three")
```
and

```
let swap (x, y) = (y,x)
List.map swap [ (1, 2); (3, 4) ]
```
and

```
let K x y = x in List.map (K 3) [ 1; 2; 3; 4 ]
```
Function and value definitions in expressions are similar to function and value definitions in class
definitions (§8.6.1.3), modules (§ 1 0.2.1), and computation expressions (§6.3.10), with the following
exceptions:

- Function and value definitions in expressions may not define explicit generic parameters (§5.3).
    For example, the following expression is rejected:
       let f<'T> (x:'T) = x in f 3
- Function and value definitions in expressions are not public and are not subject to arity analysis
    (§14.10).
- Any custom attributes that are specified on the declaration, parameters, and/or return
    arguments are ignored and result in a warning. As a result, function and value definitions in
    expressions may not have the ThreadStatic or ContextStatic attribute.

### 6.6.1 Value Definition Expressions

A value definition expression has the following form:

```
let value-defn in expr
```
where _value-defn_ has the form:

```
mutableopt accessopt pat typar-defnsopt return-typeopt = rhs-expr
```
Checking proceeds as follows:

1. Check the _value-defn_ (§14.6), which defines a group of identifiers _identj_ with inferred types _tyj_


2. Add the identifiers _identj_ to the name resolution environment, each with corresponding type
    _tyj_.
3. Check the body _expr_ against the initial type of the overall expression.

In this case, the following rules apply:

- If _pat_ is a single value pattern _ident_ , the resulting elaborated form of the entire expression is

```
let ident 1 < typars1 > = expr 1 in
body-expr
```
```
where ident 1 , typars 1 and expr 1 are defined in §14.6.
```
- Otherwise, the resulting elaborated form of the entire expression is

```
let tmp < typars 1 ... typars n> = expr in
let ident 1 < typars 1 > = expr 1 in
```
```
let identn < typars n> = exprn in
body-expr
```
```
where tmp is a fresh identifier and identi , typarsi , and expri all result from the compilation of
the pattern pat (§ 7 ) against the input tmp.
```
Value definitions in expressions may be marked as mutable. For example:

```
let mutable v = 0
while v < 10 do
v <- v + 1
printfn "v = %d" v
```
Such variables are implicitly dereferenced each time they are used.

### 6.6.2 Function Definition Expressions.......................................................................................

A function definition expression has the form:

```
let function-defn in expr
```
where _function-defn_ has the form:

```
inline opt accessopt ident-or-op typar-defnsopt pat 1 ... patn return-typeopt = rhs-expr
```
Checking proceeds as follows:

1. Check the _function-defn_ (§14.6), which defines _ident 1_ , _ty 1_ , _typars 1_ and _expr 1_
2. Add the identifier _ident 1_ to the name resolution environment, each with corresponding type _ty 1_.
3. Check the body _expr_ against the initial type of the overall expression.

The resulting elaborated form of the entire expression is

```
let ident 1 < typars 1 > = expr 1 in
expr
```
where _ident 1_ , _typars 1_ and _expr 1_ are as defined in §14.6.


### 6.6.3 Recursive Definition Expressions

An expression of the following form is a _recursive definition expression_ :

```
let rec function-or-value-defns in expr
```
The defined functions and values are available for use within their own definitions—that is can be
used within any of the expressions on the right-hand side of _function-or-value-defns_. Multiple
functions or values may be defined by using let rec ... and .... For example:

```
let test() =
let rec twoForward count =
printfn "at %d, taking two steps forward" count
if count = 1000 then "got there!"
else oneBack (count + 2)
and oneBack count =
printfn "at %d, taking one step back " count
twoForward (count - 1)
```
```
twoForward 1
```
```
test()
```
In the example, the expression defines a set of recursive functions. If one or more recursive values
are defined, the recursive expressions are analyzed for safety (§14.6.6). This may result in warnings
(including some reported as compile-time errors) and runtime checks.

### 6.6.4 Deterministic Disposal Expressions

A _deterministic disposal expression_ has the form:

```
use ident = expr 1 in expr 2
```
For example:

```
use inStream = System.IO.File.OpenText "input.txt"
let line1 = inStream.ReadLine()
let line2 = inStream.ReadLine()
(line1,line2)
```
The expression is first checked as an expression of form let _ident_ = _expr 1_ in _expr 2_ (§ **Error! R
eference source not found.** ), which results in an elaborated expression of the following form:

```
let ident 1 : ty 1 = expr 1 in expr 2.
```
Only one value may be defined by a deterministic disposal expression, and the definition is not
generalized (§14.6.7). The type _ty 1_ , is then asserted to be a subtype of System.IDisposable. If the
dynamic value of the expression after coercion to type obj is non-null, the Dispose method is called
on the value when the value goes out of scope. Thus the overall expression elaborates to this:

```
let ident 1 : ty 1 = expr 1
try expr 2
finally (match ( ident :> obj) with
| null -> ()
| _ -> ( ident :> System.IDisposable).Dispose())
```

## 6.7 TYPE-RELATED EXPRESSIONS

### 6.7.1 Type-Annotated Expressions

A _type-annotated expression_ has the following form, where _ty_ indicates the static type of _expr_ :

```
expr : ty
```
For example:

```
(1 : int)
let f x = (x : string) + x
```
When checked, the initial type of the overall expression is asserted to be equal to _ty_. Expression _expr_
is then checked with initial type _ty_. The expression elaborates to the elaborated form of _expr_. This
ensures that information from the annotation is used during the analysis of expr itself.

### 6.7.2 Static Coercion Expressions

A _static coercion expression_ —also called a flexible type constraint—has the following form:

```
expr :> ty
```
The expression upcast _expr_ is equivalent to _expr_ :> ___ , so the target type is the same as the initial
type of the overall expression. For example:

```
(1 :> obj)
("Hello" :> obj)
([1;2;3] :> seq<int>).GetEnumerator()
(upcast 1 : obj)
```
The initial type of the overall expression is _ty_. Expression _expr_ is checked using a fresh initial type
_tye_ , with constraint _tye_ :> _ty_. Static coercions are a primitive elaborated form.

### 6.7.3 Dynamic Type-Test Expressions

A dynamic type-test expression has the following form:

```
expr :? ty
```
For example:

```
((1 :> obj) :? int)
((1 :> obj) :? string)
```
The initial type of the overall expression is _bool_. Expression _expr_ is checked using a fresh initial type
_tye_. After checking:

- The type _tye_ must not be a variable type.
- A warning is given if the type test will always be true and therefore is unnecessary.
- The type _tye_ must not be sealed.
- If type _ty_ is sealed, or if _ty_ is a variable type, or if type _tye_ is not an interface type, then _ty :> tye_
    is asserted.


Dynamic type tests are a primitive elaborated form.

### 6.7.4 Dynamic Coercion Expressions

A dynamic coercion expression has the following form:

```
expr :?> ty
```
The expression downcast _e1_ is equivalent to _expr_ :?> ___ , so the target type is the same as the initial
type of the overall expression. For example:

```
let obj1 = (1 :> obj)
(obj1 :?> int)
(obj1 :?> string)
(downcast obj1 : int)
```
The initial type of the overall expression is _ty_. Expression _expr_ is checked using a fresh initial type
_tye_. After these checks:

- The type _tye_ must not be a variable type.
- A warning is given if the type test will always be true and therefore is unnecessary.
- The type _tye_ must not be sealed.
- If type _ty_ is sealed, or if _ty_ is a variable type, or if type _tye_ is not an interface type, then _ty :> tye_
    is asserted.

Dynamic coercions are a primitive elaborated form.

## 6.8 QUOTED EXPRESSIONS

An expression in one of these forms is a quoted expression:

<@ _expr_ @>

<@@ _expr_ @@>

The former is a _strongly typed quoted expression_ , and the latter is a _weakly typed quoted expression_.
In both cases, the expression forms capture the enclosed expression in the form of a typed abstract
syntax tree.

The exact nodes that appear in the expression tree are determined by the elaborated form of _expr_
that type checking produces.

For details about the nodes that may be encountered, see the documentation for the
FSharp.Quotations.Expr type in the F# core library. In particular, quotations may contain:

- References to module-bound functions and values, and to type-bound members. For example:

```
let id x = x
let f (x : int) = <@ id 1 @>
```
```
In this case the value appears in the expression tree as a node of kind
FSharp.Quotations.Expr.Call.
```

- A type, module, function, value, or member that is annotated with the ReflectedDefinition
    attribute. If so, the expression tree that forms its definition may be retrieved dynamically using
    the FSharp.Quotations.Expr.TryGetReflectedDefinition.
    If the ReflectedDefinition attribute is applied to a type or module, it will be recursively applied
    to all members, too.
- References to defined values, such as the following:

```
let f (x : int) = <@ x + 1 @>
```
```
Such a value appears in the expression tree as a node of kind FSharp.Quotations.Expr.Value.
```
- References to generic type parameters or uses of constructs whose type involves a generic
    parameter, such as the following:
       let f (x:'T) = <@ (x, x) : 'T * 'T @>

```
In this case, the actual value of the type parameter is implicitly substituted throughout the type
annotations and types in the generated expression tree.
```
As of F# 3. 1 , the following limitations apply to quoted expressions:

- Quotations may not use object expressions.
- Quotations may not define expression-bound functions that are themselves inferred to be
    generic. Instead, expression-bound functions should either include type annotations to refer to a
    specific type or should be written by using module-bound functions or class-bound members.

### 6.8.1 Strongly Typed Quoted Expressions

A strongly typed quoted expression has the following form:

```
<@ expr @>
```
For example:

```
<@ 1 + 1 @>
```
```
<@ (fun x -> x + 1) @>
```
In the first example, the type of the expression is FSharp.Quotations.Expr<int>. In the second
example, the type of the expression is FSharp.Quotations.Expr<int -> int>.

When checked, the initial type of a strongly typed quoted expression <@ _expr_ @> is asserted to be of
the form FSharp.Quotations.Expr< _ty_ > for a fresh type _ty_. The expression _expr_ is checked with initial
type _ty_.

### 6.8.2 Weakly Typed Quoted Expressions

A _weakly typed quoted expression_ has the following form:

```
<@@ expr @@>
```
Weakly typed quoted expressions are similar to strongly quoted expressions but omit any type
annotation. For example:


```
<@@ 1 + 1 @@>
```
```
<@@ (fun x -> x + 1) @@>
```
In both these examples, the type of the expression is FSharp.Quotations.Expr.

When checked, the initial type of a weakly typed quoted expression <@@ _expr_ @@> is asserted to be
of the form FSharp.Quotations.Expr. The expression _expr_ is checked with fresh initial type _ty_.

### 6.8.3 Expression Splices

Both strongly typed and weakly typed quotations may contain expression splices in the following
forms:

```
%expr
%%expr
```
These are respectively strongly typed and weakly typed splicing operators.

**6.8.3.1 Strongly Typed Expression Splices**
An expression of the following form is a _strongly typed expression splice_ :

```
% expr
```
For example, given

```
open FSharp.Quotations
let f1 (v:Expr<int>) = <@ %v + 1 @>
let expr = f1 <@ 3 @>
```
the identifier expr evaluates to the same expression tree as <@ 3 + 1 @>. The expression tree for <@
3 @> replaces the splice in the corresponding expression tree node.

A strongly typed expression splice may appear only in a quotation. Assuming that the splice
expression % _expr_ is checked with initial type _ty_ , the expression _expr_ is checked with initial type
FSharp.Quotations.Expr< _ty_ >.

```
Note: The rules in this section apply to any use of the prefix operator
FSharp.Core.ExtraTopLevelOperators.(~%). Uses of this operator must be applied to an
argument and may only appear in quoted expressions.
```
**6.8.3.2 Weakly Typed Expression Splices**
An expression of the following form is a _weakly typed expression splice_ :

```
%% expr
```
For example, given

```
open FSharp.Quotations
let f1 (v:Expr) = <@ %%v + 1 @>
let tree = f1 <@@ 3 @@>
```
the identifier tree evaluates to the same expression tree as <@ 3 + 1 @>. The expression tree
replaces the splice in the corresponding expression tree node.


A weakly typed expression splice may appear only in a quotation. Assuming that the splice
expression %% _expr_ is checked with initial type _ty_ , then the expression _expr_ is checked with initial type
FSharp.Quotations.Expr. No additional constraint is placed on _ty_.

Additional type annotations are often required for successful use of this operator.

```
Note: The rules in this section apply to any use of the prefix operator
FSharp.Core.ExtraTopLevelOperators.(~%%), which is defined in the F# core library. Uses
of this operator must be applied to an argument and may only occur in quoted
expressions.
```
## 6.9 EVALUATION OF ELABORATED FORMS

At runtime, execution evaluates expressions to values. The evaluation semantics of each expression
form are specified in the subsections that follow.

### 6.9.1 Values and Execution Context

The execution of elaborated F# expressions results in values. Values include:

- Primitive constant values
- The special value null
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

#### 6.9.2 Parallel Execution and Memory Model

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

The VolatileField attribute marks a mutable location as volatile in the compiled form of the code.

Ordering of reads and writes from mutable locations may be adjusted according to the limitations
specified by the CLI memory model. The following example shows situations in which changes to
read and write order can occur, with annotations about the order of reads:

```
type ClassContainingMutableData() =
let value = (1, 2)
let mutable mutableValue = (1, 2)
```
```
[<VolatileField>]
let mutable volatileMutableValue = (1, 2)
```
```
member x.ReadValues() =
// Two reads on an immutable value
let (a1, b1) = value
```
```
// One read on mutableValue, which may be duplicated according
// to ECMA CLI spec.
let (a2, b2) = mutableValue
```
```
// One read on volatileMutableValue, which may not be duplicated.
let (a3, b3) = volatileMutableValue
```
```
a1, b1, a2, b2, a3, b3
```
```
member x.WriteValues() =
// One read on mutableValue, which may be duplicated according
// to ECMA CLI spec.
let (a2, b2) = mutableValue
```
```
// One write on mutableValue.
mutableValue <- (a2 + 1, b2 + 1)
```
```
// One read on volatileMutableValue, which may not be duplicated.
let (a3, b3) = volatileMutableValue
```

```
// One write on volatileMutableValue.
volatileMutableValue <- (a3 + 1, b3 + 1)
```
```
let obj = ClassContainingMutableData()
Async.Parallel [ async { return obj.WriteValues() };
async { return obj.WriteValues() };
async { return obj.ReadValues() };
async { return obj.ReadValues() } ]
```
#### 6.9.3 Zero Values

Some types have a _zero value_. The zero value is the“default” value for the type in the CLI execution
environment. The following types have the following zero values:

- For reference types, the null value.
- For value types, the value with all fields set to the zero value for the type of the field. The zero
    value is also computed by the F# library function Unchecked.defaultof< _ty_ >.

#### 6.9.4 Taking the Address of an Elaborated Expression

When the F# compiler determines the elaborated forms of certain expressions, it must compute a
“reference” to an elaborated expression _expr_ , written _AddressOf_ ( _expr_ , _mutation_ ). The _AddressOf_
operation is used internally within this specification to indicate the elaborated forms of address-of
expressions, assignment expressions, and method and property calls on objects of variable and value
types.

The _AddressOf_ operation is computed as follows:

- If _expr_ has form _path_ where _path_ is a reference to a value with type byref< _ty_ >, the elaborated
    form is & _path_.
- If _expr_ has form _expra.field_ where _field_ is a mutable, non-readonly CLI field, the elaborated
    form is &( _AddressOf_ ( _expra_ ) _.field_ ).
- If _expr_ has form _expra._ [ _exprb_ ] where the operation is an array lookup, the elaborated form is
    &( _AddressOf_ ( _expra_ )_._ [ _exprb_ ]).
- If _expr_ has any other form, the elaborated form is & _v_ ,where _v_ is a fresh mutable local value that
    is initialized by adding let _v_ = _expr_ to the overall elaborated form for the entire assignment
    expression. This initialization is known as a _defensive copy_ of an immutable value. If _expr_ is a
    struct, _expr_ is copied each time the _AddressOf_ operation is applied, which results in a different
    address each time. To keep the struct in place, the field that contains it should be marked as
    mutable.

The _AddressOf_ operation is computed with respect to _mutation_ , which indicates whether the
relevant elaborated form uses the resulting pointer to change the contents of memory. This
assumption changes the errors and warnings reported.

- If _mutation_ is DefinitelyMutates, then an error is given if a defensive copy must be created.
- If _mutation_ is PossiblyMutates, then a warning is given if a defensive copy arises.


An F# compiler can optionally upgrade PossiblyMutates to DefinitelyMutates for calls to property
setters and methods named MoveNext and GetNextArg, which are the most common cases of struct-
mutators in CLI library design. This is done by the F# compiler.

```
Note:In F#, the warning “copy due to possible mutation of value type” is a level 4
warning and is not reported when using the default settings of the F# compiler. This is
because the majority of value types in CLI libraries are immutable. This is warning
number 52 in the F# implementation.
```
```
CLI libraries do not include metadata to indicate whether a particular value type is
immutable. Unless a value is held in arrays or locations marked mutable, or a value type
is known to be immutable to the F# compiler, F# inserts copies to ensure that
inadvertent mutation does not occur.
```
#### 6.9.5 Evaluating Value References

At runtime, an elaborated value reference v is evaluated by looking up the value of v in the local
environment.

#### 6.9.6 Evaluating Function Applications

At runtime, an elaborated application of a function _f e 1_ ... _en_ is evaluated as follows:

- The expressions _f_ and _e 1_ ... _en_ , are evaluated.
- If _f_ evaluates to a function value with closure environment **E** , arguments _v 1_ ... _vm_ , and body _expr_ ,
    where _m_ <= _n_ , then **E** is extended by mapping _v 1_ ... _vm_ to the argument values for _e 1_ ... _em_. The
    expression _expr_ is then evaluated in this extended environment and any remaining arguments
    applied.
- If _f_ evaluates to a function value with more than _n_ arguments, then a new function value is
    returned with an extended closure mapping _n_ additional formal argument names to the
    argument values for _e 1_ ... _em_.

The result of calling the obj.GetType() method on the resulting object is under-specified (see
§6.9.24).

#### 6.9.7 Evaluating Method Applications

At runtime an elaborated application of a method is evaluated as follows:

- The elaborated form is _e 0_ .M( _e 1_ ,..., _en_ ) for an instance method or M( _e 1_ ,..., _en_ ) for a static method.
- The (optional) _e 0_ and _e 1_ ,..., _en_ are evaluated in order.
- If _e 0_ evaluates to null, a NullReferenceException is raised.
- If the method is declared abstract—that is, if it is a virtual dispatch slot—then the body of the
    member is chosen according to the dispatch maps of the value of _e 0_ (§14.8).
- The formal parameters of the method are mapped to corresponding argument values. The body
    of the method member is evaluated in the resulting environment.


#### 6.9.8 Evaluating Union Cases

At runtime, an elaborated use of a union case _Case_ ( _e 1_ ,..., _en_ ) for a union type _ty_ is evaluated as
follows:

- The expressions _e 1_ ,..., _en_ are evaluated in order.
- The result of evaluation is an object value with union case label _Case_ and fields given by the
    values of _e 1_ ,..., _en_.
- If the type _ty_ uses null as a representation (§5.4.8) and _Case_ is the single union case without
    arguments, the generated value is null.
- The runtime type of the object is either _ty_ or an internally generated type that is compatible
    with _ty_.

#### 6.9.9 Evaluating Field Lookups

At runtime, an elaborated lookup of a CLI or F# fields is evaluated as follows:

- The elaborated form is _expr_. _F_ for an instance field or _F_ for a static field.
- The(optional) _expr_ is evaluated.
- If _expr_ evaluates to null, a NullReferenceException is raised.
- The value of the field is read from either the global field table or the local field table associated
    with the object.

#### 6.9.10 Evaluating Array Expressions

At runtime, an elaborated array expression [| _e 1 ; ..._ ; _en_ |] _ty_ is evaluated as follows:

- Each expression _e 1 ... en_ is evaluated in order.
- The result of evaluation is a new array of runtime type _ty_ [] that contains the resulting values in
    order.

#### 6.9.11 Evaluating Record Expressions

At runtime, an elaborated record construction { _field_ 1 = _e 1 ; ..._ ; _field_ n = _en_ } _ty_ is evaluated as
follows:

- Each expression _e 1 ... en_ is evaluated in order.
- The result of evaluation is an object of type _ty_ with the given field values

#### 6.9.12 Evaluating Function Expressions

At runtime, an elaborated function expression (fun _v 1_ ... _vn_ - > _expr_ ) is evaluated as follows:

- The expression evaluates to a function object with a closure that assigns values to all variables
    that are referenced in _expr_ and a function body that is _expr_.
- The values in the closure are the current values of those variables in the execution environment.
- The result of calling the obj.GetType() method on the resulting object is under-specified (see
    §6.9.24).


#### 6.9.13 Evaluating Object Expressions

At runtime, elaborated object expressions

```
{ new ty 0 args-expropt object-members
interface ty 1 object-members 1
interface tyn object-membersn }
```
is evaluated as follows:

- The expression evaluates to an object whose runtime type is compatible with all of the _tyi_ and
    which has the corresponding dispatch map (§14.8). If present, the base construction expression
    _ty_ 0 ( _args-expr_ ) is executed as the first step in the construction of the object.
- The object is given a closure that assigns values to all variables that are referenced in _expr_.
- The values in the closure are the current values of those variables in the execution environment.

The result of calling the obj.GetType() method on the resulting object is under-specified (see
§6.9.24).

#### 6.9.14 Evaluating Definition Expressions

At runtime, each elaborated definition _pat_ = _expr_ is evaluated as follows:

- The expression _expr_ is evaluated.
- The expression is then matched against _pat_ to produce a value for each variable pattern (§7.2)
    in _pat_.
- These mappings are added to the local environment.

#### 6.9.15 Evaluating Integer For Loops

At runtime, an integer for loop for _var_ = _expr 1_ to _expr 2_ do _expr 3_ done is evaluated as follows:

- Expressions _expr 1_ and _expr 2_ are evaluated once to values _v 1_ and _v 2_.
- The expression _expr 3_ is evaluated repeatedly with the variable _var_ assigned successive values in
    the range of _v 1_ up to _v 2_.
- If _v 1_ is greater than _v 2_ , then _expr 3_ is never evaluated.

#### 6.9.16 Evaluating While Loops

As runtime, while-loops while _expr 1_ do _expr 2_ done are evaluated as follows:

- Expression _expr 1_ is evaluated to a value _v 1_.
- If _v 1_ is true, expression _expr 2_ is evaluated, and the expression while _expr 1_ do _expr 2_ done is
    evaluated again.
- If _v 1_ is false, the loop terminates and the resulting value is null (the representation of the only
    value of type unit)

#### 6.9.17 Evaluating Static Coercion Expressions

At runtime, elaborated static coercion expressions of the form _expr_ :> _ty_ are evaluated as follows:


- Expression _expr_ is evaluated to a value _v_.
- If the static type of _e_ is a value type, and _ty_ is a reference type, _v_ is _boxed_ ; that is, _v_ is converted
    to an object on the heap with the same field assignments as the original value. The expression
    evaluates to a reference to this object.
- Otherwise, the expression evaluates to _v_.

#### 6.9.18 Evaluating Dynamic Type-Test Expressions

At runtime, elaborated dynamic type test expressions _expr_ :? _ty_ are evaluated as follows:

1. Expression _expr_ is evaluated to a value _v_.
2. If _v_ is null, then:
    - If _tye_ uses null as a representation (§5.4.8), the result is true.
    - Otherwise the expression evaluates to false.
3. If _v_ is not null and has runtime type _vty_ which dynamically converts to _ty_ (§5.4.10), the
    expression evaluates to true. However, if _ty_ is an enumeration type, the expression evaluates to
    true if and only if _ty_ is precisely _vty_.

#### 6.9.19 Evaluating Dynamic Coercion Expressions

At runtime, elaborated dynamic coercion expressions _expr_ :?> _ty_ are evaluated as follows:

1. Expression _expr_ is evaluated to a value _v_.
2. If _v_ is null:
    - If _tye_ uses null as a representation (§5.4.8), the result is the null value.
    - Otherwise a NullReferenceException is raised.
3. If _v_ is not null:
    - If _v_ has dynamic type _vty_ which _dynamically converts to ty_ (§5.4.10), the expression
       evaluates to the dynamic conversion of _v_ to _ty_.
          o If _vty_ is a reference type and _ty_ is a value type, then _v_ is _unboxed_ ; that is, _v_ is
             converted from an object on the heap to a struct value with the same field
             assignments as the object. The expression evaluates to this value.
          o Otherwise, the expression evaluates to _v_.
    - Otherwise an InvalidCastException is raised.

Expressions of the form _expr_ :?> _ty_ evaluate in the same way as the F# library function
unbox _<ty>_ ( _expr_ ).

```
Note: Some F# types—most notably the option<_> type—use null as a representation
for efficiency reasons (§5.4.8),. For these types, boxing and unboxing can lose type
distinctions. For example, contrast the following two examples:
```

```
> (box([]:string list) :?> int list);;
System.InvalidCastException...
> (box(None:string option) :?> int option);;
val it : int option = None
```
```
In the first case, the conversion from an empty list of strings to an empty list of integers
(after first boxing) fails. In the second case, the conversion from a string option to an
integer option (after first boxing) succeeds.
```
#### 6.9.20 Evaluating Sequential Execution Expressions

At runtime, elaborated sequential expressions _expr 1_ ; _expr 2_ are evaluated as follows:

- The expression _expr 1_ is evaluated for its side effects and the result is discarded.
- The expression _expr 2_ is evaluated to a value _v 2_ and the result of the overall expression is _v 2_.

#### 6.9.21 Evaluating Try-with Expressions

At runtime, elaborated try-with expressions try _expr 1_ with _rules_ are evaluated as follows:

- The expression _expr 1_ is evaluated to a value _v 1_.
- If no exception occurs, the result is the value _v 1_.
- If an exception occurs, the pattern rules are executed against the resulting exception value.
    - If no rule matches, the exception is reraised.
    - If a rule _pat -> expr 2_ matches, the mapping _pat = v 1_ is added to the local environment,
       and _expr 2_ is evaluated.

#### 6.9.22 Evaluating Try-finally Expressions

At runtime, elaborated try-finally expressions try _expr 1_ finally _expr 2_ are evaluated as follows:

- The expression _expr 1_ is evaluated.
    - If the result of this evaluation is a value _v_ , then _expr 2_ is evaluated.
       1) If this evaluation results in an exception, then the overall result is that exception.
       2) If this evaluation does not result in an exception, then the overall result is _v_.
    - If the result of this evaluation is an exception, then _expr 2_ is evaluated.
       3) If this evaluation results in an exception, then the overall result is that exception.
       4) If this evaluation does not result in an exception, then the original exception is re-
          raised.

#### 6.9.23 Evaluating AddressOf Expressions

At runtime, an elaborated address-of expression is evaluated as follows. First, the expression has
one of the following forms:

- & _path_ where _path_ is a static field.


- &( _expr.field_ )
- &( _expra._ [ _exprb_ ])
- & _v_ where _v_ is a local mutable value.

The expression evaluates to the address of the referenced local mutable value, mutable field, or
mutable static field.

```
Note: The underlying CIL execution machinery that F# uses supports covariant arrays, as
evidenced by the fact that the type string[] dynamically converts to obj[] (§5.4.10).
Although this feature is rarely used in F#, its existence means that array assignments and
taking the address of array elements may fail at runtime with a
System.ArrayTypeMismatchException if the runtime type of the target array does not
match the runtime type of the element being assigned. For example, the following code
fails at runtime:
let f (x: byref<obj>) = ()
```
```
let a = Array.zeroCreate<obj> 10
let b = Array.zeroCreate<string> 10
f (&a.[0])
let bb = ((b :> obj) :?> obj[])
// The next line raises a System.ArrayTypeMismatchException exception.
F (&bb.[1])
```
#### 6.9.24 Values with Underspecified Object Identity and Type Identity

The CLI and F# support operations that detect object identity—that is, whether two object
references refer to the same “physical” object. For example, System.Object.ReferenceEquals(obj 1 ,
obj 2 ) returns true if the two object references refer to the same object. Similarly,
System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode() returns a hash code that is partly
based on physical object identity, and the AddHandler and RemoveHandler operations (which register
and unregister event handlers) are based on the object identity of delegate values.

The results of these operations are underspecified when used with values of the following F# types:

- Function types
- Tuple types
- Immutable record types
- Union types
- Boxed immutable value types

For two values of such types, the results of System.Object.ReferenceEquals and
System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode are underspecified; however, the
operations terminate and do not raise exceptions. An implementation of F# is not required to define
the results of these operations for values of these types.

For function values and objects that are returned by object expressions, the results of the following
operations are underspecified in the same way:

- Object.GetHashCode()


- Object.GetType()

For union types the results of the following operations are underspecified in the same way:

- Object.GetType()



## 7. PATTERNS

Patterns are used to perform simultaneous case analysis and decomposition on values together with
the match, try...with, function, fun, and let expression and declaration constructs. Rules are
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
```

```
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

### 7.1 SIMPLE CONSTANT PATTERNS

The pattern _const_ is a _constant pattern_ which matches values equal to the given constant. For
example:

```
let rotate3 x =
match x with
| 0 -> "two"
| 1 -> "zero"
| 2 -> "one"
| _ -> failwith "rotate3"
```
In this example, the constant patterns are 0, 1, and 2. Any constant listed in §6.3.1 may be used as a
constant pattern except for integer literals that have the suffixes Q, R, Z, I, N, G.

Simple constant patterns have the corresponding simple type. Such patterns elaborate to a call to
the F# structural equality function FSharp.Core.Operators.(=) with the pattern input and the
constant as arguments. The match succeeds if this call returns true; otherwise, the match fails.

```
Note : The use of FSharp.Core.Operators.(=) means that CLI floating-point equality is
used to match floating-point values, and CLI ordinal string equality is used to match
strings.
```
### 7.2 NAMED PATTERNS

Patterns in the following forms are _named patterns_ :

```
Long-ident
Long-ident pat
Long-ident pat-params pat
```

If _long-ident_ is a single identifier that does not begin with an uppercase character, it is interpreted
as a _variable pattern_. During checking, the variable is assigned the same value and type as the
pattern input.

If _long-ident_ is more than one-character long or begins with an uppercase character (that is, if
System.Char.IsUpperInvariant is true and System.Char.IsLowerInvariant is false on the first
character), it is resolved by using _Name Resolution in Patterns_ (§14.1.6). This algorithm produces one
of the following:

- A union case
- An exception label
- An active pattern case name
- A literal value

Otherwise, _long-ident_ must be a single uppercase identifier _ident_. In this case, _pat_ is a variable
pattern. An F# implementation may optionally generate a warning if the identifier is uppercase. Such
a warning is recommended if the length of the identifier is greater than two.

After name resolution, the subsequent treatment of the named pattern is described in the following
sections.

#### 7.2.1 Union Case Patterns

If _long-ident_ from §7.2 resolves to a union case, the pattern is a union case pattern. If _long-ident_
resolves to a union case _Case_ , then _long-ident_ and _long-ident pat_ are patterns that match pattern
inputs that have union case label _Case_. The _long-ident_ form is used if the corresponding case takes
no arguments, and the _long-ident pat_ form is used if it takes arguments.

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
```

```
| Rectangle of width: float * height: float
| Square of width: float
```
```
let getArea (s: Shape) =
match s with
| Rectangle (width = w; height = h) -> w*h
| Square (width = w) -> w*w
```
#### 7.2.2 Literal Patterns

If _long-ident_ from §7.2 resolves to a literal value, the pattern is a literal pattern. The pattern is
equivalent to the corresponding constant pattern.

In the following example, the Literal attribute (§10.2.2) is first used to define two literals, and these
literals are used as identifiers in the match expression:

```
[<Literal>]
let Case1 = 1
```
```
[<Literal>]
let Case2 = 100
```
```
let result =
match 1 00 with
| Case1 -> "Case1"
| Case2 -> "Case 2 "
| _ -> "Some other case"
```
In this case, result is given the value "Case2”.

#### 7.2.3 Active Patterns

If _long-ident_ from §7.2 resolves to an _active pattern case name CaseNamei_ then the pattern is an
active pattern. The rules for name resolution in patterns (§14.1.6) ensure that _CaseNamei_ is
associated with an _active pattern function f_ in one of the following forms:

- (| _CaseName_ |) _inp_

```
Single case. The function accepts one argument (the value being matched) and can return any
type.
```
- (| _CaseName_ |_|) _inp_

```
Partial. The function accepts one argument (the value being matched) and must return a value
of type FSharp.Core.option<_>
```
- (| _CaseName 1_ | ...| _CaseNamen_ |) _inp_

```
Multi-case. The function accepts one argument (the value being matched), and must return a
value of type FSharp.Core.Choice<_,...,_> based on the number of case names. In F#, the
limitation n ≤ 7 applies.
```
- (| _CaseName_ |) _arg 1_ ... _argn inp_

```
Single case with parameters. The function accepts n +1 arguments, where the last argument ( inp )
is the value to match, and can return any type.
```

- (| _CaseName_ |_|) _arg 1_ ... _argn inp_

```
Partial with parameters. The function accepts n +1 arguments, where the last argument ( inp ) is
the value to match, and must return a value of type FSharp.Core.option<_>.
```
Other active pattern functions are not permitted. In particular, multi-case, partial functions such as
the following are not permitted:

```
(|CaseName1| ... |CaseNamen|_|)
```
When an active pattern function takes arguments, the _pat-params_ are interpreted as expressions
that are passed as arguments to the active pattern function. The _pat-params_ are converted to the
syntactically identical corresponding expression forms and are passed as arguments to the active
pattern function _f_.

At runtime, the function _f_ is applied to the pattern input, along with any parameters. The pattern
matches if the active pattern function returns _v_ , Choice _k_ Of _N v_ , or Some _v_ , respectively, when applied
to the pattern input. If the pattern argument _pat_ is present, it is then matched against _v_.

The following example shows how to define and use a partial active pattern function:

```
let (|Positive|_|) inp = if inp > 0 then Some(inp) else None
let (|Negative|_|) inp = if inp < 0 then Some(-inp) else None
```
```
match 3 with
| Positive n -> printfn "positive, n = %d" n
| Negative n -> printfn "negative, n = %d" n
| _ -> printfn "zero"
```
The following example shows how to define and use a multi-case active pattern function:

```
let (|A|B|C|) inp = if inp < 0 then A elif inp = 0 then B else C
```
```
match 3 with
| A -> "negative"
| B -> "zero"
| C - > "positive"
```
The following example shows how to define and use a parameterized active pattern function:

```
let (|MultipleOf|_|) n inp = if inp%n = 0 then Some (inp / n) else None
```
```
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
```
```
let (|B|_|) x =
if x=3 then failwith "x is three" else None
```

```
let (|C|) x = failwith "got to C"
```
```
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

### 7.3 “AS” PATTERNS

An “as” pattern is of the following form:

```
pat as ident
```
The “as” pattern defines _ident_ to be equal to the pattern input and matches the pattern input
against _pat_. For example:

```
let t1 = (1, 2)
let (x, y) as t2 = t1
printfn "%d-%d-%A" x y t2 // 1- 2 - (1, 2)
```
This example binds the identifiers x, y, and t1 to the values 1 , 2 , and (1,2), respectively.

### 7.4 WILDCARD PATTERNS

The pattern _ is a wildcard pattern and matches any input. For example:

```
let categorize x =
match x with
| 1 - > 0
| 0 -> 1
| _ -> 0
```
In the example, if x is 0, the match returns 1. If x has any other value, the match returns 0.


### 7.5 DISJUNCTIVE PATTERNS

A disjunctive pattern matches an input value against one or the other of two patterns:

```
pat | pat
```
At runtime, the patterm input is matched against the first pattern. If that fails, the pattern input is
matched against the second pattern. Both patterns must bind the same set of variables with the
same types. For example:

```
type Date = Date of int * int * int
```
```
let isYearLimit date =
match date with
| (Date (year, 1, 1) | Date (year, 12, 31)) -> Some year
| _ -> None
```
```
let result = isYearLimit (Date (2010,12,31))
```
In this example, result is given the value true, because the pattern input matches the second
pattern.

### 7.6 CONJUNCTIVE PATTERNS

A conjunctive pattern matches the pattern input against two patterns.

```
pat 1 & pat 2
```
For example:

```
let (|MultipleOf|_|) n inp = if inp%n = 0 then Some (inp / n) else None
```
```
let result =
match 56 with
| MultipleOf 4 m & MultipleOf 7 n -> m + n
| _ -> false
```
In this example, result is given the value 22 (= 16 + 8 ), because the pattern input match matches
both patterns.

### 7. 7 LIST PATTERNS

The pattern _pat_ :: _pat_ is a union case pattern that matches the “cons” union case of F# list values.

The pattern [] is a union case pattern that matches the “nil” union case of F# list values.

The pattern [ _pat 1_ ; ... ; _patn_ ] is shorthand for a series of :: and empty list patterns
_pat 1_ :: ... :: _patn_ :: [].

For example:

```
let rec count x =
match x with
```

```
| [] -> 0
| h :: t -> h + count t
```
```
let result 1 = count [1;2;3]
let result2 =
match [1;2;3] with
| [a;b;c] -> a + b + c
| _ -> 0
```
In this example, both result 1 and result2 are given the value 6.

### 7.8 TYPE-ANNOTATED PATTERNS

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
In this example, the initial type of h is asserted to be equal to int before the pattern h is checked.
Through type inference, this in turn implies that xs and t have static type int list, and sum has
static type
int list -> int.

### 7.9 DYNAMIC TYPE-TEST PATTERNS

_Dynamic type-test patterns_ have the following two forms:

```
:? type
:? type as ident
```
A dynamic type-test pattern matches any value whose runtime type is _type_ or a subtype of _type_. For
example:

```
let message (x : System.Exception) =
match x with
| :? System.OperationCanceledException -> "cancelled"
| :? System.ArgumentException -> "invalid argument"
| _ -> "unknown error"
```
If the type-test pattern is of the form :? _type_ as _ident_ , then the value is coerced to the given type
and _ident_ is bound to the result. For example:

```
let findLength (x : obj) =
match x with
| :? string as s -> s.Length
| _ -> 0
```

In the example, the identifier s is bound to the value x with type string.

If the pattern input has type _tyin_ , pattern checking uses the same conditions as both a dynamic type-
test expression _e_ :? _type_ and a dynamic coercion expression _e_ :?> _type_ where _e_ has type _tyin_. An
error occurs if _type_ cannot be statically determined to be a subtype of the type of the pattern input_._
A warning occurs if the type test will always succeed based on _type_ and the static type of the pattern
input.

A warning is issued if an expression contains a redundant dynamic type-test pattern, after any
coercion is applied. For example:

```
match box "3" with
| :? string -> 1
| :? string -> 1 // a warning is reported that this rule is "never matched"
| _ -> 2
```
```
match box "3" with
| :? System.IComparable -> 1
| :? string -> 1 // a warning is reported that this rule is "never matched"
| _ -> 2
```
At runtime, a dynamic type-test pattern succeeds if and only if the corresponding dynamic type-test
expression _e_ :? _ty_ would return true where _e_ is the pattern input. The value of the pattern is bound
to the results of a dynamic coercion expression _e_ :?> _ty_.

### 7.10 RECORD PATTERNS

The following is a _record pattern_ :

```
{ long-ident 1 = pat 1 ; ... ; long-identn = patn }
```
For example:

```
type Data = { Header:string; Size: int; Names: string list }
```
```
let totalSize data =
match data with
| { Header = "TCP"; Size = size; Names = names } -> size + names.Length * 12
| { Header = "UDP"; Size = size } -> size
| _ -> failwith "unknown header"
```
The _long-identi_ are resolved in the same way as field labels for record expressions and must
together identify a single, unique F# record type. Not all record fields for the type need to be
specified in the pattern.

### 7.11 ARRAY PATTERNS

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
### 7.12 NULL PATTERNS

The _null pattern_ null matches values that are represented by the CLI value null. For example:

```
let path =
match System.Environment.GetEnvironmentVariable("PATH") with
| null -> failwith "no path set!"
| res -> res
```
Most F# types do not use null as a representation; consequently, the null pattern is generally used
to check values passed in by CLI method calls and properties. For a list of F# types that use null as a
representation, see §5.4.8.

### 7.13 GUARDED PATTERN RULES

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
For example, the following evaluates to 2 with no output.

```
match (1, 2) with
| (3, x) when (printfn "not printed"; true) -> 0
| (_, y) -> y
```

## 8. TYPE DEFINITIONS

Type definitions define new named types. The grammar of type definitions is shown below.

```
type-defn :=
abbrev-type-defn
record-type-defn
union-type-defn
anon-type-defn
class-type-defn
struct-type-defn
interface-type-defn
enum-type-defn
delegate-type-defn
type-extension
type-name :=
attributesopt accessopt ident typar-defns opt
abbrev-type-defn :=
type-name = type
union-type-defn :=
type-name '=' union-type-cases type-extension-elementsopt
union-type-cases :=
'|' opt union-type-case '|' ... '|' union-type-case
union-type-case :=
attributesopt union-type-case-data
union-type-case-data :=
ident -- null union case
ident of union-type-field * ... * union-type-field -- n-ary union case
ident : uncurried-sig -- n-ary union case
union-type-field :=
type -- unnamed union fiels
ident : type -- named union field
record-type-defn :=
type-name = '{' record-fields '}' type-extension-elementsopt
record-fields :=
record-field ; ... ; record-field ; opt
record-field :=
attributesopt mutable opt accessopt ident : type
anon-type-defn :=
type-name primary-constr-argsopt object-valopt '=' begin class-type-body end
class-type-defn :=
type-name primary-constr-argsopt object-valopt '=' class class-type-body end
as-defn := as ident
class-type-body :=
class-inherits-declopt class-function-or-value-defnsopt type-defn-elementsopt
class-inherits-decl := inherit type expropt
```

_class-function-or-value-defn_ :=
_attributesopt_ static _opt_ let rec _opt function-or-value-defns
attributesopt_ static _opt_ do _expr_

_struct-type-defn_ :=
_type-name primary-constr-argsopt as-defnopt_ '=' struct _struct-type-body_ end

_struct-type-body_ := _type-defn-elements_

_interface-type-defn_ :=
_type-name_ '=' interface _interface-type-body_ end

_interface-type-body_ := _type-defn-elements_

_exception-defn_ :=
_attributesopt_ exception _union-type-case-data_ -- exception definition
_attributesopt_ exception _ident_ = _long-ident_ -- exception abbreviation

_enum-type-defn_ :=
_type-name '_ =' _enum-type-cases_

_enum-type-cases_ =
'|' _opt enum-type-case_ '|' ... '|' _enum-type-case_

_enum-type-case_ :=
_ident_ '=' _const_ -- enum constant definition

_delegate-type-defn_ :=
_type-name '_ =' _delegate-sig_

_delegate-sig_ :=
delegate of _uncurried-sig --_ CLI delegate definition

_type-extension_ :=
_type-name type-extension-elements_

_type-extension-elements_ := with _type-defn-elements_ end

_type-defn-element_ :=
_member-defn
interface-impl
interface-spec_

_type-defn-elements :_ = _type-defn-element ... type-defn-element_

_primary-constr-args_ :=
_attributesopt accessopt_ ( _simple-pat, ... , simple-pat_ )

_simple-pat :=
| ident
| simple-pat : type_

_additional-constr-defn_ :=
_attributesopt accessopt_ new _pat as-defn_ = _additional-constr-expr_

_additional-constr-expr_ :=
_stmt_ ';' _additional-constr-expr_ -- sequence construction (after)
_additional-constr-expr_ then _expr_ -- sequence construction (before)
if _expr_ then _additional-constr-expr_ else _additional-constr-expr_
let _function-or-value-defn_ in _additional-constr-expr
additional-constr-init-expr_

_additional-constr-init-expr_ :=
'{' _class-inherits-decl field-initializers_ '}' -- explicit construction
new _type expr_ -- delegated construction


```
member-defn :=
attributesopt static opt member accessopt method-or-prop-defn -- concrete member
attributesopt abstract member opt accessopt member-sig -- abstract member
attributesopt override accessopt method-or-prop-defn -- override member
attributesopt default accessopt method-or-prop-defn -- override member
attributesopt static opt val mutable opt accessopt ident : type -- value member
additional-constr-defn -- additional constructor
method-or-prop-defn :=
ident.opt function-defn -- method definition
ident.opt value-defn -- property definition
ident.opt ident with function-or-value-defns -- property definition via
get/set methods
member ident = exp – - auto-implemented property definition
member ident = exp with get – - auto-implemented property definition
member ident = exp with set – - auto-implemented property definition
member ident = exp with get,set – - auto-implemented property definition
member ident = exp with set,get – - auto-implemented property definition
member-sig :=
ident typar-defnsopt : curried-sig -- method or property signature
ident typar-defnsopt : curried-sig with get -- property signature
ident typar-defnsopt : curried-sig with set -- property signature
ident typar-defnsopt : curried-sig with get,set -- property signature
ident typar-defnsopt : curried-sig with set,get -- property signature
curried-sig :=
args-spec - > ... - > args-spec - > type
uncurried-sig :=
args-spec - > type
args-spec :=
arg-spec * ... * arg-spec
arg-spec :=
attributesopt arg-name-specopt type
arg-name-spec :=
? opt ident :
interface-spec :=
interface type
```
For example:

```
type int = System.Int32
type Color = Red | Green | Blue
type Map<'T> = { entries: 'T[] }
```
Type definitions can be declared in:

- Module definitions
- Namespace declaration groups

F# supports the following kinds of type definitions:

- Type abbreviations (§8.3)
- Record type definitions (§8.4)
- Union type definitions (§8.5)


- Class type definitions (§8.6)
- Interface type definitions (§8.7)
- Struct type definitions (§8.8)
- Enum type definitions (§8.9)
- Delegate type definitions (§8.10)
- Exception type definitions (§8.11)
- Type extension definitions (§8.12)
- Measure type definitions (§9.4)

With the exception of type abbreviations and type extension definitions, type definitions define
fresh, named types that are distinct from other types.

A _type definition group_ defines several type definitions or extensions simultaneously:

```
type ... and ...
```
For example:

```
type RowVector(entries: seq<int>) =
let entries = Seq.toArray entries
member x.Length = entries.Length
member x.Permute = ColumnVector(entries)
```
```
and ColumnVector(entries: seq<int>) =
let entries = Seq.toArray entries
member x.Length = entries.Length
member x.Permute = RowVector(entries)
```
A type definition group can include any type definitions except for exception type definitions and
module definitions.

Most forms of type definitions may contain both _static_ elements and _instance_ elements. Static
elements are accessed by using the type definition. Within a static definition, only the static
elements are in scope. Most forms of type definitions may contain _members_ (§8.13).

Custom attributes may be placed immediately before a type definition group, in which case they
apply to the first type definition, or immediately before the name of the type definition:

```
[<Obsolete>] type X1() = class end
```
```
type [<Obsolete>] X2() = class end
and [<Obsolete>] Y2() = class end
```
### 8.1 TYPE DEFINITION GROUP CHECKING AND ELABORATION

F# checks type definition groups by determining the basic shape of the definitions and then filling in
the details. In overview, a type definition group is checked as follows:

1. For each type definition:


- Determine the generic arguments, accessibility and kind of the type definition
- Determine whether the type definition supports equality and/or comparison
- Elaborate the explicit constraints for the generic parameters.
2. For each type definition:
- Establish type abbreviations
- Determine the base types and implemented interfaces of each new type definition
- Detect any cyclic abbreviations
- Verify the consistency of types in fields, union cases, and base types.
3. For each type definition:
- Determine the union cases, fields, and abstract members (§8.14) of each new type
definition.
- Check the union cases, fields, and abstract members themselves, as described in the
corresponding sections of this chapter.
4. For each member, add items that represent the members to the environment as a recursive
group.
5. Check the members, function, and value definitions in order and apply incremental
generalization.

In the context in which type definitions are checked, the type definition itself is in scope, as are all
members and other accessible functionality of the type. This context enables recursive references to
the accessible static content of a type. It also enables recursive references to the accessible
properties of any object that has the same type as the type definition or a related type.

In more detail, given an initial environment _env_ , a type definition group is checked as described in
the following paragraphs.

First, check the individual type definitions. For each type definition:

1. Determine the number, names, and sorts of generic arguments of the type definition.
    - For each generic argument, if a Measure attribute is present, mark the generic argument as a
       measure parameter. The generic arguments are initially inference parameters, and
       additional constraints may be inferred for these parameters.
    - For each type definition _T_ , the subsequent steps use an environment _envT_ that is produced
       by adding the type definitions themselves and the generic arguments for _T_ to _env_.
2. Determine the accessibility of the type definition.
3. Determine and check the basic kind of the type definition, using _Type Kind Inference_ if necessary
    (§8.2).
4. Mark the type definition as a measure type definition if a Measure attribute is present.


5. If the type definition is generic, infer whether the type definition supports equality and/or
comparison.

6. Elaborate and add the explicit constraints for the generic parameters of the type definition, and
    then generalize the generic parameters. Inference of additional constraints is not permitted.
7. If the type definition is a type abbreviation, elaborate and establish the type being abbreviated.
8. Check and elaborate any base types and implemented interfaces.
9. If the type definition is a type abbreviation, check that the type abbreviation is not cyclic.
10. Check whether the type definition has a single, zero-argument constructor, and hence forms a
    type that satisfies the default constructor constraint.
11. Recheck the following to ensure that constraints are consist:
    - The type being abbreviated, if any.
    - The explicit constraints for any generic parameters, if any.
    - The types and constraints occurring in the base types and implemented interfaces, if any.
12. Determine the union cases, fields, and abstract members, if any, of the type definition. Check
    and elaborate the types that the union cases, fields, and abstract members include.
13. Make additional checks as defined elsewhere in this chapter. For example, check that the
    AbstractClass attribute does not appear on a union type.
14. For each type definition that is a struct, class, or interface, check that the inheritance graph and
    the struct-inclusion graph are not cyclic. This check ensures that a struct does not contain itself
    and that a class or interface does not inherit from itself. This check includes the following steps:

```
a) Create a graph with one node for each type definition.
```
```
b) Close the graph under edges.
```
- (T, base-type-definition)
- (T, interface-type-definition)
- (T 1 , T 2 ) where T 1 is a struct and T 2 is a type that would store a value of type T 1 <...> for
    some instantiation. Here “X storing Y” means that X is Y or is a struct type with an
    instance field that stores Y.

```
c) Check for cycles.
```
```
The special case of a struct S< typars > storing a static field of type S< typars > is allowed.
```
15. Collectively add the elaborated member items that represent the members for all new type
    definitions to the environment as a recursive group (§8.13), excluding interface implementation
    members.


16. If the type definition has a primary constructor, create a member item to represent the primary
    constructor.

After these steps are complete for each type definition, check the members. For each member:

1. If the member is in a generic type, create a copy of the type parameters for the generic type and
    add the copy to the environment for that member.
2. If the member has explicit type parameters, elaborate these type parameters and any explicit
    constraints.
3. If the member is an override, default, or interface implementation member, apply dispatch-slot
    inference.
4. If the member has syntactic parameters, assign an initial type to the elaborated member item
    based on the patterns that specify arguments for the members.
5. If the member is an instance member, assign a type to the instance variable.

Finally, check the function, value, and member definitions of each new type definition in order as a
recursive group.

### 8.2 TYPE KIND INFERENCE

A type that is specified in one of the following ways has an anonymous type kind:

- By using begin and end on the right-hand side of the = token.
- In lightweight syntax, with an implicit begin/end.

F# infers the kind of an anonymous type by applying the following rules, in order:

1. If the type has a Class attribute, Interface attribute, or Struct attribute, this attribute identifies
    the kind of the type.
2. If the type has any concrete elements, the type is a class. Concrete elements are primary
    constructors, additional object constructors, function definitions, value definitions, non-abstract
    members, and any inherit declarations that have arguments.
3. Otherwise, the type is an interface type.

For example:

```
// This is implicitly an interface
type IName =
abstract Name : string
```
```
// This is implicitly a class, because it has a constructor
type ConstantName(n:string) =
member x.Name = n
```

```
// This is implicitly a class, because it has a constructor
type AbstractName(n:string) =
abstract Name : string
default x.Name = "<no-name>"
```
If a type is not an anonymous type, any use of the Class attribute, Interface attribute, or Struct
attribute must match the class/end, interface/end, and struct/end tokens, if such tokens are
present. These attributes cannot be used with other kinds of type definitions such as type
abbreviations, record, union, or enum types.

### 8.3 TYPE ABBREVIATIONS

Type abbreviations define new names for other types. For example:

```
type PairOfInt = int * int
```
Type abbreviations are expanded and erased during compilation and do not appear in the
elaborated form of F# declarations, nor can they be referred to or accessed at runtime.

The process of repeatedly eliminating type abbreviations in favor of their equivalent types must not
result in an infinite type derivation. For example, the following are not valid type definitions:

```
type X = option<X>
```
```
type Identity<'T> = 'T
and Y = Identity<Y>
```
The constraints on a type abbreviation must satisfy any constraints that the abbreviated type
requires.

For example, assuming the following declarations:

```
type IA =
abstract AbstractMember : int -> int
```
```
type IB =
abstract AbstractMember : int -> int
```
```
type C<'T when 'T :> IB>() =
static member StaticMember(x : 'a) = x.AbstractMember(1)
```
the following is permitted:

```
type D<'T when 'T :> IB> = C<'T>
```
whereas the following is not permitted:

```
type E<'T> = C<'T> // invalid: missing constraint
```
Type abbreviations can define additional constraints, so the following is permitted:

```
type F<'T when 'T :> IA and 'T :> IB> = C<'T>
```

The right side of a type abbreviation must use all the declared type variables that appear on the left
side. For this purpose, the order of type variables that are used on the right-hand side of a type
definition is determined by their left-to-right occurrence in the type.

For example, the following is not a valid type abbreviation.

```
type Drop<'T,'U> = 'T * 'T // invalid: dropped type variable
```
```
Note : This restriction simplifies the process of guaranteeing a stable and consistent
compilation to generic CLI code.
```
Flexible type constraints # _type_ may not be used on the right side of a type abbreviation, because
they expand to a type variable that has not been named in the type arguments of the type
abbreviation. For example, the following type is disallowed:

```
type BadType = #Exception -> int // disallowed
```
Type abbreviations may be declared internal or private.

```
Note: Private type abbreviations are still, for all purposes, considered equivalent to the
abbreviated types.
```
## 8.4 RECORD TYPE DEFINITIONS

A _record type definition_ introduces a type in which all the inputs that are used to construct a value
are accessible as properties on values of the type. For example:

```
type R1 =
{ x : int;
y : int }
member this.Sum = this.x + this.y
```
In this example, the integers x and y can be accessed as properties on values of type R1.

Record fields may be marked mutable. For example:

```
type R2 =
{ mutable x : int;
mutable y : int }
member this.Move(dx,dy) =
this.x <- this.x + dx
this.y <- this.y + dy
```
The mutable attribute on x and y makes the assignments valid.

Record types are implicitly sealed and may not be given the Sealed attribute. Record types may not
be given the AbstractClass attribute.

Record types are implicitly marked serializable unless the AutoSerializable(false) attribute is used.


### 8.4.1 Members in Record Types

Record types may declare members (§8.13), overrides, and interface implementations. Like all types
with overrides and interface implementations, they are subject to _Dispatch Slot Checking_ (§14.8).

### 8.4.2 Name Resolution and Record Field Labels

For a record type, the record field labels field _1_ ... field _N_ are added to the _FieldLabels_ table of the
current name resolution environmentunless the record type has the RequireQualifiedAccess
attribute.

Record field labels in the _FieldLabels_ table play a special role in _Name Resolution for Members_
(§14.1): an expression’s type may be inferred from a record label. For example:

```
type R = { dx : int; dy: int }
let f x = x.dx // x is inferred to have type R
```
In this example, the lookup .dx is resolved to be a field lookup.

### 8.4.3 Structural Hashing, Equality, and Comparison for Record Types

Record types implicitly implement the following interfaces and dispatch slots unless they are
explicitly implemented as part of the definition of the record type:

```
interface System.Collections.IStructuralEquatable
interface System.Collections.IStructuralComparable
interface System.IComparable
override GetHashCode : unit -> int
override Equals : obj -> bool
```
The implicit implementations of these interfaces and overrides are described in §8.1 5.

### 8.4.4 With/End in Record Type Definitions

Record type definitions can include with/end tokens, as the following shows:

```
type R1 =
{ x : int;
y : int }
with
member this.Sum = this.x + this.y
end
```
The with/end tokens can be omitted if the type-defn-elements vertically align with the { in the
record-fields. The semicolon (;) tokens can be omitted if the next _record-field_ vertically aligns
with the previous _record-field_.

### 8.4.5 CLIMutable Attributes

Adding the CLIMutable attribute to a record type causes it to be compiled to a CLI representation as
a plain-old CLR object (POCO) with a default constructor along with property getters and setters.
Adding the default constructor and mutable properties makes objects of the record type usable with
.NET tools and frameworks such as database queries, serialization frameworks, and data models in
XAML programming.


For example, an F# immutable record cannot be serialized because it does not have a constructor.
However, if you attach the CLIMutable attribute as in the following example, the XmlSerializer is
enable to serialize or deserialize this record type:

```
[<CLIMutable>]
type R1 = { x : string; y : int }
```
## 8.5 UNION TYPE DEFINITIONS

A _union type definition_ is a type definition that includes one or more _union cases_. For example:

```
type Message =
| Result of string
| Request of int * string
member x.Name = match x with Result(nm) -> nm | Request(_,nm) -> nm
```
Union case names must begin with an uppercase letter, which is defined to mean any character for
which the CLI library function System.Char.IsUpper returns true and System.Char.IsLower returns
false.

The union cases Case1 ... CaseN have module scope and are added to the _ExprItems_ and _PatItems_
tables in the name resolution environment. This means that their unqualified names can be used to
form both expressions and patterns, unless the record type has the RequireQualifiedAccess
attribute.

Parentheses are significant in union definitions. Thus, the following two definitions differ:

```
type CType = C of int * int
type CType = C of (int * int)
```
The lack of parentheses in the first example indicates that the union case takes two arguments. The
parentheses in the second example indicate that the union case takes one argument that is a first-
class tuple value.

Union fields may optionally be named within each case of a union type. For example:

```
type Shape =
| Rectangle of width: float * length: float
| Circle of radius: float
| Prism of width: float * float * height: float
```
The names are referenced when pattern matching on union values of this type. When using pattern
matching with multiple fields, semicolons are used to delimit the named fields, e.g. Prism(width=w;
height=h).

The following declaration defines a type abbreviation if the named type A exists in the name
resolution environment. Otherwise it defines a union type.

```
type OneChoice = A
```

To disambiguate this case and declare an explicit union type, use the following:

```
type OneChoice =
| A
```
Union types are implicitly marked serializable unless the AutoSerializable(false) attribute is used.

### 8.5.1 Members in Union Types

Union types may declare members (§8.13), overrides, and interface implementations. As with all
types that declare overrides and interface implementations, they are subject to _Dispatch Slot
Checking_ (§14.8).

### 8.5.2 Structural Hashing, Equality, and Comparison for Union Types

Union types implicitly implement the following interfaces and dispatch slots unless they are explicitly
implemented as part of the definition of the union type:

```
interface System.Collections.IStructuralEquatable
interface System.Collections.IStructuralComparable
interface System.IComparable
override GetHashCode : unit -> int
override Equals : obj -> bool
```
The implicit implementations of these interfaces and overrides are described in §8.15.

### 8.5.3 With/End in Union Type Definitions

Union type definitions can include with/end tokens, as the following shows:

```
type R1 =
{ x : int;
y : int }
with
member this.Sum = this.x + this.y
end
```
The with/end tokens can be omitted if the type-defn-elements vertically align with the { in the
record-fields. The semicolon (;) tokens can be omitted if the next _record-field_ vertically aligns
with the previous _record-field_.

For union types, the with/end tokens can be omitted if the type-defn-elements vertically alignwith
the first | in the union-type-cases. However, with/end must be present if the | tokens align with the
type token. For example:

```
/// Note: this layout is permitted
type Message =
| Result of string
| Request of int * string
member x.Name = match x with Result(nm) -> nm | Request(_,nm) -> nm
```
```
/// Note: this layout is not permitted
type Message =
| Result of string
| Request of int * string
member x.Name = match x with Result(nm) -> nm | Request(_,nm) -> nm
```

### 8.5.4 Compiled Form of Union Types for Use from Other CLI Languages

A compiled union type U has:

- One CLI static getter property U.C for each null union case C. This property gets a singleton
    object that represents each such case.
- One CLI nested type U.C for each non-null union case C. This type has instance properties Item1,
    Item2.... for each field of the union case, or a single instance property Item if there is only one
    field. However, a compiled union type that has only one case does not have a nested type.
    Instead, the union type itself plays the role of the case type.
- One CLI static method U.NewC for each non-null union case C. This method constructs an object
    for that case.
- One CLI instance property U.IsC for each case C. This property returns true or false for the case.
- One CLI instance property U.Tag for each case C. This property fetches or computes an integer
    tag corresponding to the case.
- If U has more than one case, it has one CLI nested type U.Tags. The U.Tags typecontains one
    integer literal for each case, in increasing order starting from zero.
- A compiled union type has the methods that are required to implement its auto-generated
    interfaces, in addition to any user-defined properties or methods.

These methods and properties may not be used directly from F#. However, these types have user-
facing List.Empty, List.Cons, Option.None, and Option.Some properties and/or methods.

A compiled union type may not be used as a base type in another CLI language, because it has at
least one assembly-private constructor and no public constructors.

## 8.6 CLASS TYPE DEFINITIONS

A _class type definition_ encapsulates values that are constructed by using one or more object
constructors. Class types have the form:

```
type type-name patopt as-defnopt =
class
class-inherits-declopt
class-function-or-value-defnsopt
type-defn-elements
end
```
The class/end tokens can be omitted, in which case Type Kind Inference (§8.2) is used to determine
the kind of the type.

In F#, class types are implicitly marked serializable unless the AutoSerializable(false) attribute is
present.


### 8.6.1 Primary Constructors in Classes

An _object constructor_ represents a way of initializing an object. Object constructors can create values
of the type and can partially initialize an object from a subclass. A class can have an optional _primary
constructor_ and zero or more _additional object constructors_.

If a type definition has a pattern immediately after the _type-name_ and any accessibility annotation,
then it has a _primary constructor_. For example, the following type has a primary constructor:

```
type Vector2D(dx : float, dy : float) =
let length = sqrt(dx*x + dy*dy)
member v.Length = length
member v.DX = dx
member v.DY = dy
```
Class definitions that have a primary constructor may contain function and value definitions,
including those that use let rec.

The pattern for a primary constructor must have zero or more patterns of the following form:

```
( simple-pat , ..., simple-pat )
```
Each _simple-pat_ has this form:

```
simple-pat :=
| ident
| simple-pat : type
```
Specifically, nested patterns may not be used in the primary constructor arguments. For example,
the following is not permitted because the primary constructor arguments contain a nested tuple
pattern:

```
type TwoVectors((px, py), (qx, qy)) =
member v.Length = sqrt((qx-px)*(qx-px) + (qy-py)*(qy-py))
```
Instead, one or more value definitions should be used to accomplish the same effect:

```
type TwoVectors(pv, qv) =
let (px, py) = pv
let (qx, qy) = qv
member v.Length = sqrt((qx-px)*(qx-px) + (qy-py)*(qy-py))
```
When a primary constructor is evaluated, the inheritance and function and value definitions are
evaluated in order.

**8.6.1.1 Object References in Primary Constructors**
For types that have a primary constructor, the name of the object parameter can be bound and used
in the non-static function, value, and member definitions of the type definition as follows:

```
type X(a:int) as x =
let mutable currentA = a
let mutable currentB = 0
do x.B <- x.A + 3
member self.GetResult()= currentA + currentB
member self.A with get() = currentA and set v = currentA <- v
member self.B with get() = currentB and set v = currentB <- v
```

During construction, no member on the type may be called before the last value or function
definition in the type has completed; such a call results in an InvalidOperationException. For
example, the following code raises this exception:

```
type C() as self =
let f = (fun (x:C) -> x.F())
let y = f self
do printfn "construct"
member this.F() = printfn "hi, y = %A" y
```
```
let r = new C() // raises InvalidOperationException
```
The exception is raised because an attempt may be made to access the value of the field y before
initialization is complete.

**8.6.1.2 Inheritance Declarations in Primary Constructors**
An inherit declaration specifies that the type being defined is an extension of an existing type. Such
declarations have the following form:

```
class-inherits-decl := inherit type expropt
```
For example:

```
type MyDerived(...) =
inherit MyBase(...)
```
If a class definition does not contain an inherit declaration, the class inherits fromSystem.Object by
default.

The inherit declaration for a type must have arguments if and only if the type has a primary
constructor.

Unlike §8.6.1.2, members of a base type can be accessed during construction of the derived class.
For example, the following code does not raise an exception:

```
type B() =
member this.G() = printfn "hello "
```
```
type C() as self =
inherit B()
let f = (fun (x:C) -> x.G())
let y = f self
do printfn "construct"
member this.F() = printfn "hi, y = %A" y
```
```
let r = new C() // does not raise InvalidOperationException
```
**8.6.1.3 Instance Function and Value Definitions in Primary Constructors**
Classes that have primary constructors may include function definitions, value definitions, and “do”
statements. The following rules apply to these definitions:

- Each definition may be marked static (see §8.6.2.1). If the definition is not marked static, it is
    called an instance definition.


- The functions and values defined by instance definitions are lexically scoped (and thus implicitly
    private) to the object being defined.
- Each value definition may optionally be marked mutable.
- A group of function and value definitions may optionally be marked rec.
- Function and value definitions are generalized.
- Value definitions that declared in classes are represented in compiled code as follows:
    - If a value definition is not mutable, and is not used in any function or member, then the
       value is represented as a local value in the object constructor.
    - If a value definition is mutable, or used in any function or member, then the value is
       represented as an instance field in the corresponding CLI type.
- Function definitions are represented in compiled code as private members of the corresponding
    CLI type.
    For example, consider this type:
       type C(x:int,y:int) =
       let z = x + y
       let f w = x + w
       member this.Z = z
       member this.Add(w) = f w

```
The input y is used only during construction, and no field is stored for it. Likewise the function f
is represented as a member rather than a field that is a function value.
```
A value definition is considered a function definition if its immediate right-hand-side is an
anonymous function, as in this example:

```
let f = (fun w -> x + w)
```
Function and value definitions may have attributes as follows:

- Value definitions represented as fields may have attributes that target fields.
- Value definitions represented as locals may have attributes that target fields, but these
    attributes will not be attached to any construct in the resulting CLI assembly.
- Function definitions represented as methods may have attributes that target methods.

For example:

```
type C(x:int) =
[<System.Obsolete>]
let unused = x
member __.P = 1
```
In this example, no field is generated for unused, and no corresponding compiled CLI attribute is
generated.

**8.6.1.4 Static Function and Value Definitions in Primary Constructors**
Classes that have primary constructors may have function definitions, value definitions, and “do”
statements that are marked as static:


- The values that are defined by static function and value definitions are lexically scoped (and thus
    implicitly private) to the type being defined.
- Each value definition may optionally be marked mutable.
- A group of function and value definitions may optionally be marked rec.
- Static function and value definitions are generalized.
- Static function and value definitions are computed once per generic instantiation.
- Static function and value definitions are elaborated to a _static initializer_ associated with each
    generic instantiation of the generated class. Static initializers are executed on demand in the
    same way as static initializers for implementation files §12.5.
- The compiled representation for static value definitions is as follows:
    - If the value is not used in any function or member then the value is represented as a local
       value in the CLI class initializer of the type.
    - If the value is used in any function or member, then the value is represented as a static field
       of the CLI class for the type.
- The compiled representation for a static function definition is a private static member of the
    corresponding CLI type.

Static function and value definitions may have attributes as follows:

- Static function and value definitions represented as fields may have attributes that target fields.
- Static function and value definitions represented as methods may have attributes that target
    methods.

For example:

```
type C<'T>() =
static let mutable v = 2 + 2
static do v <- 3
```
```
member x.P = v
static member P2 = v+v
```
```
printfn "check: %d = 3" (new C<int>()).P
printfn "check: %d = 3" (new C<int>()).P
printfn "check: %d = 3" (new C<string>()).P
printfn "check: %d = 6" (C<int>.P2)
printfn "check: %d = 6" (C<string>.P2)
```
In this example, the value v is represented as a static field in the CLI type for C. One instance of this
field exists for each generic instantiation of C. The output of the program is

```
check: 3 = 3
check: 3 = 3
check: 3 = 3
check: 6 = 6
check: 6 = 6
```

### 8.6.2 Members in Classes

Class types may declare members (§8.13), overrides, and interface implementations. As with all
types that have overrides and interface implementations, such class types are subject to _Dispatch
Slot Checking_ (§14.8).

### 8.6.3 Additional Object Constructors in Classes

Although the use of primary object constructors is generally preferable, additional object
constructors may also be specified. Additional object constructors are required in two situations:

- To define classes that have more than one constructor.
- To specify explicit val fields without the DefaultValue attribute.

For example, the following statement adds a second constructor to a class that has a primary
constructor:

```
type PairOfIntegers(x:int,y:int) =
new (x) = PairOfIntegers(x,x)
```
The next example declares a class without a primary constructor:

```
type PairOfStrings =
val s1 : string
val s2 : string
new (s) = { s1 = s; s2 = s }
new (s1,s2) = { s1 = s1; s2 = s2 }
```
If a primary constructor is present, additional object constructors must call another object
constructor in the same type, which may be another additional constructor or the primary
constructor.

If no primary constructor is present, additional constructors must initialize any val fields of the
object that do not have the DefaultValue attribute. They must also specify a call to a base class
constructor for any inherited class type. A call to a base class constructor is not required if the base
class is System.Object.

The use of additional object constructors and val fields is required if a class has multiple object
constructors that must each call different base class constructors. For example:

```
type BaseClass =
val s1 : string
new (s) = { s1 = s }
new () = { s 1 = "default" }
```
```
type SubClass =
inherit BaseClass
val s2 : string
new (s1,s2) = { inherit BaseClass(s1); s2 = s2 }
new (s2) = { inherit BaseClass(); s2 = s2 }
```
To implement additional object constructors, F# uses a restricted subset of expressions that ensure
that the code generated for the constructor is valid according to the rules of object construction for


CLI objects. Note that precisely one _additional-constr-init-expr_ occurs for each branch of a
construction expression.

For classes without a primary constructor, side effects can be performed after the initialization of
the fields of the object by using the _additional-constr-expr_ then _stmt_ form. For example:

```
type PairOfIntegers(x:int,y:int) =
// This additional constructor has a side effect after initialization.
new(x) =
PairOfIntegers(x, x)
then
printfn "Initialized with only one integer"
```
The name of the object parameter can be bound within additional constructors. For example:

```
type X =
val a : (unit -> string)
val mutable b : string
new() as x = { a = (fun () -> x.b); b = "b" }
```
A warning is given if x occurs syntactically in or before the _additional-constr-init-expr_ of the
construction expression. If any member is called before the completion of execution of the
_additional-constr-init-expr_ within the _additional-constr-expr_ then an InvalidOperationException
is thrown.

### 8.6.4 Additional Fields in Classes

Additional field declarations indicate that a value is stored in an object. They are generally used only
for classes without a primary constructor, or for mutable fields that use default initialization, and
typically occur only in generated code. For example:

```
type PairOfIntegers =
val x : int
val y : int
new(x, y) = {x = x; y = y}
```
The following shows an additional field declaration as a static field in an explicit class type:

```
type TypeWithADefaultMutableBooleanField =
[<DefaultValue>]
static val mutable ready : bool
```
At runtime, such a field is initially assigned the zero value for its type (§6.9.3). For example:

```
type MyClass(name:string) =
// Keep a global count. It is initially zero.
[<DefaultValue>]
static val mutable count : int
```
```
// Increment the count each time an object is created
do MyClass.count <- MyClass.count + 1
```
```
static member NumCreatedObjects = MyClass.count
```
```
member x.Name = name
```

A val specification in a type that has a primary constructor must be marked mutable and must have
the DefaultValue attribute. For example:

```
type X() =
[<DefaultValue>]
val mutable x : int
```
The DefaultValue attribute takes a check parameter, which indicates whether to ensure that the val
specification does not create unexpected null values. The default value for check is true. If this
parameter is true, the type of the field must permit default initialization (§5.4.8). For example, the
following type is rejected:

```
type MyClass<'T>() =
[<DefaultValue>]
static val mutable uninitialized : 'T
```
The reason is that the type 'T does not admit default initialization. However, in compiler-generated
and hand-optimized code it is sometimes essential to be able to emit fields that are completely
uninitialized. In this case, DefaultValue(false) can be used. For example:

```
type MyNullable<'T>() =
[<DefaultValue>]
static val mutable ready : bool
```
```
[<DefaultValue(false)>]
static val mutable uninitialized : 'T
```
## 8.7 INTERFACE TYPE DEFINITIONS...................................................................................................

An _interface type definition_ represents a contract that an object may implement. Such a type
definition containsonly abstract members. For example:

```
type IPair<'T,'U> =
interface
abstract First: 'T
abstract Second: 'U
end
```
```
type IThinker<'Thought> =
abstract Think: ('Thought -> unit) -> unit
abstract StopThinking: (unit -> unit)
```
```
Note: The interface/end tokens can be omitted when lightweight syntax is used, in
which case Type Kind Inference (§8.2) is used to determine the kind of the type. The
presence of any non-abstract members or constructors means a type is not an interface
type.
```
```
By convention, interface type names start with I, as in IEvent. However, this convention
is not followed as strictly in F# as in other CLI languages.
```
Interface types may be arranged hierarchically by specifying inherit declarations. For example:

```
type IA =
abstract One: int -> int
```

```
type IB =
abstract Two: int -> int
```
```
type IC =
inherit IA
inherit IB
abstract Three: int -> int
```
Each inherit declaration must itself be an interface type. Circular references are not allowed among
inherit declarations. F# uses the named types of the inherited interface types to determine
whether references are circular.

## 8.8 STRUCT TYPE DEFINITIONS

A _struct type definition_ is a type definition whose instances are stored inline inside the stack frame or
object of which they are a part. The type is represented as a CLI struct type, also called a _value type_.
For example:

```
type Complex =
struct
val real: float;
val imaginary: float
member x.R = x.real
member x.I = x.imaginary
end
```
```
Note: The struct/end tokens can be omitted when lightweight syntax is used, in which
case Type Kind Inference (§8.2) is used to determine the kind of the type.
```
Becaues structs undergo type kind inference (§8.2), the following is valid:

```
[<Struct>]
type Complex(r:float, i:float) =
member x.R = r
member x.I = i
```
Structs may have primary constructors:

```
[<Struct>]
type Complex(r : float, I : float) =
member x.R = r
member x.I = i
```
Structs that have primary constructors must accept at least one argument.

Structs may have additional constructors. For example:

```
[<Struct>]
type Complex(r : float, I : float) =
member x.R = r
member x.I = i
new(r : float) = new Complex(r, 0.0)
```

The fields in a struct may be mutable only if the struct does not have a primary constructor. For
example:

```
[<Struct>]
type MutableComplex =
val mutable real : float;
val mutable imaginary : float
member x.R = x.real
member x.I = x.imaginary
member x.Change(r, i) = x.real <- r; x.imaginary <- i
new (r, i) = { real = r; imaginary = i }
```
Struct types may declare members, overrides, and interface implementations. As for all types that
declare overrides and interface implementations, struct types are subject to _Dispatch Slot Checking_
(§14.8).

Structs may not have inherit declarations.

Structs may not have “let” or “do” statements unless they are static. For example, the following is
not valid:

```
[<Struct>]
type BadStruct1 (def : int) =
do System.Console.WriteLine("Structs cannot use 'do'!")
```
Structs may have static “let” or “do” statements. For example, the following is valid:

```
[<Struct>]
type GoodStruct1 (def : int) =
static do System.Console.WriteLine("Structs can use 'static do'")
```
A struct type must be valid according to the CLI rules for structs; in particular, recursively
constructed structs are not permitted. For example, the following type definition is not permitted,
because the size of BadStruct2 would be infinite:

```
[<Struct>]
type BadStruct 2 =
val data : float;
val rest : BadStruct 2
new (data, rest) = { data = data; rest = rest }
```
Likewise, the implied size of the following struct would be infinite:

```
[<Struct>]
type BadStruct 3 (data : float, rest : BadStruct 3 ) =
member s.Data = data
member s.Rest = rest
```
If the types of all the fields in a struct type permit default initialization, the struct type has an _implicit
default constructor_ ,which initializes all the fields to the default value. For example, the Complex type
defined earlier in this section permits default initialization.

```
[<Struct>]
type Complex(r : float, I : float) =
member x.R = r
member x.I = i
```

```
new(r : float) = new Complex(r, 0.0)
```
```
let zero = Complex()
```
```
Note : The existence of the implicit default constructor for structs is not recorded in CLI
metadata and is an artifact of the CLI specification and implementation itself. A CLI
implementation permits default constructors for all struct types, although F# does not
permit their direct use for F# struct types unless all field types admit default
initialization. This is similar to the way that F# considers some types to have null as an
abnormal value.
```
```
Public struct types for use from other CLI languages should be designed with the
existence of the default zero-initializing constructor in mind.
```
## 8.9 ENUM TYPE DEFINITIONS

Occasionally the need arises to represent a type that compiles as a CLI enumeration type. An _enum
type definition_ has values that are represented by integer constants and has a CLI enumeration as its
compiled form. Enum type definitions are declared by specifying integer constants in a format that is
syntactically similar to a union type definition. For example:

```
type Color =
| Red = 0
| Green = 1
| Blue = 2
```
```
let rgb = (Color.Red, Color.Green, Color.Blue)
```
```
let show(colorScheme) =
match colorScheme with
| (Color.Red, Color.Green, Color.Blue) -> printfn "RGB in use"
| _ -> printfn "Unknown color scheme in use"
```
The example defines the enum type Color, which has the values Red, Green, and Blue, mapped to
the constants 0, 1, and 2 respectively. The values are accessed by their qualified names: Color.Red,
Color.Green, and Color.Blue.

Each case must be given a constant value of the same type. The constant values dictate the
_underlying type_ of the enum, and must be one of the following types:

- sbyte, int16, int32, int 64 , byte, uint16, uint32, uint64, char

The declaration of an enumeration type in an implementation file has the following effects on the
typing environment:

- Brings a named type into scope.
- Adds the named type to the inferred signature of the containing namespace or module.

Enum types coerce to System.Enum and satisfy the enum< _underlying-type_ > constraint for their
underlying type.


Each enum type declaration is implicitly annotated with the RequiresQualifiedAccess attribute and
does not add the tags of the enumeration to the name environment.

```
type Color =
| Red = 0
| Green = 1
| Blue = 2
```
```
let red = Red // not accepted, must use Color.Red
```
Unlike unions, enumeration types are fundamentally “incomplete,” because CLI enumerations can
be converted to and from their underlying primitive type representation. For example, a Color value
that is not in the above enumeration can be generated by using the enum function from the F#
library:

```
let unknownColor : Color = enum<Color>(7)
```
This statement adds the value named unknownColor, equal to the constant 7, to the Color
enumeration.

## 8.10 DELEGATE TYPE DEFINITIONS

Occasionally the need arises to represent a type that compiles as a CLI delegate type. A _delegate
type definition_ has as its values functions that are represented as CLI delegate values. A delegate
type definition is declared by using the delegate keyword with a member signature. For example:

```
type Handler<'T> = delegate of obj * 'T -> unit
```
Delegates are often used when using Platform Invoke (P/Invoke) to interface with CLI libraries, as in
the following example:

```
type ControlEventHandler = delegate of int -> bool
```
```
[<DllImport("kernel32.dll")>]
extern void SetConsoleCtrlHandler(ControlEventHandler callback, bool add)
```
## 8.11 EXCEPTION DEFINITIONS..........................................................................................................

An _exception definition_ defines a new way of constructing values of type exn (a type abbreviation for
System.Exception). Exception definitions have the form:

```
exception ident of type 1 * ... * typen
```
An exception definition has the following effect:

- The identifier _ident_ can be used to generate values of type exn.
- The identifier _ident_ can be used to pattern match on values of type exn.
- The definition generates a type with name _ident_ that derives from exn.

For example:


```
exception Error of int * string
raise (Error (3, "well that didn't work did it"))
```
```
try
raise (Error (3, "well that didn't work did it"))
with
| Error(sev, msg) -> printfn "severity = %d, message = %s" sev msg
```
The type that corresponds to the exception definition can be used as a type in F# code. For example:

```
let exn = Error (3, "well that didn't work did it")
let checkException() =
if (exn :? Error) then printfn "It is of type Error"
if (exn.GetType() = typeof<Error>) then printfn "Yes, it really is of type Error"
```
Exception abbreviations may abbreviate existing exception constructors. For example:

```
exception ThatWentBadlyWrong of string * int
exception ThatWentWrongBadly = ThatWentBadlyWrong
```
```
let checkForBadDay() =
if System.DateTime.Today.DayOfWeek = System.DayOfWeek.Monday then
raise (ThatWentWrongBadly("yes indeed",123))
```
Exception values may also be generated by defining and using classes that extend System.Exception.

## 8.12 TYPE EXTENSIONS

A _type extension_ associates additional members with an existing type. For example, the following
associates the additional member IsLong with the existing type System.String:

```
type System.String with
member x.IsLong = (x.Length > 1000)
```
Type extensions may be applied to any accessible type definition except those defined by type
abbreviations. For example, to add an extension method to a list type, use 'a List because 'a list
is a type abbreviation of 'a List. For example:

```
type 'a List with
member x.GetOrDefault(n) =
if x.Length > n then x.[n]
else Unchecked.defaultof<'a>
let intlst = [1; 2; 3]
intlst.GetOrDefault(1) //2
intlst.GetOrDefault(4) //0
```
For an array type, backtick marks can be used to define an extension method to the array type:

```
type 'a ``[]`` with
member x.GetOrDefault(n) =
if x.Length > n then x.[n]
else Unchecked.defaultof<'a>
let arrlist = [| 1; 2; 3 |]
arrlist.GetOrDefault(1) //2
```

```
arrlist.GetOrDefault(4) //0
```
A type can have any number of extensions.

If the type extension is in the same module or namespace declaration group as the original type
definition, it is called an _intrinsic extension_. Members that are defined in intrinsic extensions follow
the same name resolution and other language rules as members that are defined as part of the
original type definition.

If the type extension is not intrinsic, it must be in a module, and it is called an _extension member_.
Opening a module that contains an extension member extends the name resolution of the dot
syntax for the extended type. That is, extension members are accessible only if the module that
contains the extension is open.

Name resolution for members that are defined in type extensions behaves as follows:

- In method application resolution (see §14.4), regular members (that is, members that are part of
    the original definition of a type, plus intrinsic extensions) are preferred to extension members.
- Extension members that are in scope and have the correct name are included in the group of
    members considered for method application resolution (see §14.4).
- An intrinsic member is always preferred to an extension member. If an extension member has
    the same name and type signature as a member in the original type definition or an inherited
    member, then it will be inaccessible.

The following illustrates the definition of one intrinsic and one extension member for the same type:

```
namespace Numbers
type Complex(r : float, i : float) =
member x.R = r
member x.I = i
```
```
// intrinsic extension
type Complex with
static member Create(a, b) = new Complex (a, b)
member x.RealPart = x.R
member x.ImaginaryPart = x.I
```
```
namespace Numbers
```
```
module ComplexExtensions =
```
```
// extension member
type Numbers.Complex with
member x.Magnitude = ...
member x.Phase = ...
```
Extensions may define both instance members and static members.

Extensions are checked as follows:

- Checking applies to the member definitions in an extension together with the members and
    other definitions in the group of type definitions of which the extension is a part.


- Two intrinsic extensions may not contain conflicting members because intrinsic extensions are
    considered part of the definition of the type.
- Extensions may not define fields, interfaces, abstract slots, inherit declarations, or dispatch slot
    (interface and override) implementations.
- Extension members must be in modules.
- Extension members are compiled as CLI static members with encoded names.
    - The elaborated form of an application of a static extension member _C_. _M_ (arg 1 ,..., _argn_ ) is a call
       to this static member with arguments arg 1 ,..., _argn_ ..
    - The elaborated form of an application of an instance extension member _obj_. _M_ (arg 1 ,..., _argn_ )
       is an invocation of the static instance member where the object parameter is supplied as the
       first argument to the extension member followed by arguments arg 1 ... _argn_.

### 8.12.1 Imported CLI C# Extensions Members

The CLI C# language defines an “extension member,” which commonly occurs in CLI libraries, along
with some other CLI languages. C# limits extension members to instance methods.

C#-defined extension members are made available to F# code in environments where the C#-
authored assembly is referenced and an open declaration of the corresponding namespace is in
effect.

The encoding of compiled names for F# extension members is not compatible with C# encodings of
C# extension members. However, for instance extension methods, the naming can be made
compatible. For example:

```
open System.Runtime.CompilerServices
```
```
[<Extension>]
module EnumerableExtensions =
[<CompiledName("OutputAll"); Extension>]
type System.Collections.Generic.IEnumerable<'T> with
member x.OutputAll (this:seq<'T>) =
for x in this do
System.Console.WriteLine (box x)
```
C#-style extension members may also be declared directly in F#. When combined with the “inline”
feature of F#, this allows the definition of generic, constrained extension members that are not
otherwise definable in C# or F#.

```
[<Extension>]
type ExtraCSharpStyleExtensionMethodsInFSharp () =
[<Extension>]
static member inline Sum(xs: seq<'T>) = Seq.sum xs
```
Such an extension member can be used as follows:

```
let listOfIntegers = [ 1 .. 100 ]
let listOfBigIntegers = [ 1I .. 100I ]
listOfIntegers.Sum()
listOfBigIntegers.Sum()
```

## 8.13 MEMBERS

Member definitions describe functions that are associated with type definitions and/or values of
particular types. Member definitions can be used in type definitions. Members can be classified as
follows:

- Property members
- Method members

A _static member_ is prefixed by static and is associated with the type, rather than with any particular
object. Here are some examples of static members:

```
type MyClass() =
static let mutable adjustableStaticValue = "3"
static let staticArray = [| "A"; "B" |]
static let staticArray2 = [|[| "A"; "B" |]; [| "A"; "B" |] |]
```
```
static member StaticMethod(y:int) = 3 + 4 + y
```
```
static member StaticProperty = 3 + staticArray.Length
```
```
static member StaticProperty2
with get() = 3 + staticArray.Length
```
```
static member MutableStaticProperty
with get() = adjustableStaticValue
and set(v:string) = adjustableStaticValue <- v
```
```
static member StaticIndexer
with get(idx) = staticArray.[idx]
```
```
static member StaticIndexer2
with get(idx1,idx2) = staticArray2.[idx1].[idx2]
```
```
static member MutableStaticIndexer
with get (idx1) = staticArray.[idx1]
and set (idx1) (v:string) = staticArray.[idx1] <- v
```
An _instance member_ is a member without static. Here are some examples of instance members:

```
type MyClass() =
let mutable adjustableInstanceValue = "3"
let instanceArray = [| "A"; "B" |]
let instanceArray2 = [| [| "A"; "B" |]; [| "A"; "B" |] |]
```
```
member x.InstanceMethod(y:int) = 3 + y + instanceArray.Length
```
```
member x.InstanceProperty = 3 + instanceArray.Length
```
```
member x.InstanceProperty2
with get () = 3 + instanceArray.Length
```
```
member x.InstanceIndexer
with get (idx) = instanceArray.[idx]
```
```
member x.InstanceIndexer2
with get (idx1,idx2) = instanceArray2.[idx1].[idx2]
```

```
member x.MutableInstanceProperty
with get () = adjustableInstanceValue
and set (v:string) = adjustableInstanceValue <- v
```
```
member x.MutableInstanceIndexer
with get (idx1) = instanceArray.[idx1]
and set (idx1) (v:string) = instanceArray.[idx1] <- v
```
Members from a set of mutually recursive type definitions are checked as a single mutually recursive
group. As with collections of recursive functions, recursive calls to potentially-generic methods may
result in inconsistent type constraints:

```
type Test() =
static member Id x = x
member t.M1 (x: int) = Test.Id(x)
member t.M2 (x: string) = Test.Id(x) // error, x has type 'string' not 'int'
```
A target method that has a full type annotation is eligible for early generalization (§14.6.7).

```
type Test() =
static member Id<'T> (x:'T) : 'T = x
member t.M1 (x: int) = Test.Id(x)
member t.M2 (x: string) = Test.Id(x)
```
### 8.13.1 Property Members

A _property member_ is a _method-or-prop-defn_ in one of the following forms:

```
static opt member ident. opt ident = expr
static opt member ident. opt ident with get pat = expr
static opt member ident. opt ident with set patopt pat = expr
static opt member ident. opt ident with get pat = expr and set patopt pat = expr
static opt member ident. opt ident with set patopt pat = expr and get pat = expr
```
A property member in the form

```
static opt member ident. opt ident with get pat 1 = expr 1 and set pat2a pat2b opt = expr 2
```
is equivalent to two property members of the form:

```
static opt member ident. opt ident with get pat 1 = expr 1
```
static _opt_ member _ident_. _opt ident_ with set _pat2a pat2b_ (^) opt = _expr 2_
Furthermore, the following two members are equivalent:
static _opt_ member _ident_. _opt ident_ = _expr_
static _opt_ member _ident_. _opt ident_ with get () = _expr_
These two are also equivalent:
static _opt_ member _ident_. _opt ident_ with set _pat_ = _expr 2_
static _opt_ member _ident_. _opt ident_ with set () _pat_ = _expr_
Thus, property members may be reduced to the following two forms:
static _opt_ member _ident_. _opt ident_ with get _patidx_ = _expr_
static _opt_ member _ident_. _opt ident_ with set _patidx pat_ = _expr_


The _ident_. _opt_ must be present if and only if the property member is an instance member. When
evaluated, the identifier _ident_ is bound to the “this” or “self” object parameter that is associated
with the object within the expression _expr_.

A property member is an _indexer property_ if _patidx_ is not the unit pattern (). Indexer properties
called Item are special in the sense that they are accessible via the .[] notation. An Item property
that takes one argument is accessed by using x.[i]; with two arguments by x.[i,j], and so on.
Setter properties must return type unit.

```
Note : As of F# 3. 1 , the special .[] notation for Item properties is available only for
instance members. A static indexer property cannot be accessible by using the .[]
notation.
```
Property members may be declared abstract. If a property has both a getter and a setter, then both
must be abstract or neither must be abstract.

Each property member has an implied property type. The property type is the type of the value that
the getter property returns or the setter property accepts. If a property member has both a getter
and a setter, and neither is an indexer property, the signatures of both the getter and the setter
must imply the same property type.

Static and instance property members are evaluated every time the member is invoked. For
example, in the following, the body of the member is evaluated each time C.Time is evaluated:

```
type C () =
static member Time = System.DateTime.Now
```
Note that a static property member may also be written with an explicit get method:

static member ComputerName
with get() = System.Environment.GetEnvironmentVariable("COMPUTERNAME")

Property members that have the same name may not appear in the same type definition even if
their signatures are different. For example:

```
type C () =
static member P = false // error: Duplicate property.
member this.P = true
```
However, methods that have the same name can be overloaded when their signatures are different.

### 8.13.2 Auto-implemented Properties

Properties can be declared in two ways: either explicitly specified with the underlying value or
automatically generated by the compiler. The compiler creates a backing field automatically if all of
the following are true for the declaration:

- The declaration uses the member val keywords.
- The declaration omits the self-identifier.
- The declaration includes an expression to initialize the property.

To create a mutable property, include with get, with set,or both:


```
static opt member val accessopt ident : tyopt = expr
static opt member val accessopt ident : tyopt = expr with get
static opt member val accessopt ident : tyopt = expr with set
static opt member val accessopt ident : tyopt = expr with get, set
```
Automatically implemented properties are part of the initialization of a type, so they must be
included before any other member definitions, in the same way as let bindings and do bindings in a
type definition. The expression that initializes an automatically implemented property is evaluated
only at initialization, and not every time the property is accessed. This behavior is different from the
behavior of an explicitly implemented property.

For example, the following class type includes two automatically implemented properties. Property1
is read-only and is initialized to the argument provided to the primary constructor and Property2 is a
settable property that is initialized to an empty string:

```
type D (x:int) =
member val Property1 = x
member val Property2 = "" with get, set
```
Auto-implemented properties can also be used to implement default or override properties:

```
type MyBase () =
abstract Property : string with get, set
default val Property = “default” with get, set
```
```
type MyDerived() =
inherit MyBase()
override val Property = "derived" with get, set
```
The following example shows how to use an auto-implemented property to implement an interface:

```
type MyInterface () =
abstract Property : string with get, set
```
```
type MyImplementation () =
interface MyInterface with
member val Property = "implemented" with get, set
```
### 8.13.3 Method Members

A _method member_ is of the form:

```
static opt member ident. opt ident pat 1 ... patn = expr
```
The _ident_. _opt_ can be present if and only if the property member is an instance member. In this case,
the identifier _ident_ corresponds to the “this” (or “self”) variable associated with the object on which
the member is being invoked.

Arity analysis (§14.10) applies to method members. This is because F# members must compile to CLI
methods, which accept only a single fixed collection of arguments.

### 8.13.4 Curried Method Members

Methods that take multiple arguments may be written in iterated (“curried”) form. For example:

```
static member StaticMethod2 s1 s2 =
```

```
sprintf "In StaticMethod(%s,%s)" s1 s2
```
The rules of arity analysis (§14.10) determine the compiled form of these members.

The following limitations apply to curried method members:

- Additional argument groups may not include optional or byref parameters.
- When the member is called, additional argument groups may not use named
    arguments(§8.13.5).
- Curried members may not be overloaded.

The compiled representation of a curried method member is a .NET method in which the arguments
are concatenated into a single argument group.

```
Note : It is recommended that curried argument members do not appear in the public
API of an F# assembly that is designed for use from other .NET languages. Information
about the currying order is not visible to these languages.
```
### 8.13.5 Named Arguments to Method Members

Calls to methods—but not to let-bound functions or function values—may use named arguments.
For example:

```
System.Console.WriteLine(format = "Hello {0}", arg0 = "World")
System.Console.WriteLine("Hello {0}", arg0 = "World")
System.Console.WriteLine(arg0 = "World", format = "Hello {0}")
```
The argument names that are associated with a method declaration are derived from the names
that appear in the first pattern of a member definition, or from the names used in the signature for a
method member. For example:

```
type C() =
member x.Swap(first, second) = (second, first)
let c = C()
c.Swap(first = 1,second = 2) // result is '(2,1)'
c.Swap(second = 1,first = 2) // result is '(1,2)'
```
Named arguments may be used only with the arguments that correspond to the arity of the
member. That is, because members have an arity only up to the first set of tupled arguments, named
arguments may not be used with subsequent curried arguments of the member.

The resolution of calls that use named arguments is specified in _Method Application Resolution_ (see
§14.4). The rules in that section describe how resolution matches a named argument with either a
formal parameter of the same name or a “settable” return property of the same name. For example,
the following code resolves the named argument to a settable property:

```
System.Windows.Forms.Form(Text = "Hello World")
```
If an ambiguity exists, assigning the named argument is assigned to a formal parameter rather than
to a settable return property.

The _Method Application Resolution_ (§14.4) rules ensure that:


- Named arguments must appear after all other arguments, including optional arguments that
    are matched by position.

After named arguments have been assigned, the remaining required arguments are called the
_required unnamed arguments_. The required unnamed arguments must precede the named
arguments in the argument list. The _n_ unnamed arguments are matched to the first _n_ formal
parameters; the subsequent named arguments must include only the remaining formal parameters.
In addition, the arguments must appear in the correct sequence.

For example, the following code is invalid:

```
// error: unnamed args after named
System.Console.WriteLine(arg0 = "World", "Hello {0}")
```
Similarly, the following code is invalid:

```
type Foo() =
static member M (arg1, arg2, arg3) = 1
// error: arg1, arg3 not a prefix of the argument list
Foo.M(1, 2, arg2 = 3)
```
The following code is valid:

```
type Foo() =
static member M (arg1, arg2, arg3) = 1
```
```
Foo.M (1, 2, arg 3 = 3)
```
The names of arguments to members may be listed in member signatures. For example, in a
signature file:

```
type C =
static member ThreeArgs : arg1:int * arg2:int * arg3:int -> int
abstract TwoArgs : arg1:int * arg2:int -> int
```
### 8.13.6 Optional Arguments to Method Members

Method members—but not functions definitions—may have optional arguments. Optional
arguments must appear at the end of the argument list. An optional argument is marked with a?
before its name in the method declaration. Inside the member, the argument has type
option< _argType_ >.

The following example declares a method member that has two optional arguments:

```
let defaultArg x y = match x with None -> y | Some v -> v
```
```
type T() =
static member OneNormalTwoOptional (arg1, ?arg2, ?arg3) =
let arg2 = defaultArg arg2 3
let arg3 = defaultArg arg3 10
arg1 + arg2 + arg3
```
Optional arguments may be used in interface and abstract members. In a signature, optional
arguments appear as follows:


```
static member OneNormalTwoOptional : arg1:int * ?arg2:int * ?arg3:int -> int
```
Callers may specify values for optional arguments in the following ways:

- By name, such as arg2 = 1.
- By propagating an existing optional value by name, such as ?arg2=None or ?arg2=Some(3) or
    ?arg2=arg2. This can be useful when building a method that passes optional arguments on to
    another method.
- By using normal, unnamed arguments that are matched by position.

For example:

```
T.OneNormalTwoOptional(3)
T.OneNormalTwoOptional(3, 2)
T.OneNormalTwoOptional(arg1 = 3)
T.OneNormalTwoOptional(arg1 = 3, arg2 = 1)
T.OneNormalTwoOptional(arg2 = 3, arg1 = 0)
T.OneNormalTwoOptional(arg2 = 3, arg1 = 0, arg3 = 11)
T.OneNormalTwoOptional(0, 3, 11)
T.OneNormalTwoOptional(0, 3, arg3 = 11)
T.OneNormalTwoOptional(arg1 = 3, ?arg2 = Some 1)
T.OneNormalTwoOptional(arg2 = 3, arg1 = 0, arg3 = 11)
T.OneNormalTwoOptional(?arg2 = Some 3, arg1 = 0, arg3 = 11)
T.OneNormalTwoOptional(0, 3, ?arg3 = Some 11)
```
The resolution of calls that use optional arguments is specified in _Method Application Resolution_ (see
§14.4).

Optional arguments may not be used in member constraints.

```
Note : Imported CLI metadata may specify arguments as optional and may additionally
specify a default value for the argument. These are treated as F# optional arguments. CLI
optional arguments can propagate an existing optional value by name; for example,
?ValueTitle = Some (...).
```
```
For example, here is a fragment of a call to a Microsoft Excel COM automation API that
uses named and optional arguments.
chartobject.Chart.ChartWizard(Source = range5,
Gallery = XlChartType.xl3DColumn,
PlotBy = XlRowCol.xlRows,
HasLegend = true,
Title = "Sample Chart",
CategoryTitle = "Sample Category Type",
ValueTitle = "Sample Value Type")
```
```
CLI optional arguments are not passed as values of type Option<_>. If the optional
argument is present, its value is passed. If the optional argument is omitted, the default
value from the CLI metadata is supplied instead. The value
System.Reflection.Missing.Value is supplied for any CLI optional arguments of type
System.Object that do not have a corresponding CLI default value, and the default (zero-
bit pattern) value is supplied for other CLI optional arguments of other types that have
no default value.
```

The compiled representation of members varies as additional optional arguments are added. The
addition of optional arguments to a member signature results in a compiled form that is not binary-
compatible with the previous compiled form.

Marking an argument as optional is equivalent to adding the FSharp.Core.OptionalArgument
attribute (§17.1) to a required argument. This attribute is added implicitly for optional arguments.
Adding the [<OptionalArgument>] attribute to a parameter of type 'a option in a virtual method
signature is equivalent to using the (?x:'a) syntax in a method definition. If the attribute is applied
to an argument of a method, it should also be applied to all subsequent arguments of the method.
Otherwise, it has no effect and callers must provide all of the arguments.

### 8.13.7 Type-directed Conversions at Member Invocations

As described in _Method Application Resolution_ (see §14.4), three type-directed conversions are
applied at method invocations.

**8.13.7.1 Conversion to Delegates**
The first type-directed conversion converts anonymous function expressions and other function-
valued arguments to delegate types. Given:

- A formal parameter of delegate type _D_
- An actual argument _farg_ of known type _ty 1_ - > ... -> _tyn_ - > _rty_
- Precisely _n_ arguments to the Invoke method of delegate type _D_

Then:

- The parameter is interpreted as if it were written:

```
new D (fun arg 1 ... argn - > farg arg 1 ... argn )
```
If the type of the formal parameter is a variable type, then F# uses the known inferred type of the
argument including instantiations to determine whether a formal parameter has delegate type. For
example, if an explicit type instantiation is given that instantiates a generic type parameter to a
delegate type, the following conversion can apply:

```
type GenericClass<'T>() =
static member M(arg: 'T) = ()
```
```
GenericClass<System.Action>.M(fun () -> ()) // allowed
```
**8.13.7.2 Conversion to Reference Cells**
The second type-directed conversion enables an F# reference cell to be passed where a byref< _ty_ > is
expected. Given:

- A formal out parameter of type byref< _ty_ >
- An actual argument that is not a byref type

Then:

- The actual parameter is interpreted as if it had type ref< _ty_ >.


For example:

```
type C() =
static member M1(arg: System.Action) = ()
static member M2(arg: byref<int>) = ()
```
```
C.M1(fun () -> ()) // allowed
let f = (fun () -> ()) in C.M1(f) // not allowed
```
```
let result = ref 0
C.M2(result) // allowed
```
```
Note: These type-directed conversions are primarily for interoperability with existing
member-based .NET libraries and do not apply at invocations of functions defined in
modules or bound locally in expressions.
```
A value of type ref<ty> may be passed to a function that accepts a byref parameter. The interior
address of the heap-allocated cell that is associated with such a parameter is passed as the pointer
argument.

For example, consider the following C# code:

```
public class C
{
static public void IntegerOutParam(out int x) { x = 3; }
}
public class D
{
virtual public void IntegerOutParam(out int x) { x = 3; }
}
```
This C# code can be called by the following F# code:

```
let res1 = ref 0
C.IntegerOutParam(res 1 )
// res1.contents now equals 3
```
Likewise, the abstract signature can be implemented as follows:

```
let x = {new D() with IntegerOutParam(res : byref<int>) = res <- 4}
let res2 = ref 0
x.IntegerOutParam(res2);
// res2.contents now equals 4
```
**8.13.7.3 Conversion to Quotation Values**
The third type-directed conversion enables an F# expression to be implicitly quoted at a member
call.

Conversion to a quotation value is driven by the ReflectedDefinition attribute to a method argument
of type FSharp.Quotations.Expr<_>:

```
static member Plot([<ReflectedDefinition>] values:Expr<int>) = (...)
```
The intention is that this gives an implicit quotation from X --> <@ X @> at the callsite. So for

```
Chart.Plot(f x + f y)
```

the caller becomes:

```
Chart.Plot(<@ f x + f y @>)
```
Additionally, the method can declare that it wants both the quotation and the evaluation of the
expression, by giving "true" as the "includeValue" argument of the ReflectedDefinitionAttribute.

```
static member Plot([<ReflectedDefinition(true)>] values:Expr<X>) = (...)
```
So for

```
Chart.Plot(f x + f y)
```
the caller becomes:

```
Chart.Plot(Expr.WithValue(f x + f y, <@ f x + f y @>))
```
and the quotation value Q received by Chart.Plot matches:

```
match Q with
| Expr.WithValue(v, ty) --> // v = f x + f y
| ...
```
```
Methods with ReflectedDefinition arguments may be used as first class values
(including pipelined uses), but it will not normally be useful to use them in this way. This
is because, in the above example, a first-class use of the method Chart.Plot is
considered shorthand for (fun x -> C.Plot(x)) for some compiler-generated local
name “x”, which will become (fun x -> C.Plot( <@ x @> )), so the implicit quotation
will just be a local value substitution. This means a pipelines use expr |> C.Plot will not
capture a full quotation for expr, but rather just its value.
```
```
The same applies to auto conversions for LINQ expressions: if you pipeline a method
accepting Expression arguments. This is an intrinsic cost of having an auto-quotation
meta-programming facility. All uses of auto-quotation need careful use API designers.
```
```
Auto-quotation of arguments only applies at method calls, and not function calls.
```
```
The conversion only applies if the called-argument-type is type Expr for some type T, and
if the caller-argument type is not of the form Expr for any U.
```
```
The caller-argument-type is determined as normal, with the addition that a caller
argument of the form <@ ... @> is always considered to have a type of the form Expr<>,
in the same way that caller arguments of the form (fun x -> ...) are always assumed to
have type of the form `` -> _`` (i.e. a function type)
```
**8.13.7.4 Conversion to LINQ Expressions**
The third type-directed conversion enables an F# expression to be implicitly converted to a LINQ
expression at a method call. Conversion is driven by an argument of type
System.Linq.Expressions.Expression.

```
static member Plot(values:Expression<Func<int,int>>) = (...)
```

This attribute results in an implicit quotation from X --> <@ X @> at the callsite and a call for a
helper function. So for

```
Chart.Plot(f x + f y)
```
the caller becomes:

```
Chart.Plot(FSharp.Linq.RuntimeHelpers.LeafExpressionConverter.
QuotationToLambdaExpression <@ f x + f y @>)
```
### 8.13.8 Overloading of Methods

Multiple methods that have the same name may appear in the same type definition or extension.
For example:

```
type MyForm() =
inherit System.Windows.Forms.Form()
```
```
member x.ChangeText(text: string) =
x.Text <- text
```
```
member x.ChangeText(text: string, reason: string) =
x.Text <- text
System.Windows.Forms.MessageBox.Show ("changing text due to " + reason)
```
Methods must be distinct based on their name and fully inferred types, after erasure of type
abbreviations and unit-of-measure annotations.

Methods that take curried arguments may not be overloaded.

### 8.13.9 Naming Restrictions for Members

A member in a record type may not have the same name as a record field in that type.

A member may not have the same name and signature as another method in the type. This check
ignores return types except for members that are named op_Implicit or op_Explicit.

### 8.13.10 Members Represented as Events

_Events_ are the CLI notion of a “listening point”—that is, a configurable object that holds a set of
callbacks, which can be triggered, often by some external action such as a mouse click or timer tick.

In F#, events are first-class values; that is, they are objects that mediate the addition and removal of
listeners from a backing list of listeners. The F# library supports the type
FSharp.Control.IEvent<_,_> and the module FSharp.Control.Event, which contains operations to
map, fold, create, and compose events. The type is defined as follows:

```
type IDelegateEvent<'del when 'del :> System.Delegate > =
abstract AddHandler : 'del -> unit
abstract RemoveHandler : 'del -> unit
type IEvent<'Del,'T when 'Del : delegate<'T,unit> and 'del :> System.Delegate > =
abstract Add : event : ('T -> unit) -> unit
inherit IDelegateEvent<'del>
type Handler<'T> = delegate of sender : obj * 'T -> unit
```

```
type IEvent<'T> = IEvent<Handler<'T>, 'T>
```
The following shows a sample use of events:

```
open System.Windows.Forms
```
```
type MyCanvas() =
inherit Form()
let event = new Event<PaintEventArgs>()
member x.Redraw = event.Publish
override x.OnPaint(args) = event.Trigger(args)
```
```
let form = new MyCanvas()
form.Redraw.Add(fun args -> printfn "OnRedraw")
form.Activate()
Application.Run(form)
```
Events from CLI languages are revealed as object properties of type
FSharp.Control.IEvent< _ty_ delegate, _ty_ args>. The F# compiler determines the type arguments, which
are derived from the CLI delegate type that is associated with the event.

Event declarations are not built into the F# language, and event is not a keyword. However, property
members that are marked with the CLIEvent attribute and whose type coerces to
FSharp.Control.IDelegateEvent< _ty_ delegate> are compiled to include extra CLI metadata and methods
that mark the property name as a CLI event. For example, in the following code, the
ChannelChanged property is currently compiled as a CLI event:

```
type ChannelChangedHandler = delegate of obj * int -> unit
```
```
type C() =
let channelChanged = new Event<ChannelChangedHandler,_>()
[<CLIEvent>]
member self.ChannelChanged = channelChanged.Publish
```
Similarly, the following shows the definition and implementation of an abstract event:

```
type I =
[<CLIEvent>]
abstract ChannelChanged : IEvent<ChannelChanged,int>
```
```
type ImplI() =
let channelChanged = new Event<ChannelChanged,_>()
interface I with
[<CLIEvent>]
member self.ChannelChanged = channelChanged.Publish
```
### 8.13.11 Members Represented as Static Members

Most members are represented as their corresponding CLI method or property. However, in certain
situations an instance member may be compiled as a static method. This happens when either of the
following is true:

- The type definition uses null as a representation by placing the
    CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue) attribute on
    the type that declares the member.


- The member is an extension member.

Compilation of an instance member as a static method can affect the view of the type when seen
from other languages or from System.Reflection. A member that might otherwise have a static
representation can be reverted to an instance member representation by placing the attribute
CompilationRepresentation(CompilationRepresentationFlags.Instance) on the member.

For example, consider the following type:

```
[<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
type option<'T> =
| None
| Some of 'T
```
```
member x.IsNone = match x with None -> true | _ -> false
member x.IsSome = match x with Some _ -> true | _ -> false
```
```
[<CompilationRepresentation(CompilationRepresentationFlags.Instance)>]
member x.Item =
match x with
| Some x -> x
| None -> failwith "Option.Item"
```
The IsNone and IsSome properties are represented as CLI static methods. The Item property is
represented as an instance property.

## 8.14 ABSTRACT MEMBERS AND INTERFACE IMPLEMENTATIONS

Abstract member definitions and interface declarations in a type definition represent promises that
an object will provide an implementation for a corresponding contract.

### 8.14.1 Abstract Members

An _abstract member definition_ in a type definition represents a promise that an object will provide
an implementation for a dispatch slot. For example:

```
type IX =
abstract M : int -> int
```
The abstract member M indicates that an object of type IX will implement a displatch slot for a
member that returns an int.

A class definition may contain abstract member definitions, but the definition must be labeled with
the AbstractClass attribute:

```
[<AbstractClass>]
type X() =
abstract M : int -> int
```
An abstract member definition has the form

```
abstract accessopt member-sig
```
where a member signature has one of the following forms


```
ident typar-defnsopt : curried-sig
ident typar-defnsopt : curried-sig with get
ident typar-defnsopt : curried-sig with set
ident typar-defnsopt : curried-sig with get, set
ident typar-defnsopt : curried-sig with set, get
```
and the curried signature has the form

```
args-spec 1 - > ... - > args-specn - > type
```
If _n_ ≥ 2 , then _args-spec 2_ ... _args-specn_ must all be patterns without attribute or optional argument
specifications.

If get or set is specified, the abstract member is a _property member_. If both get and set are
specified, the abstract member is equivalent to two abstract members, one with get and one with
set.

### 8.14.2 Members that Implement Abstract Members

An _implementation member_ has the form:

```
override ident. ident pat 1 ... patn = expr
default ident. ident pat 1 ... patn = expr
```
Implementation members implement dispatch slots. For example:

```
[<AbstractClass>]
type BaseClass() =
abstract AbstractMethod : int -> int
```
```
type SubClass(x: int) =
inherit BaseClass()
override obj.AbstractMethod n = n + x
```
```
let v1 = BaseClass() // not allowed – BaseClass is abstract
let v2 = (SubClass(7) :> BaseClass)
```
```
v2.AbstractMethod 6 // evaluates to 13
```
In this example, BaseClass() declares the abstract slot AbstractMethod and the SubClass type
supplies an implementation member obj.AbstractMethod, which takes an argument n and returns
the sum of n and the argument that was passed in the instantiation of SubClass. The v2 object
instantiates SubClass with the value 7, so v2.AbstractMethod 6 evaluates to 13.

The combination of an abstract slot declaration and a default implementation of that slot create the
F# equivalent of a “virtual” method in some other languages—that is, an abstract member that is
guaranteed to have an implementation. For example:

```
type BaseClass() =
abstract AbstractMethodWithDefaultImplementation : int -> int
default obj.AbstractMethodWithDefaultImplementation n = n
```
```
type SubClass1(x: int) =
inherit BaseClass()
override obj.AbstractMethodWithDefaultImplementation n = n + x
```

```
type SubClass2() =
inherit BaseClass()
```
```
let v1 = BaseClass() // allowed -- BaseClass contains a default implementation
let v2 = (SubClass1(7) :> BaseClass)
let v3 = (SubClass2() :> BaseClass)
```
```
v1.AbstractMethodWithDefaultImplementation 6 // evaluates to 6
v2.AbstractMethodWithDefaultImplementation 6 // evaluates to 13
v3.AbstractMethodWithDefaultImplementation 6 // evaluates to 6
```
Here, the BaseClass type contains a default implementation, so F# allows the instantiation of v1. The
instantiation of v2 is the same as in the previous example. The instantiation of v3 is similar to that of
v1, because SubClass2 inherits directly from BaseClass and does not override the default method.

```
Note: The keywords override and default are synonyms. However, it is recommended
that default be used only when the implementation is in the same class as the
corresponding abstract definition; override should be used in other cases. This records
the intended role of the member implementation.
```
Implementations may override methods from System.Object:

```
type BaseClass() =
override obj.ToString() = "I'm an instance of BaseClass"
```
```
type SubClass(x: int) =
inherit BaseClass()
override obj.ToString() = "I'm an instance of SubClass"
```
In this example, BaseClass inherits from System.Object and overrides the ToString method from
that class. The SubClass, in turn, inherits from BaseClass and overrides its version of the ToString
method.

Implementations may include abstract property members:

```
[<AbstractClass>]
type BaseClass() =
let mutable data1 = 0
let mutable data2 = 0
abstract AbstractProperty : int
abstract AbstractSettableProperty : int with get, set
```
```
abstract AbstractPropertyWithDefaultImplementation : int
default obj.AbstractPropertyWithDefaultImplementation = 3
```
```
abstract AbstractSettablePropertyWithDefaultImplementation : int with get, set
default obj.AbstractSettablePropertyWithDefaultImplementation
with get() = data2
and set v = data2 <- v
```
```
type SubClass(x: int) =
inherit BaseClass()
let mutable data1b = 0
let mutable data2b = 0
override obj.AbstractProperty = 3 + x
override obj.AbstractSettableProperty
with get() = data1b + x
```

```
and set v = data1b <- v - x
override obj.AbstractPropertyWithDefaultImplementation = 6 + x
override obj.AbstractSettablePropertyWithDefaultImplementation
with get() = data2b + x
and set v = data2b <- v - x
```
The same rules apply to both property members and method members. In the preceding example,
BaseClass includes abstract properties named AbstractProperty, AbstractSettableProperty,
AbstractPropertyWithDefaultImplementation, and
AbstractSettablePropertyWithDefaultImplementation and provides default implementations for the
latter two. SubClass provides implementations for AbstractProperty and AbstractSettableProperty,
and overrides the default implementations for AbstractPropertyWithDefaultImplementation and
AbstractSettablePropertyWithDefaultImplementation.

Implementation members may also implement CLI events (§8.13.10). In this case, the member
should be marked with the CLIEvent attribute. For example:

```
type ChannelChangedHandler = delegate of obj * int -> unit
```
```
[<AbstractClass>]
type BaseClass() =
[<CLIEvent>]
abstract ChannelChanged : IEvent<ChannelChangedHandler, int>
```
```
type SubClass() =
inherit BaseClass()
let mutable channel = 7
let channelChanged = new Event<ChannelChangedHandler, int>()
```
```
[<CLIEvent>]
override self.ChannelChanged = channelChanged.Publish
member self.Channel
with get () = channel
and set v = channel <- v; channelChanged.Trigger(self, channel)
```
BaseClass implements the CLI event IEvent, so the abstract member ChannelChanged is marked with
[<CLIEvent>] as described earlier in §8.13.10. SubClass provides an implementation of the abstract
member, so the [<CLIEvent>] attribute must also precede the override declaration in SubClass.

### 8.14.3 Interface Implementations

An _interface implementation_ specifies how objects of a given type support a particular interface. An
interface in a type definition indicates that objects of the defined type support the interface. For
example:

```
type IIncrement =
abstract M : int -> int
```
```
type IDecrement =
abstract M : int -> int
```
```
type C() =
interface IIncrement with
member x.M(n) = n + 1
interface IDecrement with
member x.M(n) = n - 1
```

The first two definitions in the example are implementations of the interfaces IIncrement and
IDecrement. In the last definition,the type C supports these two interfaces.

No type may implement multiple different instantiations of a generic interface, either directly or
through inheritance. For example, the following is not permitted:

```
// This type definition is not permitted because it implements two instantiations
// of the same generic interface
type ClassThatTriesToImplemenTwoInstantiations() =
interface System.IComparable<int> with
member x.CompareTo(n : int) = 0
interface System.IComparable<string> with
member x.CompareTo(n : string) = 1
```
Each member of an interface implementation is checked as follows:

- The member must be an instance member definition.
- _Dispatch Slot Inference_ (§14.7) is applied.
- The member is checked under the assumption that the “this” variable has the enclosing type.

In the following example, the value x has type C.

```
type C() =
interface IIncrement with
member x.M(n) = n + 1
interface IDecrement with
member x.M(n) = n - 1
```
All interface implementations are made explicit. In its first implementation, every interface must be
completely implemented, even in an abstract class. However, interface implementations may be
inherited from a base class. In particular, if a class C implements interface I, and a base class of C
implements interface I, then C is not required to implement all the methods of I;it can implement
all, some, or none of the methods instead. For example:

```
type I1 =
abstract V1 : string
abstract V2 : string
```
```
type I2 =
inherit I1
abstract V3 : string
```
```
type C1() =
interface I1 with
member this.V1 = "C1"
member this.V2 = "C2"
```
```
// This is OK
type C2() =
inherit C1()
```
```
// This is also OK; C3 implements I2 but not I1.
type C3() =
inherit C1()
interface I2 with
member this.V3 = "C3"
```

```
// This is also OK; C4 implements one method in I1.
type C4() =
inherit C1()
interface I1 with
member this.V2 = "C2b"
```
## 8.15 EQUALITY, HASHING, AND COMPARISON

Functional programming in F# frequently involves the use of structural equality, structural hashing,
and structural comparison. For example, the following expression evaluates to true, because tuple
types support structural equality:

```
(1, 1 + 1) = (1, 2)
```
Likewise, these two function calls return identical values:

```
hash (1, 1 +1 )
hash (1,2)
```
Similarly, an ordering on constituent parts of a tuple induces an ordering on tuples themselves, so all
the following evaluate to true:

```
(1, 2) < (1, 3)
(1, 2) < (2, 3)
(1, 2) < (2, 1)
(1, 2) > (1, 0)
```
The same applies to lists, options, arrays, and user-defined record, union, and struct types whose
constituent field types permit structural equality, hashing, and comparison. For example, given:

```
type R = R of int * int
```
then all of the following also evaluate to true:

```
R (1, 1 + 1) = R (1, 2)
```
```
R (1, 3) <> R (1, 2)
```
```
hash (R (1, 1 + 1)) = hash (R (1, 2))
```
```
R (1, 2) < R (1, 3)
R (1, 2) < R (2, 3)
R (1, 2) < R (2, 1)
R (1, 2) > R (1, 0)
```
To facilitate this, by default, record, union, and struct type definitions—called _structural types_ —
implicitly include compiler-generated declarations for structural equality, hashing, and comparison.
These implicit declarations consist of the following for structural equality and hashing:

```
override x.GetHashCode() = ...
override x.Equals(y:obj) = ...
interface System.Collections.IStructuralEquatable with
member x.Equals(yobj: obj, comparer: System.Collections.IEqualityComparer) = ...
member x.GetHashCode(comparer: System.IEqualityComparer) = ...
```

The following declarations enable structural comparison:

```
interface System.IComparable with
member x.CompareTo(y:obj) = ...
interface System.Collections.IStructuralComparable with
member x.CompareTo(yobj: obj, comparer: System.Collections.IComparer) = ...
```
For exception types, implicit declarations for structural equality and hashings are generated, but
declarations for structural comparison are not generated. Implicit declarations are never generated
for interface, delegate, class, or enum types. Enum types implicitly derive support for equality,
hashing, and comparison through their underlying representation as integers.

### 8.15.1 Equality Attributes

Several attributes affect the equality behavior of types:

```
FSharp.Core.NoEquality
FSharp.Core.ReferenceEquality
FSharp.Core.StructuralEquality
FSharp.Core.CustomEquality
```
The following table lists the effects of each attribute on a type:

**Attrribute Effect**

NoEquality (^) ▪ No equality or hashing is generated for the type.
▪ The type does not satisfy the _ty_ : equality constraint.
ReferenceEquality (^) ▪ No equality or hashing is generated for the type.
▪ The defaults for System.Object will implicitly be used.
StructuralEquality (^) ▪ The type must be a structural type.
▪ All structural field types _ty_ must satisfy _ty_ : equality.
CustomEquality (^) ▪ The type must have an explicit implementation of
override Equals(obj: obj)
None (^) ▪ For a non-structural type, the default is ReferenceEquality.
▪ For a structural type:
The default is NoEquality if any structural field type F fails F : equality.
The default is StructuralEquality if all structural field types F satisfy
F : equality.^
Equality inference also determines the _constraint dependencies_ of a generic structural type. That is:

- If a structural type has a generic parameter 'T and T : equality is necessary to make the type
    default to StructuralEquality, then the EqualityConditionalOn constraint dependency is
    inferred for 'T.

### 8.15.2 Comparison Attributes

The comparison behavior of types can be affected by the following attributes:

```
FSharp.Core.NoComparison
FSharp.Core.StructuralComparison
FSharp.Core.CustomComparison
```
The following table lists the effects of each attribute on a type.

**Attribute Effect**


**Attribute Effect**

NoComparison (^) ▪ No comparisons are generated for the type.
▪ The type does not satisfy the _ty_ : comparison constraint.
StructuralComparison (^) ▪ The type must be a structural type other than an exception type.
▪ All structural field types must _ty_ satisfy _ty_ : comparison.
▪ An exception type may not have the StructuralComparison attribute.
CustomComparison (^) ▪ The type must have an explicit implementation of one or both of the following:
interface System.IComparable
interface System.Collections.IStructuralComparable
▪ A structural type that has an explicit implementation of one or both of these
contracts must specify the CustomComparison attribute.
None (^) ▪ For a non-structural or exception type, the default is NoComparison.
▪ For any other structural type:
The default is NoComparison if any structural field type F fails F : comparison.
The default is StructuralComparison if all structural field types F satisfy
F : comparison.^
This check also determines the _constraint dependencies_ of a generic structural type. That is:

- If a structural type has a generic parameter 'T and T : comparison is necessary to make the type
    default to StructuralComparison, then the ComparisonConditionalOn constraint dependency is
    inferred for 'T.

For example:

```
[<StructuralEquality; StructuralComparison>]
type X = X of (int -> int)
```
results in the following message:

```
The struct, record or union type 'X' has the 'StructuralEquality' attribute
but the component type '(int -> int)' does not satisfy the 'equality' constraint
```
For example, given

```
type R1 =
{ myData : int }
static member Create() = { myData = 0 }
```
```
[<ReferenceEquality>]
type R2 =
{ mutable myState : int }
static member Fresh() = { myState = 0 }
```
```
[<StructuralEquality; NoComparison >]
type R3 =
{ someType : System.Type }
static member Make() = { someType = typeof<int> }
```
then the following expressions all evaluate to true:

R1.Create() = R1.Create()
not (R2.Fresh() = R2.Fresh())
R3.Make() = R3.Make()


Combinations of equality and comparion attributes are restricted. If any of the following attributes
are present, they may be used only in the following combinations:

- No attributes
- [<NoComparison>] on any type
- [<NoEquality; NoComparison>] on any type
- [<CustomEquality; NoComparison>] on a structural type
- [<ReferenceEquality>] on a non-struct structural type
- [<ReferenceEquality; NoComparison>] on a non-struct structural type
- [<StructuralEquality; NoComparison>] on a structural type
- [<CustomEquality; CustomComparison>] on a structural type
- [<StructuralEquality; CustomComparison>] on a structural type
- [<StructuralEquality; StructuralComparison>] on a structural type

### 8.15.3 Behavior of the Generated Object.Equals Implementation

For a type definition T, the behavior of the generated override x.Equals(y:obj) = ...
implementation is as follows.

1. If the interface System.IComparable has an explicit implementation, then just call
    System.IComparable.CompareTo:

```
override x.Equals(y : obj) =
((x :> System.IComparable).CompareTo(y) = 0)
```
2. Otherwise:
    - Convert the y argument to type T. If the conversion fails, return false.
    - Return false if T is a reference type and y is null.
    - If T is a struct or record type, invoke FSharp.Core.Operators.(=) on each corresponding pair
       of fields of x and y in declaration order. This method stops at the first false result and
       returns false.
    - If T is a union type, invoke FSharp.Core.Operators.(=) first on the index of the union cases
       for the two values, then on each corresponding field pair of x and y for the data carried by
       the union case. This method stops at the first false result and returns false.
    - If T is an exception type, invoke FSharp.Core.Operators.(=) on the index of the tags for the
       two values, then on each corresponding field pair for the data carried by the exception. This
       method stops at the first false result and returns false.

### 8.15.4 Behavior of the Generated CompareTo Implementations

For a type T, the behavior of the generated System.IComparable.CompareTo implementation is as
follows:


- Convert the y argument to type T. If the conversion fails, raise the InvalidCastException.
- If T is a reference type and y is null, return 1.
- If T is a struct or record type, invoke FSharp.Core.Operators.compare on each corresponding pair
    of fields of x and y in declaration order, and return the first non-zero result.
- If T is a union type, invoke FSharp.Core.Operators.compare first on the index of the union cases
    for the two values, and then on each corresponding field pair of x and y for the data carried by
    the union case. Return the first non-zero result.

The first few lines of this code can be written:

```
interface System.IComparable with
member x.CompareTo(y:obj) =
let y = (obj :?> T) in
match obj with
| null -> 1
| _ -> ...
```
### 8.15.5 Behavior of the Generated GetHashCode Implementations.....................................

For a type T, the generated System.Object.GetHashCode() override implements a combination hash
of the structural elements of a structural type.

#### 8.15.6 Behavior of Hash, =, and Compare

The generated equality, hashing, and comparison declarations that are described in sections 8.15.3,
8.15.4, and 8.15.5 use the hash, = and compare functions from the F# library. The behavior of these
library functions is defined by the pseudocode later in this section. This code ensures:

- Ordinal comparison for strings
- Structural comparison for arrays
- Natural ordering for native integers (which do not support System.IComparable)

**8.15.6.1 Pseudocode for FSharp.Core.Operators.compare**

```
Note: In practice, fast (but semantically equivalent) code is emitted for direct calls to
(=), compare, and hash for all base types, and faster paths are used for comparing most
arrays.
```
```
open System
```
```
/// Pseudo code for code implementation of generic comparison.
let rec compare x y =
let xobj = box x
let yobj = box y
match xobj, yobj with
| null, null -> 0
| null, _ -> - 1
| _, null -> 1
```
```
// Use Ordinal comparison for strings
| (:? string as x),(:? string as y) ->
String.CompareOrdinal(x, y)
```

```
// Special types not supporting IComparable
| (:? Array as arr1), (:? Array as arr2) ->
... compare the arrays by rank, lengths and elements ...
| (:? nativeint as x),(:? nativeint as y) ->
... compare the native integers x and y....
| (:? unativeint as x),(:? unativeint as y) ->
... compare the unsigned integers x and y....
```
```
// Check for IComparable
| (:? IComparable as x),_ -> x.CompareTo(yobj)
| _,(:? IComparable as yc) -> -(sign(yc.CompareTo(xobj)))
```
```
// Otherwise raise a runtime error
| _ -> raise (new ArgumentException(...))
```
**8.15.6.2 Pseudo code for FSharp.Core.Operators.(=)**

```
Note: In practice, fast (but semantically equivalent) code is emitted for direct calls to
(=), compare, and hash for all base types, and faster paths are used for comparing most
arrays
```
```
open System
```
```
/// Pseudo code for core implementation of generic equality.
let rec (=) x y =
let xobj = box x
let yobj = box y
match xobj,yobj with
| null,null -> true
| null,_ -> false
| _,null -> false
```
```
// Special types not supporting IComparable
| (:? Array as arr1), (:? Array as arr2) ->
... compare the arrays by rank, lengths and elements ...
```
```
// Ensure NaN semantics on recursive calls
| (:? float as f1), (:? float as f2) ->
... IEEE equality on f1 and f2...
| (:? float32 as f1), (:? float32 as f2) ->
... IEEE equality on f1 and f2...
```
```
// Otherwise use Object.Equals. This is reference equality
// for reference types unless an override is provided (implicitly
// or explicitly).
| _ -> xobj.Equals(yobj)
```

## 9. UNITS OF MEASURE

F# supports static checking of _units of measure_. Units of measure, or _measure_ s for short, are like
types in that they can appear as parameters to other types and values (as in float<kg>, vector<m/s>,
add<m>), can contain variables (as in float<'U>), and are checked for consistency by the type-checker.

However, measures differ from types in several important ways:

- Measures play no role at runtime; in fact, they are erased.
- Measures obey special rules of _equivalence_ , so that N m can be interchanged with m N.
- Measures are supported by special syntax.

The syntax of constants (§4.3) is extended to support numeric constants with units of measure. The
syntax of types is extended with measure type annotations.

```
measure-literal-atom :=
long-ident -- named measure e.g. kg
( measure-literal-simp ) -- parenthesized measure, such as (N m)
measure-literal-power :=
measure-literal-atom
measure-literal-atom ^ int32 -- power of measure, such as m^3
measure-literal-seq :=
measure-literal-power
measure-literal-power measure-literal-seq
measure-literal-simp :=
measure-literal-seq -- implicit product, such as m s^- 2
measure-literal-simp * measure-literal-simp -- product, such as m * s^3
measure-literal-simp / measure-literal-simp -- quotient, such as m/s^2
/ measure-literal-simp -- reciprocal, such as /s
1 -- dimensionless
measure-literal :=
_ -- anonymous measure
measure-literal-simp -- simple measure, such as N m
const :=
...
sbyte < measure-literal > -- 8 - bit integer constant
int16 < measure-literal > -- 16 - bit integer constant
int32 < measure-literal > -- 32 - bit integer constant
int64 < measure-literal > -- 64 - bit integer constant
ieee32 < measure-literal > -- single-precision float32 constant
ieee64 < measure-literal > -- double-precision float constant
decimal < measure-literal > -- decimal constant
measure-atom :=
typar -- variable measure, such as 'U
long-ident -- named measure, such as kg
( measure-simp ) -- parenthesized measure, such as (N m)
measure-power :=
measure-atom
measure-atom ^ int32 -- power of measure, such as m^3
```

```
measure-seq :=
measure-power
measure-power measure-seq
measure-simp :=
measure-seq -- implicit product, such as 'U 'V^3
measure-simp * measure-simp -- product, such as 'U * 'V
measure-simp / measure-simp -- quotient, such as 'U / 'V
/ measure-simp -- reciprocal, such as /'U
1 -- dimensionless measure (no units)
measure :=
_ -- anonymous measure
measure-simp -- simple measure, such as 'U 'V
```
Measure definitions use the special Measure attribute on type definitions. Measure parameters use
the syntax of generic parameters with the same special Measure attribute to parameterize types and
members by units of measure. The primitive types sbyte, int16, int32, int64, float, float32, and
decimal have non-parameterized (dimensionless) and parameterized versions.

Here is a simple example:

```
[<Measure>] type m // base measure: meters
[<Measure>] type s // base measure: seconds
[<Measure>] type sqm = m^2 // derived measure: square meters
let areaOfTriangle (baseLength:float<m>, height:float<m>) : float<sqm> =
baseLength*height/2.0
let distanceTravelled (speed:float<m/s>, time:float<s>) : float<m> = speed*time
```
As with ordinary types, F# can infer that functions are generic in their units. For example, consider
the following function definitions:

```
let sqr (x:float<_>) = x*x
let sumOfSquares x y = sqr x + sqr y
```
The inferred types are:

```
val sqr : float<'u> -> float<'u ^ 2>
val sumOfSquares : float<'u> -> float<'u> -> float<'u ^ 2>
```
Measures are type-like annotations such as kg or m/s or m^2. Their special syntax includes the use of *
and / for product and quotient of measures, juxtaposition as shorthand for product, and ^ for
integer powers.

### 9.1 MEASURES

Measures are built from:

- _Atomic measures_ from long identifiers such as SI.kg or MyUnits.feet.
- _Product measures_ , which are written _measure measure_ (juxtaposition ) or _measure_ * _measure_.
- _Quotient measures_ , which are written _measure_ / _measure_.


- _Integer powers of measures_ , which are written _measure_ ^ _int_.
- _Dimensionless measures_ , which are written 1.
- Variable measures, which are written 'u or 'U. Variable measures can include anonymous
    measures _, which indicates that the compiler can infer the measure from the context.

Dimensionless measures indicate “without units,” but are rarely needed, because non-
parameterized types such as float are aliases for the parameterized type with 1 as parameter, that
is, float = float<1>.

The precedence of operations involving measure is similar to that for floating-point expressions:

- Products and quotients (* and /) have the same precedence, and associate to the left, but
    juxtaposition has higher syntactic precedence than both * and /.
- Integer powers (^) have higher precedence than juxtaposition.
- The / symbol can also be used as a unary reciprocal operator.

### 9.2 CONSTANTS ANNOTATED BY MEASURES

A floating-point constant can be annotated with its measure by specifying a literal measure in angle
brackets following the constant.

Measure annotations on constants may not include measure variables.

Here are some examples of annotated constants:

```
let earthGravity = 9.81f<m/s^2>
let atmosphere = 101325.0<N m^-2>
let zero = 0.0f<_>
```
Constants that are annotated with units of measure are assigned a corresponding numeric type with
the measure parameter that is specified in the annotation. In the example above, earthGravity is
assigned the type float32<m/s^2>, atmosphere is assigned the type float<N/m^2> and zero is assigned
the type float<'U>.

### 9.3 RELATIONS ON MEASURES

After measers are parsed and checked, they are maintained in the following normalized form:

```
measure-int := 1 | long-ident | measure-par | measure-int measure-int | / measure-int
```
Powers of measures are expanded. For example, kg^3 is equivalent to kg kg kg.

Two measures are indistinguishable if they can be made equivalent by repeated application of the
following rules:

- _Commutativity_. _measure-int 1 measure-int 2_ is equivalent to _measure-int 2 measure-int 1_.


- _Associativity_. It does not matter what grouping is used for juxtaposition (product) of measures,
    so parentheses are not required. For example, kg m s can be split as the product of kg m and s,
    or as the product of kg and m s.
- _Identity_. 1 _measure-int_ is equivalent to _measure-int_.
- _Inverses. measure-int_ / _measure-int_ is equivalent to 1.
- _Abbreviation_. _long-ident_ is equivalent to _measure_ if a measure abbreviation of the form
    [<Measure>] type _long-ident_ = _measure_ is currently in scope.

Note that these are the laws of Abelian groups together with expansion of abbreviations.

For example, kg m / s^2 is the same as m kg / s^2.

For presentation purposes (for example, in error messages), measures are presented in the
normalized form that appears at the beginning of this section, but with the following restrictions:

- Powers are positive and greater than 1. This splits the measure into positive powers and
    negative powers, separated by /.
- Atomic measures are ordered as follows: measure parameters first, ordered alphabetically,
    followed by measure identifiers, ordered alphabetically.

For example, the measure expression m^1 kg s^- 1 would be normalized to kg m / s.

This normalized form provides a convenient way to check the equality of measures: given two
measure expressions _measure-int 1_ and _measure-int 2_ , reduce each to normalized form by using the
rules of commutativity, associativity, identity, inverses and abbreviation, and then compare the
syntax.

To check the equality of two measures, abbreviations are expanded to compare their normalized
forms. However, abbreviations are not expanded for presentation. For example, consider the
following definitions:

```
[<Measure>] type a
[<Measure>] type b = a * a
let x = 1<b> / 1<a>
```
The inferred type is presented as int<b/a>, not int<a>. If a measure is equivalent to 1 , however, abbreviations
are expanded to cancel each other and are presented without units:

```
let y = 1<b> / 1<a a> // val y : int = 1
```
#### 9.3.1 Constraint Solving

The mechanism described in §14.5 is extended to support equational constraints between measure
expressions. Such expressions arise from equations between parameterized types—that is, when
_type_ < _tyarg 11_ ,..., _tyarg1n_ > = _type_ < _tyarg 21_ ,..., _tyarg2n_ > is reduced to a series of constraints
_tyarg1i_ = _tyarg2i_. For the arguments that are measures, rather than types, the rules listed in §9.3
are applied to obtain primitive equations of the form 'U = _measure-int_ where 'U is a measure
variable and _measure-int_ is a measure expression in internal form. The variable 'U is then replaced
by _measure-int_ wherever else it occurs. For example, the equation float<m^2/s^2> = float<'U^2>


would be reduced to the constraint m^2/s^2 = 'U^2, which would be further reduced to the primitive
equation 'U = m/s.

If constraints cannot be solved, a type error occurs. For example, the following expression

```
fun (x : float<m^2>, y : float<s>) -> x + y
```
would eventually)result in the constraint m^2 = s, which cannot be solved, indicating a type error.

#### 9.3.2 Generalization of Measure Variables

Analogous to the process of generalization of type variables described in §14.6.7, a generalization
procedure produces measure variables over which a value, function, or member can be generalized.

### 9.4 MEASURE DEFINITIONS

Measure definitions define new named units of measure by using the same syntax as for type
definitions, with the addition of the Measure attribute. For example:

```
[<Measure>] type kg
[<Measure>] type m
[<Measure>] type s
[<Measure>] type N = kg / m s^2
```
A primitive measure abbreviation defines a fresh, named measure that is distinct from other
measures. Measure abbreviations, like type abbreviations, define new names for existing measures.
Also like type abbreviations, repeatedly eliminating measure abbreviations in favor of their
equivalent measures must not result in infinite measure expressions. For example, the following is
not a valid measure definition because it results in the infinite squaring of X:

```
[<Measure>] type X = X^2
```
Measure definitions and abbreviations may not have type or measure parameters.

### 9.5 MEASURE PARAMETER DEFINITIONS

Measure parameter definitions can appear wherever ordinary type parameter definitions can (see
§5.2.9). If an explicit parameter definition is used, the parameter name is prefixed by the special
Measure attribute. For example:

```
val sqr<[<Measure>] 'U> : float<'U> -> float<'U^2>
```
```
type Vector<[<Measure>] 'U> =
{ X: float<'U>;
Y: float<'U>;
Z: float<'U>}
```
```
type Sphere<[<Measure>] 'U> =
{ Center:Vector<'U>;
Radius:float<'U> }
```

```
type Disc<[<Measure>] 'U> =
{ Center:Vector<'U>;
Radius:float<'U>;
Norm:Vector<1> }
```
```
type SceneObject<[<Measure>] 'U> =
| Sphere of Sphere<'U>
| Disc of Disc<'U>
```
Internally, the type checker distinguishes between type parameters and measure parameters by
assigning one of two _sorts_ (Type or Measure) to each parameter. This technique is used to check the
actual arguments to types and other parameterized definitions. The type checker rejects ill-formed
types such as float<int> and IEnumerable<m/s>.

### 9.6 MEASURE PARAMETER ERASURE

In contrast to _type_ parameters on generic types, _measure_ parameters are not exposed in the
metadata that the runtime interprets; instead, measures are _erased_. Erasure has several
consequences:

- Casting is with respect to erased types.
- Method application resolution (see §14.4) is with respect to erased types.
- Reflection is with respect to erased types.

### 9.7 TYPE DEFINITIONS WITH MEASURES IN THE F# CORE LIBRARY

The F# core library defines the following types:

```
type float<[<Measure>] 'U>
type float32<[<Measure>] 'U>
type decimal<[<Measure>] 'U>
type int<[<Measure>] 'U>
type sbyte<[<Measure>] 'U>
type int16<[<Measure>] 'U>
type int64<[<Measure>] 'U>
```
```
Note: These definitions are called measure-annotated base types and are marked with
the MeasureAnnotatedAbbreviation attribute in the implementation of the library. The
MeasureAnnotatedAbbreviation attribute is not for use in user code and in future
revisions of the language may result in a warning or error.
```
These type definitions have the following special properties:

- They extend System.ValueType.
- They explicitly implement System.IFormattable, System.IComparable, System.IConvertible, and
    corresponding generic interfaces, instantiated at the given type—for example,
    System.IComparable<float<'u>> and System.IEquatable<float<'u>> (so that you can invoke, for
    example, CompareTo after an explicit upcast).


- As a result of erasure, their compiled form is the corresponding primitive type.
- For the purposes of constraint solving and other logical operations on types, a type equivalence
    holds between the unparameterized primitive type and the corresponding measured type
    definition that is instantiated at <1>:
       sbyte = sbyte<1>
       int16 = int16<1>
       int32 = int32<1>
       int64 = int64<1>
       float = float<1>
       float32 = float32<1>
       decimal = decimal<1>
- The measured type definitions sbyte, int16, int32, int64, float32, float, and decimal are
    assumed to have additional static members that have the measure types that are listed in the
    table. Note that N is any of these types, and F is either float32 or float.
    **Member Measure Type**
    Sqrt F<'U^2> -> F<'U>
    Atan2 F<'U> -> F<'U> -> F<1>
    op_Addition
    op_Subtraction
    op_Modulus

```
N<'U> -> N<'U> -> N<'U>
```
```
op_Multiply N<'U> -> N<'V> -> N<'U 'V>
op_Division N<'U> -> N<'V> -> N<'U/'V>
Abs
op_UnaryNegation
op_UnaryPlus
```
```
N<'U> -> N<'U>
```
Sign^ N<'U> -> int^
This mechanism is used to support units of measure in the following math functions of the F#
library:
(+),(-), (*), (/),(%),(~+),(~-),abs, sign, atan2 and sqrt.

### 9.8 RESTRICTIONS

Measures can be used in range expressions but a properly measured step is required. For example,
these are not allowed:

```
[<Measure>] type s
[1<s> .. 5<s>] // error: The type 'int<s>' does not match the type 'int'
[1<s> .. 1 .. 5<s>] // error: The type 'int<s>' does not match the type 'int'
```
However, the following range expression is valid:

```
[1<s> .. 1<s> .. 5<s>] // int<s> list = [1; 2; 3; 4; 5]
```


## 10. NAMESPACES AND MODULES

F# is primarily an expression-based language. However, F# source code units are made up of
_declarations_ , some of which can contain further declarations. Declarations are grouped using
_namespace declaration groups_ , _type definitions_ , and _module definitions_. These also have
corresponding forms in _signatures_. For example, a file may contain multiple namespace declaration
groups, each of which defines types and modules, and the types and modules may contain member,
function, and value definitions, which contain expressions.

Declaration elements are processed in the context of an _environment_. The definition of the elements
of an environment is found in §14.1.

```
namespace-decl-group :=
namespace long-ident module-elems -- elements within a namespace
namespace global module-elems -- elements within no namespace
module-defn :=
attributesopt module accessopt ident = module-defn-body
module-defn-body :=
begin module-elemsopt end
module-elem :=
module-function-or-value-defn -- function or value definitions
type-defns -- type definitions
exception-defn -- exception definitions
module-defn -- module definitions
module-abbrev -- module abbreviations
import-decl -- import declarations
compiler-directive-decl -- compiler directives
module-function-or-value-defn :=
attributesopt let function-defn
attributesopt let value-defn
attributesopt let rec opt function-or-value-defns
attributesopt do expr
import-decl := open long-ident
module-abbrev := module ident = long-ident
compiler-directive-decl := # ident string ... string
module-elems := module-elem ... module-elem
access :=
private
internal
public
```
### 10.1 NAMESPACE DECLARATION GROUPS

Modules and types in an F# program are organized into _namespaces_ , which encompass the
identifiers that are defined in the modules and types_._ New components may contribute entities to


existing namespaces. Each such contribution to a namespace is called a _namespace declaration
group_.

In the following example, the MyCompany.MyLibrary namespace contains Values and x:

```
namespace MyCompany.MyLibrary
```
```
module Values1 =
let x = 1
```
A namespace declaration group is the basic declaration unit within an F# implementation file and is
of the form

```
namespace long-ident
```
```
module-elems
```
The _long-ident_ must be fully qualified. Each such group contains a series of module and type
definitions that contribute to the indicated namespace. An implementation file may contain multiple
namespace declaration groups, as in this example:

```
namespace MyCompany.MyOtherLibrary
```
```
type MyType() =
let x = 1
member v.P = x + 2
```
```
module MyInnerModule =
let myValue = 1
```
```
namespace MyCompany.MyOtherLibrary.Collections
```
```
type MyCollection(x : int) =
member v.P = x
```
Namespace declaration groups may not be nested.

A namespace declaration group can contain type and module definitions, but not function or value
definitions. For example:

```
namespace MyCompany.MyLibrary
```
```
// A type definition in a namespace
type MyType() =
let x = 1
member v.P = x+2
```
```
// A module definition in a namespace
module MyInnerModule =
let myValue = 1
```
```
// The following is not allowed: value definitions are not allowed in namespaces
let addOne x = x + 1
```
When a namespace declaration group _N_ is checked in an environment _env_ , the individual
declarations are checked in order and an overall _namespace declaration group signature Nsig_ is


inferred for the module. An entry for _N_ is then added to the _ModulesAndNamespaces_ table in the
environment _env_ (see §14.1.3).

Like module declarations, namespace declaration groups are processed sequentially rather than
simultaneously, so that later namespace declaration groups are not in scope when earlier ones are
processed. This prevents invalid recursive definitions.

In the following example, the declaration of x in Module1 generates an error because the
Utilities.Part2 namespace is not in scope:

```
namespace Utilities.Part1
```
```
module Module1 =
let x = Utilities.Part2.Module2.x + 1 // error (Part2 not yet declared)
```
```
namespace Utilities.Part2
```
```
module Module2 =
let x = Utilities.Part1.Module1.x + 2
```
Within a namespace declaration group, the namespace itself is implicitly opened if any preceding
namespace declaration groups or referenced assemblies contribute to it. For example:

```
namespace MyCompany.MyLibrary
```
```
module Values1 =
let x = 1
```
```
namespace MyCompany.MyLibrary
```
```
// Here, the implicit open of MyCompany.MyLibrary brings Values1 into scope
```
```
module Values2 =
let x = Values1.x
```
### 10.2 MODULE DEFINITIONS

A module definition is a named collection of declarations such as values, types, and function values.
Grouping code in modules helps keep related code together and helps avoid name conflicts in your
program. For example:

```
module MyModule =
let x = 1
type Foo = A | B
module MyNestedModule =
let f y = y + 1
type Bar = C | D
```
When a module definition _M_ is checked in an environment _env 0_ , the individual declarations are
checked in order and an overall _module signature Msig_ is inferred for the module. An entry for _M_ is
then added to the _ModulesAndNamespaces_ table to environment _env 0_ to form the new environment
used for checking subsequent modules.


Like namespace declaration groups, module definitions are processed sequentially rather than
simultaneously, so that later modules are not in scope when earlier ones are processed.

```
module Part1 =
```
```
let x = Part2.StorageCache() // error (Part2 not yet declared)
```
```
module Part2 =
```
```
type StorageCache() =
member cache.Clear() = ()
```
No two types or modules may have identical names in the same namespace. The
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>] attribute adds the
suffix Module to the name of a module to distinguish the module name from a type of a similar name.

For example, this is frequently used when defining a type and a set of functions and values to
manipulate values of this type.

```
type Cat(kind: string) =
member x.Meow() = printfn "meow"
member x.Purr() = printfn "purr"
member x.Kind = kind
```
```
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Cat =
```
```
let tabby = Cat "Tabby"
let purr (c:Cat) = c.Purr()
let purrTwice (c:Cat) = purr(); purr()
```
```
Cat.tabby |> Cat.purr |> Cat.purrTwice
```
#### 10.2.1 Function and Value Definitions in Modules

Function and value definitionsin modules introduce named values and functions.

let rec _opt function-or-value-defn 1_ and _..._ and _function-or-value-defnn_

The following example defines value x and functions id and fib:

```
module M =
let x = 1
let id x = x
let rec fib x = if x <= 2 then 1 else fib (n - 1) + fib (n - 2)
```
Function and value definitions in modules may declare explicit type variables and type constraints:

```
let pair<'T>(x : 'T) = (x, x)
let dispose<'T when 'T :> System.IDisposable>(x : 'T) = x.Dispose()
let convert<'T, 'U>(x) = unbox<'U>(box<'T>(x))
```
A value definition that has explicit type variables is called a type function (§10.2.3).

Function and value definitions may specify attributes:

```
// A value definition with the System.Obsolete attribute
```

```
[<System.Obsolete("Don't use this")>]
let oneTwoPair = ( 1 , 2 )
```
```
// A function definition with an attribute
[<System.Obsolete("Don't use this either")>]
let pear v = (v, v)
```
By the use of pattern matching, a value definition can define more than one value. In such cases,
the attributes apply to each value.

```
// A value definition that defines two values, each with an attribute
[<System.Obsolete("Don't use this")>]
let (a, b) = (1, 2)
```
Values may be declared mutable:

```
// A value definition that defines a mutable value
let mutable count = 1
let freshName() = (count <- count + 1; count)
```
Function and value definitions in modules are processed in the same way as function and value
definitions in expressions (§14.6), with the following adjustments:

- Each defined value may have an accessibility annotation (§10.5). By default, the accessibility
    annotation of a function or value definition in a module is _public_.
- Each defined value is _externally accessible_ if its accessibility annotation is public and it is not
    hidden by an explicit signature. Externally accessible values are guaranteed to have compiled CLI
    representations in compiled CLI binaries.
- Each defined value can be used to satisfy the requirements of any signature for the module
    (§11.2).
- Each defined value is subject to arity analysis (§14.10).
- Values may have attributes, including the ThreadStatic or ContextStatic attribute.

#### 10.2.2 Literal Definitions in Modules

Value definitions in modules may have the Literal attribute. This attribute causes the value to be
compiled as a constant. For example:

```
[<Literal>]
let PI = 3.141592654
```
Literal values may be used in custom attributes and pattern matching. For example:

```
[<Literal>]
let StartOfWeek = System.DayOfWeek.Monday
```
```
[<MyAttribute(StartOfWeek)>]
let feeling(day) =
match day with
| StartOfWeek -> "rough"
| _ -> "great"
```
A value that has the Literal attribute is subject to the following restrictions:


- It may not be marked mutable or inline.
- It may not also have the ThreadStatic or ContextStatic attributes.
- The right-hand side expression must be a _literal constant expression_ that is both a valid
    expression after checking, and is made up of either:
    - A simple constant expression, with the exception of (), native integer literals, unsigned native
       integer literals, byte array literals, BigInteger literals, and user-defined numeric literals.

```
—OR—
```
- A reference to another literal

```
—OR—
```
- A bitwise combination of literal constant expressions

```
—OR—
```
- A “+” concatenation of two literal constant expressions which are strings

```
—OR—
```
- “enum x” or “LanguagePrimitives.EnumOfValue x” where “x” is a literal constant expression.

#### 10.2.3 Type Function Definitions in Modules

Value definitions within modules may have explicit generic parameters. For example, ‘T is a generic
parameter to the value empty:

```
let empty<'T> : (list<'T> * Set<'T>) = ([], Set.empty)
```
A value that has explicit generic parameters but has arity [] (that is, no explicit function parameters)
is called a _type function_. The following are some example type functions from the F# library:

```
val typeof<'T> : System.Type
val sizeof<'T> : int
module Set =
val empty<'T> : Set<'T>
module Map =
val empty<'Key,'Value> : Map<'Key,'Value>
```
Type functions are rarely used in F# programming, although they are convenient in certain
situations. Type functions are typically used for:

- Pure functions that compute type-specific information based on the supplied type arguments.
- Pure functions whose result is independent of inferred type arguments, such as empty sets and
    maps.

Type functions receive special treatment during generalization (§14.6.7) and signature conformance
(§11.2). They typically have either the RequiresExplicitTypeArguments attribute or the
GeneralizableValue attribute. Type functions may not be defined inside types, expressions, or
computation expressions.


In general, type functions should be used only for computations that do not have observable side
effects. However, type functions may still perform computations. In this example, r is a type function
that calculates the number of times it has been called

```
let mutable count = 1
let r<'T> = (count <- count + 1); ref ([] : 'T list);;
// count = 1
let x1 = r<int>
// count = 2
let x2 = r<int>
// count = 3
let z0 = x1
// count = 3
```
The elaborated form of a type function is that of a function definition that takes one argument of
type unit. That is, the elaborated form of

```
let ident typar-defns = expr
```
is the same as the compiled form for the following declaration:

```
let ident typar-defns () = expr
```
References to type functions are elaborated to invocations of such a function.

#### 10.2.4 Active Pattern Definitions in Modules.......................................................................

A value definition within a module that has an _active-pattern-op-name_ introduces pattern-matching
tags into the environment when the module is accessed or opened. For example,

```
let (|A|B|C|) x = if x < 0 then A elif x = 0 then B else C
```
introduces pattern tags A, B, and C into the _PatItems_ table in the name resolution environment.

#### 10.2.5 “do” statements in Modules

A “do” statement within a module has the following form:

```
do expr
```
The expression _expr_ is checked with an arbitrary initial type _ty_. After checking _expr_ , _ty_ is asserted to
be equal to unit. If the assertion fails, a warning rather than an error is reported. This warning is
suppressed for plain expressions without do in script files (that is, .fsx and .fsscript files).

A “do” statement may have attributes. In this example, the STAThread attribute specifies that main
uses the single-threaded apartment (STA) threading model of COM:

```
let main() =
let form = new System.Windows.Forms.Form()
System.Windows.Forms.Application.Run(form)
```
```
[<STAThread>]
do main()
```

### 10.3 IMPORT DECLARATIONS

Namespace declaration groups and module definitions can include _import declarations_ in the
following form:

```
open long-ident
```
Import declarations make elements of other namespace declaration groups and modules accessible
by the use of unqualified names. For example:

```
open FSharp.Collections
open System
```
Import declarations can be used in:

- Module definitions and their signatures.
- Namespace declaration groups and their signatures.

An import declaration is processed by first resolving the _long-ident_ to one or more namespace
declaration groups and/or modules [ _F 1_ , ..., _Fn_ ] by _Name Resolution in Module and Namespace Paths_
(§14.1.2). For example, System.Collections.Generic may resolve to one or more namespace
declaration groups—one for each assembly that contributes a namespace declaration group in the
current environment. Next, each _Fi_ is added to the environment successively by using the technique
specified in §14.1.3. An error occurs if any _Fi_ is a module that has the RequireQualifiedAccess
attribute.

### 10.4 MODULE ABBREVIATIONS

A module abbreviation defines a local name for a module long identifier, as follows:

```
module ident = long-ident
```
For example:

```
module Ops = FSharp.Core.Operators
```
Module abbreviations can be used in:

- Module definitions and their signatures.
- Namespace declaration groups and their signatures.

Module abbreviations are implicitly private to the module or namespace declaration group in which
they appear.

A module abbreviation is processed by first resolving the _long-ident_ to a list of modules by _Name
Resolution in Module and Namespace Paths_ (see §14.1). The list is then appended to the set of
names that are associated with _ident_ in the _ModulesAndNamespaces_ table.

Module abbreviations may not be used to abbreviate namespaces.


### 10 .5 ACCESSIBILITY ANNOTATIONS

Accessibilities may be specified on declaration elements in namespace declaration groups and
modules, and on members in types. The table lists the accessibilities that can appear in user code:

**Accessibility Description**

public (^) No restrictions on access.
private (^) Access is permitted only from the enclosing type, module, or namespace
declaration group.
internal (^) Access is permitted only from within the enclosing assembly, or from
assemblies whose name is listed using the InternalsVisibleTo attribute in
the current assembly.^
The default accessibilities are public. Specifically:

- Function definitions, value definitions, type definitions, and exception definitions in modules are
    public.
- Modules, type definitions, and exception definitions in namespaces are public.
- Members in type definitions are public.

Some function and value definitions may not be given an accessibility and, by their nature, have
restricted lexical scope. In particular:

- Function and value definitions in classes are lexically available only within the class being
    defined, and only from the point of their definition onward.
- Module type abbreviations are lexically available only within the module or namespace
    declaration group being defined, and only from their point of their definition onward.

Note that:

- private on a member means “private to the enclosing type or module.”
- private on a function or value definition in a module means “private to the module or
    namespace declaration group.”
- private on a type, module, or type representation in a module means “private to the module.”

The CLI compiled form of all non-public entities is internal.

```
Note: The family and protected specifications are not supported in this version of the F#
language.
```
Accessibility modifiers can appear only in the locations summarized in the following table.

**Component Location Example**
Function or value
definition in module

Precedes identifier let private x = 1^
let inline private f x = 1
let mutable private x = 1
Module definition Precedes identifier module private M =^
let x = 1
Type definition Precedes identifier type private C = A | B^
type private C<'T> = A | B
val definition in a class Precedes identifier val private x : int^
Explicit constructor Precedes identifier private new () = { inherit Base }^


**Component Location Example**
Implicit constructor Precedes identifier type C private() = ...^
Member definition Precedes identifier, but cannot
appear on:
▪ inherit definitions
▪ interface definitions
▪ abstract definitions
▪ Individual union cases

```
Accessibility for inherit,
interface, and abstract
definitions is always the same as
that of the enclosing class.
```
```
member private x.X = 1
```
Explicit property get or set
in a class

Precedes identifier member __.Item^
with private get i = 1
and private set i v = ()
Type representation Precedes identifier type Cases =^
private
| A
| B


## 11. NAMESPACE AND MODULE SIGNATURES

A signature file contains one or more namespace or module signatures, and specifies the
functionality that is implemented by its corresponding implementation file. It also can hide
functionality that the corresponding implementation file contains.

```
namespace-decl-group-signature :=
namespace long-ident module-signature-elements
module-signature =
module ident = module-signature-body
module-signature-element :=
val mutable opt curried-sig -- value signature
val value-defn -- literal value signature
type type-signatures -- type(s) signature
exception exception-signature -- exception signature
module-signature -- submodule signature
module-abbrev -- local alias for a module
import-decl -- locally import contents of a module
module-signature-elements := module-signature-element ... module-signature-element
module-signature-body =
begin module-signature-elements end
type-signature :=
abbrev-type-signature
record-type-signature
union-type-signature
anon-type-signature
class-type-signature
struct-type-signature
interface-type-signature
enum-type-signature
delegate-type-signature
type-extension-signature
type-signatures := type-signature ... and ... type-signature
type-signature-element :=
attributesopt access opt new : uncurried-sig -- constructor signature
attributesopt member access opt member-sig -- member signature
attributesopt abstract access opt member-sig -- member signature
attributesopt override member-sig -- member signature
attributesopt default member-sig -- member signature
attributesopt static member access opt member-sig -- static member signature
interface type -- interface signature
abbrev-type-signature := type-name '=' type
union-type-signature := type-name '=' union-type-cases type-extension-elements-
signatureopt
record-type-signature := type-name '=' '{' record-fields '}' type-extension-
elements-signatureopt
anon-type-signature := type-name '=' begin type-elements-signature end
```

```
class-type-signature := type-name '=' class type-elements-signature end
struct-type-signature := type-name '=' struct type-elements-signature end
interface-type-signature := type-name '=' interface type-elements-signature end
enum-type-signature := type-name ' =' enum-type-cases
delegate-type-signature := type-name ' =' delegate-sig
type-extension-signature := type-name type-extension-elements-signature
type-extension-elements-signature := with type-elements-signature end
```
The begin and end tokens are optional when lightweight syntax is used.

Like module declarations, signature declarations are processed sequentially rather than
simultaneously, so that later signature declarations are not in scope when earlier ones are
processed.

```
namespace Utilities.Part1
```
```
module Module1 =
val x : Utilities.Part2.StorageCache // error (Part2 not yet declared)
```
```
namespace Utilities.Part2
```
```
type StorageCache =
new : unit -> unit
```
### 11.1 SIGNATURE ELEMENTS

A namespace or module signature declares one or more _value signatures_ and one or more _type
definition signatures_. A type definition signature may include one or more _member signatures_ , in
addition to other elements of type definitions that are specified in the signature grammar at the
start of this chapter.

#### 11.1.1 Value Signatures

A value signature indicates that a value exists in the implementation. For example, in the signature
of a module, the following declares two value signatures:

```
module MyMap =
val mapForward : index1: int * index2: int -> string
val mapBackward : name: string -> (int * int)
```
The corresponding implementation file might contain the following implementation:

```
module MyMap =
let mapForward (index1:int, index2:int) = string index1 + "," + string index2
let mapBackward (name:string) = (0, 0)
```

#### 11.1.2 Type Definition and Member Signatures

A type definition signature indicates that a corresponding type definition appears in the
implementation. For example, in an interface type, the following declares a type definition signature
for Forward and Backward:

```
type IMap =
interface
abstract Forward : index1: int * index2: int -> string
abstract Backward : name: string -> (int * int)
end
```
A member signature indicates that a corresponding member appears on the corresponding type
definition in the implementation. Member specifications must specify argument and return types,
and can optionally specify names and attributes for parameters.

For example, the following declares a type definition signature for a type with one constructor
member, one property member Kind and one method member Purr:

```
type Cat =
new : kind:string -> Cat
member Kind : string
member Purr : unit -> Cat
```
The corresponding implementation file might contain the following implementation:

```
type Cat(kind: string) =
member x.Meow() = printfn "meow"
member x.Purr() = printfn "purr"
member x.Kind = kind
```
### 11.2 SIGNATURE CONFORMANCE

Values, types, and members that are present in implementations can be omitted in signatures, with
the following exceptions:

- Type abbreviations may not be hidden by signatures. That is, a type abbreviation type T = _ty_ in
    an implementation does not match type T (without an abbreviation) in a signature.
- Any type that is represented as a record or union must reveal either all or none of its fields or
    cases, in the same order as that specified in the implementation. Types that are represented as
    classes may reveal some, all, or none of their fields in a signature.
- Any type that is revealed to be an interface, or a type that is a class or struct with one or more
    constructors may not hide its inherit declaration, abstract dispatch slot declarations, or abstract
    interface declarations.

```
Note: This section does not yet document all checks made by the F# 3 .1 language
implementation.
```

#### 11.2.1 Signature Conformance for Functions and Values

If both a signature and an implementation contain a function or value definition with a given name,
the signature and implementation must conform as follows:

- The declared accessibilities, inline, and mutable modifiers must be identical in both the
    signature and the implementation.
- If either the signature or the implementation has the [<Literal>] attribute, both must have this
    attribute. Furthermore, the declared literal values must be identical.
- The number of generic parameters—both inferred and explicit—must be identical.
- The types and type constraints must be identical up to renaming of inferred and/or explicit
    generic parameters. For example, assume a signature is written “val head : seq<'T> -> 'T” and
    the compiler could infer the type “val head : seq<'a> -> 'a” from the implementation. These
    are considered identical up to renaming the generic parameters.
- The arities must match, as described in the next section.

**11.2.1.1 Arity Conformance for Functions and Values**
Arities of functions and values must conform between implementation and signature. Arities of
values are implicit in module signatures. A signature that contains the following results in the arity
[ _A 1_ ... _An_ ] for F:

```
val F : ty1,1 * ... * ty1,A1 - > ... -> tyn,1 * ... * tyn,An - > rty
```
Arities in a signature must be equal to or shorter than the corresponding arities in an
implementation, and the prefix must match. This means that F# makes a deliberate distinction
between the following two signatures:

```
val F: int -> int
```
and

```
val F: (int -> int)
```
The parentheses indicate a top-level function, which might be a first-class computed expression that
computes to a function value, rather than a compile-time function value.

The first signature can be satisfied only by a true function; that is, the implementation must be a
lambda value as in the following:

```
let F x = x + 1
```
```
Note: Because arity inference also permits right-hand-side function expressions, the
implementation may currently also be:
let F = fun x -> x + 1
```
The second signature

```
val F: (int -> int)
```
can be satisfied by any value of the appropriate type. For example:


```
let f =
let myTable = new System.Collections.Generic.Dictionary<int,int>(4)
fun x ->
if myTable.ContainsKey x then
myTable.[x]
else
let res = x * x
myTable.[x] <- res
res
```
—or—

```
let f = fun x -> x + 1
```
—or—

```
// throw an exception as soon as the module initialization is triggered
let f : int -> int = failwith "failure"
```
For both the first and second signatures, you can still use the functions as first-class function values
from client code—the parentheses simply act as a constraint on the implementation of the value.

The reason for this interpretation of types in value and member signatures is that CLI
interoperability requires that F# functions compile to methods, rather than to fields that are
function values. Thus, signatures must contain enough information to reveal the desired arity of a
method as it is revealed to other CLI programming languages.

**11.2.1.2 Signature Conformance for Type Functions**
If a value is a type function, then its corresponding value signature must have explicit type
arguments. For example, the implementation

```
let empty<'T> : list<'T> = printfn "hello"; []
```
conforms to this signature:

```
val empty<'T> : list<'T>
```
but not to this signature:

```
val empty : list<'T>
```
The reason for this rule is that the second signature indicates that the value is, by default,
generalizable (§14.6.7).

#### 11.2.2 Signature Conformance for Members.......................................................................

If both a signature and an implementation contain a member with a given name, the signature and
implementation must conform as follows:

- If one is an extension member, both must be extension members.
- If one is a constructor, then both must be constructors.
- If one is a property, then both must be properties.


- The types must be identical up to renaming of inferred or explicit type parameters (as for
    functions and values).
- The static, abstract, and override qualifiers must match precisely.
- Abstract members must be present in the signature if a representation is given for a type.

```
Note: This section does not yet document all checks made by the F# 3 .1 language
implementation.
```

## 12. PROGRAM STRUCTURE AND EXECUTION

F# programs are made up of a collection of assemblies. F# assemblies are made up of static
references to existing assemblies, called the _referenced assemblies_ , and an interspersed sequence of
signature (.fsi) files, implementation (.fs) files, script (.fsx or .fsscript) files, and interactively
executed code fragments.

```
implementation-file :=
namespace-decl-group ... namespace-decl-group
named-module
anonynmous-module
script-file := implementation-file
-- script file, additional directives allowed
signature-file :=
namespace-decl-group-signature ... namespace-decl-group-signature
anonynmous-module-signature
named-module-signature
named-module :=
module long-ident module-elems
anonymous-module :=
module-elems
named-module-signature :=
module long-ident module-signature-elements
anonymous-module-signature :=
module-signature-elements
script-fragment :=
module-elems -- interactively entered code fragment
```
A sequence of implementation and signature files is checked as follows.

1. Form an initial environment _sig-env 0_ and _impl-env 0_ by adding all assembly references to the
    environment in the order in which they are supplied to the compiler. This means that the
    following procedure is applied for each referenced assembly:
    - Add the top level types, modules, and namespaces to the environment.
    - For each AutoOpen attribute in the assembly, find the types, modules, and namespaces that
       the attribute references and add these to the environment.

```
The resulting environment becomes the active environment for the first file to be processed.
```
2. For each file:
    - If the _i_ th file is a signature file _file_ .fsi:


```
a. Check it against the current signature environment sig-envi- 1 , which generates the
signature Sigfile for the current file.
b. Add Sigfile to sig-envi- 1 to produce sig-env i to make it available for use in later
signature files.
```
```
The processing of the signature file has no effect on the implementation environment, so
impl-envi is identical to impl-envi- 1.
```
- If the file is an implementation file _file_ .fs, check it against the environment _impl-envi- 1_ ,
    which gives elaborated namespace declaration groups _Implfile_.
       a. If a corresponding signature _Sigfile_ exists, check _Implfile_ against _Sigfile_ during this
          process (§11.2). Then add _Sigfile_ to _impl-envi- 1_ to produce _impl-env_ i. This step makes
          the signature-constrained view of the implementation file available for use in later
          implementation files. The processing of the implementation file has no effect on the
          signature environment, so _sig-envi_ is identical to _sig-envi- 1_.
    b. If the implementation file has no signature file, add _Implfile_ to both _sig-envi- 1_ and _impl-_
       _envi- 1_ , to produce _sig-env_ i and _impl-env_ i. This makes the contents of the
       implementation available for use in both later signature and implementation files.

The signature file for a particular implementation must occur before the implementation file in the
compilation order. For every signature file, a corresponding implementation file must occur after the
file in the compilation order. Script files may not have signatures.

### 12.1 IMPLEMENTATION FILES

Implementation files consist of one or more namespace declaration groups. For example:

```
namespace MyCompany.MyOtherLibrary
```
```
type MyType() =
let x = 1
member v.P = x + 2
```
```
module MyInnerModule =
let myValue = 1
```
```
namespace MyCompany. MyOtherLibrary.Collections
```
```
type MyCollection(x : int) =
member v.P = x
```
An implementation file that begins with a module declaration defines a single namespace declaration
group with one module. For example:

```
module MyCompany.MyLibrary.MyModule
```
```
let x = 1
```
is equivalent to:

```
namespace MyCompany.MyLibrary
```

```
module MyModule =
let x = 1
```
The final identifier in the _long-ident_ that follows the module keyword is interpreted as the module
name, and the preceding identifiers are interpreted as the namespace.

_Anonymous implementation files_ do not have either a leading module or namespace declaration. Only
the scripts and the last file within an implementation group for an executable image (.exe) may be
anonymous. An anonymous implementation file contains module definitions that are implicitly
placed in a module. The name of the module is generated from the name of the source file by
capitalizing the first letter and removing the filename extensionIf the filename contains characters
that are not valid in an F# identifier, the resulting module name is unusable and a warning occurs.

Given an initial environment _env 0_ , an implementation file is checked as follows:

- Create a new constraint solving context.
- Check the namespace declaration groups in the file against the existing environment _envi- 1_ and
    incrementally add them to the environment (§10.1) to create a new environment _envi_.
- Apply default solutions to any remaining type inference variables that include default
    constraints. The defaults are applied in the order that the type variables appear in the type-
    annotated text of the checked namespace declaration groups.
- Check the inferred signature of the implementation file against any required signature by using
    _Signature Conformance_ (§11.2). The resulting signature of an implementation file is the required
    signature, if it is present; otherwise it is the inferred signature.
- Report a “value restriction” error if the resulting signature of any item that is not a member,
    constructor, function, or type function contains any free inference type variables.
- Choose solutions for any remaining type inference variables in the elaborated form of an
    expression. Process any remaining type variables in the elaborated form from left-to-right to
    find a minimal type solution that is consistent with constraints on the type variable. If no unique
    minimal solution exists for a type variable, report an error.

The result of checking an implementation file is a set of elaborated namespace declaration groups.

### 12.2 SIGNATURE FILES

Signature files specify the functionality that is implemented by a corresponding implementation file.
Each signature file contains a sequence of _namespace-decl-group-signature_ elements. The inclusion
of a signature file in compilation implicitly applies that signature type to the contents of a
corresponding implementation file.

_Anonymous signature files_ do not have either a leading module or namespace declaration. Anonymous
signature files contain _module-elems_ that are implicitly placed in a module. The name of the module
is generated from the name of the source file by capitalizing the first letter and removing the
filename extension. If the filename contains characters that are not valid in an F# identifier, the
resulting module name is unusable and a warning occurs.


Given an initial environment _env_ , a signature file is checked as follows:

- Create a new constraint solving context.
- Check each _namespace-decl-group-signaturei_ in _envi- 1_ and add the result to that environment to
    create a new environment _envi_.

The result of checking a signature file is a set of elaborated namespace declaration group types.

### 12.3 SCRIPT FILES

Script files have the.fsx or .fsscript filename extension. They are processed in the same way as
files that have the .fs extension, with the following exceptions:

- Side effects from all scripts are executed at program startup.
- For script files, the namespace FSharp.Compiler.Interactive.Settings is opened by default.
- F# Interactive references the assembly FSharp.Compiler.Interactive.Settings.dll by default,
    but the F# compiler does not. If the script uses the script helper fsi object, then the script
    should explicitly reference FSharp.Compiler.Interactive.Settings.dll.

Script files may add to the set of referenced assemblies by using the #r directive (§12.312.4).

Script files may add other signature, implementation, and script files to the list of sources by using
the #load directive. Files are compiled in the same order that was passed to the compiler, except
that each script is searched for #load directives and the loaded files are placed before the script, in
the order they appear in the script. If a filename appears in more than one #load directive, the file is
placed in the list only once, at the position it first appeared.

Script files may have #nowarn directives, which disable a warning for the entire compilation.

The F# compiler defines the COMPILED compilation symbol for input files that it has processed. F#
Interactive defines the INTERACTIVE symbol.

Script files may not have corresponding signature files.

### 12.4 COMPILER DIRECTIVES

_Compiler directives_ are declarations in non-nested modules or namespace declaration groups in the
following form:

```
# id string ... string
```
The lexical preprocessor directives #if, #else, #endif and #indent "off" are similar to compiler
directives. For details on #if, #else, #endif, see §3.3. The #indent "off" directive is described in
§19.4.

The following directives are valid in all files:


**Directive Example Short Description**

#nowarn #nowarn "54" (^) For signature (.fsi) files and implementation
(.fs) files, turns off warnings within this lexical
scope.
For script (.fsx or .fsscript) files, turns off
warnings globally.


The following directives are valid in script files:

**Directive Example Short Description**
#r
#reference

```
#r "System.Core"
#r @"Nunit.Core.dll"
#r @"c:\NUnit\Nunit.Core.dll"
#r "nunit.core, Version=2.2.2.0,
Culture=neutral,
PublicKeyToken=96d09a1eb7f44a77"
```
```
References a DLL within this entire
script.
```
#I
#Include

#I @"c:\Projects\Libraries\Bin" (^) Adds a path to the search paths for DLLs
that are referenced within this entire
script.
#load #load "library.fs"
#load "core.fsi" "core.fs"
Loads a set of signature and
implementation files into the script
execution engine.
#time #time
#time "on"
#time "off"
Enables or disables the display of
performance information, including
elapsed real time, CPU time, and
garbage collection information for each
section of code that is interpreted and
executed.
#help #help (^) Asks the script execution environment
for help.
#q
#quit
#q
#quit
Requests the script execution
environment to halt execution and exit.

### 12 .5 PROGRAM EXECUTION

Execution of F# code occurs in the context of an executing CLI program into which one or more
compiled F# assemblies or script fragments is loaded. During execution, the CLI program can use the
functions, values, static members, and object constructors that the assemblies and script fragments
define.

#### 12.5.1 Execution of Static Initializers

Each implementation file, script file, and script fragment involves a _static initializer_. The execution of
the static initializer is triggered as follows:

- For executable (.exe) files that have an explicit entry point function, the static initializer for the
    last file that appears on the command line is forced immediately as the first action in the
    execution of the entry point function.
- For executable files that have an implicit entry point, the static initializer for the last file that
    appears on the command line is the body of the implicit entry point function.
- For scripts, F# Interactive executes the static initializer for each program fragment immediately.
- For all other implementation files, the static initializer for the file is executed on first access of a
    value that has observable initialization according to the rules that follow, or first access to any
    member of any type in the file that has at least one “static let” or “static do” declaration.


At runtime, the static initializer evaluates, in order, the definitions in the file that have observable
initialization according to the rules that follow. Definitions with observable initialization in nested
modules and types are included in the static initializer for the overall file.

All definitions have observable initialization except for the following definitions in modules:

- Function definitions
- Type function definitions
- Literal definitions
- Value definitions that are generalized to have one or more type variables
- Non-mutable, non-thread-local values that are bound to an _initialization constant expression_ ,
    which is an expression whose elaborated form is one of the following:
    - A simple constant expression.
    - A null expression.
    - A use of the typeof<_> or sizeof<_> operator from FSharp.Core.Operators, or the
       defaultof<_> operator from FSharp.Core.Operators.Unchecked.
    - A let expression where the constituent expressions are initialization constant expressions.
    - A match expression where the input is an initialization constant expression, each case is a
       test against a constant, and each target is an initialization constant expression.
    - A use of one of the unary or binary operators =, <>, <, >, <=, >=, +, -, * , <<<, >>>, |||, &&&, ^^^,
       ~~~, enum<_>, not, compare, prefix –, and prefix + from FSharp.Core.Operators on one or two
       arguments, respectively. The arguments themselves must be initialization constant
       expressions, but cannot be operations on decimals or strings. Note that the operators are
       unchecked for arithmetic operations, and that the operators % and / are not included
       because their use can raise division-by-zero exceptions.
    - A use of a [<Literal>] value.
    - A use of a case from an enumeration type.
    - A use of a null case from a union type.
    - A use of a value that is defined in the same assembly and does not have observable
       initialization, or the use of a value that is defined by a “let” or “match” expression within the
       expression itself.

If the execution environment supports the concurrent execution of multiple threads of F# code, each
static initializer runs as a mutual exclusion region. The use of a mutual exclusion region ensures that
if another thread attempts to access a value that has observable initialization, that thread pauses
until static initialization is complete. A static initializer runs only once, on the first thread that
acquires entry to the mutual exclusion region.


Values that have observable initialization have implied CLI fields that are private to the assembly. If
such a field is accessed by using CLI reflection before the execution of the corresponding
initialization code, then the default value for the type of the field will be returned.

Within implementation files, generic types that have static value definitions receive a static initializer
for each generic instantiation. These initializers are executed immediately before the first
dereference of the static fields for the generic type, subject to any limitations present in the specific
CLI implementation in used. If the static initializer for the enclosing file is first triggered during
execution of the static initializer for a generic instantiation, references to static values definition in
the generic class evaluate to the default value.

For example, if external code accesses data in this example, the static initializer runs and the
program prints “hello”:

```
module LibraryModule
printfn "hello"
let data = new Dictionary<int,int>()
```
That is, the side effect of printing “hello” is guaranteed to be triggered by an access to the value
data.

If external code calls id or accesses size in the following example, the execution of the static
initializer is not yet triggered. However if external code calls f(),the execution of the static initializer
is triggered because the body refers to the value data, which has observable initialization.

```
module LibraryModule
printfn "hello"
let data = new Dictionary<int,int>()
let size = 3
let id x = x
let f() = data
```
All of the following represent definitions that do not have observable initialization because they are
initialization constant expressions.

```
let x = System.DayOfWeek.Friday
let x = 1.0
let x = "two"
let x = enum<System.DayOfWeek>(0)
let x = 1 + 1
let x : int list = []
let x : int option = None
let x = compare 1 1
let x = match true with true -> 1 | false -> 2
let x = true && true
let x = 42 >>> 2
let x = typeof<int>
let x = Unchecked.defaultof<int>
let x = Unchecked.defaultof<string>
let x = sizeof<int>
```

#### 12.5.2 Explicit Entry Point

The last file that is specified in the compilation order for an executable file may contain an explicit
entry point. The entry point is indicated by annotating a function in a module with EntryPoint
attribute:

- The EntryPoint attribute applies only to a “let”-bound function in a module. The function cannot
    be a member.
- This attribute can apply to only one function, and the function must be the last declaration in the
    last file processed on the command line. The function may be in a nested module.
- The function is asserted to have type string[] -> int before type checking. If the assertion fails,
    an error occurs.
- At runtime, the entry point is passed one argument at startup: an array that contains the same
    entries as System.Environment.GetCommandLineArgs(), minus the first entry in that array.

The function becomes the entry point to the program. At startup, F# immediately forces execution
of the static initializer for the file in which the function is declared, and then evaluates the body of
the function.



## 13. CUSTOM ATTRIBUTES AND REFLECTION

CLI languages use metadata inspection and the System.Reflection libraries to make guarantees
about how compiled entities appear at runtime. They also allow entities to be attributed by static
data, and these attributes may be accessed and read by tools and running programs. This chapter
describes these mechanisms for F#.

Attributes are given by the following grammar:

```
attribute := attribute-target : opt object-construction
attribute-set := [< attribute ; ... ; attribute >]
attributes := attribute-set ... attribute-set
attribute-target :=
assembly
module
return
field
property
param
type
constructor
event
```
### 13.1 CUSTOM ATTRIBUTES

CLI languages support the notion of _custom attributes_ which can be added to most declarations.
These are added to the corresponding elaborated and compiled forms of the constructs to which
they apply.

Custom attributes can be applied only to certain target language constructs according to the
AttributeUsage attribute, which is found on the attribute class itself. An error occurs if an attribute is
attached to a language construct that does not allow that attribute.

Custom attributes are not permitted on function or value definitions in expressions or computation
expressions. Attributes on parameters are given as follows:

```
let foo([<SomeAttribute>] a) = a + 5
```
If present, the arguments to a custom attribute must be _literal constant expressions_ , or arrays of the
same.

Custom attributes on return values are given as follows:

```
let foo a : [<SomeAttribute>] = a + 5
```

Custom attributes on primary constructors are given before the arguments and before any
accessibility annotation:

```
type Foo1 [<System.Obsolete("don't use me")>] () =
member x.Bar() = 1
```
```
type Foo2 [<System.Obsolete("don't use me")>] private () =
member x.Bar() = 1
```
Custom attributes are mapped to compiled CLI metadata as follows:

- Custom attributes map to the element that is specified by their target, if a target is given.
- A custom attribute on a type _type_ is compiled to a custom attribute on the corresponding CLI
    type definition, whose System.Type object is returned by typeof< _type_ >.
- By default, a custom attribute on a record field F for a type T is compiled to a custom attribute
    on the CLI property for the fieldthat is named F, unless the target of the attribute is field, in
    which case it becomes a custom attribute on the underlying backing field for the CLI property
    that is named _F.
- A custom attribute on a union case ABC for a type T is compiled to a custom attribute on a static
    method on the CLI type definition T. This method is called:
    - get_ABC if the union case takes no arguments
    - ABC otherwise
- Custom attributes on arguments are propagated only for arguments of member definitions, and
    not for “let”-bound function definitions.
- Custom attributes on generic parameters are not propagated.

Custom attributes that appear immediately preceding “do” statements in modules anywhere in an
assembly are attached to one of the following:

- The main entry point of the program.
- The compiled module.
- The compiled assembly.

Custom attributes are attached to the main entry point if it is valid for them to be attached to a
method according to the AttributeUsage attribute that is found on the attribute class itself, and
likewise for the assembly. If it is valid for the attribute to be attached to either the main method or
the assembly. the main method takes precedence.

For example, the STAThread attribute should be placed immediately before a top-level “do”
statement.

let main() =
let form = new System.Windows.Forms.Form()
System.Windows.Forms.Application.Run(form)

[<STAThread>]
do main()


#### 13.1.1 Custom Attributes and Signatures

During signature checking, custom attributes attached to items in F# signature files (.fsi files) are
combined with custom attributes on the corresponding element from the implementation file
according to the following algorithm:

- Start with lists _AImpl_ and _ASig_ containing the attributes in the implementation and signature, in
    declaration order.
- Check each attribute in _AImpl_ against the available attributes in _ASig_.
- If _ASig_ contains an attribute that is an exact match after evaluating attribute arguments, then
    ignore the attribute in the implementation, remove the attribute from _ASig_ , and continue
    checking;
- If _ASig_ contains an attribute that has the same attribute type but is not an exact match, then
    give a warning and ignore the attribute in the implementation;
- Otherwise, keep the attribute in the implementation.

The compiled element contains the compiled forms of the attributes from the signature and the
retained attributes from the implementation.

This means:

- When an implementation has an attribute X("abc") and the signature is missing the
    attribute, then no warning is given and the attribute appears in the compiled assembly.
- When a signature has an attribute X("abc") and the implementation is missing the attribute,
    then no warning is given, and the attribute appears in the compiled assembly.
- When an implementation has an attribute X("abc") and the signature has attribute
    X("def"), then a warning is given, and only X("def") appears in the compiled assembly.

### 13.2 REFLECTED FORMS OF DECLARATION ELEMENTS

The typeof and typedefof F# library operators return a System.Type object for an F# type definition.
According to typical implementations of the CLI execution environment, the System.Type object in
turn can be used to access further information about the compiled form of F# member declarations.
If this operation is supported in a particular implementation of F#, then the following rules describe
which declaration elements have corresponding System.Reflection objects:

- All member declarations are present as corresponding methods, properties or events.
- Private and internal members and types are included.
- Type abbreviations are not given corresponding System.Type definitions.

In addition:

- F# modules are compiled to provide a corresponding compiled CLI type declaration and
    System.Type object, although the System.Type object is not accessible by using the typeof
    operator.


However:

- Internal and private function and value definitions are not guaranteed to be given corresponding
    compiled CLI metadata definitions. They may be removed by optimization.
- Additional internal and private compiled type and member definitions may be present in the
    compiled CLI assembly as necessary for the correct implementation of F# programs.
- The System.Reflection operations return results that are consistent with the erasure of F# type
    abbreviations and F# unit-of-measure annotations.
- The definition of new units of measure results in corresponding compiled CLI type declarations
    with an associated System.Type.


## 14. INFERENCE PROCEDURES

### 14.1 NAME RESOLUTION

The following sections describe how F# resolves names in various contexts.

#### 14.1.1 Name Environments

Each point in the interpretation of an F# program is subject to an environment. The environment
encompasses:

- All referenced external DLLs (assemblies).
- _ModulesAndNamespaces_ : a table that maps _long-ident_ s to a list of signatures. Each signature is
    either a namespace declaration group signature or a module signature.
    For example, System.Collections may map to one namespace declaration group signature for
    each referenced assembly that contributes to the System.Collections namespace, and to a
    module signature, if a module called System.Collections is declared or in a referenced
    assembly.

```
If the program references multiple assemblies, the assemblies are added to the name resolution
environment in the order in which the references appear on the command line. The order is
important only if ambiguities occur in referencing the contents of assemblies—for example, if
two assemblies define the type MyNamespace.C.
```
- _ExprItems_ : a table that maps names to the following items:
    - A value
    - A union case for use when constructing data
    - An active pattern result tag for use when returning results from active patterns
    - A type name for each class or struct type
- _FieldLabels_ : a table that maps names to sets of field references for record types
- _PatItems_ : a table that maps names to the following items:
    - A union case, for use when pattern matching on data
    - An active pattern case name, for use when specifying active patterns
    - A literal definition
- _Types_ : a table that maps names to type definitions. Two queries are supported on this table:
    - Find a type by name alone. This query may return multiple types. For example, in the default
       type-checking environment, the resolution of System.Tuple returns multiple tuple types.


- Find a type by name and generic arity _n_. This query returns at most one type. For example, in
    the default type-checking environment, the resolution of System.Tuple with _n_ = 2 returns a
    single type.
- _ExtensionsInScope_ : a table that maps type names to one or more member definitions

The dot notation is resolved during type checking by consulting these tables.

#### 14.1.2 Name Resolution in Module and Namespace Paths

Given an input _long-ident_ and environment _env_ , _Name Resolution in Module and Namespace Paths_
computes the result of interpreting _long-ident_ as a module or namespace. The procedure returns a
list of modules and namespace declaration groups.

_Name Resolution in Module and Namespace Paths_ proceeds through the following steps:

1. Consult the _ModulesAndNamespaces_ table to resolve the _long-ident_ prefix to a list of modules
    and namespace declaration group signatures.
2. If any identifiers remain unresolved, recursively consult the declared modules and sub-modules
    of these namespace declaration groups.
3. Concatenate all the results.

If the _long-ident_ starts with the special pseudo-identifier keyword global, the identifier is resolved
by consulting the _ModulesAndNamespaces_ table and ignoring all open directives, including those
implied by AutoOpen attributes.

For example, if the environment contains two referenced DLLs, and each DLL has namespace
declaration groups for the namespaces System, System.Collections, and
System.Collections.Generic, _Name Resolution in Module and Namespace Paths_ for
System.Collections returns the two namespace declaration groups named System.Collections, one
from each assembly.

#### 14.1.3 Opening Modules and Namespace Declaration Groups

When a module or namespace declaration group _F_ is opened, the compiler adds items to the name
environment as follows:

1. Add each exception label for each exception type definition (§8.11) in _F_ to the _ExprItems_ and
    _PatItems_ tables in the original order of declaration in _F_.
2. Add each type definition in the original order of declaration in _F_. Adding a type definition
    involves the following procedure:

```
a. If the type is a class or struct type (or an abbreviation of such a type), add the type name to
the ExprItems table.
b. If the type definition is a record, add the record field labels to the FieldLabels table, unless
the type has the RequireQualifiedAccess attribute.
```

```
c. If the type is a union, add the union cases to the ExprItems and PatItems tables, unless the
type has the RequireQualifiedAccess attribute.
d. Add the type to the TypeNames table. If the type has a CLI-encoded generic name such as
List`1, add an entry under both List and List`1.
```
3. Add each value in the original order of declaration in _F_ , as follows:

```
a. Add the value to the ExprItems table.
b. If any value is an active pattern, add the tags of that active pattern to the PatItems table
according to the original order of declaration.
c. If the value is a literal, add it to the PatItems table.
```
4. Add the member contents of each type extension in _Fi_ to the _ExtensionsInScope_ table according
    to the original order of declaration in _Fi_.
5. Add each sub-module or sub-namespace declaration group in _Fi_ to the _ModulesAndNamespaces_
    table according to the original order of declaration in _Fi_.
6. Open any sub-modules that are marked with the FSharp.Core.AutoOpen attribute.

#### 14.1.4 Name Resolution in Expressions

Given an input _long-ident_ , environment _env_ , and an optional count _n_ of the number of subsequent
type arguments < __,...,__ >, _Name Resolution in Expressions_ computes a result that contains the
interpretation of the _long-ident_ < __,...,__ > prefix as a value or other expression item, and a residue
path _rest_.

How Name Resolution in Expressions proceeds depends on whether _long-ident_ is a single identifier
or is composed of more than one identifier.

If _long-ident_ is a single identifier _ident_ :

1. Look up _ident_ in the _ExprItems_ table. Return the result and empty _rest_.
2. If _ident_ does not appear in the _ExprItems_ table, look it up in the _Types_ table, with generic arity
    that matches _n_ if available. Return this type and empty _rest_.
3. If _ident_ does not appear in either the _ExprItems_ table or the _Types_ table, fail.

If _long-ident_ is composed of more than one identifier _ident.rest_ , _Name Resolution in Expressions_
proceeds as follows:

1. If _ident_ exists as a value in the _ExprItems_ table, return the result, with _rest_ as the residue.
2. If _ident_ does not exist as a value in the _ExprItems_ table, perform a backtracking search as
    follows:

```
a. Consider each division of long-ident into [ namespace-or-module-path ]. ident [. rest ], in
which the namespace-or-module-path becomes successively longer.
```

```
b. For each such division, consider each module signature or namespace declaration group
signature F in the list that is produced by resolving namespace-or-module-path by using Name
Resolution in Module and Namespace Paths.
c. For each such F , attempt to resolve ident [. rest ] in the following order. If any resolution
succeeds, then terminate the search:
1) A value in F. Return this item and rest.
2) A union case in F. Return this item and rest.
3) An exception constructor in F. Return this item and rest.
4) A type in F. If rest is empty, then return this type; if not, resolve using Name
Resolution for Members.
5) A [sub-]module in F. Recursively resolve rest against the contents of this module.
```
3. If steps 1 and 2 do not resolve _long-ident_ , look up _ident_ in the _Types_ table.

```
a. If the generic arity n is available, then look for a type that matches both ident and n.
b. If no generic arity n is available, and rest is not empty:
1) If the Types table contains a type ident that does not have generic arguments,
resolve to this type.
2) If the Types table contains a unique type ident that has generic arguments, resolve
to this type. However, if the overall result of the Name Resolution in Expressions
operation is a member, and the generic arguments do not appear in either the
return or argument types of the item, warn that the generic arguments cannot be
inferred from the type of the item.
3) If neither of the preceding steps resolves the type, give an error.
c. If rest is empty, return the type, otherwise resolve using Name Resolution for Members.
```
4. If steps 1-3 do not resolve _long-ident_ , look up _ident_ in the _ExprItems_ table and return the result
    and residue _rest_.
5. Otherwise, if _ident_ is a symbolic operator name, resolve to an item that indicates an implicitly
    resolved symbolic operator.
6. Otherwise, fail.

If the expression contains ambiguities, _Name Resolution in Expressions_ returns the first result that
the process generates. For example, consider the following cases:


```
module M =
type C =
| C of string
| D of string
member x.Prop1 = 3
type Data =
| C of string
| E
member x.Prop1 = 3
member x.Prop2 = 3
let C = 5
open M
let C = 4
let D = 6
```
```
let test1 = C // resolves to the value C
let test2 = C.ToString() // resolves to the value C with residue ToString
let test3 = M.C // resolves to the value M.C
let test4 = M.Data.C // resolves to the union case M.Data.C
let test5 = M.C.C // error: first part resolves to the value M.C,
// and this contains no field or property "C"
let test6 = C.Prop1 // error: the value C does not have a property Prop
let test7 = M.E.Prop2 // resolves to M.E, and then a property lookup
```
The following example shows the resolution behavior for type lookups that are ambiguous by
generic arity:

```
module M =
type C<'T>() =
static member P = 1
```
```
type C<'T,'U>() =
static member P = 1
```
```
let _ = new M.C() // gives an error
let _ = new M.C<int>() // no error, resolves to C<'T>
let _ = M.C() // gives an error
let _ = M.C<int>() // no error, resolves to C<'T>
let _ = M.C<int,int>() // no error, resolves to C<'T,'U>
let _ = M.C<_>() // no error, resolves to C<'T>
let _ = M.C<_,_>() // no error, resolves to C<'T,'U>
let _ = M.C.P // gives an error
let _ = M.C<_>.P // no error, resolves to C<'T>
let _ = M.C<_,_>.P // no error, resolves to C<'T,'U>
```

The following example shows how the resolution behavior differs slightly if one of the types has no
generic arguments.

```
module M =
type C() =
static member P = 1
```
```
type C<'T>() =
static member P = 1
```
```
let _ = new M.C() // no error, resolves to C
let _ = new M.C<int>() // no error, resolves to C<'T>
let _ = M.C() // no error, resolves to C
let _ = M.C< >() // no error, resolves to C
let _ = M.C<int>() // no error, resolves to C<'T>
let _ = M.C< >() // no error, resolves to C
let _ = M.C<_>() // no error, resolves to C<'T>
let _ = M.C.P // no error, resolves to C
let _ = M.C< >.P // no error, resolves to C
let _ = M.C<_>.P // no error, resolves to C<'T>
```
In the following example, the procedure issues a warning for an incomplete type. In this case, the
type parameter 'T cannot be inferred from the use M.C.P, because 'T does not appear at all in the
type of the resolved element M.C<'T>.P.

```
module M =
type C<'T>() =
static member P = 1
```
```
let _ = M.C.P // no error, resolves to C<'T>.P, warning given
```
The effect of these rules is to prefer value names over module names for single identifiers. For
example, consider this case:

```
let Foo = 1
```
```
module Foo =
let ABC = 2
let x1 = Foo // evaluates to 1
```
The rules, however, prefer type names over value names for single identifiers, because type names
appear in the _ExprItems_ table. For example, consider this case:

```
let Foo = 1
type Foo() =
static member ABC = 2
let x1 = Foo.ABC // evaluates to 2
let x2 = Foo() // evaluates to a new Foo()
```
#### 14.1.5 Name Resolution for Members

_Name Resolution for Members_ is a sub-procedure used to resolve _.member-ident_ [. _rest_ ] to a
member, in the context of a particular type _type_.

_Name Resolution for Members_ proceeds through the following steps:

1. Search the hierarchy of the type from System.Object to _type_.


2. At each type, try to resolve _member-ident_ to one of the following, in order:

```
a. A union case of type.
b. A property group of type.
c. A method group of type.
d. A field of type.
e. An event of type.
f. A property group of extension members of type , by consulting the ExtensionsInScope table.
g. A method group of extension members of type , by consulting the ExtensionsInScope table.
h. A nested type type-nested of type. Recursively resolve. rest if it is present, otherwise return
type-nested.
```
3. At any type, the existence of a property, event, field, or union case named _member-ident_ causes
    any methods or other entities of that same name from base types to be hidden.
4. Combine method groups with method groups from base types. For example:

```
type A() =
member this.Foo(i : int) = 0
```
```
type B() =
inherit A()
member this.Foo(s : string) = 1
```
```
let b = new B()
b.Foo(1) // resolves to method in A
b.Foo("abc") // resolves to method in B
```
#### 14.1.6 Name Resolution in Patterns

_Name Resolution for Patterns_ is used to resolve _long-ident_ in the context of pattern expressions.
The _long-ident_ must resolve to a union case, exception label, literal value, or active pattern case
name. If it does not, the _long-ident_ may represent a new variable definition in the pattern.

_Name Resolution for Patterns_ follows the same steps to resolve the _member-ident_ as _Name
Resolution in Expressions_ (§14.1.4) except that it consults the _PatItems_ table instead of the _ExprItems_
table. As a result, values are not present in the namespace that is used to resolve identifiers in
patterns. For example:

```
let C = 3
match 4 with
| C -> sprintf "matched, C = %d" C
| _ -> sprintf "no match, C = %d" C
```
results in "matched, C = 4", because C is _not_ present in the _PatItems_ table, and hence becomes a
value pattern. In contrast,


```
[<Literal>]
let C = 3
```
```
match 4 with
| C -> sprintf "matched, C = %d" C
| _ -> sprintf "no match, C = %d" C
```
results in "no match, C = 3", because C is a literal and therefore _is_ present in the _PatItems_ table.

#### 14.1.7 Name Resolution for Types

_Name Resolution for Types_ is used to resolve _long-ident_ in the context of a syntactic type. A generic
arity that matches _n_ is always available. The result is a type definition and a possible residue _rest_.

_Name Resolution for Types_ proceeds through the following steps:

1. Given _ident_ [ _.rest_ ], look up _ident_ in the _Types_ table, with generic arity _n_. Return the result and
    residue _rest_.
2. If _ident_ is not present in the _Types_ table:

```
a. Divide long-ident into [ namespace-or-module-path ]. ident [. rest ], in which the namespace-
or-module-path becomes successively longer.
b. For each such division, consider each module and namespace declaration group F in the list
that results from resolving namespace-or-module-path by using Name Resolution in Module
and Namespace Paths (§14.1.2).
c. For each such F , attempt to resolve ident [. rest ] in the following order. Terminate the
search when the expression is successfully resolved.
1) A type in F. Return this type and residue rest.
2) A [sub-]module in F. Recursively resolve rest against the contents of this module.
```
In the following example, the name C on the last line resolves to the named type M.C<_,_> because C
is applied to two type arguments:

```
module M =
type C<'T, 'U> = 'T * 'T * 'U
```
```
module N =
type C<'T> = 'T * 'T
```
```
open M
open N
```
```
let x : C<int, string> = (1, 1, "abc")
```

#### 14.1.8 Name Resolution for Type Variables

Whenever the F# compiler processes syntactic types and expressions, it assumes a context that
maps identifiers to inference type variables. This mapping ensures that multiple uses of the same
type variable name map to the same type inference variable. For example, consider the following
function:

```
let f x y = (x:'T), (y:'T)
```
In this case, the compiler assigns the identifiers x and y the same static type—that is, the same type
inference variable is associated with the name 'T. The full inferred type of the function is:

```
val f<'T> : 'T -> 'T -> 'T * 'T
```
The map is used throughout the processing of expressions and types in a left-to-right order. It is
initially empty for any member or any other top-level construct that contains expressions and types.
Entries are eliminated from the map after they are generalized. As a result, the following code
checks correctly:

```
let f () =
let g1 (x:'T) = x
let g2 (y:'T) = (y:string)
g1 3, g1 "3", g2 "4"
```
The compiler generalizes g1, which is applied to both integer and string types. The type variable 'T in
(y:'T) on the third line refers to a different type inference variable, which is eventually constrained to
be type string.

#### 14.1.9 Field Label Resolution

_Field Label Resolution_ specifies how to resolve identifiers such as _field1_ in { _field1_ = _expr_ ; ...
_fieldN_ = _expr_ }.

_Field Label Resolution_ proceeds through the following steps:

1. Look up all fields in all available types in the _Types_ table and the _FieldLabels_ table (§8.4. 2 ).
2. Return the set of field declarations.

### 14.2 RESOLVING APPLICATION EXPRESSIONS......................................................................................

Application expressions that use dot notation—such as _x.Y<int>.Z(g).H.I.j_ —are resolved
according to a set of rules that take into account the many possible shapes and forms of these
expressions and the ambiguities that may occur during their resolution. This section specifies the
exact algorithmic process that is used to resolve these expressions.

Resolution of application expressions proceeds as follows:

1. Repeatedly decompose the application expression into a leading expression _expr_ and a list of
    projections projs. Each projection has the following form:
    -. _long-ident-or-op_ is a dot lookup projection.


- _expr_ is an application projection.
- < _types_ > is a type application projection.
For example:
- x.y.Z(g).H.I.j decomposes into x.y.Z and projections (g), .H.I.j.
- x.M<int>(g) decomposes into x.M and projections <int>, (g).
- f x decomposes into f and projection x.

```
Note: In this specification we write sequences of projections by juxtaposition; for
example, (expr).long-ident<types>(expr). We also write ( .rest + projs ) to refer to
adding a residue long identifier to the front of a list of projections, which results in projs
if rest is empty and .rest projs otherwise.
```
2. After decomposition:
    - If _expr_ is a long identifier expression _long-ident_ , apply _Unqualified Lookup_ (§14.2.1) on _long-_
       _ident_ with projections _projs_.
    - If _expr_ is not such an expression, check the expression against an arbitrary initial type _ty_ , to
       generate an elaborated expression _expr_. Then process _expr_ , _ty_ , and _projs_ by using
       _Expression-Qualified Lookup_ (§14.2.3)

#### 14.2.1 Unqualified Lookup

Given an input _long-ident_ and projections _projs_ , _Unqualified Lookup_ computes the result of
“looking up” _long-ident.projs_ in an environment _env_. The first part of this process resolves a prefix
of the information in _long-ident.projs_ , and recursive resolutions typically use _Expression-Qualified
Resolution_ to resolve the remainder.

For example, _Unqualified Lookup_ is used to resolve the vast majority of identifier references in F#
code, from simple identifiers such as sin, to complex accesses such as
System.Environment.GetCommandLineArgs().Length.

_Unqualified Lookup_ proceeds through the following steps:

1. Resolve _long-ident_ by using _Name Resolution in Expressions_ (§14.1). This returns a _name_
    _resolution item item_ and a _residue long identifier rest_.

```
For example, the result of Name Resolution in Expressions for v.X.Y may be a value reference v
along with a residue long identifier .X.Y. Likewise, N.X(args).Y may resolve to an overloaded
method N.X and a residue long identifier.Y.
```
```
Name Resolution in Expressions also takes as input the presence and count of subsequent type
arguments in the first projection. If the first projection in projs is < tyargs >, Unqualified Lookup
invokes Name Resolution in Expressions with a known number of type arguments. Otherwise, it
is invoked with an unknown number of type arguments.
```
2. Apply _Item-Qualified Lookup_ for _item_ and ( _rest_ + _projs_ ).


#### 14.2.2 Item-Qualified Lookup

Given an input item _item_ and projections _projs_ , _Item-Qualified Lookup_ computes the projection
_item.projs_. This computation is often a recursive process: the first resolution uses a prefix of the
information in _item.projs_ , and recursive resolutions resolve any remaining projections.

_Item-Qualified Lookup_ proceeds as follows:

1. If _item_ is not one of the following, return an error:
    - A named value
    - A union case
    - A group of named types
    - A group of methods
    - A group of indexer getter properties
    - A single non-indexer getter property
    - A static F# field
    - A static CLI field
    - An implicitly resolved symbolic operator name
2. If the first projection is < _types_ >, then we say the resolution has a type application < _types_ > with
    remaining projections.
3. Otherwise, checking proceeds as shown in the table.

**If** **_item_** **is: Action**

A value reference v (^) 1. Instantiate the type scheme of v, which results in a type _ty_. Apply these rules:
▪ If the first projection is < _types_ >, process the types and use the results as the
arguments to instantiate the type scheme.
▪ If the first projection is not < _types_ >, the type scheme is _freshly instantiated_.
▪ If the value has the RequiresExplicitTypeArguments attribute, the first
projection must be _<types_ >.
▪ If the value has type byref< _ty 2_ >, add a byref dereference to the elaborated
expression.
▪^ Insert implicit flexibility for the use of the value (§14.4.3).^

2. Apply _Expression_ - _Qualified Lookup_ for type _ty_ and any remaining projections.
A type name, where
_projs_ begins with
< _types_ > _.long-ident_
1. Process the types and use the results as the arguments to instantiate the named
type reference, thus generating a type _ty_.
2. Apply _Name Resolution for Members_ to _ty_ and _long-ident_ , which generates a new
_item_.
3. Apply _Item-Qualified Lookup_ to the new _item_ and any remaining projections.
A group of type
names where _projs_
begins with < _types_ >
or _expr_ or _projs_ is
empty
1. Process the types and use the results as the arguments to instantiate the named
type reference, thus generating a type _ty_.
2. Process the object construction _ty_ ( _expr_ ) as an object constructor call in the same
way as new _ty_ ( _expr_ ). If _projs_ is empty then process the object construction _ty_ as
an object constructor call in the same way as (fun _arg_ - > new _ty_ ( _arg_ )), i.e.
resolve the object constructor call with no arguments.
3. Apply _Expression_ - _Qualified Lookup_ to _item_ and any remaining projections.


**If** **_item_** **is: Action**
A group of method
references

1. Apply _Method Application Resolution_ for the method group. _Method Application_
    _Resolution_ accepts an optional set of type arguments and a syntactic expression
    argument. Determine the arguments based on what _projs_ begins with:
    ▪ < _types_ > _expr_ , then use < _types_ > as the type arguments and _expr_ as the
       expression argument.
    ▪ _expr_ , then use _expr_ as the expression argument.
▪^ anything else,^ use no expression argument or type arguments.^
2. If the result of _Method Application Resolution_ is labeled with the
    RequiresExplicitTypeArguments attribute, then explicit type arguments are
    required.
3. Let _fty_ be the actual return type that results from _Method Application Resolution_.
    Apply _Expression_ - _Qualified Lookup_ to _fty_ and any remaining projections.
A group of property
indexer references
1. Apply _Method Application Resolution_ , and use the underlying getter indexer
methods for the method group.
2. Determine the arguments to _Method Application Resolution_ as described for a
group of methods.
A static field
reference
1. Check the field for accessibility and attributes.
2. Let _fty_ be the actual type of the field, taking into account the type _ty_ via which the
field was accessed in the case where this is a field in a generic type.
3. Apply _Expression_ - _Qualified Lookup_ to _fty_ and _projs_.
A union case tag,
exception tag, or
active pattern result
element tag
1. Check the tag for accessibility and attributes.
2. If _projs_ begins with _expr_ , use _expr_ as the expression argument.
3. Otherwise, use no expression argument or type arguments. In this case, build a
function expression for the union case.
4. Let _fty_ be the actual type of the union case.
5. Apply _Expression_ - _Qualified Lookup_ to _fty_ and remaining _projs_.

A CLI event reference (^) 1. Check the event for accessibility and attributes.

2. Let _fty_ be the actual type of the event.
3. Apply _Expression_ - _Qualified Lookup_ to _fty_ and _projs_.
An implicitly resolved
symbolic operator
name _op_
1. If _op_ is a unary, binary or the ternary operator ?<-, resolve to the following
expressions, respectively:
(fun (x:^a) -> (^a : static member (op) : ^a -> ^b) x)
(fun (x:^a) (y:^b) ->
((^a or ^b) : static member (op) : ^a * ^b -> ^c) (x,y))
(fun (x:^a) (y:^b) (z:^c) ->
((^a or ^b or ^c) : static member (op) : ^a * ^b * ^c -> ^d) (x,y,z))
2. The resulting expressions are static member constraint invocation expressions (§ 0 ),
which enable the default interpretation of operators by using type-directed
member resolution.
3. Recheck the entire expression with additional subsequent projections _.projs_.

#### 14.2.3 Expression-Qualified Lookup

Given an elaborated expression _expr_ of type _ty_ , and projections _projs_ , _Expression_ - _Qualified Lookup_
computes the “lookups or applications” for _expr.projs_.


Expression-Qualified Lookup proceeds through the following steps:

1. Inspect _projs_ and process according to the following table.

**_projs_** (^) **Action Comments**
Empty Assert that the type of the overall,
original application expression is _ty_.
Checking is complete.
Starts with( _expr2_ ) Apply _Function Application Resolution_
(§14.3).
Checking is complete when _Function
Application Resolution_ returns.
Starts with< _types_ > Fail. Type instantiations may not be applied
to arbitrary expressions; they can apply
only to generic types, generic methods,
and generic values.
Starts with. _long-ident_ Resolve _long-ident_ using _Name
Resolution for Members_ (§14.1.4)_._
Return a name resolution item _item_ and
a residue long identifier _rest_. Continue
processing at step 2.
For example, for _ty_ = string and
_long-ident_ = Length , _Name
Resolution for Members_ returns a
property reference to the CLI instance
property System.String.Length.^

2. If Step 1 returned an _item_ and _rest_ , report an error if _item_ is not one of the following:
    - A group of methods.
    - A group of instance getter property indexers.
    - A single instance, non-indexer getter property.
    - A single instance F# field.
    - A single instance CLI field.
3. Proceed based on _item_ as shown in the table:

**If** **_item_** **is: Action**

Group of methods (^) 1. Apply _Method Application Resolution_ for the method group. _Method
Application Resolution_ accepts an optional set of type arguments and a
syntactic expression argument. If _projs_ begins with:
▪ < _types_ >( _arg_ ), then use < _types_ > as the type arguments and _arg_ as
the expression argument.
▪ ( _arg_ ), then use _arg_ as the expression argument.
▪^ otherwise,^ use no expression argument or type arguments.^

2. Let _fty_ be the actual return type resulting from _Method Application_
    _Resolution_. Apply _Expression-Qualified Lookup_ to _fty_ and any
    remaining projections.

Group of indexer properties (^) 1. Apply _Method Application Resolution_ and use the underlying getter
indexer methods for the method group.

2. Determine the arguments to _Method Application Resolution_ as
    described for a group of methods.
Non-indexer getter property Apply _Method Application Resolution_ for the method group that contains
only the getter method for the property, with no type arguments and
one () argument.


**If** **_item_** **is: Action**
Instance intermediate language
(IL) or F# field _F_

1. Check the field for accessibility and attributes.
2. Let _fty_ be the actual type of the field (taking into account the type _ty_
    by which the field was accessed).
3. Assert that _ty_ is a subtype of the actual containing type of the field.
4. Produce an elaborated form for _expr.F_. If _F_ is a field in a value type
    then take the address of _expr_ by using the _AddressOf_ ( _expr_ ,
    NeverMutates) operation §6.9.4.
5. Apply _Expression-Qualified Lookup_ to _fty_ and _projs_.

### 14.3 FUNCTION APPLICATION RESOLUTION

Given expressions _f_ and _expr_ where _f_ has type _ty_ , and given subsequent projections _projs_ , _Function
Application Resolution_ does the following:

1. Asserts that _f_ has type _ty 1_ - > _ty 2_ for new inference variables _ty 1_ and _ty 2._
2. If the assertion succeeds:

```
a. Check expr with the initial type ty 1.
b. Process projs using Expression-Qualified against ty 2.
```
3. If the assertion fails, and _expr_ has the form { _computation-expr_ }:

```
a. Check the expression as the computation expression form f { computation-expr }, giving
result type ty 1.
b. Process projs using Expression-Qualified Lookup against ty 1.
```
### 14.4 METHOD APPLICATION RESOLUTION

Given a method group _M_ , optional type arguments < _ActualTypeArgs_ >, an optional syntactic argument
obj, an optional syntactic argument arg, and overall initial type _ty_ , _Method Application Resolution_
resolves the overloading based on the partial type information that is available. It also:

- Resolves optional and named arguments.
- Resolves “out” arguments.
- Resolves post-hoc property assignments.
- Applies method application resolution.
- Inserts _ad hoc_ conversions that are only applied for method calls.

If no syntactic argument is supplied, _Method Application Resolution_ tries to resolve the use of the
method as a first class value, such as the method call in the following example:

```
List.map System.Environment.GetEnvironmentVariable ["PATH"; "USERNAME"]
```
_Method Application Resolution_ proceeds through the following steps:


1. Restrict the candidate method group _M_ to those methods that are _accessible_ from the point of
    resolution.
2. If an argument _arg_ is present, determine the sets of _unnamed_ and _named actual arguments_ ,
    _UnnamedActualArgs_ and _NamedActualArgs_ :

```
a. Decompose arg into a list of arguments:
```
- If arg is a syntactic tuple arg1 ,..., argN, use these arguments.
- If arg is a syntactic unit value (),use a zero-length list of arguments.

```
b. For each argument:
```
- If arg is a binary expression of the form name=expr, it is a named actual argument.
- Otherwise, arg is an unnamed actual argument.

```
If there are no named actual arguments, and M has only one candidate method, which accepts
only one required argument, ignore the decomposition of arg to tuple form. Instead, arg itself is
the only named actual argument.
```
```
All named arguments must appear after all unnamed arguments.
```
```
Examples:
```
```
x.M(1, 2) has two unnamed actual arguments.
```
```
x.M(1, y = 2) has one unnamed actual argument and one named actual argument.
```
```
x.M(1, (y = 2)) has two unnamed actual arguments.
```
```
x.M( printfn "hello"; ()) has one unnamed actual argument.
```
```
x.M((a, b)) has one unnamed actual argument.
```
```
x.M(()) has one unnamed actual argument.
```
3. Determine the named and unnamed _prospective actual argument types_ , called _ActualArgTypes_.
    - If an argument _arg_ is present, the prospective actual argument types are fresh type
       inference variables for each unnamed and named actual argument.
       - If the argument has the syntactic form of an address-of expression & _expr_ after ignoring
          parentheses around the argument, equate this type with a type byref< _ty_ > for a fresh
          type _ty_.
       - If the argument has the syntactic form of a function expression fun _pat 1_ ... _patn_ - > _expr_
          after ignoring parentheses around the argument, equate this type with a type _ty 1_ - > ...
          _tyn_ - > _rty_ for fresh types _ty 1_ ... _tyn_.
    - If no argument _arg_ is present:


```
a. If the method group contains a single method, the prospective unnamed argument
types are one fresh type inference variable for each required, non-“out” parameter that
the method accepts.
b. If the method group contains more than one method, the expected overall type of the
expression is asserted to be a function type dty - > rty.
▪ If dty is a tuple type ( dty 1 * .. * dty N), the prospective argument types are ( dty 1,
.. , dty N).
```
```
▪ If dty is unit, then the prospective argument types are an empty list.
```
```
▪ If dty is any other type, the prospective argument types are dty alone.
```
```
c. Subsequently:
▪ The method application is considered to have one unnamed actual argument for
each prospective unnamed actual argument type.
```
```
▪ The method application is considered to have no named actual arguments.
```
4. For each candidate method in M, attempt to produce zero, one, or two _prospective method calls_
    Mpossible as follows:

```
a. If the candidate method is generic and has been generalized, generate fresh type inference
variables for its generic parameters. This results in the FormalTypeArgs for Mpossible.
b. Determine the named and unnamed formal parameters , called NamedFormalArgs and
UnnamedFormalArgs respectively, by splitting the formal parameters for M into parameters
that have a matching argument in NamedActualArgs and parameters that do not.
c. If the number of UnnamedFormalArgs exceeds the number of UnnamedActualArgs , then modify
UnnamedFormalArgs as follows:
```
- Determine the suffix of _UnnamedFormalArgs_ beyond the number of _UnnamedActualArgs_.
- If all formal parameters in the suffix are “out” arguments with byref type, remove the
    suffix from _UnnamedFormalArgs_ and call it _ImplicitlyReturnedFormalArgs_.
- If all formal parameters in the suffix are optional arguments, remove the suffix from
    _UnnamedFormalArgs_ and call it _ImplicitlySuppliedFormalArgs_.

```
d. If the last element of UnnamedFormalArgs has the ParamArray attribute and type pty [] for
some pty , then modify UnnamedActualArgs as follows:
```
- If the number of _UnnamedActualArgs_ exceeds the number of _UnnamedFormalArgs- 1_ ,
    produce a prospective method call named _ParamArrayActualArgs_ that has the excess of
    _UnnamedActualArgs_ removed.
- If the number of _UnnamedActualArgs_ equals the number of _UnnamedFormalArgs_ - 1 , produce
    two prospective method calls:

```
▪ One has an empty ParamArrayActualArgs.
```

```
▪ One has no ParamArrayActualArgs.
```
- If _ParamArrayActualArgs_ has been produced, then Mpossible is said to _use ParamArray_
    _conversion with type pty_.

```
e. Associate each name = arg in NamedActualArgs with a target. A target is a named formal
parameter , a settable return property , or a settable return field as follows:
```
- If one of the arguments in _NamedFormalArgs_ has name _name_ , that argument is the target.
- If the return type of M, before the application of any type arguments _ActualTypeArgs_ ,
    contains a settable property _name_ ,then name is the target. The available properties
    include any property extension members of type, found by consulting the
    _ExtensionsInScope_ table.
- If the return type of M, before the application of any type arguments _ActualTypeArgs_ ,
    contains a settable field _name_ , then _name_ is the target.

```
f. No prospective method call is generated if any of the following are true:
```
- A named argument cannot be associated with a target.
- The number of _UnnamedActualArgs_ is less than the number of _UnnamedFormalArgs_ after
    steps 4 a-e.
- The number of _ActualTypeArgs_ , if any actual type arguments are present, does not
    precisely equal the number of _FormalTypeArgs_ for M.
- The candidate method is static and the optional syntactic argument obj is present, or
    the candidate method is an instance method and obj is not present.
5. Attempt to apply initial types before argument checking. If only one prospective method call
Mpossible exists, _assert_ Mpossible by performing the following steps:

```
a. Verify that each ActualTypeArgi is equal to its corresponding FormalTypeArgi.
b. Verify that the type of obj is a subtype of the containing type of the method M.
c. For each UnnamedActualArgi and UnnamedFormalArgi , verify that the corresponding
ActualArgType coerces to the type of the corresponding argument of M.
d. If Mpossible uses ParamArray conversion with type pty , then for each ParamArrayActualArgi ,
verify that the corresponding ActualArgType coerces to pty.
e. For each NamedActualArgi that has an associated formal parameter target, verify that the
corresponding ActualArgType coerces to the type of the corresponding argument of M.
f. For each NamedActualArgi that has an associated property or field setter target, verify that
the corresponding ActualArgType coerces to the type of the property or field.
g. Verify that the prospective formal return type coerces to the expected actual return type. If
the method M has return type rty , the formal return type is defined as follows:
```

- If the prospective method call contains _ImplicitlyReturnedFormalArgs_ with type ty 1 , ...,
    tyN, the formal return type is _rty_ * ty 1 * ... * tyN. If _rty_ is unit then the formal
    return type is ty 1 * ... * tyN.
- Otherwise the formal return type is _rty_.
6. Check and elaborate argument expressions. If _arg_ is present:
- Check and elaborate each unnamed actual argument expression _argi_. Use the
corresponding type in _ActualArgTypes_ as the initial type.
- Check and elaborate each named actual argument expression _argi_. Use the corresponding
type in _ActualArgTypes_ as the initial type.
7. Choose a unique Mpossible according to the following rules:
- For each Mpossible, determine whether the method is _applicable_ by attempting to assert
Mpossible as described in step 4a). If the actions in step 4a detect an inconsistent constraint set
(§14.5), the method is not applicable. Regardless, the overall constraint set is left unchanged
as a result of determining the applicability of each Mpossible.
- If a unique applicable Mpossible exists, choose that method. Otherwise, choose the unique _best_
Mpossible by applying the following criteria, in order:
1) Prefer candidates whose use does not constrain the use of a user-introduced generic
type annotation to be equal to another type.

```
2) Prefer candidates that do not use ParamArray conversion. If two candidates both use
ParamArray conversion with types pty 1 and pty 2 , and pty 1 feasibly subsumes pty 2 , prefer
the second; that is, use the candidate that has the more precise type.
```
```
3) Prefer candidates that do not have ImplicitlyReturnedFormalArgs.
```
```
4) Prefer candidates that do not have ImplicitlySuppliedFormalArgs.
```
```
5) If two candidates have unnamed actual argument types ty 11 ... ty1n and ty 21 ... ty2n , and
each ty1i either
```
```
a. feasibly subsumes ty2i , or
```
```
b. ty2i is a System.Func type and ty1i is some other delegate type,
```
```
then prefer the second candidate. That is, prefer any candidate that has the more
specific actual argument types, and consider any System.Func type to be more specific
than any other delegate type.
```
```
6) Prefer candidates that are not extension members over candidates that are.
```
```
7) To choose between two extension members, prefer the one that results from the most
recent use of open.
```

```
8) Prefer candidates that are not generic over candidates that are generic—that is, prefer
candidates that have empty ActualArgTypes.
```
```
Report an error if steps 1) through 8 ) do not result in the selection of a unique better method.
```
8. Once a unique best Mpossible is chosen, commit that method.
9. Apply attribute checks.
10. Build the resulting elaborated expression by following these steps:

```
a. If the type of obj is a variable type or a value type, take the address of obj by using the
AddressOf ( obj , PossiblyMutates) operation (§6.9.4).
b. Build the argument list by:
```
- Passing each argument corresponding to an _UnamedFormalArgs_ where the argument is an
    optional argument as a Some value.
- Passing a None value for each argument that corresponds to an
    _ImplicitlySuppliedFormalArgs_.
- Applying coercion to arguments.

```
c. Bind ImplicitlyReturnedFormalArgs arguments by introducing mutable temporaries for each
argument, passing them as byref parameters, and building a tuple from these mutable
temporaries and any method return value as the overall result.
d. For each NamedActualArgs whose target is a settable property or field, assign the value into
the property.
e. If arg is not present, return a function expression that represents a first class function value.
```
Two additional rules apply when checking arguments (see §8.13.7 for examples):

- If a formal parameter has delegate type _D_ , an actual argument _farg_ has known type
    _ty 1_ - > ... -> _tyn_ - > _rty_ , and the number of arguments of the Invoke method of delegate type
    _D_ is precisely _n_ , interpret the formal parameter in the same way as the following:
       new _D_ (fun _arg 1_ ... _argn_ - > _farg arg 1_ ... _argn_ ).

```
For more information on the conversions that are automatically applied to arguments, see
§8.13.6.
```
- If a formal parameter is an “out” parameter of type byref< _ty_ >, and an actual argument type is
    not a byref type, interpret the actual parameter in the same way as type ref< _ty_ >. That is, an F#
    reference cell can be passed where a byref< _ty_ > is expected.

One effect of these additional rules is that a method that is used as a first class function value can
resolve even if a method is overloaded and no further information is available. For example:

```
let r = new Random()
let roll = r.Next;;
```

_Method Application Resolution_ results in the following, despite the fact that in the standard CLI
library, System.Random.Next is overloaded:

```
val roll : int -> int
```
The reason is that if the initial type contains no information about the expected number of
arguments, the F# compiler assumes that the method has one argument.

#### 14.4.1 Additional Propagation of Known Type Information in F# 3.1

In the above descreiption of F# overload resolution, the argument expressions of a call to an
overloaded set of methods

```
callerObjArgTy .Method( callerArgExpr1 , ... callerArgExprN )
```
calling

```
calledObjArgTy .Method( calledArgTy1 , ... calledArgTyN )
```
In F# 3.1 and subsequently, immediately prior to checking argument expressions, each argument
position of the unnamed caller arguments for the method call is analysed to propagate type
information extracted from method overloads to the expected types of lambda expressions. The
new rule is applied when

- the candidates are overloaded
- the caller argument at the given unnamed argument position is a syntactic lambda, possible
    parenthesized
- all the corresponding formal called arguments have _calledArgTy_ either of

```
o function type “ calledArgDomainTy1 - > ... -> calledArgDomainTyN - >
calledArgRangeTy “ (after taking into account “function to delegate” adjustments), or
o some other type which would cause an overload to be discarded
```
- at least one overload has enough curried lambda arguments for it corresponding expected
    function type

In this case, for each unnamed argument position, then for each overload:

- Attempt to solve “ _callerObjArgTy_ = _calledObjArgTy_ ” for the overload, if the overload is for an
    instance member. When making this application, only solve type inference variables present in
    the _calledObjArgTy_. If any of these conversions fail, then skip the overload for the purposes of
    this rule
- Attempt to solve “ _callerArgTy_ = ( _calledArgDomainTy1_ - > ... -> _calledArgDomainTyN_ - > ?)”. If
    this fails, then skip the overload for the purposes of this rule

#### 14.4.2 Conditional Compilation of Member Calls

If a member definition has the System.Diagnostics.Conditional attribute, then any application of
the member is adjusted as follows:


- The Conditional(" _symbol_ ") attribute may apply to methods only.
- Methods that have the Conditional attribute must have return type unit. The return type may
    be checked either on use of the method or definition of the method.
- If _symbol_ is not in the current set of conditional compilation symbols, the compiler eliminates
    application expressions that resolve to calls to members that have the Conditional attribute and
    ensures that arguments are not evaluated. Elimination of such expressions proceeds first with
    static members and then with instance members, as follows:
    - Static members: Type.M( _args_ )  ()
    - Instance members: expr.M( _args_ )  ()

#### 14.4.3 Implicit Insertion of Flexibility for Uses of Functions and Members

At each use of a data constructor, named function, or member that forms an expression, flexibility is
implicitly added to the expression. This flexibility is associated with the use of the function or
member, according to the inferred type of the expression. The added flexibility allows the item to
accept arguments that are statically known to be subtypes of argument types to a function without
requiring explicit upcasts

The flexibility is added by adjusting each expression _expr_ which represents a use of a function or
member as follows:

- The type of the function or member is decomposed to the following form:

```
ty 11 * ... * ty 1n - > ... -> ty m1 * ... * ty mn -> rty
```
- If the type does not decompose to this form, no flexibility is added.
- The positions _ty_ ij are called the “parameter positions” for the type. For each parameter position
    where _ty_ ij is not a sealed type, and is not a variable type, the type is replaced by a fresh type
    variable _ty'_ ij with a coercion constraint _ty'_ ij :> _ty_ ij.
- After the addition of flexibility, the expression elaborates to an expression of type

```
ty' 11 * ... * ty' 1n - > ... -> ty' m1 * ... * ty' mn -> rty
```
```
but otherwise is semantically equivalent to expr by creating an anonymous function expression
and inserting appropariate coercions on arguments where necessary.
```
This means that F# functions whose inferred type includes an unsealed type in argument position
may be passed subtypes when called, without the need for explicit upcasts. For example:

```
type Base() =
member b.X = 1
```
```
type Derived(i : int) =
inherit Base()
member d.Y = i
```
```
let d = new Derived(7)
```
```
let f (b : Base) = b.X
```

```
// Call f: Base -> int with an instance of type Derived
let res = f d
```
```
// Use f as a first-class function value of type : Derived -> int
let res2 = (f : Derived -> int)
```
The F# compiler determines whether to insert flexibility after explicit instantiation, but before any
arguments are checked. For example, given the following:

```
let M<'b>(c :'b, d :'b) = 1
let obj = new obj()
let str = ""
```
these expressions pass type-checking:

```
M<obj>(obj, str)
M<obj>(str, obj)
M<obj>(obj, obj)
M<obj>(str, str)
M(obj, obj)
M(str, str)
```
These expressions do not, because the target type is a variable type:

```
M(obj, str)
M(str, obj)
```
### 14.5 CONSTRAINT SOLVING

Constraint solving involves processing (“solving”) non-primitive constraints to reduce them to
primitive, normalized constraints on type variables. The F# compiler invokes constraint solving every
time it adds a constraint to the set of current inference constraints at any point during type
checking.

Given a type inference environment, the _normalized form_ of constraints is a list of the following
primitive constraints where _typar_ is a type inference variable:

```
typar :> type
typar : null
( type or ... or type ) : ( member-sig )
typar : (new : unit -> 'T)
typar : struct
typar : unmanaged
typar : comparison
typar : equality
typar : not struct
typar : enum< type >
typar : delegate< type, type >
```
Each newly introduced constraint is solved as described in the following sections.


#### 14.5.1 Solving Equational Constraints

New equational constraints in the form _typar_ = _type_ or _type_ = _typar_ , where _typar_ is a type
inference variable, cause _type_ to replace _typar_ in the constraint problem; _typar_ is eliminated. Other
constraints that are associated with _typar_ are then no longer primitive and are solved again.

New equational constraints of the form _type_ < _tyarg 11_ ,..., _tyarg1n_ > = _type_ < _tyarg 21_ ,..., _tyarg2n_ >
are reduced to a series of constraints _tyarg1i_ = _tyarg2i_ on identical named types and solved again.

#### 14.5.2 Solving Subtype Constraints

Primitive constraints in the form _typar_ :> obj are discarded.

New constraints in the form _type_ 1 :> _type_ 2 , where _type_ 2 is a sealed type, are reduced to the
constraint _type_ 1 = _type_ 2 and solved again.

New constraints in either of these two forms are reduced to the constraints _tyarg 11_ = _tyarg 21_ ...
_tyarg1n = tyarg2n_ and solved again:

```
type < tyarg 11 ,..., tyarg1n > :> type < tyarg 21 ,..., tyarg2n >
type < tyarg 11 ,..., tyarg1n > = type < tyarg 21 ,..., tyarg2n >
```
```
Note: F# generic types do not support covariance or contravariance. That is, although
single-dimensional array types in the CLI are effectively covariant, F# treats these types
as invariant during constraint solving. Likewise, F# considers CLI delegate types as
invariant and ignores any CLI variance type annotations on generic interface types and
generic delegate types.
```
New constraints of the form _type 1_ < _tyarg 11_ ,..., _tyarg1n_ > :> _type 2_ < _tyarg 21_ ,..., _tyarg2n_ > where
_type 1_ and _type 2_ are hierarchically related, are reduced to an equational constraint on two
instantiations of _type 2_ according to the subtype relation between _type 1_ and _type 2_ , and solved again.

For example, if MySubClass<'T> is derived from MyBaseClass<list<'T>>, then the constraint

```
MySubClass<'T> :> MyBaseClass<int>
```
is reduced to the constraint

```
MyBaseClass<list<'T>> :> MyBaseClass<list<int>>
```
and solved again, so that the constraint 'T = int will eventually be derived.

```
Note : Subtype constraints on single-dimensional array types ty[] :> ty are reduced to
residual constraints, because these types are considered to be subtypes of System.Array,
System.Collections.Generic.IList<'T>, System.Collections.Generic.ICollection<'T>,
and System.Collections.Generic.IEnumerable<'T>. Multidimensional array types
ty[,...,] are also subtypes of System.Array.
```

```
Types from other CLI languages may, in theory, support multiple instantiations of the
same interface type, such as C : I<int>, I<string>. Consequently, it is more difficult to
solve a constraint such as C :> I<'T>. Such constraints are rarely used in practice in F#
coding. To solve this constraint, the F# compiler reduces it to a constraint C :> I<'T>,
where I<'T> is the first interface type that occurs in the tree of supported interface
types, when the tree is ordered from most derived to least derived, and iterated left-to-
right in the order of the declarations in the CLI metadata.
```
```
The F# compiler ignores CLI variance type annotations on interfaces.
```
New constraints of the form _type_ :> 'b are solved again as _type_ = 'b.

```
Note : Such constraints typically occur only in calls to generic code from other CLI
languages where a method accepts a parameter of a “naked” variable type—for
example, a C# 2.0 function with a signature such as T Choose<'T>(T x, T y).
```
#### 14.5.3 Solving Nullness, Struct, and Other Simple Constraints

New constraints in any of the following forms, where _type_ is not a variable type, are reduced to
further constraints:

```
type : null
type : (new : unit -> 'T)
type : struct
type : not struct
type : enum< type >
type : delegate< type, type >
type : unmanaged
```
The compiler then resolves them according to the requirements for each kind of constraint listed in
§5.2 and §5.4.8.

#### 14.5.4 Solving Member Constraints

New constraints in the following form ) are solved as _member constraints_ (§5.2.3):

```
(type 1 or ... or typen) : (member-sig)
```
A member constraint is satisfied if one of the types in the _support set type 1_ ... _typen_ satisfies the
member constraint. A static type _type_ satisfies a member constraint in the form
(staticopt member _ident_ : _arg-type_ 1 * ... * _arg-type_ n _- > ret-type_ )
if all of the following are true:

- _type_ is a named type whose type definition contains the following member, which takes _n_
    arguments:
    staticopt member _ident_ : _formal-arg-type_ 1 * ... * _formal-arg-type_ n _- > ret-type_
- The _type_ and the constraint are both marked static or neither is marked static.
- The assertion of type inference constraints on the arguments and return types does not result in
    a type inference error.

As mentioned in §5.2.3, a type variable may not be involved in the support set of more than one
member constraint that has the same name, staticness, argument arity, and support set. If a type


variable is in the support set of more than one such constraint, the argument and return types are
themselves constrained to be equal.

**14.5.4.1 Simulation of Solutions for Member Constraints**
Certain types are assumed to implicitly define static members even though the actual CLI metadata
for types does not define these operators. This mechanism is used to implement the extensible
conversion and math functions of the F# library including sin, cos, int, float, (+), and (-). The
following table shows the static members that are implicitly defined for various types.

**Type Implicitly defined static members**
Integral types:
byte, sbyte, int16, uint16, int32, uint32, int64,
uint64, nativeint, unativeint

op_BitwiseAnd, op_BitwiseOr, op_ExclusiveOr,
op_LeftShift, op_RightShift, op_UnaryPlus,
op_UnaryNegation, op_Increment, op_Decrement,
op_LogicalNot, op_OnesComplement
op_Addition, op_Subtraction, op_Multiply,
op_Division, op_Modulus, op_UnaryPlus
op_Explicit: takes the type as an argument and
returns byte, sbyte, int16, uint16, int32, uint32,
int64, uint64, float32, float, decimal,
nativeint, or unativeint
Signed integral CLI types:
sbyte, int16, int32, int64 and nativeint

op_UnaryNegation
Sign
Abs
Floating-point CLI types:
float32 and float

Sin, Cos, Tan, Sinh, Cosh, Tanh, Atan, Acos, Asin,
Exp, Ceiling, Floor, Round, Log10, Log, Sqrt, Atan2,
Pow
op_Addition, op_Subtraction, op_Multiply,
op_Division, op_Modulus, op_UnaryPlus
op_UnaryNegation
Sign
Abs
op_Explicit: takes the type as an argument and
returns byte, sbyte, int16, uint16, int32, uint32,
int64, uint64, float32, float, decimal,
nativeint, or unativeint
decimal type
**Note** : The decimal type is included only for the Sign
static member. This is deliberate: in the CLI,
System.Decimal includes the definition of static
members such as op_Addition and the F# compiler
does not need to simulate the existence of these
methods.

```
Sign
```
String type string op_Addition^
op_Explicit: takes the type as an argument and
return byte, sbyte, int16, uint16, int32, uint32,
int64, uint64, float32, float or decimal.

#### 14.5.5 Over-constrained User Type Annotations

An implementation of F# must give a warning if a type inference variable that results from a user
type annotation is constrained to be a type other than another type inference variable. For example,
the following results in a warning because 'T has been constrained to be precisely string:

```
let f (x:'T) = (x:string)
```

During the resolution of overloaded methods, resolutions that do not give such a warning are
preferred over resolutions that do give such a warning.

### 14.6 CHECKING AND ELABORATING FUNCTION, VALUE, AND MEMBER DEFINITIONS

This section describes how function, value, and member definitions are checked, generalized, and
elaborated. These definitions occur in the following contexts:

- Module declarations
- Class type declarations
- Expressions
- Computation expressions

Recursive definitions can also occur in each of these locations. In addition, member definitions in a
mutually recursive group of type declarations are implicitly recursive.

Each definition is one of the following:

- A function definition :

```
inline opt ident 1 pat 1 ... patn : opt return-typeopt = rhs-expr
```
- A value definition, which defines one or more values by matching a pattern against an
    expression:
    mutable _opt pat_ : _opt typeopt_ = _rhs-expr_
- A member definition:

```
static opt member identopt ident pat 1 ... patn = expr
```
For a function, value, or member definition in a class:

1. If the definition is an instance function, value or member, checking uses an environment to
    which both of the following have been added:
    - The instance variable for the class, if one is present.
    - All previous function and value definitions for the type, whether static or instance.
2. If the definition is static (that is, a static function, value or member defeinition), checking uses an
    environment to which all previous static function, value, and member definitions for the type
    have been added.

#### 14.6.1 Ambiguities in Function and Value Definitions

In one case, an ambiguity exists between the syntax for function and value definitions. In particular,
_ident pat_ = _expr_ can be interpreted as either a function or value definition. For example, consider
the following:

```
type OneInteger = Id of int
```

```
let Id x = x
```
In this case, the ambiguity is whether Id x is a pattern that matches values of type OneInteger or is
the function name and argument list of a function called Id. In F# this ambiguity is always resolved
as a function definition. In this case, to make a value definition, use the following syntax in which the
ambiguous pattern is enclosed in parentheses:

```
let v = if 3 = 4 then Id "yes" else Id "no"
let (Id answer) = v
```
#### 14.6.2 Mutable Value Definitions

Value definitions may be marked as mutable. For example:

```
let mutable v = 0
while v < 10 do
v <- v + 1
printfn "v = %d" v
```
These variables are implicitly dereferenced when used.

#### 14.6.3 Processing Value Definitions

A value definition _pat_ = _rhs-expr_ with optional pattern type _type_ is processed as follows:

1. The pattern _pat_ is checked against a fresh initial type _ty_ (or _type_ if such a type is present). This
    check results in zero or more identifiers _ident 1 ... identm_ , each of type _ty 1 ... tym_.
2. The expression _rhs-expr_ is checked against initial type _ty_ , resulting in an elaborated form _expr_.
3. Each _identi_ (of type _tyi_ ) is then generalized (§14.6.7) and yields generic parameters < _typarsj_ >.
4. The following rules are checked:
    - All _identj_ must be distinct.
    - Value definitions may not be inline.
5. If _pat_ is a single value pattern, the resulting elaborated definition is:

```
ident < typars 1 > = expr
body-expr
```
6. Otherwise, the resulting elaborated definitions are the following, where _tmp_ is a fresh identifier
    and each _expri_ results from the compilation of the pattern _pat_ (§ 7 ) against input _tmp_.

```
tmp < typars 1 ... typars n> = expr
ident 1 < typars 1 > = expr 1
```
```
identn < typars n> = exprn
```
#### 14.6.4 Processing Function Definitions

A function definition _ident 1 pat 1_ ... _patn_ = _rhs-expr_ is processed as follows:

1. If _ident 1_ is an active pattern identifier then active pattern result tags are added to the
    environment (§10.2.4).


2. The expression ( _fun pat 1_ ... _patn_ : _return-type_ - > _rhs-expr_ ) is checked against a fresh initial
    type _ty 1_ and reduced to an elaborated form _expr_ 1. The return type is omitted if the definition
    does not specify it.
3. The _ident 1_ (of type _ty 1_ ) is then generalized (§14.6.7) and yields generic parameters < _typars 1_ >.
4. The following rules are checked:
    - Function definitions may not be mutable. Mutable function values should be written as
       follows:
       let mutable f = (fun args -> ...)
    - The patterns of functions may not include optional arguments (§8.13.6).
5. The resulting elaborated definition is:

```
ident 1 < typars 1 > = expr 1
```
#### 14.6.5 Processing Recursive Groups of Definitions

A group of functions and values may be declared recursive through the use of let rec. Groups of
members in a recursive set of type definitions are also implicitly recursive. In this case, the defined
values are available for use within their own definitions—that is, within all the expressions on the
right-hand side of the definitions.

For example:

```
let rec twoForward count =
printfn "at %d, taking two steps forward" count
if count = 1000 then "got there!"
else oneBack (count + 2)
and oneBack count =
printfn "at %d, taking one step back " count
twoForward (count – 1)
```
When one or more definitions specifies a value, the recursive expressions are analyzed for safety
(§14.6.6). This analysis may result in warnings—including some reported at compile time—and
runtime checks.

Within recursive groups, each definition in the group is checked (§14.6.7) and then the definitions
are generalized incrementally. In addition, any use of an ungeneralized recursive definition results in
immediate constraints on the recursively defined construct. For example, consider the following
declaration:

```
let rec countDown count x =
if count > 0 then
let a = countDown (count - 1) 1 // constrains "x" to be of type int
let b = countDown (count – 1) "Hello" // constrains "x" to be of type string
a + b
else
1
```
In this example, the definition is not valid because the recursive uses of f result in inconsistent
constraints on x.


If a definition has a full signature, early generalization applies and recursive calls at different types
are permitted (§14.6.7). For example:

```
module M =
let rec f<'T> (x:'T) : 'T =
let a = f 1
let b = f "Hello"
x
```
In this example, the definition is valid because f is subject to early generalization, and so the
recursive uses of f do not result in inconsistent constraints on x.

#### 14.6.6 Recursive Safety Analysis

A set of recursive definitions may include value definitions. For example:

```
type Reactor = React of (int -> React) * int
```
```
let rec zero = React((fun c -> zero), 0)
```
```
let const n =
let rec r = React((fun c -> r), n)
r
```
Recursive value definitions may result in invalid recursive cycles, such as the following:

```
let rec x = x + 1
```
The _Recursive Safety Analysis_ process partially checks the safety of these definitions and convert
thems to a form that uses lazy initialization, where runtime checks are inserted to check
initialization.

A right-hand side expression is _safe_ if it is any of the following:

- A function expression, including those whose bodies include references to variables that are
    defined recursively.
- An object expression that implements an interface, including interfaces whose member bodies
    include references to variables that are being defined recursively.
- A lazy delayed expression.
- A record, tuple, list, or data construction expression whose field initialization expressions are all
    safe.
- A value that is not being recursively bound.
- A value that is being recursively bound and appears in one of the following positions:
    - As a field initializer for a field of a record type where the field is marked mutable.
    - As a field initializer for an immutable field of a record type that is defined in the current
       assembly.
       If record fields contain recursive references to values being bound, the record fields must be
       initialized in the same order as their declared type, as described later in this section.


- Any expression that refers only to earlier variables defined by the sequence of recursive
    definitions.

Other right-hand side expressions are elaborated by adding a new definition. If the original definition
is

```
u = expr
```
then a fresh value (say v) is generated with the definition:

```
v = lazy expr
```
and occurrences of the original variable _u_ on the right-hand side are replaced by Lazy.force _v_. The
following definition is then added at the end of the definition list:

```
u = v .Force()
```
```
Note: This specification implies that recursive value definitions are executed as an
initialization graph of delayed computations. Some recursive references may be checked
at runtime because the computations that are involved in evaluating the definitions
might actually execute the delayed computations. The F# compiler gives a warning for
recursive value definitions that might involve a runtime check. If runtime self-reference
does occur then an exception will be raised.
```
```
Recursive value definitions that involve computation are useful when defining objects
such as forms, controls, and services that respond to various inputs. For example, GUI
elements that store and retrieve the state of the GUI elements as part of their
specification typically involve recursive value definitions. A simple example is the
following menu item, which prints out part of its state when invoked:
open System.Windows.Form
let rec menuItem : MenuItem =
new MenuItem("&Say Hello",
new EventHandler(fun sender e ->
printfn "Text = %s" menuItem.Text),
Shortcut.CtrlH)
```
```
This code results in a compiler warning because, in theory, the
new MenuItem(...) constructor might evaluate the callback as part of the construction
process. However, because the System.Windows.Forms library is well designed, in this
example this does not happen in practice, and so the warning can be suppressed or
ignored by using compiler options.
```
The F# compiler performs a simple approximate static analysis to determine whether immediate
cyclic dependencies are certain to occur during the evaluation of a set of recursive value definitions.
The compiler creates a graph of definite references and reports an error if such a dependency cycle
exists. All references within function expressions, object expressions, or delayed expressions are
assumed to be indefinite, which makes the analysis an under-approximation. As a result, this check
catches naive and direct immediate recursion dependencies, such as the following:

```
let rec A = B + 1
and B = A + 1
```

Here, a compile-time error is reported. This check is necessarily approximate because dependencies
under function expressions are assumed to be delayed, and in this case the use of a lazy initialization
means that runtime checks and forces are inserted.

```
Note: In F# 3 .1 this check does not apply to value definitions that are generic through
generalization because a generic value definition is not executed immediately, but is
instead represented as a generic method. For example, the following value definitions
are generic because each right-hand-side is generalizable:
let rec a = b
and b = a
```
```
In compiled code they are represented as a pair of generic methods, as if the code had
been written as follows:
let rec a<'T>() = b<'T>()
and b<'T>() = a<'T>()
```
```
As a result, the definitions are not executed immediately unless the functions are called.
Such definitions indicate a programmer error, because executing such generic,
immediately recursive definitions results in an infinite loop or an exception. In practice
these definitions only occur in pathological examples, because value definitions are
generalizable only when the right-hand-side is very simple, such as a single value. Where
this issue is a concern, type annotations can be added to existing value definitions to
ensure they are not generic. For example:
let rec a : int = b
and b : int = a
```
```
In this case, the definitions are not generic. The compiler performs immediate
dependency analysis and reports an error. In addition, record fields in recursive data
expressions must be initialized in the order they are declared. For example:
type Foo = {
x: int
y: int
parent: Foo option
children: Foo list
}
let rec parent = { x = 0; y = 0; parent = None; children = children }
and children = [{ x = 1; y = 1; parent = Some parent; children = [] }]
printf "%A" parent
```
```
Here, if the order of the fields x and y is swapped, a type-checking error occurs.
```
#### 14.6.7 Generalization

Generalization is the process of inferring a generic type for a definition where possible, thereby
making the construct reusable with multiple different types. Generalization is applied by default at
all function, value, and member definitions, except where listed later in this section. Generalization
also applies to member definitions that implement generic virtual methods in object expressions.

Generalization is applied incrementally to items in a recursive group after each item is checked.


Generalization takes a set of ungeneralized but type-checked definitions _checked-defns_ that form
part of a recursive group, plus a set of unchecked definitions _unchecked-defns_ that have not yet been
checked in the recursive group, and an environment _env_. Generalization involves the following steps:

1. Choose a subset _generalizable-defns_ of _checked-defns_ to generalize.

```
A definition can be generalized if its inferred type is closed with respect to any inference
variables that are present in the types of the unchecked-defns that are in the recursive group and
that are not yet checked or which, in turn, cannot be generalized. A greatest-fixed-point
computation repeatedly removes definitions from the set of checked-defns until a stable set of
generalizable definitions remains.
```
2. Generalize all type inference variables that are not otherwise ungeneralizable and for which any
    of the following is true:
    - The variable is present in the inferred types of one or more of _generalizable-defns_.
    - The variable is a type parameter copied from the enclosing type definition (for members and
       “let” definitions in classes).
    - The variable is explicitly declared as a generic parameter on an item.

The following type inference variables cannot be generalized:

- A type inference variable _^typar_ that is part of the inferred or declared type of a definition,
    unless the definition is marked inline.
- A type inference variable in an inferred type in the _ExprItems_ or _PatItems_ tables of _env_ , or in
    an inferred type of a module in the _ModulesAndNamespaces_ table in _env_.
- A type inference variable that is part of the inferred or declared type of a definition in which
    the elaborated right-hand side of the definition is not a generalizable expression, as
    described later in this section.
- A type inference variable that appears in a constraint that itself refers to an ungeneralizable
    type variable.

Generalizable type variables are computed by a greatest-fixed-point computation, as follows:

1. Start with all variables that are candidates for generalization.

2. Determine a set of variables _U_ that cannot be generalized because they are free in the
environment or present in ungeneralizable definitions.

3. Remove the variables in _U_ from consideration.

4. Add to _U_ any inference variables that have a constraint that involves a variable in _U_.

5. Repeat steps 2 through 4.


Informally, generalizable expressions represent a subset of expressions that can be freely copied and
instantiated at multiple types without affecting the typical semantics of an F# program. The
following expressions are generalizable:

- A function expression
- An object expression that implements an interface
- A delegate expression
- A “let” definition expression in which both the right-hand side of the definition and the body of
    the expression are generalizable
- A “let rec” definition expression in which the right-hand sides of all the definitions and the body
    of the expression are generalizable
- A tuple expression, all of whose elements are generalizable
- A record expression, all of whose elements are generalizable, where the record contains no
    mutable fields
- A union case expression, all of whose arguments are generalizable
- An exception expression, all of whose arguments are generalizable
- An empty array expression
- A simple constant expression
- An application of a type function that has the GeneralizableValue attribute.

Explicit type parameter definitions on value and member definitions can affect the process of type
inference and generalization. In particular, a declaration that includes explicit generic parameters
will not be generalized beyond those generic parameters. For example, consider this function:

```
let f<'T> (x : 'T) y = x
```
During type inference, this will result in a function of the following type, where '_b is a type
inference variable that is yet to be resolved.

```
f<'T> : 'T -> '_b -> '_b
```
To permit generalization at these definitions, either remove the explicit generic parameters (if they
can be inferred), or use the required number of parameters, as the following example shows:

```
let throw<'T,'U> (x:'T) (y:'U) = x
```
#### 14.6.8 Condensation of Generalized Types

After a function or member definition is generalized, its type is condensed by removing generic type
parameters that apply subtype constraints to argument positions. (The removed flexibility is
implicitly reintroduced at each use of the defined function; see §14.4.3).

Condensation decomposes the type of a value or member to the following form:

```
ty 11 * ... * ty 1n - > ... -> ty m1 * ... * ty mn -> rty
```
The positions _ty_ ij are called the parameter positions for the type.


Condensation applies to a type parameter 'a if all of the following are true:

- 'a is not an explicit type parameter.
- 'a occurs at exactly one _ty_ ij parameter position.
- 'a has a single coercion constraint 'a :> _ty_ and no other constraints. However, one additional
    nullness constraint is permitted if _ty_ satisfies the nullness constraint.
- 'a does not occur in any other _ty_ ij, nor in _rty_.
- 'a does not occur in the constraints of any condensed typar.

Condensation is a greatest-fixed-point computation that initially assumes all generalized type
parameters are condensed, and then progressively removes type parameters until a minimal set
remains that satisfies the above rules.

The compiler removes all condensed type parameters and replaces them with their subtype
constraint _ty_. For example:

```
let F x = (x :> System.IComparable).CompareTo(x)
```
After generalization, the function is inferred to have the following type:

```
F : 'a -> int when 'a :> System.IComparable
```
In this case, the actual inferred, generalized type for F is condensed to:

```
F : System.IComparable -> R
```
Condensation does not apply to arguments of unconstrained variable type. For example:

```
let ignore x = ()
```
with type

```
ignore: 'a -> unit
```
In particular, this is not condensed to

```
ignore: obj -> unit
```
In rare cases, condensation affects the points at which value types are boxed. In the following
example, the value 3 is now boxed at uses of the function:

```
F 3
```
If a function is not generalized, condensation is not applied. For example, consider the following:

```
let test1 =
let ff = Seq.map id >> Seq.length
(ff [1], ff [| 1 |]) // error here
```
In this example, ff is not generalized, because it is not defined by using a generalizable expression—
computed functions such as Seq.map id >> Seq.length are not generalizable. This means that its
inferred type, after processing the definition, is


```
F : '_a -> int when '_a :> seq<'_b>
```
where the type variables are not generalized and are unsolved inference variables. The application
of ff to [1] equates 'a with int list, making the following the type of F:

```
F : int list -> int
```
The application of ff to an array type then causes an error. This is similar to the error returned by
the following:

```
let test1 =
let ff = Seq.map id >> Seq.length
(ff [1], ff ["one"]) // error here
```
Again, ff is not generalized, and its use with arguments of type int list and string list is not
permitted.

### 14.7 DISPATCH SLOT INFERENCE

The F# compiler applies _Dispatch Slot Inference_ to object expressions and type definitions before it
processes their members. For both object expressions and type definitions, the following are input
to Dispatch Slot Inference:

- A type _ty 0_ that is being implemented.
- A set of members override x.M(arg _1_ ...arg _N_ ).
- A set of additional interface types _ty 1_ ... _tyn._
- A further set of members override x.M( _arg 1_ ... _argN_ ) for each _tyi_.

Dispatch slot inference associates each member with a unique abstract member or interface
member that the collected types _tyi_ define or inherit.

The types _ty 0_ ... _tyn_ together imply a collection of _required types_ R, each of which has a set of
_required dispatch slots_ SlotsR of the form abstract M : _aty 1_ ... _atyN_ - > _atyrty_. Each dispatch slot is
placed under the _most-specific tyi_ relevant to that dispatch slot. If there is no most-specific type for
a dispatch slot, an error occurs.

For example, assume the following definitions:

```
type IA = interface abstract P : int end
type IB = interface inherit IA end
type ID = interface inherit IB end
```
With these definitions, the following object expression is legal. Type IB is the most-specific
implemented type that encompasses IA, and therefore the implementation mapping for P must be
listed under IB:

```
let x = { new ID
interface IB with
member x.P = 2 }
```
But given:


```
type IA = interface abstract P : int end
type IB = interface inherit IA end
type IC = interface inherit IB end
type ID = interface inherit IB inherit IC end
```
then the following object expression causes an error, because both IB and IC include the interface
IA, and consequently the implementation mapping for P is ambiguous.

```
let x = { new ID
interface IB with
member x.P = 2
interface IC with
member x.P = 2 }
```
The ambiguity can be resolved by explicitly implementing interface IA.

After dispatch slots are assigned to types, the compiler tries to associate each member with a
dispatch slot based on name and number of arguments. This is called _dispatch slot inference,_ and it
proceeds as follows:

- For each member x.M( _arg 1_ ... _argN_ ) in type _tyi_ , attempt to find a single dispatch slot in the form

```
abstract M : aty 1 ... atyN - > rty
```
```
with name M, argument count N, and most-specific implementing type tyi.
```
- To determine the argument counts, analyze the syntax of patterns and look specifically for
    tuple and unit patterns. Thus, the following members have argument count 1, even though
    the argument type is unit:
    member obj.ToString(() | ()) = ...
    member obj.ToString(():unit) = ...
    member obj.ToString(_:unit) = ...
- A member may have a return type, which is ignored when determining argument counts:
    member obj.ToString() : string = ...

For example, given

```
let obj1 =
{ new System.Collections.Generic.IComparer<int> with
member x.Compare(a,b) = compare (a % 7) (b % 7) }
```
the types of a and b are inferred by looking at the signature of the implemented dispatch slot, and
are hence both inferred to be int.

### 14.8 DISPATCH SLOT CHECKING

_Dispatch Slot Checking_ is applied to object expressions and type definitions to check consistency
properties, such as ensuring that all abstract members are implemented.

After the compiler checks all bodies of all methods, it checks that a one-to-one mapping exists
between dispatch slots and implementing members based on exact signature matching.


The interface methods and abstract method slots of a type are collectively known as _dispatch slots_.
Each object expression and type definition results in an elaborated _dispatch map_. This map is keyed
by dispatch slots, which are qualified by the declaring type of the slot. This means that a type that
supports two interfaces I and I2, both of which contain the method m, may supply different
implementations for I.m() and I2.m().

The construction of the dispatch map for any particular type is as follows:

- If the type definition or extension has an implementation of an interface, mappings are added
    for each member of the interface,
- If the type definition or extension has a default or override member, a mapping is added for the
    associated abstract member slot.

### 14.9 BYREF SAFETY ANALYSIS

Byref arguments are pointers that can be stack-bound and are used to pass values by reference to
procedures in CLI languages, often to simulate multiple return values. Byref pointers are not often
used in F#; more typically, tuple values are used for multiple return values. However, a byref value
can result from calling or overriding a CLI method that has a signature that involves one or more
byref values.

To ensure the safety of byref arguments, the following checks are made:

- Byref types may not be used as generic arguments.
- Byref values may not be used in any of the following:
    - The argument types or body of function expressions (fun ... -> ...).
    - The member implementations of object expressions.
    - The signature or body of let-bound functions in classes.
    - The signature or body of let-bound functions in expressions.

Note that function expressions occur in:

- The elaborated form of sequence expressions.
- The elaborated form of computation expressions.
- The elaborated form of partial applications of module-bound functions and members.

In addition:

- A generic type cannot be instantiated by a byref type.
- An object field cannot have a byref type.
- A static field or module-bound value cannot have a byref type.

As a result, a byref-typed expression can occur only in these situations:

- As an argument to a call to a module-defined function or class-defined function.


- On the right-hand-side of a value definition for a byref-typed local.

These restrictions also apply to uses of the prefix && operator for generating native pointer values.

### 14.10 Promotion of Escaping Mutable Locals to Objects

Value definitions whose byref address would be subject to the restrictions on byref<_> listed in
§14.9 are treated as implicit declarations of reference cells. For example

```
let sumSquares n =
let mutable total = 0
[ 1 .. n ] |> Seq.iter (fun x -> total <- total + x*x)
total
```
is considered equivalent to the following definition:

```
let sumSquares n =
let total = ref 0
[ 1 .. n ] |> Seq.iter
(fun x -> total.contents <- total.contents + x*x)
total.contents
```
because the following would be subject to byref safety analysis:

```
let sumSquares n =
let mutable total = 0
&total
```
### 14.10 ARITY INFERENCE

During checking, members within types and function definitions within modules are inferred to have
an _arity_. An arity includes both of the following:

- The number of iterated (curried) arguments n
- A tuple length for these arguments [ _A 1_ ;...; _An_ ]. A tuple length of zero indicates that the
    corresponding argument is of type unit.

Arities are inferred as follows. A function definition of the following form is given arity [ _A 1_ ;...; _An_ ],
where each _Ai_ is derived from the tuple length for the final inferred types of the patterns:

```
let ident pat 1 ... patn = ...
```
For example, the following is given arity [1; 2]:

```
let f x (y,z) = x + y + z
```
Arities are also inferred from function expressions that appear on the immediate right of a value
definition. For example, the following has an arity of [1]:

```
let f = fun x -> x + 1
```
Similarly, the following has an arity of [1;1]:


```
let f x = fun y -> x + y
```
Arity inference is applied partly to help define the elaborated form of a function definition. This is
the form that other CLI languages see. In particular:

- A function value F in a module that has arity [A 1 ;...;An] and the type
    _ty1,1_ * ... * _ty1,A1_ - > ... -> _tyn,1_ * ... * _tyn,An_ - > _rty_
    elaborates to a CLI static method definition with signature
    _rty_ F( _ty1,1_ , ..., _ty1,A1_ , ..., _tyn,1_ , ..., _tyn,An_ ).
- F# instance (respectively static) methods that have arity [A 1 ;...;An] and type
    _ty1,1_ * ... * _ty1,A1_ - > ... -> _tyn,1_ * ... * _tyn,An_ - > _rty_
    elaborate to a CLI instance (respectively static) method definition with signature
    _rty_ F( _ty1,1_ , ..., _ty1,A1_ ), subject to the syntactic restrictions that result from the patterns that
    define the member, as described later in this section.

For example, consider a function in a module with the following definition:

```
let AddThemUp x (y, z) = x + y + z
```
This function compiles to a CLI static method with the following C# signature:

```
int AddThemUp(int x, int y, int z);
```
Arity inference applies differently to function and member definitions. Arity inference on function
definitions is fully type-directed. Arity inference on members is limited if parentheses or other
patterns are used to specify the member arguments. For example:

```
module Foo =
// compiles as a static method taking 3 arguments
let test1 (a1: int, a2: float, a3: string) = ()
```
```
// compiles as a static method taking 3 arguments
let test2 (aTuple : int * float * string) = ()
```
```
// compiles as a static method taking 3 arguments
let test3 ( (aTuple : int * float * string) ) = ()
```
```
// compiles as a static method taking 3 arguments
let test4 ( (a1: int, a2: float, a3: string) ) = ()
```
```
// compiles as a static method taking 3 arguments
let test5 (a1, a2, a3 : int * float * string) = ()
```
```
type Bar() =
// compiles as a static method taking 3 arguments
static member Test1 (a1: int, a2: float, a3: string) = ()
```
```
// compiles as a static method taking 1 tupled argument
static member Test2 (aTuple : int * float * string) = ()
```
```
// compiles as a static method taking 1 tupled argument
static member Test3 ( (aTuple : int * float * string) ) = ()
```
```
// compiles as a static method taking 1 tupled argument
static member Test4 ( (a1: int, a2: float, a3: string) ) = ()
```

```
// compiles as a static method taking 1 tupled argument
static member Test5 (a1, a2, a3 : int * float * string) = ()
```
### 14.11 ADDITIONAL CONSTRAINTS ON CLI METHODS

F# treats some CLI methods and types specially, because they are common in F# programming and
cause extremely difficult-to-find bugs. For each use of the following constructs, the F# compiler
imposes additional _ad hoc_ constraints:

```
x.Equals(yobj) requires type ty : equality for the static type of x
```
```
x.GetHashCode() requires type ty : equality for the static type of x
```
```
new Dictionary<A,B>() requires A : equality, for any overload that does not take an
IEqualityComparer<T>
```
No constraints are added for the following operations. Consider writing wrappers around these
functions to improve the type safety of the operations.

```
System.Array.BinarySearch<T>(array,value) requiring C : comparison, for any overload that
does not take an IComparer<T>
```
```
System.Array.IndexOf requiring C : equality
```
```
System.Array.LastIndexOf(array,T) requiring C : equality
```
```
System.Array.Sort<'T>(array) requiring C : comparison, for any overload that does not take an
IEqualityComparer<T>
```
```
new SortedList<A,B>() requiring A : comparison, for any overload that does not take an
IEqualityComparer<T>
```
```
new SortedDictionary<A,B>() requiring C : comparison, for any overload that does not take an
IEqualityComparer<_>
```

## 15. LEXICAL FILTERING

### 15.1 LIGHTWEIGHT SYNTAX

F# supports lightweight syntax, in which whitespace makes indentation significant.

The lightweight syntax option is a conservative extension of the explicit language syntax, in the sense
that it simply lets you leave out certain tokens such as in and ;; because the parser takes
indentation into account. Indentation can make a surprising difference in the readability of code.
Compiling your code with the indentation-aware syntax option is useful even if you continue to use
explicit tokens, because the compiler reports many indentation problems with your code and
ensures a regular, clear formatting style.

In the processing of lightweight syntax, comments are considered pure whitespace. This means that
the compiler ignores the indentation position of comments. Comments act as if they were replaced
by whitespace characters. Tab characters cannot be used in F# files.

#### 15.1.1 Basic Lightweight Syntax Rules by Example

The basic rules that the F# compiler applies when it processes lightweight syntax are shown below,
illustrated by example.

**;; delimiter**
When the lightweight syntax option is enabled, top level expressions do not require the ;; delimiter
because every construct that starts in the first column is implicitly a new declaration. The ;;
delimiter is still required to terminate interactive entries to fsi.exe, but not when using F# Interactive
from Visual Studio.
Lightweight Syntax
printf "Hello"
printf "World"

Normal Syntax
printf "Hello";;
printf "World";;
**in keyword**
When the lightweight syntax option is enabled, the in keyword is optional. The token after the "=" in
a 'let' definition begins a new block, and the pre-parser inserts an implicit separating in token
between each definition that begins at the same column as that token.
Lightweight Syntax
let SimpleSample() =
let x = 10 + 12 - 3
let y = x * 2 + 1
let r1,r2 = x/3, x%3
(x,y,r1,r2)

Normal Syntax
#indent "off"
let SimpleSample() =
let x = 10 + 12 - 3 in
let y = x * 2 + 1 in
let r1,r2 = x/3, x%3 in
(x,y,r1,r2)
done **keyword**
When the lightweight syntax option is enabled, the done keyword is optional. Indentation establishes
the scope of structured constructs such as match, for, while and if/then/else.
Lightweight Syntax
let FunctionSample() =
let tick x = printfn "tick %d" x
let tock x = printfn "tock %d" x
let choose f g h x =
if f x then g x else h x
for i = 0 to 10 do
choose (fun n -> n%2 = 0) tick tock i

```
Normal Syntax
#indent "off"
let FunctionSample() =
let tick x = printfn "tick %d" x in
let tock x = printfn "tock %d" x in
let choose f g h x =
if f x then g x else h x in
for i = 0 to 10 do
```

printfn "done!" choose (fun n -> n%2 = 0) tick tock i
done;
printfn "done!"
if **/** then **/** else Scope
When the lightweight syntax option is enabled, the scope of if/then/else is implicit from
indentation. Without the lightweight syntax option, begin/end or parentheses are often required to
delimit such constructs.
Lightweight Syntax
let ArraySample() =
let numLetters = 26
let results = Array.create numLetters 0
let data = "The quick brown fox"
for i = 0 to data.Length - 1 do
let c = data.Chars(i)
let c = Char.ToUpper(c)
if c >= 'A' && c <= 'Z' then
let i = Char.code c - Char.code 'A'
results.[i] <- results.[i] + 1
printfn "done!"

```
Normal Syntax
#indent "off"
let ArraySample() =
let numLetters = 26 in
let results = Array.create numLetters 0 in
let data = "The quick brown fox" in
for i = 0 to data.Length - 1 do
let c = data.Chars(i) in
let c = Char.ToUpper(c) in
if c >= 'A' && c <= 'Z' then begin
let i = Char.code c - Char.code 'A' in
results.[i] <- results.[i] + 1
end
done;
printfn "done!"
```
#### 15.1.2 Inserted Tokens

Lexical filtering inserts the following hidden tokens :

```
token $in // Note: also called ODECLEND
token $done // Note: also called ODECLEND
token $begin // Note: also called OBLOCKBEGIN
token $end // Note: also called OEND, OBLOCKEND and ORIGHT_BLOCK_END
token $sep // Note: also called OBLOCKSEP
token $app // Note: also called HIGH_PRECEDENCE_APP
token $tyapp // Note: also called HIGH_PRECEDENCE_TYAPP
```
```
Note: The following tokens are also used in the Microsoft F# implementation. They are
translations of the corresponding input tokens and help provide better error messages
for lightweight syntax code:
tokens $let $use $let! $use! $do $do! $then $else $with $function $fun
```
#### 15.1.3 Grammar Rules Including Inserted Tokens

Additional grammar rules take into account the token transformations performed by lexical filtering:

```
expr +:=
| let function-defn $ in expr
| let value-defn $ in expr
| let rec function-or-value-defns $ in expr
| while expr do expr $done
| if expr then $begin expr $end
| for pat in expr do expr $done
| for expr to expr do expr $done
| try expr $end with expr $done
| try expr $end finally expr $done
| expr $app expr // equivalent to " expr ( expr )"
| expr $sep expr // equivalent to " expr ; expr "
| expr $tyapp < types > // equivalent to " expr < types >"
| $begin expr $end // equivalent to “ expr ”
elif-branch +:=
| elif expr then $begin expr $end
```

```
else-branch +:=
| else $begin expr $end
class-or-struct-type-body +:=
| $begin class-or-struct-type-body $end
// equivalent to class-or-struct-type-body
module-elems +:=
| $begin module-elem ... module-elem $end
module-abbrev +:=
| module ident = $begin long-ident $end
module-defn +:=
| module ident = $begin module-defn-body $end
module-signature-elements +:=
| $begin module-signature-element ... module-signature-element $end
module-signature +:=
| module ident = $begin module-signature-body $end
```
#### 15.1.4 Offside Lines

Lightweight syntax is sometimes called the “offside rule”. In F# code, offside lines occur at column
positions. For example, an = token associated with let introduces an offside line at the column of
the first non-whitespace token after the = token.

Other structured constructs also introduce offside lines at the following places:

- The column of the first token after then in an if/then/else construct.
- The column of the first token after try, else, ->, with (in a match/with or try/with), or with (in a
    type extension).
- The column of the first token of a (, { or begin token.
- The start of a let, if or module token.

Here are some examples of how the offside rule applies to F# code. In the first example, let and
type declarations are not properly aligned, which causes F# to generate a warning.

```
// "let" and "type" declarations in
// modules must be precisely aligned.
let x = 1
let y = 2 <-- unmatched 'let'
let z = 3 <-- warning FS0058: possible
incorrect indentation: this token is offside of
context at position (2:1)
```
In the second example, the | markers in the match patterns do not align properly:

```
// The "|" markers in patterns must align.
// The first "|" should always be inserted.
let f () =
match 1+1 with
| 2 -> printf "ok"
| _ -> failwith "no!" <-- syntax error
```

#### 15.1.5 The Pre-Parse Stack...................................................................................................

F# implements the lightweight syntax option by preparsing the token stream that results from a
lexical analysis of the input text according to the lexical rules in §15.1.3. Pre-parsing for lightweight
syntax uses a stack of _contexts_.

- When a column position becomes an offside line, a context is pushed.
- The closing bracketing tokens ), }, and end terminate offside contexts up to and including the
    context that the corresponding opening token introduced.

#### 15.1.6 Full List of Offside Contexts

This section describes the full list of offside contexts that is kept on the pre-parse stack.

The _SeqBlock_ context is the primary context of the analysis.It indicates a sequence of items that
must be column-aligned. Where necessary for parsing, the compiler automatically inserts a delimiter
that replaces the regular in and ; tokens between the syntax elements. The _SeqBlock_ context is
pushed at the following times:

- Immediately after the start of a file, excluding lexical directives such as #if.
- Immediately after an = token is encountered in a _Let_ or _Member_ context.
- Immediately after a _Paren_ , _Then_ , _Else_ , _WithAugment, Try_ , _Finally_ , _Do_ context is pushed.
- Immediately after an infix token is encountered.
- Immediately after a -> token is encountered in a _MatchClauses_ context.
- Immediately after an interface, class, or struct token is encountered in a type declaration.
- Immediately after an = token is encountered in a record expression when the subsequent token
    either (a) occurs on the next line or (b) is one of _try_ , _match_ , _if_ , _let_ , _for_ , _while_ or _use_.
- Immediately after a <- token is encoutered when the subsequent token either (a) does not occur
    on the same line or (b) is one of _try_ , _match_ , _if_ , _let_ , _for_ , _while_ or _use_.

Here “immediately after” refers to the fact that the column position associated with the _SeqBlock_ is
the first token following the significant token.

In the last two rules, a new line is significant. For example, the following do not start a SeqBlock on
the right-hand side of the “<-“ token, so it does not parse correctly:

```
let mutable x = 1
// The subsequent token occurs on the same line.
X <- printfn "hello"
2 + 2
```
To start a SeqBlock on the right, either parentheses or a new line should be used:

```
// The subsequent token does not occur on the same line, so a SeqBlock is pushed.
X <-
printfn "hello"
2 + 2
```

The following contexts are associated with nested constructs that are introduced by the specified
keywords:

Context (^) **Pushed when the token stream contains...**
Let The let keyword
If The if or elif keyword
Try The try keyword
Lazy The lazy keyword
Fun The fun keyword
Function The function keyword
WithLet The with keyword as part of a record expression or an object expression whose
members use the syntax{ new Foo with M() = 1 and N() = 2 }
WithAugment The with keyword as part of an extension, interface, or object expression whose
members use the syntax { new Foo member x.M() = 1 member x. N() = 2 }
Match the match keyword
For the for keyword
While The while keyword
Then The then keyword
Else The else keyword
Do The do keyword
Type The type keyword
Namespace The namespace keyword
Module The module keyword
Member (^) ▪ The member, abstract, default, or override keyword, if the Member context is
not already active, because multiple tokens may be present.
—or—
▪ ( is the next token after the new keyword. This distinguishes the member
declaration new(x) = ... from the expression new x()
Paren(token) (, begin, struct, sig, {, [, [|, or _quote-op-left_
MatchClauses The with keyword in a Try or Match context immediately after a function keyword.
Vanilla An otherwise unprocessed keyword in a SeqBlock context.

#### 15.1.7 Balancing Rules

When the compiler processes certain tokens, it pops contexts off the offside stack until the stack
reaches a particular condition. When it pops a context, the compiler may insert extra tokens to
indicate the end of the construct. This procedure is called balancing the stack.

The following table lists the contexts that the compiler pops and the balancing condition for each:

**Token Contexts Popped and Balancing Conditions:**


**Token Contexts Popped and Balancing Conditions:**

End (^) Enclosing context is one of the following:
▪ WithAugment
▪ Paren(interface)
▪ Paren(class)
▪ Paren(sig)
▪ Paren(struct)
▪ Paren(begin)
;; (^) Pop all contexts from stack
else If
elif If
done Do
in For or Let
eith Match, Member, Interface, Try, Type
finally Try
) Paren(()
} Paren({)
] Paren([)
|] Paren([|)
quote-op-right Paren(quote-op-left)

#### 15.1.8 Offside Tokens, Token Insertions, and Closing Contexts

The _offside limit_ for the current offside stack is the rightmost offside line for the offside contexts on
the context stack. The following figure shows the offside limits:

```
let FunctionSample() =
let tick x = printfn "tick %d" x
let tock x = printfn "tock %d" x
let choose f g h x =
if f x then g x else h x
for i = 0 to 10 do
choose (fun n - > n% 2 = 0 ) tick tock i
printfn "done!"
```
```
Offside limit for inner let and for contexts
Offside limit for outer let context
```
When a token occurs on or before the _offside limit_ for the current offside stack, and a _permitted
undentation_ does not apply, enclosing contexts are _closed_ until the token is no longer offside. This
may result in the insertion of extra delimiting tokens.

Contexts are closed as follows:

- When a _Fun_ context is closed, the $end token is inserted.
- When a _SeqBlock_ , _MatchClauses_ , _Let_ , or _Do_ context is closed, the $end token is inserted, with the
    exception of the first _SeqBlock_ pushed for the start of the file.
- When a _While_ or _For_ context is closed, and the offside token that forced the close is not done,
    the $done token is inserted.
- When a _Member_ context is closed, the $end token is inserted.


- When a _WithAugment_ context is closed, the $end token is inserted.

If a token is offside and a context cannot be closed, then an “undentation” warning or error is issued
to indicate that the construct is badly formatted.

Tokens are also inserted in the following situations:

- When a _SeqBlock_ context is pushed, the $begin token is inserted, with the exception of the first
    _SeqBlock_ pushed for the start of the file.
- When a token other than and appears directly on the offside line of _Let_ context, and the next
    surrounding context is a _SeqBlock_ , the $in token is inserted.
- When a token occurs directly on the offside line of a _SeqBlock_ on the second or subsequent lines
    of the block, the $sep token is inserted. This token plays the same role as ; in the grammar rules.
    For example, consider this source text:
       let x = 1
       x

```
The raw token stream contains let, x, =, 1 , x and the end-of-file marker eof. An initial SeqBlock is
pushed immediately after the start of the file, at the first token in the file, with an offside line on
column 0. The let token pushes a Let context. The = token in a Let context pushes a SeqBlock
context and inserts a $begin token. The 1 pushes a Vanilla context. The final token, x, is offside
from the Vanilla context, which pops that context. It is also offside from the SeqBlock context,
which pops the context and inserts $end. It is also offside from the Let context, which inserts
another $end token. It is directly aligned with the SeqBlock context, so a $seq token is inserted.
```
#### 15.1.9 Exceptions to the Offside Rules

The compiler makes some exceptions to the offside rules when it analyzes a token to determine
whether it is offside from the current context. The following table summarizes the exceptions and
shows examples of each.

**Context Exception Example**
_SeqBlock_ An infix token may be offside by the
size of the token plus one.

let x =
expr + expr
+ expr + expr
let x =
expr
|> f expr
|> f expr
_SeqBlock_ An infix token may align precisely
with the offside line of the _SeqBlock_.

```
let someFunction(someCollection) =
someCollection
|> List.map (fun x -> x + 1)
```

**Context Exception Example**
_SeqBlock_ The infix |> token that begins the last
line is not considered as a new
element in the sequence block on the
right-hand side of the definition. The
same also applies to end, and, with,
then, and right-parenthesis
operators.
In the example, the first ) token does
not indicate a new element in a
sequence of items, even though it
aligns precisely with the sequence
block that starts at the beginning of
the argument list.

```
new MenuItem("&Open...",
new EventHandler(fun _ _ ->
...
))
```
Let (^) The and token may align precisely
with the let keyword.
let rec x = 1
and y = 2
x + y
Type (^) The }, end, and, and | tokens may
align precisely with the type
keyword.
type X =
| A
| B
with
member x.Seven = 21 / 3
end
and Y = {
x : int
}
and Z() = class
member x.Eight = 4 + 4
end
For (^) The done token may align precisely
with the for keyword.
for i = 1 to 3 do
expr
done
SeqBlock;
Match
On the right-hand side of an arrow for
a match expression, a token may align
precisely with the match keyword.
This exception allows the last
expression to align with the match, so
that a long series of matches does not
increase indentation.
match x with
| Some(_) -> 1
| None ->
match y with
| Some(_) -> 2
| None ->
3
Interface (^) The end token may align precisely
with the interface keyword.
interface IDisposable with
member x.Dispose() = printfn disposing!"
end
If (^) The then, elif, and else tokens may
align precisely with the if keyword.
if big
then callSomeFunction()
elif small
then callSomeOtherFunction()
else doSomeCleanup()
Try (^) The finally and with tokens may
align precisely with the try keyword.
Example 1:
try
callSomeFunction()
finally
doSomeCleanup()
Example 2:
try
callSomeFunction()
with Failure(s) ->
doSomeCleanup()
Do (^) The done token may align precisely
with the do keyword.
for i = 1 to 3
do
expr
done


#### 15.1.10 Permitted Undentations............................................................................................

As a general rule, incremental indentation requires that nested expressions occur at increasing
column positions in indentation-aware code. Warnings or syntax errors are issued when this is not
the case. However, undentation is permitted for the following constructs:

- Bodies of function expressions
- Branches of if/then/else expressions
- Bodies of modules and module types

**15.1.10.1 Undentation of Bodies of Function Expressions**
The bodies of functions may be undented from the fun or function symbol. As a result, the compiler
ignores the symbol when determining whether the body of the function satisfies the incremental
indentation rule. For example, the printf expression in the following example is undented from the
fun symbol that delimits the function definition:

```
let HashSample(tab: Collections.HashTable<_,_>) =
tab.Iterate (fun c v ->
printfn "Entry (%O,%O)" c v)
```
However, the block must not undent past other offside lines. Thefollowing is not permitted because
the second line breaks the offside line established by the = in the first line:

```
let x = (function (s, n) ->
(fun z ->
s+n+z))
```
Constructs enclosed in brackets may be undented.

**15.1.10.2 Undentation of Branches of If/Then/Else Expressions**
The body of a ( ... ) or begin ... end block in an if/then/else expression may be undented when the
body of the block follows the then or else keyword but may not undent further than the if
keyword. In this example, the parenthesized block follows then, so the body can be undented to the
offside line established by if:

```
let IfSample(day: System.DayOfWeek) =
if day = System.DayOfWeek.Monday then (
printf "I don't like Mondays"
)
```
**15.1.10.3 Undentation of Bodies of Modules and Module Types**
The bodies of modules and module types that are delimited by begin and end may be undented. For
example, in the following example the two let statements that comprise the module body are
undented from the =.

```
module MyNestedModule = begin
let one = 1
let two = 2
end
```
Similarly, the bodies of classes, interfaces, and structs delimited by { ... }, class ... end, struct ... end,
or interface ... end may be undented to the offside line established by the type keyword. For
example:


```
type MyNestedModule = interface
abstract P : int
end
```
### 15.2 HIGH PRECEDENCE APPLICATION

The entry f x in the precedence table in §4.4.2 refers to a function application in which the function
and argument are separated by spaces. The entry "f(x)" indicates that in expressions and patterns,
identifiers that are followed immediately by a left parenthesis without intervening whitespace form
a “high precedence” application. Such expressions are parsed with higher precedence than prefix
and dot-notation operators. Conceptually this means that

```
Example 1: B(e)
```
is analyzed lexically as

```
Example 1: B $app (e)
```
where $app is an internal symbol inserted by lexical analysis. We do not show this symbol in the
remainder of this specification and simply show the original source text.

This means that the following two statements

```
Example 1: B(e).C
Example 2: B (e).C
```
are parsed as

```
Example 1: (B(e)).C
Example 2: B ((e).C)
```
respectively.

Furthermore, arbitrary chains of method applications, property lookups, indexer lookups (.[]), field
lookups, and function applications can be used in sequence if the arguments of method applications
are parenthesized and immediately follow the method name, with no intervening spaces. For
example:

```
e.Meth1(arg1,arg2).Prop1.[3].Prop2.Meth2()
```
Although the grammar and these precedence rules technically allow the use of high-precedence
application expressions as direct arguments, an additional check prevents such use. Instead, such
expressions must be surrounded by parentheses. For example,

```
f e.Meth1(arg1,arg2) e.Meth2(arg1,arg2)
```
must be written

```
f (e.Meth1(arg1,arg2)) (e.Meth2(arg1,arg2))
```
However, indexer, field, and property dot-notation lookups may be used as arguments without
adding parentheses. For example:


```
f e.Prop1 e.Prop2.[3]
```
### 15.3 LEXICAL ANALYSIS OF TYPE APPLICATIONS

The entry f< _types_ > x in the precedence table (§4.4.2) refers to any identifier that is followed
immediately by a < symbol and a sequence of all of the following:

- _, ,, *, ', [, ], whitespace, or identifier tokens.
- A parentheses ( or < token followed by any tokens until a matching parentheses ) or > is
    encountered.
- A final > token.

During this analysis, any token that is composed only of the > character (such as >, >>, or >>>) is
treated as a series of individual > tokens. Likewise, any token composed only of > characters
followed by a period (such as >., >>., or >>>.) is treated as a series of individual > tokens followed by
a period.

If such a sequence of tokens follows an identifier, lexical analysis marks the construct as a _high
precedence type application_ and subsequent grammar rules ensure that the enclosed text is parsed
as a type. Conceptually this means that

```
Example 1: B<int>.C<int>(e).C
```
is returned as the following stream of tokens:

```
Example 1: B $app <int> .C $app <int>(e).C
```
where $app is an internal symbol inserted by lexical analysis. We do not show this symbol elsewhere
in this specification and simply show the original source text.

The lexical analysis of type applications does not apply to the character sequence “<>”. A character
sequence such as “< >” with intervening whitespace should be used to indicate an empty list of
generic arguments.

```
type Foo() =
member this.Value = 1
let b = new Foo< >() // valid
let c = new Foo<>() // invalid
```


## 16. PROVIDED TYPES

Type providers are extensions provided to an F# compiler or interpreter which provide information
about types available in the environment for the F# code being analysed.

The compilation context is augmented with a set of _type provider instances_. A type provider insance
is interrogated for information through _type provider invocations_ (TPI). Type provider invocations
are all executed at compile-time. The type provider instance is not required at runtime.

```
Wherever an operation on a provided namespace, provided type definition or provided
member is mentioned in this section, it is assumed to be a compile-time type provider
invocation.
```
```
The exact protocol used to implement type provider invocations and communicate
between an F# compiler/interpreter and type provider instances is implementation
dependent.
```
```
As of this release of F#,
```
- a type provider is a .NET 4.x binary component referenced as an imported asssembly
    reference. The assembly should have a TypeProviderAssemblyAttribute, with at
    least one component marked with TypeProviderAttribute.
- a type provider instance is an object created for a component marked with
    TypeProviderAttribute.
- provided type definitions are System.Type objects returned by a type provider
    instance.
- provided methods are System.Reflection.MethodInfo objects returned by a type
    provider instance.
- provided constructors are System.Reflection.ConstructorInfo objects returned by
    a type provider instance.
- provided properties are System.Reflection.PropertyInfo objects returned by a type
    provider instance.
- provided events are System.Reflection.EventInfo objects returned by a type
    provider instance.
- provided literal fields are System.Reflection.FieldInfo objects returned by a type
    provider instance.
- provided parameters are System.Reflection.ParameterInfo objects returned by a
    type provider instance.
- provided static parameters are System.Reflection.ParameterInfo objects returned
    by a type provider instance.
- provided attributes are attribute value objects returned by a type provider instance.


### 16.1 STATIC PARAMETERS

The syntax of types in F# is expanded to include static parameters, including named static
parameters:

```
type-arg =
static-parameter
static-parameter =
static-parameter-value
id = static-parameter-value
static-parameter-value =
const expr
simple-constant-expression
```
References to provided types may include static parameters, e.g.

```
type SomeService = ODataService<"http://some.url.org/service">
```
Static parameters which are constant expressions, but not simple literal constants, may be specified
using the const keyword, e.g.

```
type SomeService = CsvFile<const (__SOURCE_DIRECTORY__ + "/a.csv")>
```
Parentheses are needed around any simple contanst expressions after “const” that are not simple
literal constants, e.g.

```
type K = N.T< const (+1) >
```
During checking of a type A< _type-args_ >, where A is a provided type, the TPM GetStaticParameters is
invoked to determine the static parameters for the type A if any. If the static parameters exist and
are of the correct kinds, the TPM ApplyStaticArguments is invoked to apply the static arguments to
the provided type.

During checking of a method M< _type-args_ >, where M is a provided method definition, the TPM
GetStaticParametersForMethod is invoked to determine the static parameters if any. If the static
parameters exist and are of the correct kinds, the TPM ApplyStaticArgumentsForMethod is invoked to
apply the static arguments to the provided method.

In both cases a static parameter value must be given for each non-optional static parameter.

#### 16.1.1 Mangling of Static Parameter Values

Static parameter values are encoded into the names used for types and methods within F#
metadata. The encoding scheme used is

**encoding** (A<arg1,...,argN>) =

typeOrMethodName,ParamName1= **encoding** (arg1),..., ParamNameN= **encoding** (argN)

**encoding** ( _v_ ) = " _s_ "


```
where s is the result applying the F# ‘string’ operator to v (using invariant numeric
formatting), and in the result " is replaced by \" and \ by \\
```
### 16.2 PROVIDED NAMESPACE

Each type provider instance in the assembly context reports a collection of provided namespaces
though the GetNamespaces type provider method. Each provided namespace can in turn report
further namespaces through the GetNestedNamespaces type provider method.

### 16.3 PROVIDED TYPE DEFINITIONS

Each provided namespace reports provided type definitions though the GetTypes and
ResolveTypeName type provider methods. The type provider is obliged to ensure that these two
methods return consistent results.

Name resolution for unqualified identifiers may return provided type definitions if no other
resolution is available.

#### 16.3.1 Generated v. Erased Types

Each provided type definition may be _generated_ or _erased_. In this case, the types and method calls
are removed entirely during compilation and replaced with other representations. When an erased
type is used, the compiler will replace it with the first concrete type in its inheritance chain as
returned by the TPM type.BaseType. The erasure of an erased interface type is “object”.

```
➢ If it has a type definition under a path D.E.F , and the .Assembly of that type is in a different
assembly A to the provider’s assembly, then that type definition is a “generated” type
definition. Otherwise it is an erased type definition.
```
```
➢ Erased type definitions must return TypeAttributes with the IsErased flag set, value
0x40000000 and given by the F# literal TypeProviderTypeAttributes.IsErased.
```
```
➢ When a provided type definition is generated, its reported assembly A is treated as an
injected assembly which is statically linked into the resulting assembly.
```
```
➢ Concrete type definitions (both provided and F#-authored) and object expressions may not
inherit from erased types
```
```
➢ Concrete type definitions (both provided and F#-authored) and object expressions may not
implement erased interfaces
```
```
➢ If an erased type definition reports an interface, its erasure must implement the erasure of
that interface. The interfaces reported by an erased type definition must be unique up to
erasure.
```
```
➢ Erased types may not be used as the target type of a runtime type test of runtime coercion.
```

```
➢ When determining uniqueness for F#-declared methods, uniqueness is determined after
erasure of both provided types and units of measure.
```
```
➢ The elaborated form of F# expressions is after erasure of provided types.
```
```
➢ Two generated type definitions are equivalent if and only if they have the same F# path and
name in the same assembly, once they are rooted according to their corresponding
generative type definition.
```
```
➢ Two erased type definitions are only equivalent if they are provided by the same provider,
using the same type name, with the same static arguments.
```
#### 16.3.2 Type References

The elements of provided type definitions may reference other provided type definitions, and types
from imported assemblies referenced in the compilation context. They may not reference type
defined in the F# code currently being compiled.

#### 16.3.3 Static Parameters

A provided type definition may report a set of static parameters. For such a definition, all other
provided contents are ignored.

A provided method definition may also report a set of static parameters. For such a definition, all
other provided contents are ignored.

Static parameters may be optional and/or named, indicated by the Attributes property of the static
parameter. For a given set of static parameters, no two static parameters may have the same name
and named static arguments must come after all other arguments.

#### 16.3.4 Kind

```
➢ Provided type definitions may be classes.
```
```
This includes both erased and concrete types. This corresponds to the type.IsClass property
returning true for the provided type definition.
```
```
➢ Provided type definitions may be interfaces.
```
```
This includes both erased and concrete types. This corresponds to the type.IsInterface
property returning true. Only one of IsInterface, IsClass, IsStruct, IsEnum, IsDelegate,
IsArray may return true.
```
```
➢ Provided type definitions may be static classes.
```
```
This includes both erased and concrete types.
```
```
➢ Provided type definitions may be sealed.
```
```
➢ Provided type definitions may not be arrays. This means the type.IsArray property must
always return false. Provided types used in return types and argument positions may be
array “symbol” types, see below.
```

```
➢ By default provided type definitions which are reference types are considered to support
null literals.
```
```
A provided type definition may have the AllowNullLiteralAttribute with value false in
which case the type is considered to have null as an abnormal value.
```
#### 16.3.5 Inheritance

```
➢ Provided type definitions may report base types.
```
```
➢ Provided type definition may report interfaces.
```
#### 16.3.6 Members

```
➢ Provided type definitions may report methods.
```
```
This corresponds to non-null results from the type.GetMethod and type.GetMethods of the
provided type definition. The results returned by these methods must be consistent.
```
```
o Provided methods may be static, instance and abstract
```
```
o Provided methods may not be class constructors (.cctor). By .NET rules these would
have to be private anyway.
```
```
o Provided methods may be operators such as op_Addition.
```
```
➢ Provided type definitions may report properties.
```
```
This corresponds to non-null results from the type.GetProperty and type.GetProperties of the
provided type definition. The results returned by these methods must be consistent.
```
```
o Provided properties may be static or instance
```
```
o Provided properties may be indexers. This corresponds to reporting methods with
name Item , or as identified by DefaultMemberAttribute non-null results from the
type.GetEvent and type.GetEvents of the provided type definition. The results
returned by these methods must be consistent. This include 1D, 2D, 3D and 4D
indexer access notation in F# (corresponding to different numbers of parameters to
the indexer property).
```
```
➢ Provided type definitions may report constructors.
```
```
This corresponds to non-null results from the type.GetConstructor and type.GetConstructors of
the provided type definition. The results returned by these methods must be consistent.
```
```
➢ Provided type definitions may report events.
```
```
This corresponds to non-null results from the type.GetEvent and type.GetEvents of the
provided type definition. The results returned by these methods must be consistent.
```
```
➢ Provided type definitions may report nested types.
```

```
This corresponds to non-null results from the type.GetNestedType and type.GetNestedTypes of
the provided type definition. The results returned by these methods must be consistent.
```
```
o The nested types of an erased type may be generated types in a generated
assembly. The type.DeclaringType property of the nested type need not report the
erased type.
```
```
➢ Provided type definitions may report literal (constant) fields.
```
```
This corresponds to non-null results from the type.GetField and type.GetFields of the
provided type definition, and is related to the fact that provided types may be
enumerations. The results returned by these methods must be consistent.
```
```
➢ Provided type definitions may not report non-literal (i.e. non-const) fields
```
```
This is a deliberate feature limitation, because in .NET, non-literal fields should not appear in
public API surface area.
```
#### 16.3.7 Attributes

```
➢ Provided type definitions, properties, constructors, events and methods may report
attributes.
```
```
This includes ObsoleteAttribute and ParamArrayAttribute attributes
```
#### 16.3.8 Accessibility

```
➢ All erased provided type definitions must be public
```
```
However, concrete provided types are each in an assembly A that gets statically linked into
the resulting F# component. These assemblies may contain private types and methods.
These types are not directly “provided” types, since they are not returned to the compiler by
the API, but they are part of the closure of the types that are being embedded.
```
#### 16.3.9 Elaborated Code

Elaborated uses of provided methods are erased to elaborated expressions returned by the TPM
GetInvokerExpression. In the current release of F#, replacement elaborated expressions are
specified via F# quotation values composed of quotations constructed with respect to the
referenced assemblies in the compilation context according to the following quotation library calls:

```
➢ Expr.NewArray
➢ Expr.NewObject
➢ Expr.WhileLoop
➢ Expr.NewDelegate
➢ Expr.ForIntegerRangeLoop
➢ Expr.Sequential
➢ Expr.TryWith
➢ Expr.TryFinally
```

```
➢ Expr.Lambda
➢ Expr.Call
➢ Expr.Constant
➢ Expr.DefaultValue
➢ Expr.NewTuple
➢ Expr.TupleGet
➢ Expr.TypeAs
➢ Expr.TypeTest
➢ Expr.Let
➢ Expr.VarSet
➢ Expr.IfThenElse
➢ Expr.Var
```
The type of the quotation expression returned by GetInvokerExpression must be an erased type. The
type provider is obliged to ensure that this type is equivalent to the erased type of the expression it
is replacing.

#### 16.3.10 Further Restrictions

```
➢ If a provided type definition reports a member with ExtensionAttribute, it is not treated as
an extension member
```
```
➢ Provided type and method definitions may not be generic
```
```
This corresponds to
```
- GetGenericArguments returning length 0
- For type definitions, IsGenericType and IsGenericTypeDefinition returning false
- For method definitions, IsGenericMethod and IsGenericMethodDefinition returning false


## 17. SPECIAL ATTRIBUTES AND TYPES

This chapter describes attributes and types that have special significance to the F# compiler.

### 17.1 CUSTOM ATTRIBUTES RECOGNIZED BY F#

The following custom attributes have special meanings recognized by the F# compiler. Except where
indicated, the attributes may be used in F# code, in referenced assemblies authored in F#, or in
assemblies that are authored in other CLI languages.

Attribute Description
System.ObsoleteAttribute
[<Obsolete(...)>]

Indicates that the construct is obsolete and
gives a warning or error depending on the
settings in the attribute.
This attribute may be used in both F# and
imported assemblies.
System.ParamArrayAttribute
[<ParamArray(...)>]

When applied to an argument of a method,
indicates that the method can accept a
variable number of arguments.
This attribute may be used in both F# and
imported assemblies.
System.ThreadStaticAttribute
[<ThreadStatic(...)>]

Marks a mutable static value in a class as
thread static.
This attribute may be used in both F# and
imported assemblies.
System.ContextStaticAttribute
[<ContextStatic(...)>]

Marks a mutable static value in a class as
context static.
This attribute may be used in both F# and
imported assemblies.
System.AttributeUsageAttribute
[<AttributeUsage(...)>]

Specifies the attribute usage targets for an
attribute.
This attribute may be used in both F# and
imported assemblies.
System.Diagnostics.ConditionalAttribute
[<Conditional(...)>]

Emits code to call the method only if the
corresponding conditional compilation symbol
is defined.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyInformationalVersionAttrib
ute
[<AssemblyInformationalVersion(...)>]

Attaches additional version metadata to the
compiled form of the assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyFileVersionAttribute
[<AssemblyFileVersion(...)>]

```
Attaches file version metadata to the compiled
form of the assembly.
This attribute may be used in both F# and
imported assemblies.
```

Attribute Description
System.Reflection.AssemblyDescriptionAttribute
[<AssemblyDescription(...)>]

Attaches descriptive metadata to the compiled
form of the assembly, such as the “Comments”
attribute in the Win32 version resource for the
assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyTitleAttribute
[<AssemblyTitle(...)>]

Attaches title metadata to the compiled form
of the assembly, such as the “ProductName”
attribute in the Win32 version resource for the
assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyCopyrightAttribute
[<AssemblyCopyright(...)>]

Attaches copyright metadata to the compiled
form of the assembly, such as the
“LegalCopyright” attribute in the Win32
version resource for the assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyTrademarkAttribute
[<AssemblyTrademark(...)>]

Attaches trademark metadata to the compiled
form of the assembly, such as the
“LegalTrademarks” attribute in the Win32
version resource for the assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyCompanyAttribute
[<AssemblyCompany(...)>]

Attaches company name metadata to the
compiled form of the assembly, such as the
“CompanyName” attribute in the Win32
version resource for the assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyProductAttribute
[<AssemblyProduct(...)>]

Attaches product name metadata to the
compiled form of the assembly, such as the
“ProductName” attribute in the Win32 version
resource for the assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.AssemblyKeyFileAttribute
[<AssemblyKeyFile(...)>]

Indicates to the F# compiler how to sign an
assembly.
This attribute may be used in both F# and
imported assemblies.
System.Reflection.DefaultMemberAttribute
[<DefaultMember(...)>]

When applied to a type, specifies the name of
the indexer property for that type.
This attribute may be used in both F# and
imported assemblies.
System.Runtime.CompilerServices.InternalsVisibleToAt
tribute
[<InternalsVisibleTo(...)>]

Directs the F# compiler to permit access to the
internals of the assembly.
This attribute may be used in both F# and
imported assemblies.
System.Runtime.CompilerServices.TypeForwardedToAttri
bute
[<TypeForwardedTo(...)>]

```
Indicates a type redirection.
This attribute may be used only in imported
non-F# assemblies. It is not permitted in F#
code.
```

Attribute Description
System.Runtime.CompilerServices.ExtensionAttribute
[<Extension(...)>]

Indicates the compiled form of a C# extension
member.
This attribute may be used only in imported
non-F# assemblies. It is not permitted in F#
code.
System.Runtime.InteropServices.DllImportAttribute
[<DllImport(...)>]

When applied to a function definition in a
module, causes the F# compiler to ignore the
implementation of the definition, and instead
compile it as a CLI P/Invoke stub declaration.
This attribute may be used in both F# and
imported assemblies.
System.Runtime.InteropServices.MarshalAsAttribute
[<MarshalAs(...)>]

When applied to a parameter or return type,
specifies the marshalling attribute for a CLI
P/Invoke stub declaration.
This attribute may be used in both F# and
imported assemblies. However, F# does not
support the specification of "custom"
marshallers.
System.Runtime.InteropServices.InAttribute
[<In>]

When applied to a parameter, specifies the CLI
In attribute.
This attribute may be used in both F# and
imported assemblies. However, in F# its only
effect is to change the corresponding
attribute in the CLI compiled form.
System.Runtime.InteropServices.OutAttribute
[<Out>]

When applied to a parameter, specifies the CLI
Out attribute.
This attribute may be used in both F# and
imported assemblies. However, in F# its only
effect is to change the corresponding attribute
in the CLI compiled form.
System.Runtime.InteropServices.OptionalAttribute
[<Optional(...)>]

When applied to a parameter, specifies the CLI
Optional attribute.
This attribute may be used in both F# and
imported assemblies. However, in F# its only
effect is to change the corresponding attribute
in the CLI compiled form.
System.Runtime.InteropServices.FieldOffsetAttribute
[<FieldOffset(...)>]

When applied to a field, specifies the field
offset of the underlying CLI field.
This attribute may be used in both F# and
imported assemblies.
System.NonSerializedAttribute
[<NonSerialized>]

When applied to a field, sets the "not
serialized" bit for the underlying CLI field.
This attribute may be used in both F# and
imported assemblies.
System.Runtime.InteropServices.StructLayoutAttribute
[<StructLayout(...)>]

Specifies the layout of a CLI type.
This attribute may be used in both F# and
imported assemblies.
FSharp.Core.AutoSerializableAttribute
[<AutoSerializable(false)>]

```
When added to a type with value false ,
disables default serialization, so that F# does
not make the type serializable.
This attribute should be used only in F#
assemblies.
```

Attribute Description
FSharp.Core.CLIMutableAttribute
[<CLIMutable>]

When specified, a record type is compiled to a
CLI representation with a default constructor
with property getters and setters.
This attribute should be used only in F#
assemblies.
FSharp.Core.AutoOpenAttribute
[<AutoOpen>]

When applied to an assembly and given a
string argument, causes the namespace or
module to be opened automatically when the
assembly is referenced.
When applied to a module without a string
argument, causes the module to be opened
automatically when the enclosing namespace
or module is opened.
This attribute should be used only in F#
assemblies.
FSharp.Core.
CompilationRepresentationAttribute
[<CompilationRepresentation(...)>]

Adjusts the runtime representation of a type.
This attribute should be used only in F#
assemblies.
FSharp.Core.CompiledNameAttribute
[<CompiledName(...)>]

Changes the compiled name of an F# language
construct.
This attribute should be used only in F#
assemblies.
FSharp.Core.CustomComparisonAttribute
[<CustomComparison>]

When applied to an F# structural type,
indicates that the type has a user-specified
comparison implementation.
This attribute should be used only in F#
assemblies.
FSharp.Core.CustomEqualityAttribute
[<CustomEquality>]

When applied to an F# structural type,
indicates that the type has a user-defined
equality implementation.
This attribute should be used only in F#
assemblies.
FSharp.Core.DefaultAugmentationAttribute
[<DefaultAugmentation(...)>]

When applied to an F# discriminated union
type with value false, turns off the generation
of standard helper member tester, constructor
and accessor members for the generated CLI
class for that type.
This attribute should be used only in F#
assemblies.
FSharp.Core.DefaultValueAttribute
[<DefaultValue(...)>]

When added to a field declaration, specifies
that the field is not initialized. During type
checking, a constraint is asserted that the field
type supports null. If the argument to the
attribute is **false** , the constraint is not
asserted.
This attribute should be used only in F#
assemblies.
FSharp.Core.GeneralizableValueAttribute
[<GeneralizableValue>]

```
When applied to an F# value, indicates that
uses of the attribute can result in generic code
through the process of type inference. For
example, Set.empty. The value must typically
be a type function whose implementation has
no observable side effects.
This attribute should be used only in F#
assemblies.
```

Attribute Description
FSharp.Core.LiteralAttribute
[<Literal>]

When applied to a value, compiles the value as
a CLI literal.
This attribute should be used only in F#
assemblies.
FSharp.Core.NoDynamicInvocationAttribute
[<NoDynamicInvocation>]

When applied to an inline function or member
definition, replaces the generated code with a
stub that throws an exception at runtime. This
attribute is used to replace the default
generated implementation of unverifiable
inline members with a verifiable stub.
This attribute should be used only in F#
assemblies.
FSharp.Core.CompilerMessageAttribute
[<CompilerMessage(...)>]

When applied to an F# construct, indicates
that the F# compiler should report a message
when the construct is used.
This attribute should be used only in F#
assemblies.
FSharp.Core.StructAttribute
[<Struct>]

Indicates that a type is a struct type.
This attribute should be used only in F#
assemblies.
FSharp.Core.ClassAttribute
[<Class>]

Indicates that a type is a class type.
This attribute should be used only in F#
assemblies.
FSharp.Core.InterfaceAttribute
[<Interface>]

Indicates that a type is an interface type.
This attribute should be used only in F#
assemblies.
FSharp.Core.MeasureAttribute
[<Measure>]

Indicates that a type or generic parameter is a
unit of measure definition or annotation.
This attribute should be used only in F#
assemblies.
FSharp.Core.ReferenceEqualityAttribute
[<ReferenceEquality>]

When applied to an F# record or union type,
indicates that the type should use reference
equality for its default equality
implementation.
This attribute should be used only in F#
assemblies.
FSharp.Core.ReflectedDefinitionAttribute
[<ReflectedDefinition>]

Makes the quotation form of a definition
available at runtime through the
FSharp.Quotations.
Expr.GetReflectedDefinition method.
This attribute should be used only in F#
assemblies.
FSharp.Core.
RequireQualifiedAccessAttribute
[<RequireQualifiedAccess>]

```
When applied to an F# module, warns if an
attempt is made to open the module name.
When applied to an F# union or record type,
indicates that the field labels or union cases
must be referenced by using a qualified path
that includes the type name.
This attribute should be used only in F#
assemblies.
```

Attribute Description
FSharp.Core.
RequiresExplicitTypeArgumentsAttribute
[<RequiresExplicitTypeArguments>]

When applied to an F# function or method,
indicates that the function or method must be
invoked with explicit type arguments, such as
typeof<int>.
This attribute should be used only in F#
assemblies.
FSharp.Core.StructuralComparisonAttribute
[<StructuralComparison>]

When added to a record, union, exception, or
structure type, confirms the automatic
generation of implementations for
**IComparable** for the type.
This attribute should only be used in F#
assemblies.
FSharp.Core.StructuralEqualityAttribute
[<StructuralEquality>]

When added to a record, union, or struct type,
confirms the automatic generation of
overrides for Equals and GetHashCode for the
type.
This attribute should be used only in F#
assemblies.
FSharp.Core.VolatileFieldAttribute
[<VolatileField>]

```
When applied to an F# field or mutable value
definition, controls whether the CLI volatile
prefix is emitted before accesses to the field.
This attribute should be used only in F#
assemblies.
```
FSharp.Core.TypeProviderXmlDocAttribute (^) Specifies documentation for provided type
definitions and provided members
FSharp.Core.TypeProviderDefinitionLocationAttribute (^) Specifies location information for provided
type definitions and provided members

### 17.2 CUSTOM ATTRIBUTES EMITTED BY F#

The F# compiler can emit the following custom attributes:

**Attribute Description**

System.Diagnostics.DebuggableAttribute (^) Improves debuggability of F# code.
System.Diagnostics.DebuggerHiddenAttribute (^) Improves debuggability of F# code.
System.Diagnostics.DebuggerDisplayAttribute (^) Improves debuggability of F# code.
System.Diagnostics.DebuggerBrowsableAttribute (^) Improves debuggability of F# code.
System.Runtime.CompilerServices.
CompilationRelaxationsAttribute
Enables extra JIT optimizations.
System.Runtime.CompilerServices.
CompilerGeneratedAttribute
Indicates that a method, type, or
property is generated by the F#
compiler, and does not correspond
directly to user source code.
System.Reflection.DefaultMemberAttribute (^) Specifies the name of the indexer
property for a class.
FSharp.Core.CompilationMappingAttribute (^) Indicates how a CLI construct
corresponds to an F# source language
construct.
FSharp.Core.FSharpInterfaceDataVersionAttribute (^) Defines the schema number for the
embedded binary resource for F#-
specific interface and optimization data.


**Attribute Description**

FSharp.Core.OptionalArgumentAttribute (^) Indicates optional arguments to F#
members.

### 17.3 CUSTOM ATTRIBUTES NOT RECOGNIZED BY F#

The following custom attributes are defined in some CLI implementations and may appear to be
relevant to F#. However, they either do not affect the behavior of the F# compiler, or result in an
error when used in in F# code.

**Attribute Description**

System.Runtime.CompilerServices.DecimalConstantAttribute (^) The F# compiler ignores this attribute.
However, if used in F# code, it can
cause some other CLI languages to
interpret a decimal constant as a
compile-time literal.
System.Runtime.CompilerServices.RequiredAttributeAttribute (^) Do not use this attribute in F# code.
The F# compiler ignores it or returns
an error.
System.Runtime.InteropServices.
DefaultParameterValueAttribute
Do not use this attribute in F# code.
The F# compiler ignores it or returns
an error.
System.Runtime.InteropServices.
UnmanagedFunctionPointerAttribute
Do not use this attribute in F# code.
The F# compiler ignores it or returns
an error.
System.Runtime.CompilerServices.FixedBufferAttribute (^) Do not use this attribute in F# code.
The F# compiler ignores it or returns
an error.
System.Runtime.CompilerServices.UnsafeValueTypeAttribute (^) Do not use this attribute in F# code.
The F# compiler ignores it or returns
an error.
System.Runtime.CompilerServices.SpecialNameAttribute (^) Do not use this attribute in F# code.
The F# compiler ignores it or returns
an error.

### 17.4 EXCEPTIONS THROWN BY F# LANGUAGE PRIMITIVES

Certain F# language and primitive library operations throw the following exceptions.

**Attribute Description**

System.ArithmeticException (^) An arithmetic operation failed. This is the base class for exceptions
such as System.DivideByZeroException and
System.OverflowException.
System.ArrayTypeMismatchException (^) An attempt to store an element in an array failed because the
runtime type of the stored element is incompatible with the
runtime type of the array.
System.DivideByZeroException (^) An attempt to divide an integral value by zero occurred.
System.IndexOutOfRangeException (^) An attempt to index an array failed because the index is less than
zero or outside the bounds of the array.
System.InvalidCastException (^) An explicit conversion from a base type or interface to a derived
type failed at run time.


**Attribute Description**

System.NullReferenceException (^) A null reference was used in a way that caused the referenced
object to be required.
System.OutOfMemoryException (^) An attempt to use new to allocate memory failed.
System.OverflowException (^) An arithmetic operation in a checked context overflowed.
System.StackOverflowException (^) The execution stack was exhausted because of too many pending
method calls, which typically indicates deep or unbounded
recursion.
System.TypeInitializationException (^) F# initialization code for a type threw an exception that was not
caught.



## 18. THE F# LIBRARY FSHARP.CORE.DLL

All compilations reference the following two base libraries:

- The CLI base library mscorlib.dll.
- The F# base library FSharp.Core.dll

The following namespaces are automatically opened for all F# code:

```
open FSharp
open FSharp.Core
open FSharp.Core.LanguagePrimitives
open FSharp.Core.Operators
open FSharp.Text
open FSharp.Collections
open FSharp.Core.ExtraTopLevelOperators
```
A compilation may open additional namespaces may be opened if the referenced F# DLLs contain
AutoOpenAttribute declarations.

See also the online documentation at [http://msdn.com/library/ee353567.aspx.](http://msdn.com/library/ee353567.aspx.)

### 18.1 BASIC TYPES (FSHARP.CORE)

This section provides details about the basic types that are defined in FSharp.Core.

#### 18.1.1 Basic Type Abbreviations

**Type Name Description**
obj System.Object
exn System.Exception
nativeint System.IntPtr
unativeint System.UIntPtr
string System.String
float32, single System.Single
float, double System.Double
sbyte, int8 System.SByte
byte, uint8 System.Byte
int16 System.Int16
uint16 System.UInt16
int32, int System.Int32
uint32 System.UInt32
int64 System.Int64
uint64 System.UInt64
char System.Char
bool System.Boolean
decimal System.Decimal

#### 18.1.2 Basic Types that Accept Unit of Measure Annotations

**Type Name Description**

sbyte<_> (^) Underlying representation System.SByte, but accepts a unit of measure.
int16<_> (^) Underlying representation System.Int16, but accepts a unit of measure.


**Type Name Description**

int32<_> (^) Underlying representation System.Int32, but accepts a unit of measure.
int64<_> (^) Underlying representation System.Int64, but accepts a unit of measure.
float32<_> (^) Underlying representation System.Single, but accepts a unit of measure.
float<_> (^) Underlying representation System.Double, but accepts a unit of measure.
decimal<_> (^) Underlying representation System.Decimal, but accepts a unit of measure.

#### 18.1.3 The nativeptr<_> Type

When the nativeptr< _type_ > is used in method argument or return position, it is represented in
compiled CIL code as either:

- A CLI pointer type _type_ *, if _type_ does not contain any generic type parameters.
- T CLI type System.IntPtr otherwise.

```
Note : CLI pointer types are rarely used. In CLI metadata, pointer types sometimes
appear in CLI metadata unsafe object constructors for the CLI type System.String.
```
```
You can convert between System.UIntPtr and nativeptr<'T> by using the inlined
unverifiable functions in FSharp.NativeInterop.NativePtr.
```
```
nativeptr<_> compiles in different ways because CLI restricts where pointer types can
appear.
```
### 18.2 BASIC OPERATORS AND FUNCTIONS (FSHARP.CORE.OPERATORS)

#### 18.2.1 Basic Arithmetic Operators

The following operators are defined in FSharp.Core.Operators:

**Operator or Function
Name**

```
Expression Form Description
```
(+) x + y (^) Overloaded addition.
(-) x - y (^) Overloaded subtraction.
(*) x * y (^) Overloaded multiplication.
(/) x / y (^) Overloaded division.
For negative numbers, the behavior of this operator
follows the definition of the corresponding operator in
the C# specification.
(%) x % y (^) Overloaded remainder.
For integer types, the result of x % y is the value
produced by x – (x / y) * y. If y is zero,
System.DivideByZeroException is thrown. The
remainder operator never causes an overflow. This
follows the definition of the remainder operator in the C#
specification.
For floating-point types, the behavior of this operator
also follows the definition of the remainder operator in
the C# specification.
(~-) - x (^) Overloaded unary negation.
not not x (^) Boolean negation.


#### 18.2.2 Generic Equality and Comparison Operators

The following operators are defined in FSharp.Core.Operators:

**Operator or Function
Name**

```
Expression Form Description
```
(<) x < y (^) Generic less-than
(<=) x <= y (^) Generic less-than-or-equal
(>) x > y (^) Generic greater-than
(>=) x >= y (^) Generic greater-than-or-equal
(=) x = y (^) Generic equality
(<>) x <> y (^) Generic disequality
max max x y (^) Generic maximum
min min x y (^) Generic minimum

#### 18.2.3 Bitwise Operators......................................................................................................

The following operators are defined in FSharp.Core.Operators:

**Operator or Function
Name**

```
Expression Form Description
```
(<<<) x <<< y (^) Overloaded bitwise left-shift
(>>>) x >>> y (^) Overloaded bitwise arithmetic right-shift
(^^^) x ^^^ y (^) Overloaded bitwise exclusive or (XOR)
(&&&) x &&& y (^) Overloaded bitwise and
(|||) x ||| y (^) Overloaded bitwise or
(~~~) ~~~x (^) Overloaded bitwise negation

#### 18.2.4 Math Operators

The following operators are defined in FSharp.Core.Operators:

**Operator or Function
Name**

```
Expression Form Description
```
abs abs x (^) Overloaded absolute value
acos acos x (^) Overloaded inverse cosine
asin asin x (^) Overloaded inverse sine
atan atan x (^) Overloaded inverse tangent
atan2 atan2 x y (^) Overloaded inverse tangent of x/y
ceil ceil x (^) Overloaded floating-point ceiling
cos cos x (^) Overloaded cosine
cosh cosh x (^) Overloaded hyperbolic cosine
exp exp x (^) Overloaded exponent
floor floor x (^) Overloaded floating-point floor
log log x (^) Overloaded natural logarithm
log10 log10 x (^) Overloaded base-10 logarithm
(**) x ** y (^) Overloaded exponential
pown pown x y (^) Overloaded integer exponential
round round x (^) Overloaded rounding
sign sign x (^) Overloaded sign function
sin sin x (^) Overloaded sine function
sinh sinh x (^) Overloaded hyperbolic sine function
sqrt sqrt x (^) Overloaded square root function
tan tan x (^) Overloaded tangent function
tanh tanh x (^) Overloaded hyperbolic tangent function


#### 18.2.5 Function Pipelining and Composition Operators

The following operators are defined in FSharp.Core.Operators:

**Operator/Function
Name**

```
Expression Form Description
```
(|>) x |> f (^) Pipelines the value x to the function f (forward
pipelining)
(>>) f >> g (^) Composes two functions, so that they are applied in order
from left to right
(<|) f <| x (^) Pipelines the value x to the function f (backward
pipelining)
(<<) g << f (^) Composes two functions, so that they are applied in order
from right to left (backward function composition)
ignore ignore x (^) Computes and discards a value

#### 18.2.6 Object Transformation Operators

The following operators are defined in FSharp.Core.Operators:

**Operator/Function
Name**

```
Expression Form Description
```
box box x (^) Converts to object representation.
hash hash x (^) Generates a hash value.
sizeof sizeof< _type_ > (^) Computes the size of a value of the given type.
typeof typeof< _type_ > (^) Computes the System.Type representation of the given
type.
typedefof typedefof< _type_ > (^) Computes the System.Type representation of _type_ and
calls GetGenericTypeDefinition if it is a generic type.
unbox unbox x (^) Converts from object representation.
ref ref x (^) Allocates a mutable reference cell.
(!) !x (^) Reads a mutable reference cell.

#### 18.2.7 Pair Operators

The following operators are defined in FSharp.Core.Operators:

**Operator or Function
Name**

```
Expression Form Description
```
fst fst p (^) Returns the first element of a pair.
snd snd p (^) Returns the second element of a pair

#### 18.2.8 Exception Operators

The following operators are defined in FSharp.Core.Operators:

**Operator/Function
Name**

```
Expression Form Description
```
failwith failwith x (^) Raises a FailureException exception.
invalidArg invalidArg x (^) Raises an ArgumentException exception.
raise raise x (^) Raises an exception.
reraise reraise() (^) Rethrows the current exception.

#### 18.2.9 Input/Output Handles

The following operators are defined in FSharp.Core.Operators:


**Operator or Function
Name**

```
Expression Form Description
```
stdin Stdin (^) Computes System.Console.In.
stdout Stdout (^) Computes System.Console.Out.
stderr Stderr (^) Computes System.Console.Error.

#### 18.2.10 Overloaded Conversion Functions

The following operators are defined in FSharp.Core.Operators:

**Operator or Function
Name**

```
Expression Form Description
```
byte byte x (^) Overloaded conversion to a byte
sbyte sbyte x (^) Overloaded conversion to a signed byte
int16 int16 x (^) Overloaded conversion to a 16-bit integer
uint16 uint16 x (^) Overloaded conversion to an unsigned 16-bit integer
int32, int int32 x
int x
Overloaded conversion to a 32-bit integer
uint32 uint32 x (^) Overloaded conversion to an unsigned 32-bit integer
int64 int64 x (^) Overloaded conversion to a 64-bit integer
uint64 uint64 x (^) Overloaded conversion to an unsigned 64-bit integer
nativeint nativeint x (^) Overloaded conversion to an native integer
unativeint unativeint x (^) Overloaded conversion to an unsigned native integer
float, double float x
double x
Overloaded conversion to a 64-bit IEEE floating-point
number
float32, single float32 x
single x
Overloaded conversion to a 32-bit IEEE floating-point
number
decimal decimal x (^) Overloaded conversion to a System.Decimal number
char char x (^) Overloaded conversion to a System.Char value
enum enum x (^) Overloaded conversion to a typed enumeration value

### 18.3 CHECKED ARITHMETIC OPERATORS

The module FSharp.Core.Operators.Checked defines runtime-overflow-checked versions of the
following operators:

**Operator or Function
Name**

```
Expression Form Description
```
(+) x + y (^) Checked overloaded addition
(-) x – y (^) Checked overloaded subtraction
(*) x * y (^) Checked overloaded multiplication
(~-) - x (^) Checked overloaded unary negation
byte byte x (^) Checked overloaded conversion to a byte
sbyte sbyte x (^) Checked overloaded conversion to a signed byte
int16 int16 x (^) Checked overloaded conversion to a 16-bit integer
uint16 uint16 x (^) Checked overloaded conversion to an unsigned 16-bit
integer
int32, int int32 x
int x
Checked overloaded conversion to a 32-bit integer
uint32 uint32 x (^) Checked overloaded conversion to an unsigned 32-bit
integer
int64 int64 x (^) Checked overloaded conversion to a 64 - bit integer
uint64 uint64 x (^) Checked overloaded conversion to an unsigned 64-bit
integer


**Operator or Function
Name**

```
Expression Form Description
```
nativeint nativeint x (^) Checked overloaded conversion to an native integer
unativeint unativeint x (^) Checked overloaded conversion to an unsigned native
integer
char char x (^) Checked overloaded conversion to a System.Char value

### 18.4 LIST AND OPTION TYPES

#### 18.4.1 The List Type

The following shows the elements of the F# type FSharp.Collections.list referred to in this
specification:

```
type 'T list =
| ([])
| (::) of 'T * 'T list
static member Empty : 'T list
member Length : int
member IsEmpty : bool
member Head : 'T
member Tail : 'T list
member Item :int -> 'T with get
static member Cons : 'T * 'T list -> 'T list
interface System.Collections.Generic.IEnumerable<'T>
interface System.Collections.IEnumerable
```
#### 18.4.2 The Option Type

The following shows the elements of the F# type FSharp.Core.option referred to in this specification:

```
[<DefaultAugmentation(false)>]
[<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
type 'T option =
| None
| Some of 'T
static member None : 'T option
static member Some : 'T -> 'T option
[<CompilationRepresentation(CompilationRepresentationFlags.Instance)>]
member Value : 'T
member IsSome : bool
member IsNone : bool
```
### 18.5 LAZY COMPUTATIONS (LAZY)

See [http://msdn.microsoft.com/library/ee353813.aspx](http://msdn.microsoft.com/library/ee353813.aspx)

### 18.6 ASYNCHRONOUS COMPUTATIONS (ASYNC)

See [http://msdn.microsoft.com/library/ee370232.aspx](http://msdn.microsoft.com/library/ee370232.aspx)


### 18.7 QUERY EXPRESSIONS

See [http://msdn.microsoft.com/library/hh698410](http://msdn.microsoft.com/library/hh698410)

### 18.8 AGENTS (MAILBOXPROCESSOR)

See [http://msdn.microsoft.com/library/ee370357.aspx](http://msdn.microsoft.com/library/ee370357.aspx)

### 18.9 EVENT TYPES

See [http://msdn.microsoft.com/library/ee370608.aspx](http://msdn.microsoft.com/library/ee370608.aspx)

### 18.10 IMMUTABLE COLLECTION TYPES (MAP, SET)

See [http://msdn.microsoft.com/library/ee353413.aspx](http://msdn.microsoft.com/library/ee353413.aspx)

### 18.11 TEXT FORMATTING (PRINTF)

See [http://msdn.microsoft.com/library/ee370560.aspx](http://msdn.microsoft.com/library/ee370560.aspx)

### 18.12 REFLECTION

See [http://msdn.microsoft.com/library/ee353491.aspx](http://msdn.microsoft.com/library/ee353491.aspx)

### 18.13 QUOTATIONS

See [http://msdn.microsoft.com/library/ee370558.aspx](http://msdn.microsoft.com/library/ee370558.aspx)

### 18.14 NATIVE POINTER OPERATIONS

The FSharp.Core.NativeIntrop namespace contains functionality for interoperating with native
code.

Use of these functions is unsafe, and incorrect use may generate invalid IL code.

**Operator or Function Name Description**

NativePtr.ofNativeInt (^) Returns a typed native pointer for a machine address.
NativePtr.toNativeInt (^) Returns a machine address for a typed native pointer.
NativePtr.add (^) Computes an indexed offset from the input pointer.
NativePtr.read (^) Reads the memory that the input pointer references.
NativePtr.write (^) Writes to the memory that the input pointer references.
NativePtr.get (^) Reads the memory at an indexed offset from the input pointer.


**Operator or Function Name Description**

NativePtr.set (^) Writes the memory at an indexed offset from the input pointer.
NativePtr.stackalloc (^) Allocates a region of memory on the stack.

#### 18.14.1 Stack Allocation

The NativePtr.stackalloc function works as follows. Given

```
stackalloc< ty > n
```
the unmanaged type ty specifies the type of the items that will be stored in the newly allocated
location, and _n_ indicates the number of these items. Taken together, these establish the required
allocation size.

The stackalloc function allocates _n_ * sizeof< _ty_ > bytes from the call stack and returns a pointer of
type nativeptr< _ty_ > to the newly allocated block. The content of the newly allocated memory is
undefined. If _n_ is a negative value, the behavior of the function is undefined. If _n_ is zero, no allocation
is made, and the returned pointer is implementation-defined. If insufficient memory is available to
allocate a block of the requested size, the System.StackOverflowException is thrown.

Use of this function is unsafe, and incorrect use might generate invalid IL code. For example, the
function should not be used in with or finally blocks in try/with or try/finally expressions. These
conditions are not checked by the F# compiler, because this primitive is rarely used from F# code.

There is no way to explicitly free memory that is allocated using stackalloc. All stack-allocated
memory blocks that are created during the execution of a function or member are automatically
discarded when that function or member returns. This behavior is similar to that of the alloca
function, an extension commonly found in C and C++ implementations.


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

## APPENDIX A: F# GRAMMAR SUMMARY

This appendix summarizes the grammar of the F# language. The following table describes the
notation conventions used in the grammar.

**Notation Conventions in Grammar Rules
Notation Description Example**

_element-name_ opt (^) The (^) opt subscript indicates that element-name
is optional.
**let rec** opt
... (^) An ellipsis indicates that the preceding non-
terminal construct and the separator token
can repeat any number of times.
_expr_ ',' ... ',' _expr_
**keyword** (^) Boldface type identifies a language keyword
that must appear verbatim.
**module** _long-ident module-
elems
element-name_ (^) Italics identify an element that is defined in
the grammar.
_script-fragment_ :
_module-elems_
[ char1 – char2 ] (^) All ASCII characters in the range from _char1_
to _char2_ , inclusive_._
[ a – z ]
[ ^ char1 – char2 ] (^) All ASCI characters except those in the
specified range.
[ ^ A – Z ]
‘symbol’ or “symbol” (^) The literal _symbol_ is used in the grammar. '(', "if"
(spec) (^) Parentheses enclose required individual
grammar elements.
(+|-)
$token (^) Lexical analysis inserts _$token_ as a hidden
symbol.
$app

### A.1 Lexical Grammar

##### A.1.1 Whitespace

_whitespace_ : ' '+

_newline_ :
'\n'
'\r' '\n'

_whitespace-or-newline_ :
_whitespace
newline_

##### A.1.2 Comments

_block-comment-start_ : "(*"


_block-comment-end_ : "*)"

_end-of-line-comment_ : "//" [^'\n' '\r']*

##### A.1.3 Conditional Compilation

```
if-directive : "#if" whitespace ident-text
else-directive : "#else"
endif-directive : "#endif"
```
##### A.1.4 Identifiers and Keywords

A.1.4.1 Identifiers
_digit-char_ : [0-9]

_letter-char_ :
'\Lu'
'\Ll'
'\Lt'
'\Lm'
'\Lo'
'\Nl'
_connecting-char_ : '\Pc'

_combining-char_ :
'\Mn'
'\Mc'

_formatting-char_ : '\Cf'

_ident-start-char_ :
_letter-char_
_

_ident-char_ :
_letter-char
digit-char
connecting-char
combining-char
formatting-char_
'
_

_ident-text_ : _ident-start-char ident-char_ *

_ident_ :
_ident-text_
`` ( [^'`' '\n' '\r' '\t'] | '`' [^ '`' '\n' '\r' '\t'] )+ ``

A.1.4.2 Long Identifiers
_long-ident_ : _ident_ '.' ... '.' _ident
long-ident-or-op_ :
_long-ident_ '.' _ident-or-op
ident-or-op_

A.1.4.3 Keywords
_ident-keyword_ : one of


**abstract and as assert base begin class default delegate do done
downcast downto elif else end exception extern false finally for
fun function global if in inherit inline interface internal lazy let
match member module mutable namespace new null of open or
override private public rec return sig static struct then to
true try type upcast use val void when while with yield**

_reserved-ident-keyword_ : one of
**atomic break checked component const constraint constructor
continue eager fixed fori functor include
measure method mixin object parallel params process protected pure
recursive sealed tailcall trait virtual volatile**

_reserved-ident-formats_ :
_ident-text_ ( '!' | '#')

A.1.4.4 Symbolic Keywords
_symbolic-keyword_ : one of
**let! use! do! yield! return!**
| -> <-. : ( ) [ ] [< >] [| |] { }
' # :?> :? :> .. :: := ;; ; =
_? ?? (*) <@ @> <@@ @@>

_reserved-symbolic-sequence_ :
~ `

##### A.1.5 Strings and Characters

_escape-char_ : '\' ["\'ntbr]

_non-escape-chars_ : '\' [^"\'ntbr]

_simple-char-char_ : any char except
'\n' '\t' '\r' '\b' ' \ "

_unicodegraph-short_ : '\' 'u' _hexdigit hexdigit hexdigit hexdigit_

_unicodegraph-long_ : '\' 'U' _hexdigit hexdigit hexdigit hexdigit
hexdigit hexdigit hexdigit hexdigit_

_char-char_ :
_simple-char-char
escape-char
trigraph
unicodegraph-short_

_string-char_ :
_simple-string-char
escape-char
non-escape-chars
trigraph
unicodegraph-short
unicodegraph-long
newline_

_string-elem_ :
_string-char_
'\' _newline whitespace_ * _string-elem_

_char_ : ' _char-char_ '


_string_ : " _string-char_ * "

_verbatim-string-char_ :
_simple-string-char
non-escape-chars
newline_
\
""

_verbatim-string_ : @" _verbatim-string-char_ * "

_bytechar_ : ' _simple-or-escape-char_ 'B

_bytearray_ : " _string-char_ * "B

_verbatim-bytearray_ : @" _verbatim-string-char_ * "B

_simple-or-escape-char_ :
_escape-char
simple-char_

_simple-char_ : any char except
newline, return, tab, backspace,',\,"

_triple-quoted-string_ : """ _simple-or-escape-char_ * """

##### A.1.6 Numeric Literals

_digit_ : [0-9]

_hexdigit_ :
_digit_
[A-F]
[a-f]

_octaldigit_ : [0-7]

_bitdigit_ : [0-1]

_int_ : _digit_ +

_xint_ :
0 (x|X) _hexdigit_ +
0 (o|O) _octaldigit_ +
0 (b|B) _bitdigit_ +

_sbyte_ : ( _int_ | _xint_ ) 'y'

_byte_ : ( _int_ | _xint_ ) _'_ uy'

_int16_ : ( _int_ | _xint_ ) _'_ s'

_uint16_ : ( _int_ | _xint_ ) _'_ us'

_int32_ : ( _int_ | _xint_ ) _'_ l'

_uint32_ :
( _int_ | _xint_ ) _'_ ul'
( _int_ | _xint_ ) _'_ u'


_nativeint_ : ( _int_ | _xint_ ) _'_ n'

_unativeint_ : ( _int_ | _xint_ ) _'_ un'

_int64_ : ( _int_ | _xint_ ) _'_ L'

_uint64_ :
( _int_ | _xint_ ) _'_ UL'
( _int_ | _xint_ ) _'_ uL'

_ieee32_ :
_float_ [Ff]
_xint_ 'lf'

_ieee64_ :
_float
xint_ 'LF'

_bignum_ : _int_ ('Q' | _'_ R' | 'Z' | 'I' | 'N' | 'G')

_decimal_ : ( _float_ | _int_ ) [Mm]

_float_ :
_digit_ +. _digit_ *
_digit_ + (. _digit_ * )? (e|E) (+|-)? _digit_ +

_reserved-literal-formats_ :
( **xint** | **ieee32** | **ieee64** ) _ident-char_ +

##### A.1.7 Line Directives

_line-directive_ :
# _int_
# _int string_
# _int verbatim-string_
**#line** _int_
**#line** _int string_
**#line** _int verbatim-string_

##### A.1.8 Identifier Replacements

**__SOURCE_DIRECTORY__
__SOURCE_FILE__
__LINE__**

##### A.1.9 Operators

A.1.9.1 Operator Names
_ident-or-op_ :
_ident_
( _op-name_ )
(*)

_op-name_ :
_symbolic-op
range-op-name
active-pattern-op-name_


_range-op-name_ :
..
.. ..

a _ctive-pattern-op-name_ :
| _ident_ | ... | _ident_ |
| _ident_ | ... | _ident_ | _ |

A.1.9.2 Symbolic Operators
_first-op-char_ : one of
!%&*+-./<=>@^|~

_op-char_ :
_first-op-char_
?

_quote-op-left_ :
<@ <@@

_quote-op-right_ :
@> @@>

_symbolic-op_ :
?
?<-
_first-op-char op-char_ *
_quote-op-left
quote-op-right_

A.1.9.3 Infix and Prefix Operators
The OP marker represents all _symbolic-op_ tokens that begin with the indicated prefix, except for
tokens that appear elsewhere in the table.

_infix-or-prefix-op_ : one of
+, -, +., -., %, &, &&

_prefix-op_ :
_infix-or-prefix-op_
~ ~~ ~~~ (and any repetitions of ~)
!OP (all tokens that begin with! except !=)

_infix-op_ :
_infix-or-prefix-op_

- OP +OP || <OP >OP = |OP &OP ^OP *OP /OP %OP !=
(or any of these preceded by one or more ‘.’)
:=
::
$
**or**
?

A.1.9.4 Constants
_const_ :
_sbyte
int16
int32
int64
byte_


_uint16
uint32
int
uint64
ieee32
ieee64
bignum
char
string
verbatim-string
triple-quoted-string
bytestring
verbatim-bytearray
bytechar_
**false
true**
()

### A.2 Syntactic Grammar

In general, this syntax summary describes full syntax. By default, however, .fs, .fsi, .fsx, and
.fsscript files support lightweight syntax, in which indentation replaces **begin** / **end** and **done**
tokens. This appendix uses **begin** opt, **endopt,** and **done** opt to indicate that these tokens are omitted in
lightweight syntax. Complete rules for lightweight syntax appear in §15.1.

To disable lightweight syntax:

```
#indent "off"
```
When lightweight syntax is disabled, whitespace can include tab characters:

_whitespace_ : [ ' ' '\t' ]+

**A.2.1 Program Format**
_implementation-file :
namespace-decl-group_ ... _namespace-decl-group
named-module
anonynmous-module_

_script-file_ : _implementation-file_

_signature-file_ :
_namespace-decl-group-signature_ ... _namespace-decl-group-signature
anonynmous-module-signature
named-module-signature_

_named-module_ : **module** _long-ident module-elems_

_anonymous-module_ : _module-elems_

_named-module-signature_ : **module** _long-ident module-signature-elements_

_anonymous-module-signature_ : _module-signature-elements_

_script-fragment_ : _module-elems_


A.2.1.1 Namespaces and Modules
_namespace-decl-group_ :
**namespace** _long-ident module-elems_
**namespace global** _module-elems_

_module-defn_ : _attributesopt_ **module** _accessopt ident_ = **beginopt** _module-defn-body_ **endop**

_module-defn-body_ : **begin** _module-elemsopt_ **end**

_module-elem_ :
_module-function-or-value-defn
type-defns
exception-defn
module-defn
module-abbrev
import-decl
compiler-directive-decl_

_module-function-or-value-defn_ :
_attributesopt_ **let** _function-defn
attributesopt_ **let** _value-defn
attributesopt_ **let rec** _opt function-or-value-defns
attributesopt_ **do** _expr_

_import-decl_ : **open** _long-ident_

_module-abbrev_ : _module ident_ = _long-ident_

_compiler-directive-decl_ : **#** _ident string_ ... _string_

_module-elems_ : _module-elem_ ... _module-elem_

_access_ :
**private
internal
public**

A.2.1.2 Namespace and Module Signatures
_namespace-decl-group-signature_ : **namespace** _long-ident module-signature-elements_

_module-signature_ : **module** _ident_ = **beginopt** _module-signature-body_ **endopt**

_module-signature-element_ :
**val mutable** _opt curried-sig_
**val** _value-defn_
**type** _type-signatures_
**exception** _exception-signature
module-signature
module-abbrev
import-decl_

_module-signature-elements_ :
**beginopt** _module-signature-element_ ... _module-signature-element_ **endopt**

_module-signature-body_ : **begin** _module-signature-elements_ **end**

_type-signature_ :
_abbrev-type-signature
record-type-signature
union-type-signature_


_anon-type-signature
class-type-signature
struct-type-signature
interface-type-signature
enum-type-signature
delegate-type-signature
type-extension-signature_

_type-signatures_ : _type-signature_ ... **and** ... _type-signature_

_type-signature-element_ :
_attributesopt_ **access** _opt_ **new** : _uncurried-sig
attributesopt_ **member access** _opt member-sig
attributesopt_ **abstract access** _opt member-sig
attributesopt_ **override** _member-sig
attributesopt_ **default** _member-sig
attributesopt_ **static member access** _opt member-sig_
**interface** _type_

_abbrev-type-signature_ : _type-name_ '=' _type_

_union-type-signature_ : _type-name_ '=' _union-type-cases type-extension-elements-signatureopt_

_record-type-signature_ :
_type-name_ '=' '{' _record-fields_ '}' _type-extension-elements-signatureopt_

_anon-type-signature_ : _type-name_ '=' **begin** _type-elements-signature_ **end**

_class-type-signature_ : _type-name_ '=' **class** _type-elements-signature_ **end**

_struct-type-signature_ : _type-name_ '=' **struct** _type-elements-signature_ **end**

_interface-type-signature_ : _type-name_ '=' **interface** _type-elements-signature_ **end**

_enum-type-signature_ : _type-name '_ =' _enum-type-cases_

_delegate-type-signature_ : _type-name '_ =' _delegate-sig_

_type-extension-signature_ : _type-name type-extension-elements-signature_

_type-extension-elements-signature_ : **with** _type-elements-signature_ **end**

##### A.2.2 Types and Type Constraints

_type_ :
( _type_ )
_type_ - > _type
type_ * ... * _type
typar
long-ident
long-ident_ < _type-args_ >
_long-ident_ < >
_type long-ident
type_ [ , ... , ]
_type typar-defns
typar_ :> _type_
# _type_

_type-args := type-arg, ..., type-arg_


_type-arg :=
type
measure
static-parameter_

_atomic-type_ :
_type_ : one of
_#type typar_ ( _type_ ) _long-ident long-ident_ < _types_ >)

_typar_ :
___
' _ident_
^ _ident_

_constraint_ :
_typar_ :> _type
typar_ : **null**
_static-typars_ : ( _member-sig_ )
_typar_ : ( **new** : **unit** - > 'T)
_typar_ : **struct**
_typar_ : **not struct**
_typar_ : **enum** < _type_ >
_typar_ : **unmanaged**
_typar_ : **delegate** < _type, type_ >

_typar-defn : attributes_ opt _typar_

_typar-defns_ : < _typar-defn, ..., typar-defn typar-constraints_ opt >

_typar-constraints_ : **when** _constraint_ **and** ... **and** _constraint_

_static-typars :_
^ _ident_
(^ _ident_ **or** ... **or** ^ _ident_ )

A.2.2.1 Equality and Comparison Constraints

_typar_ : **equality**
_typar_ : **comparison**

A.2.2.2 Type Providers

_static-parameter =
static-parameter-value
id = static-parameter-value_

_static-parameter-value =
const_
const _expr_

##### A.2.3 Expressions

_expr_ :
_const_
( _expr_ )


**begin** _expr_ **end**
_long-ident-or-op
expr_ '.' _long-ident-or-op
expr expr
expr_ ( _expr_ )
_expr_ < _types_ >
_expr infix-op expr
prefix-op expr
expr_ .[ _expr_ ]
_expr_ .[ _slice-ranges_ ]
_expr_ <- _expr
expr_ , ... , _expr_
**new** _type expr_
{ **new** _base-call object-members interface-impls_ }
{ _field-initializers_ }
{ _expr_ **with** _field-initializers_ }
[ _expr_ ; ... ; _expr_ ]
[| _expr_ ; ... ; _expr_ |]
_expr_ { _comp-or-range-expr_ }
[ _comp-or-range-expr_ ]
[| _comp-or-range-expr_ |]
**lazy** _expr_
**null**
_expr_ : _type
expr_ :> _type
expr_ :? _type
expr_ :?> _type_
**upcast** _expr_
**downcast** _expr_

In the following four expression forms, the in token is optional if _expr_ appears on a subsequent line
and is aligned with the _let_ token.

let _function-defn_ in _expr_
**let** _value-defn_ in _expr_
**let rec** _function-or-value-defns_ **in** _expr_
**use** _ident_ = _expr_ **in** _expr_

**fun** _argument-pats_ - > _expr_
**function** _rules_
**match** _expr_ **with** _rules_
**try** _expr_ **with** _rules_
**try** _expr_ **finally** _expr_
**if** _expr_ **then** _expr elif-branchesopt else-branch_ opt
**while** _expr_ **do** _expr_ doneopt
**for** _ident_ = _expr_ **to** _expr_ **do** _expr_ doneopt
**for** _pat_ **in** _expr_ - _or-range-expr_ **do** _expr_ doneopt
**assert** _expr_
<@ _expr_ @>
<@@ _expr_ @@>
% _expr_
%% _expr_
( _static-typars_ : ( _member-sig_ ) _expr)
expr_ $app _expr_ // equivalent to " _expr_ ( _expr_ )"
_expr_ $sep _expr_ // equivalent to " _expr_ ; _expr_ "
_expr_ $tyapp < _types >_ // equivalent to " _expr_ < _types_ >"

_expr_ < >

_exprs_ : _expr_ ',' ... ',' _expr_


_expr-or-range-expr_ :
_expr
range-expr_

_elif-branches_ : _elif-branch_ ... _elif-branch_

_elif-branch_ : **elif** _expr_ **then** _expr_

_else-branch_ : **else** _expr_

_function-or-value-defn :
function-defn
value-defn_

_function-defn_ :
**inline** **_opt_** _accessopt ident-or-op typar-defnsopt argument-pats return-typeopt_ = _expr
value-defn_ :
**mutable** **_opt_** _accessopt pat typar-defnsopt return-typeopt_ = _expr_

_return-type_ :
**:** _type_

_function-or-value-defns_ :
_function-or-value-defn_ **and** ... **and** _function-or-value-defn_

_argument-pats_ : _atomic-pat_ ... _atomic-pat_

_field-initializer_ : _long-ident_ = _expr_

_field- initializer s_ : _field-
initializer_ ; ... ; _field-initializer_

_object-construction_ :
_type expr
type_

_base-call_ :
_object-construction
object-construction_ **as** _ident_

_interface-impls_ : _interface-impl_ ... _interface-impl_

_interface-impl_ : **interface** _type object-membersopt_

_object-members_ : **with** _member-defns_ **end**

_member-defns_ : _member-defn_ ... _member-defn_

A.2.3.1 Computation and Range Expressions

_comp-or-range-expr_ :
_comp-expr
short-comp-expr
range-expr_


_comp-expr_ :
**let!** _pat_ = _expr_ **in** _comp-expr_
**let** _pat_ = _expr_ **in** _comp-expr_
**do!** _expr_ **in** _comp-expr_
**do** _expr_ **in** _comp-expr_
**use!** _pat_ = expr **in** _comp-expr_
**use** _pat_ = expr **in** _comp-expr_
**yield!** _expr_
**yield** _expr_
**return!** _expr_
**return** _expr_
**if** _expr_ **then** _comp-expr_
**if** _expr_ **then** _comp-expr_ **else** _comp-expr_
**match** _expr_ **with** _comp-rules_
**try** _comp-expr_ **with** _comp-rules_
**try** _comp-expr_ **finally** _expr_
**while** _expr_ **do** _expr_ doneopt
**for** _ident_ = _expr_ **to** _expr_ **do** _comp-expr_ doneopt
**for** _pat_ **in** _expr_ - _or-range-expr_ **do** _comp-expr_ doneopt
_comp-expr_ ; _comp-expr
expr_

_comp-rule_ : _pat pattern-guardopt_ - > _comp_ - _expr_

_comp-rules_ : '|' _opt comp_ - _rule_ '|' ... '|' _comp_ - _rule_

_short-comp-expr_ : **for** _pat_ **in** _expr-or-range-expr_ - > _expr_

_range-expr_ :
_expr_ .. _expr
expr_ .. _expr_ .. _expr_

_slice-ranges_ : _slice-range_ , _..._ , _slice-range_

_slice-range_ :
_expr
expr_ ..
.. _expr
expr_ .. _expr
'*'_

A.2.3.2 Computation Expressions

_expr_ { **for** ... }
_expr_ { **let** ... }
_expr_ { **let!** ... }
_expr_ { **use** ... }
_expr_ { **while** ... }
_expr_ { **yield** ... }
_expr_ { **yield!** ... }
_expr_ { **try** ... }
_expr_ { **return** ... }
_expr_ { **return!** ... }

A.2.3.3 Sequence Expressions

seq { _comp-expr_ }
seq { _short-comp-expr_ }


A.2.3.4 Range Expressions

**seq** { _e1_ .. _e2_ }
**seq** { _e1_ .. _e2 .. e3_ }

A.2.3.5 Copy and Update Record Expression

{ _expr_ **with** _field-label 1_ = _expr 1_ ; ... ; _field-labeln_ = _exprn_ }

A.2.3.6 Dynamic Operator Expressions

_expr_? _ident_ → (?) _expr_ " _ident_ "
_expr1_? ( _expr2_ ) → (?) _expr1 expr2
expr1_? _ident_ <- _expr2_ → (?<-) _expr1_ " _ident_ " _expr2
expr1_? ( _expr2_ ) <- _expr3_ → (?<-) _expr1 expr2 expr3_

" _ident_ " is a string literal that contains the text of _ident_.

A.2.3.7 AddressOf Operators

& _expr_
&& _expr_

A.2.3.8 Lookup Expressions

_e1_ .[ _eargs_ ] → _e1_ .get_Item( _eargs_ )
_e1_ .[ _eargs_ ] <- _e3_ → _e1_ .set_Item( _eargs_ , _e3_ )

A.2.3.9 Slice Expressions

_e1.[sliceArg1, ,,, sliceArgN] → e1.GetSlice( args1,...,argsN)
e1.[sliceArg1, ,,, sliceArgN] <- expr → e1.SetSlice( args1,...,argsN, expr)_

where each sliceArgN is a _slice-range_ and translated to argsN (giving one or two args) as follows:

```
* → None, None
e1.. → Some e1, None
..e2 → None, Some e2
e1..e2 → Some e1, Some e2
idx → idx
```
A.2.3.10 Shortcut Operator Expressions

_expr1_ && _expr2_ → if _expr1_ then _expr2_ else false
_expr1_ || _expr2_ → if _expr1_ then true else _expr2_

A.2.3.11 Deterministic Disposal Expressions

**use** _ident_ = _expr1_ **in** _expr2_

##### A.2.4 Patterns

_rule_ : _pat pattern-guardopt_ - > _expr_

_pattern-guard_ : **when** _expr_

_pat_ :


_const
long-ident pat-paramopt patopt_
_
_pat_ **as** _ident
pat_ '|' _pat
pat_ '&' _pat
pat_ :: _pat
pat_ : _type
pat_ ,..., _pat_
( _pat_ )
_list-pat
array-pat
record-pat_
:? _atomic-type_
:? _atomic-type_ **as** _ident_
**null**
_attributes pat_

_list-pat_ :
[ ]
[ _pat_ ; ... ; _pat_ ]

_array-pat_ :
[| |]
[| _pat_ ; ... ; _pat_ |]

_record-pat_ : { _field-pat_ ; ... ; _field-pat_ }

_atomic-pat :
pat_ one of
_const long-ident list-pat record-pat array-pat_ ( _pat_ )
:? _atomic-type_
**null** _ _

_field-pat_ : _long-ident_ = _pat_

_pat-param_ :
_const
long-ident_
[ _pat-param_ ; ... ; _pat-param_ ]
( _pat-param_ , ..., _pat-param_ )
_long-ident pat-param
pat-param_ : _type_
<@ _expr_ @>
<@@ _expr_ @@>
**null**

_pats_ : _pat_ , ... , _pat_

_field-pats_ : _field-pat_ ; ... ; _field-pat_

_rules_ : '|' _opt rule_ '|' ... '|' _rule_

##### A.2.5 Type Definitions

_type-defn_ :
_abbrev-type-defn
record-type-defn_


_union-type-defn
anon-type-defn
class-type-defn
struct-type-defn
interface-type-defn
enum-type-defn
delegate-type-defn
type-extension_

_type-name_ : _attributesopt accessopt ident typar-defns_ opt

_abbrev-type-defn_ : _type-name_ = _type_

_union-type-defn_ : _type-name_ '=' _union-type-cases type-extension-elementsopt_

_union-type-cases_ : '|' _opt union-type-case_ '|' ... '|' _union-type-case_

_union-type-case_ : _attributesopt union-type-case-data_

_union-type-case-data_ :
_ident_ -- nullary union case
_ident_ **of** _union-type-field_ * ... * _union-type-field_ -- n-ary union case
_ident_ : _uncurried-sig_ -- n-ary union case

_union-type-field_ :
_type --_ unnamed union type field
_ident_ : _type --_ named union type field

_anon-type-defn_ :
_type-name primary-constr-argsopt object-valopt_ '=' **begin** _class-type-body_ **end**

_record-type-defn_ : _type-name =_ '{' _record-fields_ '}' _type-extension-elementsopt_

_record-fields_ : _record-field_ ; ... ; _record-field_ ; _opt_

_record-field_ : _attributesopt_ **mutable** _opt accessopt ident_ : _type_

_class-type-defn_ :
_type-name primary-constr-argsopt object-valopt_ '=' **class** _class-type-body_ **end**

_as-defn_ : **as** _ident_

_class-type-body_ :
**beginopt** _class-inherits-declopt class-function-or-value-defnsopt type-defn-elementsopt_ **endopt**

_class-inherits-decl_ : **inherit** _type expropt_

_class-function-or-value-defn_ :
_attributesopt_ **static** _opt_ **let rec** _opt function-or-value-defns
attributesopt_ **static** _opt_ **do** _expr_

_struct-type-defn_ :
_type-name primary-constr-argsopt as-defnopt_ '=' **struct** _struct-type-body_ **end**

_struct-type-body_ : _type-defn-elements_

_interface-type-defn_ : _type-name_ '=' **interface** _interface-type-body_ **end**

_interface-type-body_ : _type-defn-elements_


_exception-defn_ :
_attributesopt_ **exception** _union-type-case-data
attributesopt_ **exception** _ident_ = _long-ident_

_enum-type-defn_ : _type-name '_ =' _enum-type-cases_

_enum-type-cases_ : '|' _opt enum-type-case_ '|' ... '|' _enum-type-case_

_enum-type-case_ : _ident_ '=' _const_

_delegate-type-defn_ : _type-name '_ =' _delegate-sig_

_delegate-sig_ : delegate **of** _uncurried-sig_

_type-extension_ : _type-name type-extension-elements_

_type-extension-elements_ : **with** _type-defn-elements_ **end**

_type-defn-element_ :
_member-defn
interface-impl
interface-signature_

_type-defn-elements : type-defn-element ... type-defn-element_

_primary-constr-args_ : _attributesopt accessopt_ ( _simple-pat, ... , simplepat_ )

_simple-pat_ :
| _ident_
| _simple-pat_ : _type_

_additional-constr-defn_ :
_attributesopt accessopt_ **new** _pat as-defn_ = _additional-constr-expr_

_additional-constr-expr_ :
_stmt_ ';' _additional-constr-expr
additional-constr-expr_ **then** _expr_
**if** _expr_ **then** _additional-constr-expr_ **else** _additional-constr-expr_
**let** val-decls **in** _additional-constr-expr
additional-constr-init-expr_

_additional-constr-init-expr_ :
'{' _class-inherits-decl field-initializers_ '}'
**new** _type expr_

_member-defn_ :
_attributesopt_ **static** _opt_ **member** _accessopt method-or-prop-defn
attributesopt_ **abstract member** _opt accessopt member-sig
attributesopt_ **override** _accessopt method-or-prop-defn
attributesopt_ **default** _accessopt method-or-prop-defn
attributesopt_ **static** _opt_ **val mutable** _opt accessopt ident : type
additional-constr-defn_

_method-or-prop-defn_ :
_identopt function-defn
identopt value-defn
identopt ident_ **with** _function-or-value-defns_
**member** _ident_ = _exp_


**member** _ident_ = _exp_ **with get
member** _ident_ = _exp_ **with set
member** _ident_ = _exp_ **with get,set
member** _ident_ = _exp_ **with set,get**

_member-sig_ :
_ident typar-defnsopt_ : _curried-sig
ident typar-defnsopt_ : _curried-sig_ **with get**
_ident typar-defnsopt_ : _curried-sig_ **with set**
_ident typar-defnsopt_ : _curried-sig_ **with get,set**
_ident typar-defnsopt_ : _curried-sig_ **with set,get**

_curried-sig_ : _args-spec_ - > _..._ - > _args-spec_ - > _type_

_uncurried-sig_ : _args-spec_ - > _type_

_args-spec_ : _arg-spec * ... * arg-spec_

_arg-spec_ : _attributesopt arg-name-specopt type_

_arg-name-spec_ :? _opt ident_ :

_interface-spec_ : **interface** _type_

A.2.5.1 Property Members

static _opt_ **member** _ident_. _opt ident_ = _expr_
static _opt_ **member** _ident_. _opt ident_ **with get** _pat_ = _expr_
static _opt_ **member** _ident_. _opt ident_ **with set** _patopt pat_ = _expr_
static _opt_ **member** _ident_. _opt ident_ **with get** _pat_ = _expr_ **and set** _patopt pat_ = _expr_
static _opt_ **member** _ident_. _opt ident_ **with set** _patopt pat_ = _expr_ **and get** _pat_ = _expr_

A.2.5.2 Method Members

**static** _opt_ **member** _ident_. _opt ident pat1_ ... _patn_ = _expr_

A.2.5.3 Abstract Members

**abstract** _accessopt member-sig_

_member-sig_ :
_ident typar-defnsopt : curried-sig
ident typar-defnsopt : curried-sig_ **with get**
_ident typar-defnsopt : curried-sig_ **with set**
_ident typar-defnsopt : curried-sig_ **with get, set**
_ident typar-defnsopt : curried-sig_ **with set, get**

_curried-sig : args-spec 1_ - > _..._ - > _args-specn - > type_

A.2.5.4 Implementation Members

**override** _ident_. _ident pat1_ ... _patn_ = _expr_
**default** _ident_. _ident pat1_ ... _patn_ = _expr_

##### A.2.6 Units Of Measure

_measure-literal-atom_ :
_long-ident_
( _measure-literal-simp_ )


_measure-literal-power_ :
_measure-literal-atom
measure-literal-atom_ ^ _int32_

_measure-literal-seq_ :
_measure-literal-power
measure-literal-power measure-literal-seq_

_measure-literal-simp_ :
_measure-literal-seq
measure-literal-simp_ * _measure-literal-simp
measure-literal-simp_ / _measure-literal-simp_
/ _measure-literal-simp_
1

_measure-literal :_
_
_measure-literal-simp_

_const_ :
...
_sbyte_ < _measure-literal_ >
_int16_ < _measure-literal_ >
_int32_ < _measure-literal_ >
_int64_ < _measure-literal_ >
_ieee32_ < _measure-literal_ >
_ieee64_ < _measure-literal_ >
_decimal_ < _measure-literal_ >

_measure-atom_ :
_typar
long-ident_
( _measure-simp_ )

_measure-power_ :
_measure-atom
measure-atom_ ^ _int32_

_measure-seq_ :
_measure-power
measure-power measure-seq_

_measure-simp_ :
_measure-seq
measure-simp_ * _measure-simp
measure-simp_ / _measure-simp_
/ _measure-simp_
1

_measure_ :
_
_measure-simp_

##### A.2.7 Custom Attributes and Reflection

_attribute_ : _attribute-target_ : _opt object-construction_

_attribute-set_ : [< _attribute_ ; ... ; _attribute_ >]


_attributes_ : _attribute-set_ ... _attribute-set_

_attribute-target_ :
**assembly
module
return
field
property
param
type
constructor
event**

##### A.2.8 Compiler Directives

Compiler directives in non-nested modules or namespace declaration groups:

# _id string_ ... _string_

### A.3 ML Compatibility Features

##### A.3.1 Conditional Compilation

_start-fsharp-token_ :
"(*IF-FSHARP"
"(*F#"
_end-fsharp-token_ :
"ENDIF-FSHARP*)"
"F#*)"
_start-ml-token_ : "(*IF-OCAML*)"
_end-ml-token_ : "(*ENDIF-OCAML*)"

##### A.3.2 Extra Syntactic Forms

_ocaml-ident-keyword_ : one of
**asr land lor lsl lsr lxor mod**

_expr_ :
...
_expr_ .( _expr_ ) // array lookup
_expr_ .( _expr_ ) <- _expr_ // array assignment

_type_ :
...
( _type_ ,..., _type_ ) _long-ident_ // generic type instantiation

_module-implementation_ :
...
**module** _ident_ = **struct** ... **end**

_module-signature_ :
...
**module** _ident_ : **sig** ... **end**


##### A.3.3 Extra Operators

```
e 1 or e 2 → (or) e 1 e 2
e 1 & e 2 → (&) e 1 e 2
```

## REFERENCES

Ecma International. _Standard ECMA- 335 ,_ Common Language Infrastructure (CLI)
[http://www.ecma-international.org/publications/standards/Ecma-335.htm](http://www.ecma-international.org/publications/standards/Ecma-335.htm)

The French National Institute for Research in Computer Science and Control (INRIA). _The Caml
Language_.
[http://caml.inria.fr/](http://caml.inria.fr/)

Microsoft Corporation. _The C# Language Specification_
[http://msdn.microsoft.com/library/ms228593.aspx](http://msdn.microsoft.com/library/ms228593.aspx)


## GLOSSARY

This section contains terminology that is specific to F#. It provides a reference for terms that are
used elsewhere in this document.

### A

```
abstract member
A member in a type that represents a promise that an object will provide an implementation for
a dispatch slot.
accessibility
The program text that has access to a particular declaration element or member. You can specify
accessibilities on declaration elements in namespace declaration groups and modules, and on
members in types. F# supports public , private , and internal accessibility.
and pattern
A pattern that consists of two patterns joined by an ampersand (&). An and pattern matches the
input against both patterns and binds any variables that appear in either pattern.
anonymous implementation file
A file that lacks either a leading module or namespace declaration. Only the scripts and the last file
within an implementation group for an executable image can be anonymous. An anonymous
implementation file can contain module definitions that are implicitly placed in a module, the
name of which is implicit from the name of the source file that contains the module.
anonymous variable type with a subtype constraint
A type in the form #type. This is equivalent to 'a when 'a :> type where 'a is a fresh type
inference variable.
anonymous signature file
A signature file that does not have either a leading module or namespace declaration. The name of
the implied module signature is derived from the file name of the signature file.
anonymous variable type
A type in the form _.
application expression
An expression that involves variable names, dot-notation lookups, function applications, method
applications, type applications, and item lookups
assignment expression
An expression in the form expr 1 <- expr 2.
arity
The number of arguments to a method or function.
array expression
An expression in the form [| expr 1 ;...; expr n |].
array pattern
The pattern [| pat ; ... ; pat |] , which matches arrays of a specified length.
```

```
array sequence expression
An expression that describes a series of elements in an array, in one of the following forms:
[| comp-expr |]
[| short-comp-expr |]
[| range-expr |]
```
```
as pattern
A pattern in the form pat as ident. The as pattern binds the name ident to the input value and
matches the input against the pattern.
automatic generalization
A technique that, during type inference, automatically makes code generic when possible, which
means that the code can be used on many types of data.
```
### B

```
base type declarations
A declaration that represents an additional, encapsulated type that is supported by any values
that are formed by using the type definition.
block comments
Comments that are delimited by (* and *), can span more than one line, and can be nested.
block expression
An expression in the form begin expr end.
```
### C

```
class type definition
The definition of a type that encapsulates values that are themselves constructed by using one
or more object constructors. A class type typically describes an object that can have properties,
methods, and events.
coercion
The changing of data from one type to another.
comparison constraint
A constraint of the form typar : comparison.
compiled name
The name that appears in the compiled form of an F# program for a symbolic operator or certain
symbolic keywords.
conditional expression
An expression in the following form
if expr 1a then expr 1b
elif expr 3a then expr 2b
...
elif expr na then expr nb
else expr last
```
```
The elif and else branches are optional.
```

```
cons pattern
The pattern pat :: pat, which is used to decompose a list into two parts: the head, which
consists of the first element, and the tail, which contains the remaining elements.
constraint
See type constraint.
constraint solving
The process of reducing constraints to a normalized form so that variables can be solved by
deducing equations.
copy-and-update record expression
An expression in the following form:
{ expr with field-label 1 = expr 1 ; ... ; field-label n = expr n }
```
```
current inference constraints
The set of type constraints that are in effect at a particular point in the program as a result of
type checking and elaboration.
curried method members
Arguments to a method that are written in an interated form.
custom attribute
A class that encapsulates information, often metadata that describes or supplements an F#
declaration. Custom attributes derive from System.Attribute in the .NET framework and can be
used in any language that targets the common language runtime.
```
### D

```
default constructor constraint
A constraint of the form typar : (new : unit -> 'T).
default initialization
The practice of setting the values of particular types to zero at the beginning of execution. Unlike
many programming languages, F# performs default initialization in only limited circumstances.
definitely equivalent types
Static types that match exactly in definition, form, and number; or variable types that refer to
the same declaration or are the same type inference variable.
delayed expression
An expression in the form lazy expr, which is evaluated on demand in response to a .Value
operation on the lazy value.
delegate constraint.
A constraint of the form typar : delegate<tupled-arg-type, return-type >.
dispatch slot
A key representing part of the contract of an interface or class type. Each object that implements
the type provides a dictionary mapping dispatch slots to member implementations.
dynamic type test pattern
The patterns :? type and :? type as ident , which match any value whose runtime type is the
given type or a subtype of the given type.
```

### E

```
elaborated expression
An expression that the F# compiler generates in a simpler, reduced language. An elaborated
expression contains a fully resolved and annotated form of the source expression and carries
more explicit information than the source expression.
enumerable extraction
The process of getting sequential values of a static type by using CLI library functions that
retrieve individual, enumerable values.
enumeration constraint
A constraint in the form typar : enum< underlying-type >, which limits the type to an
enumeration of the specified underlying type.
equality constraint.
A constraint in the form typar : equality, which limits the type to one that supports equality
operations.
event
A configurable object that has a set of callbacks that can be triggered, often by some external
action such as a mouse click or timer tick. The F# library supports the
FSharp.Control.IEvent<_,_> type and the FSharp.Control.Event module to support the use of
events.
```
### F

```
F# Interactive
An F# dynamic compiler that runs in a command window and executes script fragments as well
as complete programs.
feasible coercion
Indicates that one type either coerces to another, or could become coercible through the
addition of further constraints to the current inference constraints.
feasibly equivalent types
Types that are not definitely equivalent but could become so by the addition of further
constraints to the current inference constraints.
floating type variable environment
The set of types that are currently defined, for use during type inference.
fresh type
A static type that is formed from a fresh type inference variable.
fresh type inference variable
A variable that is created during type inference and has a unique identity.
function expression
An expression of the form fun pat 1 ... patn - > expr.
function value
The value that results at runtime from the evaluation of function expressions.
```

### G

```
generic type definition
A type definition that has one or more generic type parameters. For example:
System.Collections.Generic.Dictionary<'Key,'Value>.
guarded pattern matching rule
A rule of the form pat when expr that occurs as part of a pattern matching expression such as
match expr 0 with rule 1 - > expr 1 | ... | rulen - > exprn. The guard expression expr is executed
only if the value of expr 0 successfully matches the pattern pat.
```
### I

```
identifier
A sequence of characters that is enclosed in `` `` double-backtick marks, excluding newlines,
tabs, and double-backtick pairs themselves.
immutable value
A named value that cannot be changed.
imperative programming
One of several primary programming paradigms; others include declarative, functional,
procedural, among others. An imperative program consists of a sequence of actions for the
computer to perform, and the statements change the state of the program.
implementation member
An abstract member that implements a dispatch slot or CLI property.
import declaration
A declaration that makes the elements of another namespace’s declarations and modules
accessible by the use of unqualified names. Import definitions can appear in namespace
declaration groups and module definitions.
inference type variable
A type variable that does not have a declaration site.
initialization constant expression
An expression whose elaborated form is determined to cause no observable initialization effect.
instance member
A member that is declared without static.
interface type definition
A declaration that represents an encapsulated type that specifies groups of related members
that other classes implement.
```
### K

```
keyword
A word that has a defined meaning in F# and is used as part of the language itself.
```

### L

```
lambda expression
See function expression.
lightweight syntax
A simplified, indentation-aware syntax in which lines of code that form a sequence of
declarations are aligned on the same column, and the in and ;; separators can be omitted.
Lightweight syntax is the default for all F# code in files with extension .fs, .fsx, .fsi and
.fsscript.
list
An F# data structure that consists of a sequence of items. Each item contains a pointer to the
next item in the sequence.
list expression
An expression of the form [ expr 1 ;...; exprn ].
list pattern
A data recognizer pattern that describes a list. Examples are pat :: pat , which matches the
'cons' case of F# list values; [], which matches the empty list; and [ pat ; ... ; pat ], which
represents a series of :: and empty list patterns.
list sequence expression
An expression that evaluates to a sequence that is essentially a list. List sequence expressions
can have the following forms:
[ comp-expr ]
[ short-comp-expr ]
[ range-expr ]
```
```
literal constant expression
An expression that consists of a simple constant expression or a simple compile-time
computation.
```
### M

```
member
A function that is associated with a type definition or with a value of a particular type. Member
definitions can be used in type definitions. F# supports property members and method
members.
member constraint
A constraint that specifies the signature that is required for a particular member function.
Member constraints have the form ( typar or ... or typar ) : ( member-sig ).
member signature
The “footprint” of a property or method that is visible outside the defining module.
method member
An operation that is associated with a type or an object.
module
A named collection of declarations such as values, types, and function values.
```

```
module abbreviation
A statement that defines a local name for a long identifier in a module. For example:
module Ops = FSharp.Core.Operators
```
```
module signature
A description of the contents of a module that the F# compiler generates during type inference.
The module signature describes the externally visible elements of the module.
```
### N

```
name resolution environment
The collection of names that have been defined at the current point, which F# can use in furthy
type inference and checking. The name resolution environment includes namespace declaration
groups from imported namespaces in addition to names that have been defined in the current
code.
named type
A type that has a name, in the form long-ident < ty 1 ,...,tyn >, where long-ident resolves to a a
type definition that has formal generic parameters and formal constraints.
namespace
A way of organizing the modules and types in an F# program, so that they form logical groups
that are associated with a name. Identifiers must be unique within a namespace.
namespace declaration group
The basic declaration unit within an F# implementation file. It contains a series of module and
type definitions that contribute to the indicated namespace. An implementation can contain
multiple namespace declaration groups.
namespace declaration group signature
The “footprint” of a namespace declaration group, which describes the externally visible
elements of the group.
null expression
An expression of the form null.
nullness constraint
A constraint in the form typar : null, which indicates that the type must support the Null literal.
null pattern
The pattern null, which matches the values that the CLI value null represents.
numeric literal
A sequence of Unicode characters or an unsigned byte array that represents a numeric value.
```
### O

```
object construction expression
An expression in the form new ty ( e1 ... en ), which constructs a new instance of a type, usually
by calling a constructor method on the type.
```

```
object constructor
A member of a class that can create a value of the type and partially initialize an object. The
primary constructor contains function and value definitions that appear at the start of the class
definition, and its parameters appear in parentheses immediately after the type name. Any
additional object constructors are specified with the new keyword, and they must call the
primary constructor.
object expression
An expression that creates a new instance of a dynamically created, anonymous object type that
is based on an existing base type, interface, or set of interfaces.
offside lines
Lines that occur at column positions in lightweight syntax. Offside lines are introduced by other
structured constructs, such asthe = token associated with let, and the first token after then in
an if/then/else construct.
offside rule
Another term for lightweight or indentation-aware syntax.
```
### P

```
parenthesized expression
An expression in the form ( expr ).
pattern matching
A switch construct that supports branched control flow and the definition of new values.
pipeline operator
The |> operator, which directs the value of one function to be input to the next function in a
pipeline.
property member
A function in a type that gets or sets data about the type.
```
### Q

```
quoted expression
An expression that is delimited in such a way that it is not compiled as part of your program, but
instead is compiled into an object that represents an F# expression.
```
### R

```
range expression
An expression that generates a sequence over a given range of values.
record construction expression
An expression that builds a record, in the form { field-initializer 1 ; ... ; field-initializern
}.
```

```
record pattern
The pattern { long-ident 1 = pat 1 ; ... ; long-identn = patn }.
recursive definition
A definition in which the bound functions and values can be used within their own definitions.
reference type constraint
A constraint of the form typar : not struct.
reference type
A class, interface delegate, function, tuple, record, or union type. A type is a reference type if its
outermost named type definition is a reference type, after expanding type definitions.
referenced assemblies
The existing assemblies to which an F# program makes static references.
rigid type variable
A type variable that refers to one or more explicit type parameter definitions.
runtime type
An object of type System.Type that is the runtime representation of some or all of the
information carried in type definitions and static types. The runtime type associated with an
objects is accessed by using the obj.GetType() method, which is available on all F# values.
```
### S

```
script
A fragment of an F# program that can be run in F# Interactive.
sealed type definition
A type definition that is concrete and cannot be extended. Record, union, function, tuple, struct,
delegate, enum, and array types are all sealed types, as are class types marked with the
SealedAttribute attribute.
sequence expression
An expression that evaluates to a sequence of values, in one of the following forms
seq { comp-expr }
seq { short-comp-expr }
```
```
sequential execution expression
An expression that represents the sequential execution of one statement followed by another.
The expression has the form expr 1 ; expr 2.
signature file
A file that contains information about the public signatures and accessibility of a set of F#
program elements.
simple constant expressions
A numeric, string, Boolean, or unit constant.
single-line comments
A comment that begins with // and extends to the end of a line.
slice expression
An expression that describes a subset of an array.
```

```
static type
The type that is inferred for an expression as the result of type checking, constraint solving, and
inference.
static member
A member that is prefixed by static and is associated with the type, rather than with any
particular object.
statically resolved type variable
A type parameter in the form ^ident. Such a parameter is replaced with an actual type at
compile time instead of runtime.
string
A type that represents immutable text as a sequence of Unicode characters.
string literal
A Unicode string or an unsigned byte array that is treated as a string.
strong name
A cryptographic signature for an assembly that provides a unique name, guarantees the
publisher over subsequent versions, and ensures the integrity of the contents.
subtype constraint
A constraint of the form typar :> type , which limits the type of typar to the specified type , or
to a type that is derived from that type. If type is an interface, typar must implement the
interface.
symbolic keyword
A symbolic or partially symbolic character sequence that is treated as a keyword.
structural type
A record, union, struct, or exception type definition.
symbolic operator
A user-defined or library-defined function that has one or more symbols as a name.
syntactic sugar
Syntax that makes code easier to read or express; often a shortcut way of expressing a more
complicated relationship for which one or more other syntactic options exist.
syntactic type
The form of a type specification that appears in program source code, such as the text
“option<_>”. Syntactic types are converted to static types during the process of type checking
and inference.
```
### T

```
tuple
An ordered collection of values that is treated as an atomic unit. A tuple allows you to keep data
organized by grouping related values together, without introducing a new type.
tuple expression
An expression in the form expr 1 , ..., expr n, which describes a tuple value.
```

```
tuple type
A type in the form ty 1 * ... * tyn , which defines a tuple. The elaborated form of a tuple type is
shorthand for a use of the family of F# library types System.Tuple<_,...,_>.
type abbreviation
An alias or alternative name for a type.
type annotation
An addition to an expression that specifies the type of the expression. A type annotation has the
form expr : type.
type constraint
A restriction on a generic type parameter or type variable that limits the types that may be used
to instantiate that parameter. Example type constraint include subtype constraints, null
constraints, value type constraints, comparison constraints and equality constraints.
type definition kind
A class, interface, delegate, struct, record, union, enum, measure, or abstract type.
The kind of type refers to the kind of its outermost named type definition, after expanding
abbreviations.
type extension
A definition that associates additional dot-notation members with an existing type.
type function
A value that has explicit generic parameters but arity []—that is, it has no explicit function
parameters.
type inference
A feature of F# that determines the type of a language construct when the type is not specified
in the source code.
type inference environment
The set of definitions and constraints that F# uses to infer the type of a value, variable, function,
or parameter, or similar language construct.
type parameter definition
In a generic function, method, or type, a placeholder for a specific type that is specified when
the generic function, method, or type is instantiated.
type provider
A component that provides new types and methods that are based on the schemas of external
information sources.
type variable
A variable that represents a type, rather than data.
```
### U

```
undentation
The opposite of indentation.
underlying type
The type of the constant values of an enumeration. The underlying type of an enum must be
sbyte, int16, int32, int64, byte, uint16, uint32, uint64, or char.
```

```
union pattern
The pattern pat | pat attempts to match the input value against the first pattern, and if that
fails matches instead the second pattern. Both patterns must bind the same set of variables with
the same types.
union type
A type that can hold a value that satisfies one of a number of named cases.
unit of measure
A construct similar to a type that represents a measure, such as kilogram or meters per second.
Like types, measures can appear as parameters to other types and values, can contain variables,
and are checked for consistency by the type-checker. Unlike types, however, measures are
erased at runtime, have special equivalence rules, and are supported by special syntax.
unmanaged type
The primitive types (sbyte, byte, char, nativeint, unativeint, float32, float, int16, uint16,
int32, uint32, int64, uint64, and decimal), enumeration types, and nativeptr<_>, or a non-
generic structure whose fields are all unmanaged types.
unmanaged constraint
An addition to a type parameter that limits the type to an unmanaged type.
```
### V

```
value signature
The “footprint” of a value in a module, which indicates that the value exists and is externally
visible.
value type
A type that is allocated on the stack or inline in an object or array. Value types include primitive
integers, floating-point numbers, and any value of a struct type.
value type constraint
A constraint of the form typar : struct, which limits the type of typar to a .NET value type.
variable type
A type of the form 'ident, which represents the name of another type.
```
### W

```
wildcard pattern
The underscore character _, which matches any input.
```

## INDEX

# flexible type symbol, 150
#indent, 317
#load directive, 224
#nowarn directive, 224
% operator, 116
%% operator, 116
& byref address-of operator, 98
& conjunctive patterns, 136
&& native pointer address-of operator, 98
&& operator, 105
.fs extension, 23, 224
.fsi extension, 23
.fsscript extension, 23, 224
.fsx extension, 23, 224
.ml extension, 317
.mli extension, 317
:: cons pattern, 136
; token, 104
_ wildcard pattern, 135
__LINE__, 33
__SOURCE_DIRECTORY__, 33
__SOURCE_FILE__, 33
|| operator, 105
= function, 193
abstract members, 183
abstract types, 53
AbstractClass attribute, 183
accessibilities
annotations for, 211
default annotation for modules, 208
location of modifiers, 212
active pattern functions, 133
active pattern results, 96
address-of expressions, 98
_AddressOf_ expressions, 120, 125
agents, 311
AllowIntoPattern, 81
AllowNullLiteral attribute, 57
anonymous variable type, 46
application expressions, 94, 244
arguments
CLI optional, 178
named, 175
optional, 176
required unnamed, 176
arity, 274
conformance in value signatures, 218

```
array expressions, 71, 122
array sequence expression, 92
array type, 46
assemblies
contents of, 221
referenced, 221
assert, 109
assertion expression, 109
assignment expression, 102
asynchronous computations, 311
attributes
AbstractClass, 183
AllowNullLiteral, 57
AttributeUsage, 231
AutoOpen, 221
AutoOpenAttribute, 305
CLIEvent, 181, 186
CLIMutable, 152
comparison, 190
CompilationRepresentation, 182, 206
conditional compilation, 255
ContextStatic, 110, 208
custom, 53, 231, 296
custom operation, 80
DefaultValue, 161
emitted by F# compiler, 301
EntryPoint, 229
equality, 189
GeneralizableValue, 209
grammar of, 231
in type definitions, 145
InternalsVisibleTo, 212
Literal, 208
mapping to CLI metadata, 232
Measure, 146, 196, 200
MeasureAnnotatedAbbreviation, 201
NoEquality, 51
OptionalArgument, 178
ReflectedDefinition, 115
RequireQualifiedAccess, 237
RequiresExplicitTypeArguments, 209
RequiresQualifiedAccess, 166
SealedAttribute, 54
ThreadStatic, 110, 208
unrecognized by F#, 302
VolatileField, 118
AttributeUsage attribute, 231
```

automatic generalization, 13
AutoOpen attribute, 221
AutoOpenAttribute, 305
AutoSerializable attribute, 151, 153, 155
base type, 55
basic types
abbreviations for, 305
block expressions, 104
bprintf function, 93
byref arguments, 273
byref pointers, 67
byref-address-of expression, 98
case names, 152
characters, 28
class types, 155
additional fields in, 161
members in, 159
class/end tokens, 155
classes, 53
CLI methods, 276
CLI pointer types, 306
CLIEvent attribute, 181, 186
CLIMutable, 152
comments, 25, 277
compare function, 193
CompareTo, 192
comparison attributes, 190
comparison constraint, 51
ComparisonConditionalOn constraint
dependency, 190
compatibility features, 315
compilation order, 222
CompilationRepresentation attribute, 182,
206
COMPILED compilation symbol, 23, 224
compiler directives, 225
computation expression, 76
condensation, 269
Conditional attribute, 255
conditional compilation, 26, 255
ML compatibility and, 315
conditional expressions, 104
constant expressions, 68
constants with measure annotations, 197
constrained types, 47
constraints, 47
comparison, 51
current inference, 45
default constructor, 49
delegate, 50
dependency of, 190

```
enumeration, 50
equality, 51
equational, 257
explicit declaration of, 52
flexible type, 113
inflexible type, 113
member, 259
member, 48
nullness, 48, 58, 93, 258
reference type, 50
simple, 258
solving, 257
struct, 49, 258
subtype, 47, 257
unmanaged, 51
ContextStatic attribute, 110, 208
control flow expressions, 104
copy-and-update record expression , 72
curried form, 175
custom attributes
effect on signature checking, 233
in type definitions, 145
CustomComparison attribute, 190
CustomEquality attribute, 189
CustomOperationAttribute, 80
declarations
base type, 54
interface, 54
default initialization, 58
DefaultValue attribute, 161
definition expressions, 109
definitions
recursive, 2 61
delayed expression, 76
delegate constraint, 50
delegate implementation expression, 96
delegate type, 166
delegates, 53
deterministic disposal expression, 112
directives
#load, 224
#nowarn, 224
compiler, 225
lexical, 225
line, 33
preprocessing, 26
dispatch slot checking, 75, 273
dispatch slot inference, 75, 271
dispatch slots, 273
do statements, 157
in modules, 210
```

static, 158
done token, 108
dynamic coercion expressions, 114, 124
dynamic type-test expressions, 113, 123
elif branch, 105
else branch, 105
entry points, 229
EntryPoint attribute, 229
enum types, 165
enumerable extraction, 106
enums, 53
equality attributes, 189
equality constraint, 51
EqualityConditionalOn constraint
dependency, 190
evaluation
of active pattern results, 96
of _AddressOf_ expressions, 125
of array expressions, 122
of definition expressions, 123
of dynamic coercion expressions, 124
of dynamic type-test expressions, 123
of field lookups, 121
of _for_ loops, 123
of function applications, 121
of function expressions, 122
of method applications, 121
of object expressions, 122
of record expressions, 122
of sequential execution expressions, 124
of _try-finally_ expressions, 125
of _try-with_ expressions, 125
of union cases, 121
of value references, 120
of _while_ loops, 123
event types, 311
events, 180
exception definitions, 166
exceptions, 302
execution of F# code, 226
expression splices, 116
expressions
address-of, 98
application, 94
array. _See_ array expression
array sequence, 92
assertion, 109
assignment, 102
block, 104
builder, 76
checking of, 65

```
computation, 65, 76
conditional, 104
constant, 68
delayed, 76
delegate implementation, 96
deterministic disposal, 112
dynamic coercion, 114
dynamic type-test, 113
elaborated, 66
evaluation of, 117
for loop, 107
function, 73
function and value definitions, 109
list, 70
list sequence, 92
lookup, 99
member constraint invocation, 101
name resolution in, 237
null, 93
object. See object expressions
object construction, 96
operator, 97, 98
parenthesized, 104
pattern-matching, 105
precedence in, 41
quoted, 67, 114
range, 65, 91
record construction, 71
recursive, 112
reraise, 108
sequence, 90
sequence iteration, 106
sequential conditional, 105
sequential execution, 104
shortcut and , 105
shortcut or , 105
slice, 100
static coercion, 113
syntactical elements of, 61
try-finally , 108
try-with , 108
tuple, 69
type-annotated, 113
while-loop, 107
extension members, 168
defined by C#, 169
field lookups, 121
fields
additional, in classes, 161
name resolution for labels, 243
filename extensions, 23
```

ML compatibility and, 317
files
implementation, 222
signature. _See_ signature files
flexibility, 255
flexible types, 150
floating type variable environment, 45
_for_ loop, 107
_for_ loops, 123
format strings, 93
fprintf function, 93
fresh type, 45
function applications, 121
function definition expressions, 109
function definitions, 157, 261, 263
ambiguous, 261
in modules, 207
static, 158
function expressions, 73, 122
function values, 14
functions
active pattern, 133
undentation of, 285
GeneralizableValue attribute, 209
generalization, 55, 267
generic types, 267
GetHashCode, 192
GetSlice, 100
guarded rules, 139
hash function, 193
hashing, 188
hidden tokens, 278
identifiers, 26
local names for, 211
long, 39
OCaml keywords as, 315
replacement of, 33
if statement, 104
if/then/else expression
undentation of body, 285
immutability, 13
immutable collection types, 311
implementation files
anonymous, 223
contents of, 222
implementation members, 183
import declarations, 210
in token, 109
indentation, 277
incremental, 285
indexer properties, 173

```
inference
arity, 274
dispatch slot, 271
inference variables, 55
infix operators, 41
Information-rich Programming, 19
inherit declaration, 156, 162
initialization, 58
of objects, 155
static, 226
instance members, 171
compilation as static method, 182
integer literals, 69
INTERACTIVE compilation symbol, 23, 224
interface type definitions, 162
interface types, 56, 186
interface/end tokens, 162
interfaces, 53
internal accessibility, 211
internal type abbreviations, 150
InternalsVisibleTo attribute, 212
intrinsic extensions, 168
IsLikeGroupJoin, 81
IsLikeJoin, 81
JoinConditionWord, 81
keywords
OCaml, 315
symbolic, 30
kind
anonymous, 148
kind of type definition, 53
lazy computations, 311
libraries
CLI base, 305
F# base, 305
lightweight syntax, 11, 277
balancing rules for, 282
disabling, 317
parsing, 280
rules for, 277
line directives, 33
list expression, 70
list sequence expression, 92
list type, 310
Literal attribute, 208
literals
integer, 69
numeric, 31
string, 28
lookup
expression-qualified, 247
```

item-qualified, 245
unqualified, 244
lookup expressions, 99
mailbox processor, 311
MaintainsVariableSpace, 80
MaintainsVariableSpaceUsingBind, 81
measure annotated base types, 201
Measure attribute, 17, 196, 200
measure parameters, 146
defining, 200
erasing of, 200
MeasureAnnotatedAbbreviation attribute,
201
measures, 53
basic types and annotations for, 306
building blocks of, 197
constraints on, 199
defined, 195
defining, 199
generalization of, 199
relations on, 198
type definitions with, 201
member constraint invocation expressions,
101
member definitions, 261
member signatures, 217
members, 170
extension, 168
intrinsic, 168
name resolution for, 241
naming restrictions for, 180
processing of definitions, 261
signature conformance for, 220
method applications, 121
method calls
conditional compilation of, 255
method members, 170, 174
curried, 175
named arguments to, 175
optional arguments to, 176
methods
overloading of, 180
overriding, 75
Microsoft.FSharp.Collections.list, 310
Microsoft.FSharp.Core, 305
Microsoft.FSharp.Core.NativeIntrop, 312
Microsoft.FSharp.Core.Operators, 306
Microsoft.FSharp.Core.option, 311
mlcompatibility option, 315
module declaration, 222
modules

```
abbreviations for, 211
active pattern definitions in, 210
defining, 206
do statements in, 210
function definitions in, 207
name resolution in, 236
signature of, 206
undentation of, 286
value definitions in, 207
mscorlib.dll, 305
mutable, 150, 157
mutable value definitions, 262
mutable values, 103
name environment, 235
adding items to, 236
name resolution, 45, 46, 235
namespace declaration, 223
namespace declaration groups, 204
namespaces, 204
grammar of, 203
name resolution in, 236
opened for F# code, 305
native pointer operations, 312
nativeptr type, 306
nativeptr-address-of expression, 98
NoComparison attribute, 190
NoEquality attribute, 189
null, 57
null expression, 93
NullReferenceException, 121
numeric literals, 31
object construction expression, 96
object constructors, 155
additional, 159
primary, 155
object expressions, 74, 122
Object.Equals, 191
objects
initialization of, 155
physical identity of, 126
references to, 126
offside contexts, 280
offside limit, 283
offside lines, 279
offside rule, 279
exceptions to, 283
operations
underspecified results of, 126
operator expressions, 97
operators
address-of, 98
```

basic arithmetic, 306
bitwise, 307
checked arithmetic, 310
default definition of, 97
exception, 309
function pipelining and composition, 308
generic equality and comparison, 307
infix, 41
input and output handles, 309
math, 307
ML compatibility and, 317
names of, 35
object transformation, 308
overloaded conversion functions, 309
pair, 309
precedence of, 41
prefix, 41
splicing, 116
symbolic, 30, 40
option type, 311
OptionalArgument attribute, 178
overflow checking, 310
parallel execution, 118
ParamArray conversion, 251
parenthesized expressions, 104
pattern matching, 14
pattern-matching expression, 105
pattern-matching function, 106
patterns, 129
active, 133
array, 138
_as_ , 135
conjunctive, 136
_cons_ , 136
dynamic type-test, 137
guarded rules for, 139
literal, 132
name resolution for, 241
named, 131
null, 139
record, 138
simple constant, 130
type-annotated, 136
union case, 131
variable, 131
wildcard, 135
pointer, byref, 67
precedence
differences from OCaml, 316
of function applications, 286
of type applications, 287

```
prefix operators, 41
preprocessing directives, 26
printf, 312
printf function, 93
private accessibility, 211
private type abbreviations, 150
ProjectionParameterAttribute, 81
properties
custom operation, 80
property members, 170, 172, 183
public accessibility, 208, 211
quotations, 312
quoted expression, 114
quoted expressions, 67
range expressions, 91
rec, 157
record construction expression, 71
record expressions
evaluation of, 122
record expressionss
copy-and-update, 72
record types
automatically implemented interfaces in,
151
members in, 151
scope of field labels, 151
record types, 150
records, 53
recursive definitions, 261, 263
recursive function definition, 112
recursive safety analysis, 264
recursive value definition, 112
reference types
zero value of, 119
ReferenceEquality attribute, 189
reflected forms, 233
ReflectedDefinition attribute, 115
reflection, 312
RequireQualifiedAccess attribute, 236
RequiresExplicitTypeArguments attribute, 209
RequiresQualifiedAccess attribute, 166
reraise expressions, 108
resolution
function application, 248
method application, 249
script files, 224
Sealed attribute, 151
SealedAttribute attribute, 54
sequence expression, 90
sequence iteration expression, 106
sequential conditional expressions, 105
```

sequential execution expressions, 104, 124
shortcut _and_ expression, 105
shortcut _or_ expression, 105
signature elements, 217
signature files, 215
anonymous, 224
compilation order of, 222
contents of, 223
signatures
conformance of, 218
declarations of, 216
member, 217
module, 206
of namespace declaration groups, 205
type definition, 217
value, 217
slice expressions, 100
source code files, 23
sprintf function, 93
stack allocation, 312
static coercion expressions, 113
static initializer
execution of, 226
static initializers, 158
static members, 170
static types, 44
strings, 28
format, 93
newlines in, 29
triple-quoted, 29
strongly typed quoted expressions, 115
struct types
default constructor in, 164
struct/end tokens, 163
structs, 53
structural equality, 188
structural types, 189
StructuralComparison attribute, 190
StructuralEquality attribute, 189
symbolic operators, 30, 40
syntactic types, 44
System.Object, 75
System.Reflection objects, 233
System.Tuple, 69
System.Type objects, 233
text formatting, 312
ThreadStatic attribute, 110, 208
tokens
hidden, 33, 278
_try-finally_ expressions, 108
evaluation of, 125

```
try-with expressions, 108, 125
tuple type, 46
type
fresh, 45
meanings of, 43
named, 45
statically resolved variable, 46
type abbreviations, 53, 149
type annotations
over-constrained, 260
type applications
lexical analysis of, 287
type definition group, 145
type definition signatures, 217
type definitions, 43, 53
abstract members in, 183
checking of, 146
delegate, 166
enum, 165
exception, 166
generic, 53
grammar of, 141
interface, 162
interfaces in, 186
kinds of, 144
location of, 144
reference, 54
sealed, 54
struct, 163
type extensions, 167
type functions, 207
signature conformance for, 220
type inference, 13, 45
type inference environment, 45
type kind inference, 148
type parameter definitions, 52
type providers, 19
type variable
definition site, 55
type variables, 43
name resolution for, 243
rigid, 55
type-annotated expressions, 113
type-annotated patterns, 136
typedefof operator, 233
type-directed conversions, 178
typeof operator, 233
types
anonymous variable. See anonymous
variable type
array. See array type
```

base, 55
class, 53, 155
coercion of, 56
comparison of, 188
condensation of generalized function types,
269
constrained, 47
conversion of, 178
delegate, 96, 166
dynamic conversion of, 58
enum, 165
equivalence of, 56
exn (exception), 166
flexible, 150
implicit static members of, 259
initial, 66
interface types of. _See_ interface types
logical properties of, 53
name resolution for, 242
nativeptr, 306
partial static, 55
record, 150
reference, 54
renaming, 149
runtime, 43
static, 43
structural, 189
syntactic, 43
tuple. _See_ tuple type
union, 152
unit, 107
unmanaged, 51
value, 54
variable, 45
zero value of, 119
undentation, 283, 285

```
union cases, 121
union types, 152
automatically implemented interfaces for,
153
compiled, 154
members in, 153
unions, 53
unit type, 57, 107
units of measure. See measures
unmanaged constraint, 51
val specification, 161
value definition expressions, 109
value definitions, 157, 261
in modules, 207
static, 158
value references, 120
value signatures, 217
value types
zero value of, 119
values
arity conformance for, 218
processing of definitions, 262
runtime, 117
signature conformance for, 218
verbatim strings, 29
virtual methods, 184
VolatileField attribute, 118
weakly typed quoted expression, 116
while loops, 123
while-loop expression, 107
whitespace, 25
significance in lightweight syntax, 277
with/end tokens, 151, 153
XML documentation tokens, 25
zero value, 119
```

