0 value max-dist

: 3dup { x y z -- x y z x y z }
	x y z x y z ;

: manhattan-distance ( n ne se -- d )
	abs swap abs + swap abs + 2 / ;

: n { x y z -- x' y z }
	x y 1+ z 1- 
	3dup manhattan-distance max-dist max to max-dist ;

: s { x y z -- x y' z }
	x y 1- z 1+
	3dup manhattan-distance max-dist max to max-dist ;

: ne { x y z -- x y z' }
	x 1+ y z 1-
	3dup manhattan-distance max-dist max to max-dist ;

: sw { x y z -- x' y z }
	x 1- y z 1+
	3dup manhattan-distance max-dist max to max-dist ;

: nw { x y z -- x y' z }
	x 1- y 1+ z
	3dup manhattan-distance max-dist max to max-dist ;

: se { x y z -- x y z' }
	x 1+ y 1- z
	3dup manhattan-distance max-dist max to max-dist ;

: print-bearings ( n ne se -- n ne se )
	CR ." Bearings:"
	CR ." N: " rot dup .
	CR ." NE: " rot dup .
	CR ." SE: " rot dup . ;

