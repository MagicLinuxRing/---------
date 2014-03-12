using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// CLASSCOURSE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CLASSCOURSE
	{
		public CLASSCOURSE()
		{}
		#region Model
		private int _id;
		private int? _classid;
		private int? _courseid;
		private double? _attendance;
		private int? _teacherid;
		private string _summary;
		/// <summary>
		/// 标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 班级ID
		/// </summary>
		public int? CLASSID
		{
			set{ _classid=value;}
			get{return _classid;}
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
		/// 授课老师ID
		/// </summary>
		public int? TEACHERID
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 课程总结
		/// </summary>
		public string SUMMARY
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		#endregion Model

	}
}

