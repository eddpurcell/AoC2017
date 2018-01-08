: PARTICLE: create , , , , , , , , , ;
                 \ 0 1 2|3 4 5|6 7 8

: update-vel ( particle -- particle )
	dup 3 cells + @ over 6 cells + @ + over 3 cells + ! 
	dup 4 cells + @ over 7 cells + @ + over 4 cells + ! 
	dup 5 cells + @ over 8 cells + @ + over 5 cells + ! ;

: update-pos ( particle -- particle )
	dup 0 cells + @ over 3 cells + @ + over 0 cells + !
	dup 1 cells + @ over 4 cells + @ + over 1 cells + !
	dup 2 cells + @ over 5 cells + @ + over 2 cells + ! ;

: pmove ( particle -- )
	update-vel update-pos drop ;

: manhattan-dist ( particle -- n )
	dup @ abs over 1 cells + @ abs rot 2 cells + @ abs + + ;

: print-particle ( particle -- "..." )
	cr ." p=<" dup @ . dup 1 cells + @ . dup 2 cells + @ . ." >, "
	." v=<" dup 3 cells + @ . dup 4 cells + @ . dup 5 cells + @ . ." >, "
	." a=<" dup 6 cells + @ . dup 7 cells + @ . dup 8 cells + @ . ." >" drop ;
