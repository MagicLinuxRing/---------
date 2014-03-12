using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// GURDIANATTENDANCE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GURDIANATTENDANCE
	{
		public GURDIANATTENDANCE()
		{}
		#region Model
		private int _id;
		private int? _gurdianid;
		private int? _mettingid;
		private bool _isattend= false;
		private string _attenddate;
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
		/// 监护人ID
		/// </summary>
		public int? GURDIANID
		{
			set{ _gurdianid=value;}
			get{return _gurdianid;}
		}
		/// <summary>
		/// 会议ID
		/// </summary>
		public int? METTINGID
		{
			set{ _mettingid=value;}
			get{return _mettingid;}
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
		public string ATTENDDATE
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

