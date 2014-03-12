using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// KIDPAYMENT
	/// </summary>
	public partial class KIDPAYMENT
	{
		private readonly IKIDPAYMENT dal=new ForKids.DB.OleDbDAL.KIDPAYMENT();
		public KIDPAYMENT()
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
		public bool Add(ForKids.DB.Model.KIDPAYMENT model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.KIDPAYMENT model)
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
		public ForKids.DB.Model.KIDPAYMENT GetModel(int ID)
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
		public List<ForKids.DB.Model.KIDPAYMENT> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.KIDPAYMENT> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.KIDPAYMENT> modelList = new List<ForKids.DB.Model.KIDPAYMENT>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.KIDPAYMENT model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.KIDPAYMENT();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["KIDID"]!=null && dt.Rows[n]["KIDID"].ToString()!="")
					{
						model.KIDID=int.Parse(dt.Rows[n]["KIDID"].ToString());
					}
					if(dt.Rows[n]["CHARGEID"]!=null && dt.Rows[n]["CHARGEID"].ToString()!="")
					{
						model.CHARGEID=int.Parse(dt.Rows[n]["CHARGEID"].ToString());
					}
					if(dt.Rows[n]["PAYMENT"]!=null && dt.Rows[n]["PAYMENT"].ToString()!="")
					{
					    model.PAYMENT=double.Parse(dt.Rows[n]["PAYMENT"].ToString());
					}
					if(dt.Rows[n]["PAYDATE"]!=null && dt.Rows[n]["PAYDATE"].ToString()!="")
					{
						model.PAYDATE=DateTime.Parse(dt.Rows[n]["PAYDATE"].ToString());
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

