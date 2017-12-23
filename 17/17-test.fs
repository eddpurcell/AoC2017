include ../test.fs
include 17.fs

." 3 1 spin-round creates [0 (1)] "
3 1 spin-round buff @ 0 test-result buff cell+ @ 1 test-result curr-ind 1 test-result CR

." 3 2 spin-round creates [0 (2) 1] "
3 2 spin-round buff @ 0 test-result buff cell+ @ 2 test-result buff 2 cells + @ 1 test-result
curr-ind 1 test-result CR

." 3 3 spin-round creates [0 2 (3) 1] "
3 3 spin-round buff @ 0 test-result buff cell+ @ 2 test-result buff 2 cells + @ 3 test-result
buff 3 cells + @ 1 test-result curr-ind 2 test-result CR

." 3 4 spin-round creates [0 2 (4) 3 1] "
3 4 spin-round
print CR

reset
." 3 spin-lock curr-ind returns index of 2017 at end "
3 2018 spin-lock buff curr-ind cells + @ 2017 test-result CR

." 3 spin-lock buff curr-ind 1+ cells + @ returns 638 "
buff curr-ind 1+ cells + @ 638 test-result CR

