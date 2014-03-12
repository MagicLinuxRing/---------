using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// KIDCMDRECORD:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KIDCMDRECORD
	{
		public KIDCMDRECORD()
		{}
		#region Model
		private int _id;
		private int? _kidid;
		private string _command;
		private int? _userid;
		/// <summary>
		/// 标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 幼儿ID
		/// </summary>
		public int? KIDID
		{
			set{ _kidid=value;}
			get{return _kidid;}
		}
		/// <summary>
		/// 操作命令
		/// </summary>
		public string COMMAND
		{
			set{ _command=value;}
			get{return _command;}
		}
		/// <summary>
		/// 操作用户ID
		/// </summary>
		public int? USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

