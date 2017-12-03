: min 2dup < 1+ roll nip ; ( need if-less min )
: max 2dup > 1+ roll nip ; ( need if-less max )

: record ( -1 n... -- checksum )
	dup dup ( n...  mn mx )
	begin rot dup -1 <> while
	dup 3 roll min swap
	dup 3 roll max swap drop ( -1 ... n_i-1 )
	repeat drop - ;

: find-divisible-value { addr len n ind -- 0 | checksum }
	len 0 ?do
		i 0<> if drop endif
		i ind <> if
		addr i cells + @ n 2dup < if swap endif
		mod ( remainder )
		0= if addr i cells + @ n / unloop exit else 0 endif
		else 0
		endif
	loop ;

: fill-array ( n... addr len -- )
	0 ?do
		swap over i + !
	loop ;

: record-divisible-value ( addr len -- checksum )
	dup 0 ?do
		2dup over i cells + @ i find-divisible-value ( 0 | checksum )
		dup 0<> if nip nip unloop exit else drop endif
	loop ;

