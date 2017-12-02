: ret-if-dup ( n n -- n n' )
	2dup <> IF drop 0 ENDIF ;

: sum-dups ( nlast n... len -- sum )
	0 ( sum )
	BEGIN
	2swap ret-if-dup ( len sum n n' )
	rot + ( len n sum )
	rot 1 - swap ( n len' sum )
	over 0=
	UNTIL
	nip nip ;
