let fileWriteWithAsync = 
    use stream = new System.IO.FileStream("test.txt",System.IO.FileMode.Create)
    printfn "starting async write"
    let asyncResult = stream.BeginWrite(Array.empty,0,0,null,null)
    let async =  Async.AwaitIAsyncResult(asyncResult) |> Async.Ignore
    printfn "doing something useful while waiting for write to complete"

    Async.RunSynchronously async

    printfn "Async write completed"
    