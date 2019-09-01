using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public interface IToolPlugin
    {
        string FuncName { get; }
        void Func(string Params);
        bool CheckIfUsing { get; }
        event EventHandler ToolFinishedEvent;
    }
}
