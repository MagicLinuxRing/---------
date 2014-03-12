
// ForKids_WinView.cpp : CForKids_WinView 类的实现
//

#include "stdafx.h"
// SHARED_HANDLERS 可以在实现预览、缩略图和搜索筛选器句柄的
// ATL 项目中进行定义，并允许与该项目共享文档代码。
#ifndef SHARED_HANDLERS
#include "ForKids_Win.h"
#endif

#include "ForKids_WinDoc.h"
#include "ForKids_WinView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CForKids_WinView

IMPLEMENT_DYNCREATE(CForKids_WinView, CView)

BEGIN_MESSAGE_MAP(CForKids_WinView, CView)
	// 标准打印命令
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CForKids_WinView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// CForKids_WinView 构造/析构

CForKids_WinView::CForKids_WinView()
{
	// TODO: 在此处添加构造代码

}

CForKids_WinView::~CForKids_WinView()
{
}

BOOL CForKids_WinView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: 在此处通过修改
	//  CREATESTRUCT cs 来修改窗口类或样式

	return CView::PreCreateWindow(cs);
}

// CForKids_WinView 绘制

void CForKids_WinView::OnDraw(CDC* /*pDC*/)
{
	CForKids_WinDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 在此处为本机数据添加绘制代码
}


// CForKids_WinView 打印


void CForKids_WinView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CForKids_WinView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 默认准备
	return DoPreparePrinting(pInfo);
}

void CForKids_WinView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加额外的打印前进行的初始化过程
}

void CForKids_WinView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 添加打印后进行的清理过程
}

void CForKids_WinView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CForKids_WinView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CForKids_WinView 诊断

#ifdef _DEBUG
void CForKids_WinView::AssertValid() const
{
	CView::AssertValid();
}

void CForKids_WinView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CForKids_WinDoc* CForKids_WinView::GetDocument() const // 非调试版本是内联的
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CForKids_WinDoc)));
	return (CForKids_WinDoc*)m_pDocument;
}
#endif //_DEBUG


// CForKids_WinView 消息处理程序
