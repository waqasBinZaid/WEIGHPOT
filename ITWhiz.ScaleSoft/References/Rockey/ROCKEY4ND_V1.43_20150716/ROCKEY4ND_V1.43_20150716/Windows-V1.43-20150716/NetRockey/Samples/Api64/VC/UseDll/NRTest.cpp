/********************************************************************
	created:	2001/06/18
	created:	18:6:2001   9:10
	filename: 	nrtest.cpp		
	
	purpose:	Rockey-Net Client sample for VC++6.0.
				Test functions of NrClient.dll.
				This program need NrClient.dll and clicfg.ini.
*********************************************************************/

#include "stdio.h"
#include "conio.h"
#include "stdlib.h"

#include "NRCLIENT.H"					//Hearder file of NrClient.dll

void	ShowError(HRESULT err);			//Function to print error code.

NETROCKEY		pfnNetRockey=NULL;		//Pointer of function in NrClient.dll
NRGETLASTERROR	pfnNrGetLastError=NULL; //Pointer of function in NrClient.dll
NRSETINIPNAME	pfnSetIniPathName=NULL;	//Pointer of function in NrClient.dll	


int main()
{
	//Load NrClient.dll to process memoryspace.
	HMODULE hDll=LoadLibrary("NrClient_X64.dll");	
	
	if(!hDll) 			
	{		
		printf("can't find NrClient_X64.dll,please copy and try again.\n");
		return 0;
	}
	
	//Locate entry address of function in NrClient.dll
	pfnNetRockey=(NETROCKEY)GetProcAddress(hDll,"NetRockey");
	pfnNrGetLastError=(NRGETLASTERROR)GetProcAddress(hDll,"NrGetLastError");
	pfnSetIniPathName=(NRSETINIPNAME)GetProcAddress(hDll,"SetIniPathName");
	
	if(!pfnNetRockey||!pfnNrGetLastError||!pfnSetIniPathName)
	{
		printf("This is a wrong NrClient_X64.dll,please replace it.\n");
		FreeLibrary(hDll);
		return 0;
	}
	
	
	DWORD		hResult;				//errcode of Function.
	WORD		handle;					//record opened handle.
	WORD		p1, p2, p3, p4;			//WORD	parameters.
	DWORD		lp1, lp2;				//DWORD parameters.
	BYTE		buffer[1024];			//Buffer

	DWORD		hID[256];				//record HardID of found Net-Rockey.
	DWORD		dwMaxRockey=0;			//totle number of found Net-Rockey.

	



	//Find Net-Rockey,using DEMO password.	
	//The high address space (500 ~ 999 )  can't be written in anything with Net-Rockey API ;
	printf("****** Finding Net-Rockeys ...\n");
	p1 = 0xc44c;
	p2 = 0xc8f8;
	p3 = 0;
	p4 = 0;		
	dwMaxRockey=0;
	hResult=pfnNetRockey(RY_FIND,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ERR_SUCCESS==hResult)
	{
		//lp1    ---- HardID of Founded Net-Rockey.
		//buffer ---- computer name of Net-Rockey insert in.
		printf("Found, (%d) HID:%lx @ %s\n",dwMaxRockey,lp1,buffer);
		hID[dwMaxRockey]=lp1;
		dwMaxRockey++;
	}		
	else 
	{		
		//Show Error and exit program.
		ShowError(hResult);
		FreeLibrary(hDll);
		return 0;
	}

	//find other Net-Rockeys.
	while(1)
	{
		hResult=pfnNetRockey(RY_FIND_NEXT,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ERR_SUCCESS==hResult)
		{			
			printf("Found, (%d) HID:%lx @ %s\n",dwMaxRockey,lp1,buffer);
			hID[dwMaxRockey]=lp1;
			dwMaxRockey++;			
		}			
		else break;
	}

	
	printf("\n****** Select rockey and module to open,(exp.Input 0 0)\n");	
	int iRockey,iModule;
	scanf("%d %d",&iRockey,&iModule);	


	//Open a module
	printf("\n****** Opening module %d of %x ...\n",iModule,hID[iRockey]);
	lp1=hID[iRockey];
	lp2=(DWORD)iModule;
	hResult=pfnNetRockey(RY_OPEN,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ERR_SUCCESS==hResult)
	{		
		printf("Opened,Handle:%d\n",handle);
	}		
	else 
	{
		ShowError(hResult); 
		FreeLibrary(hDll);
		exit(0);
	}


	printf("\n****** Press any key to begin testing...\n");
	getch();	

	
	//Read User Memory.
	printf("\n****** Reading user memory ...\n");
	
	BYTE rbuffer[30];
	p1=0; p2=24;
	hResult=pfnNetRockey(RY_READ,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,rbuffer);
	if(ERR_SUCCESS==hResult)
	{
		rbuffer[24]=0;
		printf("Succeed, %s\n",rbuffer);
	}		
	else 
	{
		ShowError(hResult); goto ENDPROGRAM;
	}
	
	//Random number test.
	printf("\n****** Testing Random function...");
	int i;
	for(i=0; i<5;i++)
	{
		hResult=pfnNetRockey(RY_RANDOM,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,rbuffer);
		if(ERR_SUCCESS==hResult) printf("%8x\n",p1);				
		else 
		{
			ShowError(hResult); goto ENDPROGRAM;
		}
	}	
	printf("\n");

	//Seed test.
	lp2=0x3F025;		
	printf("\n****** Seed test,seed is %04x\n",lp2);
	hResult=pfnNetRockey(RY_SEED,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,rbuffer);
	if(ERR_SUCCESS==hResult) printf("%8x%8x%8x%8x\n",p1,p2,p3,p4);			
	else 
	{
		ShowError(hResult); goto ENDPROGRAM;
	}
	
	
	//Read User ID
	lp1=0;
	printf("\n****** Reading UserID...\n");
	hResult=pfnNetRockey(RY_READ_USERID,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,rbuffer);
	if(ERR_SUCCESS==hResult) printf("Succeed,ID = %08lx\n",lp1);			
	else 
	{
		ShowError(hResult); goto ENDPROGRAM;
	}
	
	//Check the property of module 0
	p1=0;	
	printf("\n****** Checking module 0...\n");
	hResult=pfnNetRockey(RY_CHECK_MOUDLE,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,rbuffer);
	if(ERR_SUCCESS==hResult) 
	{
		printf("Succeed,validity:%d,can decrease:%d\n",p2,p3);

		/*if(p3)
		{
			//you can decrese this module by using below code
			p1=0;	
			printf("\n****** Decrease module 0...\n");
			hResult=pfnNetRockey(RY_DECREASE,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,rbuffer);
			if(ERR_SUCCESS==hResult) printf("Succeed.\n");
		}*/
	}
	else 
	{
		ShowError(hResult); goto ENDPROGRAM;
	}

	
	
	//Calculate 1
	lp1=0; lp2=0;
	p1=1;p2=2;p3=3;p4=4;
	printf("\n****** Calculate 1 test,Startposition %d\n",lp1);
	hResult=pfnNetRockey(RY_CALCULATE1,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ERR_SUCCESS==hResult) printf("Succeed,p1=%d,p2=%d,p3=%d,p4=%d\n",p1,p2,p3,p4);			
	else 
	{
		ShowError(hResult); goto ENDPROGRAM;
	}	
	
	// you can do calculate 2,3 here.
	
	
ENDPROGRAM:
	
	//close Rockey.
	pfnNetRockey(RY_CLOSE,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	printf("Handle %x Closed.\n",handle);	
	
	FreeLibrary(hDll);
	getch();
	return 0;
}


void ShowError(HRESULT hResult)
{
	char temp[80];
	
	if(hResult<2000)	sprintf(temp,"Normal error,code %d\n",hResult);			
	else
	{
		sprintf(temp,"Net error,code %d,Extended errcode %d\n",hResult,
			pfnNrGetLastError());
	}	
	printf(temp);
}