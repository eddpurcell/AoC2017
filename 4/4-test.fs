include 4.fs
include ../test.fs

s" test1" s" test2" s" test1"
." test1 test2 test1 returns false "
3 check-valid-in-line false test-result 2drop 2drop  CR

s" test1" s" test2" s" test3"
." test1 test2 test3 returns true "
3 check-valid-in-line true test-result 2drop 2drop  CR

s" test1" s" test2" s" test1" s" test3"
." test1 test2 test1 test3 returns false "
4 check-line false test-result CR

s" test1" s" test2" s" test3"
." test1 test2 test3 returns true "
3 check-line true test-result CR

0 s" sayndz" rot 1+  s" zfxlkl" rot 1+  s" attjtww" rot 1+  s" cti" rot 1+  s" sokkmty" rot 1+  s" brx" rot 1+  s" fhh" rot 1+  s" suelqbp" rot 1+ 
check-line true test-result CR

0 s" htfkd" rot 1+  s" htfkd" rot 1+  s" hwykmm" rot 1+  s" htfkd" rot 1+ 
check-line false test-result CR

0 s" sfpku" rot 1+  s" viwihi" rot 1+  s" fje" rot 1+  s" umdkwvi" rot 1+  s" ejzhzj" rot 1+  s" qrbl" rot 1+  s" ksnku" rot 1+  s" sad" rot 1+  s" nawnow" rot 1+  s" sfpku" rot 1+  check-valid-in-line false test-result CR

0 s" sfpku" rot 1+  s" viwihi" rot 1+  s" fje" rot 1+  s" umdkwvi" rot 1+  s" ejzhzj" rot 1+  s" qrbl" rot 1+  s" sfpku" rot 1+  s" sad" rot 1+  s" nawnow" rot 1+  s" ksnku" rot 1+  check-line false test-result CR
