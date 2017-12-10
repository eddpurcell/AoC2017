: check-valid-in-line ( addr1 u1 ... addrn un n -- addr1 u1 ... true | false ) { addrn un n }
	n 0 ?do
		n 1- 2* 1- roll n 1- 2* 1- roll 2dup addrn un compare 0= if ." false" false unloop exit endif
	loop true ;

: check-line ( addr1 u1 ... addrn un n -- true | false )
	1- { n } n 0 swap 0 ?do
		drop
		2dup type CR
		n i - check-valid-in-line 
		0= if 
			n i - 0 ?do 2drop loop false 
			unloop exit else 0 endif
	loop
	drop 2drop true ;

: ?1 ( flag -- 1 | 0 ) if 1 else 0 endif ;

