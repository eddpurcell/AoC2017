include 7-vars.fs
include list.fs

: child! ( child addr -- )
	1 cells + new-addr-node ;

: child@ ( n addr -- )
	1 cells + swap ?do
		list-next @
	loop addrlist-addr @ ;

