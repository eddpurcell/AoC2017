include ../test.fs
include 9.fs

CR
{ } score 1 test-result CR
reset

{ { { } } } score 6 test-result CR
reset

{ { } , { } } score 5 test-result CR
reset

{ { { } , { } , { { } } } } score 16 test-result CR
reset

< a b c d > garbageCount 4 test-result CR
reset

< > garbageCount 0 test-result CR
reset
< < < < > garbageCount 3 test-result CR
reset
< { } > garbageCount 2 test-result CR
reset
< { o " i , < { i < a > garbageCount 10 test-result CR
reset
