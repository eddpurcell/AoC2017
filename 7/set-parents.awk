#!/usr/bin/awk -f

BEGIN {FS=" -> "} 

$2 { 
	n=split($2,array,", "); 
	for (i=1;i<=n;i++) { 
		printf("%s %s parent!\n", substr($1, 1, index($1, " ")), array[i])
	}
}
