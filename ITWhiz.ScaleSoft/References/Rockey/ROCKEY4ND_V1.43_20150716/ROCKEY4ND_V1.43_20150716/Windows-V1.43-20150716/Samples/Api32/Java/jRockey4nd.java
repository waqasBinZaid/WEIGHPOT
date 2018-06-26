import java.lang.*;
import FTsafe.*;

class jRockey4nd
{
	public static void main(String[] args)
	{
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
		short[] hAll=new short[128];

		Rockey4nd rockey=new Rockey4nd();
	
		p1[0] = -(0xffff-0xc44c)-1;
		p2[0] = -(0xffff-0xc8f8)-1;
		p3[0] = 	0x0799;
		p4[0] = -(0xffff-0xc43b)-1;
		
		retval=rockey.Rockey4nd(rockey.RY_FIND,handle,lp1,lp2,p1,p2,p3,p4,buffer);
		if(retval!=rockey.ERR_SUCCESS)
		{
			System.out.println("No Rockey Found!");
			return;
		}	
		System.out.println("Find Rock:"+lp1[0]);
		
		retval=rockey.Rockey4nd(rockey.RY_OPEN,handle,lp1,lp2,p1,p2,p3,p4,buffer);
		if(retval!=rockey.ERR_SUCCESS)
		{
			System.out.println("Open Rockey Failed!");
			return;
		}
		
		hAll[0]=handle[0];
		int i=1;
		while(retval==rockey.ERR_SUCCESS)
		{
			retval=rockey.Rockey4nd(rockey.RY_FIND_NEXT,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval==rockey.ERR_NOMORE)break;
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Find next rockey failed!");
				return;
			}
			retval=rockey.Rockey4nd(rockey.RY_OPEN,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Open Rockey Failed!");
				return;
			}
			hAll[i]=handle[0];
			i++;
			System.out.println("Find another Rock:"+lp1[0]);
		}
		
