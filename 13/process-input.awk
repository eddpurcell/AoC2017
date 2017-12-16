BEGIN {
	FS=":"
}

{
	printf("%s %s !range\n", $2, $1)
}
