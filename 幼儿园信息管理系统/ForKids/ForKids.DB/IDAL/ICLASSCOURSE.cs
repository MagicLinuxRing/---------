using System;
using System.Data;
namespace ForKids.DB.IDAL
{
	/// <summary>
	/// 接口层CLASSCOURSE
	/// </summary>
	public interface ICLASSCOURSE
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
		bool Add(ForKids.DB.Model.CLASSCOURSE model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ForKids.DB.Model.CLASSCOURSE model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ID);
		bool DeleteList(string IDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ForKids.DB.Model.CLASSCOURSE GetModel(int ID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	} 
}
