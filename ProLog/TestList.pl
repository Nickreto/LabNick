%Программа на пролог
:- initialization(main,main).
%База знаний
%CLAUSES
% Запуск процесса
% Запуск процесса
read_elements(ListN) :-
	write('Введите количество элементов:'),
	read(Count),
	writeln('Вводите элементы:'),
	whileCount(ListN,Count).
% Если ввели stop, список заканчивается
whileCount([],0).
whileCount([Input|Tail],Count) :-
	Count > 0,
	read(Input), Count1 is Count - 1,
	whileCount(Tail,Count1).
%Rules
main :-
        write("Введите натуральные числа для подсчёта НОД"),nl,
        write("Не забудьте точку после введённого числа!"),nl,
        read_elements(List),
	write(List).
	
