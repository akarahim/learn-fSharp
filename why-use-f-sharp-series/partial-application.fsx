let add x y  = x+y
let z = add 1 2

let add42 =  add 42

add42 2

let genericLogger before after anyFunc input =  
    before input
    let result  = anyFunc input
    after result
    result

let add1 input = input + 1

genericLogger 
    (fun x-> printfn "before = %i" x ) 
    (fun x-> printfn "after = %i" x)
    add1
    2

genericLogger 
    (fun x-> printfn "started with = %i" x ) 
    (fun x-> printfn "ended with = %i" x)
    add1
    2
let add1WithConsoleLogging =
    genericLogger
        (fun x -> printf "input=%i." x)
        (fun x -> printfn " result=%i" x)
        add1
add1WithConsoleLogging 2
[1..5] |> List.map add1WithConsoleLogging
