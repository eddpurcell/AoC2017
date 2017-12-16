BEGIN {
	FS="<->"
}

{
	n=split($2,array,", "); 
	for (i=1;i<=n;i++) { 
		printf("grid %s %s %s !edge\n", array[i], $1, len)
	}
}
