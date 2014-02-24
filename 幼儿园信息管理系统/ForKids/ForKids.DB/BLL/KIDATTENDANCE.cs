using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// KIDATTENDANCE
	/// </summary>
	public partial class KIDATTENDANCE
	{
		private readonly IKIDATTENDANCE dal=new ForKids.DB.OleDbDAL.KIDATTENDANCE();
		public KIDATTENDANCE()
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
		public bool Add(ForKids.DB.Model.KIDATTENDANCE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.KIDATTENDANCE model)
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
		public ForKids.DB.Model.KIDATTENDANCE GetModel(int ID)
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
		public List<ForKids.DB.Model.KIDATTENDANCE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.KIDATTENDANCE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.KIDATTENDANCE> modelList = new List<ForKids.DB.Model.KIDATTENDANCE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.KIDATTENDANCE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.KIDATTENDANCE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["KIDID"]!=null && dt.Rows[n]["KIDID"].ToString()!="")
					{
					//model.KIDID=dt.Rows[n]["KIDID"].ToString();
					}
					if(dt.Rows[n]["COURSEID"]!=null && dt.Rows[n]["COURSEID"].ToString()!="")
					{
					//model.COURSEID=dt.Rows[n]["COURSEID"].ToString();
					}
					if(dt.Rows[n]["ISATTEND"]!=null && dt.Rows[n]["ISATTEND"].ToString()!="")
					{
						if((dt.Rows[n]["ISATTEND"].ToString()=="1")||(dt.Rows[n]["ISATTEND"].ToString().ToLower()=="true"))
						{
						model.ISATTEND=true;
						}
						else
						{
							model.ISATTEND=false;
						}
					}
					if(dt.Rows[n]["ATTENDDATE"]!=null && dt.Rows[n]["ATTENDDATE"].ToString()!="")
					{
						model.ATTENDDATE=DateTime.Parse(dt.Rows[n]["ATTENDDATE"].ToString());
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

