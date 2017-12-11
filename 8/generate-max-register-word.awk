BEGIN {
	print ": max-register ( -- )"
	print "\t0 ( maxval )"
}

{
	printf("\t%s @ max\n", $1)
}

END {
	print ";"
}
