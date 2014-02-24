using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using ForKids.DB.IDAL;
using ForKids.DB.Utility;//Please add references
namespace ForKids.DB.OleDbDAL
{
	/// <summary>
	/// 数据访问类:GURDIANATTENDANCE
	/// </summary>
	public partial class GURDIANATTENDANCE:IGURDIANATTENDANCE
	{
		public GURDIANATTENDANCE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "GURDIANATTENDANCE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GURDIANATTENDANCE");
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
		public bool Add(ForKids.DB.Model.GURDIANATTENDANCE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GURDIANATTENDANCE(");
			strSql.Append("GURDIANID,METTINGID,ISATTEND,ATTENDDATE,DESCRIPTION)");
			strSql.Append(" values (");
			strSql.Append("@GURDIANID,@METTINGID,@ISATTEND,@ATTENDDATE,@DESCRIPTION)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GURDIANID", OleDbType.SmallInt),
					new OleDbParameter("@METTINGID", OleDbType.SmallInt),
					new OleDbParameter("@ISATTEND", OleDbType.Boolean,1),
					new OleDbParameter("@ATTENDDATE", OleDbType.VarChar,255),
					new OleDbParameter("@DESCRIPTION", OleDbType.VarChar,255)};
			parameters[0].Value = model.GURDIANID;
			parameters[1].Value = model.METTINGID;
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
		public bool Update(ForKids.DB.Model.GURDIANATTENDANCE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GURDIANATTENDANCE set ");
			strSql.Append("GURDIANID=@GURDIANID,");
			strSql.Append("METTINGID=@METTINGID,");
			strSql.Append("ISATTEND=@ISATTEND,");
			strSql.Append("ATTENDDATE=@ATTENDDATE,");
			strSql.Append("DESCRIPTION=@DESCRIPTION");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GURDIANID", OleDbType.SmallInt),
					new OleDbParameter("@METTINGID", OleDbType.SmallInt),
					new OleDbParameter("@ISATTEND", OleDbType.Boolean,1),
					new OleDbParameter("@ATTENDDATE", OleDbType.VarChar,255),
					new OleDbParameter("@DESCRIPTION", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.GURDIANID;
			parameters[1].Value = model.METTINGID;
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
			strSql.Append("delete from GURDIANATTENDANCE ");
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
			strSql.Append("delete from GURDIANATTENDANCE ");
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
		public ForKids.DB.Model.GURDIANATTENDANCE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,GURDIANID,METTINGID,ISATTEND,ATTENDDATE,DESCRIPTION from GURDIANATTENDANCE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			ForKids.DB.Model.GURDIANATTENDANCE model=new ForKids.DB.Model.GURDIANATTENDANCE();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GURDIANID"]!=null && ds.Tables[0].Rows[0]["GURDIANID"].ToString()!="")
				{
					//model.GURDIANID=ds.Tables[0].Rows[0]["GURDIANID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["METTINGID"]!=null && ds.Tables[0].Rows[0]["METTINGID"].ToString()!="")
				{
					//model.METTINGID=ds.Tables[0].Rows[0]["METTINGID"].ToString();
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
					model.ATTENDDATE=ds.Tables[0].Rows[0]["ATTENDDATE"].ToString();
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
			strSql.Append("select ID,GURDIANID,METTINGID,ISATTEND,ATTENDDATE,DESCRIPTION ");
			strSql.Append(" FROM GURDIANATTENDANCE ");
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
			strSql.Append("select count(1) FROM GURDIANATTENDANCE ");
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
			strSql.Append(")AS Row, T.*  from GURDIANATTENDANCE T ");
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
			parameters[0].Value = "GURDIANATTENDANCE";
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

