// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>
using namespace System;
	typedef  unsigned char   BYTE;
typedef  unsigned short  WORD;
typedef  unsigned int    DWORD;
[System::Runtime::InteropServices::DllImport("Rockey4ND.dll")]
WORD Rockey(WORD function, WORD* handle, DWORD* lp1,  DWORD* lp2, 
            WORD* p1, WORD* p2, WORD* p3, WORD* p4, BYTE* buffer);


int _tmain()
{
    // TODO: Please replace the sample code below with your own.
	WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[1024];

			 function = 1;  //RY_FIND
 			 	
	         p1 = 0xc44c;//please change to you key
	         p2 = 0xc8f8;
	         p3 = 0x0799;
	         p4 = 0xc43b;

		
	
	//find rockey4nd
   retcode= Rockey(1,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
   if(0!=retcode)
   {
	   printf("Find rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
   //open rockey4nd
   retcode=Rockey(3,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
   if(0!=retcode)
   {
	   printf("open rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
   //read rockey4nd
   p1=0;
   p2=10;
   retcode=Rockey(5,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
   if(0!=retcode)
   {
	   printf("read rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
    //close rockey4nd
   retcode=Rockey(4,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
   if(0!=retcode)
   {
	   printf("close rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
   	printf("Success!\r\n");
	return 0;
	
}