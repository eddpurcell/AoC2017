{
	if ($1 == "snd" || $1 == "rcv")
	{
		printf("_ %s ", $2)
		if(match($2, /[a-z]/)) {
			printf("@ ", $2)
		}
		printf("%s ", $1)
	} else {
		printf("_ %s ", $2)
		if (match($3, /[0-9]+/)) {
			printf("%s %s ", $3, $1)
		} else {
			printf("%s @ %s ", $3, $1)
		}
	}
}
