using System;
using System.Data;
using System.Collections.Generic;
namespace ForKids.DB.BLL
{
	/// <summary>
	/// 接口层CHARGEBASE
	/// </summary>
	public interface IBLL
	{
		#region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(ForKids.DB.Model.CHARGEBASE model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(ForKids.DB.Model.CHARGEBASE model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ForKids.DB.Model.CHARGEBASE GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<ForKids.DB.Model.CHARGEBASE> GetModelList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<ForKids.DB.Model.CHARGEBASE> DataTableToList(DataTable dt);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetAllList();
		#endregion  成员方法
	} 
}
