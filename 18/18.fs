create linebuff 50 cells allot

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
	0 ?do
		goto-next-marker
	loop endif ;

variable last-sound

: snd ( n -- )
	last-sound ! ;

: set ( addr n -- )
	swap ! ;

: add ( addr n -- )
	over @ + swap ! ;

: mul ( addr n -- )
	over @ * swap ! ;

: mod ( addr n -- )
	over @ swap /mod drop swap ! ;

: rcv ( n -- "last-sound" )
	0<> if CR ." last-sound: " last-sound @ . endif ;

: jgz ( addr n -- )
	swap @ 0> if goto endif ;