		for(int j=0;j<i;j++)
		{
			handle[0]=hAll[j];
			p1[0]=3;
			p2[0]=5;
//			buffer[0]=12;	buffer[1]=34;	buffer[2]=56;	
	//		buffer[3]=78;	buffer[4]=90;	
			
			buffer[0]='A';	buffer[1]='C';	buffer[2]='c';	
			buffer[3]='B';	buffer[4]='D';	
			
			retval = rockey.Rockey4nd(rockey.RY_WRITE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Write Rockey Failed!");
				return;
			}			
			System.out.println("Write Text: "+buffer[0]+buffer[1]+buffer[2]+buffer[3]+buffer[4]);
			
			p1[0]=3;
			p2[0]=5;
			for(int m=0;m<5;m++)buffer[m]=0;
			retval = rockey.Rockey4nd(rockey.RY_READ,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Read Rockey Failed!");
				return;
			}
			System.out.println("Read Text: "+buffer[0]+buffer[1]+buffer[2]+buffer[3]+buffer[4]);
			
			retval=rockey.Rockey4nd(rockey.RY_RANDOM,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Get random number failed!");
				return;
			}
			System.out.println("Random number: "+  p1[0] +" " + p2[0] + " " + p3[0] +" " + p4[0]) ;			
		
			lp2[0]=0x12345678;
			retval=rockey.Rockey4nd(rockey.RY_SEED,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Get Seed failed!");
				return;
			}																				
			System.out.println("Seed: "+p1[0]+","+p2[0]+","+p3[0]+","+p4[0]);		
			rc[0] = p1[0];
			rc[1] = p2[0];
			rc[2] = p3[0];
			rc[3] = p4[0];
			
			lp1[0] = 0x88888888;
			retval = rockey.Rockey4nd(rockey.RY_WRITE_USERID,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Write UserId failed!");
				return;
			}
			System.out.println("Write User ID: "+lp1[0]);																						
			
			lp1[0]=0;
			retval=rockey.Rockey4nd(rockey.RY_READ_USERID,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Read UserID failed!");
				return;
			}
			System.out.println("Read User ID: "+lp1[0]);
			
			p1[0]=7;
			p2[0]=0x2121;
			p3[0]=0;
			retval = rockey.Rockey4nd(rockey.RY_SET_MODULE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Set module failed!");
				return;
			}
			System.out.println("Set module 7,pass="+p2[0]+",Decreasement not allowed!");
			
			p1[0] = 7;
			retval = rockey.Rockey4nd(rockey.RY_CHECK_MODULE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Chech Module Failed!");
				return;
			}
			System.out.print("Check module 7:");
			if(p2[0]!=0)System.out.println("Allow!");
			else System.out.println("Not Allow!");
			if(p3[0]!=0)System.out.println("Allow decresement!");
			else System.out.println("Decrsement not allowed!");
			
			p1[0]=0;
			buffer[0]='H';buffer[1]='=';buffer[2]='H';
			buffer[3]='^';buffer[4]='H';buffer[5]=',';
			buffer[6]='A';buffer[7]='=';buffer[8]='A';
			buffer[9]='*';buffer[10]='2';buffer[11]='3';
			buffer[12]=',';buffer[13]='F';buffer[14]='=';
			buffer[15]='B';buffer[16]='*';buffer[17]='1';
			buffer[18]='7';buffer[19]=',';buffer[20]='A';
			buffer[21]='=';buffer[22]='A';buffer[23]='+';
			buffer[24]='F';buffer[25]=',';buffer[26]='A';
			buffer[27]='=';buffer[28]='A';buffer[29]='+';
			buffer[30]='G';buffer[31]=',';buffer[32]='A';
			buffer[33]='=';buffer[34]='A';buffer[35]='<';
			buffer[36]='C';buffer[37]=',';buffer[38]='A';
			buffer[39]='=';buffer[40]='A';buffer[41]='^';
			buffer[42]='D';buffer[43]=',';buffer[44]='B';
			buffer[45]='=';buffer[46]='B';buffer[47]='^';
			buffer[48]='B';buffer[49]=',';buffer[50]='C';
			buffer[51]='=';buffer[52]='C';buffer[53]='^';
			buffer[54]='C';buffer[55]=',';buffer[56]='D';
			buffer[57]='=';buffer[58]='D';buffer[59]='^';
			buffer[60]='D';
			
			retval=rockey.Rockey4nd(rockey.RY_WRITE_ARITHMETIC,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("write arithmetic failed!");
				return;
			}
			System.out.println("Write Arithmetic 1,Succeed!");
			
			lp1[0] = 0;
			lp2[0] = 7;
			p1[0] = 5;
			p2[0] = 3;
			p3[0] = 1;
			p4[0] = -1;
			retval = rockey.Rockey4nd(rockey.RY_CALCULATE1,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Caculate failed");
				return; 
			}
			System.out.println("Calculate Input: p1=5, p2=3, p3=1, p4=0xffff");
			System.out.println("Result = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71");
			System.out.println("Calculate Output: p1="+p1[0]+",p2="+p2[0]+",p3="+p3[0]+",p4="+p4[0]);
			
			p1[0]=10;
			buffer[0]='A';buffer[1]='=';buffer[2]='A';buffer[3]='+';buffer[4]='B';buffer[5]=',';
			buffer[6]='A';buffer[7]='=';buffer[8]='A';buffer[9]='+';buffer[10]='C';buffer[11]=',';
			buffer[12]='A';buffer[13]='=';buffer[14]='A';buffer[15]='+';buffer[16]='D';buffer[17]=',';
			buffer[18]='A';buffer[19]='=';buffer[20]='A';buffer[21]='+';buffer[22]='E';buffer[23]=',';
			buffer[24]='A';buffer[25]='=';buffer[26]='A';buffer[27]='+';buffer[28]='F';buffer[29]=',';
			buffer[30]='A';buffer[31]='=';buffer[32]='A';buffer[33]='+';buffer[34]='G';buffer[35]=',';
			buffer[36]='A';buffer[37]='=';buffer[38]='A';buffer[39]='+';buffer[40]='H';buffer[41]=0;
			
			retval=rockey.Rockey4nd(rockey.RY_WRITE_ARITHMETIC,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Write caculate2 failed!");
				return;
			}
			System.out.println("Write caculate2,succeed!");
			
			lp1[0]=10;
			lp2[0]=0x12345678;
			p1[0]=1;
			p2[0]=2;
			p3[0]=3;
			p4[0]=4;
			retval=rockey.Rockey4nd(rockey.RY_CALCULATE2,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Calculate2 failed!");
				return;
			}
			System.out.println("Calculate Input: p1=1, p2=2, p3=3, p4=4");
			System.out.println("Result = "+rc[0]+"+"+rc[1]+"+"+rc[2]+"+"+rc[3]+"+ 1 + 2 + 3 + 4");
			System.out.println("Caculate result: p1="+p1[0]+",p2="+p2[0]+",p3="+p3[0]+",p4="+p4[0]);
			
			p1[0]=9;
			p2[0]=5;
			p3[0]=1;
			retval=rockey.Rockey4nd(rockey.RY_SET_MODULE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Set module failed!");
				return;
			}
			
			p1[0]=17;	
			buffer[0]='A';buffer[1]='=';buffer[2]='E';
			buffer[3]='|';buffer[4]='E';buffer[5]=',';
			buffer[6]='B';buffer[7]='=';buffer[8]='F';
			buffer[9]='|';buffer[10]='F';buffer[11]=',';
			buffer[12]='C';buffer[13]='=';buffer[14]='G';
			buffer[15]='|';buffer[16]='G';buffer[17]=',';
			buffer[18]='D';buffer[19]='=';buffer[20]='H';
			buffer[21]='|';buffer[22]='H';
			
			retval=rockey.Rockey4nd(rockey.RY_WRITE_ARITHMETIC,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("write arithmetic3 failed!");
				return;
			}
			System.out.println("Write arithmetic 3,Succeed!");
			
			lp1[0]=17;
			lp2[0]=6;
			p1[0]=1;
			p2[0]=2;
			p3[0]=3;
			p4[0]=4;
			retval = rockey.Rockey4nd(rockey.RY_CALCULATE3,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("");
				return;
			}	
			System.out.println("Show module from 6: p1="+p1[0]+",p2="+p2[0]+",p3="+p3[0]+",p4="+p4[0]);
			
			p1[0]=9;
			retval=rockey.Rockey4nd(rockey.RY_DECREASE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Decrese failed!");
				return;
			}
			System.out.println("Decrease module 9.");
			
			
			lp1[0] = 17;
			lp2[0] = 6;
			p1[0] = 1;
			p2[0] = 2;
			p3[0] = 3;
			p4[0] = 4;
			
			retval=rockey.Rockey4nd(rockey.RY_CALCULATE3,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("caculate 3 failed!");
				return;
			}
			System.out.println("Show module from 6: p1="+p1[0]+",p2="+p2[0]+",p3="+p3[0]+",p4="+p4[0]);
			
			retval=rockey.Rockey4nd(rockey.RY_CLOSE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Close rockey failed!");
				return;
			}
		}
	}
}
