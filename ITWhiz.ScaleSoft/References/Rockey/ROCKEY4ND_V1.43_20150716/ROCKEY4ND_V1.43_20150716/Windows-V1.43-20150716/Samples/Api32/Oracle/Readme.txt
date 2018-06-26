How to use Oracle sample (Oracle10g is used here):
1. Copy Rockey4ND.dll to \oracle\product\10.2.0\db_1\BIN\ directory;
2. Reset the path to ROCKEY4ND.dll in the SQL script in "Create library externProcedures as ..." statement to the correct value (see Step 1);
3. Modify the HID in the SQL script in "lp1:=..." statement in Rockey_Open procedure to the HID of the real dongle;
4. Run scirpt:
   SQL> start c:\rockey.sql;
   or SQL> @ c:\rockey.sql;

Tips:
1. All data in Oracle is decimal.
2. The type of the returned error code is WORD for standard APIs. But the code is declared as a 32-bit numeric value in Oracle. The high 16 bits may be invalid data. Only the low 16 bits are required for determination.


