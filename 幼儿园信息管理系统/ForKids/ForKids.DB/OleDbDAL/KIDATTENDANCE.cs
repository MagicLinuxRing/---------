using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using ForKids.DB.IDAL;
using ForKids.DB.Utility;//Please add references
namespace ForKids.DB.OleDbDAL
{
	/// <summary>
	/// 数据访问类:KIDATTENDANCE
	/// </summary>
	public partial class KIDATTENDANCE:IKIDATTENDANCE
	{
		public KIDATTENDANCE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "KIDATTENDANCE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KIDATTENDANCE");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ForKids.DB.Model.KIDATTENDANCE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into KIDATTENDANCE(");
			strSql.Append("KIDID,COURSEID,ISATTEND,ATTENDDATE,DESCRIPTION)");
			strSql.Append(" values (");
			strSql.Append("@KIDID,@COURSEID,@ISATTEND,@ATTENDDATE,@DESCRIPTION)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@KIDID", OleDbType.SmallInt),
					new OleDbParameter("@COURSEID", OleDbType.SmallInt),
					new OleDbParameter("@ISATTEND", OleDbType.Boolean,1),
					new OleDbParameter("@ATTENDDATE", OleDbType.Date),
					new OleDbParameter("@DESCRIPTION", OleDbType.VarChar,255)};
			parameters[0].Value = model.KIDID;
			parameters[1].Value = model.COURSEID;
			parameters[2].Value = model.ISATTEND;
			parameters[3].Value = model.ATTENDDATE;
			parameters[4].Value = model.DESCRIPTION;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.KIDATTENDANCE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update KIDATTENDANCE set ");
			strSql.Append("KIDID=@KIDID,");
			strSql.Append("COURSEID=@COURSEID,");
			strSql.Append("ISATTEND=@ISATTEND,");
			strSql.Append("ATTENDDATE=@ATTENDDATE,");
			strSql.Append("DESCRIPTION=@DESCRIPTION");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@KIDID", OleDbType.SmallInt),
					new OleDbParameter("@COURSEID", OleDbType.SmallInt),
					new OleDbParameter("@ISATTEND", OleDbType.Boolean,1),
					new OleDbParameter("@ATTENDDATE", OleDbType.Date),
					new OleDbParameter("@DESCRIPTION", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.KIDID;
			parameters[1].Value = model.COURSEID;
			parameters[2].Value = model.ISATTEND;
			parameters[3].Value = model.ATTENDDATE;
			parameters[4].Value = model.DESCRIPTION;
			parameters[5].Value = model.ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KIDATTENDANCE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KIDATTENDANCE ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ForKids.DB.Model.KIDATTENDANCE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,KIDID,COURSEID,ISATTEND,ATTENDDATE,DESCRIPTION from KIDATTENDANCE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			ForKids.DB.Model.KIDATTENDANCE model=new ForKids.DB.Model.KIDATTENDANCE();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["KIDID"]!=null && ds.Tables[0].Rows[0]["KIDID"].ToString()!="")
				{
					//model.KIDID=ds.Tables[0].Rows[0]["KIDID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["COURSEID"]!=null && ds.Tables[0].Rows[0]["COURSEID"].ToString()!="")
				{
					//model.COURSEID=ds.Tables[0].Rows[0]["COURSEID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ISATTEND"]!=null && ds.Tables[0].Rows[0]["ISATTEND"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ISATTEND"].ToString()=="1")||(ds.Tables[0].Rows[0]["ISATTEND"].ToString().ToLower()=="true"))
					{
						model.ISATTEND=true;
					}
					else
					{
						model.ISATTEND=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ATTENDDATE"]!=null && ds.Tables[0].Rows[0]["ATTENDDATE"].ToString()!="")
				{
					model.ATTENDDATE=DateTime.Parse(ds.Tables[0].Rows[0]["ATTENDDATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DESCRIPTION"]!=null && ds.Tables[0].Rows[0]["DESCRIPTION"].ToString()!="")
				{
					model.DESCRIPTION=ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,KIDID,COURSEID,ISATTEND,ATTENDDATE,DESCRIPTION ");
			strSql.Append(" FROM KIDATTENDANCE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM KIDATTENDANCE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperOleDb.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from KIDATTENDANCE T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "KIDATTENDANCE";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

