using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// KIDBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KIDBASE
	{
		public KIDBASE()
		{}
		#region Model
		private int _id;
		private string _studentid;
		private int? _gurdianid;
		private string _name;
		private short _age;
		private double? _height;
		private double? _weight;
		private bool _sex= false;
		private DateTime? _indate;
		private double? _insurance;
		private short _classid;
		private byte[] _photo;
		private string _medicalrecord;
		private string _transferrecord;
		private string _shuttleroute;
		private string _teacheradvice;
		/// <summary>
		/// 标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 学号
		/// </summary>
		public string STUDENTID
		{
			set{ _studentid=value;}
			get{return _studentid;}
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
		/// 姓名
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public short AGE
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public double? HEIGHT
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public double? WEIGHT
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public bool SEX
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 入学日期
		/// </summary>
		public DateTime? INDATE
		{
			set{ _indate=value;}
			get{return _indate;}
		}
		/// <summary>
		/// 保险
		/// </summary>
		public double? INSURANCE
		{
			set{ _insurance=value;}
			get{return _insurance;}
		}
		/// <summary>
		/// 班级
		/// </summary>
		public short CLASSID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public byte[] PHOTO
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 体检记录
		/// </summary>
		public string MEDICALRECORD
		{
			set{ _medicalrecord=value;}
			get{return _medicalrecord;}
		}
		/// <summary>
		/// 异动调班情况记录
		/// </summary>
		public string TRANSFERRECORD
		{
			set{ _transferrecord=value;}
			get{return _transferrecord;}
		}
		/// <summary>
		/// 接送路线
		/// </summary>
		public string SHUTTLEROUTE
		{
			set{ _shuttleroute=value;}
			get{return _shuttleroute;}
		}
		/// <summary>
		/// 教师评价与建议
		/// </summary>
		public string TEACHERADVICE
		{
			set{ _teacheradvice=value;}
			get{return _teacheradvice;}
		}
		#endregion Model

	}
}

