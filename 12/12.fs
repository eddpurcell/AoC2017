create seen-nodes 2000 cells allot

: setup ( grid len -- )
	dup 0 ?do
		false seen-nodes i cells + !
	loop
	dup * 0 ?do ( addr )
		false over i cells + !
	loop drop ;

: !edge ( grid end start len -- )
	* + cells + true tuck drop ! ;

: ?seen ( node -- true|false )
	seen-nodes swap cells + @ ;

: seen ( node -- )
	true swap seen-nodes swap cells + ! ;

: size-of-group ( grid len node -- size )
	dup seen
	over * ( grid len rowOff )
	1 2 pick 0 ?do ( grid len rowOff count )
		3 pick 2 pick ( grid len rowOff count grid rowOff )
		i + cells + @ ( grid len rowOff count ?edge )
		if
			i ?seen invert if
				3 pick 3 pick ( grid len rowOff count+1 grid len )
				i recurse +
				i seen
			endif
		endif ( grid len rowOff count' )
	loop nip nip nip ;

: #groups ( grid len -- n )
	0 over 0 ?do ( grid len count )
		i ?seen invert if
			1+
			2 pick 2 pick i size-of-group drop
		endif
	loop nip nip ;

: print-grid ( grid len -- )
	dup 0 2dup ?do
		2dup
		CR ?do ( grid len len 0 )
			3 pick 3 pick j * i + cells + @ -1 * .
		loop
	loop 2drop 2drop ;

