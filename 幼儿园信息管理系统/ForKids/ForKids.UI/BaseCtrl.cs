using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ForKids.DB.BLL;
using BAISF;

namespace ForKids.UI
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">数据模型</typeparam>
    public partial class BaseCtrl<T_BLL, T_Model> : UserControl
    {
        private object _BLL;
        private Type _TypeBLL;
        private Type _TypeModel;
        private string _FormName = "TeacherBaseForm";
        private string _TBName = "TEACHERBASE";

        public BaseCtrl(string formName, string tbName)
        {
            InitializeComponent();
            _FormName = formName;
            _TBName = tbName;
        }

        private void TeacherBaseCtrl_Load(object sender, EventArgs e)
        {
            _TypeBLL = typeof(T_BLL);
            _BLL = _TypeBLL.GetConstructors()[0].Invoke(null);
            _TypeModel = typeof(T_Model);
            RefreshData();
        }

        private object BLLInvoke(string method, object[] paramers)
        {
            return _TypeBLL.GetMethod(method).Invoke(_BLL, paramers);
        }

        private object ModelGetProperty(object obj, string name)
        {
            return _TypeModel.GetProperty(name).GetValue(obj, null);
        }

        private void ModelSetProperty(object obj, string name, object value)
        {
            _TypeModel.GetProperty(name).SetValue(obj, value, null);
        }

        private DataTable GetDataColumns()
        {
            DataSet ds = BLLInvoke("GetList", new object[] { "1=0" }) as DataSet;
            return ds.Tables[0];
        }

        private void RefreshData()
        {

            DataSet ds = BLLInvoke("GetAllList", null) as DataSet;
            DataTable dt = ds.Tables[0];
            this.dataGridView_date.DataSource = dt;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    this.dataGridView_date.Rows.Add(dr.ItemArray);
            //}
            CommonHelper.SetDGVColumnsDesc(dataGridView_date, _TBName);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            CfgForm cfgForm = new CfgForm(_FormName);
            if (cfgForm.ShowDialog() == DialogResult.OK)
            {
                object model = cfgForm.GetValues<T_Model>();
                bool isSuccess = BLLInvoke("Add", new object[] { model }).Equals(true);
                if (isSuccess)
                {
                    MessageBox.Show("增加成功！"); 
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("增加失败！");
                }
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if(dataGridView_date.SelectedRows.Count!=0)
            {
                DataGridViewRow dr =dataGridView_date.SelectedRows[0];
                ShowEditDlg(dr);
            }
            else
            {
                MessageBox.Show("请选中一项需要修改的记录！");
            }
        }

        private void ShowEditDlg(DataGridViewRow dr)
        {
            int id = int.Parse(dr.Cells["ID"].Value.ToString());
            object model = BLLInvoke("GetModel", new object[] { id });
            if (model != null)
            {
                CfgForm cfgForm = new CfgForm(_FormName);
                cfgForm.SetValues<T_Model>(model);
                if (cfgForm.ShowDialog() == DialogResult.OK)
                {
                    object newModel = cfgForm.GetValues<T_Model>();
                    // newModel.ID = model.ID;
                    ModelSetProperty(newModel, "ID", id);

                    bool isSuccess = BLLInvoke("Update", new object[] { newModel }).Equals(true);
                    if (isSuccess)
                    {
                        MessageBox.Show("修改成功！");
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_date.SelectedRows.Count != 0)
            {
                DataGridViewRow dr = dataGridView_date.SelectedRows[0];
                int id = int.Parse(dr.Cells["ID"].Value.ToString());
                bool isSuccess = BLLInvoke("Delete", new object[] { id }).Equals(true);
                if (isSuccess)
                {
                    MessageBox.Show("删除成功！");
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
            else
            {
                MessageBox.Show("请选中一项需要删除的记录！");
            }
        }

        private void dataGridView_date_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                DataGridViewRow dr = dataGridView_date.Rows[e.RowIndex];
                ShowEditDlg(dr);
            }
        }
    }
}
