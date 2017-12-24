{
	split($0, chars, "")
	if (chars[1] == "s") {
		#printf("%s > ", $0)
		printf("%s s\n", substr($0, 2))
	}
	else if (chars[1] == "x") {
		split($0, parts, "/")
		#printf("%s > ", $0)
		printf("%s %s x\n", substr(parts[1], 2), parts[2])
	}
	else if (chars[1] == "p") { 
		split($0, parts, "/")
		#printf("%s > ", $0)
		printf("'%s '%s p\n", substr(parts[1], 2), parts[2]) 
	}
}
