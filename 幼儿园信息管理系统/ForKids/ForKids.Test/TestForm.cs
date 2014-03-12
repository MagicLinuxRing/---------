using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAISF;

namespace ForKids.Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new CfgForm("KidBaseForm")).Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new CfgForm("GuadianBaseForm")).Show(this);
        }
    }
}
