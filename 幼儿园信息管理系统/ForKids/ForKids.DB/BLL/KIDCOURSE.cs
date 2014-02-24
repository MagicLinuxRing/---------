using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// KIDCOURSE
	/// </summary>
	public partial class KIDCOURSE
	{
		private readonly IKIDCOURSE dal=new ForKids.DB.OleDbDAL.KIDCOURSE();
		public KIDCOURSE()
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
		public bool Add(ForKids.DB.Model.KIDCOURSE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.KIDCOURSE model)
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
		public ForKids.DB.Model.KIDCOURSE GetModel(int ID)
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
		public List<ForKids.DB.Model.KIDCOURSE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.KIDCOURSE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.KIDCOURSE> modelList = new List<ForKids.DB.Model.KIDCOURSE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.KIDCOURSE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.KIDCOURSE();
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
					if(dt.Rows[n]["ATTENDANCE"]!=null && dt.Rows[n]["ATTENDANCE"].ToString()!="")
					{
					//model.ATTENDANCE=dt.Rows[n]["ATTENDANCE"].ToString();
					}
					if(dt.Rows[n]["PERFORMANCE"]!=null && dt.Rows[n]["PERFORMANCE"].ToString()!="")
					{
					model.PERFORMANCE=dt.Rows[n]["PERFORMANCE"].ToString();
					}
					if(dt.Rows[n]["CREDIT"]!=null && dt.Rows[n]["CREDIT"].ToString()!="")
					{
					//model.CREDIT=dt.Rows[n]["CREDIT"].ToString();
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

