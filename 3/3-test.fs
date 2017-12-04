include ../test.fs
include 3.fs

." 12 get-i returns 2 "
12 get-i 2 test-result CR

." 23 get-i returns 2 "
23 get-i 2 test-result CR

." 25 get-i returns 2 "
25 get-i 2 test-result CR

." 12 calc2 returns 3 "
12 calc3 3 test-result CR

." 23 calc2 returns 2 "
23 calc3 2 test-result CR

." 26 calc2 returns 5 "
26 calc3 5 test-result CR

." 49 calc2 returns 6 "
49 calc3 6 test-result CR

." 1024 cale2 returns 31 "
1024 calc3 31 test-result CR

." 2 2 pos-at-coords returns 13 "
2 2 pos-at-coords 13 test-result CR

." -1 -2 pos-at-coords returns 22 "
-1 -2 pos-at-coords 22 test-result CR

." -1 2 pos-at-coords returns 16 "
-1 2 pos-at-coords 16 test-result CR

." 1 -2 pos-at-coords returns 24 "
1 -2 pos-at-coords 24 test-result CR

." 12 coords-of-pos returns 2 1 "
12 coords-of-pos 1 test-result 2 test-result CR

." 15 coords-of-pos returns 0 2 "
15 coords-of-pos 2 test-result 0 test-result CR

." 18 coords-of-pos returns -2 1 "
18 coords-of-pos 1 test-result -2 test-result CR

." 25 coords-of-pos returns 2 -2 "
25 coords-of-pos -2 test-result 2 test-result CR

." 24 coords-of-pos returns 1 -2 "
24 coords-of-pos -2 test-result 1 test-result CR

." 13 coords-of-pos returns 2 2 "
13 coords-of-pos 2 test-result 2 test-result CR

." 17 coords-of-pos returns -2 2 "
17 coords-of-pos 2 test-result -2 test-result CR

." 21 coords-of-pos returns -2 -2 "
21 coords-of-pos -2 test-result -2 test-result CR

." 10 calc-value-of-position returns 26 "
10 calc-value-of-position 26 test-result CR

." 25 first-value-over returns 10 26 "
25 first-value-over 26 test-result 10 test-result CR

." 747 first-value-over returns 23 806 "
747 first-value-over 806 test-result 23 test-result CR

