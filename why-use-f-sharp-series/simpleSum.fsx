let square x = x*x
let sumOfSquares n = 
    [1..n] 
    |> List.map square 
    |> List.sum
sumOfSquares 2
