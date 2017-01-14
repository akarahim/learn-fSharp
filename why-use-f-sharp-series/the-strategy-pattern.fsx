type Animal(noiseMakingStrategy) = 
    member this.MakeNoise = noiseMakingStrategy() |> printfn "Making noise %s"

//now create a cat
let meowing() = "Meow"
let cat =  Animal(meowing)

cat.MakeNoise

// .. and a dog
let woofOrBark() = if (System.DateTime.Now.Second % 2 = 0) then "Woof" else "Bark"
let dog = Animal(woofOrBark)
dog.MakeNoise
dog.MakeNoise