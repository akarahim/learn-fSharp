open System
open Microsoft.FSharp.Control;

let userTimerAsync = 
    let timer = new System.Timers.Timer(2000.0)
    let timerEvent = Async.AwaitEvent(timer.Elapsed) |> Async.Ignore
    
    printfn "waiting for timer at %O" DateTime.Now.TimeOfDay
    timer.Start()

    printfn "doing something useful while waiting for event"
    Async.RunSynchronously timerEvent

    printfn "Timer ticked at %O" DateTime.Now.TimeOfDay


