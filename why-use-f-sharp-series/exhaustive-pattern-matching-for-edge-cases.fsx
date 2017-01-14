let rec movingAverages list=
    match list with 
    |[]->[]
    |x::y::rest->
        let avg = (x+y)/2.0
        avg :: movingAverages(y::rest)
    |[_]->[]

movingAverages [1.0]
movingAverages [1.2;2.0]
movingAverages [1.2;2.0;3.0]