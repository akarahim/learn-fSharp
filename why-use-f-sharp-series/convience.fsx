//functions as interfaces
let addingCalculator input = input+1

let loggingCalculator innerCalculator input =
    printfn "input is %A" input
    let result = innerCalculator input
    printfn "result is %A" result
    result
loggingCalculator addingCalculator 5

//Generics Wrappers
let add1 input = input+1
let times2 input = input * 2
let genericLogger anyFunc input = 
    printfn "input is %A" input
    let result = anyFunc input
    printfn "result is %A" result
    result
let add1WithLogging = genericLogger add1
let times2WithLogging = genericLogger times2

//test
add1WithLogging 3
times2WithLogging 3

[1..5] |> List.map add1WithLogging

let genericTimer anyFunc input =
    let stopWatch = System.Diagnostics.Stopwatch()
    stopWatch.Start()
    let result = anyFunc input //evaluate the functions
    printfn "elapsed ms is %A " stopWatch.ElapsedMilliseconds
    result
let add1WithTimer = genericTimer add1
add1WithTimer 3
