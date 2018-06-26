#include <windows.h>
#include <stdio.h>

#include "../Rockey4_ND_32.h"

#pragma comment(lib, "..\\Rockey4ND.lib")

void ShowERR(WORD retcode)
{
	if (retcode == 0) return;
	printf("Error Code: %d\n", retcode);
}

void main()
{
	WORD handle[16], p1, p2, p3, p4, retcode;
	DWORD lp1, lp2;
	BYTE buffer[1024];

	int i, j;

	
	p1 = 0xc44c;
	p2 = 0xc8f8;
	p3 = 0;
	p4 = 0;

	retcode = Rockey(RY_FIND, &handle[0], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)
	{
		ShowERR(retcode);
		return;
	}
	printf("Find Rock: %08X\n", lp1);
	retcode = Rockey(RY_OPEN, &handle[0], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)
	{
		ShowERR(retcode);
		return;
	}

	i = 1;
	while (retcode == 0)
	{
		retcode = Rockey(RY_FIND_NEXT, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode == ERR_NOMORE) break;
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}

		
		retcode = Rockey(RY_OPEN, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}

		i++;
		printf("Find Rock: %08X\n", lp1);
	}
	printf("\n");

	
	for (j=0;j<i;j++)
	{
		
		lp2 = 0x12345678; 
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Seed: %04X %04X %04X %04X\n", p1, p2, p3, p4);
		
        
		if(p1==0xD03A && p2==0x94D6 && p3==0x96A9 && p4==0x7F54)
         printf("Hello Fei!\n");
		else
		 break;
      

		lp2 = 0x87654321; 
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Seed: %04X %04X %04X %04X\n", p1, p2, p3, p4);
	
        
		if(p1==0xB584 && p2==0xD64F && p3==0xC885 && p4==0x5BA0)
         printf("Hello Tian!\n");
		else
		 break;

		lp2 = 0x18273645; 
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Seed: %04X %04X %04X %04X\n", p1, p2, p3, p4);
	
        
		if(p1==0x2F6D && p2==0x27F8 && p3==0xB3EE && p4==0xBE5A)
         printf("Hello OK!\n");
		else
		 break;


		retcode = Rockey(RY_CLOSE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}

		printf("\n");
		getchar();
	}
}
