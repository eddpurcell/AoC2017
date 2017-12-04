include ../test.fs
include 3.fs

." 12 get-i returns 2 "
12 get-i 2 test-result CR

." 23 get-i returns 2 "
23 get-i 2 test-result CR

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

1024 dup get-i normalize-deg f.
