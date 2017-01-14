//define union type of two diffrent alternatives
type Result<'a,'b> =
    |Success of 'a //'a means generic type. The actual type    // will be determined when it is used
    |Failue of 'b

//define all possible error
type FileErrorReason =
    |FileNotFound of string
    |UnAuthorizedAccess of string * System.Exception
let performActionOnFile action filePath =
    try
        use sr = new System.IO.StreamReader(filePath:string)
        let result= action sr
        sr.Close()
        Success(result)
    with 
    | :? System.IO.FileNotFoundException as ex
        -> Failue(FileNotFound filePath)
    | :? System.Security.SecurityException as ex
        -> Failue(UnAuthorizedAccess(filePath,ex))
//a function in the middle layer
let middleLayerDo action filePath =
    let fileResult = performActionOnFile action filePath
    fileResult
//a function in the top layer
let topLayerDo action filePath =
    let fileResult = middleLayerDo action filePath
    fileResult

let printFirstLineOfFIle filePath =
    let fileResult = topLayerDo (fun fs->fs.ReadLine()) filePath
    match fileResult with
    | Success result->
        printfn "first line is '%s'" result
    | Failue reason ->
        match reason with  
        | FileNotFound file ->
             printfn "File not found: %s" file
        | UnAuthorizedAccess (file,_)->
            printfn "You do not have access to the file"

let goodFileName ="convience.fsx"
let badFileName ="bad.txt"
printFirstLineOfFIle goodFileName
printFirstLineOfFIle badFileName