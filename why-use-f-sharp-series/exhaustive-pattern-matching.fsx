type State = New | Draft | Published | Inactive | Discontinued

//compiler tells you the problem
let HandleState state = 
    match state with
    | Inactive -> ()
    | Draft -> ()
    | New -> ()
    | Discontinued->()


