# 5. TYPES AND TYPE CONSTRAINTS

The notion of _type_ is central to both the static checking of F# programs and to dynamic type tests
and reflection at runtime. The word is used with four distinct but related meanings:

- **Type definitions,** such as the actual CLI or F# definitions of `System.String` or
  `FSharp.Collections.Map<_,_>`.
- **Syntactic types,** such as the text `option<_>` that might occur in a program text. Syntactic types
  are converted to static types during the process of type checking and inference.
- **Static types** , which result from type checking and inference, either by the translation of syntactic
  types that appear in the source text, or by the application of constraints that are related to
  particular language constructs. For example, `option<int>` is the fully processed static type that is
  inferred for an expression `Some(1+1)`. Static types may contain `_type variables_` as described later
  in this section.
- **Runtime types** , which are objects of type `System.Type` and represent some or all of the
  information that type definitions and static types convey at runtime. The `obj.GetType()` method,
  which is available on all F# values, provides access to the runtime type of an object. An object’s
  runtime type is related to the static type of the identifiers and expressions that correspond to
  the object. Runtime types may be tested by built-in language operators such as `:?` and `:?>`, the
  expression form downcast _expr_ , and pattern matching type tests. Runtime types of objects do
  not contain type variables. Runtime types that `System.Reflection` reports may contain type
  variables that are represented by `System.Type` values.

The following describes the syntactic forms of types as they appear in programs:

```fsgrammar
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

```fsgrammar
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

```fsgrammar
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

### 5.1 CHECKING SYNTACTIC TYPES

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
environment (14.1), a floating type variable environment, which is a mapping from names to type
variables, and a type inference environment (14.5).

The phrase “fresh type” means a static type that is formed from a _fresh type inference variable_. Type
inference variables are either solved or generalized by type inference (§14.5). During conversion and
throughout the checking of types, expressions, declarations, and entire files, a set of _current
inference constraints_ is maintained. That is, each static type is processed under input constraints _Χ_ ,
and results in output constraints _Χ’_. Type inference variables and constraints are progressively
_simplified_ and _eliminated_ based on these equations through _constraint solving_ (§14.5).

#### 5.1.1 Named Types

_Named types_ have several forms, as listed in the following table.

| Form                       | Description                                                                                                                                                                                                          |
|----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `long-ident <ty1,...,tyn>` | Named type with one or more suffixed type arguments.                                                                                                                                                                 |
| `long-ident`               | Named type with no type arguments                                                                                                                                                                                    |
| `type long-ident`          | Named type with one type argument; processed the same as `long-ident<type>`                                                                                                                                          |
| `ty1 -> ty2`               | A function type, where: <br> ▪ ty1 is the domain of the function values associated with the type<br> ▪ ty2 is the range.<br>In compiled code it is represented by the named type<br>`FSharp.Core.FastFunc<ty1,ty2>`. |

Named types are converted to static types as follows:

- Name Resolution for Types (14.1) resolves `long-ident` to a type definition with formal generic
  parameters `<typar1,...,typarn>` and formal constraints `C`. The number of type arguments `n` is
  used during the name resolution process to distinguish between similarly named types that take
  different numbers of type arguments.
- Fresh type inference variables `<ty'1,...,ty'n>` are generated for each formal type parameter. The
  formal constraints _C_ are added to the current inference constraints for the new type inference
  variables; and constraints `tyi = ty'i` are added to the current inference constraints.

#### 5.1.2 Variable Types

A type of the form `'ident` is a variable type. For example, the following are all variable types:

```fsharp
'a
'T
'Key
```

During checking, Name Resolution (14.1) is applied to the identifier.

- If name resolution succeeds, the result is a variable type that refers to an existing declared type
  parameter.
- If name resolution fails, the current floating type variable environment is consulted, although
  only in the context of a syntactic type that is embedded in an expression or pattern. If the type
  variable name is assigned a type in that environment, F# uses that mapping. Otherwise, a fresh

```
type inference variable is created (see 14.5) and added to both the type inference environment
and the floating type variable environment.
```

A type of the form `_` is an anonymous variable type. A fresh type inference variable is created and
added to the type inference environment (see 14.5) for such a type.

A type of the form `^ident` is a _statically resolved type variable. A fresh type inference variable is
created and added to the type inference environment (see 14.5). This type variable is tagged with
an attribute that indicates that it can be generalized only at `inline` definitions (see 14.6.7). The
same restriction on generalization applies to any type variables that are contained in any type that is
equated with the `^ident` type in a type inference equation.

> [!NOTE]
> Note: this specification generally uses uppercase identifiers such as `'T` or `'Key` for user-
> declared generic type parameters, and uses lowercase identifiers such as `'a` or `'b` for
> compiler-inferred generic parameters.

#### 5.1.3 Tuple Types

A tuple type has the following form:

```fsgrammar
ty 1 * ... * tyn
```

The elaborated form of a tuple type is shorthand for a use of the family of F# library types
`System.Tuple<_,...,_>`. (See 6.3.2) for the details of this encoding.

When considered as static types, tuple types are distinct from their encoded form. However, the
encoded form of tuple types is visible in the F# type system through runtime types. For example,
`typeof<int * int>` is equivalent to `typeof<System.Tuple<int,int>>`.

#### 5.1.4 Array Types

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

> [!NOTE]
> The type `int[][,]` in F# is the same as the type `int[,][]` in C# although the
> dimensions are swapped. This ensures consistency with other postfix type names in F#
> such as int list list.

```
F# supports multidimensional array types only up to rank 4.
```

#### 5.1.5 Constrained Types

A type with constraints has the following form:

```
type when constraints
```

During checking, `type` is first checked and converted to a static type, then `constraints` are checked
and added to the current inference constraints. The various forms of constraints are described
in (See 5.2)

A type of the form `typar :> type` is a type variable with a subtype constraint and is equivalent to
`typar when typar :> type`.

A type of the form `#type` is an anonymous type with a subtype constraint and is equivalent to `'a
when 'a :> type` , where `'a` is a fresh type inference variable.

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

- _ty_ 1 has form _op_ < _ty_ 11 _, ..., ty_ 1n>, _ty_ 2 has form _op_ < _ty_ 21 _, ..., ty_ 2n> and each _ty1i_ is
  definitely
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