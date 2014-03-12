using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRESDAMng.UI.SCtrls;

namespace CRESDAMng.MetaDataCheckTool
{
    public partial class DetailForm : Form
    {
        private int _CurDetailLeft = 9;
        private int _CurDetailTop = 15;
        private int _CurNameLeft = 0;
        private int _CurNameTop = 0;
        private int _DetailItemCount = 0;
        private const int LabelWidth = 100;
        private const int TextBoxWidth = 126;
        private const int ItemHDis = 24;
        private const int LabelDis = 4;
        private const int ItemVDis = 16 + 21;
        private const int ItemStartLeft = 9;
        private const int ItemStartTop = 15;
        private Dictionary<string, DetailItem> _DetailItemDic = new Dictionary<string, DetailItem>();
        private Dictionary<string, TextBox> _NameItemDic = new Dictionary<string, TextBox>();
        private Dictionary<string, string> _ValueDic = null; // 属性值字典
        private Dictionary<string, StringPair> _NameDic = null; // 属性值字典
        private Dictionary<string, GDB.Model.DataDict> _DataDictDic = null; // 数据字典
        private Font _BoldFont;
        private Pen _GrayPen;

        private bool _CanEdit = true;

        public DetailForm(string name, Dictionary<string, string> valueDic, Dictionary<string, StringPair> nameDic, bool canEdit, Dictionary<string, GDB.Model.DataDict> dataDictDic)
        {
            InitializeComponent();
            this.Text += " - " + name;

            _ValueDic = new Dictionary<string, string>(valueDic); // 复制，不能使用直接赋值引用 2014/03/04 14:29
            _NameDic = new Dictionary<string, StringPair>(nameDic);
            _CanEdit = canEdit;
            _DataDictDic = dataDictDic;
            _BoldFont = new Font(this.Font, FontStyle.Bold);
            _GrayPen = new Pen(Color.Gray);
        }

        public Dictionary<string, string> ValueDic
        {
            get { return _ValueDic; }
        }

        public Dictionary<string, StringPair> NameDic
        {
            get { return _NameDic; }
        }

        private void DetailForm_SizeChanged(object sender, EventArgs e)
        {
            if (!_CanEdit)
            {
                // 居中
                this.button_ok.Left = (this.Width - this.button_ok.Width) / 2;
            }
            //ReLayoutOutputName();
        }

        private void ReLayoutOutputName()
        {
            SizeF sf = label_outputName.CreateGraphics().MeasureString(label_outputName.Text, label_outputName.Font);
            label_outputName.Left = (this.Width - (int)sf.Width) / 2;
        }

        /// <summary>
        /// 增加详细项
        /// </summary>
        /// <param name="key">属性名</param>
        /// <param name="value">属性值</param>
        public void AddDetailItem(string key, string value)
        {
            if (!_DetailItemDic.ContainsKey(key))
            {
                if (_DataDictDic != null && _DataDictDic.ContainsKey(key))
                {
                    GDB.Model.DataDict dataDict = _DataDictDic[key];
                    if (_DetailItemCount > 0 && _DetailItemCount % 4 == 0)
                    {
                        if (_CurDetailTop + ItemVDis > panel_container.Height)
                        {
                            panel_container.Height += ItemVDis;
                        }
                        _CurDetailTop += ItemVDis;
                        _CurDetailLeft = ItemStartLeft;
                    }
                    int iWidth = 0;
                    Label label = new Label();
                    label.AutoSize = true;
                    label.ForeColor = !dataDict.IsNullable ? Color.Red : label.ForeColor; // 是否为空

                    this.panel_container.Controls.Add(label);
                    label.Location = new Point(_CurDetailLeft, _CurDetailTop + 3);
                    _CurDetailLeft += LabelWidth + LabelDis;
                    label.Text = key;
                    iWidth += label.Width;
                    if (dataDict.ColType != 9 && dataDict.ColType != 10 && dataDict.ColType != 11) // 时间类型
                    {
                        TextBox textBox = new TextBox();
                        textBox.Width = TextBoxWidth;
                        this.panel_container.Controls.Add(textBox);
                        textBox.Location = new Point(_CurDetailLeft, _CurDetailTop);
                        _CurDetailLeft += TextBoxWidth + ItemHDis;
                        textBox.BackColor = Color.White;
                        //textBox.ReadOnly = !_CanEdit; // 是否可编辑
                        textBox.Text = value;

                        _DetailItemDic.Add(key, new DetailItem(textBox, dataDict.IsNullable));
                    }
                    else
                    {
                        SDateTimePicker sdateTimePicker = new SDateTimePicker();
                        sdateTimePicker.Format = DateTimePickerFormat.Custom;
                        sdateTimePicker.CustomFormat = "yyyy-MM-dd"; // 日期格式
                        sdateTimePicker.Width = TextBoxWidth;
                        this.panel_container.Controls.Add(sdateTimePicker);
                        sdateTimePicker.Location = new Point(_CurDetailLeft, _CurDetailTop);
                        _CurDetailLeft += TextBoxWidth + ItemHDis;
                        sdateTimePicker.BackColor = Color.White;
                        //sdateTimePicker.ReadOnly = !_CanEdit; // 是否可编辑
                        DateTime dt;
                        if (DateTime.TryParse(value, out dt))
                            sdateTimePicker.Text = value;
                        else
                            sdateTimePicker.Text = "";
                        _DetailItemDic.Add(key, new DetailItem(sdateTimePicker, dataDict.IsNullable));
                    }
                    ++_DetailItemCount;
                }
            }
        }

