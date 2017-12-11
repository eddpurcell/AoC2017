include 10.fs

256 setup
46 step
41 step
212 step
83 step
1 step
255 step
157 step
65 step
139 step
52 step
39 step
254 step
2 step
86 step
0 step
204 step

CR ." Part 1 answer: " buffer @ buffer 1 cells + @ * .

CR ." Part 2 answer: "
s" 46,41,212,83,1,255,157,65,139,52,39,254,2,86,0,204" hash print-dense-hash

