let firstPart , secondPart,_ =  (1,2,3)
let elem1::elem2::rest = [1..10]
let listMatcher aList  = 
    match aList with 
    |[]->printfn "the list is empty"
    |[firstElement]-> printfn "the list has one element %A" firstElement
    |[first;second]->printfn "list is %A and %A" first second
    |_->printfn"the lis has more than two elements"
listMatcher[1;2;3;4]
listMatcher[1;2]
listMatcher[1]
listMatcher[]
type Address =  {Street:string;City:string;}
type Customer = {ID:int;Name:string;Address:Address}
let customer1 = {ID=1;Name="Bob";
            Address={Street="123 Main";City="NY"}}
//extract Name only
let {Name=name1}=customer1 
printfn "the Customer is called %s" name1
//extract name and ID
let {Name=name2; ID=id2}=customer1
printfn "The Customer called %s and has id %i" name2 id2
// extract name and address
let {Name=name3; Address={Street=street3}}=customer1
printfn "The Customer is called %s and lives on %s" name3 street3









