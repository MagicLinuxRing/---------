using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using ForKids.DB.IDAL;
using ForKids.DB.Utility;//Please add references
namespace ForKids.DB.OleDbDAL
{
	/// <summary>
	/// 数据访问类:GURDIANBASE
	/// </summary>
	public partial class GURDIANBASE:IGURDIANBASE
	{
		public GURDIANBASE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "GURDIANBASE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GURDIANBASE");
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
		public bool Add(ForKids.DB.Model.GURDIANBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GURDIANBASE(");
			strSql.Append("RELATIONSHIP,NAME,IDNUMBER,AGE,SEX,PHOTO,PHONE,EXPHONE,ADDRESS,FAMILYINFO)");
			strSql.Append(" values (");
			strSql.Append("@RELATIONSHIP,@NAME,@IDNUMBER,@AGE,@SEX,@PHOTO,@PHONE,@EXPHONE,@ADDRESS,@FAMILYINFO)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@RELATIONSHIP", OleDbType.VarChar,20),
					new OleDbParameter("@NAME", OleDbType.VarChar,30),
					new OleDbParameter("@IDNUMBER", OleDbType.VarChar,20),
					new OleDbParameter("@AGE", OleDbType.SmallInt),
					new OleDbParameter("@SEX", OleDbType.Boolean,1),
					new OleDbParameter("@PHOTO", OleDbType.Binary,0),
					new OleDbParameter("@PHONE", OleDbType.VarChar,20),
					new OleDbParameter("@EXPHONE", OleDbType.VarChar,20),
					new OleDbParameter("@ADDRESS", OleDbType.VarChar,255),
					new OleDbParameter("@FAMILYINFO", OleDbType.VarChar,255)};
			parameters[0].Value = model.RELATIONSHIP;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.IDNUMBER;
			parameters[3].Value = model.AGE;
			parameters[4].Value = model.SEX;
			parameters[5].Value = model.PHOTO;
			parameters[6].Value = model.PHONE;
			parameters[7].Value = model.EXPHONE;
			parameters[8].Value = model.ADDRESS;
			parameters[9].Value = model.FAMILYINFO;

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
		public bool Update(ForKids.DB.Model.GURDIANBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GURDIANBASE set ");
			strSql.Append("RELATIONSHIP=@RELATIONSHIP,");
			strSql.Append("NAME=@NAME,");
			strSql.Append("IDNUMBER=@IDNUMBER,");
			strSql.Append("AGE=@AGE,");
			strSql.Append("SEX=@SEX,");
			strSql.Append("PHOTO=@PHOTO,");
			strSql.Append("PHONE=@PHONE,");
			strSql.Append("EXPHONE=@EXPHONE,");
			strSql.Append("ADDRESS=@ADDRESS,");
			strSql.Append("FAMILYINFO=@FAMILYINFO");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@RELATIONSHIP", OleDbType.VarChar,20),
					new OleDbParameter("@NAME", OleDbType.VarChar,30),
					new OleDbParameter("@IDNUMBER", OleDbType.VarChar,20),
					new OleDbParameter("@AGE", OleDbType.SmallInt),
					new OleDbParameter("@SEX", OleDbType.Boolean,1),
					new OleDbParameter("@PHOTO", OleDbType.Binary,0),
					new OleDbParameter("@PHONE", OleDbType.VarChar,20),
					new OleDbParameter("@EXPHONE", OleDbType.VarChar,20),
					new OleDbParameter("@ADDRESS", OleDbType.VarChar,255),
					new OleDbParameter("@FAMILYINFO", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.RELATIONSHIP;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.IDNUMBER;
			parameters[3].Value = model.AGE;
			parameters[4].Value = model.SEX;
			parameters[5].Value = model.PHOTO;
			parameters[6].Value = model.PHONE;
			parameters[7].Value = model.EXPHONE;
			parameters[8].Value = model.ADDRESS;
			parameters[9].Value = model.FAMILYINFO;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from GURDIANBASE ");
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
			strSql.Append("delete from GURDIANBASE ");
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
		public ForKids.DB.Model.GURDIANBASE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,RELATIONSHIP,NAME,IDNUMBER,AGE,SEX,PHOTO,PHONE,EXPHONE,ADDRESS,FAMILYINFO from GURDIANBASE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			ForKids.DB.Model.GURDIANBASE model=new ForKids.DB.Model.GURDIANBASE();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RELATIONSHIP"]!=null && ds.Tables[0].Rows[0]["RELATIONSHIP"].ToString()!="")
				{
					model.RELATIONSHIP=ds.Tables[0].Rows[0]["RELATIONSHIP"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NAME"]!=null && ds.Tables[0].Rows[0]["NAME"].ToString()!="")
				{
					model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IDNUMBER"]!=null && ds.Tables[0].Rows[0]["IDNUMBER"].ToString()!="")
				{
					model.IDNUMBER=ds.Tables[0].Rows[0]["IDNUMBER"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AGE"]!=null && ds.Tables[0].Rows[0]["AGE"].ToString()!="")
				{
					//model.AGE=ds.Tables[0].Rows[0]["AGE"].ToString();
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
				if(ds.Tables[0].Rows[0]["PHOTO"]!=null && ds.Tables[0].Rows[0]["PHOTO"].ToString()!="")
				{
					model.PHOTO=(byte[])ds.Tables[0].Rows[0]["PHOTO"];
				}
				if(ds.Tables[0].Rows[0]["PHONE"]!=null && ds.Tables[0].Rows[0]["PHONE"].ToString()!="")
				{
					model.PHONE=ds.Tables[0].Rows[0]["PHONE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EXPHONE"]!=null && ds.Tables[0].Rows[0]["EXPHONE"].ToString()!="")
				{
					model.EXPHONE=ds.Tables[0].Rows[0]["EXPHONE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ADDRESS"]!=null && ds.Tables[0].Rows[0]["ADDRESS"].ToString()!="")
				{
					model.ADDRESS=ds.Tables[0].Rows[0]["ADDRESS"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FAMILYINFO"]!=null && ds.Tables[0].Rows[0]["FAMILYINFO"].ToString()!="")
				{
					model.FAMILYINFO=ds.Tables[0].Rows[0]["FAMILYINFO"].ToString();
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
			strSql.Append("select ID,RELATIONSHIP,NAME,IDNUMBER,AGE,SEX,PHOTO,PHONE,EXPHONE,ADDRESS,FAMILYINFO ");
			strSql.Append(" FROM GURDIANBASE ");
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
			strSql.Append("select count(1) FROM GURDIANBASE ");
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
			strSql.Append(")AS Row, T.*  from GURDIANBASE T ");
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
			parameters[0].Value = "GURDIANBASE";
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

