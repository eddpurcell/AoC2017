: test-result ( n n -- )
	over = IF ." PASS" drop ELSE ." FAIL - " . ENDIF ;

