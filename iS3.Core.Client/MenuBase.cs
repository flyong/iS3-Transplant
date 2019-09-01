using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public class MenuBase
    {
        public string TargetObjType { get; set; }
        public OperationType MethodType { get; set; }
        public string Desc { get; set; }
        public string Tip { get; set; }
    }
    public enum OperationType
    {
        CreateObjs, Create, Update, UpdateObjs, Read, ReadObjs, Delete, DeleteObjs
    }
}
