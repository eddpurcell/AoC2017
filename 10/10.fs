create buffer 256 cells allot
0 value size
0 value pos
0 value skip

: print-buffer ( -- )
	CR size 0 ?do buffer i cells + @ . ." , " loop ;

: setup ( n -- )
	256 min dup to size 0 ?do i buffer i cells + ! loop ;

: reverse { len -- }
	len 0 ?do buffer pos i + size mod cells + @ loop
	len 0 ?do buffer pos i + size mod cells + ! loop ;	

: step ( len -- )
	dup reverse
	pos skip + + size mod to pos
	skip 1+ to skip ;

: round ( caddr len -- )
	0 ?do
		dup i + c@ step
	loop 
	drop 17 step 31 step 73 step 47 step 23 step ;

: hash ( caddr len -- )
	256 setup
	0 to pos
	0 to skip
	64 0 ?do
		2dup round
	loop 2drop ;

: dense-hash ( addr -- )
	16 0 ?do
		0
		16 0 ?do
			buffer i j 16 * + cells + @ xor
		loop
		over i cells + !
	loop drop ;

: print-dense-hash ( -- )
	16 0 ?do
		decimal
		0
		16 0 ?do
			buffer i j 16 * + cells + @ xor
		loop
		hex s>d <<# # #s #> type #>>
	loop decimal ;
	
