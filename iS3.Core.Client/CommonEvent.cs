using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public enum OperationType
    {
        Create, Update,Read,Delete
    }
    public class CommonEvent : EventArgs
    {
        public OperationType type { get; set; }
        public object data { get; set; }
    }
}
