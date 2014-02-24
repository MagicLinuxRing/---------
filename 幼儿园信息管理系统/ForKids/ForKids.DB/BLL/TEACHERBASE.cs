using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// TEACHERBASE
	/// </summary>
	public partial class TEACHERBASE
	{
		private readonly ITEACHERBASE dal=new ForKids.DB.OleDbDAL.TEACHERBASE();
		public TEACHERBASE()
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
		public bool Add(ForKids.DB.Model.TEACHERBASE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.TEACHERBASE model)
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
		public ForKids.DB.Model.TEACHERBASE GetModel(int ID)
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
		public List<ForKids.DB.Model.TEACHERBASE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.TEACHERBASE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.TEACHERBASE> modelList = new List<ForKids.DB.Model.TEACHERBASE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.TEACHERBASE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.TEACHERBASE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["JOBNUMBER"]!=null && dt.Rows[n]["JOBNUMBER"].ToString()!="")
					{
					model.JOBNUMBER=dt.Rows[n]["JOBNUMBER"].ToString();
					}
					if(dt.Rows[n]["NAME"]!=null && dt.Rows[n]["NAME"].ToString()!="")
					{
					model.NAME=dt.Rows[n]["NAME"].ToString();
					}
					if(dt.Rows[n]["AGE"]!=null && dt.Rows[n]["AGE"].ToString()!="")
					{
						model.AGE=int.Parse(dt.Rows[n]["AGE"].ToString());
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
					if(dt.Rows[n]["PHOTO"]!=null && dt.Rows[n]["PHOTO"].ToString()!="")
					{
						model.PHOTO=(byte[])dt.Rows[n]["PHOTO"];
					}
					if(dt.Rows[n]["PHONE"]!=null && dt.Rows[n]["PHONE"].ToString()!="")
					{
					model.PHONE=dt.Rows[n]["PHONE"].ToString();
					}
					if(dt.Rows[n]["EXPHONE"]!=null && dt.Rows[n]["EXPHONE"].ToString()!="")
					{
					model.EXPHONE=dt.Rows[n]["EXPHONE"].ToString();
					}
					if(dt.Rows[n]["DESCRIPTION"]!=null && dt.Rows[n]["DESCRIPTION"].ToString()!="")
					{
					model.DESCRIPTION=dt.Rows[n]["DESCRIPTION"].ToString();
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

