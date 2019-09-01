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
    //视频资料
    public class D3_Construction_CHAG : IToolPlugin
    {
        public static bool state = true;
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            //初始化三维事件
            U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
            SetPointEvent _event = new SetPointEvent(UnityEventType.SetPointEvent);
            _event.Domain = "Construction";
            _event.state = state;
            state = !state;
            _event.ObjType = "CHAG";
            //获取数据
            Project _prj = Globals.project;
            Domain _constructionDoamin2 = _prj.getDomain("Construction");
            DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "CHAG").FirstOrDefault();
            foreach (DGObject obj in _gprfDGObjects2.objContainer)
            {
                try
                {
                    CHAG chag = JsonConvert.DeserializeObject<CHAG>(JsonConvert.SerializeObject(obj));
                    if ((chag.CHAG_CHAI == null) || (chag.CHAG_CHAI.Length == 0)) { continue; }
                    _event.TunnelPointList.Add(chag.CHAG_CHAI.Split('-')[0] + "#" + chag.ID.ToString());
                    int before = findNum(chag.CHAG_PRIM);     //原来的衬砌类型
                    int after = findNum(chag.CHAG_PRES);
                    if (before == after)
                    {
                        _event.ImageList.Add("Panel_Keep");
                    }
                    if (before > after)
                    {
                        _event.ImageList.Add("Panel_Decrease");
                    }
                    if (before < after)
                    {
                        _event.ImageList.Add("Panel_Increase");
                    }
                }
                catch (Exception ex)
                {

                }
               
            }
            model.ExcuteCommand(JsonConvert.SerializeObject(_event));
            //通知对象组改变事件
            Globals.mainFrame.DGObjectsSelectionChangedListener(this, new DGObjectsSelectionChangedEvent() { newObjs = _gprfDGObjects2 });
            //二维视图改变

            IMainFrame mainFrame = Globals.mainFrame;
            //获取要添加图元的视图view 右幅
            IView2D _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
            List<string> dynamiclayerlist = new List<string>() { "CHAG" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            iS3Legned legeng_CHAG = new iS3Legned()
            {
                legndTitle = "施工变更图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){colorName="HotPink",label="施工变更",symbolType=SymbolType.Rectangle}
                }
            };
            _inputView.holder.setlegend(legeng_CHAG);
            _inputView.holder.setLegendShow(true);

            //左幅
            _inputView = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
            dynamiclayerlist = new List<string>() { "CHAG" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            legeng_CHAG = new iS3Legned()
            {
                legndTitle = "施工变更图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){colorName="HotPink",label="施工变更",symbolType=SymbolType.Rectangle}
                }
            };
            _inputView.holder.setlegend(legeng_CHAG);

            _inputView.holder.setLegendShow(true);

        }
        public int findNum(string str)
        {
            if (str == null) return 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0') && (str[i] <= '9'))
                {
                    return int.Parse(str[i].ToString());
                }
            }
            return 0;
        }
    }
}
