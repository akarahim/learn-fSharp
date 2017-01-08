// "open" brings a .NET namespace into visibility
open System.Net
open System
open System.IO

// Fetch the contents of a web page
let fetchUrl callback url =        
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    callback reader url
let myCallBack (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let html1000 =  html.Substring(0,1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html
let fetchUrl2 = fetchUrl myCallBack
// let google = fetchUrl2 "http://google.com"
// let bbc = fetchUrl2 "http://news.bbc.com"

let sites =["http://ww.bing.com";"http://www.google.com";"http://www.yahoo.com"]
sites |> List.map fetchUrl2




