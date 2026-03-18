//Сумма элементов дерева
open System
type 't btree =
    Node of 't * 't btree * 't btree
    | Nil


[<EntryPoint>]
let body args =
    let infix root left right = (left(); root(); right())

    let iterh trav f t =
        let rec tr t h =
            match t with
            Node (x,L,R) -> trav
                                (fun () -> (f x h)) // обход корня
                                (fun () -> tr L (h+1)) // обход левого поддерева
                                (fun () -> tr R (h+1)); // обход прав. поддерева
            | Nil -> ()
        tr t 0
    let spaces n = List.fold (fun s _ -> s+"  ") "" [0..n]
    let print_tree T = iterh infix (fun x h -> printfn "%s%A" (spaces h)x) T
    let rec insert t x =
        match t with
            Nil -> Node(x,Nil,Nil)
            | Node(z,L,R) -> 
                if x<z then Node(z,insert L x ,R)
                else Node(z,L,insert R x)
    //Функция свертки дерева
    let tree_fold f st tree =   
        let rec ob d k = 
            match d with
            | Node (t,l,r) -> ob r (f (ob l k) t)
            | Nil -> k
        ob tree st

    let sum s a =
        s+a
    let rec createWord n str =
        let r = new Random()
        if n = 0 then
            str
        else
            let s = str + string (char (r.Next(97,122)))
            createWord (n-1) s

    let A =
        [
            let str = ""
            let r = new Random()
            printfn "Количество элементов?"
            let n = Console.ReadLine() |> Convert.ToInt32 
            for i in 1..n do
                yield createWord (r.Next( 2,10)) str
        ]
    printfn "Исходный список %A" A
    let BT = A |> List.fold insert Nil
    print_tree BT
    //BT |> tree_fold sum 0 |> printfn "Сумма элементов дерева %A"
    0









    //Функция свертки дерева
let tree_fold func st root =   
    let rec bypass tree k = 
        match tree with
        | Node (value,left,right) -> bypass right (func (bypass left k) value)
        | Nil -> k
    bypass root st