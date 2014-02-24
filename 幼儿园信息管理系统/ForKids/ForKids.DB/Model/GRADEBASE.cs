using System;
namespace ForKids.DB.Model
{
	/// <summary>
	/// GRADEBASE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GRADEBASE
	{
		public GRADEBASE()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _headteacherid;
		private int? _tuition;
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
		/// 年级名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 年级主任
		/// </summary>
		public int? HEADTEACHERID
		{
			set{ _headteacherid=value;}
			get{return _headteacherid;}
		}
		/// <summary>
		/// 学费
		/// </summary>
		public int? TUITION
		{
			set{ _tuition=value;}
			get{return _tuition;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string DESCRIPTION
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

