: travel-stack ( n... len -- steps ) { len } \ broken on inputs bigger than 951...
	len 1- roll 0 0 ( ind steps )
	begin
		CR .s
		>r >r
		dup 1+ swap .s
		dup r@ + len <
	while
		dup 0< if len + endif dup >r 0 CR .s ?do len 1- roll loop r> r> + r> 1+ .s 
	repeat r> drop r> 1+ ;

: travel { addr len -- steps }
	0 0 ( ind steps )
	begin
		>r >r
		addr r@ cells + @
		dup 1+ addr r@ cells + !
		dup r@ + len <
	while
		r> + r> 1+
	repeat r> drop r> 1+ ;

: travel2 { addr len -- steps }
	0 0 ( ind steps )
	begin
		>r >r
		addr r@ cells + @ \ get value at index
		dup dup 3 >= if 1- else 1+ endif addr r@ cells + ! \ write new value
		dup r@ + len <
	while
		r> + r> 1+
	repeat r> drop r> 1+ ;

