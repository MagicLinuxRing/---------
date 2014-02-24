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
    public partial class KidBaseCtrl : UserControl
    {
        private KIDBASE _BLL = new KIDBASE();
        public KidBaseCtrl()
        {
            InitializeComponent();
        }

        private void KidBaseCtrl_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _BLL.GetAllList().Tables[0];
                this.dataGridView_date.DataSource = dt;

                string dbPath = AppDomain.CurrentDomain.BaseDirectory + "ForKids\\DB\\ForKids.mdb";
                //ForKids.Util.AccessDbClass accessDbClass = new ForKids.Util.AccessDbClass(dbPath);
                //DataTable dtt = accessDbClass.GetSchema();
                Dictionary<string, string> fieldCaptionDic = ForKids.Util.AccessDbClass.GetFieldDescriptions(dbPath, "KIDBASE");
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
    }
}
