open System
let sleepWorkflow = async{
    printfn "starting sleep workflow at %O" DateTime.Now.TimeOfDay
    do! Async.Sleep 3000
    printfn "Finished sleep workflow at %O" DateTime.Now.TimeOfDay
}
Async.RunSynchronously sleepWorkflow

let nestedWorkflow = async{
    printfn "starting parent"
    let! childWorkflow = Async.StartChild sleepWorkflow
    do! Async.Sleep 100
    printfn "doing something useful while waiting"

    let! result = childWorkflow
    printfn "Finished parent"
}
Async.RunSynchronously nestedWorkflow
