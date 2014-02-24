using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using ForKids.DB.IDAL;
using ForKids.DB.Utility;//Please add references
namespace ForKids.DB.OleDbDAL
{
	/// <summary>
	/// 数据访问类:DEVICEBASE
	/// </summary>
	public partial class DEVICEBASE:IDEVICEBASE
	{
		public DEVICEBASE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "DEVICEBASE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DEVICEBASE");
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
		public bool Add(ForKids.DB.Model.DEVICEBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DEVICEBASE(");
			strSql.Append("NAME,FUNDING,LOSSINFO,PURCHASEPLAN,INVESTMENT,PURCHASEDATE,DESCRIPTION)");
			strSql.Append(" values (");
			strSql.Append("@NAME,@FUNDING,@LOSSINFO,@PURCHASEPLAN,@INVESTMENT,@PURCHASEDATE,@DESCRIPTION)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@NAME", OleDbType.VarChar,50),
					new OleDbParameter("@FUNDING", OleDbType.Double),
					new OleDbParameter("@LOSSINFO", OleDbType.VarChar,255),
					new OleDbParameter("@PURCHASEPLAN", OleDbType.VarChar,255),
					new OleDbParameter("@INVESTMENT", OleDbType.Double),
					new OleDbParameter("@PURCHASEDATE", OleDbType.Date),
					new OleDbParameter("@DESCRIPTION", OleDbType.VarChar,255)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.FUNDING;
			parameters[2].Value = model.LOSSINFO;
			parameters[3].Value = model.PURCHASEPLAN;
			parameters[4].Value = model.INVESTMENT;
			parameters[5].Value = model.PURCHASEDATE;
			parameters[6].Value = model.DESCRIPTION;

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
		public bool Update(ForKids.DB.Model.DEVICEBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DEVICEBASE set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("FUNDING=@FUNDING,");
			strSql.Append("LOSSINFO=@LOSSINFO,");
			strSql.Append("PURCHASEPLAN=@PURCHASEPLAN,");
			strSql.Append("INVESTMENT=@INVESTMENT,");
			strSql.Append("PURCHASEDATE=@PURCHASEDATE,");
			strSql.Append("DESCRIPTION=@DESCRIPTION");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@NAME", OleDbType.VarChar,50),
					new OleDbParameter("@FUNDING", OleDbType.Double),
					new OleDbParameter("@LOSSINFO", OleDbType.VarChar,255),
					new OleDbParameter("@PURCHASEPLAN", OleDbType.VarChar,255),
					new OleDbParameter("@INVESTMENT", OleDbType.Double),
					new OleDbParameter("@PURCHASEDATE", OleDbType.Date),
					new OleDbParameter("@DESCRIPTION", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.FUNDING;
			parameters[2].Value = model.LOSSINFO;
			parameters[3].Value = model.PURCHASEPLAN;
			parameters[4].Value = model.INVESTMENT;
			parameters[5].Value = model.PURCHASEDATE;
			parameters[6].Value = model.DESCRIPTION;
			parameters[7].Value = model.ID;

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
			strSql.Append("delete from DEVICEBASE ");
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
			strSql.Append("delete from DEVICEBASE ");
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
		public ForKids.DB.Model.DEVICEBASE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NAME,FUNDING,LOSSINFO,PURCHASEPLAN,INVESTMENT,PURCHASEDATE,DESCRIPTION from DEVICEBASE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			ForKids.DB.Model.DEVICEBASE model=new ForKids.DB.Model.DEVICEBASE();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NAME"]!=null && ds.Tables[0].Rows[0]["NAME"].ToString()!="")
				{
					model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FUNDING"]!=null && ds.Tables[0].Rows[0]["FUNDING"].ToString()!="")
				{
					//model.FUNDING=ds.Tables[0].Rows[0]["FUNDING"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LOSSINFO"]!=null && ds.Tables[0].Rows[0]["LOSSINFO"].ToString()!="")
				{
					model.LOSSINFO=ds.Tables[0].Rows[0]["LOSSINFO"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PURCHASEPLAN"]!=null && ds.Tables[0].Rows[0]["PURCHASEPLAN"].ToString()!="")
				{
					model.PURCHASEPLAN=ds.Tables[0].Rows[0]["PURCHASEPLAN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["INVESTMENT"]!=null && ds.Tables[0].Rows[0]["INVESTMENT"].ToString()!="")
				{
					//model.INVESTMENT=ds.Tables[0].Rows[0]["INVESTMENT"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PURCHASEDATE"]!=null && ds.Tables[0].Rows[0]["PURCHASEDATE"].ToString()!="")
				{
					model.PURCHASEDATE=DateTime.Parse(ds.Tables[0].Rows[0]["PURCHASEDATE"].ToString());
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
			strSql.Append("select ID,NAME,FUNDING,LOSSINFO,PURCHASEPLAN,INVESTMENT,PURCHASEDATE,DESCRIPTION ");
			strSql.Append(" FROM DEVICEBASE ");
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
			strSql.Append("select count(1) FROM DEVICEBASE ");
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
			strSql.Append(")AS Row, T.*  from DEVICEBASE T ");
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
			parameters[0].Value = "DEVICEBASE";
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

