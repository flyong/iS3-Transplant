using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_IRSI")]
	public class IRSI:DGObject
 	{ 
/// <summary>
///
///航片ID </summary>
		public string AERP_ID {get;set;}
/// <summary>
///
///解译索引编号 </summary>
		public string IRSI_ID {get;set;}
/// <summary>
///
///解译方法 </summary>
		public string IRSI_MEAN {get;set;}
/// <summary>
///
///图像类型 </summary>
		public string IRSI_PTYPE {get;set;}
/// <summary>
///
///解译地物类型 </summary>
		public string IRSI_GTYPE {get;set;}
/// <summary>
///
///主要解译标志 </summary>
		public string IRSI_SIGN {get;set;}
/// <summary>
///
///光学图像处理方法 </summary>
		public string IRSI_OIPM {get;set;}
/// <summary>
///
///数字图像处理方法 </summary>
		public string IRSI_DIPM {get;set;}
/// <summary>
///
///执行人 </summary>
		public string IRSI_STAFF {get;set;}
/// <summary>
///
///勘察单位 </summary>
		public string IRSI_CONT {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}