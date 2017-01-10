//building blocks
let add2 x = x+2
let mult3 x = x*3
let square x= x*x

[1..10]|>List.map add2 |> printfn "%A"
[1..10]|>List.map mult3 |> printfn "%A"
[1..10]|>List.map square |> printfn "%A"


//new composed functions
let add2ThenMult3 = add2>>mult3
let mult3ThenSquare = mult3>>square

add2ThenMult3 5
mult3ThenSquare 5
[1..10] |> List.map add2ThenMult3 |> printfn "%A"
[1..10] |> List.map mult3ThenSquare |> printfn "%A"

//extending existing functions
let logMsg msg x= printf "%s%i" msg x ;x
let logMsgN msg x= printfn "%s%i" msg x ;x

//new composed functions with new improved logging
let mult3ThenSquareLogged =
    logMsg "before=" 
    >> mult3
    >> logMsg " after mult3="
    >> square
    >> logMsgN  " result"

mult3ThenSquareLogged 5
[1..10] |> List.map mult3ThenSquareLogged
