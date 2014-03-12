using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// KIDPAYMENT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KIDPAYMENT
	{
		public KIDPAYMENT()
		{}
		#region Model
		private int _id;
		private int? _kidid;
		private int? _chargeid;
		private double? _payment;
		private DateTime? _paydate;
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
		/// 收费项ID
		/// </summary>
		public int? CHARGEID
		{
			set{ _chargeid=value;}
			get{return _chargeid;}
		}
		/// <summary>
		/// 已缴费金额
		/// </summary>
		public double? PAYMENT
		{
			set{ _payment=value;}
			get{return _payment;}
		}
		/// <summary>
		/// 缴费日期
		/// </summary>
		public DateTime? PAYDATE
		{
			set{ _paydate=value;}
			get{return _paydate;}
		}
		#endregion Model

	}
}

