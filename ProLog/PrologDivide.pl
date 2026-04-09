:- initialization(main,main).
%Функция вычитает список из другого, элементы уникальны
subL([],_,Lilo,Lilo).
subL([Head|Tail],List2,ListOut,Lilo):-
	(member(Head,List2) 
	-> subL(Tail,List2,ListOut,Lilo)
	; subL(Tail,List2,[Head|ListOut],Lilo)).


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
	subL(List1,List2,[],Ll),
	writeln("Результат вычитания:"),
	write(Ll),nl.
