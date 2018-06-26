#include <windows.h>
#include <stdio.h>
#include "../Rockey4_ND_32.h"		// Include Rockey Header File

#pragma comment(lib, "..\\Rockey4ND.lib")

// Rockey4 Type
#define  TYPE_ROCKEY4S          0
#define  TYPE_ROCKEY4			1
#define  TYPE_ROCKEY4P			2
#define  TYPE_ROCKEYUSB			3
#define  TYPE_ROCKEYUSBP		4
#define  TYPE_ROCKEYNET			5
#define  TYPE_ROCKEYUSBNET		6
#define  TYPE_ROCEYND			9
#define  TYPE_NETROCKY4		10

void main()
{
	int i, rynum;
	WORD retcode;
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

		printf("Found Rockey: %08X  ", lp1);

		retcode = Rockey(RY_OPEN, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)	// Error
		{
			printf("Error Code: %d\n", retcode);
			return;
		}

		printf("(");
		switch(lp2)
		{
			case TYPE_ROCKEY4:
				printf("Rockey 4 Standard Parallel Port");
				break;
			case TYPE_ROCKEY4P:
				printf("Rockey 4 Plus Parallel Port");
				break;
			case TYPE_ROCKEYUSB:
				printf("Rockey 4 Standard USB Port");
				break;
			case TYPE_ROCKEYUSBP:
				printf("Rockey 4 Plus USB Port");
				break;
			case TYPE_ROCKEYNET:
				printf("Rockey 4 Net Parallel Port");
				break;
			case TYPE_ROCKEYUSBNET:
				printf("Rockey 4 Net USB Port");
				break;
			case TYPE_ROCEYND:
				printf("ROCKEY4ND");
				break;
			case TYPE_NETROCKY4:
				printf("net Rocekey4");
				break;
			default:
				printf("Unknown Type");
		}
		printf(")\n");
	}
	printf("\n");

	rynum = i;

	// Do our work
	for (i=0;i<rynum;i++)
	{
		// Read Rockey user memory
		p1 = 0;		// Pos
		p2 = 10;	// Length
		buffer[10] = 0;
		retcode = Rockey(RY_READ, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)	// Error
		{
			printf("Error Code: %d\n", retcode);
			return;
		}
		printf("%s\n", buffer);		// Output
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
