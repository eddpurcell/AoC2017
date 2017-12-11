: #children ( parent -- n )
	2 cells + @ ;

: parent! ( parent child -- )
	2dup 1 cells + ! 
	over dup #children 3 + cells + ! ( parent )
	dup #children 1+ swap 2 cells + ! ; 

: parent@ ( child -- parent )
	1 cells + @ ;

: child@ ( node n -- )
	3 + cells + @ ;

: weight@ ( node -- weight )
	@ ;

: find-root ( node -- root )
	begin
		dup parent@ 0<>
	while
		parent@
	repeat ;
	
: total-weight ( node -- weight )
	0 over ( node total node )
	#children 0 ?do ( node total )
		over i child@ ( node total child )
		recurse + ( node total' )
	loop swap weight@ + ;

: sort ( addr i -- ) { len }
	len 1- 0 ?do
		len 1- 0	
		?do ( addr )
			dup dup i cells + @ ( addr val1 )
			over i 1+ cells + @ ( addr val1 val2 )
			2dup > if ( addr val1 val2 )
				rot swap over ( val1 addr val2 addr )
				i cells + !
				i 1+ cells + !
			else
				2drop drop
			endif
		loop
	loop drop ;

: odd-number-out ( n1 ... ni i -- common odd )
	here over allot ( n1 ... ni i addr )
	over 0 ?do
		rot over ( n1 ... i addr nx addr )
		i cells + ! ( n1 ... nx-1 i addr )
	loop ( i addr )
	swap 2dup sort ( addr i )
	over dup 1 cells + @ swap @ ( addr i val1 val0 )
	= if
		2dup 1- cells + @ ( addr i odd-out )
		>r
		over @ >r \ common number
		-1 * allot drop
		r> r> ( common odd )
	else
		over @ >r ( addr i ) ( r odd-out )
		over 1 cells + @ >r ( addr i ) ( r odd-out common )
		-1 * allot drop
		r> r> ( common odd )
	endif ;

: find-child-with-total-weight ( root tot -- child )
	over #children 0 ?do
		over i child@ total-weight ( root tot childTot )
		over = if drop i child@ unloop exit endif
	loop ;

: find-balance-weight ( prevDiff root -- new-weight )
	begin
	{ rt }
	rt dup #children 0 ?do ( prevDiff root )
		dup i child@ total-weight swap
	loop ( prevDiff w1 ... wn root )
	#children odd-number-out ( prevDiff common odd )
	rt #children 2 = if
		CR ." two children case"
		rot ( common odd prevDiff ) dup 0< if
			rot rot ( prev common odd )
			max 2dup +
		else rot rot min 2dup -
		endif
	endif
	2dup <> 
	while 
		dup rt ( prevDiff common odd odd root )
		swap find-child-with-total-weight ( prevDiff common odd child )
		swap rot ( prevDiff child odd common ) - ( prevDiff child newDiff )
		rot drop swap ( newDiff child )
	repeat 2drop rt @ swap - ;

