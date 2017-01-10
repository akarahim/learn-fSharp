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

//Pattern matching for flow of control
(*
Most imperative languages offer a variety of control flow statements for branching and looping:

    if-then-else (and the ternary version bool ? if-true : if-false)
    case or switch statements
    for and foreach loops, with break and continue
    while and until loops
    and even the dreaded goto

F# does support some of these, but F# also supports the most general form of conditional expression, which is pattern-matching.

A typical matching expression that replaces if-then-else looks like this:
*)

//Pattern Matching with union types
type Shape =
    | Circle of radius:int
    | Rectangle of height:int * width:int
    | Point of x:int * y:int
    | Polygon of pointList:(int * int) list

let draw shape = 
 match shape with    
    | Circle radius ->
        printfn "The Circle had raduis of %d" radius
    | Rectangle (height ,width)->
        printfn "The Rectangle is %d high by %d wide" height width
    | Polygon points->
        printfn "The Polygon is made of these points %A" points
    | _ -> printfn "I don't recognize this shape"
let circle = Circle 10
let rect = Rectangle(4,5)
let point = Point(2,3)
let polygon = Polygon([(1,2);(2,2);(3,3)])
[circle;rect;polygon;point] |> List.iter draw
