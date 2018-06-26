#include <windows.h>
#include <stdio.h>
#include "../Rockey4_ND_32.h"		// Include Rockey Header File

#pragma comment(lib, "..\\Rockey4ND.lib")

void main()
{
	int i, j, rynum;
	WORD retcode;
	DWORD HID[16];

	WORD handle[16], p1, p2, p3, p4;	// Rockey Variable
	DWORD lp1, lp2;						// Rockey Variable
	BYTE buffer[1024];					// Rockey Variable

	p1 = 0xc44c;	// Rockey Demo Password1
	p2 = 0xc8f8;	// Rockey Demo Password2
	p3 = 0;			// Program needn't Password3, Set to 0
	p4 = 0;			// Program needn't Password4, Set to 0

	// Try to find all Rockey
	for (i=0;i<16;i++)
	{
		if (0 == i)
		{
			retcode = Rockey(RY_FIND, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			if (retcode == ERR_NOMORE) break;
		}
		else
		{
			// Notice : lp1 = Last found hardID
			retcode = Rockey(RY_FIND_NEXT, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			if (retcode == ERR_NOMORE) break;
		}

		if (retcode)	// Error
		{
			printf("Error Code: %d\n", retcode);
			return;
		}

		printf("Found Rockey: %08X\n", lp1);
		HID[i] = lp1;	// Save HardID

		retcode = Rockey(RY_OPEN, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)	// Error
		{
			printf("Error Code: %d\n", retcode);
			return;
		}
	}
	printf("\n");

	rynum = i;

	// Do our work
	for (i=0;i<rynum;i++)
	{
		printf("Rockey %08X module status: ", HID[i]);
		
		for (j=0;j<64;j++)
		{
			p1 = j;		// Module No
			retcode = Rockey(RY_CHECK_MOUDLE, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			if (retcode)	// Error
			{
				printf("Error Code: %d\n", retcode);
				return;
			}

			if (p2) 
				printf("O");
			else 
				printf("X");
		}
		printf("\n");
	}

	// Close all opened Rockey
	for (i=0;i<rynum;i++)
	{
		retcode = Rockey(RY_CLOSE, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			printf("Error Code: %d\n", retcode);
			return;
		}
	}
}
