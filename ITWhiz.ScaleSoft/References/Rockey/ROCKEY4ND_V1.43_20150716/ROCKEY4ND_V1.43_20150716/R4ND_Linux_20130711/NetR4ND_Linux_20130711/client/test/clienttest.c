#include <stdio.h>
#include <string.h>
#include "NrClient.h"

void test()
{
        unsigned short function;
	unsigned short handle[16]={0,};
	unsigned short p1,p2,p3,p4;
        unsigned int lp1,lp2,ret;
        unsigned char buffer[1024];
        unsigned int hid[16]={0,};
	int i;
	int rynum;
	char ch;
       
	printf("Find Rockey......\n");
	p1=0xc44c;p2=0xc8f8;p3=0x0799;p4=0xc43b;		//Demo rockey password
	
	for( i = 0; i < 16; i++ )
	{
		if( 0 == i )
		{
			function = RY_FIND;
			ret = NetRockey( function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer );
			if( ret == ERR_NO_ROCKEY )
			{
			       	break;
			}
		}
		else
		{
			function = RY_FIND_NEXT;
			ret = NetRockey( function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer );
			if( ret == ERR_NOMORE )
			{
			       break;
			}
		}
		if( ret )
		{
			printf("Error Code %lx\n", ret );
			return;
		}
		hid[i] = lp1;
	}
	
	rynum = i;
	printf("\nTest Begin............\n");
	printf("Find %d NetRockey\n", rynum); 
	
	//Operation NetRockey
	for( i = 0; i < rynum; i++ )
	{
		printf("\n\nOperation the %dth NetRockey, hid = %x\n",i+1, hid[i]);
		printf("Open module with sharedmode.\n");
		p1=0xc44c;p2=0xc8f8;p3=0x0799;p4=0xc43b;		//Demo rockey password
		lp1 = hid[i];
		//open module 0
		lp2 =0;							
		function = RY_OPEN;
		handle[i] = 0xFFFF;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		
		if( ret || handle[i] == 0xFFFF )
		{
			printf("In clienttest Open %d rockey error=%ld\n",i+1,ret);
	            	return;
	       	}
		//ch=getchar();
	 	//Write data to user memory
		printf("write user memory:");
		function=RY_WRITE;
		p1=0;p2=14;strcpy(buffer,"www.ftsafe.com");
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret) 
		{
			printf("[  FAILED=%ld  ]\n",ret);
		}
		else 
		{
			printf("[ SUCCESS ]\n");
		}

		//Read data form user memory
		function=RY_READ;
		printf("read user memory:");
		p1=0;p2=14;
		memset(buffer,'\0',1024);
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	        if(ret) 
		{
			printf("[READ USER MEMORY FAILED=%ld ]\n",ret);
		}
        	else
	        {
        	        if(memcmp(buffer,"www.ftsafe.com",14))
			{
			        printf("[  FAILED  ]\n");
		        }
			else
			{
		        	printf("[  SUCCESS  ]\n");
			}
	        }
		//Seed function
		printf("seed test:");
		function=RY_SEED;
		lp2=0x19750316;			//seed code
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret)
		{
			printf("[  FAILED  ]\n");
		}
		if(p1==0xe33e&&p2==0x36dc&&p3==0x1c2f&&p4==0x9559)
		{
			printf("[  SUCCESS  ]\n");
		}
		else 
		{
			printf("[  FAILED  ]\n");
		}
	

	        printf("read UserID:");
		//Read UserID
		function=RY_READ_USERID;
		lp1=0;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret)
		{
			printf("[  FAILED  ]\n");
		}
		else
		{
			printf("[  SUCCESS  ]\n");
		}
		
		//check Module Attrible
		printf("check module 0:");
		function=RY_CHECK_MODULE;
		p1=0;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret&&p2!=1&&p3!=1)
		{
			printf("[  FAILED  ]\n");
		}
		else
		{
			printf("[  SUCCESS  ]\n");
		}

		//Calculate 1
		printf("arithmetic calculate1:");
		function=RY_CALCULATE1;
		lp1=0;lp2=0;p1=p2=p3=p4=0;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret&&p3!=11)
		{
			printf("[  FAILED  ]\n");
		}
		else
		{
			printf("[  SUCCESS  ]\n");
		}

		//Calculate 2
		printf("arithmetic calculate2:");
		function=RY_CALCULATE2;
		lp1=0;
		lp2=0x19750316;
		p1=p2=p3=p4=0;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret&&p1!=0xe33e&&p2!=0x36dc&&p3!=0x1c2f&&p4!=0x9559)
		{
			printf("[  FAILED  ]\n");
		}
		else
		{
			printf("[  SUCCESS  ]\n");
		}

		//Calculate 3
		printf("arthmetic calculate3:");
		function=RY_CALCULATE3;
		lp1=0;
		lp2=0;
		p1=p2=p3=p4=0;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret&&p1!=11)
		{
			printf("[  FAILED  ]\n");
		}
		else
		{
			printf("[  SUCCESS  ]\n");
		}

		//Decrease Module word
		printf("decrease module word:");
		function=RY_DECREASE;
		p1=0;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret)
		{
			printf("[  FAILED  ]\n");
		}
		else
		{
 			printf("[ SUCCESS ]\n" );
		}

		//Close rockey
		printf("close rockey...:");
		function=RY_CLOSE;
		ret=NetRockey(function,&handle[i],&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret)
		{
			printf("[  FAILED  CODE IS %ld ]\n", ret);
		}
		else
		{
			printf("[  SUCCESS  ]\n");
		}
	}
	printf("Test complete\n");
}
int main()
{
	char ch;
	while(1){
		printf("********************************************************\n");
		printf("*	Press Enter continue.Press q end test.	       *\n");
		printf("********************************************************\n");
		ch=getchar();
		switch(ch){
		case '\n':
			test();
			break;
		case 'q':
		case 'Q':	
			return 0;
		default:
			break;
		}
	}
	return 0;
}
