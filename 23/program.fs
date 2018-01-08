include 23.fs

_ b 99 set _ c b @ set _ a 2 jnz _ 1 5 jnz _ b 100 mul _ b -100000 sub _ c b @ set _ c -17000 sub _ f 1 set _ d 2 set _ e 2 set _ g d @ set _ g e @ mul _ g b @ sub _ g 2 jnz _ f 0 set _ e -1 sub _ g e @ set _ g b @ sub _ g -8 jnz _ d -1 sub _ g d @ set _ g b @ sub _ g -13 jnz _ f 2 jnz _ h -1 sub _ g b @ set _ g c @ sub _ g 2 jnz _ 1 3 jnz _ b -17 sub _ 1 -23 jnz 

#mul . cr

: is-prime ( n -- true|false)
	dup 2/ 2 ?do
		dup i mod 0= if drop false unloop exit endif
	loop drop true ;

: shortcut ( -- n )
	0 126901 109900 ?do
		i is-prime invert abs +
	17 +loop ;

shortcut .
