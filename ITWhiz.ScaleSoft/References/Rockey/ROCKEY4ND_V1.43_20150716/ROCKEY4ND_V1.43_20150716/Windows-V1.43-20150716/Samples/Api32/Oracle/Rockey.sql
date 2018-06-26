-- 
-- Copyright (c) 1997 by Oracle Corporation
--
-- NAME
--   EXTERN.SQL
--
-- DESCRIPTION
--   Creates a PL/SQL library and registers the sample external procedure
-- 
-- NOTES
--   Before running this script, add your internal password to the
--   'connect internal' line (if necessary) [or enter it at runtime
--   at the Password: prompt].
--

connect internal
create user sample identified by sample;
grant connect, resource, dba to sample;
connect sample/sample;


--First associate a library with an actual DLL in the operating system...
drop library externProcedures;
create library externProcedures as 'D:\oracle\product\10.2.0\db_1\BIN\Rockey4ND.dll';
/
--In a given library, you may have multiple functions.
--You must register each function that you want to use from PL/SQL

--Next register an external function in that DLL with PL/SQL...
--This function returns the maximum of the two values passed to it.


CREATE OR REPLACE FUNCTION ROCKEY(
      func		IN PLS_INTEGER,
      handle	IN OUT NOCOPY PLS_INTEGER,
      lp1		IN OUT BINARY_INTEGER,
      lp2		IN OUT BINARY_INTEGER,
      p1		IN OUT PLS_INTEGER,
      p2		IN OUT PLS_INTEGER,
      p3		IN OUT PLS_INTEGER,
      p4		IN OUT PLS_INTEGER,
      buffer	IN OUT VARCHAR2) 
	RETURN BINARY_INTEGER AS 
	EXTERNAL LIBRARY externProcedures
	NAME "Rockey"
	LANGUAGE C
	PARAMETERS (
      func		unsigned short,
      handle		unsigned short,
      lp1		int,
      lp2		int,
      p1		unsigned short,
      p2		unsigned short,
      p3		unsigned short,
      p4		unsigned short,
      buffer	STRING);
/

--here is how it would be used:

--Find Dongle------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--When succeeded, *lp1 contains the HID of the dongle
CREATE OR REPLACE PROCEDURE Rockey_Find AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer		VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 1;		--Find Dongle
	handle	:= 0;
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 50252;	--P1 password in DEC order. User can convert Hex password to Dec by using Windows Calculator in Scientific mode
	p2		:= 51448;	--P2 password in DEC order
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('Rockey ID is '||lp1);			--Print out dongle HID
END;
/

--Find Next Dongle------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--When succeeded, *lp1 contains the HID of the dongle
CREATE OR REPLACE PROCEDURE Rockey_FindNext AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 2;		--Find Next Dongle
	handle	:= 0;
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 50252;	--P1 password in DEC order
	p2		:= 51448;	--P2 password in DEC order
	p3		:= 1945;
	p4		:= 50235;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('Rockey ID is '||lp1);			--Print out dongle HID
END;
/

--Open Dongle------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--When succeeded, *handle contains the handler of the dongle
CREATE OR REPLACE PROCEDURE Rockey_Open AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 3;			--Open Dongle
	handle	:= 0;
	lp1		:= 1900147036;	--Dongle HID, returned by Rockey_Find function
	lp2		:= 0;
	p1		:= 50252;		--P1 password in DEC order
	p2		:= 51448;		--P2 password in DEC order
	p3		:= 1945;		--P3 password in DEC order
	p4		:= 50235;		--P4 password in DEC order
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('The handle is '||handle);		--Print out dongle handler
END;
/

--Close Dongle------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_Close AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 4;			--Close Dongle
	handle	:= 0;			--Dongle handler, returned by Rockey_Open function
	lp1		:= 1900147036;	--Dongle HID, returned by Rockey_Find function
	lp2		:= 0;
	p1		:= 0;
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret); --Print out return value
END;
/

--Random Number------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--p1: Random number 1
--p2: Random number 2
--p3: Random number 3
--p4: Random number 4
CREATE OR REPLACE PROCEDURE Rockey_Random AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 7; --Random Number
	handle	:= 0; --Dongle handler, returned by Rockey_Open function
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 0;
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret); --Print out return value
	dbms_output.put_line('The random value is '||p1); --Random number 1
	dbms_output.put_line('The random value is '||p2); --Random number 2
	dbms_output.put_line('The random value is '||p3); --Random number 3
	dbms_output.put_line('The random value is '||p4); --Random number 4	
END;
/

--Seed Code------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--p1: Seed code 1
--p2: Seed code 2
--p3: Seed code 3
--p4: Seed code 4
CREATE OR REPLACE PROCEDURE Rockey_Seed AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 8; --Seed Code
	handle	:= 0; --Dongle handler, returned by Rockey_Open function
	lp1		:= 0;
	lp2		:= 5; --Seed code
	p1		:= 0;
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret); --Print out return value
	dbms_output.put_line('The random value is '||p1); --Seed code 1
	dbms_output.put_line('The random value is '||p2); --Seed code 2
	dbms_output.put_line('The random value is '||p3); --Seed code 3
	dbms_output.put_line('The random value is '||p4); --Seed code 4
END;
/

--Check Module------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--p2 = 1: Means the module is valid
--p3 = 1: Means the module is allowed to decrease
CREATE OR REPLACE PROCEDURE Rockey_CheckModule AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 12;	--Check Module
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 1;	--Module number
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('The module is valid '||p2);	--1 Means the module is valid
	dbms_output.put_line('The module can dec '||p3);	--1 Means the module is allowed to decrease
END;
/

