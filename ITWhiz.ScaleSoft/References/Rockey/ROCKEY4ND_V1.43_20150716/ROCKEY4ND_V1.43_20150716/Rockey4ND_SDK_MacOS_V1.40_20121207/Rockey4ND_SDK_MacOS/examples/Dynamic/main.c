#include <stdio.h>
#include <string.h>
#include <Carbon/Carbon.h>
#include <dlfcn.h>
#include "Rockey4_ND_32.h"


void ShowERR(WORD retcode)
{
	
	if (retcode == 0) return;
	
	
	printf("Error Code: %d\n", retcode);
}

int main(int argc,const char* argv[])
{	
#ifdef USE_DY_LIB
	const char libName[]="libRockey4ndDynamic.dylib";
	char path[256];
	strcpy(path,argv[0]);
	int len=strlen(argv[0]);
	while(argv[0][--len]!='/'){
		
	}
	memcpy(path,argv[0],len+1);
	path[len+1]=0;
	strcat(path,libName);
	//printf("%s\n",path);
	
    void *libHandle=dlopen("libRockey4ndDynamic.dylib",RTLD_LOCAL|RTLD_LAZY);
    if(!libHandle) {
		libHandle=dlopen(path,RTLD_LOCAL|RTLD_LAZY);
		if(!libHandle){
			printf("load libRockey4ndDynamic.dylib failed!\n");
			return -1;
		}
	}
	TRockey Rockey=NULL;
    Rockey=(TRockey)dlsym(libHandle,"Rockey");
    if(!Rockey){
		printf("Get Func Rockey failed!\n");
		return -1;
	}
#endif
	
	int i1=1;
	i1<<=2;
	WORD handle[16], p1, p2, p3, p4, retcode;
	DWORD lp1, lp2;
	BYTE buffer[1024];
	WORD rc[4];
	int i, j;
	
	char cmd[] = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
	char cmd1[] = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
	char cmd2[] = "A=E|E, B=F|F, C=G|G, D=H|H";
	
	p1 = 0xc44c;
	p2 = 0xc8f8;
	p3 = 0x0799;
	p4 = 0xc43b;
	
	retcode = Rockey(RY_FIND, &handle[0], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)
	{
		ShowERR(retcode);
	}
	printf("Find Rock: %08lx\n", lp1);
	retcode = Rockey(RY_OPEN, &handle[0], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (retcode)
	{
		ShowERR(retcode);
		return 0;
	}
	
	i = 1;
	while (retcode == 0)
	{
		retcode = Rockey(RY_FIND_NEXT, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode == ERR_NOMORE) break;
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		
		retcode = Rockey(RY_OPEN, &handle[i], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		
		i++;
		printf("Find Rock: %08X\n", lp1);
	}
	printf("\n");
	
	for (j=0;j<i;j++)
	{
		printf("\nTest Rockey %d:\n",j);
		p1 = 2;
		p2 = 6;
		strcpy((char*)buffer, "Hello1");
		retcode = Rockey(RY_WRITE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Write: Hello1\n");
		
		p1 = 2;
		p2 = 6;
		memset(buffer, 0, 64);
		retcode = Rockey(RY_READ, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Read: %s\n", buffer);
		
		retcode = Rockey(RY_RANDOM, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Random: %04X,%04X,%04X,%04X\n", p1,p2,p3,p4);
		
		
		int k=1;
		//while(true){
		printf("counter %d\n",k++);
		
		lp2 = 0x12345678;
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Seed: %04X %04X %04X %04X\n", p1, p2, p3, p4);
		//sleep(1);
		//}
		rc[0] = p1;
		rc[1] = p2;
		rc[2] = p3;
		rc[3] = p4;
		
		lp1 = 0x23456789;
		retcode = Rockey(RY_WRITE_USERID, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Write User ID: %08X\n", lp1);
		
		lp1 = 0;
		retcode = Rockey(RY_READ_USERID, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Read User ID: %08X\n", lp1);
		
		p1 = 7;
		p2 = 0x2121;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Set Moudle 7: Pass = %04X Decrease no allow\n", p2);
		
		
		p1 = 7;
		retcode = Rockey(RY_CHECK_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Check Moudle 7: ");
		if (p2) printf("Allow   ");
		else printf("No Allow   ");
		if (p3) printf("Allow Decrease\n");
		else printf("Not Allow Decrease\n");
		
		p1 = 0;
		strcpy((char*)buffer, cmd);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
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
			return 0;
		}
		printf("Calculate Input: p1=5, p2=3, p3=1, p4=0xffff\n");
		printf("Result = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71\n");
		printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\n\n", p1, p2, p3, p4);
		
		p1 = 10;
		strcpy((char*)buffer, cmd1);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
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
			return 0;
		}
		printf("Calculate Input: p1=1, p2=2, p3=3, p4=4\n");
		printf("Result = %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x\n", rc[0], rc[1], rc[2], rc[3], (WORD)(rc[0]+rc[1]+rc[2]+rc[3]+10));
		printf("Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\n\n", p1, p2, p3, p4);
		
		// Set Decrease
		p1 = 9;
		p2 = 0x5;
		p3 = 1;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		
		p1 = 17;
		strcpy((char*)buffer, cmd2);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Write Arithmetic 3\n");
		
		lp1 = 17;
		lp2 = 6;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		retcode = Rockey(RY_CALCULATE3, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Show Module from 6: p1=%x, p2=%x, p3=%x, p4=%x\n", p1, p2, p3, p4);
		
		// Decrease
		p1 = 9;
		retcode = Rockey(RY_DECREASE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Decrease module 9\n");
		
		lp1 = 17;
		lp2 = 6;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		retcode = Rockey(RY_CALCULATE3, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		printf("Show Module from 6: p1=%x, p2=%x, p3=%x, p4=%x\n", p1, p2, p3, p4);
		
		retcode = Rockey(RY_CLOSE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return 0;
		}
		
	}
	printf("test complete!---------------------------\n");
	
	return 0;
}
