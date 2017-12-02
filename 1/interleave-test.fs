include interleave.fs

: print ( addr n -- )
	0 ?do
		dup i + c@ emit
	loop
	drop
;

create result 8 chars allot

s" 1234" s" abcd" result interleave
8 print
