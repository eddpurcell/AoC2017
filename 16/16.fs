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

: quick-dance ( programs -- programs )
	dup 0 program-addr c@ over scratch-addr 11 chars + c! \ a
	dup 1 program-addr c@ over scratch-addr 15 chars + c! \ b
	dup 2 program-addr c@ over scratch-addr 13 chars + c! \ c
	dup 3 program-addr c@ over scratch-addr 8 chars + c! \ d
	dup 4 program-addr c@ over scratch-addr 4 chars + c! \ e
	dup 5 program-addr c@ over scratch-addr 0 chars + c! \ f
	dup 6 program-addr c@ over scratch-addr 7 chars + c! \ g
	dup 7 program-addr c@ over scratch-addr 14 chars + c! \ h
	dup 8 program-addr c@ over scratch-addr 6 chars + c! \ i
	dup 9 program-addr c@ over scratch-addr 12 chars + c! \ j
	dup 10 program-addr c@ over scratch-addr 5 chars + c! \ k
	dup 11 program-addr c@ over scratch-addr 2 chars + c! \ l
	dup 12 program-addr c@ over scratch-addr 9 chars + c! \ m
	dup 13 program-addr c@ over scratch-addr 1 chars + c! \ n
	dup 14 program-addr c@ over scratch-addr 3 chars + c! \ o
	dup 15 program-addr c@ over scratch-addr 10 chars + c! \ p
	dup scratch-addr over 0 program-addr 16 move ;
