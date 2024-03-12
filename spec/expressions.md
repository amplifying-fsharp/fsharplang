# 6. Expressions

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
## 6.1 Some Checking and Inference Terminology

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

## 6.2 Elaboration and Elaborated Expressions

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

### 6.3.2 Tuple Expressions

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
### 6.3.3 List Expressions

An expression of the form [ _expr 1_ ;...; _exprn_ ] is a _list expression_. The initial type of the expression is
asserted to be FSharp.Collections.List< _ty_ > for a fresh type _ty_.

If _ty_ is a named type, each expression _expri_ is checked using a fresh type _ty'_ as its initial type, with
the constraint _ty'_ :> _ty_. Otherwise, each expression _expri_ is checked using _ty_ as its initial type.

List expressions elaborate to uses of FSharp.Collections.List<_> as
op_Cons( _expr 1_ ,(op_Cons( _expr 2_ ... op_Cons ( _exprn_ , op_Nil)...) where op_Cons and op_Nil are the
union cases with symbolic names :: and [] respectively.

### 6.3.4 Array Expressions

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
### 6.3.5 Record Expressions

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
### 6.3.6 Copy-and-update Record Expressions

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


### 6.3.7 Function Expressions

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
### 6.3.8 Object Expressions

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
### 6.3.9 Delayed Expressions

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

### 6.3.10 Computation Expressions

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

## 6.4 Application Expressions

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
### 6.4.8 Member Constraint Invocation Expressions

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
## 6.5 Control Flow Expressions

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
## 6.6 Definition Expressions

A _definition expression_ has one of the following forms:

```
let function-defn in expr
let value-defn in expr
let rec function-or-value-defns in expr
use ident = expr1 in expr
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

### 6.6.2 Function Definition Expressions

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

## 6.7 Type-related Expressions

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

## 6.8 Quoted Expressions

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
## 6.9 Evaluation of Elaborated Forms

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
### 6.9.3 Zero Values

Some types have a _zero value_. The zero value is the“default” value for the type in the CLI execution
environment. The following types have the following zero values:

- For reference types, the null value.
- For value types, the value with all fields set to the zero value for the type of the field. The zero
    value is also computed by the F# library function Unchecked.defaultof< _ty_ >.

### 6.9.4 Taking the Address of an Elaborated Expression

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
### 6.9.5 Evaluating Value References

At runtime, an elaborated value reference v is evaluated by looking up the value of v in the local
environment.

### 6.9.6 Evaluating Function Applications

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

### 6.9.7 Evaluating Method Applications

At runtime an elaborated application of a method is evaluated as follows:

- The elaborated form is _e 0_ .M( _e 1_ ,..., _en_ ) for an instance method or M( _e 1_ ,..., _en_ ) for a static method.
- The (optional) _e 0_ and _e 1_ ,..., _en_ are evaluated in order.
- If _e 0_ evaluates to null, a NullReferenceException is raised.
- If the method is declared abstract—that is, if it is a virtual dispatch slot—then the body of the
    member is chosen according to the dispatch maps of the value of _e 0_ (§14.8).
- The formal parameters of the method are mapped to corresponding argument values. The body
    of the method member is evaluated in the resulting environment.


### 6.9.8 Evaluating Union Cases

At runtime, an elaborated use of a union case _Case_ ( _e 1_ ,..., _en_ ) for a union type _ty_ is evaluated as
follows:

- The expressions _e 1_ ,..., _en_ are evaluated in order.
- The result of evaluation is an object value with union case label _Case_ and fields given by the
    values of _e 1_ ,..., _en_.
- If the type _ty_ uses null as a representation (§5.4.8) and _Case_ is the single union case without
    arguments, the generated value is null.
- The runtime type of the object is either _ty_ or an internally generated type that is compatible
    with _ty_.

### 6.9.9 Evaluating Field Lookups

At runtime, an elaborated lookup of a CLI or F# fields is evaluated as follows:

- The elaborated form is _expr_. _F_ for an instance field or _F_ for a static field.
- The(optional) _expr_ is evaluated.
- If _expr_ evaluates to null, a NullReferenceException is raised.
- The value of the field is read from either the global field table or the local field table associated
    with the object.

### 6.9.10 Evaluating Array Expressions

At runtime, an elaborated array expression [| _e 1 ; ..._ ; _en_ |] _ty_ is evaluated as follows:

- Each expression _e 1 ... en_ is evaluated in order.
- The result of evaluation is a new array of runtime type _ty_ [] that contains the resulting values in
    order.

### 6.9.11 Evaluating Record Expressions

At runtime, an elaborated record construction { _field_ 1 = _e 1 ; ..._ ; _field_ n = _en_ } _ty_ is evaluated as
follows:

- Each expression _e 1 ... en_ is evaluated in order.
- The result of evaluation is an object of type _ty_ with the given field values

### 6.9.12 Evaluating Function Expressions

At runtime, an elaborated function expression (fun _v 1_ ... _vn_ - > _expr_ ) is evaluated as follows:

- The expression evaluates to a function object with a closure that assigns values to all variables
    that are referenced in _expr_ and a function body that is _expr_.
- The values in the closure are the current values of those variables in the execution environment.
- The result of calling the obj.GetType() method on the resulting object is under-specified (see
    §6.9.24).


### 6.9.13 Evaluating Object Expressions

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

### 6.9.14 Evaluating Definition Expressions

At runtime, each elaborated definition _pat_ = _expr_ is evaluated as follows:

- The expression _expr_ is evaluated.
- The expression is then matched against _pat_ to produce a value for each variable pattern (§7.2)
    in _pat_.
- These mappings are added to the local environment.

### 6.9.15 Evaluating Integer For Loops

At runtime, an integer for loop for _var_ = _expr 1_ to _expr 2_ do _expr 3_ done is evaluated as follows:

- Expressions _expr 1_ and _expr 2_ are evaluated once to values _v 1_ and _v 2_.
- The expression _expr 3_ is evaluated repeatedly with the variable _var_ assigned successive values in
    the range of _v 1_ up to _v 2_.
- If _v 1_ is greater than _v 2_ , then _expr 3_ is never evaluated.

### 6.9.16 Evaluating While Loops

As runtime, while-loops while _expr 1_ do _expr 2_ done are evaluated as follows:

- Expression _expr 1_ is evaluated to a value _v 1_.
- If _v 1_ is true, expression _expr 2_ is evaluated, and the expression while _expr 1_ do _expr 2_ done is
    evaluated again.
- If _v 1_ is false, the loop terminates and the resulting value is null (the representation of the only
    value of type unit)

### 6.9.17 Evaluating Static Coercion Expressions

At runtime, elaborated static coercion expressions of the form _expr_ :> _ty_ are evaluated as follows:


- Expression _expr_ is evaluated to a value _v_.
- If the static type of _e_ is a value type, and _ty_ is a reference type, _v_ is _boxed_ ; that is, _v_ is converted
    to an object on the heap with the same field assignments as the original value. The expression
    evaluates to a reference to this object.
- Otherwise, the expression evaluates to _v_.

### 6.9.18 Evaluating Dynamic Type-Test Expressions

At runtime, elaborated dynamic type test expressions _expr_ :? _ty_ are evaluated as follows:

1. Expression _expr_ is evaluated to a value _v_.
2. If _v_ is null, then:
    - If _tye_ uses null as a representation (§5.4.8), the result is true.
    - Otherwise the expression evaluates to false.
3. If _v_ is not null and has runtime type _vty_ which dynamically converts to _ty_ (§5.4.10), the
    expression evaluates to true. However, if _ty_ is an enumeration type, the expression evaluates to
    true if and only if _ty_ is precisely _vty_.

### 6.9.19 Evaluating Dynamic Coercion Expressions

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
### 6.9.20 Evaluating Sequential Execution Expressions

At runtime, elaborated sequential expressions _expr 1_ ; _expr 2_ are evaluated as follows:

- The expression _expr 1_ is evaluated for its side effects and the result is discarded.
- The expression _expr 2_ is evaluated to a value _v 2_ and the result of the overall expression is _v 2_.

### 6.9.21 Evaluating Try-with Expressions

At runtime, elaborated try-with expressions try _expr 1_ with _rules_ are evaluated as follows:

- The expression _expr 1_ is evaluated to a value _v 1_.
- If no exception occurs, the result is the value _v 1_.
- If an exception occurs, the pattern rules are executed against the resulting exception value.
    - If no rule matches, the exception is reraised.
    - If a rule _pat -> expr 2_ matches, the mapping _pat = v 1_ is added to the local environment,
       and _expr 2_ is evaluated.

### 6.9.22 Evaluating Try-finally Expressions

At runtime, elaborated try-finally expressions try _expr 1_ finally _expr 2_ are evaluated as follows:

- The expression _expr 1_ is evaluated.
    - If the result of this evaluation is a value _v_ , then _expr 2_ is evaluated.
       1) If this evaluation results in an exception, then the overall result is that exception.
       2) If this evaluation does not result in an exception, then the overall result is _v_.
    - If the result of this evaluation is an exception, then _expr 2_ is evaluated.
       3) If this evaluation results in an exception, then the overall result is that exception.
       4) If this evaluation does not result in an exception, then the original exception is re-
          raised.

### 6.9.23 Evaluating AddressOf Expressions

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
### 6.9.24 Values with Underspecified Object Identity and Type Identity

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