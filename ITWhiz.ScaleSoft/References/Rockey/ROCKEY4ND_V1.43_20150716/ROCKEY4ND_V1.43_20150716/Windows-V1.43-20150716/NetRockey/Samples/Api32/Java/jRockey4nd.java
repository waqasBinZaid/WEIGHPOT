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

		NetRockey4nd rockey=new NetRockey4nd();
	
		p1[0] = -(0xffff-0xc44c)-1;
		p2[0] = -(0xffff-0xc8f8)-1;
		p3[0] = 	0;
		p4[0] = 0;
		
		retval=rockey.NetRockey4nd(rockey.RY_FIND,handle,lp1,lp2,p1,p2,p3,p4,buffer);
		if(retval!=rockey.ERR_SUCCESS)
		{
			System.out.println("No Rockey Found!");
			return;
		}	
		System.out.println("Find Rock:"+lp1[0]);
		
		lp2[0] = 1;
		retval=rockey.NetRockey4nd(rockey.RY_OPEN,handle,lp1,lp2,p1,p2,p3,p4,buffer);
		if(retval!=rockey.ERR_SUCCESS)
		{
			System.out.println("Open Rockey Failed!");
			return;
		}
		
		hAll[0]=handle[0];
		int i=1;
		while(retval==rockey.ERR_SUCCESS)
		{
			retval=rockey.NetRockey4nd(rockey.RY_FIND_NEXT,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval==rockey.ERR_NOMORE)break;
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Find next rockey failed!");
				return;
			}
			retval=rockey.NetRockey4nd(rockey.RY_OPEN,handle,lp1,lp2,p1,p2,p3,p4,buffer);
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
			
			retval = rockey.NetRockey4nd(rockey.RY_WRITE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Write Rockey Failed!");
				return;
			}			
			System.out.println("Write Text: "+buffer[0]+buffer[1]+buffer[2]+buffer[3]+buffer[4]);
			
			p1[0]=3;
			p2[0]=5;
			for(int m=0;m<5;m++)buffer[m]=0;
			retval = rockey.NetRockey4nd(rockey.RY_READ,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Read Rockey Failed!");
				return;
			}
			System.out.println("Read Text: "+buffer[0]+buffer[1]+buffer[2]+buffer[3]+buffer[4]);
			
			retval=rockey.NetRockey4nd(rockey.RY_RANDOM,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Get random number failed!");
				return;
			}
			System.out.println("Random number: "+  p1[0] +" " + p2[0] + " " + p3[0] +" " + p4[0]) ;			
		
			lp2[0]=0x12345678;
			retval=rockey.NetRockey4nd(rockey.RY_SEED,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Get Seed failed!");
				return;
			}																				
			System.out.println("Seed: "+p1[0]+","+p2[0]+","+p3[0]+","+p4[0]);		
			
			lp1[0]=0;
			retval=rockey.NetRockey4nd(rockey.RY_READ_USERID,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Read UserID failed!");
				return;
			}
			System.out.println("Read User ID: "+lp1[0]);
			
						
			p1[0] = 7;
			retval = rockey.NetRockey4nd(rockey.RY_CHECK_MODULE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
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
			
		
			
			lp1[0] = 0;
			lp2[0] = 7;
			p1[0] = 5;
			p2[0] = 3;
			p3[0] = 1;
			p4[0] = -1;
			retval = rockey.NetRockey4nd(rockey.RY_CALCULATE1,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Caculate failed");
				return; 
			}
			System.out.println("Calculate Input: p1=5, p2=3, p3=1, p4=0xffff");
			System.out.println("Calculate Output: p1="+p1[0]+",p2="+p2[0]+",p3="+p3[0]+",p4="+p4[0]);
			
			
			retval=rockey.NetRockey4nd(rockey.RY_CLOSE,handle,lp1,lp2,p1,p2,p3,p4,buffer);
			if(retval!=rockey.ERR_SUCCESS)
			{
				System.out.println("Close rockey failed!");
				return;
			}
		}
	
	}
}
