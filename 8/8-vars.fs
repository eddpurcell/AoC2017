
create axi 0 ,
create b 0 ,
create c 0 ,
create djl 0 ,
create gr 0 ,
create j 0 ,
create jb 0 ,
create kps 0 ,
create kq 0 ,
create kyh 0 ,
create l 0 ,
create mp 0 ,
create o 0 ,
create px 0 ,
create q 0 ,
create rz 0 ,
create s 0 ,
create tup 0 ,
create txk 0 ,
create ug 0 ,
create vhu 0 ,
create wdc 0 ,
create x 0 ,
create xhe 0 ,
create y 0 ,
create zeq 0 ,

: print-registers
	CR s" axi = " type axi @ .
	CR s" b = " type b @ .
	CR s" c = " type c @ .
	CR s" djl = " type djl @ .
	CR s" gr = " type gr @ .
	CR s" j = " type j @ .
	CR s" jb = " type jb @ .
	CR s" kps = " type kps @ .
	CR s" kq = " type kq @ .
	CR s" kyh = " type kyh @ .
	CR s" l = " type l @ .
	CR s" mp = " type mp @ .
	CR s" o = " type o @ .
	CR s" px = " type px @ .
	CR s" q = " type q @ .
	CR s" rz = " type rz @ .
	CR s" s = " type s @ .
	CR s" tup = " type tup @ .
	CR s" txk = " type txk @ .
	CR s" ug = " type ug @ .
	CR s" vhu = " type vhu @ .
	CR s" wdc = " type wdc @ .
	CR s" x = " type x @ .
	CR s" xhe = " type xhe @ .
	CR s" y = " type y @ .
	CR s" zeq = " type zeq @ . ;

: max-register ( -- )
	0 ( maxval )
	axi @ max
	b @ max
	c @ max
	djl @ max
	gr @ max
	j @ max
	jb @ max
	kps @ max
	kq @ max
	kyh @ max
	l @ max
	mp @ max
	o @ max
	px @ max
	q @ max
	rz @ max
	s @ max
	tup @ max
	txk @ max
	ug @ max
	vhu @ max
	wdc @ max
	x @ max
	xhe @ max
	y @ max
	zeq @ max
;
