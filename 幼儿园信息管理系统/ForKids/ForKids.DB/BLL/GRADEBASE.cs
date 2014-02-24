using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// GRADEBASE
	/// </summary>
	public partial class GRADEBASE
	{
		private readonly IGRADEBASE dal=new ForKids.DB.OleDbDAL.GRADEBASE();
		public GRADEBASE()
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
		public bool Add(ForKids.DB.Model.GRADEBASE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.GRADEBASE model)
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
		public ForKids.DB.Model.GRADEBASE GetModel(int ID)
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
		public List<ForKids.DB.Model.GRADEBASE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.GRADEBASE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.GRADEBASE> modelList = new List<ForKids.DB.Model.GRADEBASE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.GRADEBASE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.GRADEBASE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["NAME"]!=null && dt.Rows[n]["NAME"].ToString()!="")
					{
					model.NAME=dt.Rows[n]["NAME"].ToString();
					}
					if(dt.Rows[n]["HEADTEACHERID"]!=null && dt.Rows[n]["HEADTEACHERID"].ToString()!="")
					{
						model.HEADTEACHERID=int.Parse(dt.Rows[n]["HEADTEACHERID"].ToString());
					}
					if(dt.Rows[n]["TUITION"]!=null && dt.Rows[n]["TUITION"].ToString()!="")
					{
						model.TUITION=int.Parse(dt.Rows[n]["TUITION"].ToString());
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

