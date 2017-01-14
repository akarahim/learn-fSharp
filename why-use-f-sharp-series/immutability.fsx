type PersonalName = {FirstName:string;LastName:string}
let john = {FirstName="John";LastName="Doe"}
let alice = {john with FirstName="Doe"}
let list1 = [1;2;3;4]
let list2 = 0::list1
let list3 = list2.Tail

System.Object.ReferenceEquals(list1,list3)