{
	# q inc -541 if c != 4
	# q -541 c @ 4 != inc
	printf("%s %s %s @ %s %s %s\n", $1, $3, $5, $7, $6, $2);
}
