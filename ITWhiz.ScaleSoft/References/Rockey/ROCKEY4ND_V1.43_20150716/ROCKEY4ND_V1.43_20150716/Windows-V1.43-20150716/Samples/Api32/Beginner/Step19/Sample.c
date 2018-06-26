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
    BYTE buf[1024];
	
	int i, j;
    
	SYSTEMTIME st;

	
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
		
	
		lp1 = 0x20021101;
		retcode = Rockey(RY_WRITE_USERID, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Write User ID: %08X\n", lp1);

		lp1 = 0;
		retcode = Rockey(RY_READ_USERID, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		printf("Read User ID: %08X\n", lp1);

		sprintf(buffer,"%08X",lp1);
        GetLocalTime(&st);
        printf("Date:%04d%02d%02d\n",st.wYear,st.wMonth,st.wDay);
	
		sprintf(buf,"%04d%02d%02d",st.wYear,st.wMonth,st.wDay);
		if(strcmp(buf,buffer)>=0)
		{
			printf("ok!\n");
		}
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
