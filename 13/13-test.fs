include ../test.fs
include 13.fs

setup

3 0 !range
2 1 !range
4 4 !range
4 6 !range

." 0 run returns 24 "
0 run 24 test-result CR

." 3 2 4 4 * * * first-no-caught-delay returns 10 "
3 2 4 4 * * * first-no-caught-delay 10 test-result CR
