using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SPEC")]
	public class SPEC:DGObject
 	{ 
/// <summary>
///
///采样ID </summary>
		public string SAMP_ID {get;set;}
/// <summary>
///
///钻孔ID </summary>
		public string HDPH_ID {get;set;}
/// <summary>
///
///样本ID </summary>
		public string SPEC_ID {get;set;}
/// <summary>
///
///样品容器 </summary>
		public string SPEC_CONT {get;set;}
/// <summary>
///
///样品基质 </summary>
		public string SPEC_MATX {get;set;}
/// <summary>
///
///样本岩性概述 </summary>
		public string SPEC_DESC {get;set;}
/// <summary>
///
///几何尺寸 </summary>
		public string SPEC_SIZE {get;set;}
/// <summary>
///
///样本描述时间 </summary>
		public string SPEC_DESD {get;set;}
/// <summary>
///
///样本描述者 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///样品状态 </summary>
		public string SPEC_COND {get;set;}
/// <summary>
///
///地层ID </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///样本制备细节 </summary>
		public string SPEC_PREP {get;set;}
/// <summary>
///
///备注 </summary>
		public string SPEC_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}