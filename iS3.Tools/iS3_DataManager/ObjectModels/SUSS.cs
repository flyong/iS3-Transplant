using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SUSS")]
	public class SUSS:DGObject
 	{ 
/// <summary>
///
///人员信息 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string SUSS_MILE {get;set;}
/// <summary>
///
///开始里程值 </summary>
		public Nullable<double> SUSS_SMIL {get;set;}
/// <summary>
///
///结束里程值 </summary>
		public Nullable<double> SUSS_EMIL {get;set;}
/// <summary>
///
///本次调查长度 </summary>
		public Nullable<double> SUSS_LENG {get;set;}
/// <summary>
///
///设计围岩等级 </summary>
		public Nullable<int> SUSS_DSRG {get;set;}
/// <summary>
///
///地层岩性描述 </summary>
		public string SUSS_STLD {get;set;}
/// <summary>
///
///地表岩溶描述 </summary>
		public string SUSS_SUKD {get;set;}
/// <summary>
///
///特殊地质产状描述 </summary>
		public string SUSS_SPGD {get;set;}
/// <summary>
///
///人为坑道描述 </summary>
		public string SUSS_ARTD {get;set;}
/// <summary>
///
///与设计情况是否相符 </summary>
		public string SUSS_MADE {get;set;}
/// <summary>
///
///地质评定 </summary>
		public string SUSS_GEAS {get;set;}
/// <summary>
///
///调查时间 </summary>
		public string SUSS_INTM {get;set;}
/// <summary>
///
///调查结论 </summary>
		public string SUSS_INCO {get;set;}
/// <summary>
///
///后续建议 </summary>
		public string SUSS_ADVC {get;set;}
/// <summary>
///
///实际采取措施 </summary>
		public string SUSS_ACME {get;set;}
/// <summary>
///
///备注 </summary>
		public string SUSS_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}