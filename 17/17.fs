create buff 2018 cells allot
0 value curr-ind

: reset 0 to curr-ind 2019 0 ?do 0 buff i cells + ! loop ;
reset

: shift { n ind -- }
	buff ind cells + buff ind cells + cell+ n 1+ cells move ;

: spin-round { steps i -- }
	curr-ind steps + i mod 1+ to curr-ind
	curr-ind i over - swap shift
	i buff curr-ind cells + ! ;

: spin-lock ( steps runs -- )
	1 ?do
		curr-ind over + i mod 1+ to curr-ind
		curr-ind i over - swap shift
		i buff curr-ind cells + !
	loop drop ;

: print
	10 0 ?do
		i curr-ind = if '( emit endif
		buff i cells + @ .
		i curr-ind = if ') emit endif
	loop ;

0 value after0
: after-0 ( steps runs -- ind1 )
	1 ?do
		curr-ind over + i mod 1+ to curr-ind
		curr-ind 1 = if
			i to after0
		endif
	loop ;
