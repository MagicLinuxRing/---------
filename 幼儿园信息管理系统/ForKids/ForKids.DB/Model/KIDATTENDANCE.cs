using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// KIDATTENDANCE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KIDATTENDANCE
	{
		public KIDATTENDANCE()
		{}
		#region Model
		private int _id;
		private short _kidid;
		private short _courseid;
		private bool _isattend= false;
		private DateTime? _attenddate;
		private string _description;
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
		public short KIDID
		{
			set{ _kidid=value;}
			get{return _kidid;}
		}
		/// <summary>
		/// 课程ID
		/// </summary>
		public short COURSEID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 是否出勤
		/// </summary>
		public bool ISATTEND
		{
			set{ _isattend=value;}
			get{return _isattend;}
		}
		/// <summary>
		/// 出勤日期
		/// </summary>
		public DateTime? ATTENDDATE
		{
			set{ _attenddate=value;}
			get{return _attenddate;}
		}
		/// <summary>
		/// 出勤备注
		/// </summary>
		public string DESCRIPTION
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

