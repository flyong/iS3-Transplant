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

namespace D3Operation
{
    public class D3PointControl : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
            SetPointEvent _event = new SetPointEvent(UnityEventType.SetPointEvent);
            _event.TunnelPointList = Globals.tunnelPosList2;
            
            model.ExcuteCommand(JsonConvert.SerializeObject(_event));

            //Project _prj = Globals.project;
            //Domain _constructionDoamin2 = _prj.getDomain("Construction");
            //DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "TPSI").FirstOrDefault();
            //foreach (DGObject obj in _gprfDGObjects2.objContainer)
            //{
            //    TPSI tpsi = JsonConvert.DeserializeObject<TPSI>(JsonConvert.SerializeObject(obj));
            //    TPSI t = obj as TPSI;
            //    if ((tpsi.TPSI_ZHQJ == null) || (tpsi.TPSI_ZHQJ.Length == 0)) { continue; }
            //    bool _state = tpsi.TPSI_ZGJD == "已完成" ? true : false;
            //    Globals.tunnelPosList2.Add(tpsi.TPSI_ZHQJ.Split('-')[0] + "#" + tpsi.ID.ToString() + "#" + _state.ToString());
            //}
        }
    }
}
