#include <windows.h>
#include <stdio.h>

#include "..\Rockey4_ND_32.h"
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
	int t1,t2,t3;
  
	char cmd[] = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
	char cmd1[] = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
	char cmd2[] = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
    char cmd3[] = "H=H^H,A=A|A, B=B|B, C=C|C,D=A+B,D=D+C";

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
		p1 = 7;
		p2 = 0x2121;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Set Moudle 7: Pass = %04X Decrease no allow\n", p2);
		printf("\n");

		
	  	lp2 = 0x12345678;
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Seed: %04X %04X %04X %04X\n", p1, p2, p3, p4);
		printf("\n");

		
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
		printf("\n");


		
		p1 = 0;
		strcpy((char*)buffer, cmd);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Write Arithmetic 1\n");
       
	 
		lp1 = 0;
		lp2 = 7;
		p1 = 5;
		p2 = 3;
		p3 = 1;
		p4 = 0xffff;
		retcode = Rockey(RY_CALCULATE1, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Calculate Input: p1=5, p2=3, p3=1, p4=0xffff\n");
		
	
		printf("Result = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = 0xBC71\n");
		printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\n", p1, p2, p3, p4);
		t1=p1;
			
		
		p1 = 10;
		strcpy((char*)buffer, cmd1);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Write Arithmetic 2\n");
       
	 
		lp1 = 10;
		lp2 = 0x12345678;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		retcode = Rockey(RY_CALCULATE2, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Calculate Input: p1=1, p2=2, p3=3, p4=4\n");
		
	
		printf("Result =d03a + 94d6 + 96a9 + 7f54 + 1 + 2 + 3 + 4=0x7b17\n");
		printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\n", p1, p2, p3, p4);
		t2=p1;


		p1 = 17;
		strcpy((char*)buffer, cmd2);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Write Arithmetic 3\n");

		lp1 = 17;
		lp2 = 0;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		retcode = Rockey(RY_CALCULATE3, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Calculate Input: p1=1, p2=2, p3=3, p4=4\n");
		
	 
		printf("Result = 1+2+3+4+1+2+3+4=0x14\n");
		printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\n", p1, p2, p3, p4);
		t3=p1;

		printf("\n");
		p1 = 24;
		strcpy((char*)buffer, cmd3);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Write Arithmetic \n");

		lp1 = 24;
		lp2 = 7;
		p1 = t1;
		p2 = t2;
		p3 = t3;
		p4 = 0;
		retcode = Rockey(RY_CALCULATE1, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		
		printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\n", p1, p2, p3, p4);

				
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
