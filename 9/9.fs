0 value currValue
0 value score
0 value garbageCount

: { ( -- )
	currValue 1+ to currValue
	score currValue + to score ;

: , ( -- )
	;

: } ( -- )
	currValue 1- to currValue ;

: < ( -- )
	begin
	parse-word drop c@ '>' <>
	while
	garbageCount 1+ to garbageCount
	repeat ;

: reset ( -- )
	0 to currValue 0 to score 0 to garbageCount ;
