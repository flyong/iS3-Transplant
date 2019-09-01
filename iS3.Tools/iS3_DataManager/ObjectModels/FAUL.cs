using System; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace iS3_DataManager.ObjectModel
{
    public class GeologyContext : DbContext
    {
        public GeologyContext() : base("Geology") { }
        public DbSet<FAUL> FAULs { get; set; }
    }

    [Table("Geology_FAUL")]
    public class FAUL
    {
        ///<summary>
        ///断层ID 
        ///</summary>
        public string FAUL_ID { get; set; }
        /// <summary>
        ///断层名称
        /// </summary>
        public string FAUL_NAME { get; set; }
        ///<summary>
        ///成因
        ///</summary>
        public string FAUL_CAUS { get; set; }
        /// <summary>
        ///产状
        /// </summary>
        public string FAUL_ATTD { get; set; }
        /// <summary>
        ///活动与否
        /// </summary>
        public Nullable<bool> FAUL_ACTI { get; set; }
        /// <summary>
        ///断距
        /// </summary>
        public Nullable<double> FAUL_BRED { get; set; }
        /// <summary>
        ///位移类型
        /// </summary>
        public string FAUL_TYPE { get; set; }
        /// <summary>
        ///断层破碎带组成
        /// </summary>
        public string FAUL_FFZC { get; set; }
        /// <summary>
        ///长度
        /// </summary>
        public Nullable<double> FAUL_LGTH { get; set; }
        /// <summary>
        ///与路线关系
        /// </summary>
        public string FAUL_RELA { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public string FAUL_REM { get; set; }
        /// <summary>
        ///关联文件
        /// </summary>
        public string FILE_FSET { get; set; }
    }
   
}