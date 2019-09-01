using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_DHFI")]
	public class DHFI:DGObject
 	{ 
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
///孔位ID </summary>
		public string DHRA_ID {get;set;}
/// <summary>
///
///地层记录代码或编号 </summary>
		public string STRA_STAT {get;set;}
/// <summary>
///
///层底里程值 </summary>
		public string DHRA_FMV {get;set;}
/// <summary>
///
///分层厚度 </summary>
		public Nullable<double> DHRA_LAYT {get;set;}
/// <summary>
///
///出水位置 </summary>
		public string DHRA_WATL {get;set;}
/// <summary>
///
///出水量 </summary>
		public Nullable<double> DHRA_WATO {get;set;}
/// <summary>
///
///采样 </summary>
		public string SAMP_ID {get;set;}
/// <summary>
///
///工程地质简述 </summary>
		public string DHRA_BDEG {get;set;}
/// <summary>
///
///备注 </summary>
		public string DHFI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}