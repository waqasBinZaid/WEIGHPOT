#include <CoreFoundation/CoreFoundation.h>
#include <stdio.h>
#include <unistd.h>
#include <string.h>
#include "rockey.h"

int test()
{
	unsigned short function,handle,p1,p2,p3,p4;
	unsigned long  lp1,lp2;
	unsigned char buffer[1024];
	unsigned int ret,i;

	function=RY_FIND;
	lp1=0;
	lp2=0;
	p1=0xc44c;p2=0xc8f8;p3=0x0799;p4=0xc43b;
	//p1=0x7cef;p2=0xb08c;p3=0x7038;p4=0xbf4f;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret)
	{
		printf("No Rockey Found=%x\n",ret);
		return ret;
	}
	printf("Rockey Found %08lx\n",lp1);

	
	function=RY_OPEN;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret)
	{
		printf("Open Rockey Failed\n");
		return ret;
	}
	printf("Open Rockey Success\n");
	function=RY_WRITE;
	p1=0;p2=29; 
	memset(buffer,'\0',1024);
	strcpy(buffer,"www.ftsafe.com welcome to you");
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_WRITE FAILED ret=%08x\n",ret);
		return ret;
	}
	printf("RY_WRITE SUCCESS\n");

	function=RY_READ;
	p1=0;p2=116;
	memset(buffer,'\0',1024);
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);

	if(ret||memcmp(buffer,"www.ftsafe.com welcome to you",29)){
		printf("RY_READ FAILED ret=%08x\n",ret);
		return ret;
	}

	printf("read: %s",(char*)buffer);
	printf("RY_READ SUCCESS\n");

	//Write UserID
	function=RY_WRITE_USERID;
	lp1=0x19760111;			//UserID
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_WRITE_USERID FAILED\n");
		return ret;
	}
	printf("RY_WRITE_USERID SUCCESS\n");

	//Read UserID
	function=RY_READ_USERID;
	lp1=0;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret||(lp1!=0x19760111)){
		printf("RY_READ_USERID FAILED!");
		return ret;
	}
	printf("RY_READ_USERID SUCCESS\n");

	function=RY_SET_MODULE;
	p1=15;				//Module Number
	p2=0x1234;				//Module word
	p3=1;				//Module Dec Flags (1=allow,0=deny)
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_SET_MODULE FAILED\n");
		return ret;
	}
	printf("RY_SET_MODULE SUCCESS\n");

	//Check Module Attrible
	function=RY_CHECK_MODULE;
	p1=15;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret||(p2!=1)||(p3!=1)){
		printf("RY_CHECK_MODULE FAILED\n");
		return ret;
	}
	printf("RY_CHECK_MODULE SUCCESS\n");


	function=RY_WRITE_ARITHMETIC;
	p1=7;
	memset(buffer,0,1024);
	strcpy((char *)buffer,"a=a+e,b=b+f,c=c+g,d=d+h");	//define arithmetic set
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_WRITE_ARITHMETIC FAILED\n");
		return ret;
	}
	printf("RY_WRITE_ARITHMETIC SUCCESS\n");

	function=RY_CALCULATE1;
	lp1=7;lp2=15;p1=p2=p3=p4=0;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret||(p3!=0x1234))
	{
		printf("RY_CALCULATE1 FAILED\n");
		return ret;
	}
	printf("RY_CALCULATE1 SUCCESS\n");

	function=RY_CALCULATE2;
	lp1=7;lp2=15;p1=p2=p3=p4=0;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret)
	{
		printf("RY_CALCULATE2 FAILED\n");
		return ret;
	}
	printf("RY_CALCULATE2 SUCCESS\n");

	function=RY_CALCULATE3;
	lp1=7;
	lp2=15;
	p1=p2=p3=p4=0;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret||(p1!=0x1234)){
		printf("RY_CALCULATE3 FAILED\n");
		return ret;
	}
	printf("RY_CALCULATE3 SUCCESS\n");

	function=RY_SET_MODULE;
	p1=15;				//Module Number
	p2=3;				//Module word
	p3=1;				//Module Dec Flags (1=allow,0=deny)
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_SET_MODULE FAILED\n");
		return ret;
	}

	function=RY_DECREASE;
	p1=15;
	for(i=0;i<3;i++){
		ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
		if(ret){
			printf("RY_DECREASE FAILED\n");
			return ret;
		}
	}
	printf("RY_DECREASE SUCCESS\n");

	function=RY_CHECK_MODULE;
	p1=15;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret||(p2!=0)){
		printf("RY_CHECK_MODULE FAILED\n");
		return ret;
	}

	function=RY_SET_MODULE;
	p1=15;				//Module Number
	p2=0;				//Module word
	p3=0;				//Module Dec Flags (1=allow,0=deny)
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_SET_MODULE FAILED\n");
		return ret;
	}
	function=RY_CLOSE;
	ret=Rockey(function,&handle,&lp1,&lp2,&p1,&p2,&p3,&p4,buffer);
	if(ret){
		printf("RY_CLOSE FAILED ret=%08x\n",ret);
		return ret;
	}
	return 0;
}
int main()
{
	char ch;
	while(1){
		printf("********************************************************\n");
		printf("*	Press Enter continue.Press q end test.	       *\n");
		printf("********************************************************\n");
		ch=getchar();
		switch(ch){
		case '\n':
			test();	
			break;
		case 'q':
			return 0;
		}
	}
	return 0;
}
