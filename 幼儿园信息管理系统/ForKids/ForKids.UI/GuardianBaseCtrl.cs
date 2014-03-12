using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ForKids.DB.BLL;

namespace ForKids.UI
{
    public partial class GuardianBaseCtrl : UserControl
    {
        private GURDIANBASE _BLL = new GURDIANBASE();
        public GuardianBaseCtrl()
        {
            InitializeComponent();
        }

        private void GuardianBaseCtrl_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _BLL.GetAllList().Tables[0];
                this.dataGridView_date.DataSource = dt;

                string dbPath = AppDomain.CurrentDomain.BaseDirectory + "ForKids\\DB\\ForKids.mdb";
                //ForKids.Util.AccessDbClass accessDbClass = new ForKids.Util.AccessDbClass(dbPath);
                //DataTable dtt = accessDbClass.GetSchema();
                Dictionary<string, string> fieldCaptionDic = ForKids.Util.AccessDbClass.GetFieldDescriptions(dbPath, "GURDIANBASE");
                if (fieldCaptionDic != null)
                {

                    foreach (DataColumn col in dt.Columns)
                    {
                        if (fieldCaptionDic.ContainsKey(col.ColumnName))
                        {
                            dataGridView_date.Columns[col.ColumnName].HeaderText = fieldCaptionDic[col.ColumnName];
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("加载数据源失败！" + ex.Message);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {

        }
    }
}
