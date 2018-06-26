//---------------------------------------------------------------------------

#include <vcl.h>
#include <stdio.h>
#pragma hdrstop

#include "Unit1.h"
#include "Rockey4_ND_32.h"

//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}

void _fastcall TForm1::ShowError(WORD wRetCode)
{
if (wRetCode == 0) return;
Memo1->Lines->Add("Error Code: " + AnsiString(wRetCode));
}

//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
	WORD handle;
        WORD p1, p2, p3, p4, wRetCode;
	DWORD lp1, lp2;
	BYTE buffer[1024];
	WORD rc[4];
	int i, j;
        char tbuf[500];

	char cmd[] = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
	char cmd1[] = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
	char cmd2[] = "A=E|E, B=F|F, C=G|G, D=H|H";

	p1 = 50252;
	p2 = 51448;
	p3 = 1945;
	p4 = 50235;

	wRetCode = Rockey(RY_FIND,&handle,&lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (wRetCode)
	{
		ShowError(wRetCode);
		return;
	}
        sprintf(tbuf, "Find Rockey: %08X", lp1);
        Memo1->Lines->Add(tbuf);
	wRetCode = Rockey(RY_OPEN, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
	if (wRetCode)
	{
		ShowError(wRetCode);
		return;
	}

	i = 1;
	while (wRetCode == 0)
	{
		wRetCode = Rockey(RY_FIND_NEXT, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode == ERR_NOMORE) break;
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}

		wRetCode = Rockey(RY_OPEN, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}

		i++;
		sprintf(tbuf, "Find Rockey: %08X", lp1);
                Memo1->Lines->Add(tbuf);
	}
        Memo1->Lines->Add("");

	for (j=0;j<i;j++)
	{
		p1 = 3;
		p2 = 5;
		strcpy((char*)buffer, "Hello");
		wRetCode = Rockey(RY_WRITE,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
                Memo1->Lines->Add("Write: Hello");

		p1 = 3;
		p2 = 5;
		memset(buffer, 0, 64);
		wRetCode = Rockey(RY_READ,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Read: %s", buffer);
                Memo1->Lines->Add(tbuf);

		wRetCode = Rockey(RY_RANDOM,&handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Random: %04X", p1);
                Memo1->Lines->Add(tbuf);

		lp2 = 0x12345678;
		wRetCode = Rockey(RY_SEED, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Seed: %04X %04X %04X %04X", p1, p2, p3, p4);
                Memo1->Lines->Add(tbuf);
		rc[0] = p1;
		rc[1] = p2;
		rc[2] = p3;
		rc[3] = p4;

		lp1 = 0x88888888;
		wRetCode = Rockey(RY_WRITE_USERID, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Write User ID: %08X", lp1);
                Memo1->Lines->Add(tbuf);                

		lp1 = 0;
		wRetCode = Rockey(RY_READ_USERID, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Read User ID: %08X", lp1);
                Memo1->Lines->Add(tbuf);                

		p1 = 7;
		p2 = 0x2121;
		p3 = 0;
		wRetCode = Rockey(RY_SET_MOUDLE, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Set Moudle 7: Pass = %04X Decrease no allow", p2);

		p1 = 7;
		wRetCode = Rockey(RY_CHECK_MOUDLE, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
                strcpy(tbuf, "Check Moudle 7: ");
		if (p2) strcat(tbuf, "Allow   ");
		else strcat(tbuf, "No Allow   ");
		if (p3) strcat(tbuf, "Allow Decrease");
		else strcat(tbuf, "Not Allow Decrease");
                Memo1->Lines->Add(tbuf);

		p1 = 0;
		strcpy((char*)buffer, cmd);
		wRetCode = Rockey(RY_WRITE_ARITHMETIC, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
                Memo1->Lines->Add("Write Arithmetic 1");

		lp1 = 0;
		lp2 = 7;
		p1 = 5;
		p2 = 3;
		p3 = 1;
		p4 = 0xffff;
		wRetCode = Rockey(RY_CALCULATE1, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
                Memo1->Lines->Add("Calculate Input: p1=5, p2=3, p3=1, p4=0xffff");
		Memo1->Lines->Add("Result = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71");
		sprintf(tbuf, "Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x", p1, p2, p3, p4);
                Memo1->Lines->Add(tbuf);

		p1 = 10;
		strcpy((char*)buffer, cmd1);
		wRetCode = Rockey(RY_WRITE_ARITHMETIC, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		Memo1->Lines->Add("Write Arithmetic 2");

		lp1 = 10;
		lp2 = 0x12345678;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		wRetCode = Rockey(RY_CALCULATE2, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		Memo1->Lines->Add("Calculate Input: p1=1, p2=2, p3=3, p4=4");
                sprintf(tbuf, "Result = %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x", rc[0], rc[1], rc[2], rc[3], (WORD)(rc[0]+rc[1]+rc[2]+rc[3]+10));
                Memo1->Lines->Add(tbuf);
		sprintf(tbuf, "Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x", p1, p2, p3, p4);
                Memo1->Lines->Add(tbuf);

		// Set Decrease
		p1 = 9;
		p2 = 0x5;
		p3 = 1;
		wRetCode = Rockey(RY_SET_MOUDLE, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}

		p1 = 17;
		strcpy((char*)buffer, cmd2);
		wRetCode = Rockey(RY_WRITE_ARITHMETIC, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
                Memo1->Lines->Add("Write Arithmetic 3");

		lp1 = 17;
		lp2 = 6;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		wRetCode = Rockey(RY_CALCULATE3, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Show Module from 6: p1=%x, p2=%x, p3=%x, p4=%x", p1, p2, p3, p4);
                Memo1->Lines->Add(tbuf);

		// Decrease
		p1 = 9;
		wRetCode = Rockey(RY_DECREASE, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
                Memo1->Lines->Add("Decrease module 9");

		lp1 = 17;
		lp2 = 6;
		p1 = 1;
		p2 = 2;
		p3 = 3;
		p4 = 4;
		wRetCode = Rockey(RY_CALCULATE3, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}
		sprintf(tbuf, "Show Module from 6: p1=%x, p2=%x, p3=%x, p4=%x", p1, p2, p3, p4);
                Memo1->Lines->Add(tbuf);

		wRetCode = Rockey(RY_CLOSE, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (wRetCode)
		{
			ShowError(wRetCode);
			return;
		}

                Memo1->Lines->Add("Close Rockey Success!");
	}
        
        /*int retcode, handle, select, block_index;
	DWORD uid, hid;
	char buffer[512];

       	retcode = RY2_Find();
	if (retcode < 0)
	{
	ShowError(retcode);
	return;
	}
	if (retcode == 0)
	{
	ShowError(retcode);
	return;
	}  */

}
//---------------------------------------------------------------------------
