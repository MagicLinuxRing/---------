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

// ForKidsView.cpp : CForKidsView 类的实现
//

#include "stdafx.h"
// SHARED_HANDLERS 可以在实现预览、缩略图和搜索筛选器句柄的
// ATL 项目中进行定义，并允许与该项目共享文档代码。
#ifndef SHARED_HANDLERS
#include "ForKids.h"
#endif

#include "ForKidsDoc.h"
#include "ForKidsView.h"
#include "MainFrm.h"

using namespace ForKids::UI;

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CForKidsView

IMPLEMENT_DYNCREATE(CForKidsView, CView)

BEGIN_MESSAGE_MAP(CForKidsView, CView)
	// 标准打印命令
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CForKidsView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
	ON_WM_SIZE()
END_MESSAGE_MAP()

// CForKidsView 构造/析构

CForKidsView::CForKidsView():m_bLoadMainPanel(FALSE)
{
	// TODO: 在此处添加构造代码

}

CForKidsView::~CForKidsView()
{
}

BOOL CForKidsView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: 在此处通过修改
	//  CREATESTRUCT cs 来修改窗口类或样式

	return CView::PreCreateWindow(cs);
}

// CForKidsView 绘制

void CForKidsView::OnDraw(CDC* /*pDC*/)
{
	CForKidsDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 在此处为本机数据添加绘制代码
}


// CForKidsView 打印


void CForKidsView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CForKidsView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 默认准备
	return DoPreparePrinting(pInfo);
}

void CForKidsView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加额外的打印前进行的初始化过程
}

void CForKidsView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加打印后进行的清理过程
}

void CForKidsView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CForKidsView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CForKidsView 诊断

#ifdef _DEBUG
void CForKidsView::AssertValid() const
{
	CView::AssertValid();
}

void CForKidsView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CForKidsDoc* CForKidsView::GetDocument() const // 非调试版本是内联的
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CForKidsDoc)));
	return (CForKidsDoc*)m_pDocument;
}
#endif //_DEBUG


// CForKidsView 消息处理程序


void CForKidsView::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);

	// TODO: 在此处添加消息处理程序代码
	if(this->m_hWnd!=NULL)
	{
		if(!m_bLoadMainPanel)
		{
			m_gcMainPanel = gcnew MainPanel;
			::SetParent((HWND)m_gcMainPanel->Handle.ToInt32(),this->m_hWnd);
			//DataGridView^ gcDGV = gcnew DataGridView;
			//Label^ gcLabel = gcnew Label;
			//gcLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			//gcLabel->Text=L"一个测试：这是一个C# Label控件，嵌入在基于C++语言的Ribbon风格MFC框架视图中;如果你看到这个能实现，那么所有在C#中能完成的功能，在这里也能完成！";
			//gcLabel->AutoSize=FALSE;
			//gcLabel->Font=gcnew System::Drawing::Font(gcLabel->Font->FontFamily,20,System::Drawing::FontStyle::Bold);
			//gcLabel->Dock=DockStyle::Fill;
			//m_gcMainPanel->Controls->Add(gcLabel);

			//KidBaseCtrl^ gcCtrl = gcnew KidBaseCtrl;
			//DockControl(gcCtrl);

			//Label^ gcLabel = gcnew Label;
			//gcLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			//gcLabel->Text=L"欢迎使用幼儿信息管理系统 v1.0！";
			//gcLabel->AutoSize=FALSE;
			//gcLabel->Font=gcnew System::Drawing::Font(gcLabel->Font->FontFamily,20,System::Drawing::FontStyle::Bold);
			//DockControl(gcLabel);

			m_bLoadMainPanel=true;
		}
		// 使主面板动态填充在视图中
		CRect rect;
		this->GetClientRect(&rect);
		::MoveWindow((HWND)m_gcMainPanel->Handle.ToInt32(),0,0,rect.right,rect.bottom,FALSE);

		this->RedrawWindow();   // 完美解决当存在打开子窗口的时候，改变主框架窗口，会存在 有部分不重绘的现象 @2014/03/02 21:23
	}
}

///* 
// *  停靠控件到视图中
// *  @gcNewCtrl 托管类型的控件对象
// */
//void CForKidsView::DockControl(Control^ gcNewCtrl)
//{
//	// 移除掉前一控件
//	if(m_gcMainPanel->Controls->Count>0)
//	{
//		Control^ gcOldCtrl = m_gcMainPanel->Controls[0];
//		m_gcMainPanel->Controls->Remove(gcOldCtrl);
//		gcOldCtrl->Visible = false;
//	}
//
//	// 增加控件，填充
//	gcNewCtrl->Visible = true;
//	gcNewCtrl->Dock=DockStyle::Fill;
//	m_gcMainPanel->Controls->Add(gcNewCtrl);
//}

/* 
 *  停靠控件到视图中
 *  @gcNewCtrl 托管类型的控件对象
 */
void CForKidsView::DockControl(const char* strFormName)
{
	m_gcMainPanel->DockControl(gcnew System::String(strFormName));
}

void CForKidsView::OnInitialUpdate() 
{
	CView::OnInitialUpdate();
	CFrameWnd* pFrameWnd=GetParentFrame();
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST(CMainFrame,pFrameWnd);
	pMainFrame->SetMainView(this);
}