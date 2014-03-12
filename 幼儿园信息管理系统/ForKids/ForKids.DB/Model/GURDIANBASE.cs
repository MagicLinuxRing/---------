using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// GURDIANBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GURDIANBASE
	{
		public GURDIANBASE()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _idnumber;
		private int _age;
		private bool _sex= false;
		private byte[] _photo;
		private string _phone;
		private string _exphone;
		private string _address;
		private string _familyinfo;
		/// <summary>
		/// 标识
		/// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
		/// 身份证号
		/// </summary>
		public string IDNUMBER
		{
			set{ _idnumber=value;}
			get{return _idnumber;}
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
		/// 家庭地址
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 家庭情况
		/// </summary>
		public string FAMILYINFO
		{
			set{ _familyinfo=value;}
			get{return _familyinfo;}
		}
		#endregion Model

	}
}