--Calculation 1------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--p1: Result value 1
--p2: Result value 2
--p3: Result value 3
--p4: Result value 4
CREATE OR REPLACE PROCEDURE Rockey_Calculate1 AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 14;	--Calculation 1
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;	--Start point
	lp2		:= 1;	--Module number
	p1		:= 3;	--Input value 1
	p2		:= 5;	--Input value 2
	p3		:= 2;	--Input value 3
	p4		:= 1;	--Input value 4
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('The return value1 is '||p1);	--Result value 1
	dbms_output.put_line('The return value2 is '||p2);	--Result value 2
	dbms_output.put_line('The return value3 is '||p3);	--Result value 3
	dbms_output.put_line('The return value4 is '||p4);	--Result value 4
END;
/

--Calculation 2------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--p1: Result value 1
--p2: Result value 2
--p3: Result value 3
--p4: Result value 4
CREATE OR REPLACE PROCEDURE Rockey_Calculate2 AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 15;	--Calculation 2
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;	--Start point
	lp2		:= 1;	--Seed code
	p1		:= 3;	--Input value 1
	p2		:= 5;	--Input value 2
	p3		:= 2;	--Input value 3
	p4		:= 1;	--Input value 4
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('The return value1 is '||p1);	--Result value 1
	dbms_output.put_line('The return value2 is '||p2);	--Result value 2
	dbms_output.put_line('The return value3 is '||p3);	--Result value 3
	dbms_output.put_line('The return value4 is '||p4);	--Result value 4
END;
/

--Calculation 3------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--p1: Result value 1
--p2: Result value 2
--p3: Result value 3
--p4: Result value 4
CREATE OR REPLACE PROCEDURE Rockey_Calculate3 AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 16;	--Calculation 3
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;	--Start point
	lp2		:= 1;	--Module number
	p1		:= 3;	--Input value 1
	p2		:= 5;	--Input value 2
	p3		:= 2;	--Input value 3
	p4		:= 1;	--Input value 4
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('The return value1 is '||p1);	--Result value 1
	dbms_output.put_line('The return value2 is '||p2);	--Result value 2
	dbms_output.put_line('The return value3 is '||p3);	--Result value 3
	dbms_output.put_line('The return value4 is '||p4);	--Result value 4
END;
/

--Decrease Module------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_DecreaseModule AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 17;	--Decrease Module
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 1;	--Module number
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
END;
/

--Write UserID------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_WriteUserID AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 9;			--Write UserID
	handle	:= 0;			--Dongle handler, returned by Rockey_Open function
	lp1		:= 35281281;	--UserID
	lp2		:= 0;
	p1		:= 0;
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
END;
/

--Read UserID------------------------------------------------------------
--Return Value: 0 means success, other value is error code
--lp1£ºUserID
CREATE OR REPLACE PROCEDURE Rockey_ReadUserID AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 10;	--Read UserID
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 0;
	p2		:= 0;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);	--Print out return value
	dbms_output.put_line('The UserID is '||lp1);		--UserID
END;
/

--Set Module------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_SetModule AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 11;	--Set Module
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;
	lp2		:= 0;
	p1		:= 1;	--Module number
	p2		:= 0;	--
	p3		:= 1;	--Allow decrease (1: Yes, 0: No)
	p4		:= 0;
	buffer	:= 0;
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret); --Print out return value
END;
/

--Write UDZ (User Data Zone)------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_Write AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR2(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 6;	--Write UDZ
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;	
	lp2		:= 0;	
	p1		:= 0;	--Offset
	p2		:= 2;	--Length
	p3		:= 0;
	p4		:= 0;
	buffer	:= 'abc';
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret); --Print out return value
END;
/

--Read UDZ (User Data Zone)------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_Read AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR2(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 5;	--Read UDZ
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;	
	lp2		:= 0;	
	p1		:= 0;	--Offset
	p2		:= 2;	--Length
	p3		:= 0;
	p4		:= 0;
	buffer	:= '0';
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);		--Print out return value
	dbms_output.put_line('The user memory is '||buffer);	--Read content
END;
/

--Write Algorithm------------------------------------------------------------
--Return Value: 0 means success, other value is error code
CREATE OR REPLACE PROCEDURE Rockey_Arith AS
	func	PLS_INTEGER;
	handle	PLS_INTEGER;
	lp1		BINARY_INTEGER;
	lp2		BINARY_INTEGER;
	p1		PLS_INTEGER;
      	p2		PLS_INTEGER;
      	p3		PLS_INTEGER;
      	p4		PLS_INTEGER;
	buffer	VARCHAR2(1024);
	ret		PLS_INTEGER;
BEGIN
	func	:= 13;	--Write Algorithm
	handle	:= 0;	--Dongle handler, returned by Rockey_Open function
	lp1		:= 0;	
	lp2		:= 0;	
	p1		:= 0;	--Start point
	p2		:= 2;
	p3		:= 0;
	p4		:= 0;
	buffer	:= 'A=A+B';	--Algorithm string
	ret := ROCKEY(func, handle, lp1, lp2, p1, p2, p3, p4, buffer);
	dbms_output.put_line('The return value is '||ret);		--Print out return value
END;
/


set serveroutput on;
execute Rockey_Find;
execute Rockey_Open;
execute Rockey_Write;
execute Rockey_Read;
execute Rockey_WriteUserID;
execute Rockey_ReadUserID;
execute Rockey_Random;
execute Rockey_Seed;
execute Rockey_SetModule;
execute Rockey_CheckModule;
execute Rockey_Arith;
execute Rockey_Read;
execute Rockey_DecreaseModule;
execute Rockey_Calculate1;
execute Rockey_Calculate2;
execute Rockey_Calculate3;
execute Rockey_Close;
/

