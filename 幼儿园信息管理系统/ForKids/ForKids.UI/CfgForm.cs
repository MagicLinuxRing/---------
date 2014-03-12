using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ForKids.UI.SCtrls;
using System.Reflection;
using System.IO;
using ForKids.Util;

namespace BAISF
{
    /// <summary>
    /// 可配置表单窗体
    /// </summary>
    public partial class CfgForm : Form
    {
        private FormCfgInfo _FormInfo = null;
        private Dictionary<string, SField> _SFieldDic = new Dictionary<string, SField>();

        private Pen _Pen = new Pen(Color.Gray);

        private string _FormName = "";
        public CfgForm(string formName)
        {
            InitializeComponent();
            _FormName = formName;
            Init();
        }

        public static CfgForm CreateCfgForm<T>(string formName, T obj)
        {
            CfgForm cfgForm = new CfgForm(formName);
            cfgForm.SetValues<T>(obj);
            return cfgForm;
        }

        public void SetValues<T>(object obj)
        {
            PropertyInfo[] pis = typeof(T).GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (_SFieldDic.ContainsKey(pi.Name))
                {
                    SField sField = _SFieldDic[pi.Name];
                    object val = pi.GetValue(obj, null);
                    Type piType = pi.PropertyType;
                    if (sField.InputType == SInputType.Int && piType != typeof(int))
                    {
                        if (piType == typeof(short))
                        {
                            val = Convert.ToInt32(val);
                        }
                        else if (piType == typeof(long))
                        {
                            val = Convert.ToInt32(val);
                        }
                    }
                    _SFieldDic[pi.Name].Value = val;
                }
            }
        }

