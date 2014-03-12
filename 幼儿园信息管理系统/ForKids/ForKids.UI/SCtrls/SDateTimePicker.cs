using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ForKids.UI.SCtrls
{
    public partial class SDateTimePicker : DateTimePicker
    {
        public SDateTimePicker()
        {
            InitializeComponent();
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "yyyy-MM-dd";
            this.Controls.Add(_TextBox);
            _TextBox.Location = new Point(2, (this.Height - _TextBox.Height) / 2);
            _TextBox.Width = this.Width - 2 - 38;
        }

        public override string Text
        {
            get { return _TextBox.Text; }
            set 
            {
                if (value == "" || value == null)
                {
                    _TextBox.Text = "";
                }
                else
                {
                    DateTime dt;
                    if (DateTime.TryParse(value, out dt))
                    {
                        //if (dt.CompareTo(this.Value) != 0)
                        //{
                        //    this.Value = dt;
                        //}
                        this.Value = dt;
                        _TextBox.Text = this.Value.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        _TextBox.Text = this.Value.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        private void SDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _TextBox.Text = this.Value.ToString("yyyy-MM-dd");
        }

        //private void _TextBox_TextChanged(object sender, EventArgs e)
        //{
        //    Text = Text;
        //}

        private void _TextBox_Leave(object sender, EventArgs e)
        {
            Text = Text;
        }
    }
}
