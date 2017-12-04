: sq ( x -- x^2 ) dup * ;
: fsq ( f -- f^2 ) fdup f* ;
: deg { x i -- rad } x 2 i * 1- sq - 0 d>f 3.1415e0 f* 4 i * 0 d>f f/ ;
: normalize-deg ( x i -- rad ) deg 1.57080e0 fmod ;
: normalize-deg2 ( x i -- rad ) deg 7.8539e-1 f+ 1.57080e0 fmod 7.8539e-1 f- ;
: get-i ( x -- i )
	0 begin
		1+ over over 2 * 1+ sq <
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