        public object GetValues<T>()
        {
            Type type = typeof(T);
            object obj = (type.GetConstructors()[0].Invoke(null));
            PropertyInfo[] pis = type.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (_SFieldDic.ContainsKey(pi.Name))
                {
                    SField sField=_SFieldDic[pi.Name];
                    Type piType = pi.PropertyType;
                    object val = _SFieldDic[pi.Name].Value;
                    if (sField.InputType == SInputType.Int && piType != typeof(int))
                    {
                        if (piType == typeof(short))
                        {
                            val = Convert.ToInt16(val);
                        } 
                        else if (piType == typeof(long))
                        {
                            val = Convert.ToInt64(val);
                        }
                    }
                    pi.SetValue(obj, val, null);
                }
            }
            return obj;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //DoPaint(e);
        }

        private void DoPaint(PaintEventArgs e)
        {
            if (_IsResize)
                return;
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
            int iWidth = _FormInfo.CellHCount * (_FormInfo.CellWidth + _FormInfo.CellHDis) + 2;
            int iHeight = _FormInfo.CellVCount * (_FormInfo.CellHeight + _FormInfo.CellVDis) + 2;
            this.ClientSize = new Size(iWidth, iHeight);
            _LastWidth = iWidth;
            _LastHeight = iHeight;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Init()
        {
            InfoFormInfo();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            DoResize();

            InitSFieldDic();

            foreach (SField field in _SFieldDic.Values)
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
                }
                else
                {
                    field.InputCtrl.Location = new Point(iLeft + (iWidth - field.InputCtrl.Width) / 2,
                        iTop + (iHeight - field.InputCtrl.Height) / 2);
                    this.Controls.Add(field.InputCtrl);
                }
            }

            int iBottomTop = (_FormInfo.CellVCount - 1) * (_FormInfo.CellHeight + _FormInfo.CellVDis) + 1;

            Button button_cancel = new Button();
            button_cancel.Text = "取消";
            button_cancel.Size = new Size(75, 23);
            button_cancel.Location = new Point(this.ClientSize.Width - 10 - button_cancel.Width,
                         iBottomTop + (_FormInfo.CellHeight + _FormInfo.CellVDis - button_cancel.Height) / 2);

            this.Controls.Add(button_cancel);
            button_cancel.DialogResult = DialogResult.Cancel;
            this.CancelButton = button_cancel;

            Button button_ok = new Button();
            button_ok.Text = "保存";
            button_ok.Size = new Size(75, 23);
            button_ok.Location = new Point(button_cancel.Left - 6 - button_ok.Width, button_cancel.Top);
            this.Controls.Add(button_ok);
            button_ok.DialogResult = DialogResult.None;
            button_ok.Click += new EventHandler(button_ok_Click);
            this.AcceptButton = button_ok;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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

        private void InitSFieldDic()
        {
            // 获取输入枚举列表
            List<string> enumNameList=new List<string>(typeof(SInputType).GetEnumNames());

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "FormCfg.xml");
            XmlNode node = xmlDoc.SelectSingleNode(string.Format("/Forms/{0}/SFields", _FormName));
            foreach (XmlNode subNode in node.ChildNodes)
            {
                string name = subNode.Attributes["Name"].Value;
                bool hasLabel = subNode.Attributes["HasLabel"].Value == "true";
                string strInputType = subNode.Attributes["InputType"].Value;
                object data = subNode.Attributes["Data"].Value;
                int indexEnum =enumNameList.IndexOf(strInputType);
                SInputType inputType = (SInputType)indexEnum;

                int startRowIndex = int.Parse(subNode.Attributes["StartRowIndex"].Value);
                int startColIndex = int.Parse(subNode.Attributes["StartColIndex"].Value);
                int rowSpan = int.Parse(subNode.Attributes["RowSpan"].Value);
                int colSpan = int.Parse(subNode.Attributes["ColSpan"].Value);

                SField sField = new SField(_FormInfo,name, _SFieldDic.Count, hasLabel, inputType, data);
                sField.StartRowIndex = startRowIndex;
                sField.StartColIndex = startColIndex;
                sField.RowSpan = rowSpan;
                sField.ColSpan = colSpan;
                if (hasLabel)
                    sField.Label = subNode.Attributes["Label"].Value;
                _SFieldDic.Add(name, sField);
            }
        }

        //Region _LastRegion = null;
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            _IsResize = false;
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
                    this.InputCtrl.Height = (_RowSpan-1) * (_FormCfgInfo.CellHeight + _FormCfgInfo.CellVDis);
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
                    this.InputCtrl.Width = _ColSpan * (_FormCfgInfo.CellWidth + _FormCfgInfo.CellHDis) - 20;
                else
                {
                    this.LabelCtrl.Width = 70;
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
                case SInputType.Decimal:
                case SInputType.Int:
                case SInputType.Double:
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
                case SInputType.Boolean:
                case SInputType.Combo:
                    {
                        ComboBox comboBox = new ComboBox();
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        if (data != null)
                        {
                            string[] items=data.ToString().Split(';');
                            foreach (string item in items)
                            {
                                comboBox.Items.Add(item);
                            }
                        }
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
                        picBox.SizeMode = PictureBoxSizeMode.Zoom;
                        picBox.BackColor = Color.FromKnownColor(KnownColor.AppWorkspace);
                        picBox.Image = data as Image;
                        _InputCtrl = picBox;
                        picBox.MouseDoubleClick+=new MouseEventHandler(picBox_MouseDoubleClick);
                        break;
                    }
            }
            if (_InputType != SInputType.Image)
            {
                _InputCtrl.AutoSize = false;
            }
        }

        private void picBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "图片文件(*.jpg;*.bmp;*.png;*.gif)|*.jpg;*.bmp;*.png;*.gif";
                ofd.Multiselect = false;
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    (sender as PictureBox).Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        public object Value
        {
            get
            {
                object val = null;
                try
                {
                    switch (_InputType)
                    {
                        case SInputType.String:
                            val = _InputCtrl.Text;
                            break;
                        case SInputType.MultiLine:
                            val = _InputCtrl.Text;
                            break;
                        case SInputType.Decimal:
                            val = decimal.Parse(_InputCtrl.Text);
                            break;
                        case SInputType.Combo:
                            {
                                val = _InputCtrl.Text;
                                break;
                            }
                        case SInputType.Date:
                            {
                                if (_InputCtrl.Text != "")
                                    val = DateTime.Parse(_InputCtrl.Text);
                                break;
                            }
                        case SInputType.Image:
                            {
                                PictureBox picBox = _InputCtrl as PictureBox;
                                if (picBox.Image != null)
                                    val = ImageHelper.ImageToByteArray(picBox.Image, picBox.Image.RawFormat);
                                break;
                            }
                        case SInputType.Boolean:
                            {
                                ComboBox comboBox = _InputCtrl as ComboBox;
                                val = (comboBox.SelectedIndex == 0);
                                break;
                            }
                        case SInputType.Int:
                            val = int.Parse(_InputCtrl.Text);
                            break;
                        case SInputType.Double:
                            val = double.Parse(_InputCtrl.Text);
                            break;
                    }
                }
                catch
                {
                    val = null;
                }
                return val;
            }
            set
            {
                switch (_InputType)
                {
                    case SInputType.String:
                        _InputCtrl.Text = value != null ? value.ToString() : "";
                        break;
                    case SInputType.MultiLine:
                        _InputCtrl.Text = value != null ? value.ToString() : "";
                        break;
                    case SInputType.Decimal:
                    case SInputType.Int:
                    case SInputType.Double:
                        _InputCtrl.Text = value != null ? value.ToString() : "";
                        break;
                    case SInputType.Combo:
                        {
                            if(value!=null)
                            {
                                ComboBox comboBox = _InputCtrl as ComboBox;
                                List<string> itemList = comboBox.DataSource as List<string>;
                                int index = itemList.IndexOf(value.ToString());
                                if (index != -1)
                                    comboBox.SelectedIndex = index;
                            }
                            break;
                        }
                    case SInputType.Date:
                        {
                            _InputCtrl.Text = value != null ? value.ToString() : "";
                            break;
                        }
                    case SInputType.Image:
                        {
                            if (value != null)
                            {
                                PictureBox picBox = _InputCtrl as PictureBox;
                                picBox.Image = ImageHelper.ByteArrayToImage(value as byte[]);
                            }
                            break;
                        }
                    case SInputType.Boolean:
                        {
                            if (value != null)
                            {
                                ComboBox comboBox = _InputCtrl as ComboBox;
                                if (comboBox.Items.Count > 0)
                                    comboBox.SelectedIndex = value.Equals(true) ? 0 : 1;
                            }
                            break;
                        }
                }
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
        Boolean,     // 布尔
        Double,      // 双精度
        Int,         // 整形
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
