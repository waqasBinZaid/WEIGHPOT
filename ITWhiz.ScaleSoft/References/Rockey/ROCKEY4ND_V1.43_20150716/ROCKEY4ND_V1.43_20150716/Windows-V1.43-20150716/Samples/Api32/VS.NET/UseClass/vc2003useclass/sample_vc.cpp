// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"
#include "windows.h"
#include "stdio.h"
#using <mscorlib.dll>
using namespace Rockey4NDClass;
using namespace System;

int _tmain()
{
    // TODO: Please replace the sample code below with your own.
	unsigned short handle, p1, p2, p3, p4, retcode;
	unsigned int lp1, lp2;
	unsigned char buffer __gc[]=new unsigned char __gc[1024];
	
	

	Rockey4ND *r4nd=new Rockey4ND();	
	p1 = 0xc44c;
	p2 = 0xc8f8;
	p3 = 0x0799;
	p4 = 0xc43b;

	//find rockey4nd
   retcode= r4nd->Rockey(1,handle, lp1, lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   printf("Find rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
   //open rockey4nd
   retcode=r4nd->Rockey(3,handle,lp1,lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   printf("open rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
   //read rockey4nd
   p1=0;
   p2=10;
   retcode=r4nd->Rockey(5,handle,lp1,lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   printf("read rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
    //close rockey4nd
   retcode=r4nd->Rockey(4,handle,lp1,lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   printf("close rockey4nd error code is %d\n",retcode); 
	   return 1;
   }
   printf("success");
	return 0;
	
}