BEGIN {
	print ": print-registers ( -- )"
}

{
	printf("\tCR s\" %s = \" type %s @ .\n", $1, $1)
}

END {
	print ";"
}
