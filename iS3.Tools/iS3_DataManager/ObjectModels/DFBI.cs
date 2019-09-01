using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_DFBI")]
	public class DFBI:DGObject
 	{ 
/// <summary>
///
///人员信息 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///预报方法标识 </summary>
		public string DFBI_METH {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string DFBI_MILE {get;set;}
/// <summary>
///
///掌子面里程值 </summary>
		public Nullable<double> DFBI_TUFM {get;set;}
/// <summary>
///
///预报长度 </summary>
		public Nullable<double> DFBI_LENG {get;set;}
/// <summary>
///
///预报时间 </summary>
		public string DFBI_TIME {get;set;}
/// <summary>
///
///钻探成果数据 </summary>
		public string GEPR_ID {get;set;}
/// <summary>
///
///分段信息 </summary>
		public string GPSI_ID {get;set;}
/// <summary>
///
///预报结论 </summary>
		public string DFBI_FORC {get;set;}
/// <summary>
///
///后续建议 </summary>
		public string DFBI_ADVC {get;set;}
/// <summary>
///
///实际采取措施 </summary>
		public string DFBI_ACME {get;set;}
/// <summary>
///
///备注 </summary>
		public string DFBI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}