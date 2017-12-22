16807 constant factor-a
48271 constant factor-b
2147483647 constant maxint
$ffff constant judge-area

40000000 value rounds
1 value mult-a
1 value mult-b

: run-a ( n -- n' )
	begin
		factor-a * maxint mod
		dup mult-a mod 0<>
	while
	repeat ;

: run-b ( n -- n' )
	begin
		factor-b * maxint mod
		dup mult-b mod 0<>
	while
	repeat ;

: run-round ( a b -- a' b' )
	swap run-a swap run-b ;

: judge ( a b -- f )
	judge-area and swap judge-area and = ;

: #matches ( a b -- n )
	0 rounds 0 ?do ( a b n )
		>r run-round 2dup judge
		if r> 1+ else r> endif
	loop nip nip ;

: mult! ( a b -- )
	to mult-b to mult-a ;

