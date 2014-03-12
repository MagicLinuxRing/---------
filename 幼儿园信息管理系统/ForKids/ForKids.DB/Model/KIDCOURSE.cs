using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// KIDCOURSE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KIDCOURSE
	{
		public KIDCOURSE()
		{}
		#region Model
		private int _id;
		private int? _kidid;
		private int? _courseid;
		private double? _attendance;
		private string _performance;
		private int? _credit;
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
		/// 课程ID
		/// </summary>
		public int? COURSEID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 出勤率
		/// </summary>
		public double? ATTENDANCE
		{
			set{ _attendance=value;}
			get{return _attendance;}
		}
		/// <summary>
		/// 表现描述
		/// </summary>
		public string PERFORMANCE
		{
			set{ _performance=value;}
			get{return _performance;}
		}
		/// <summary>
		/// 教师打分
		/// </summary>
		public int? CREDIT
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		#endregion Model

	}
}

