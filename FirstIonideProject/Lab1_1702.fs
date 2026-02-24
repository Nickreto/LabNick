open System

//Функция проверки на натуральность
let CheckNumNat num =
    if (num >= 0) then 
        num
    else 
        printfn "Введенное число меньше нуля"
        0
//Функция ввода списка слов для 1 задания
let EnterWords Num = [
    if not (Num = 0) then
        for i in 1 .. Num do
            printf "Введите слово: "
            yield string (Console.ReadLine())
]

//Функция поиска максимальной цифры в числе для 2 задания
let rec FindMax num maxx=
    if not (num = 0) then
        if ((num % 10) > maxx) then
            FindMax (num/10) (num%10)
        else 
            FindMax (num/10) maxx
    else 
        maxx

//Функция добавления элемента
let AddElement list element =
    element::list

//Функция удаления элемента
let rec RemoveElement list element= 
    match list with
    | [] -> printfn "Элемент не найден";[]
    | head::tail when head=element -> [] @ tail
    | head::tail -> [head] @ RemoveElement tail element



//Функция объединения списков
let ConnectLists list1 list2 =
    list1 @ list2

//Функция поиска элемента по номеру
let rec FindByNum list1 num =
    match list1 with
    | [] -> ""
    | head::tail when (num < 1) -> head
    | head::tail -> FindByNum tail (num-1)

//Функция поиска поиска номера элемента | num=0
//Возвращает -1 если элемент не найден
let rec FindElement list element num=
    match list with
    | [] -> -1
    | head::tail when (head=element) -> num
    | head::tail -> (FindElement tail element (num+1))
        

    
let task1 _ =
    printf "Введите количество элементов: "
    let N = CheckNumNat (int (Console.ReadLine()))
    let list = EnterWords N 
    printf "Введённый вами список слов: %A" list
    0

let task2 _ =
    printf "Введите натуральное число: "
    let N = CheckNumNat  (int (Console.ReadLine()))
    printfn "Максимальная цифра в числе: %i" (FindMax N 0)
    0

//Демонстрация работы функций
let task3 _ =
    let list = ["uno";"dos";"tres";"quatro"]
    printfn "Начальный список: %A" list
    printf "Введите элемент, который надо добавить: " 
    let list = (AddElement list (Console.ReadLine()))
    printfn "Изменённый список: %A" list
    printf "Введите элемент, который надо удалить: " 
    let list = (RemoveElement list (Console.ReadLine()))
    printfn "Изменённый список: %A" list
    printf "Введите элемент, который надо найти: " 
    printfn "Номер элемента: %i" (FindElement list (Console.ReadLine()) 0)
    let list2 = ["singo";"sengo";"ses"]
    printfn "Сцепка со списком: %A" list2
    let list = (ConnectLists list list2)
    printfn "Результат сцепки: %A" list
    printfn "Введите номер элемента для поиска: "
    let n =CheckNumNat(int (Console.ReadLine()))
    printf "Найденный элемент: %s" (FindByNum list n)
    0

[<EntryPoint>]
let main _ =
    printfn "Выберите программу введя её номер"
    printfn "Задание 1: Генерация списков"
    printfn "Задание 2: Реккурсия"
    printfn "Задание 3: функции"
    let task = int (Console.ReadLine())
    if (task = 1) then
        task1 1
    else if (task = 2) then
        task2 1
    else if (task = 3) then
        task3 1
    else
    0