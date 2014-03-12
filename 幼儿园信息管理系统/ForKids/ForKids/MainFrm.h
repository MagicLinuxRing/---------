// 这段 MFC 示例源代码演示如何使用 MFC Microsoft Office Fluent 用户界面 
// (“Fluent UI”)。该示例仅供参考，
// 用以补充《Microsoft 基础类参考》和 
// MFC C++ 库软件随附的相关电子文档。
// 复制、使用或分发 Fluent UI 的许可条款是单独提供的。
// 若要了解有关 Fluent UI 许可计划的详细信息，请访问  
// http://msdn.microsoft.com/officeui。
//
// 版权所有(C) Microsoft Corporation
// 保留所有权利。

// MainFrm.h : CMainFrame 类的接口
//

#pragma once
#include "CalendarBar.h"
#include "FileView.h"
#include "ClassView.h"
#include "OutputWnd.h"
#include "PropertiesWnd.h"
#include "Resource.h"

class COutlookBar : public CMFCOutlookBar
{
	virtual BOOL AllowShowOnPaneMenu() const { return TRUE; }
	virtual void GetPaneName(CString& strName) const { BOOL bNameValid = strName.LoadString(IDS_OUTLOOKBAR); ASSERT(bNameValid); if (!bNameValid) strName.Empty(); }
};

using namespace ForKids::UI;

class CForKidsView;

class CMainFrame : public CFrameWndEx
{
	
protected: // 仅从序列化创建
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// 特性
public:
	BOOL m_bLogin;
// 操作
public:

	void SetMainView(CForKidsView* pMainView);

// 重写
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);

// 实现
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // 控件条嵌入成员
	CMFCRibbonBar     m_wndRibbonBar;
	CMFCRibbonApplicationButton m_MainButton;
	CMFCToolBarImages m_PanelImages;
	CMFCRibbonStatusBar  m_wndStatusBar;
	COutlookBar       m_wndNavigationBar;
	CMFCShellTreeCtrl m_wndTree;
	CCalendarBar      m_wndCalendar;
	CMFCCaptionBar    m_wndCaptionBar;
	// 停靠视图窗口
	CFileView         m_wndFileView;
	CClassView        m_wndClassView;
	COutputWnd        m_wndOutput;
	CPropertiesWnd    m_wndProperties;

	CForKidsView*	  m_pMainView;

	gcroot<KidBaseCtrl^>	  m_gcKidBaseCtrl;
	gcroot<GuardianBaseCtrl^> m_gcGuardianBaseCtrl;
	//gcroot<TeacherBaseCtrl<BLL::TEACHERBASE,Model::TEACHERBASE>^>  m_gcTeacherBaseCtrl;

	CString m_strUserCtrlName;
// 生成的消息映射函数
protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnApplicationLook(UINT id);
	afx_msg void OnUpdateApplicationLook(CCmdUI* pCmdUI);
	afx_msg LRESULT OnToolbarCreateNew(WPARAM wp, LPARAM lp);
	afx_msg void OnViewCustomize();
	afx_msg void OnViewCaptionBar();
	afx_msg void OnUpdateViewCaptionBar(CCmdUI* pCmdUI);
	afx_msg void OnOptions();
	afx_msg void OnFilePrint();
	afx_msg void OnFilePrintPreview();
	afx_msg void OnUpdateFilePrintPreview(CCmdUI* pCmdUI);
	DECLARE_MESSAGE_MAP()

	BOOL CreateOutlookBar(CMFCOutlookBar& bar, UINT uiID, CMFCShellTreeCtrl& tree, CCalendarBar& calendar, int nInitialWidth);
	BOOL CreateCaptionBar();
	BOOL CreateDockingWindows();
	void SetDockingWindowIcons(BOOL bHiColorIcons);

	int FindFocusedOutlookWnd(CMFCOutlookBarTabCtrl** ppOutlookWnd);

	CMFCOutlookBarTabCtrl* FindOutlookParent(CWnd* pWnd);
	CMFCOutlookBarTabCtrl* m_pCurrOutlookWnd;
	CMFCOutlookBarPane*    m_pCurrOutlookPage;
public:
	afx_msg void OnButtonAbout();
	afx_msg void OnButtonLogin();
	afx_msg void OnButtonLogoff();
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg void OnMouseLeave();
	afx_msg void OnViewClassview();
	afx_msg void OnUpdateViewClassview(CCmdUI *pCmdUI);
	afx_msg void OnViewOutputwnd();
	afx_msg void OnUpdateViewOutputwnd(CCmdUI *pCmdUI);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnButtonKidbase();
	afx_msg void OnButtonGurdianbase();

	void SetRibbonButtonCheck(UINT nID, BOOL bCheck);

	afx_msg void OnUpdateButtonKidbase(CCmdUI *pCmdUI);
	afx_msg void OnUpdateButtonGurdianbase(CCmdUI *pCmdUI);
	afx_msg void OnButtonTeacherbase();

	void DockControl(const char* strFormName);

	afx_msg void OnUpdateButtonTeacherbase(CCmdUI *pCmdUI);
};


