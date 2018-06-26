// SampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Sample.h"
#include "SampleDlg.h"
#include "Rockey4_ND_32.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

wchar_t * astr2wstr(const char *astr,wchar_t *wstr,int dstlen){
	wchar_t *wp=wstr;
	//assert(wstr!=NULL && astr !=NULL);
	while(*astr !=0 && (dstlen--)>0){
		*wp++=(wchar_t)(*astr++);
	}
	*wp=0;
	return wstr;
}
/////////////////////////////////////////////////////////////////////////////
// CSampleDlg dialog

CSampleDlg::CSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSampleDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CSampleDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSampleDlg)
	DDX_Control(pDX, IDC_EDIT1, m_editMsg);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CSampleDlg, CDialog)
	//{{AFX_MSG_MAP(CSampleDlg)
	ON_BN_CLICKED(IDC_Start, OnStart)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSampleDlg message handlers

BOOL CSampleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	CenterWindow(GetDesktopWindow());	// center to the hpc screen

	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}



void CSampleDlg::OnStart() 
{
	// TODO: Add your control notification handler code here
	m_editMsg.SetSel(0, -1, FALSE);
	m_editMsg.ReplaceSel(L"");
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
		return;
	}
	myprintf(L"Find Rock: %08X\r\n", lp1);
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
		myprintf(L"Find Rock: %08X\r\n", lp1);
	}
	myprintf(L"\r\n");

	for (j=0;j<i;j++)
	{
		strcpy((char*)buffer, "Hello World");
		p1 = 450;
		p2 = strlen((char*)buffer)+1;

		retcode = Rockey(RY_WRITE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Write: Hello World\r\n");

		p1 = 450;
		p2 = strlen((char*)buffer)+1;
		memset(buffer, 0, 64);
		retcode = Rockey(RY_READ, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		WCHAR wbuf[128]={0};
		astr2wstr((char*)buffer,wbuf,strlen((char*)buffer)+1);
		myprintf(L"Read: %s\r\n", wbuf);
		
		retcode = Rockey(RY_RANDOM, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Random: %04X,%04X,%04X,%04X\r\n", p1,p2,p3,p4);

		lp2 = 0x12345678;
		retcode = Rockey(RY_SEED, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Seed: %04X %04X %04X %04X\r\n", p1, p2, p3, p4);
		rc[0] = p1;
		rc[1] = p2;
		rc[2] = p3;
		rc[3] = p4;

		lp1 = 0x88888888;
		retcode = Rockey(RY_WRITE_USERID, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Write User ID: %08X\r\n", lp1);

		lp1 = 0;
		retcode = Rockey(RY_READ_USERID, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Read User ID: %08X\r\n", lp1);

		p1 = 7;
		p2 = 0x2121;
		p3 = 0;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Set Moudle 7: Pass = %04X Decrease no allow\r\n", p2);

		p1 = 7;
		retcode = Rockey(RY_CHECK_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Check Moudle 7: ");
		if (p2) myprintf(L"Allow   ");
		else myprintf(L"No Allow   ");
		if (p3) myprintf(L"Allow Decrease\r\n");
		else myprintf(L"Not Allow Decrease\r\n");

		p1 = 0;
		strcpy((char*)buffer, cmd);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Write Arithmetic 1\r\n");

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
		myprintf(L"Calculate Input: p1=5, p2=3, p3=1, p4=0xffff\r\n");
		myprintf(L"Result = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71\r\n");
		myprintf(L"Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\r\n", p1, p2, p3, p4);

		p1 = 10;
		strcpy((char*)buffer, cmd1);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Write Arithmetic 2\r\n");

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
		myprintf(L"Calculate Input: p1=1, p2=2, p3=3, p4=4\r\n");
		myprintf(L"Result = %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x\r\n", rc[0], rc[1], rc[2], rc[3], (WORD)(rc[0]+rc[1]+rc[2]+rc[3]+10));
		myprintf(L"Calculate Output: p1=%x, p2=%x, p3=%x, p4=%x\r\n", p1, p2, p3, p4);

		// Set Decrease
		p1 = 9;
		p2 = 0x5;
		p3 = 1;
		retcode = Rockey(RY_SET_MOUDLE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}

		p1 = 17;
		strcpy((char*)buffer, cmd2);
		retcode = Rockey(RY_WRITE_ARITHMETIC, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Write Arithmetic 3\r\n");

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
			return;
		}
		myprintf(L"Show Module from 6: p1=%x, p2=%x, p3=%x, p4=%x\r\n", p1, p2, p3, p4);

		// Decrease
		p1 = 9;
		retcode = Rockey(RY_DECREASE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}
		myprintf(L"Decrease module 9\r\n");

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
			return;
		}
		myprintf(L"Show Module from 6: p1=%x, p2=%x, p3=%x, p4=%x\r\n", p1, p2, p3, p4);

		retcode = Rockey(RY_CLOSE, &handle[j], &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
		if (retcode)
		{
			ShowERR(retcode);
			return;
		}

		myprintf(L"\r\n");
	
	}
}

void CSampleDlg::ShowERR(int ret)
{
	if (ret == 0) return;
	myprintf(L"Error Code: %d\r\n", ret);
}

void CSampleDlg::myprintf(TCHAR *lpFmt, ...)
{
	TCHAR szBuf[1024]={0};
	va_list argList;
	va_start(argList, lpFmt);		
	_vstprintf(szBuf,lpFmt, argList);
	va_end(argList);

	int len = m_editMsg.GetWindowTextLength();
	
	m_editMsg.SetSel(len+2, len+2, FALSE);
	m_editMsg.ReplaceSel(szBuf);
}
