using System;   
using System.Data;   
using System.Data.OleDb;
using System.Collections.Generic;

namespace ForKids.Util
{
    /**/
    /// <summary>   
    /// AccessDb 的摘要说明，以下信息请完整保留   
    /// 请在数据传递完毕后调用Close()方法，关闭数据链接。   
    /// </summary>   
    public class AccessDbClass
    {

        #region 变量声明处
        public OleDbConnection Conn;
        public string ConnString;//连接字符串  
        #endregion


        #region 构造函数与连接关闭数据库
        /// <summary>   
        /// 构造函数   
        /// </summary>   
        /// <param name="Dbpath">ACCESS数据库路径</param>   
        public AccessDbClass(string Dbpath)
        {
            if (Dbpath.Substring(Dbpath.LastIndexOf(".") + 1).ToLower() == "accdb")
                ConnString = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=";
            else
                ConnString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
            ConnString += Dbpath;
            Conn = new OleDbConnection(ConnString);
            Conn.Open();
        }

        public DataTable GetSchema()
        {
            return Conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            //return Conn.GetSchema();
        }

        /// <summary>   
        /// 打开数据源链接   
        /// </summary>   
        /// <returns></returns>   
        public OleDbConnection DbConn()
        {
            Conn.Open();
            return Conn;
        }

        /// <summary>   
        /// 请在数据传递完毕后调用该函数，关闭数据链接。   
        /// </summary>   
        public void Close()
        {
            Conn.Close();
        }
        #endregion


        #region 数据库基本操作
        /// <summary>   
        /// 根据SQL命令返回数据DataTable数据表,   
        /// 可直接作为dataGridView的数据源   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public DataTable SelectToDataTable(string SQL)
        {
            using (OleDbCommand command = new OleDbCommand(SQL, Conn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable Dt = new DataTable();
                    adapter.Fill(Dt);
                    return Dt;
                }
            }
        }

        /// <summary>   
        /// 根据SQL命令返回数据DataSet数据集，其中的表可直接作为dataGridView的数据源。   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <param name="subtableName">在返回的数据集中所添加的表的名称</param>   
        /// <returns></returns>   
        public DataSet SelectToDataSet(string SQL, string subtableName)
        {
            using (OleDbCommand command = new OleDbCommand(SQL, Conn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataSet Ds = new DataSet();
                    Ds.Tables.Add(subtableName);
                    adapter.Fill(Ds, subtableName);
                    return Ds;
                }
            }
        }

        /// <summary>   
        /// 在指定的数据集中添加带有指定名称的表，由于存在覆盖已有名称表的危险，返回操作之前的数据集。   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <param name="subtableName">添加的表名</param>   
        /// <param name="DataSetName">被添加的数据集名</param>   
        /// <returns></returns>   
        public DataSet SelectToDataSet(string SQL, string subtableName, DataSet DataSetName)
        {
            using (OleDbCommand command = new OleDbCommand(SQL, Conn))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable Dt = new DataTable();
                    DataSet Ds = new DataSet();
                    Ds = DataSetName;
                    adapter.Fill(DataSetName, subtableName);
                    return Ds;
                }
            }
        }

        /// <summary>   
        /// 根据SQL命令返回OleDbDataAdapter，   
        /// 使用前请在主程序中添加命名空间System.Data.OleDb   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public OleDbDataAdapter SelectToOleDbDataAdapter(string SQL)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            return adapter;
        }

        /// <summary>   
        /// 执行SQL命令，不需要返回数据的修改，删除可以使用本函数   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public bool ExecuteSQLNonquery(string SQL)
        {
            using (OleDbCommand cmd = new OleDbCommand(SQL, Conn))
            {
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        /// <summary>   
        /// 获取表数据数目 
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public int GetDataCount(string tbName)
        {
            string sql = string.Format("select count(*) from {0}", tbName);
            using (OleDbCommand cmd = new OleDbCommand(sql, Conn))
            {
                object obj = cmd.ExecuteScalar();
                return Convert.ToInt32(obj);
            }

        }

        /// <summary>
        /// 获取表属性字段描述字典
        /// </summary>
        /// <param name="dbPath">数据文件路径</param>
        /// <param name="tbName">表名</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDescriptions(string dbPath, string tbName)
        {
            try
            {
                const int dbUseJet = 2;

                dao.Workspace DAOWorkspace;
                dao.Database DAODatabase;
                dao.DBEngine DAODBEngine = new dao.DBEngine();
                //创建一个工作区
                DAOWorkspace = DAODBEngine.CreateWorkspace("WorkSpace", "Admin", "", dbUseJet);

                //打开数据库
                DAODatabase = DAOWorkspace.OpenDatabase(dbPath, false, false, null);
                dao.TableDef DAOTable;

                Dictionary<string, string> fieldCaptionDic = new Dictionary<string, string>();
                // 表对象
                DAOTable = DAODatabase.TableDefs[tbName];
                foreach (dao.Field field in DAOTable.Fields)
                {
                    //读取 UserName 字段的 “标题”属性，如果标题没有设置，则会抛出异常。
                    //如果标题不存在，我们就添加一个标题
                    String descriptionText;
                    try
                    {
                        descriptionText = field.Properties["Description"].Value.ToString();
                    }
                    catch
                    {
                        descriptionText = field.Name;
                    }
                    fieldCaptionDic.Add(field.Name, descriptionText);
                }
                DAODatabase.Close();

                return fieldCaptionDic;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}

