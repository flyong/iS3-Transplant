using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_CORE")]
	public class CORE:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///钻孔ID </summary>
		public string HDPH_ID {get;set;}
/// <summary>
///
///顶埋深 </summary>
		public Nullable<double> CORE_TOP {get;set;}
/// <summary>
///
///底埋深 </summary>
		public Nullable<double> CORE_BASE {get;set;}
/// <summary>
///
///岩心采取率 (TCR) </summary>
		public Nullable<int> CORE_PREC {get;set;}
/// <summary>
///
///土心采取率(SCR) </summary>
		public Nullable<int> CORE_SREC {get;set;}
/// <summary>
///
///岩石质量指标 (RQD) </summary>
		public Nullable<int> CORE_RQD {get;set;}
/// <summary>
///
///取芯直径 </summary>
		public Nullable<int> CORE_DIAM {get;set;}
/// <summary>
///
///取芯持续时间 </summary>
		public string CORE_DURN {get;set;}
/// <summary>
///
///岩芯描述 </summary>
		public string CORE_DESC {get;set;}
/// <summary>
///
///备注 </summary>
		public string CORE_REM {get;set;}
/// <summary>
///
///关联文件（取芯照片） </summary>
		public string FILE_FSET {get;set;}
	}
}