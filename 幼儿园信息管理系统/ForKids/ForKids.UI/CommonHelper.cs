using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ForKids.UI
{
    public class CommonHelper
    {
        private static string _MDBPath = AppDomain.CurrentDomain.BaseDirectory + "ForKids\\DB\\ForKids.mdb";
        private static Dictionary<string, Dictionary<string, string>> _DGVColumnsDescDic = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// 设置数据表视图列中文描述名
        /// <param name="dgv">数据表视图对象</param>
        /// <param name="tbName">表名</param>
        /// </summary>
        public static bool SetDGVColumnsDesc(DataGridView dgv, string tbName)
        {
            try
            {
                Dictionary<string, string> fieldCaptionDic = null;
                if (_DGVColumnsDescDic.ContainsKey(tbName))
                    fieldCaptionDic = _DGVColumnsDescDic[tbName];
                else
                    fieldCaptionDic = ForKids.Util.AccessDbClass.GetFieldDescriptions(_MDBPath, tbName);
                if (fieldCaptionDic != null)
                {
                    foreach (DataGridViewColumn dc in dgv.Columns)
                    {
                        if (fieldCaptionDic.ContainsKey(dc.Name))
                        {
                            dc.HeaderText = fieldCaptionDic[dc.Name];
                        }
                    }
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("加载数据源失败！" + ex.Message);
                return false;
            }
        }
    }
}
