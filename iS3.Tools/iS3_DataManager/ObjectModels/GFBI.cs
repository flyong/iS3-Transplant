using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GFBI")]
	public class GFBI:DGObject
 	{ 
/// <summary>
///
///人员信息 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string GFBI_MILE {get;set;}
/// <summary>
///
///掌子面里程值 </summary>
		public Nullable<double> GFBI_TUFM {get;set;}
/// <summary>
///
///物探方法 </summary>
		public string GFBI_METH {get;set;}
/// <summary>
///
///设备名称 </summary>
		public string GFBI_NAME {get;set;}
/// <summary>
///
///预报长度 </summary>
		public Nullable<double> GFBI_LENG {get;set;}
/// <summary>
///
///预报时间 </summary>
		public string GFBI_TIME {get;set;}
/// <summary>
///
///物探成果数据 </summary>
		public string GEPR_ID {get;set;}
/// <summary>
///
///分段信息 </summary>
		public string GFBI_ID {get;set;}
/// <summary>
///
///预报结论 </summary>
		public string GFBI_FORC {get;set;}
/// <summary>
///
///后续建议 </summary>
		public string GFBI_ADVC {get;set;}
/// <summary>
///
///实际采取措施 </summary>
		public string GFBI_ACME {get;set;}
/// <summary>
///
///备注 </summary>
		public string GFBI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}