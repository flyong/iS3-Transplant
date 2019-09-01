using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public interface ILogin
    {
        event EventHandler<ResultData> UserLoginFinished;
    }
}
