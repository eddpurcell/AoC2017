: interleave ( addr1 n1 addr2 n2 buffAddr -- buffAddr )
	{ buffer }
	drop swap ( addr1 addr2 n1 -- assume same size strings )
	0 ?DO
		( buffAddr addr1 addr2 )
		over i + c@ buffer i 2 * + !
		dup i + c@ buffer i 2 * 1 + + ! 
	LOOP
	2drop
	buffer
;
