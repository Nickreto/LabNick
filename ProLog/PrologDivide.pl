:- initialization(main,main).
:- discontiguous listSubstraction/3.
%Функция вычитает список из другого, элементы уникальны
listdel(List1,List2,ListOut):-
	listSubstraction(List1,List2,List3),
	listdel(List3,List2,ListOut)
listSubstraction([],_,[]).
listSubstruction([Head|Tail],List2,ListOut) :-
	member(Head,List2), !,
	listSubstraction(Tail,List2,ListOut).
listSubstraction([Head|Tail],List2, [Head|ListOut]):-
	listSubstraction(Tail,List2,ListOut).
%Функция ввода списка
readElements(ListN,Count) :-
        writeln('Вводите уникальные элементы:'),
        whileCount(ListN,Count).
whileCount([],0).
whileCount([Input|Tail],Count) :-
        Count > 0,
        read(Input), Count1 is Count - 1,
        whileCount(Tail,Count1).
%Главная функция
main :-
        write("Введите длину списков натуральными числами"),nl,
        write("Не забудьте точку после введённого числа!"),nl,
        write("Введите количество элементов первого списка:"),
        read(Count1),
	readElements(List1, Count1),
	write("Введите количество элементов второго списка:"),
	read(Count2),
	readElements(List2, Count2),
	listSubstruction(List1,List2,ListOut),
	write(ListOut).
