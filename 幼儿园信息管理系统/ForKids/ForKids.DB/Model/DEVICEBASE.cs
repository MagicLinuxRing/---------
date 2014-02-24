using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// DEVICEBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DEVICEBASE
	{
		public DEVICEBASE()
		{}
		#region Model
		private int _id;
		private string _name;
		private double? _funding;
		private string _lossinfo;
		private string _purchaseplan;
		private double? _investment;
		private DateTime? _purchasedate;
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
		/// 设备名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 设备资金
		/// </summary>
		public double? FUNDING
		{
			set{ _funding=value;}
			get{return _funding;}
		}
		/// <summary>
		/// 设备损耗情况
		/// </summary>
		public string LOSSINFO
		{
			set{ _lossinfo=value;}
			get{return _lossinfo;}
		}
		/// <summary>
		/// 采购计划
		/// </summary>
		public string PURCHASEPLAN
		{
			set{ _purchaseplan=value;}
			get{return _purchaseplan;}
		}
		/// <summary>
		/// 实际投入
		/// </summary>
		public double? INVESTMENT
		{
			set{ _investment=value;}
			get{return _investment;}
		}
		/// <summary>
		/// 采购日期
		/// </summary>
		public DateTime? PURCHASEDATE
		{
			set{ _purchasedate=value;}
			get{return _purchasedate;}
		}
		/// <summary>
		/// 设备信息
		/// </summary>
		public string DESCRIPTION
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

