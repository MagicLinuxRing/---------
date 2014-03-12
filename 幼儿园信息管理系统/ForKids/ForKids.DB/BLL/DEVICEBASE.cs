using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// DEVICEBASE
	/// </summary>
	public partial class DEVICEBASE
	{
		private readonly IDEVICEBASE dal=new ForKids.DB.OleDbDAL.DEVICEBASE();
		public DEVICEBASE()
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
		public bool Add(ForKids.DB.Model.DEVICEBASE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.DEVICEBASE model)
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
		public ForKids.DB.Model.DEVICEBASE GetModel(int ID)
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
		public List<ForKids.DB.Model.DEVICEBASE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.DEVICEBASE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.DEVICEBASE> modelList = new List<ForKids.DB.Model.DEVICEBASE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.DEVICEBASE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.DEVICEBASE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["NAME"]!=null && dt.Rows[n]["NAME"].ToString()!="")
					{
					model.NAME=dt.Rows[n]["NAME"].ToString();
					}
					if(dt.Rows[n]["FUNDING"]!=null && dt.Rows[n]["FUNDING"].ToString()!="")
					{
                        model.FUNDING=double.Parse(dt.Rows[n]["FUNDING"].ToString());
					}
					if(dt.Rows[n]["LOSSINFO"]!=null && dt.Rows[n]["LOSSINFO"].ToString()!="")
					{
					model.LOSSINFO=dt.Rows[n]["LOSSINFO"].ToString();
					}
					if(dt.Rows[n]["PURCHASEPLAN"]!=null && dt.Rows[n]["PURCHASEPLAN"].ToString()!="")
					{
					model.PURCHASEPLAN=dt.Rows[n]["PURCHASEPLAN"].ToString();
					}
					if(dt.Rows[n]["INVESTMENT"]!=null && dt.Rows[n]["INVESTMENT"].ToString()!="")
					{
                        model.INVESTMENT=double.Parse(dt.Rows[n]["INVESTMENT"].ToString());
					}
					if(dt.Rows[n]["PURCHASEDATE"]!=null && dt.Rows[n]["PURCHASEDATE"].ToString()!="")
					{
						model.PURCHASEDATE=DateTime.Parse(dt.Rows[n]["PURCHASEDATE"].ToString());
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

