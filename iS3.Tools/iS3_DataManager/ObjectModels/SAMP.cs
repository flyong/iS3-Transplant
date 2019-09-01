using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SAMP")]
	public class SAMP:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///采样ID </summary>
		public string SAMP_ID {get;set;}
/// <summary>
///
///顶埋深 </summary>
		public Nullable<double> SAMP_TOP {get;set;}
/// <summary>
///
///采样类型 </summary>
		public string SAMP_TYPE {get;set;}
/// <summary>
///
///底埋深 </summary>
		public Nullable<double> SAMP_BASE {get;set;}
/// <summary>
///
///采样时间 </summary>
		public string SAMP_DTIM {get;set;}
/// <summary>
///
///贯入击数 </summary>
		public Nullable<int> SAMP_UBLO {get;set;}
/// <summary>
///
///取样时的样品制备细节 </summary>
		public string SAMP_PREP {get;set;}
/// <summary>
///
///距地下水位面高度 </summary>
		public Nullable<double> SAMP_WDEP {get;set;}
/// <summary>
///
///采样率 </summary>
		public Nullable<int> SAMP_RECV {get;set;}
/// <summary>
///
///采样方法 </summary>
		public string SAMP_METH {get;set;}
/// <summary>
///
///采样者 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///采样目的 </summary>
		public string SAMP_PURS {get;set;}
/// <summary>
///
///采样备注 </summary>
		public string SAMP_REM {get;set;}
/// <summary>
///
///采样时的大气压力 </summary>
		public Nullable<double> SAMP_BAR {get;set;}
/// <summary>
///
///采样时的样品温度 </summary>
		public Nullable<int> SAMP_TEMP {get;set;}
/// <summary>
///
///采样时的气体流速 </summary>
		public Nullable<double> SAMP_FLOW {get;set;}
/// <summary>
///
///采样结束时间 </summary>
		public string SAMP_ETIM {get;set;}
/// <summary>
///
///采样持续时间 </summary>
		public string SAMP_DURN {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}