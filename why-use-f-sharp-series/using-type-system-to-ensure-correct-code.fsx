type EmailAddress = EmailAddress of string
let sendEmail (EmailAddress email) =
    printfn "sent an email to %s" email
let aliceEmail = EmailAddress "alice@example.com"
sendEmail aliceEmail
// sendEmail "bob@example.com"

//define some measures
[<Measure>]
type cm

[<Measure>]
type inches

[<Measure>]
type feet =
    static member ToInches(feet:float<feet>):float<inches>
        = feet* 12.0<inches/feet>
let meter = 100.0<cm>
let yard = 3.0<feet>
let yardInInches = feet.ToInches(yard)

//some currencies
[<Measure>]
type GBP

[<Measure>]
type USD

let gbp10 = 10.0<GBP>
let usd10 = 10.0<USD>

gbp10 + gbp10
// gbp10 + usd10
// gbp10 + 1.0

gbp10 + 1.0<_>

open System
let obj = new Object()
let ex =  new Exception()
// let b = (obj=ex)
[<NoEquality;NoComparison>]
type CustomerAccount = {CustomerAccountId:int}
let x = {CustomerAccountId=1}
x.CustomerAccountId = x.CustomerAccountId
// x==x



    

