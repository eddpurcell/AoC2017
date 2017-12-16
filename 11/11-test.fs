include ../test.fs
include 11.fs

0 0 0 ne ne ne print-bearings
CR ." ne ne ne mahanttan-distance is 3 "
manhattan-distance 3 test-result CR

0 0 0 ne ne sw sw print-bearings
CR ." ne ne sw sw manhattan-distance is 0 "
manhattan-distance 0 test-result CR

0 0 0 ne ne s s print-bearings
CR ." ne ne s s manhattan-distance is 2 "
manhattan-distance 2 test-result CR

0 0 0 se sw se sw sw print-bearings
CR ." se sw se sw sw manhattan-distance is 3 "
manhattan-distance 3 test-result CR

0 0 0 s ne ne sw print-bearings
CR ." s ne ne sw manhattan-distance is 1 "
manhattan-distance 1 test-result CR

0 0 0 s ne print-bearings
CR ." s ne manhattan-distance is 1 "
manhattan-distance 1 test-result CR