        /// <summary>
        /// 增加命名项
        /// </summary>
        /// <param name="key">命名项关键字</param>
        /// <param name="value">命名项值</param>
        /// <param name="split">分隔符</param>
        public void AddNameItem(string key, string value,string split)
        {
            if (!_NameItemDic.ContainsKey(key))
            {
                TextBox textBox = new TextBox();
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Width = TextBoxWidth;
                textBox.Font = _BoldFont;
                this.panel_name.Controls.Add(textBox);
                textBox.Location = new Point(_CurNameLeft, _CurNameTop);
                textBox.BackColor = Color.White;
                //textBox.ReadOnly = !_CanEdit; // 是否可编辑
                textBox.Text = value;
                _NameItemDic.Add(key, textBox);

                Label label = new Label();
                label.AutoSize = true;

                label.Font = _BoldFont;
                label.Text = split;
                this.panel_name.Controls.Add(label);
                _CurNameLeft = textBox.Right;
                label.Location = new Point(_CurNameLeft, _CurNameTop + 3);
                _CurNameLeft = label.Right;
            }
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            button_cancel.Visible = _CanEdit;
            _CurNameTop = label_outputName.Top + label_outputName.Height / 2 - 10; // 命名文本框顶端
            _CurNameLeft = label_outputName.Right + LabelDis; // 命名文本框左端
            if (_CanEdit)
            {
                button_ok.Text = "保存";
            }
            else
            {
                button_ok.Text = "确定";
            }

            this.Width = 4 * (LabelWidth + TextBoxWidth + ItemHDis + LabelDis) + ItemStartLeft * 2;

            this.Height -= ItemVDis;
            this.panel_container.Height -= ItemVDis;
            if (this.panel_main.VerticalScroll.Visible)
                this.Width += 15;

            if (_ValueDic != null)
            {
                foreach (string key in _ValueDic.Keys)
                {
                    AddDetailItem(key, _ValueDic[key]);
                }
            }

            bool bValidName = true; // 命名是否有效
            if (_NameDic != null)
            {
                foreach (string key in _NameDic.Keys)
                {
                    AddNameItem(key, _NameDic[key].Key, _NameDic[key].Value);
                    //name += _NameDic[key].Key + _NameDic[key].Value;
                    if (_NameDic[key].Key == "")
                        bValidName = false;
                }
                this.panel_name.Width = _CurNameLeft;
                //label_outputName.Text = "输出目录名：" + name;
                label_outputName.ForeColor = bValidName ? Color.FromKnownColor(KnownColor.Highlight) : Color.DarkRed;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            // 保存
            _ValueDic.Clear();

            bool hasNoNullableEmpty = false; // 是否有不能为空的空着了
            string curKey ="";
            foreach (string key in _NameItemDic.Keys)
            {
                string text = _NameItemDic[key].Text;
                if ( text == "" ) // 命名项都不能为空的
                {
                    hasNoNullableEmpty = true;
                    curKey = key;
                    break;
                }
                _NameDic[key] = new StringPair(text, _NameDic[key].Value);
            }
            if (hasNoNullableEmpty)
            {
                MessageBox.Show("输出目录命名项不能为空：" + curKey);
                return;
            }

            foreach (string key in _DetailItemDic.Keys)
            {
                string text = _DetailItemDic[key].InputCtrl.Text;
                if (!_DetailItemDic[key].IsNullable && text == "") // 不能为空的
                {
                    hasNoNullableEmpty = true;
                    curKey=key;
                    break;
                }
                _ValueDic.Add(key, text);
            }
            if (!hasNoNullableEmpty)
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("标红的属性为不能为空：" + curKey);
            }
        }

        private void label_outputName_TextChanged(object sender, EventArgs e)
        {
            //ReLayoutOutputName();
        }

        private void panel_name_SizeChanged(object sender, EventArgs e)
        {
            panel_name.Left = (this.Width - (int)panel_name.Width) / 2;
        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_GrayPen, new Point(5, this.panel_name.Bottom + 1), new Point(this.panel_main.Right - 5 - 26, this.panel_name.Bottom + 1));
        }

    }

    public class DetailItem
    {
        public Control InputCtrl;
        public bool IsNullable;

        public DetailItem(Control inputCtrl, bool isNullable)
        {
            InputCtrl = inputCtrl;
            IsNullable = isNullable;
        }
    }
}
