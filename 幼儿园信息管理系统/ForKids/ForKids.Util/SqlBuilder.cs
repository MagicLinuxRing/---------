using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForKids.Util
{
    public class SqlBuilder
    {
        /// <summary>
        /// 构建模糊查询sql语句
        /// </summary>
        /// <param name="sql">sql语句字符串引用对象</param>
        /// <param name="filed">字段名</param>
        /// <param name="value">模糊查询条件值</param>
        public static void BuildMoHuSql(ref string sql, string filed, string value)
        {
            sql = sql.Trim();
            if (value != "")
            {
                if (sql == "")
                {
                    sql = " " + filed + " like '%" + value + "%' ";
                }
                else
                {
                    sql += " and " + filed + " like '%" + value + "%' ";
                }
            }
        }

        /// <summary>
        /// 构建时间范围段查询sql语句
        /// </summary>
        /// <param name="sql">sql语句字符串引用对象</param>
        /// <param name="filed">字段名</param>
        /// <param name="value">模糊查询条件值</param>
        public static void BuildYearRangeSql(ref string sql, string filed, int begYear,int endYear)
        {
            sql = sql.Trim();
            string sqlYear = "";
            if (begYear >= 0 && begYear >= 0)
            {
                if (endYear > begYear)
                {
                    sqlYear = " YEAR(" + filed + ") >= " + begYear.ToString() + " and YEAR(" + filed + ") <= " + endYear.ToString();
                }
                else if (endYear < begYear)
                {
                    sqlYear = " YEAR(" + filed + ") <= " + begYear.ToString() + " and YEAR(CY_SJ) >= " + endYear.ToString();
                }
                else
                    sqlYear = " YEAR(" + filed + ") >= " + begYear.ToString();
            }
            else
            {
                if (begYear >= 0)
                {
                    sqlYear = " YEAR(" + filed + ") = " + begYear.ToString();
                }
                else if (endYear >= 0)
                {
                    sqlYear = " YEAR(" + filed + ") = " + endYear.ToString();
                }
                else
                    return;
            }
            if (sql == "")
                sql = sqlYear;
            else
                sql += " and " + sqlYear;
        }

        public static void BuildDateRangeSql(ref string sql, string filed, DateTime dtBegin, DateTime dtEnd)
        {
            string sqlYear = "";
            sql = sql.Trim();
            string begin = dtBegin.ToShortDateString(), end = dtEnd.ToShortDateString();
            if (dtEnd > dtBegin)
            {
                sqlYear = filed + " >= '" + begin + "' and " + filed + " <= '" + end + "'";
            }
            else if (dtEnd < dtBegin)
            {
                sqlYear = filed + " <= '" + begin + "' and " + filed + " >= '" + end + "'";
            }
            else
                // 判断日期相等时，不考虑时分秒的区别，只要年月日相同即可
                sqlYear = "DAY(" + filed + ")" + " = " + dtBegin.Day.ToString() +
                    " and MONTH(" + filed + ")" + " = " + dtBegin.Month.ToString() + 
                    " and YEAR(" + filed + ")" + " = " + dtBegin.Year.ToString();
            if (sql == "")
                sql = sqlYear;
            else
                sql += " and " + sqlYear;
        }

    }
}
