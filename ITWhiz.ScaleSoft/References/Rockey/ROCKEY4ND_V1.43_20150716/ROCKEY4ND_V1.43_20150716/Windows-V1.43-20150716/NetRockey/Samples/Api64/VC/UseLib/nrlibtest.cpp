// nrlibtest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "nrclient.h"
#include "conio.h"
#include "stdio.h"
#pragma comment (lib,"NrClient_X64.lib")
void ShowError(HRESULT hResult);
int main(int argc, char* argv[])
{

	WORD	handle,p1,p2,p3,p4;
	DWORD	dwRet,lp1,lp2;
	BYTE	buffer[1024];
	
	printf("Find Rockey...\n");

	p1 = 0xc44c;
	p2 = 0xc8f8;
	p3=0x0799;
	p4=0xc43b;
	dwRet=NetRockey(RY_FIND,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);

	if(dwRet)
	{
		printf("Find failed,code %d\n",dwRet);
		return 0;
	}

	printf("Found %08x, server %s\n",lp1,buffer);

	
	p1=0xc44c;
	p2=0xc8f8;
	lp2=0;
	dwRet=NetRockey(RY_OPEN,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(dwRet)
	{
		printf("Open failed,code %d\n",dwRet);
		return 0;
	}

	printf("Opened, handle %d\n",handle);

	printf("press any key to close it.\n");
	getch();

	NetRockey(RY_CLOSE,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);	

	return 0;
}




	




