using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_DISC")]
	public class DISC:DGObject
 	{ 
/// <summary>
///
///节理组编号 </summary>
		public string FRAC_SET {get;set;}
/// <summary>
///
///节理编号 </summary>
		public string DISC_NUMB {get;set;}
/// <summary>
///
///节理类型 </summary>
		public string DISC_TYPE {get;set;}
/// <summary>
///
///倾角 </summary>
		public Nullable<int> DISC_DIP {get;set;}
/// <summary>
///
///倾向 </summary>
		public Nullable<int> DISC_DIR {get;set;}
/// <summary>
///
///小范围粗糙度Rs </summary>
		public string DISC_RS {get;set;}
/// <summary>
///
///大范围粗糙度Rl </summary>
		public string DISC_RL {get;set;}
/// <summary>
///
///大范围粗糙度下波长 </summary>
		public Nullable<double> DISC_WAVE {get;set;}
/// <summary>
///
///大范围粗糙度下振幅 </summary>
		public Nullable<double> DISC_AMP {get;set;}
/// <summary>
///
///是否有溶洞 </summary>
		public Nullable<bool> DISC_KARST {get;set;}
/// <summary>
///
///节理粗糙度系数 </summary>
		public Nullable<int> DISC_JRC {get;set;}
/// <summary>
///
///表面形貌 </summary>
		public string DISC_APP {get;set;}
/// <summary>
///
///缝宽 </summary>
		public Nullable<int> DISC_APT {get;set;}
/// <summary>
///
///是否填充 </summary>
		public Nullable<bool> DISC_APOB {get;set;}
/// <summary>
///
///填充物 </summary>
		public string DISC_INFM {get;set;}
/// <summary>
///
///延展性 </summary>
		public string DISC_DUCT {get;set;}
/// <summary>
///
///节理强度 </summary>
		public Nullable<int> DISC_STR {get;set;}
/// <summary>
///
///风化程度 </summary>
		public string DISC_WETH {get;set;}
/// <summary>
///
///渗透率评级 </summary>
		public string DISC_SEEP {get;set;}
/// <summary>
///
///水流流速 </summary>
		public Nullable<int> DISC_FLOW {get;set;}
/// <summary>
///
///备注 </summary>
		public string DISC_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}