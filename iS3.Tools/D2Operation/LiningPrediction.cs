using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core;
using iS3.Core.Client;

namespace D2Operation
{
    public class LiningPrediction : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {

        }
    }
}
