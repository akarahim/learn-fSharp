let testLoop = async {
        for i in [1..100] do
            printf "%i before .." i

            do! Async.Sleep 10
            printfn ".. after"

}
Async.RunSynchronously testLoop
open System
open System.Threading

let cancellationSource = new CancellationTokenSource()
Async.Start (testLoop,cancellationSource.Token)
Thread.Sleep(200)
cancellationSource.Cancel()

