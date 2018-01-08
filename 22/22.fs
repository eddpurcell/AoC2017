s" input.txt" r/o open-file throw value fd-in

256 constant max-line
create line-buffer max-line 2 + allot

create grid 16777216 cells allot
2047 constant center
4096 constant row-length
0 value caused-infections

: setup
	16777216 0 ?do 0 grid i cells + ! loop ;
	0 to caused-infections
setup

: scan-file ( -- )
	0
	begin
		line-buffer max-line fd-in read-line throw
	while
		0 ?do ( n )
			line-buffer i + c@ '. =
			if 0 grid 2 pick center + row-length * i center + + cells + !
			else -1 grid 2 pick center + row-length * i center + + cells + ! endif
		loop
		1+
	repeat 2drop ;
scan-file

: print-grid { x y -- }
	center 30 + center 5 - ?do
		center 30 + center 5 - ?do
			j y = i x = and if '@ emit else
			grid j row-length * i + cells + @ 
			dup -1 = if drop '# emit 
			else dup 0 = if drop '. emit 
			else dup 1 = if drop 'W emit 
			else drop 'F emit endif endif endif endif
		loop cr
	loop ;
\ center 1 + center 1 + print-grid
\ 255 255 print-grid

: step { x y d -- x' y' d' }
	d grid y row-length * x + cells + @ 
	if 1+ \ infected 
	else 1- caused-infections 1+ to caused-infections endif 4 mod ( d' )
	dup 2 mod 0= if y over 1- - x swap rot ( x' y' d' )
	else x over 2 - + y rot ( x' y' d' ) endif
	grid y 256 * x + cells + @ invert grid y 256 * x + cells + ! ;

: turn ( d n -- d' )
	dup 0= if drop 1- ( d' ) \ clean
	else dup 1 = if drop ( d ) \ weakened
	else dup -1 = if drop 1+ ( d' ) \ infected
	else ( d 2 ) drop 2 + endif endif endif \ flagged
	4 mod ;

: modify ( n -- n' )
	dup 0= if drop 1 ( n' ) \ clean
	else dup 1 = if drop -1 \ weakened
	caused-infections 1+ to caused-infections
	else dup -1 = if drop 2 \ infected
	else drop 0 endif endif endif ; \ flagged

: step2 { x y d -- x' y' d' }
	d grid y row-length * x + cells + @ turn ( d' )
	dup 2 mod 0= if y over 1- - x swap rot ( x' y' d' )
	else x over 2 - + y rot ( x' y' d' ) endif
	grid y row-length * x + cells + @ modify grid y row-length * x + cells + ! ;

: run ( x y d n -- x' y' d' )
	3 pick 3 pick print-grid
	0 ?do
		i 1000000 mod 0= if '. emit endif
		step2
	loop ;

\ 116 116 2
\ 255 255 2
center 12 + center 12 + 2
\ 100 run .s drop print-grid
10000000 run .s drop print-grid
." Caused infections: " caused-infections .
