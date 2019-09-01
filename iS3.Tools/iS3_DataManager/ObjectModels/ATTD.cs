using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ATTD")]
	public class ATTD:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///产状ID </summary>
		public string ATTD_ID {get;set;}
/// <summary>
///
///倾向 </summary>
		public Nullable<double> ATTD_DIR {get;set;}
/// <summary>
///
///倾角 </summary>
		public Nullable<double> ATTD_DIP {get;set;}
/// <summary>
///
///关联地层 </summary>
		public string ATTD_STRA {get;set;}
/// <summary>
///
///备注 </summary>
		public string ATTD_REM {get;set;}
/// <summary>
///
///有限元 </summary>
		public string FILE_FSET {get;set;}
	}
}