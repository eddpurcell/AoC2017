include ../test.fs
include 12.fs

create grid 49 cells allot

grid 7 setup

grid 2 0 7 !edge
grid 1 1 7 !edge
grid 0 2 7 !edge
grid 3 2 7 !edge
grid 4 2 7 !edge
grid 2 3 7 !edge
grid 4 3 7 !edge
grid 2 4 7 !edge
grid 3 4 7 !edge
grid 6 4 7 !edge
grid 6 5 7 !edge
grid 4 6 7 !edge
grid 5 6 7 !edge

grid 7 print-grid CR

." grid 7 0 size-of-group returns 6 "
grid 7 0 size-of-group 6 test-result CR


grid 7 setup

grid 2 0 7 !edge
grid 1 1 7 !edge
grid 0 2 7 !edge
grid 3 2 7 !edge
grid 4 2 7 !edge
grid 2 3 7 !edge
grid 4 3 7 !edge
grid 2 4 7 !edge
grid 3 4 7 !edge
grid 6 4 7 !edge
grid 6 5 7 !edge
grid 4 6 7 !edge
grid 5 6 7 !edge

." grid 7 #groups returns 2 "
grid 7 #groups 2 test-result CR
