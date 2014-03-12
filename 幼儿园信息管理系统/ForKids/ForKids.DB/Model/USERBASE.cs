using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// USERBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class USERBASE
	{
		public USERBASE()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _pwd;
		private int? _roleid;
		/// <summary>
		/// 标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string PWD
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int? ROLEID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

