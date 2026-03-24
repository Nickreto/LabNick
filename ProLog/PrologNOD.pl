:- initialization(main,main).
%
get_nod(Value,0):-write(Value).
get_nod(Big,Small):-
	Remainder is Big mod Small,
	get_nod(Small,Remainder).
%
main :-
	write("Введите натуральные числа для подсчёта НОД"),nl,
	write("Не забудьте точку после введённого числа!"),nl,
	write("Первое число="),
	read(First),
	write("Второе число="),
	read(Second),
	get_nod(First,Second),nl.
