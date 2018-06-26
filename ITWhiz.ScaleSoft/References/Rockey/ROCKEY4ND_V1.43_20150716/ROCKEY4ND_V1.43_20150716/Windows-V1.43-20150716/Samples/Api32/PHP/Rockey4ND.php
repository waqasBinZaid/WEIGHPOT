<h2>PHP Sample for Rockey4ND</h2>

<?

// Create COM object Com.CRockey4ND
print "<ul>";
print "<li><h3>Create Rockey4ND COM object</h3>";
$Rockey = new COM("Com.CRockey4ND") or die("<h3>Unable to instanciate Rockey COM object</h3>");


//Display COM interface;
//com_print_typeinfo($Rockey);

//Set Parameters
print "<li><h3>Set Parameters</h3>";
print "<h4>p1=0xc44c p2=0xc8f8 p3=0x0799 p4=0xc43b</h4>";
$Rockey->p1 = new VARIANT(0xc44c, VT_UI2);
$Rockey->p2 = new VARIANT(0xc8f8, VT_UI2);
$Rockey->p3 = new VARIANT(0x0799, VT_UI2);
$Rockey->p4 = new VARIANT(0xc43b, VT_UI2);

//Find First Rockey
print "<li><h3>Find First Rockey</h3>";
$result = $Rockey->RockeyCM(1);
if ($result==0) {
	print "<h4>Found, HID = ";
	printf("%08X </h4>", $Rockey->lp1);
} else {
	print "<h4>No Rockey is detected</h4>"	;
	exit();
}

//Open First Rockey
print "<li><h3>Open First Rockey</h3>";
$result = $Rockey->RockeyCM(3);
if ($result==0) {
	print "<h4>Success</h4>";
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Write
$text = "Hello World!";
print "<li><h3>Write \"$text\" to User Memory 1</h3>";
$Rockey->buffer = new VARIANT($text, VT_BSTR);
$Rockey->p1 = new VARIANT(0, VT_UI4);
$Rockey->p2 = new VARIANT(floor(strlen($text)/2+1)*2, VT_UI4);
$result = $Rockey->RockeyCM(6);
if ($result==0) {
	print "<h4>Success</h4>";
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Read
print "<li><h3>Read User Memory 1</h3>";
$Rockey->buffer = new VARIANT($text, VT_BSTR);
$Rockey->p1 = new VARIANT(0, VT_UI4);
$Rockey->p2 = new VARIANT(500, VT_UI4);
$result = $Rockey->RockeyCM(7);
if ($result==0) {
	print "<h4>Success, Result: ".$Rockey->buffer."</h4>";
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Generate Random Number
print "<li><h3>Generate Random Numbers</h3>";
print "  //p1 p2 p3 p4 's length is 2 bytes , it maybe display too long with printf(%04X)";
$result = $Rockey->RockeyCM(7);
if ($result==0) {
	for ($i=0; $i<10; $i++) {
		printf("<h4>%04X %04X %04X %04X</h4>", $Rockey->p1, $Rockey->p2, $Rockey->p3, $Rockey->p4);
		$Rockey->RockeyCM(7);
	}
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Generate Seed
$seed="12345678";
$Rockey->lp2 = new VARIANT(12345678, VT_UI4);
print "<li><h3>Generate Seed from $seed</h3>";
print "  //p1 p2 p3 p4 's length is 2 bytes , it maybe display too long with printf(%04X)";
$result = $Rockey->RockeyCM(8);
if ($result==0) {
	printf("<h4>Success, seed is %04X %04X %04X %04X</h4>", $Rockey->p1, $Rockey->p2, $Rockey->p3, $Rockey->p4);
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Write User ID
$Rockey->lp1 = new VARIANT(0x88888888, VT_UI4);
printf("<li><h3>Write User ID %8X</h3>",$Rockey->lp1);
$result = $Rockey->RockeyCM(9);
if ($result==0) {
	print "<h4>Success</h4>";
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Read User ID
print "<li><h3>Read User ID</h3>";
$result = $Rockey->RockeyCM(9);
if ($result==0) {
	printf("<h4>Success, User ID: %8X</h4>",$Rockey->lp1);
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

//Set Module
$Rockey->p1 = new VARIANT(7, VT_UI2);
$Rockey->p2 = new VARIANT(0x2121, VT_UI2);
$Rockey->p3 = new VARIANT(0, VT_UI2);
print "<li><h3>Set Module</h3>";
$result = $Rockey->RockeyCM(11);
if ($result==0) {
	printf("<h4>Set Moudle 7: Pass = %04X Decrease no allow</h4>", $Rockey->p2);
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}


$Rockey->p1 = new VARIANT(7, VT_UI2);
print "<li><h3>Check Module</h3>";
$result = $Rockey->RockeyCM(12);
if ($result==0) {
	printf("<h4>Check Moudle 7: %s Decrease: %s</h4>", $Rockey->p2?"Allow":"Not Allow", $Rockey->p3?"Allow":"Not Allow");
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

$Rockey->p1 = new VARIANT(0, VT_UI2);
$cmd = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
print "<li><h3>Write Arithmetic 1: $cmd</h3>";
$result = $Rockey->RockeyCM(12);
if ($result==0) {
	$Rockey->buffer = new VARIANT($cmd, VT_BSTR);
	printf("<h4>Success</h4>");
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

$Rockey->lp1 = new VARIANT(0, VT_UI4);
$Rockey->lp2 = new VARIANT(7, VT_UI4);
$Rockey->p1 = new VARIANT(5, VT_UI2);
$Rockey->p2 = new VARIANT(3, VT_UI2);
$Rockey->p3 = new VARIANT(1, VT_UI2);
$Rockey->p4 = new VARIANT(0xffff, VT_UI2);
print "<li><h3>Calculate</h3>";
$result = $Rockey->RockeyCM(14);
if ($result==0) {
	printf("<h4>Calculate Input: p1=5, p2=3, p3=1, p4=0xffff <br />");
	printf("Result = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71 <br />");
	printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x </h4>", $Rockey->p1, $Rockey->p2, $Rockey->p3, $Rockey->p4);
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}


$Rockey->p1 = new VARIANT(10, VT_UI2);
$cmd = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
print "<li><h3>Write Arithmetic 2: $cmd</h3>";
$result = $Rockey->RockeyCM(12);
if ($result==0) {
	$Rockey->buffer = new VARIANT($cmd, VT_BSTR);
	printf("<h4>Success</h4>");
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

$Rockey->lp1 = new VARIANT(10, VT_UI4);
$Rockey->lp2 = new VARIANT(0x12345678, VT_UI4);
$Rockey->p1 = new VARIANT(1, VT_UI2);
$Rockey->p2 = new VARIANT(2, VT_UI2);
$Rockey->p3 = new VARIANT(3, VT_UI2);
$Rockey->p4 = new VARIANT(4, VT_UI2);
print "<li><h3>Calculate</h3>";
$result = $Rockey->RockeyCM(15);
if ($result==0) {
	printf("<h4>Calculate Input: p1=1, p2=2, p3=3, p4=4\n");
	printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x </h4>", $Rockey->p1, $Rockey->p2, $Rockey->p3, $Rockey->p4);
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}

print "<li><h3>Close Rockey</h3>";
$result = $Rockey->RockeyCM(4);
if ($result==0) {
	print "<h4>Success</h4>";
} else {
	print "<h4>Failed, Error Code: $result</h4>";
	exit();
}
?>
