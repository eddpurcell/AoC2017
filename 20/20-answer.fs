include 20.fs
include particles.fs

: run ( n -- )
	0 ?do
		step-all
	loop ;

10000 run shortest-dist
." Closest particle: " closest-particle @ -2 cells + >name name>string type
