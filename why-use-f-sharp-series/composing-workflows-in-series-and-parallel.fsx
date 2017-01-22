let sleepWorkflow ms = async{
    printfn "%i ms workflow started" ms
    do! Async.Sleep ms
    printfn "%i ms workflow finished" ms
}

let workflowInSeries =  async{
    let! sleep1= sleepWorkflow 1000
    printfn "Finished one"
    let! sleep2 = sleepWorkflow 2000
    printfn "Finished two"
}

#time
Async.RunSynchronously workflowInSeries
#time

let sleep1 = sleepWorkflow 1000
let sleep2 = sleepWorkflow 2000

#time
[sleep1;sleep2]
    |>Async.Parallel
    |>Async.RunSynchronously
#time
