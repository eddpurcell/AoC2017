{
	match($3, /<([\-0-9]+),([\-0-9]+),([\-0-9]+)>/, accel)
	match($2, /<([\-0-9]+),([\-0-9]+),([\-0-9]+)>/, velo)
	match($1, /<([\-0-9]+),([\-0-9]+),([\-0-9]+)>/, pos)
	printf("%s %s %s %s %s %s %s %s %s particle: p%d\n",
	       accel[3], accel[2], accel[1],
	       velo[3], velo[2], velo[1],
	       pos[3], pos[2], pos[1],
	       NR-1)
}

