create map 40401 chars allot

202 constant max-line
create line-buffer max-line 2 + allot

s" input.txt" r/o open-file throw value fd-in
0 value steps

: setup ( -- )
	40401 0 ?do 32 map i + c! loop ;
setup

: create-map ( -- )
	201 0 ?do
		line-buffer max-line fd-in read-line throw drop
		0 ?do
			line-buffer i chars + c@ map j 201 * i + + c!
		loop
		\ cr map i 201 * chars + 201 type
	loop ;

create-map

: turn { x y d -- x' y' d' }
	d 2 mod 0= if
		map x 1- y 201 * + + c@ '- = if x 1- y 1 else x 1+ y 3 endif
	else map x y 1- 201 * + + c@ '| = if x y 1- 2 else x y 1+ 0 endif
	endif ;

: mv { x y d -- x' y' d }
	d 2 mod 0= if x y d 1- - d
	else x d 2 - + y d endif ;

: walk ( x y d -- ) ( "letters" )
	begin
		map 3 pick 3 pick 201 * + + c@ ( x y d c@ )
		dup 32 <>
	while
		dup '- = over '| = or if drop mv
		else dup '+ = if drop turn
		else emit mv endif endif
		steps 1+ to steps
	repeat 2drop drop ;

map 115 + c@ emit

CR
." Letters on path: " 115 0 0 walk
CR ." # Steps: " steps .
