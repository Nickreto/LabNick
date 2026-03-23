open System

type 'tree Tree =
    Node of 'tree * 'tree Tree * 'tree Tree
    | Nil

let infix root left right = (left(); root(); right())

let iterh trav func tree =
        let rec tr tree high =
            match tree with
            Node (value,left,right) -> 
                            trav
                                (fun () -> (func value high)) 
                                (fun () -> tr left (high+1)) 
                                (fun () -> tr right (high+1)); 
            | Nil -> ()
        tr tree 0
let spaces num = 
    List.fold 
        (fun str _ -> 
            str+"  ")
        "" 
        [0..num]
let printTree tree = 
    iterh infix 
        (
            fun value hight -> 
                printfn "%s%A" (spaces hight)value
        ) 
        tree
let rec insert tree value =
        match tree with
            Nil -> Node(value,Nil,Nil)
            | Node(value2,left,right) -> 
                if value<value2 then 
                    Node(value2,insert left value ,right)
                else 
                    Node(value2,left,insert right value)

let rec map func tree =
    match tree with
    | Nil -> Nil
    | Node(value, left, right) -> 
        Node(func value, map func left, map func right)

let firstSymbol (symb: char) (word: string)= 
    string symb + word.[1..]

let rec createWord num str =
    let rand = new Random()
    if num = 0 then
        str
    else
        let strOut = str + string (char 
            (rand.Next(97,122)))
        createWord (num-1) strOut

let checkForNum _=
    try 
        let count = int (Console.ReadLine())
        count
    with
    | ex ->
        printfn "Ошибка: %s" ex.Message
        -1

let charInput _ =
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

let rec leafFoldNew func acc tree =
    match tree with
    | Nil -> acc
    | Node(value, left, right) ->
        let newAcc = func acc value left right
        let accFromLeft = leafFoldNew func newAcc left 
        leafFoldNew func accFromLeft right 
let task1 _ =
    printfn "Введите количество элементов: "
    let num = checkForNum 1
    if num < 1 then
        printfn "Неверный ввод"
        0
    else
    let list =
        [
            let str = ""
            let rand = new Random()
            for i in 1..num do
                yield createWord 
                    (rand.Next( 2,10)) str
        ]
    printfn "Исходный список %A" list
    let bt = list |> List.fold insert Nil
    printTree bt
    printfn "Введите символ для замены: "
    let newSymb = charInput 1
    if newSymb = char 0 then 
        0
    else
        let newBT = bt |> map (firstSymbol newSymb)
        printfn "Вывод изменённого дерева: "
        printTree newBT    
        0

let task2 _ =
    printfn "Введите количество элементов: "
    let num = checkForNum 1
    if num < 1 then
        printfn "Неверный ввод"
        0
    else
    let list =
        [
            let str = ""
            let r = new Random()
            for i in 1..num do
                yield createWord 
                    (r.Next( 2,10)) str
        ]
    printfn "Исходный список %A" list
    let bt = list |> List.fold insert Nil
    printTree bt
    let newBT = leafFoldNew addIfLeaf  [] bt |> List.rev
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