create ranges 100 cells allot
create curr 100 cells allot
create dir 100 cells allot
create resetCurr 100 cells allot
create resetDir 100 cells allot

: setup ( -- )
	100 0 ?do
		0 ranges i cells + !
		0 curr i cells + !
		0 dir i cells + !
	loop ;

: !range ( range ind -- )
	tuck ranges swap cells + !
	1 swap dir swap cells + ! ;

: @range ( ind -- range )
	ranges swap cells + @ ;

: @curr ( ind -- n )
	curr swap cells + @ ;

: !curr ( n ind -- )
	curr swap cells + ! ;

: @dir ( ind -- n )
	dir swap cells + @ ;

: change-dir ( ind -- )
	dup @dir -1 * swap dir swap cells + ! ;

: reset ( -- )
	100 0 ?do
		0 i !curr
		i @range 0<> if 1 dir i cells + ! endif
	loop ;

: step ( -- )
	100 0 ?do
		i @curr i @dir + dup i !curr ( curr' )
		dup 0= swap i @range 1- = or if
			i change-dir
		endif
	loop ;

: caught-multiplier ( ind -- 0|1 )
	dup @range swap @curr 0= abs min ;

: print-curr ( -- )
	CR 10 0 ?do i @curr . loop ;

: run ( pre-steps -- severity )
	0 99 0 ?do ( severity )
		step
		i 1+ caught-multiplier i 1+ * i 1+ @range * + ( severity' )
	loop ;

: wait ( pre-steps -- )
	0 ?do
		step
	loop ;

: update-reset-values ( -- )
	100 0 ?do
		i @curr resetCurr i cells + !
		i @dir resetDir i cells + !
	loop ;

: reset-to ( -- )
	100 0 ?do
		resetCurr i cells + @ i !curr
		resetDir i cells + @ dir i cells + !
	loop ;

: first-no-caught-delay ( permutations -- )
	reset
	update-reset-values
	1 ?do
		reset-to
		1 wait
		update-reset-values
		0 @curr 0<> if
			run ( severity )
			0= if i unloop exit endif
		endif
	loop ;

