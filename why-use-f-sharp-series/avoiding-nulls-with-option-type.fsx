let getFileInfo filePath =
    let fi = new System.IO.FileInfo(filePath)
    if fi.Exists then Some(fi) else None
let goodFileName = "convience.fsx"
let badfileName = "bad.txt"

let goodFileInfo = getFileInfo goodFileName
let badFileInfo = getFileInfo badfileName

match goodFileInfo with
    | Some fileInfo -> 
        printfn "the file %s exists" fileInfo.FullName
    | None -> 
        printfn "the fileDoesn't exist"

match badFileInfo with
    | Some fileInfo -> 
        printfn "the file %s exists" fileInfo.FullName
    | None -> 
        printfn "the file doesn't exist"