// Decompiled by Jad v1.5.7g. Copyright 2000 Pavel Kouznetsov.
// Jad home page: http://www.geocities.com/SiliconValley/Bridge/8617/jad.html
// Decompiler options: packimports(3) fieldsfirst ansi 
// Source File Name:   Rockey4Smart.java

//package Feitian.ROCKEY4ND;
//import java.io.*;
public class Ry4ND
{

    public short RY_FIND;
    public short RY_FIND_NEXT;
    public short RY_OPEN;
    public short RY_CLOSE;
    public short RY_READ;
    public short RY_WRITE;
    public short RY_RANDOM;
    public short RY_SEED;
    public short RY_WRITE_USERID;
    public short RY_READ_USERID;
    public short RY_SET_MODULE;
    public short RY_CHECK_MODULE;
    public short RY_WRITE_ARITHMETIC;
    public short RY_CALCULATE1;
    public short RY_CALCULATE2;
    public short RY_CALCULATE3;
    public short RY_DECREASE;
    public short ERR_SUCCESS;
    public short ERR_NO_PARALLEL_PORT;
    public short ERR_NO_DRIVER;
    public short ERR_NO_ROCKEY;
    public short ERR_INVALID_PASSWORD;
    public short ERR_INVALID_PASSWORD_OR_ID;
    public short ERR_SETID;
    public short ERR_INVALID_ADDR_OR_SIZE;
    public short ERR_UNKNOWN_COMMAND;
    public short ERR_NOTBELEVEL3;
    public short ERR_READ;
    public short ERR_WRITE;
    public short ERR_RANDOM;
    public short ERR_SEED;
    public short ERR_CALCULATE;
    public short ERR_NO_OPEN;
    public short ERR_OPEN_OVERFLOW;
    public short ERR_NOMORE;
    public short ERR_NEED_FIND;
    public short ERR_DECREASE;
    public short ERR_AR_BADCOMMAND;
    public short ERR_AR_UNKNOWN_OPCODE;
    public short ERR_AR_WRONGBEGIN;
    public short ERR_AR_WRONG_END;
    public short ERR_AR_VALUEOVERFLOW;
    public short ERR_UNKNOWN;
    public short ERR_RECEIVE_NULL;
    public short ERR_PRNPORT_BUSY;

    public Ry4ND()
    {
        RY_FIND = 1;
        RY_FIND_NEXT = 2;
        RY_OPEN = 3;
        RY_CLOSE = 4;
        RY_READ = 5;
        RY_WRITE = 6;
        RY_RANDOM = 7;
        RY_SEED = 8;
        RY_WRITE_USERID = 9;
        RY_READ_USERID = 10;
        RY_SET_MODULE = 11;
        RY_CHECK_MODULE = 12;
        RY_WRITE_ARITHMETIC = 13;
        RY_CALCULATE1 = 14;
        RY_CALCULATE2 = 15;
        RY_CALCULATE3 = 16;
        RY_DECREASE = 17;
        ERR_SUCCESS = 0;
        ERR_NO_PARALLEL_PORT = 1;
        ERR_NO_DRIVER = 2;
        ERR_NO_ROCKEY = 3;
        ERR_INVALID_PASSWORD = 4;
        ERR_INVALID_PASSWORD_OR_ID = 5;
        ERR_SETID = 6;
        ERR_INVALID_ADDR_OR_SIZE = 7;
        ERR_UNKNOWN_COMMAND = 8;
        ERR_NOTBELEVEL3 = 9;
        ERR_READ = 10;
        ERR_WRITE = 11;
        ERR_RANDOM = 12;
        ERR_SEED = 13;
        ERR_CALCULATE = 14;
        ERR_NO_OPEN = 15;
        ERR_OPEN_OVERFLOW = 16;
        ERR_NOMORE = 17;
        ERR_NEED_FIND = 18;
        ERR_DECREASE = 19;
        ERR_AR_BADCOMMAND = 20;
        ERR_AR_UNKNOWN_OPCODE = 21;
        ERR_AR_WRONGBEGIN = 22;
        ERR_AR_WRONG_END = 23;
        ERR_AR_VALUEOVERFLOW = 24;
        ERR_UNKNOWN = -1;
        ERR_RECEIVE_NULL = 256;
        ERR_PRNPORT_BUSY = 257;
    }

    public native short Rockey(short word0, short aword0[], int ai[], int ai1[], short aword1[], short aword2[], short aword3[], short aword4[], byte abyte0[]);
/*	
	public static void main(String[] args) { 
    
		short func;
		short[] handle=new short[1];
		int[] lp1=new int[1];
		int[] lp2=new int[2];
		short[] p1=new short[1];
		short[] p2=new short[1];
		short[] p3=new short[1];
		short[] p4=new short[1];
		byte[]  buffer=new byte[1024];
		short	retval;
		short[]	rc= new short[4];
		Ry4S ry=new Ry4S();
	
		p1[0] = -(0xffff-0xc44c)-1;
		p2[0] = -(0xffff-0xc8f8)-1;
		p3[0] = 	0x0799;
		p4[0] = -(0xffff-0xc43b)-1;
		
		retval=ry.Rockey(ry.RY_FIND,handle,lp1,lp2,p1,p2,p3,p4,buffer);
		if(retval!=ry.ERR_SUCCESS)
		{
			System.out.println("No Rockey Found! Err:"+retval);
			return;
		}	
  } 
  */
    static 
    {
        System.loadLibrary("Rockey4ND");
    }
}
