using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// KIDBASE
	/// </summary>
	public partial class KIDBASE
	{
		private readonly IKIDBASE dal=new ForKids.DB.OleDbDAL.KIDBASE();
		public KIDBASE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ForKids.DB.Model.KIDBASE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.KIDBASE model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ForKids.DB.Model.KIDBASE GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.KIDBASE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.KIDBASE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.KIDBASE> modelList = new List<ForKids.DB.Model.KIDBASE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.KIDBASE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.KIDBASE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["STUDENTID"]!=null && dt.Rows[n]["STUDENTID"].ToString()!="")
					{
					model.STUDENTID=dt.Rows[n]["STUDENTID"].ToString();
					}
					if(dt.Rows[n]["GURDIANID"]!=null && dt.Rows[n]["GURDIANID"].ToString()!="")
					{
						model.GURDIANID=int.Parse(dt.Rows[n]["GURDIANID"].ToString());
					}
					if(dt.Rows[n]["NAME"]!=null && dt.Rows[n]["NAME"].ToString()!="")
					{
					model.NAME=dt.Rows[n]["NAME"].ToString();
					}
					if(dt.Rows[n]["AGE"]!=null && dt.Rows[n]["AGE"].ToString()!="")
					{
					//model.AGE=dt.Rows[n]["AGE"].ToString();
					}
					if(dt.Rows[n]["HEIGHT"]!=null && dt.Rows[n]["HEIGHT"].ToString()!="")
					{
					//model.HEIGHT=dt.Rows[n]["HEIGHT"].ToString();
					}
					if(dt.Rows[n]["WEIGHT"]!=null && dt.Rows[n]["WEIGHT"].ToString()!="")
					{
					//model.WEIGHT=dt.Rows[n]["WEIGHT"].ToString();
					}
					if(dt.Rows[n]["SEX"]!=null && dt.Rows[n]["SEX"].ToString()!="")
					{
						if((dt.Rows[n]["SEX"].ToString()=="1")||(dt.Rows[n]["SEX"].ToString().ToLower()=="true"))
						{
						model.SEX=true;
						}
						else
						{
							model.SEX=false;
						}
					}
					if(dt.Rows[n]["INDATE"]!=null && dt.Rows[n]["INDATE"].ToString()!="")
					{
						model.INDATE=DateTime.Parse(dt.Rows[n]["INDATE"].ToString());
					}
					if(dt.Rows[n]["INSURANCE"]!=null && dt.Rows[n]["INSURANCE"].ToString()!="")
					{
					//model.INSURANCE=dt.Rows[n]["INSURANCE"].ToString();
					}
					if(dt.Rows[n]["CLASSID"]!=null && dt.Rows[n]["CLASSID"].ToString()!="")
					{
					//model.CLASSID=dt.Rows[n]["CLASSID"].ToString();
					}
					if(dt.Rows[n]["PHOTO"]!=null && dt.Rows[n]["PHOTO"].ToString()!="")
					{
						model.PHOTO=(byte[])dt.Rows[n]["PHOTO"];
					}
					if(dt.Rows[n]["MEDICALRECORD"]!=null && dt.Rows[n]["MEDICALRECORD"].ToString()!="")
					{
					model.MEDICALRECORD=dt.Rows[n]["MEDICALRECORD"].ToString();
					}
					if(dt.Rows[n]["TRANSFERRECORD"]!=null && dt.Rows[n]["TRANSFERRECORD"].ToString()!="")
					{
					model.TRANSFERRECORD=dt.Rows[n]["TRANSFERRECORD"].ToString();
					}
					if(dt.Rows[n]["SHUTTLEROUTE"]!=null && dt.Rows[n]["SHUTTLEROUTE"].ToString()!="")
					{
					model.SHUTTLEROUTE=dt.Rows[n]["SHUTTLEROUTE"].ToString();
					}
					if(dt.Rows[n]["TEACHERADVICE"]!=null && dt.Rows[n]["TEACHERADVICE"].ToString()!="")
					{
					model.TEACHERADVICE=dt.Rows[n]["TEACHERADVICE"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		#endregion  Method
	}
}

