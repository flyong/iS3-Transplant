using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TWIS")]
	public class TWIS:DGObject
 	{ 
/// <summary>
///
///涌水量分段ID </summary>
		public string TWIS_ID {get;set;}
/// <summary>
///
///人员ID </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string TWIS_MILE {get;set;}
/// <summary>
///
///开始里程值 </summary>
		public Nullable<double> TWIS_SMIL {get;set;}
/// <summary>
///
///结束里程值 </summary>
		public Nullable<double> TWIS_EMIL {get;set;}
/// <summary>
///
///生成时间 </summary>
		public string TWIS_TIME {get;set;}
/// <summary>
///
///测量方法 </summary>
		public string TWIS_MEAM {get;set;}
/// <summary>
///
///测量仪器 </summary>
		public string TWIS_MEAI {get;set;}
/// <summary>
///
///平均涌水量 </summary>
		public Nullable<double> TWIS_AWI {get;set;}
/// <summary>
///
///实际采取措施 </summary>
		public string TWIS_ACME {get;set;}
/// <summary>
///
///备注 </summary>
		public string TWIS_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}