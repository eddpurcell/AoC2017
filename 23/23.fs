0 value #mul

: goto-last-marker ( -- )
	>in @ 1- source drop swap
	begin
		2dup chars + c@ '_ <>
	while
		1-
	repeat
	>in ! drop ;

: goto-next-marker ( -- )
	>in @ 1+ source drop swap
	begin
		2dup chars + c@ '_ <>
	while
		1+
	repeat
	>in ! drop ;

: _ ; \ noop

: goto ( n -- )
	dup 0< if abs
	1+ 0 ?do
		goto-last-marker
	loop 
	else
	1- 0 ?do
		goto-next-marker
	loop endif ;

: set ( x y -- )
	swap ! ;

: sub ( x y -- )
	over @ swap - swap ! ;

: mul ( x y -- )
	over @ swap * swap !
	#mul 1+ to #mul ; \ cr #mul . ;

: jnz ( x y -- )
	swap dup 1 <> if @ endif 0<> if goto else drop endif ;

variable a 0 a !
variable b 0 b !
variable c 0 c !
variable d 0 d !
variable e 0 e !
variable f 0 f !
variable g 0 g !
variable h 0 h !
