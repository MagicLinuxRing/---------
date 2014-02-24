using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// CHARGEBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CHARGEBASE
	{
		public CHARGEBASE()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _gradeid;
		private int? _charge;
		private DateTime? _chargedate;
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
		/// 收费名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 收费金额
		/// </summary>
		public int? CHARGE
		{
			set{ _charge=value;}
			get{return _charge;}
		}
		/// <summary>
		/// 收费日期
		/// </summary>
		public DateTime? CHARGEDATE
		{
			set{ _chargedate=value;}
			get{return _chargedate;}
		}
		/// <summary>
		/// 收费描述
		/// </summary>
		public string DESCRIPTION
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

