open System
let userTimerWithCallBack =  
    //create an event to wait on
    let event = new System.Threading.AutoResetEvent(false);
    //create a time and add an event handler that will signal the event
    let timer = new System.Timers.Timer(2000.0)
    timer.Elapsed.Add(fun _ -> event.Set()|> ignore)

    //start 
    printfn "waiting for timer at %O" DateTime.Now.TimeOfDay
    timer.Start()

    //keep  working
    printfn "Do something useful while waiting for event"
    //block on the via the AutoRest Event
    event.WaitOne() |> ignore

    //done 
    printfn "Timer ticked at %O" DateTime.Now.TimeOfDay


