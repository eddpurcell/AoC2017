: PROGRAMS: ( n ) dup dup CREATE , 0 ?do 97 i + c, loop chars allot ;

: scratch-addr ( programs -- addr )
	dup @ chars + cell+ ;

: program-addr ( programs ind -- addr )
	chars + cell+ ;

: program-str ( programs -- caddr u )
	dup @ swap cell+ swap ;

: print-programs
	dup @ swap cell+ swap type ;

: s { programs n -- programs }
	programs programs @ n - program-addr ( addr )
	programs scratch-addr ( addr scratch )
	n move 
	programs 0 program-addr
	programs scratch-addr n chars +
	programs @ n - move
	programs scratch-addr programs cell+ programs @ move
	programs ;

: x ( programs a b -- programs )
	>r 2dup program-addr c@ ( programs a a@) 2 pick scratch-addr c! ( programs a )
	2dup over r@ program-addr c@ ( programs a programs a b@ ) -rot program-addr c! ( programs a )
	drop dup scratch-addr c@ ( programs a@ ) over r> program-addr c! ( programs ) ;

: index-of ( programs a@ -- n )
	over @ 0 ?do
		over i program-addr c@ over =
		if 2drop i unloop exit endif
	loop ;

: p ( programs a@ b@ -- programs )
	>r over swap index-of ( programs a )
	over r> index-of ( programs a b )
	x ;

