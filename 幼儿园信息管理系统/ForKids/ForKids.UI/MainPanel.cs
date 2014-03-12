using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAISF;

namespace ForKids.UI
{
    public partial class MainPanel : UserControl
    {
        private Dictionary<string, Control> _UserCtrlDic = new Dictionary<string, Control>();

        public MainPanel()
        {
            InitializeComponent();
        }

        private void InitUserCtrlDic()
        {
            // 教工基本信息表
            string formName = "TeacherBaseForm", tbName = "TEACHERBASE";
            Control ctrl = new BaseCtrl<ForKids.DB.BLL.TEACHERBASE, ForKids.DB.Model.TEACHERBASE>(formName, tbName);
            AddControl(formName, ctrl);

            // 幼儿基本信息表
            formName = "KidBaseForm";
            tbName = "KIDBASE";
            ctrl = new BaseCtrl<ForKids.DB.BLL.KIDBASE, ForKids.DB.Model.KIDBASE>(formName, tbName);
            AddControl(formName, ctrl);

            // 监护人基本信息表
            formName = "GurdianBaseForm";
            tbName = "GURDIANBASE";
            ctrl = new BaseCtrl<ForKids.DB.BLL.GURDIANBASE, ForKids.DB.Model.GURDIANBASE>(formName, tbName);
            AddControl(formName, ctrl);
        }

        private void AddControl(string name, Control ctrl)
        {
            if (!_UserCtrlDic.ContainsKey(name))
                _UserCtrlDic.Add(name, ctrl);
        }

        public void DockControl(string name)
        {
            if (_UserCtrlDic.ContainsKey(name))
            {
                // 移除掉前一控件
                if (this.Controls.Count > 0)
                {
                    Control oldCtrl = this.Controls[0];
                    this.Controls.Remove(oldCtrl);
                    oldCtrl.Visible = false;
                }

                // 增加控件，填充
                Control ctrl = _UserCtrlDic[name];
                ctrl.Dock = DockStyle.Fill;
                this.Controls.Add(ctrl);
                ctrl.Visible = true;
            }
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            InitUserCtrlDic();
        }
    }
}
