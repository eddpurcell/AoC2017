include ../test.fs
include 20.fs

0 0 -1 0 0 2 0 0 3 particle: p1
0 0 -2 0 0 0 0 0 4 particle: p2

p1 print-particle
p2 print-particle

p1 pmove
p2 pmove
p1 pmove
p2 pmove
p1 pmove
p2 pmove

CR ." p1 is closer than p2 in the long term "
p1 manhattan-dist p2 manhattan-dist < true test-result CR
p1 print-particle
p2 print-particle
