open System

//Функция проверки на натуральность
let CheckNumNat num =
    if (num >= 0) then 
        num
    else 
        printfn "Введенное число меньше нуля"
        0
//Функция ввода списка слов
let EnterWords Num = [
    if not (Num = 0) then
        for i in 1 .. Num do
            printf "Введите слово: "
            yield string (Console.ReadLine())
]

//Функция ввода списка чисел 
let EnterNums Num = [
    if not (Num = 0) then
        for i in 1 .. Num do
            printf "Введите число: "
            yield int (Console.ReadLine())
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



let LenghtOfString (strin:string) =
    strin.Length

//Если num(цифра) встречается в element, то складываем в sum
let sumElementIfNum sum element num=
    if (isNumIn element num) = 1 then 
        sum + element
    else 
        sum

let task1 _ =
    printf "Введите количество элементов: "
    let N = CheckNumNat (int (Console.ReadLine()))
    let list = EnterWords N 
    //Создание списка длин строк другого списка
    printfn "Введённый вами список слов: %A" list
    let lenlist = list |> List.map LenghtOfString
    printf "Список длин слов: %A" lenlist
    0

let task2 _ =
    printf "Введите количество чисел: "
    let N = CheckNumNat (int (Console.ReadLine()))
    let list = EnterNums N 
    printfn "Введённый вами список слов: %A" list
    printf "Введите цифру для поиска в списке: "
    let Numero = int (Console.ReadLine()) 
    //Вычисление суммы элементов списка в которых есть введённая цифра   
    let sum = 
        List.fold 
            (fun acc element-> 
                sumElementIfNum acc element Numero)
            0
            list  
    printfn "Результат: %i" sum
    0

[<EntryPoint>]
let main _ =
    printfn "Выберите программу введя её номер"
    printfn "Задание 1: List.map"
    printfn "Задание 2: List.fold"
    let task = int (Console.ReadLine())
    if task = 1 then
        task1 1
    elif task = 2 then
        task2 1
    else 
    0