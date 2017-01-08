(*
Function Oriented rather than object oriented
Expression Rather than Statements
Algebraic types for creating domain model
Pattern Matching for flow of Control
*)

// Function Oriented rather than object oriented

let square x = x*x
//fuctions as values 
let squareClone = square
//Building with Composition
//Factoring and Refactoring
//Good Design

//Expression rather than Statements
(*In functional languages, there are no statements, only expressions.
That is, every chunk of code always returns a value, and larger chunks are created by combining smaller chunks using composition rather than a serialized list of statements.*)

//Algebraic Types

(*
The type system in F# is based on the concept of algebraic types. That is, new compound types are built by combining existing types in two different ways:

    First, a combination of values, each picked from a set of types. These are called "product" types.
    Of, alternately, as a disjoint union representing a choice between a set of types. These are called "sum" types.

For example, given existing types int and bool, we can create a new product type that must have one of each:

*)
//product type
type IntAndBool = {intPart:int;boolPart:bool}
let x ={intPart=1;boolPart=false}

//union type
type IntOrBool =
    |IntChoice of int
    |BoolChoice of bool
let y = IntChoice 42
let z = BoolChoice false
type Complex = float * float
type ComplexComparisonFunction = Complex -> Complex -> int






