struct
	cell% field list-next
end-struct list%

list%
	cell% field addrlist-addr
end-struct addrlist%

: addr+ ( addr list -- )
	addrlist-addr ! ;

: new-addr-node ( addr list -- list' )
	addrlist% %allot swap list-next ! 
	2dup addrlist-addr ! tuck ;

