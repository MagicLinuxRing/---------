using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// MEETINGBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MEETINGBASE
	{
		public MEETINGBASE()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _descrition;
		private DateTime? _meetingdate;
		private double? _attendance;
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
		/// 名字
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 会议介绍
		/// </summary>
		public string DESCRITION
		{
			set{ _descrition=value;}
			get{return _descrition;}
		}
		/// <summary>
		/// 会议日期
		/// </summary>
		public DateTime? MEETINGDATE
		{
			set{ _meetingdate=value;}
			get{return _meetingdate;}
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
		/// 会议总结
		/// </summary>
		public string SUMMARY
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		#endregion Model

	}
}

