using iS3.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iS3.Unity.EXE;
using Newtonsoft.Json;
using iS3UnityLib.Model.Event;
using iS3.Core.Model;
using iS3.Construction.Model;
using System.Diagnostics;

namespace D3Operation
{
    public class D3_Unity : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            Process process = new Process();
            process.StartInfo.FileName = Runtime.dataPath + "//" + Globals.project.projectID + "//show//Laoying_image.exe";
            process.Start();
        }
    }
}
