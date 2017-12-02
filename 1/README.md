## Day 1

### Challenge 1
First, pass the input string through the following sed command: `sed -e 's/\(.\)/\1 /g' < input.txt > output.fs`

Add the final number to the bottom of the stack (as the first input) to properly handle the circular list requirement.
Then add the length to the top of the stack and make the word call to `sum-dups`. Make sure 1-1.fs is included in your
program. Run with `gforth -d 32k 1-1-answer.fs -e bye`.

This program is a simple loop that checks if the next number on the stack is the same, and if so it adds that number
to the sum, otherwise it adds 0 to the sum. Because we're always just checking two numbers, it doesn't actually matter
which direction we parse the numbers, so the input doesn't also need to be reversed. This program probably would have
been smaller with string manipulation, but it wasn't a big deal at the time. This would come back to bite me in the
rear.

### Challenge 2
This challenge requires checking dups, but instead of matching against neighbors its for the digit on the opposite side
of the circular list. Had I just done string manipulation from the start, it would have been easy to do a modulus and
adding half the length of the list to the current index. But we persevere.

The a-ha moment was realizing checking the number halfway around the list was the same as checking the neighbor of an
interleaved list. New problem: automate string interleaving, to then pass through sed and make some minor adjustments
to the sum program. This actually turned out to be a little easier than expected once I re-learned the character and
string words.

With that done (finally), the minor adjustments had to be made. In this case, we only want to check each pair of inputs
instead of each input against its neighbor. Easy enough to do, we just drop the extra value and when we get the 
remaining length of the list we `swap` instead of `rot` (only the sum is in front of it). We start off our answer
program similarly to the last challenge, but read from input2.txt instead of input.txt and call `sum-dups-int` instead.


### Testing
In an attempt to be be a good coder (and minimize wrong answers), I wrote tests for the main functions. They're easy
to run with the command `gforth 1-1.fs 1-1-test.fs -e bye`. It will print out all the tests I'm focusing on and whether
or not they pass. If they fail, it'll print out the value on the stack that was wrong.

