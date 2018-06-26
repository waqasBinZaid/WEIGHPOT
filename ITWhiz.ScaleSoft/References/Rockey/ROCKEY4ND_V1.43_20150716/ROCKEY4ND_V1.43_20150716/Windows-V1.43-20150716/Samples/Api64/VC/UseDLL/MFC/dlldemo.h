// dlldemo.h : main header file for the DLLDEMO application
//

#if !defined(AFX_DLLDEMO_H__1F9D1346_92B5_11D3_A77F_0000B48A6F7A__INCLUDED_)
#define AFX_DLLDEMO_H__1F9D1346_92B5_11D3_A77F_0000B48A6F7A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CDlldemoApp:
// See dlldemo.cpp for the implementation of this class
//

class CDlldemoApp : public CWinApp
{
public:
	CDlldemoApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlldemoApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CDlldemoApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLLDEMO_H__1F9D1346_92B5_11D3_A77F_0000B48A6F7A__INCLUDED_)
