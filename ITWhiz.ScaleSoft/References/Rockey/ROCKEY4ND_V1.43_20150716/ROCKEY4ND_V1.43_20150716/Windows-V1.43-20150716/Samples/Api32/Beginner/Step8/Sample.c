#include <windows.h>
#include <stdio.h>
#include "../Rockey4_ND_32.h"		// Include Rockey Header File

#pragma comment(lib, "..\\Rockey4ND.lib")

void main()
{
	// ==============================================================
	WORD retcode;
	WORD handle, p1, p2, p3, p4;	// Rockey Variable
	DWORD lp1, lp2;					// Rockey Variable
	BYTE buffer[1024];				// Rockey Variable

	p1 = 0xc44c;	// Rockey Demo Password1
	p2 = 0xc8f8;	// Rockey Demo Password2
	p3 = 0x0799;	// Rockey Demo Password3
	p4 = 0xc43b;	// Rockey Demo Password4

	// Try to find specified Rockey
	retcode = Rockey(RY_FIND, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)	// Not found
	{
		printf("ROCKEY not found!\n");
		return;
	}
	
	retcode = Rockey(RY_OPEN, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)	// Error	
	{	printf("Error Code: %d\n", retcode);		
		return;	
	}
    

    lp1 = 0x88888888;
	retcode = Rockey(RY_WRITE_USERID, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode) // Error
	{	
		printf("Error Code: %d\n", retcode);	
		return;
	}	
		printf("Write User ID: %08X\n", lp1);


	retcode = Rockey(RY_CLOSE, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)
	{
		printf("Error Code: %d\n", retcode);
		return;
	}
	
	
}
