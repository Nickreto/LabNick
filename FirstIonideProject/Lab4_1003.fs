open System

type 'tree Tree =
    Node of 'tree * 'tree Tree * 'tree Tree
    | Nil

let infix root left right = (left(); root(); right())

let iterh trav f t =
        let rec tr t h =
            match t with
            Node (x,l,r) -> trav
                                (fun () -> (f x h)) // обход корня
                                (fun () -> tr l (h+1)) // обход левого поддерева
                                (fun () -> tr r (h+1)); // обход прав. поддерева
            | Nil -> ()
        tr t 0
let spaces n = 
    List.fold 
        (
            fun s _ -> s+"  "
        )
        "" 
        [0..n]
let print_tree t = 
    iterh infix 
        (
            fun x h -> printfn "%s%A" (spaces h)x
        ) 
        t
let rec insert t x =
        match t with
            Nil -> Node(x,Nil,Nil)
            | Node(z,l,r) -> 
                if x<z then Node(z,insert l x ,r)
                else Node(z,l,insert r x)
    //Функция свертки дерева
let tree_fold f st tree =   
    let rec ob d k = 
        match d with
        | Node (t,l,r) -> ob r (f (ob l k) t)
        | Nil -> k
    ob tree st

let rec map f tree =
    match tree with
    | Nil -> Nil
    | Node(v, left, right) -> Node(f v, map f left, map f right)

let firstSymbol (symb: char) (word: string)= 
    string symb + word.[1..]

let rec createWord n str =
    let r = new Random()
    if n = 0 then
        str
    else
        let s = str + string (char (r.Next(97,122)))
        createWord (n-1) s

let CheckForNum _=
    try 
        let count = int (Console.ReadLine())
        count
    with
    | ex ->
        printfn "Ошибка: %s" ex.Message
        -1

let CharInput _ =
    try
        let inp = char (Console.ReadLine())
        inp
    with
    | ex ->
        printfn "Ошибка: %s" ex.Message
        char(0)

let addIfLeaf acc node left right =
    match left, right with
    | Nil, Nil -> node :: acc  // добавляем только если это лист
    | _ -> acc

let rec leafFold acc tree =
    match tree with
    | Nil -> acc
    | Node(v, left, right) ->
        let newAcc = addIfLeaf acc v left right
        let accFromLeft = leafFold newAcc left
        leafFold accFromLeft right

let task1 _ =
    printfn "Введите количество элементов: "
    let n = CheckForNum 1
    if n < 1 then
        printfn "Неверный ввод"
        0
    else
    let a =
        [
            let str = ""
            let r = new Random()
            for i in 1..n do
                yield createWord (r.Next( 2,10)) str
        ]
    printfn "Исходный список %A" a
    let bt = a |> List.fold insert Nil
    print_tree bt
    printfn "Введите символ для замены: "
    let newSymb = CharInput 1
    if newSymb = char (0) then 
        0
    else
        let newBT = bt |> map (firstSymbol newSymb)
        printfn "Вывод изменённого дерева: "
        print_tree newBT    
        0

let task2 _ =
    printfn "Введите количество элементов: "
    let n = CheckForNum 1
    if n < 1 then
        printfn "Неверный ввод"
        0
    else
    let a =
        [
            let str = ""
            let r = new Random()
            for i in 1..n do
                yield createWord (r.Next( 2,10)) str
        ]
    printfn "Исходный список %A" a
    let bt = a |> List.fold insert Nil
    print_tree bt
    let newBT = leafFold [] bt |> List.rev
    printfn "Вывод списка листьев: %A" newBT  
    0

let body _ =
    printf 
        """Выберите программу введя её номер
Задание 1 map: 1
Задание 2 fold: 2
Выйти из программы: -1
Ввод:"""
    let task = int (Console.ReadLine())
    if task = 1 then
        task1 1
    elif task = 2 then
        task2 1
    elif task = -1 then
        Environment.Exit(0)
        0
    else
        0
[<EntryPoint>]
let main _ =
    while 1=1 do
        body 1
    0