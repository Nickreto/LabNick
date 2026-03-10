open System
open System.IO
//Функция обработки количества элементов
let EnterCount _=
    printf "Введите количество элементов: "
    try 
        let count = int (Console.ReadLine())
        if count > 0 then
            count
        else
            printfn "Error: Количество элементов должно быть больше 0"
            -1
    with
    | ex ->
        printfn "Error: %s" ex.Message
        -1

let CheckForNum _=
    try 
        let count = int (Console.ReadLine())
        count
    with
    | ex ->
        printfn "Error: %s" ex.Message
        0

let EnterElementsNums count= seq [
    for i in 1 .. count do
        printf "Введите число: "
        try
            let inp = int (CheckForNum 1)
            yield inp
        with
        | ex ->
            printfn "Error: %s" ex.Message
]

let EnterElementsString count= seq [
    for i in 1 .. count do
        printf "Введите слово: "
        yield string (Console.ReadLine())
]

let rec isNumIn element num=
    if not (element/10 = 0) then
        if (element%10)=num then
            1
        else 
            isNumIn (element/10) num
    else
        if (element%10)=num then
            1
        else 
            0

let isFigure element = 
    if (element < 10) then
        element
    else
        0

//Если num(цифра) встречается в element, то складываем в sum
let sumElementIfNum sum element num=
    if (isNumIn element num) = 1 then 
        sum + element
    else 
        sum

let LenghtofString (element:String) =
    element.Length

let rec allFiles root =
    seq {
        try 
            //printfn "AllFiles"
            //for dir in Directory.EnumerateDirectories(root) do
            //    yield! allFiles dir
            yield! Directory.EnumerateFiles(root)
            yield! Directory.EnumerateDirectories(root)
        with
            |ex ->
            printfn "Error: %s" ex.Message
            yield ""

    }

let findMax max element =
    if element > max then
        element
    else
        max

let ExitEnter _ =
    printfn "Enter to continue"
    Console.ReadLine()
    0

let task1 _ =
    let count = EnterCount 1
    let sequens = EnterElementsString count
    if count > 0 then
        printfn "output: %A" (Seq.toList sequens)
        let lenOfElements = sequens |> Seq.map(LenghtofString)
        printfn "len of items in seq: %A" (Seq.toList lenOfElements)
        ExitEnter 1
    else 
        ExitEnter 1

let task2 _ =
    let count = EnterCount 1
    if count < 1 then
        0
    else 
    let sequens = EnterElementsNums count
    printfn "Введите цифру для поиска: "
    let findNum = int (Console.ReadLine())
    printfn "output: %A" (Seq.toList sequens)
    let sum = 
        Seq.fold 
            (fun acc element-> 
                sumElementIfNum acc element count)
            0
            sequens
    printfn "%i" sum
    ExitEnter 1

let enterWay way =
    try 
        let fullPath = Path.GetFullPath(way)
        if Directory.Exists(fullPath) then
            allFiles way
        else
            printfn "Directory does not exist: %s" fullPath
            [""]
    with
    |ex ->
        printfn "Error: %s" ex.Message
        []

let rec OutSeq (sequen:seq<string>) =
    match Seq.toList sequen with
    | [] -> 0
    | head::tail -> 
                    printfn "%s" head
                    OutSeq tail
    

let task3 _ =
    printf "Введите путь:"
    let way = Console.ReadLine()    
    let directorys = enterWay way
    let lenOfWay = LenghtofString way
    OutSeq directorys
    let lenOfElements = directorys |> Seq.map(LenghtofString)
    let maxx =
        Seq.fold
            (fun mmax element ->
                findMax mmax element)
            lenOfWay
            lenOfElements
    if not ((maxx-lenOfWay)=0) then
        printfn "Максимальная длина файла: %i" (maxx-lenOfWay)
    else 
        printf ""
    ExitEnter 1

let body _ =
    printf 
        """Выберите программу введя её номер
Задание 1 seq.map: 1
Задание 2 seq.fold: 2
Задание 3 Work with files: 3
Выйти из программы: -1
Ввод:"""
    let task = int (Console.ReadLine())
    if task = 1 then
        task1 1
    elif task = 2 then
        task2 1
    elif task = 3 then
        task3 1
    elif task = -1 then
        Environment.Exit(0)
        0
    else
        0
        
    

[<EntryPoint>]
let main _ =
    while (1=1) do
        body 1
    0