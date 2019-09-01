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
namespace D3Operation
{
    public class D3ModelControl : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
            SetObjShowEvent _event = new SetObjShowEvent(UnityEventType.SetObjShowEvent) { ObjName = Params };
            model.ExcuteCommand(JsonConvert.SerializeObject(_event));
        }
    }
}
