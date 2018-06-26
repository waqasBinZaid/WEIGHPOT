// SampleDlg.h : header file
//

#if !defined(AFX_SAMPLEDLG_H__E8052D9A_4523_4C9B_8B37_BEEFD3777BE4__INCLUDED_)
#define AFX_SAMPLEDLG_H__E8052D9A_4523_4C9B_8B37_BEEFD3777BE4__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CSampleDlg dialog

class CSampleDlg : public CDialog
{
// Construction
public:
	void myprintf(TCHAR * lpFmt,...);
	void ShowERR(int ret);
	CSampleDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CSampleDlg)
	enum { IDD = IDD_SAMPLE_DIALOG };
	CEdit	m_editMsg;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSampleDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CSampleDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnStart();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SAMPLEDLG_H__E8052D9A_4523_4C9B_8B37_BEEFD3777BE4__INCLUDED_)
