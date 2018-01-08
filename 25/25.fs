create tape 250000 chars allot
120000 value curr-ind
variable curr-state
\ a-0 b-1 c-2 d-3 e-4 f-5

: setup
	250000 0 ?do 0 tape i chars + c! loop ;
setup

: #1s ( -- n )
	0 250000 0 ?do tape i chars + c@ 1 = if 1+ endif loop ;

: tape@ ( -- c )
	tape curr-ind chars + c@ ;

: tape! ( c -- )
	tape curr-ind chars + c! ;

: mv-right
	curr-ind 1+ to curr-ind ;

: mv-left
	curr-ind 1- to curr-ind ;

: A
	tape@
	0= if 1 tape! mv-right 1 curr-state !
	else 0 tape! mv-left 1 curr-state ! endif ;

: B
	tape@
	0= if 0 tape! mv-right 2 curr-state !
	else 1 tape! mv-left 1 curr-state ! endif ;

: C
	tape@
	0= if 1 tape! mv-right 3 curr-state !
	else 0 tape! mv-left 0 curr-state ! endif ;

: D
	tape@
	0= if 1 tape! mv-left 4 curr-state !
	else 1 tape! mv-left 5 curr-state ! endif ;

: E
	tape@
	0= if 1 tape! mv-left 0 curr-state !
	else 0 tape! mv-left 3 curr-state ! endif ;

: F
	tape@
	0= if 1 tape! mv-right 0 curr-state !
	else 1 tape! mv-left 4 curr-state ! endif ;

: step
	curr-state @ dup 0= if A drop else 
	dup 1 = if B drop else
	dup 2 = if C drop else
	dup 3 = if D drop else
	dup 4 = if E drop else
	5 = if F endif endif endif endif endif endif ;

: diagnostic-checksum
	12629077 0 ?do step loop #1s ;

diagnostic-checksum .

