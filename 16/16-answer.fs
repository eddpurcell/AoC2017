include setup.fs

." The end order is: " dancers dance print-programs CR
: mega-dance ( dancers loop -- dancers )
	0 ?do
		dance
	loop ;
: find-cycle ( dancers -- dancers loop )
	100 0 ?do
		dance
		dup program-str s" abcdefghijklmnop" compare 0= if
			i 1 + ." found loop after: " . CR i 1+
			unloop exit endif
	loop ;
16 programs: dancers-fresh
dancers-fresh find-cycle 1000000000 swap mod dup . mega-dance
CR ." The end order of the mega-dance is: " print-programs
