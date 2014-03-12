using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ForKids.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public class SField
    {
        public string Name
        {
            get;
            set;
        }
        
        private Label _Label;
        public string Label        
        {
            get{return _Label.Text;}
            set{_Label.Text = value;}
        }

        private int _Index;
        public int Index
        {
            get{return _Index;}
        }

        private Control _InputCtrl;

        private SInputType _InputType;
        public SInputType InputType
        {
            get{return _InputType;}
        }

        public SField(string name,string label, int index,SInputType inputType,object data)
        {
            Name = name;
            Label = label;
            _InputType = inputType;
            Label = label;
            Name = name;
            _Index = index;

            switch(_InputType)
            {
                case SInputType.String:
                    {
                        _InputCtrl=new TextBox();
                    break;        
                    }
                case SInputType.Decimal:
                    {
                        _InputCtrl=new TextBox();
                    break;        
                    }
                case SInputType.Combo:
                    {
                        _InputCtrl=new ComboBox();
                    break;        
                    }
                case SInputType.Date:
                    {
                        _InputCtrl=new SCtrls.SDateTimePicker();
                    break;        
                    }
                case SInputType.Image:
                    {
                        _InputCtrl=new PictureBox();
                    break;        
                    }
            }
        }

        public SField(string label, string name)
        {
            Label = label;
            Name = name;
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
        Decimal,     // 十进制
        Combo,       // 组合框
        Date,        // 日期
        Image,       // 图片
    }
}
