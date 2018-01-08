include 18.fs
include registers.fs

_ i 31 set _ a 1 set _ p 17 mul _ p p @ jgz _ a 2 mul _ i -1 add _ i -2 jgz _ a -1 add _ i 127 set _ p 680 set _ p 8505 mul _ p a @ mod _ p 129749 mul _ p 12345 add _ p a @ mod _ b p @ set _ b 10000 mod _ b @ snd _ i -1 add _ i -9 jgz _ a 3 jgz _ b @ rcv _ b -1 jgz _ f 0 set _ i 126 set _ a @ rcv _ b @ rcv _ p a @ set _ p -1 mul _ p b @ add _ p 4 jgz _ a @ snd _ a b @ set _ 1 3 jgz _ b @ snd _ f 1 set _ i -1 add _ i -11 jgz _ a @ snd _ f -16 jgz _ a -19 jgz 
