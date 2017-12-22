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

CR create input '1' c, ',' c, '2' c, ',' c, '3' c,
input 5 hash here dup 16 cells allot dense-hash
hex dup @ .
dup 1 cells + @ .
dup 2 cells + @ .
dup 3 cells + @ .
dup 4 cells + @ .
dup 5 cells + @ .
dup 6 cells + @ .
dup 7 cells + @ .
dup 8 cells + @ .
dup 9 cells + @ .
dup a cells + @ .
dup b cells + @ .
dup c cells + @ .
dup d cells + @ .
dup e cells + @ .
dup f cells + @ .
