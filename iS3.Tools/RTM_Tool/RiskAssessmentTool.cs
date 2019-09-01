using iS3.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace RTM_Tool
{
    public class RiskAssessmentTool : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            RiskAssessment riskassess = new RiskAssessment();
            riskassess.Show();
        }
    }
}
