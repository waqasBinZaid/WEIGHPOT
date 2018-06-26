// dlldemoDlg.h : header file
//

#if !defined(AFX_DLLDEMODLG_H__1F9D1348_92B5_11D3_A77F_0000B48A6F7A__INCLUDED_)
#define AFX_DLLDEMODLG_H__1F9D1348_92B5_11D3_A77F_0000B48A6F7A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CDlldemoDlg dialog

class CDlldemoDlg : public CDialog
{
// Construction
public:
	void ShowERR(WORD retcode);
	CDlldemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CDlldemoDlg)
	enum { IDD = IDD_DLLDEMO_DIALOG };
	CListBox	mList;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlldemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CDlldemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnButtonTest();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLLDEMODLG_H__1F9D1348_92B5_11D3_A77F_0000B48A6F7A__INCLUDED_)
