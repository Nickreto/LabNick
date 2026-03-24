:- initialization(main,main).
%
solution([A,N,V,G,D]) :-
	member(A, [yes, no]),
	member(N, [yes, no]),
	member(V, [yes, no]),
	member(G, [yes, no]),
	member(D, [yes, no]),
	% Если А с D пришли, то N должен присутсвовать
	( A = yes, D = yes -> N = yes ; true ),
	% Если D отсутсвует, то N должен прийти, а V должен отсутсвовать
	( D = no -> (N = yes, V = no) ; true ),
	% A и V не могут одновременно отсутсвовать или присутствовать
	A \= V,
	% Если прийдёт D, то G должен отсутствовать
	( D = yes -> G = no ; true ),
	% Если N и V отсутствуют, то D должен присутствовать
	( N = no, V = no -> D = yes ; true ),
	% Если V присутствует, а N отсутствует, то D должен отсутствовать,
	% а G должен прийти
	( N = no, V = yes -> (D = no, G = yes) ; true ).
outLists([],[]).
outLists([Head1|Tail1],[Head2|Tail2]):-
	write(Head1),
	write(" - "),
	write(Head2),nl,
	outLists(Tail1,Tail2).


main :-
	solution(List),
	outLists(['Андрей','Николай','Виктор','Григорий','Дмитрий'],List),nl.
	
