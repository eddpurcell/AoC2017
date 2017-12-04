: sq ( x -- x^2 ) dup * ;
: fsq ( f -- f^2 ) fdup f* ;
: deg { x i -- rad } x 2 i * 1- sq - 0 d>f 3.1415e0 f* 4 i * 0 d>f f/ ;
: normalize-deg ( x i -- rad ) deg 1.57080e0 fmod ;
: normalize-deg2 ( x i -- rad ) deg 7.8539e-1 f+ 1.57080e0 fmod 7.8539e-1 f- ;
: get-i ( x -- i )
	0 begin
		1+ over over 2 * 1+ sq <=
	until nip ;

: dist-euclidean ( f -- H ) 1e0 fswap fcos f/ ;
: dist-x ( f -- fx ) fcos ;
: dist-y ( f -- fy ) fsin ;
: calc2 ( x -- dm )
	dup get-i normalize-deg 
	fdup dist-euclidean
	fswap fdup dist-y fsq
	fswap dist-x fsq f+ fsqrt f*
	fround f>d drop ;

: calc3 ( x -- dm )
	dup get-i 2* 1+ ( x i )
	dup 1- 2/ rot rot ( numR x i )
	2dup 2 - sq - ( numR x i cycle )
	over 1- mod ( numR x i innerOff )
	nip nip over - abs + ;

: nth-odd ( i -- n )
	2 * 1 + ;

create spiral 512 cells allot
1 spiral 1 cells + ! 1 spiral 2 cells + ! 2 spiral 3 cells + ! 4 spiral 4 cells + ! 5 spiral 5 cells + !
10 spiral 6 cells + ! 11 spiral 7 cells + ! 23 spiral 8 cells + ! 25 spiral 9 cells + !

: ring-axis-pos-s { i -- n }
	i nth-odd sq i - ;
: ring-axis-pos-w { i -- n }
	i nth-odd sq 3 i * - ;
: ring-axis-pos-n { i -- n }
	i nth-odd sq 5 i * - ;
: ring-axis-pos-e { i -- n }
	i nth-odd sq 7 i * - ;

: pos-at-coords ( x y -- n )
	2dup swap abs swap abs ( x y |x| |y| )
	> if swap dup 0> if ring-axis-pos-e + else abs ring-axis-pos-w swap - endif ( y axis-pos )
	else dup 0> if ring-axis-pos-n swap - else abs ring-axis-pos-s + endif ( x axis-pos )
	endif ;
: ring-corner-pos-ne { i -- n }
	i 1- nth-odd sq 2 i * + ;
: ring-corner-pos-nw { i -- n }
	i 1- nth-odd sq 4 i * + ;
: ring-corner-pos-sw { i -- n }
	i 1- nth-odd sq 6 i * + ;
: ring-corner-pos-se { i -- n }
	i 1- nth-odd sq 8 i * + ;
: coords-of-pos ( n -- x y )
	dup get-i swap
	over ring-corner-pos-ne over over <= if - swap dup rot + ( x y )
	else drop over ring-corner-pos-nw over over <= if swap - over -1 * + swap ( x y )
	else drop over ring-corner-pos-sw over over <= if swap - over -1 * + swap -1 * swap ( x y )
	else drop over ring-corner-pos-se over over <= if - over + swap -1 * ( x y ) 
	endif endif endif endif ;
: pos! ( x n -- )
	spiral swap cells + ! ;
: pos@ ( n -- x )
	spiral swap cells + @ ;
: calc-value-of-position ( n -- )
	0 over pos! 0 ( n sum )
	over dup coords-of-pos ( n sum n x y )
	swap 1 - swap 1 - pos-at-coords ( n sum n n' ) min pos@ + ( n sum' )
	over dup coords-of-pos
	swap 1 - swap pos-at-coords min pos@ +
	over dup coords-of-pos
	swap 1 - swap 1 + pos-at-coords min pos@ +
	over dup coords-of-pos
	1 + pos-at-coords min pos@ +
	over dup coords-of-pos
	swap 1 + swap 1 + pos-at-coords min pos@ + 
	over dup coords-of-pos
	swap 1 + swap pos-at-coords min pos@ +
	over dup coords-of-pos
	swap 1 + swap 1 - pos-at-coords min pos@ +
	over dup coords-of-pos
	1 - pos-at-coords min pos@ + nip ( sum ) ;

: first-value-over ( x -- n )
	10 swap
	begin
		over calc-value-of-position
		over over >=
	while
		rot tuck pos!
		1+ swap
	repeat
	nip ;
