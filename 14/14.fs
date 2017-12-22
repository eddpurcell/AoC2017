include ../10/10.fs

create defrag-grid 2048 cells allot
create region-map 16384 cells allot
128 constant ROW_LENGTH

create x>1s 0 , 1 , 1 , 2 , 1 , 2 , 2 , 3 , 1 , 2 , 2 , 3 , 2 , 3 , 3 , 4 ,

: >binarymap ( ind -- )
	dup ROW_LENGTH * swap
	defrag-grid swap 16 * cells +
	16 0 ?do ( rowOff addr )
		dup i cells + @ ( rowOff addr hex )
		dup %10000000 and 0<> region-map 4 pick i 8 * 0 + + cells + ! ( rowOff addr hex ) 
		dup %01000000 and 0<> region-map 4 pick i 8 * 1 + + cells + ! ( rowOff addr hex ) 
		dup %00100000 and 0<> region-map 4 pick i 8 * 2 + + cells + ! ( rowOff addr hex ) 
		dup %00010000 and 0<> region-map 4 pick i 8 * 3 + + cells + ! ( rowOff addr hex ) 
		dup %00001000 and 0<> region-map 4 pick i 8 * 4 + + cells + ! ( rowOff addr hex ) 
		dup %00000100 and 0<> region-map 4 pick i 8 * 5 + + cells + ! ( rowOff addr hex ) 
		dup %00000010 and 0<> region-map 4 pick i 8 * 6 + + cells + ! ( rowOff addr hex ) 
		dup %00000001 and 0<> region-map 4 pick i 8 * 7 + + cells + ! ( rowOff addr hex ) 
		drop
	loop 2drop ;

: calc-row ( ind caddr u -- )
	hash defrag-grid over 16 * cells + dense-hash 
	>binarymap ;

: print-row ( row -- )
	defrag-grid swap 16 * cells +
	16 0 ?do
		dup i cells + @ hex . decimal
	loop drop ;

: print-binary ( row -- )
	region-map swap 128 * cells +
	8 0 ?do
		dup i cells + @ dup -1 = if 35 emit 32 emit drop
		else dup 0 = if 46 emit 32 emit drop else . endif endif
	loop drop ;

: write-hex ( n -- )
	dup $8 and 0<> if 1 else 0 endif .
	dup $4 and 0<> if 1 else 0 endif .
	dup $2 and 0<> if 1 else 0 endif .
	    $1 and 0<> if 1 else 0 endif . ;

: #used-row ( row -- n )
	defrag-grid swap 16 * cells +
	0
	16 0 ?do ( addr 1s )
		over i cells + @ ( addr 1s val )
		dup $000f and x>1s swap cells + @ swap ( addr 1s n1 val )
		$00f0 and 4 rshift x>1s swap cells + @ + + ( addr 1s' )
	loop nip ;

: #used ( -- n )
	0 128 0 ?do ( total )
		i #used-row +
	loop ;

: binary@ ( row col -- n )
	swap ROW_LENGTH * + region-map swap cells + @ ;

: expand-region ( row col n -- n )
	>r
	over ROW_LENGTH * over + r@ swap region-map swap cells + ! ( row col )
	over 1- dup 0 >= if over 2dup binary@ -1 = if r@ recurse drop else 2drop endif else drop endif
	over 1+ dup 128 < if over 2dup binary@ -1 = if r@ recurse drop else 2drop endif  else drop endif
	2dup 1- dup 0 >= if 2dup binary@ -1 = if r@ recurse drop else 2drop endif else 2drop endif
	1+ dup 128 < if 2dup binary@ -1 = if r@ recurse drop else 2drop endif else 2drop endif r> ;

: fill-regions ( -- n )
	0 128 0 ?do
		128 0 ?do
			j i 2dup binary@ -1 = if rot 1+ expand-region else 2drop endif
		loop
	loop ;

