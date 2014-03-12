using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using ForKids.DB.IDAL;
using ForKids.DB.Utility;//Please add references
namespace ForKids.DB.OleDbDAL
{
	/// <summary>
	/// 数据访问类:KIDBASE
	/// </summary>
	public partial class KIDBASE:IKIDBASE
	{
		public KIDBASE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "KIDBASE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KIDBASE");
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
		public bool Add(ForKids.DB.Model.KIDBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into KIDBASE(");
			strSql.Append("STUDENTID,GURDIANID,NAME,AGE,HEIGHT,WEIGHT,SEX,INDATE,INSURANCE,CLASSID,PHOTO,MEDICALRECORD,TRANSFERRECORD,SHUTTLEROUTE,TEACHERADVICE)");
			strSql.Append(" values (");
			strSql.Append("@STUDENTID,@GURDIANID,@NAME,@AGE,@HEIGHT,@WEIGHT,@SEX,@INDATE,@INSURANCE,@CLASSID,@PHOTO,@MEDICALRECORD,@TRANSFERRECORD,@SHUTTLEROUTE,@TEACHERADVICE)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@STUDENTID", OleDbType.VarChar,255),
					new OleDbParameter("@GURDIANID", OleDbType.Integer,4),
					new OleDbParameter("@NAME", OleDbType.VarChar,30),
					new OleDbParameter("@AGE", OleDbType.Integer,4),
					new OleDbParameter("@HEIGHT", OleDbType.Double),
					new OleDbParameter("@WEIGHT", OleDbType.Double),
					new OleDbParameter("@SEX", OleDbType.Boolean,1),
					new OleDbParameter("@INDATE", OleDbType.Date),
					new OleDbParameter("@INSURANCE", OleDbType.Double),
					new OleDbParameter("@CLASSID", OleDbType.Integer,4),
					new OleDbParameter("@PHOTO", OleDbType.Binary,0),
					new OleDbParameter("@MEDICALRECORD", OleDbType.VarChar,255),
					new OleDbParameter("@TRANSFERRECORD", OleDbType.VarChar,255),
					new OleDbParameter("@SHUTTLEROUTE", OleDbType.VarChar,255),
					new OleDbParameter("@TEACHERADVICE", OleDbType.VarChar,255)};
			parameters[0].Value = model.STUDENTID;
			parameters[1].Value = model.GURDIANID;
			parameters[2].Value = model.NAME;
			parameters[3].Value = model.AGE;
			parameters[4].Value = model.HEIGHT;
			parameters[5].Value = model.WEIGHT;
			parameters[6].Value = model.SEX;
			parameters[7].Value = model.INDATE;
			parameters[8].Value = model.INSURANCE;
			parameters[9].Value = model.CLASSID;
			parameters[10].Value = model.PHOTO;
			parameters[11].Value = model.MEDICALRECORD;
			parameters[12].Value = model.TRANSFERRECORD;
			parameters[13].Value = model.SHUTTLEROUTE;
			parameters[14].Value = model.TEACHERADVICE;

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
		public bool Update(ForKids.DB.Model.KIDBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update KIDBASE set ");
			strSql.Append("STUDENTID=@STUDENTID,");
			strSql.Append("GURDIANID=@GURDIANID,");
			strSql.Append("NAME=@NAME,");
			strSql.Append("AGE=@AGE,");
			strSql.Append("HEIGHT=@HEIGHT,");
			strSql.Append("WEIGHT=@WEIGHT,");
			strSql.Append("SEX=@SEX,");
			strSql.Append("INDATE=@INDATE,");
			strSql.Append("INSURANCE=@INSURANCE,");
			strSql.Append("CLASSID=@CLASSID,");
			strSql.Append("PHOTO=@PHOTO,");
			strSql.Append("MEDICALRECORD=@MEDICALRECORD,");
			strSql.Append("TRANSFERRECORD=@TRANSFERRECORD,");
			strSql.Append("SHUTTLEROUTE=@SHUTTLEROUTE,");
			strSql.Append("TEACHERADVICE=@TEACHERADVICE");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@STUDENTID", OleDbType.VarChar,255),
					new OleDbParameter("@GURDIANID", OleDbType.Integer,4),
					new OleDbParameter("@NAME", OleDbType.VarChar,30),
					new OleDbParameter("@AGE", OleDbType.Integer,4),
					new OleDbParameter("@HEIGHT", OleDbType.Double),
					new OleDbParameter("@WEIGHT", OleDbType.Double),
					new OleDbParameter("@SEX", OleDbType.Boolean,1),
					new OleDbParameter("@INDATE", OleDbType.Date),
					new OleDbParameter("@INSURANCE", OleDbType.Double),
					new OleDbParameter("@CLASSID", OleDbType.Integer,4),
					new OleDbParameter("@PHOTO", OleDbType.Binary,0),
					new OleDbParameter("@MEDICALRECORD", OleDbType.VarChar,255),
					new OleDbParameter("@TRANSFERRECORD", OleDbType.VarChar,255),
					new OleDbParameter("@SHUTTLEROUTE", OleDbType.VarChar,255),
					new OleDbParameter("@TEACHERADVICE", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.STUDENTID;
			parameters[1].Value = model.GURDIANID;
			parameters[2].Value = model.NAME;
			parameters[3].Value = model.AGE;
			parameters[4].Value = model.HEIGHT;
			parameters[5].Value = model.WEIGHT;
			parameters[6].Value = model.SEX;
			parameters[7].Value = model.INDATE;
			parameters[8].Value = model.INSURANCE;
			parameters[9].Value = model.CLASSID;
			parameters[10].Value = model.PHOTO;
			parameters[11].Value = model.MEDICALRECORD;
			parameters[12].Value = model.TRANSFERRECORD;
			parameters[13].Value = model.SHUTTLEROUTE;
			parameters[14].Value = model.TEACHERADVICE;
			parameters[15].Value = model.ID;

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
			strSql.Append("delete from KIDBASE ");
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
			strSql.Append("delete from KIDBASE ");
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
		public ForKids.DB.Model.KIDBASE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,STUDENTID,GURDIANID,NAME,AGE,HEIGHT,WEIGHT,SEX,INDATE,INSURANCE,CLASSID,PHOTO,MEDICALRECORD,TRANSFERRECORD,SHUTTLEROUTE,TEACHERADVICE from KIDBASE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			ForKids.DB.Model.KIDBASE model=new ForKids.DB.Model.KIDBASE();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["STUDENTID"]!=null && ds.Tables[0].Rows[0]["STUDENTID"].ToString()!="")
				{
					model.STUDENTID=ds.Tables[0].Rows[0]["STUDENTID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["GURDIANID"]!=null && ds.Tables[0].Rows[0]["GURDIANID"].ToString()!="")
				{
					model.GURDIANID=int.Parse(ds.Tables[0].Rows[0]["GURDIANID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NAME"]!=null && ds.Tables[0].Rows[0]["NAME"].ToString()!="")
				{
					model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AGE"]!=null && ds.Tables[0].Rows[0]["AGE"].ToString()!="")
				{
					model.AGE=int.Parse(ds.Tables[0].Rows[0]["AGE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HEIGHT"]!=null && ds.Tables[0].Rows[0]["HEIGHT"].ToString()!="")
				{
                    model.HEIGHT=double.Parse(ds.Tables[0].Rows[0]["HEIGHT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WEIGHT"]!=null && ds.Tables[0].Rows[0]["WEIGHT"].ToString()!="")
				{
                    model.WEIGHT=double.Parse(ds.Tables[0].Rows[0]["WEIGHT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SEX"]!=null && ds.Tables[0].Rows[0]["SEX"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["SEX"].ToString()=="1")||(ds.Tables[0].Rows[0]["SEX"].ToString().ToLower()=="true"))
					{
						model.SEX=true;
					}
					else
					{
						model.SEX=false;
					}
				}
				if(ds.Tables[0].Rows[0]["INDATE"]!=null && ds.Tables[0].Rows[0]["INDATE"].ToString()!="")
				{
					model.INDATE=DateTime.Parse(ds.Tables[0].Rows[0]["INDATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["INSURANCE"]!=null && ds.Tables[0].Rows[0]["INSURANCE"].ToString()!="")
				{
                    model.INSURANCE=double.Parse(ds.Tables[0].Rows[0]["INSURANCE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CLASSID"]!=null && ds.Tables[0].Rows[0]["CLASSID"].ToString()!="")
				{
					model.CLASSID=int.Parse(ds.Tables[0].Rows[0]["CLASSID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PHOTO"]!=null && ds.Tables[0].Rows[0]["PHOTO"].ToString()!="")
				{
					model.PHOTO=(byte[])ds.Tables[0].Rows[0]["PHOTO"];
				}
				if(ds.Tables[0].Rows[0]["MEDICALRECORD"]!=null && ds.Tables[0].Rows[0]["MEDICALRECORD"].ToString()!="")
				{
					model.MEDICALRECORD=ds.Tables[0].Rows[0]["MEDICALRECORD"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TRANSFERRECORD"]!=null && ds.Tables[0].Rows[0]["TRANSFERRECORD"].ToString()!="")
				{
					model.TRANSFERRECORD=ds.Tables[0].Rows[0]["TRANSFERRECORD"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SHUTTLEROUTE"]!=null && ds.Tables[0].Rows[0]["SHUTTLEROUTE"].ToString()!="")
				{
					model.SHUTTLEROUTE=ds.Tables[0].Rows[0]["SHUTTLEROUTE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TEACHERADVICE"]!=null && ds.Tables[0].Rows[0]["TEACHERADVICE"].ToString()!="")
				{
					model.TEACHERADVICE=ds.Tables[0].Rows[0]["TEACHERADVICE"].ToString();
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
			strSql.Append("select ID,STUDENTID,GURDIANID,NAME,AGE,HEIGHT,WEIGHT,SEX,INDATE,INSURANCE,CLASSID,PHOTO,MEDICALRECORD,TRANSFERRECORD,SHUTTLEROUTE,TEACHERADVICE ");
			strSql.Append(" FROM KIDBASE ");
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
			strSql.Append("select count(1) FROM KIDBASE ");
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
			strSql.Append(")AS Row, T.*  from KIDBASE T ");
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
			parameters[0].Value = "KIDBASE";
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

