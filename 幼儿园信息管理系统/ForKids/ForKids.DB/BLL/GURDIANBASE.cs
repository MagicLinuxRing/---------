using System;
using System.Data;
using System.Collections.Generic;

using ForKids.DB.Model;

using ForKids.DB.IDAL;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// GURDIANBASE
	/// </summary>
	public partial class GURDIANBASE
	{
		private readonly IGURDIANBASE dal=new ForKids.DB.OleDbDAL.GURDIANBASE();
		public GURDIANBASE()
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
		public bool Add(ForKids.DB.Model.GURDIANBASE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.GURDIANBASE model)
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
		public ForKids.DB.Model.GURDIANBASE GetModel(int ID)
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
		public List<ForKids.DB.Model.GURDIANBASE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ForKids.DB.Model.GURDIANBASE> DataTableToList(DataTable dt)
		{
			List<ForKids.DB.Model.GURDIANBASE> modelList = new List<ForKids.DB.Model.GURDIANBASE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ForKids.DB.Model.GURDIANBASE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ForKids.DB.Model.GURDIANBASE();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["RELATIONSHIP"]!=null && dt.Rows[n]["RELATIONSHIP"].ToString()!="")
					{
					model.RELATIONSHIP=dt.Rows[n]["RELATIONSHIP"].ToString();
					}
					if(dt.Rows[n]["NAME"]!=null && dt.Rows[n]["NAME"].ToString()!="")
					{
					model.NAME=dt.Rows[n]["NAME"].ToString();
					}
					if(dt.Rows[n]["IDNUMBER"]!=null && dt.Rows[n]["IDNUMBER"].ToString()!="")
					{
					model.IDNUMBER=dt.Rows[n]["IDNUMBER"].ToString();
					}
					if(dt.Rows[n]["AGE"]!=null && dt.Rows[n]["AGE"].ToString()!="")
					{
					//model.AGE=dt.Rows[n]["AGE"].ToString();
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
					if(dt.Rows[n]["ADDRESS"]!=null && dt.Rows[n]["ADDRESS"].ToString()!="")
					{
					model.ADDRESS=dt.Rows[n]["ADDRESS"].ToString();
					}
					if(dt.Rows[n]["FAMILYINFO"]!=null && dt.Rows[n]["FAMILYINFO"].ToString()!="")
					{
					model.FAMILYINFO=dt.Rows[n]["FAMILYINFO"].ToString();
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

