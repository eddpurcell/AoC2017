{
	printf("_ %s ", $2)
	if (match($3, /[0-9]+/)) {
	printf("%s %s ", $3, $1)
	} else {
		printf("%s @ %s ", $3, $1)
	}
}
