using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.Interface;

namespace iS3_DataManager.Models
{
    //*
    //  数据方案
    //
    public class DataSchema
    {
        public IDataFormatConverter dataFormatConverter { get; set; }

        public IPropertyMapping dataPropertyMapping { get; set; }

        public IDataVerification dataVerification { get; set; }
    }
}
