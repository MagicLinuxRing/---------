using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// CLASSBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CLASSBASE
	{
		public CLASSBASE()
		{}
		#region Model
		private int _id;
		private int? _headteacherid;
		private int? _gradeid;
		private string _name;
		private int? _kidcount;
		/// <summary>
		/// 标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 班主任ID
		/// </summary>
		public int? HEADTEACHERID
		{
			set{ _headteacherid=value;}
			get{return _headteacherid;}
		}
		/// <summary>
		/// 年级ID
		/// </summary>
		public int? GRADEID
		{
			set{ _gradeid=value;}
			get{return _gradeid;}
		}
		/// <summary>
		/// 班级名字
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 人数
		/// </summary>
		public int? KIDCOUNT
		{
			set{ _kidcount=value;}
			get{return _kidcount;}
		}
		#endregion Model

	}
}

