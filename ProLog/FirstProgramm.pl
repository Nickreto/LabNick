%Программа на пролог
:- initialization(main,main).
%База знаний
%CLAUSES
get_nod(X,0):-write(X).
get_nod(X,Y):-H is X mod Y,get_nod(Y,H).
%Rules
main :-
	write("Введите натуральные числа для подсчёта НОД"),nl,
	write("Не забудьте точку после введённого числа!"),nl,
	write("X="),read(X),
	write("Y="),read(Y),
	get_nod(X,Y),nl.
