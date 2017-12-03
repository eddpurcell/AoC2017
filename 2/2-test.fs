include ../test.fs
include 2.fs

CR

." -1 record returns 0 "
-1 record 0 test-result CR

." -1 5 1 9 5 record returns 8 "
-1 5 1 9 5 record 8 test-result CR

." -1 7 5 3 record returns 4 "
-1 7 5 3 record 4 test-result CR

." -1 2 4 6 8 record returns 6 "
-1 2 4 6 8 record 6 test-result CR

." [2 6] find-divisible-value returns 3 "
create var 2 , 6 ,
var 2 2 0 find-divisible-value 3 test-result CR

." [2 7] find-divisible-value returns 0 "
create var 2 , 7 ,
var 2 2 0 find-divisible-value 0 test-result CR

." [2 7 9 10] find-divisible-value returns 5 "
create var 2 , 7 , 9 , 10 ,
var 4 2 0 find-divisible-value 5 test-result CR

." [3 7 2 15] find-divisible-value returns 5 "
create var 3 , 7 , 2 , 15 ,
var 4 3 0 find-divisible-value 5 test-result CR

." [15 7 2 3] find-divisible-value returns 5 "
create var 15 , 7 , 2 , 3 ,
var 3 3 3 find-divisible-value 5 test-result CR

." [5 9 2 8] record-divisible-value returns 4 "
create row1 5 , 9 , 2 , 8 ,
row1 4 record-divisible-value 4 test-result CR

." [9 4 7 3] record-divisible-value returns 3 "
create row1 9 , 4 , 7 , 3 ,
row1 4 record-divisible-value 3 test-result CR

." [[5 9 2 8] [3 4 7 9] [3 8 6 5]] checksum is 9 "
create row1 5 , 9 , 2 , 8 ,
create row2 3 , 4 , 7 , 9 ,
create row3 3 , 8 , 6 , 5 ,
0
row1 4 record-divisible-value + .s
row2 4 record-divisible-value + .s
row3 4 record-divisible-value + 9 test-result CR 
