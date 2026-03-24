:- initialization(main,main).
%Функция обрабатывает список с элементом и выводит количество
isDigitEndsBySymbol([],_,Count):-write(Count),nl.
isDigitEndsBySymbol([Head|Tail],Symbol,Count):-
	Digit is Head mod 10,
	Digit=:=Symbol,
	NewCount is Count + 1,
	isDigitEndsBySymbol(Tail,Symbol,NewCount).
isDigitEndsBySymbol([_|Tail],Symbol,Count):-
	isDigitEndsBySymbol(Tail,Symbol,Count).
%Функция ввода списка
readElements(ListN,Count) :-
        writeln('Вводите элементы:'),
        whileCount(ListN,Count).
whileCount([],0).
whileCount([Input|Tail],Count) :-
        Count > 0,
        read(Input), Count1 is Count - 1,
        whileCount(Tail,Count1).
%Главная функция
main :-
        write("Введите длину списка натуральным числом"),nl,
        write("Не забудьте точку после введённого числа!"),nl,
	write('Введите количество элементов:'),
        read(Count),
        readElements(List,Count),
	write("Ваш список: "),write(List),nl,
	write("Введите цифру для поиска: "), read(Numero),
	write("Количество эелементов заканчивающихся на "), write(Numero),write(':'),
	isDigitEndsBySymbol(List,Numero,0).	
	
