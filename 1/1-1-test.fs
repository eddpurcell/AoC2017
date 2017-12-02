: test-result ( n n -- )
	over = IF ." PASS" drop ELSE ." FAIL - " . ENDIF ;

." 1 1 ret-if-dup returns 1 1 "
1 1 ret-if-dup 1 test-result 1 test-result CR

." 1 2 ret-if-dup returns 1 0 "
1 2 ret-if-dup 0 test-result 1 test-result CR

." 1 1 1 1 1 4 sum-dups returns 4 "
1 1 1 1 1 4 sum-dups 4 test-result CR

." 2 1 1 2 2 4 sum-dups returns 3 "
2 1 1 2 2 4 sum-dups 3 test-result CR

." 4 1 2 3 4 4 sum-dups returns 0 "
4 1 2 3 4 4 sum-dups 0 test-result CR

." 9 9 1 2 1 2 1 2 9 8 sum-dups returns 9 "
9 9 1 2 1 2 1 2 9 8 sum-dups 9 test-result CR

