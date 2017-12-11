include ../test.fs
include 10.fs

5 setup

." 3 reverse returns [2,1,0,3,4]
3 reverse
buffer @ 2 test-result
buffer 1 cells + @ 1 test-result
buffer 2 cells + @ 0 test-result
buffer 3 cells + @ 3 test-result
buffer 4 cells + @ 4 test-result CR

5 setup
3 step
4 step
1 step
5 step

." Input 3,4,1,5 on a list of 5 returns 12 "
buffer @ buffer 1 cells + @ * 12 test-result CR .s

." No input prints correct dense hash "
s" " hash print-dense-hash
