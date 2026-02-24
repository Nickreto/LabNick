open System
(*
let N = 115.375
let d = 2.54
let M Num dec : int =
    int (Num * dec) / 100

let SM Num dec : int =
    int (Num * dec) % 100

let MM Num dec: float =
    (float (Num * dec ) % 100.0 - float (SM Num dec)) * 10.0

let x = M N d

printfn "%f = %i метров" N (M N d)
printfn "%f = %i сантиметров" N (SM N d)
printfn "%f = %f миллиметров" N (MM N d)
*)

(*
printfn "Введите число"
let N = int (Console.ReadLine())

let XX x = [
    for i in 1 .. x do
        if i % 2 = 0 then
            //printf "%i  " i
            yield i
]

printfn "Чётные числа: %A" (XX N)
*)

(*
printf "Введите число: "
let N = int(Console.ReadLine())
let rec Recur x =
    if (x/10=0) then (x%10)
    else (Recur (x / 10))+x%10

printfn "Сумма цифр: %i" (Recur N)
*)


(*
let XYaaa x y =
    if (x > 0) then
        if (y > 0) then printf "1 четверть"
        else if (y < 0) then printfn "2 четверть"
        else printfn "Правая половина, y на оси"
    else if (x < 0)then
        if (y > 0) then printf "4 четверть"
        else if (y < 0) then printfn "3 четверть"
        else printfn "Левая половина, y на оси"
    else 
        if (y > 0) then printf "Верхняя половина, x на оси"
        else if (y < 0) then printfn "Нижняя половина, x на оси"
        else printfn "Точка в начале координат"

[<EntryPoint>] // Обязательно
let main =
    printf "Введите x:"
    let x = int (Console.ReadLine())
    printf "Введите y:"
    let y = int (Console.ReadLine())
    XYaaa x y
    *)


let rec Fib N a1 a2=
    if (a2 < 1) then
        printf "Последовательность: 1 1 "
        Fib N 1 1
    else if (a1+a2<N) then 
        printf "%i " (a1+a2)
        Fib N (a1+a2) a1
[<EntryPoint>] // Обязательно
let main _ = 
    printf "Введите n:"
    let N = int (Console.ReadLine())
    (Fib N 0 0)
    0
