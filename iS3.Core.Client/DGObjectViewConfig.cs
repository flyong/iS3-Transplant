using iS3.Core.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public class DGObjectViewConfig
    {
        public string objType;
        // Summary:
        //     Call back function
        public delegate IDGObjectView DelegateFunc();
        public DelegateFunc func;

        public DGObjectViewConfig(string objType, DelegateFunc func)
        {
            this.objType = objType;
            this.func = func;
        }
    }
}
