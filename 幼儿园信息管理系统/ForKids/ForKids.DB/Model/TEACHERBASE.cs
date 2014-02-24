using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// TEACHERBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TEACHERBASE
	{
		public TEACHERBASE()
		{}
		#region Model
		private int _id;
		private string _jobnumber;
		private string _name;
		private int _age;
		private bool _sex= false;
		private byte[] _photo;
		private string _phone;
		private string _exphone;
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
		/// 工号
		/// </summary>
		public string JOBNUMBER
		{
			set{ _jobnumber=value;}
			get{return _jobnumber;}
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
		public int AGE
		{
			set{ _age=value;}
			get{return _age;}
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
		/// 照片
		/// </summary>
		public byte[] PHOTO
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string PHONE
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 备用电话号码
		/// </summary>
		public string EXPHONE
		{
			set{ _exphone=value;}
			get{return _exphone;}
		}
		/// <summary>
		/// 个人说明
		/// </summary>
		public string DESCRIPTION
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

