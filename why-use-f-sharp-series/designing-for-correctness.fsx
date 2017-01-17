type CartItem = string
type EmptyState = NoItems
type ActiveState ={UnPaidItems:CartItem list}
type PaidForState ={PaidItems:CartItem list;Payment:decimal}

type Cart =
    | Empty of EmptyState
    | Active of ActiveState
    | PaidFor of PaidForState

let addToEmptyState item =
    Cart.Active {UnPaidItems=[item]}
let addToActiveState state itemToAdd =   
    let newList = itemToAdd::state.UnPaidItems
    Cart.Active  {state with UnPaidItems = newList }

let removeItemFromActiveState state itemToRemove =
    let newList= state.UnPaidItems |> List.filter (fun i->i<>itemToRemove)
    match newList with  
    |[]->Cart.Empty NoItems
    |_->Cart.Active {state with UnPaidItems = newList}

let payForActiveState state amount =
    Cart.PaidFor {PaidItems = state.UnPaidItems;Payment= amount}

type EmptyState with
    member this.Add = addToEmptyState
type ActiveState with   
    member this.Add = addToActiveState this
    member this.Remove = removeItemFromActiveState this
    member this.Pay = payForActiveState this

let addItemToCart cart item =
    match cart with 
    |Empty state ->
         state.Add item
    |Active state ->
         state.Add  item
    |PaidFor state ->
     printfn "ERROR : the cart is paid for"  
     cart

let removeItemFromCart cart item =
    match cart with
    |Empty state ->
        printfn "ERROR : the cart is empty"
        cart
    |Active state -> 
        state.Remove item
    |PaidFor state ->
        printfn "ERROR : the cart is paid for"
        cart
let displayCart cart = 
    match cart with
    |Empty state->
        printfn "The Cart is Empty"
    |Active state ->
        printfn "The cart contains %A unpaid items" state.UnPaidItems
    |PaidFor state ->
        printfn "The Cart contains %A paid item. Amount paid : %f" state.PaidItems state.Payment

type Cart with 
    static member NewCart = Cart.Empty NoItems
    member this.Add = addItemToCart this
    member this.Remove = removeItemFromCart this
    member this.Display = displayCart this


let emptyCart = Cart.NewCart
printfn "empty cart=";emptyCart.Display
let cartA = emptyCart.Add "A"
printf "cartA=";cartA.Display
let cartAB= cartA.Add "B"
printf "cartAB=";cartAB.Display
let cartB =  cartAB.Remove "A"
printf "Cart B=";cartB.Display
let emptyCart2=cartB.Remove "B"
printf "emptyCart2=";emptyCart2.Display
let emptyCart3=emptyCart2.Remove "B"
let cardAPaid=
    match cartA with    
    | Empty _ | PaidFor _ -> cartA
    | Active state ->  state.Pay 100M
printf "cart APaid";cardAPaid.Display

let emptyCartPaid =
    match emptyCart with    
    | Empty _ | PaidFor _ -> emptyCart
    | Active state->state.Pay 100m
printf "emptyCartPaid=";emptyCartPaid.Display
let cardABPaid=
    match cartAB with    
    | Empty _ | PaidFor _ -> cartAB
    | Active state ->  state.Pay 100M
printf "cart ABPaid";cardABPaid.Display