include ../test.fs
include 15.fs

." 65 8921 run-round returns 1092455 430625591 "
65 8921 run-round 430625591 test-result 1092455 test-result CR

." 245556042 1431495498 judge returns true "
245556042 1431495498 judge true test-result CR

." 65 8921 #matches returns 588 "
65 8921 #matches 588 test-result CR

." 4 8 mult!" CR
4 8 mult!
5000000 to rounds

." 65 8921 run-round returns 1352636452 1233683848 "
65 8921 run-round 1233683848 test-result 1352636452 test-result CR 

." 65 8921 #matches returns 309 "
65 8921 #matches 309 test-result CR

