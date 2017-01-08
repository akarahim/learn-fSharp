let theInt = 5
let theFloat=3.14
let theString="hello"
let twoToFive =  [2;3;4;5]
let oneToFive = 1::twoToFive
let ZeroToFive = [0;1] @ twoToFive
let square x = x * x
square 3

let add x y = x + y
add 2 3

let evens list = 
    let isEven x = x % 2 =0
    List.filter isEven list
evens oneToFive

let sumOfSquareTo100 = 
    List.sum(List.map square [1..100])
let sumOfSquareTo100Piped =
    [1..100] |> List.map square |> List.sum

let sumOfSquareTo100withFun=
    [1..100]|>List.map(fun x->x*x)|> List.sum

//=====Pattern Matching
let simplaPatternMatch = 
    let x = "a"
    match x with
    | "a" -> printfn "x is a" 
    | "b" -> printfn "x is b"
    | _ -> printfn "x is something else"

let validValue = Some(99)
let inValidValue = None

let optionPatternMatch input =  
match input with
|Some i-> printfn "input is an int=%d" i
|None->printfn "input is missing"

optionPatternMatch validValue
optionPatternMatch inValidValue 


// Tuple types are pairs, triples, etc. Tuples use commas.
let twoTuple = 1,2
let threeTuple = "a",2,true

// Record types have named fields. Semicolons are separators.
type Person={First:string;Last:string}
let person1 = {First="Rahim";Last="Khan"}

type Temp =
    |DegreeC of float
    |DegreeF of float

let temp = DegreeF 98.6 

type Employee = 
    | Worker of Person
    | Manager of Employee list

let rkhan = {First="Rahim";Last="Khan"}
let worker = Worker rkhan
let manager = Manager [worker]








