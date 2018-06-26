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
	char str[20] = "Hello FeiTian!";
	DWORD mykey = 12345678;
	int n, slen;

	WORD handle[16], p1, p2, p3, p4, retcode;
	DWORD lp1, lp2;
	BYTE buffer[1024];

	int  i,j;

	
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
		slen = strlen(str);
    	// Encrypt my data
	    lp2 = mykey;
	    retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)	// Error
		{
		printf("Error Code: %d\n", retcode);
		return;
		}

		for (n=0;n<slen;n++)
		{
		str[n] = str[n] + (char)p1 + (char)p2 + (char)p3 + (char)p4;
		}
		printf("Encrypted data is %s\n", str);

		// Decrypt my data
		lp2 = mykey;
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)	// Error
		{
		printf("Error Code: %d\n", retcode);
		return;
		}

		for (n=0;n<slen;n++)
		{
		str[n] = str[n] - (char)p1 - (char)p2 - (char)p3 - (char)p4;
		}
		printf("Decrypted data is %s\n", str);

	
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
