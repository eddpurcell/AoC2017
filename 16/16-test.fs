include ../test.fs
include 16.fs

5 programs: dancers
." 5 programs: dancers creates programs abcde "
dancers 0 program-addr c@ 'a test-result
dancers 1 program-addr c@ 'b test-result
dancers 2 program-addr c@ 'c test-result
dancers 3 program-addr c@ 'd test-result
dancers 4 program-addr c@ 'e test-result CR
dancers print-programs CR

." dancers 1 s returns eabcd "
dancers 1 s program-str s" eabcd" compare 0 test-result CR

." dancers 3 4 x returns eabdc "
dancers 3 4 x program-str s" eabdc" compare 0 test-result CR

." dancers 'a index-of returns 1 "
dancers 'a index-of 1 test-result CR

." dancers 'e 'b p returns baedc "
dancers 'e 'b p program-str s" baedc" compare 0 test-result CR

: quick-dance ( dancers -- dancers )
	dup 0 program-addr c@ over scratch-addr 1 chars + c!
	dup 1 program-addr c@ over scratch-addr 0 chars + c!
	dup 2 program-addr c@ over scratch-addr 4 chars + c!
	dup 3 program-addr c@ over scratch-addr 3 chars + c!
	dup 4 program-addr c@ over scratch-addr 2 chars + c!
	dup scratch-addr 5 cr type
	dup scratch-addr over 0 program-addr 5 move ;

." dancers quick-dance returns ceadb "
dancers quick-dance program-str s" ceadb" compare 0 test-result CR
dancers print-programs
