%Программа на пролог
:- initialization(main,main).
%База знаний
%CLAUSES
get_nod(value,0):-write(value).
get_nod(big,small):-remainder is big mod small,get_nod(small,remainder).
%Rules
main :-
	write("Введите натуральные числа для подсчёта НОД"),nl,
	write("Не забудьте точку после введённого числа!"),nl,
	write("Большее число="),read(big),
	write("Меньшее число="),read(small),
	get_nod(big,small),nl.
