using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// CLASSCOURSE
	/// </summary>
	public partial class CLASSCOURSE
	{
		private readonly ICLASSCOURSE dal=new ForKids.DB.OleDbDAL.CLASSCOURSE();
		public CLASSCOURSE()
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
		public bool Add(ForKids.DB.Model.CLASSCOURSE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.CLASSCOURSE model)
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
		public ForKids.DB.Model.CLASSCOURSE GetModel(int ID)
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
		public List<ForKids.DB.Model.CLASSCOURSE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.CLASSCOURSE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.CLASSCOURSE> modelList = new List<ForKids.DB.Model.CLASSCOURSE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.CLASSCOURSE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.CLASSCOURSE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["CLASSID"]!=null && dt.Rows[n]["CLASSID"].ToString()!="")
					{
					//model.CLASSID=dt.Rows[n]["CLASSID"].ToString();
					}
					if(dt.Rows[n]["COURSEID"]!=null && dt.Rows[n]["COURSEID"].ToString()!="")
					{
					//model.COURSEID=dt.Rows[n]["COURSEID"].ToString();
					}
					if(dt.Rows[n]["ATTENDANCE"]!=null && dt.Rows[n]["ATTENDANCE"].ToString()!="")
					{
					//model.ATTENDANCE=dt.Rows[n]["ATTENDANCE"].ToString();
					}
					if(dt.Rows[n]["TEACHERID"]!=null && dt.Rows[n]["TEACHERID"].ToString()!="")
					{
					//model.TEACHERID=dt.Rows[n]["TEACHERID"].ToString();
					}
					if(dt.Rows[n]["SUMMARY"]!=null && dt.Rows[n]["SUMMARY"].ToString()!="")
					{
					model.SUMMARY=dt.Rows[n]["SUMMARY"].ToString();
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

