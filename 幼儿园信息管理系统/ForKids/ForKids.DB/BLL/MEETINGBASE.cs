using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// MEETINGBASE
	/// </summary>
	public partial class MEETINGBASE
	{
		private readonly IMEETINGBASE dal=new ForKids.DB.OleDbDAL.MEETINGBASE();
		public MEETINGBASE()
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
		public bool Add(ForKids.DB.Model.MEETINGBASE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.MEETINGBASE model)
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
		public ForKids.DB.Model.MEETINGBASE GetModel(int ID)
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
		public List<ForKids.DB.Model.MEETINGBASE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.MEETINGBASE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.MEETINGBASE> modelList = new List<ForKids.DB.Model.MEETINGBASE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.MEETINGBASE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.MEETINGBASE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["NAME"]!=null && dt.Rows[n]["NAME"].ToString()!="")
					{
					model.NAME=dt.Rows[n]["NAME"].ToString();
					}
					if(dt.Rows[n]["DESCRITION"]!=null && dt.Rows[n]["DESCRITION"].ToString()!="")
					{
					model.DESCRITION=dt.Rows[n]["DESCRITION"].ToString();
					}
					if(dt.Rows[n]["MEETINGDATE"]!=null && dt.Rows[n]["MEETINGDATE"].ToString()!="")
					{
						model.MEETINGDATE=DateTime.Parse(dt.Rows[n]["MEETINGDATE"].ToString());
					}
					if(dt.Rows[n]["ATTENDANCE"]!=null && dt.Rows[n]["ATTENDANCE"].ToString()!="")
					{
					model.ATTENDANCE=double.Parse(dt.Rows[n]["ATTENDANCE"].ToString());
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

