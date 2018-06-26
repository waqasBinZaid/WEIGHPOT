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
  
	char cmd2[] = "A=E|E,B=F|F,C=G|G,D=H|H";


	p1 = 0xc44c;
	p2 = 0xc8f8;
	p3 = 0x0799;
	p4 = 0xc43b;

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

		p1 = 0;
		p2 = 1;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Set Moudle 0: Pass = %04X Decrease no allow\n", p2);

		p1 = 1;
		p2 = 2;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Set Moudle 1: Pass = %04X Decrease no allow\n", p2);
		p1 = 2;
		p2 = 3;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Set Moudle 2: Pass = %04X Decrease no allow\n", p2);
		p1 = 3;
		p2 = 4;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Set Moudle 3: Pass = %04X Decrease no allow\n", p2);
		                    //  :
        
		
		p1 = 0;
		strcpy((char*)buffer, cmd2);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Write Arithmetic 3\n");

		lp1 = 0;
		lp2 = 0;
		p1 = 0;
		p2 = 0;
		p3 = 0;
		p4 = 0;
		retcode = Rockey(RY_CALCULATE3, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Calculate Input: p1=0, p2=0, p3=0, p4=0\n");
				
		printf("\n");
		printf("Moudle 0: %x\n",p1);
		printf("Moudle 1: %x\n",p2);
		printf("Moudle 2: %x\n",p3);
		printf("Moudle 3: %x\n",p4);
        
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
