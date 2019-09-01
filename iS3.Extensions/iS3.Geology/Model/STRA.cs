﻿using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Geology.Model
{
    //施工进度信息
    //
    [Table("Geology_STRA")]
    public class STRA : DGObject
    {
        //标段号
        public string STRA_ID { get; set; }
        //左右幅
        public string STRA_NAME { get; set; }
        //记录时间
        public string STRA_DESC { get; set; }
        //终点桩号
        public string STRA_GEO1 { get; set; }
        //施工面进度
        public string STRA_GEO2 { get; set; }
        //初衬进度
        public string STRA_STAT { get; set; }
        //二衬进度
        public string STRA_DSRG { get; set; }
        //二衬进度
        public string STRA_DIP { get; set; }
        //二衬进度
        public string STRA_DIR { get; set; }
        //二衬进度
        public string FILE_FSET { get; set; }
    }
}
