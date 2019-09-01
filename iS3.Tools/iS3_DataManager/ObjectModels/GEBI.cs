using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GEBI")]
	public class GEBI:DGObject
 	{ 
/// <summary>
///
///物探ID </summary>
		public string GEBI_ID {get;set;}
/// <summary>
///
///测线里程冠号 </summary>
		public string GEBI_MILE {get;set;}
/// <summary>
///
///测线起始桩号 </summary>
		public string GEBI_SMIL {get;set;}
/// <summary>
///
///测线终止桩号 </summary>
		public string GEBI_EMIL {get;set;}
/// <summary>
///
///测线长度 </summary>
		public Nullable<double> GEBI_LENG {get;set;}
/// <summary>
///
///测点坐标集合 </summary>
		public string GEBI_PCS {get;set;}
/// <summary>
///
///测点间距 </summary>
		public Nullable<double> GEBI_MPS {get;set;}
/// <summary>
///
///探测深度 </summary>
		public Nullable<double> GEBI_PROD {get;set;}
/// <summary>
///
///物探方法 </summary>
		public string GEBI_METH {get;set;}
/// <summary>
///
///探测时间 </summary>
		public string GEBI_DTIM {get;set;}
/// <summary>
///
///设备信息 </summary>
		public string GEBI_DEVI {get;set;}
/// <summary>
///
///物探单位 </summary>
		public string GEBI_CONT {get;set;}
/// <summary>
///
///人员信息 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///备注 </summary>
		public string GEBI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}