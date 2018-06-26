use Win32::API;

#------Load Rockey() Function------------------------

$Rockey = Win32::API->new("Rockey4ND", "Rockey", "IPPPPPPPP", "I");#
if(not defined $Rockey) 
{
	print("Can't Find Rockey() function");
	exit;
}

#------Find Dongle--------------------------

$handle = "  ";
$lp1    = "    ";
$lp2    = "    ";
$p1     = pack('S', 0xC44C);
$p2     = pack('S', 0xC8F8);
$p3     = "  ";
$p4     = "  ";
$buffer = "  ";
$retcode = 0;
$retcode = $Rockey->Call(1, $handle, $lp1, $lp2, $p1, $p2, $p3, $p4, $buffer); #RY_FIND
if($retcode != 0)
{
	print("Find Failed error code = $retcode");
	exit;
}
else
{
	$lp1a = unpack("L", $lp1);
	$retcod = unpack("S", $retcode);
	printf("Find Successful, HID = %08X \n", $lp1a);
}

#------Open Dongle--------------------------

$retcode = 222;

$retcode = pack("S",$Rockey->Call(3, $handle, $lp1, $lp2, $p1, $p2, $p3, $p4, $buffer)); #RY_OPEN

if($retcode != 0)
{
	print("Open Failed error code = $retcode");
	exit;
}
else
{
	$handle_2 = unpack("S", $handle);
	$retcode = unpack("S", $retcode);
	print("Open Successful, Handle Index = $handle_2 \n");
}

#------Read User ID--------------------------

$retcode = pack("S",$Rockey->Call(10, $handle, $lp1, $lp2, $p1, $p2, $p3, $p4, $buffer)); #RY_READ_USERID

if($retcode != 0)
{
	print("Read UserID Failed error code = $retcode");
	
	exit;
}
else
{
	$lp1a = unpack("L", $lp1);
	printf("Read UserID Successful, UserID = %08X \n", $lp1a);
}


#------Read Module Value--------------------------

$p1 = pack('S', 0); #Module No.0
$retcode = pack("S",$Rockey->Call(12, $handle, $lp1, $lp2, $p1, $p2, $p3, $p4, $buffer)); #RY_CHECK_MOUDLE

if($retcode != 0)
{
	print("Read Moudle Failed error code = $retcode");
	exit;
}
else
{
	$p2a = unpack("S", $p2);
	if($p2a == 1)
	{
		$p2b = "Module Enable";
	}
	else
	{
		$p2b = "Module Disable";
	}
	$p3a = unpack("S", $p3);
	if($p3a == 1)
	{
		$p3b = "Decrease";
	}
	else
	{
		$p3b = "un Descrease";
	}
	print("Read Moudle Successful, Module NO.0 $p2b $p3b \n");
}

#------Read Dongle Memory--------------------------

$p1 = pack('S', 0);  #offset in Rockey Dongle Memory
$p2 = pack('S', 80); #Length(Bytes)
$buffer = " " x 80;
$retcode = pack("S",$Rockey->Call(5, $handle, $lp1, $lp2, $p1, $p2, $p3, $p4, $buffer)); #RY_READ

if($retcode != 0)
{
	print("Read Memory Failed error code = $retcode");
	exit;
}
else
{
	print("Read Memory Successful, offset 0, 80 Bytes \n");
	@buffer2 = unpack("C80", $buffer);
	
	for($i = 0; $i < 80; $i++)
	{
                printf("%02X ", @buffer2[$i]);
	}	
	print("\n");
	
}

#------Close--------------------------

$retcode = pack("S",$Rockey->Call(4, $handle, $lp1, $lp2, $p1, $p2, $p3, $p4, $buffer)); #RY_CLOSE

if($retcode != 0)
{
	print("CloseFailed error code = $retcode");
	exit;
}
else
{
	print("CloseSuccessful");
}



