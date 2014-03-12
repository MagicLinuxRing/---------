using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace ForKids.DB.Utility
{
    public class DbHelperOleDb
    {
        private static string _OleDbConnString = null;
        public static string OleDbConnString
        {
            get
            {
                if (_OleDbConnString == null)
                    _OleDbConnString = ForKids.Util.ConfigOper.SqlConnString;
                return _OleDbConnString;
            }
        }

        public static bool Exists(string sql, OleDbParameter[] parameters)
        {
            return int.Parse(DbHelperOleDb.GetSingle(sql, parameters).ToString()) != 0;
        }

        ///<summary>
        ///执行简单的SQL语句，返回结果集中的首行首列
        ///</summary>
        ///<param name="sql">要执行的SQL查询语句</param>
        ///<return></return>
        public static object GetSingle(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(OleDbConnString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                object obj = null;
                obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        ///<summary>
        ///执行带参数的SQL语句，返回结果集中的首行首列
        ///</summary>
        ///<param name="sql">要执行的SQL查询语句</param>
        ///<param name="parameters">集合参数</param>
        ///<return></return>
        public static object GetSingle(string sql, OleDbParameter[] parameters)
        {
            using(OleDbConnection conn=new OleDbConnection(OleDbConnString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (OleDbParameter parameter in parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
                object obj = null;
                obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        ///<summary>
        ///执行一条带参数的SQL语句，返回DataTable对象
        ///</summary>
        ///<param name="sql">要执行的SQL查询语句</param>
        ///<param name="parameters">集合参数</param>
        ///<return></return>
        public static DataSet Query(string sql, OleDbParameter[] parameters)
        {
            using(OleDbConnection conn=new OleDbConnection(OleDbConnString))
            {
                conn.Open();
                DataSet ds = null;
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (OleDbParameter parameter in parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }

        ///<summary>
        ///执行不带参数的SQL语句，返回DataTable对象
        ///</summary>
        ///<param name="sql">要执行的SQL查询语句</param>
        ///<return></return>
        public static DataSet Query(string sql)
        {
            using(OleDbConnection conn=new OleDbConnection(OleDbConnString))
            {
                conn.Open();
                DataSet ds = null;
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }

        ///<summary>
        ///执行简单的SQL语句，返回受影响的记录数
        ///</summary>
        ///<param name="sql">要执行的SQL语句</param>
        ///<return>受影响的记录数</return>
        public static int ExecuteSql(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(OleDbConnString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int rows = 0;
                rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }

        ///<summary>
        ///执行带参数的SQL语句，返回受影响的记录数
        ///</summary>
        ///<param name="sql">要执行的SQL语句</param>
        ///<param name="parameters">参数集合</param>
        ///<return>受影响的记录数</return>
        public static int ExecuteSql(string sql, OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(OleDbConnString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (OleDbParameter parameter in parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
                int rows = 0;
                rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }

        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                {
                    if (parm.Value == null)
                    {
                        parm.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parm);
                }
            }
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <param name="key">ID主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>最大ID</returns>
        public static int GetMaxID(string key, string tableName)
        {
            string sql = string.Format("select {0} from {1}", key, tableName);
            object obj = DbHelperOleDb.GetSingle(sql);
            return Convert.ToInt32(obj);
        }
    }
}

