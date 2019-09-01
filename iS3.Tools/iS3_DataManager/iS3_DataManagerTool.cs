using iS3.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace iS3_DataManager
{
    public class iS3_DataManagerTool : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            MainWindow datamanagerwindow = new MainWindow();
            datamanagerwindow.Show();
        }
    }
}
