using iS3.Core.Client;
using iS3.Unity.EXE;
using iS3UnityLib.Model.Event;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using iS3.Construction.Model;
using iS3.Core.Client;
namespace D3Operation
{
    public class D3ProgressControl : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;
        public static bool _state = true;
        public static int _init = 0;
        public double getMileage(string m)
        {
            string mi = m.Substring(2, m.Length - 2);
            mi = mi.Replace("+", "");
            return double.Parse(mi);
        }
        public void Func(string Params)
        {
            if (_init == 0)
            {
                SetProgressEvent _event = new SetProgressEvent(UnityEventType.SetProgressEvent);
                _event.TunnelSectionList = new List<TunnelSection>();
                List<Tuple<string, string>> list = Globals.tunnelSectionList;
                foreach (var data in Globals.tunnelSectionList)
                {
                    _event.TunnelSectionList.Add(new TunnelSection() { startM = data.Item1, endM = data.Item2 });
                }
                _event.TunnelPointList = new List<string>();
                double zmax = 0;double zmin = 20000; double ymax = 0; double ymin = 20000;
                string zmaxStr = "";string zminStr = ""; string ymaxStr = ""; string yminStr = "";
                foreach (string str in Globals.tunnelPosList)
                {
                    if (str.StartsWith("YK"))
                    {
                        double mi = getMileage(str);
                        if ((mi<7000) && (mi > ymax)) { ymax = mi;ymaxStr = str; }
                        if ((mi > 7000) && (mi < ymin)) { ymin = mi; yminStr = str; }
                    }
                    if (str.StartsWith("ZK"))
                    {
                        double mi = getMileage(str);
                        if ((mi < 7000) && (mi > zmax)) { zmax = mi; zmaxStr = str; }
                        if ((mi > 7000) && (mi < zmin)) { zmin = mi; zminStr = str; }

                    }

                }
                _event.TunnelPointList.Add(ymaxStr);
                _event.TunnelPointList.Add(zmaxStr);
                _event.TunnelPointList.Add(yminStr);
                _event.TunnelPointList.Add(zminStr);
                U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
                model.ExcuteCommand(JsonConvert.SerializeObject(_event));
            }
            else
            {
                _state = !_state;
                SetProgressEvent _event = new SetProgressEvent(UnityEventType.SetProgressEvent);
                _event.state = _state;
                U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
                model.ExcuteCommand(JsonConvert.SerializeObject(_event));
            }
            _init++;

            Project _prj = Globals.project;
            Domain _constructionDoamin = _prj.getDomain("Construction");
            DGObjects _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
            Globals.mainFrame.DGObjectsSelectionChangedListener(this, new DGObjectsSelectionChangedEvent() { newObjs = _gprfDGObjects });
            //二维视图改变
            IMainFrame mainFrame = Globals.mainFrame;
            //获取要添加图元的视图view
            IView2D _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
            List<string> dynamiclayerlist = new List<string>() { "ACHE", "ACHE_EC", "ACHE_YG","ACHE_ZZM" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            iS3Legned legeng_ACHE = new iS3Legned()
            {
                legndTitle = "施工进度图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){colorName="Yellow",label="初衬",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="GreenYellow",label="二衬",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Khaki",label="仰拱",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){label="掌子面",symbolType=SymbolType.Icon,refPath="redflag.png" }
                     //new iS3Symbol(){label="图片",symbolType=SymbolType.Icon,refPath="照片.png"}
                }
            };
            _inputView.holder.setlegend(legeng_ACHE);
            _inputView.holder.setLegendShow(true);

            _inputView = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
            dynamiclayerlist = new List<string>() { "ACHE", "ACHE_EC", "ACHE_YG", "ACHE_ZZM" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            legeng_ACHE = new iS3Legned()
            {
                legndTitle = "施工进度图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){colorName="Yellow",label="初衬",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="GreenYellow",label="二衬",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Khaki",label="仰拱",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){label="掌子面",symbolType=SymbolType.Icon,refPath="redflag.png" }
                     //new iS3Symbol(){label="图片",symbolType=SymbolType.Icon,refPath="照片.png"}
                }
            };
            _inputView.holder.setlegend(legeng_ACHE);
            _inputView.holder.setLegendShow(true);

        }
    }
}
