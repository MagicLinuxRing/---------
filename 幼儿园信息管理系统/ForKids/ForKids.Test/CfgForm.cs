using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BAISF
{
    /// <summary>
    /// 可配置表单窗体
    /// </summary>
    public partial class CfgForm : Form
    {
        private FormCfgInfo _FormInfo = null;

        //private int _CurColIndex = 0;
        //private int _CurRowIndex = 0;
        private List<SField> _SFieldList = new List<SField>();

        private Pen _Pen = new Pen(Color.Gray);

        private string _FormName = "";
        public CfgForm(string formName)
        {
            InitializeComponent();
            _FormName = formName;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoPaint(e);
        }

        private void DoPaint(PaintEventArgs e)
        {
            if (_IsResize)
                return;
            //int iHCellCount = this.ClientSize.Width / (CellWidth + CellHDis);
            //int iVCellCount = this.Height / (CellHeight + CellVDis);
            int iTheBottom = this.ClientSize.Height - 1;
            for (int x = 0; x <= _FormInfo.CellHCount; ++x)
            {
                int iLeft = x * (_FormInfo.CellWidth + _FormInfo.CellHDis) + 1;
                e.Graphics.DrawLine(_Pen,
                    new Point(iLeft, 1),
                    new Point(iLeft, iTheBottom));
            }

            int iTheLeft = this.ClientSize.Width - 1;
            for (int y = 0; y < _FormInfo.CellVCount; ++y)
            {
                int iTop = y * (_FormInfo.CellHeight + _FormInfo.CellVDis) + 1;
                e.Graphics.DrawLine(_Pen,
                    new Point(1, iTop),
                    new Point(iTheLeft, iTop));
            }
        }

        bool _IsResize = false;
        private void Form1_Resize(object sender, EventArgs e)
        {
            //DoResize();
            _IsResize = true;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            _IsResize = false;
            //DoResize();
            //Invalidate();
        }

        int _LastWidth = 0;
        int _LastHeight = 0;
        private void DoResize()
        {
            //int iHCellCount = this.ClientSize.Width / (CellWidth + CellHDis);
            //int iVCellCount = this.ClientSize.Height / (CellHeight + CellVDis);
            int iWidth = _FormInfo.CellHCount * (_FormInfo.CellWidth + _FormInfo.CellHDis) + 2;
            int iHeight = _FormInfo.CellVCount * (_FormInfo.CellHeight + _FormInfo.CellVDis) + 2;
            this.ClientSize = new Size(iWidth, iHeight);//Invalidate();
            if(iWidth!=_LastWidth||iHeight!=_LastHeight)
            {

                //// 大小变化才触发
                //int iCount = 0;
                //this.Controls.Clear();
                //for (int y = 0; y < iVCellCount; ++y)
                //{
                //    int iTop = y * (CellHeight + CellVDis) + 1;
                //    for (int x = 0; x < iHCellCount; ++x)
                //    {
                //        int iLeft = x * (CellWidth + CellHDis) + 1;

                //        Label label = new Label();
                //        label.AutoSize = false;
                //        label.TextAlign = ContentAlignment.MiddleLeft;
                //        label.Width = 60;
                //        label.Height = 21;
                //        label.Location = new Point(iLeft + 10, iTop + (CellHeight + CellVDis - label.Height) / 2);
                //        label.Text = string.Format("属性{0}：", ++iCount);
                //        this.Controls.Add(label);

                //        TextBox textBox = new TextBox();
                //        textBox.AutoSize = false;
                //        textBox.Width = 120;
                //        textBox.Height = 23;
                //        textBox.Location = new Point(label.Right + 10, iTop + (CellHeight + CellVDis - textBox.Height) / 2);
                //        textBox.Text = string.Format("文本值{0}：", iCount);
                //        this.Controls.Add(textBox);

                //    }
                //}
            }
            _LastWidth = iWidth;
            _LastHeight = iHeight;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoFormInfo();
            //this.ResizeRedraw = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            DoResize();

            InitSFieldList();

            foreach (SField field in _SFieldList)
            {
                int iWidth = field.ColSpan * (_FormInfo.CellWidth + _FormInfo.CellHDis);
                int iHeight = field.RowSpan * (_FormInfo.CellHeight + _FormInfo.CellVDis);
                int iLeft = field.StartColIndex * (_FormInfo.CellWidth + _FormInfo.CellHDis) + 1;
                int iTop = field.StartRowIndex * (_FormInfo.CellHeight + _FormInfo.CellVDis) + 1;
                if (field.HasLabel)
                {

                    Label label = field.LabelCtrl;
                    label.Location = new Point(iLeft + 10, iTop + (iHeight - label.Height) / 2);

                    this.Controls.Add(label);

                    Control textBox = field.InputCtrl;
                    textBox.Location = new Point(label.Right, iTop + (iHeight - textBox.Height) / 2);

                    if (field.InputType == SInputType.MultiLine)
                        label.Top = textBox.Top;
                    this.Controls.Add(textBox);

                    //_CurRowIndex += sField.RowSpan;
                    //_CurColIndex += sField.ColSpan;
                    //if (_CurRowIndex % CellVCount == 0)
                    //{
                    //    _CurColIndex += 1;
                    //    if (_CurColIndex % CellHCount == 0)
                    //    {
                    //        _CurRowIndex = CellVCount;
                    //    }
                    //}
                }
                else
                {
                    field.InputCtrl.Location = new Point(iLeft + (iWidth - field.InputCtrl.Width) / 2,
                        iTop + (iHeight - field.InputCtrl.Height) / 2);
                    this.Controls.Add(field.InputCtrl);
                }
            }
        }

        private void InfoFormInfo()
        {
            try
            {
                _FormInfo = new FormCfgInfo();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "FormCfg.xml");
                XmlNode node = xmlDoc.SelectSingleNode(string.Format("/Forms/{0}", _FormName));
                _FormInfo.CellHCount = int.Parse(node.Attributes["CellHCount"].Value);
                _FormInfo.CellVCount = int.Parse(node.Attributes["CellVCount"].Value);
                _FormInfo.CellHDis = int.Parse(node.Attributes["CellHDis"].Value);
                _FormInfo.CellVDis = int.Parse(node.Attributes["CellVDis"].Value);
                _FormInfo.CellHeight = int.Parse(node.Attributes["CellHeight"].Value);
                _FormInfo.CellWidth = int.Parse(node.Attributes["CellWidth"].Value);

                this.Text = node.Attributes["Name"].Value;
            }
            catch (System.Exception ex)
            {
                _FormInfo = null;
                MessageBox.Show("加载窗体配置失败！" + ex.Message);
                this.Close();
            }
        }

        private void InitSFieldList()
        {
            //SField sField = new SField("image", _SFieldList.Count, false, SInputType.Image,
            //    Image.FromFile(@"D:\Documents\Pictures\bao\yan.png"));
            //sField.StartRowIndex = 0;
            //sField.StartColIndex = 0;
            //sField.RowSpan = 8;
            //sField.ColSpan = 2;
            //_SFieldList.Add(sField);

            ////        SField sField2 = new SField("image", _SFieldList.Count, false, SInputType.Image,
            ////Image.FromFile(@"D:\Documents\Pictures\bao\yellow.png"));
            ////        sField2.StartRowIndex = 0;
            ////        sField2.StartColIndex = 1;
            ////        sField2.RowSpan = 8;
            ////        sField2.ColSpan = 1;
            ////        _SFieldList.Add(sField2);


            //SField sField3 = new SField("姓名", _SFieldList.Count, true, SInputType.String, "小白");
            //sField3.LabelCtrl.Text = "姓名：";
            //sField3.StartRowIndex = 0;
            //sField3.StartColIndex = 2;
            //sField3.RowSpan = 2;
            //sField3.ColSpan = 1;
            //_SFieldList.Add(sField3);


            //SField sField4 = new SField("年龄", _SFieldList.Count, true, SInputType.Decimal, "22");
            //sField4.LabelCtrl.Text = "年龄：";
            //sField4.StartRowIndex = 2;
            //sField4.StartColIndex = 2;
            //sField4.RowSpan = 2;
            //sField4.ColSpan = 1;
            //_SFieldList.Add(sField4);

            //SField sField5 = new SField("性别", _SFieldList.Count, true, SInputType.Combo, new List<string>() { "男", "女" });
            //sField5.LabelCtrl.Text = "性别：";
            //sField5.StartRowIndex = 4;
            //sField5.StartColIndex = 2;
            //sField5.RowSpan = 2;
            //sField5.ColSpan = 1;
            //_SFieldList.Add(sField5);

            //SField sField6 = new SField("生日", _SFieldList.Count, true, SInputType.Date, "1991-02-12");
            //sField6.LabelCtrl.Text = "生日：";
            //sField6.StartRowIndex = 6;
            //sField6.StartColIndex = 2;
            //sField6.RowSpan = 2;
            //sField6.ColSpan = 1;
            //_SFieldList.Add(sField6);

            //SField sField7 = new SField("简介", _SFieldList.Count, true, SInputType.MultiLine, "因为前几年工作当中接触过一些计算机图形方面的基础内容，所以平时闲暇之余对于游戏开发也就有些好奇。年前听说Milo Yip翻译的新书《游戏引擎架构》要上市了，所以就有心想买来一读，满足一下好奇心。除此之外，出于敬仰译者在对待技术方面的严谨态度，除了拜读以外，也希望能够收藏此书。 上上周的周末，拿到了此书，接下来花了一个多星期的时间通读了一遍。因为自己并不是做游戏开发的，所以这里只是谈一谈自己的阅读感.");
            //sField7.LabelCtrl.Text = "简介：";
            //sField7.StartRowIndex = 8;
            //sField7.StartColIndex = 0;
            //sField7.RowSpan = 3;
            //sField7.ColSpan = 3;
            //_SFieldList.Add(sField7);


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "FormCfg.xml");
            XmlNode node = xmlDoc.SelectSingleNode(string.Format("/Forms/{0}/SFields", _FormName));
            foreach (XmlNode subNode in node.ChildNodes)
            {
                string name = subNode.Attributes["Name"].Value;
                bool hasLabel = subNode.Attributes["HasLabel"].Value == "true";
                string strInputType = subNode.Attributes["InputType"].Value;
                object data = subNode.Attributes["Data"].Value;
                SInputType inputType;
                switch (strInputType)
                {
                    default:
                    case "String":
                        inputType = SInputType.String;
                        break;
                    case "MultiLine":
                        inputType = SInputType.MultiLine;
                        break;
                    case "Decimal":
                        inputType = SInputType.Decimal;
                        break;
                    case "Date":
                        inputType = SInputType.Date;
                        break;
                    case "Combo":
                        inputType = SInputType.Combo;
                        data = data.ToString().Split(';');
                        break;
                    case "Image":
                        inputType = SInputType.Image;
                        break;
                }
                int startRowIndex = int.Parse(subNode.Attributes["StartRowIndex"].Value);
                int startColIndex = int.Parse(subNode.Attributes["StartColIndex"].Value);
                int rowSpan = int.Parse(subNode.Attributes["RowSpan"].Value);
                int colSpan = int.Parse(subNode.Attributes["ColSpan"].Value);

                SField sField = new SField(_FormInfo,name, _SFieldList.Count, hasLabel, inputType, data);
                sField.StartRowIndex = startRowIndex;
                sField.StartColIndex = startColIndex;
                sField.RowSpan = rowSpan;
                sField.ColSpan = colSpan;
                if (hasLabel)
                    sField.Label = subNode.Attributes["Label"].Value;
                _SFieldList.Add(sField);
            }
        }

        //Region _LastRegion = null;
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            _IsResize = false;
            //             Region reg = new Region(this.ClientRectangle);
            //             if (_LastRegion != null)
            //{
            //reg.Exclude(_LastRegion);
            //Invalidate(reg);
            //}
            //_LastRegion = new Region(this.ClientRectangle);
            Invalidate(false);
        }
    }

    public class SField
    {
        private FormCfgInfo _FormCfgInfo;
        public string Name
        {
            get;
            set;
        }

        private Label _LabelCtrl;
        public Label LabelCtrl
        {
            get { return _LabelCtrl; }
        }

        private bool _HasLabel;
        public bool HasLabel
        {
            get { return _HasLabel; }
        }
        private string _Label;
        public string Label
        {
            get { return _HasLabel?_Label:null; }
            set
            {
                _Label = value;
                if (_HasLabel)
                {
                    if (_Label != null)
                        _LabelCtrl.Text = _Label;
                }
            }
        }

        private int _Index;
        public int Index
        {
            get { return _Index; }
        }

        private Control _InputCtrl;
        public Control InputCtrl
        {
            get { return _InputCtrl; }
        }

        private SInputType _InputType;
        public SInputType InputType
        {
            get { return _InputType; }
        }

        private int _StartRowIndex;
        public int StartRowIndex
        {
            get { return _StartRowIndex; }
            set { _StartRowIndex = value; }
        }

        private int _StartColIndex;
        public int StartColIndex
        {
            get { return _StartColIndex; }
            set 
            { 
                _StartColIndex = value; 
            }
        }

        private int _RowSpan;
        public int RowSpan
        {
            get { return _RowSpan; }
            set
            {
                _RowSpan = value;
                if (_InputType == SInputType.Image)
                    this.InputCtrl.Height = _RowSpan * (_FormCfgInfo.CellHeight + _FormCfgInfo.CellVDis) - 20;
                else
                {
                    this.LabelCtrl.Height = 21;
                    if (_InputType == SInputType.MultiLine)
                        this.InputCtrl.Height = _RowSpan * (_FormCfgInfo.CellHeight + _FormCfgInfo.CellVDis) - 20;
                    else
                        this.InputCtrl.Height = 23;
                }
            }
        }

        private int _ColSpan;
        public int ColSpan
        {
            get { return _ColSpan; }
            set
            {
                _ColSpan = value;
                if (_InputType == SInputType.Image)
                    this.InputCtrl.Width = _ColSpan * (_FormCfgInfo.CellWidth + _FormCfgInfo.CellHDis) - 10;
                else
                {
                    this.LabelCtrl.Width = 60;
                    this.InputCtrl.Width = (_FormCfgInfo.CellWidth + _FormCfgInfo.CellHDis) * _ColSpan - this.LabelCtrl.Width - 20;
                }
            }
        }

        public SField(FormCfgInfo formCfgInfo, string name, int index, bool hasLabel, SInputType inputType, object data)
        {
            _FormCfgInfo = formCfgInfo;
            Name = name;
            _HasLabel = hasLabel;
            if (_HasLabel)
            {
                _LabelCtrl = new Label();
                _LabelCtrl.AutoSize = false;
                _LabelCtrl.TextAlign = ContentAlignment.MiddleLeft;
            }
            _InputType = inputType;
            Name = name;
            _Index = index;

            switch (_InputType)
            {
                case SInputType.String:
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = data as string;
                        _InputCtrl = textBox;
                        break;
                    }
                case SInputType.MultiLine:
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = data as string;
                        textBox.Multiline = true;
                        _InputCtrl = textBox;
                        break;
                    }
                case SInputType.Decimal:
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = data as string;
                        _InputCtrl = textBox;
                        break;
                    }
                case SInputType.Combo:
                    {
                        ComboBox comboBox = new ComboBox();
                        comboBox.DataSource = data;
                        _InputCtrl = comboBox;
                        break;
                    }
                case SInputType.Date:
                    {
                        ForKids.UI.SCtrls.SDateTimePicker sDateTimePicker = new ForKids.UI.SCtrls.SDateTimePicker();
                        sDateTimePicker.Text = (data == null ? DateTime.Now.ToString() : data as string);
                        _InputCtrl = sDateTimePicker;
                        break;
                    }
                case SInputType.Image:
                    {
                        PictureBox picBox = new PictureBox();
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        picBox.Image = data as Image;
                        _InputCtrl = picBox;
                        break;
                    }
            }
            if (_InputType != SInputType.Image)
            {
                _InputCtrl.AutoSize = false;
            }
        }

        public object Value
        {
            get
            {
                object val = null;

                switch (_InputType)
                {
                    case SInputType.String:
                        val = _InputCtrl.Text;
                        break;
                    case SInputType.MultiLine:
                        val = _InputCtrl.Text;
                        break;
                    case SInputType.Decimal:
                        val = _InputCtrl.Text;
                        break;
                    case SInputType.Combo:
                        val = _InputCtrl.Text;
                        break;
                    case SInputType.Date:
                        val = _InputCtrl.Text;
                        break;
                    case SInputType.Image:
                        val = _InputCtrl.Text;
                        break;
                }
                return val;
            }
        }
    }

    public enum SInputType
    {
        String = 0,  // 一般文本 
        MultiLine,   // 多行文本
        Decimal,     // 十进制
        Combo,       // 组合框
        Date,        // 日期
        Image,       // 图片
    }

    public class FormCfgInfo
    {
        public int CellWidth = 192;
        public int CellHeight = 20;
        public int CellVDis = 5;
        public int CellHDis = 8;

        public int CellVCount = 20;
        public int CellHCount = 5;
    }
}
