include 8-test-vars.fs

0 value maxval
: == = ;
: inc ( addr n flag )
	if over @ swap + swap ! ( addr )
	else 2drop endif ;
: dec ( addr n flag )
	if over @ swap - swap ! ( addr )
	else 2drop endif ;

b 5 a @ 1 > inc CR .s
a 1 b @ 5 < inc
c -10 a @ 1 >= dec
c -20 c @ 10 == inc

CR .s
a @ b @ c @ CR .s

CR CR
maxval .

