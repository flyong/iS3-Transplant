using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;


using Newtonsoft.Json;

using iS3UnityLib.Model.Event;
using System.Diagnostics;
using System.Threading;
using iS3.Core.Client.ViewModel;
using iS3.Core.Model;
using iS3.Core.Client;
using System.Linq;

namespace iS3.Unity.EXE
{
    public class U3DViewModel : IView3D
    {
        protected UnityPanel _parent;

        public Project prj
        {
            get { return Globals.project; }
        }
        protected EngineeringMap _map;
        private UnityPanel unityPanel;
        private Process process;
        TcpServer tcp;

        public EngineeringMap eMap
        {
            get { return _map; }
            set { _map = value; }
        }

        public ViewBaseType BaseType
        {
            get { return ViewBaseType.D3; }
        }

        public ViewType type
        {
            get { return ViewType.General3DView; }
        }

        public string name { get { return "Unity3D"; } }

        public ViewBaseType baseType
        {
            get { return ViewBaseType.D3; }
        }

        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }
        public EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get; set; }
        public IViewHolder holder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public ObservableCollection<ModelLayer> mySceneLayer { get; set; }

        public event EventHandler<ObjSelectionChangedEvent> objSelectionChangedTrigger;
        //public event EventHandler<MessageArgs> ReceiveMessageTrigger;
        //public event EventHandler<MessageArgs> SendMessageTrigger;
        public event EventHandler viewLoaded;
        // public EventHandler<UnityLayerUpdateEvent> unityLayerUpdateEventEventHandler;
        public U3DViewModel(UnityPanel parent)
        {
            _parent = parent;
            // actionManager = new iS3ActionManager(this);

        }

        public U3DViewModel()
        {
        }
        IntPtr WndHandle;
        public async Task<bool> Load3DScene(string DestnationPath)
        {
            try
            {
                process = new Process();
                process.StartInfo.FileName = DestnationPath;
                process.StartInfo.Arguments = _parent.GetArguments();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                process.WaitForInputIdle();

                _parent.EnumChildWindows();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
            tcp = new TcpServer();
            TcpServer.messageHandler += ReceiveMessageListener;
            tcp.StartServer();
            return true;
        }
        public bool IsEmbeded = true;
        public void EmbedWnd()
        {
            if (IsEmbeded == true) return;
            IsEmbeded = true;
            UnityPanel.SetParent(process.MainWindowHandle, _parent.unityHWND);
            ShowNormal();
           
        }

        public void NoEmbedWnd()
        {
            if (IsEmbeded == false) return;
            IsEmbeded = false;
            UnityPanel.SetParent(process.MainWindowHandle, IntPtr.Zero);
            ShowMini();
        }
        public void ShowMini()
        {
            UnityPanel.ShowWindow(process.MainWindowHandle, 2);
        }

        public void ShowNormal()
        {
            UnityPanel.ShowWindow(process.MainWindowHandle, 1);
        }
        public void onClose()
        {
            try
            {
                
                tcp.QuitServer();
                process.CloseMainWindow();

                Thread.Sleep(1000);
                while (process.HasExited == false)
                    process.Kill();
            }
            catch (Exception)
            {
                try
                {
                    process.CloseMainWindow();
                    Thread.Sleep(1000);
                    while (process.HasExited == false)
                        process.Kill();
                }
                catch { }
   
            }
        }
        public void highlightObject(DGObject obj, bool on = true)
        {
            try
            {
                SelectObjEvent ev = new SelectObjEvent(UnityEventType.SelectObjEvent)
                {
                    layerName = obj.parent.definition.Layer3DName,
                    ID = obj.ID.ToString(),
                    isSelected = on

                };
                tcp.SendMessage(JsonConvert.SerializeObject(ev));

            }
            catch
            {

            }
        }

        public void highlightObjects(IEnumerable<DGObject> objs, bool on = true)
        {
            foreach (DGObject obj in objs)
            {
                highlightObject(obj, on);
            }
        }

        public void highlightObjects(IEnumerable<DGObject> objs, string layerID, bool on = true)
        {
            foreach (DGObject obj in objs)
            {
                highlightObject(obj, on);
            }
        }

        public void highlightAll(bool on = true)
        {

        }

        public Core.Client.Geometry.IMapPoint screenToLocation(Point screenPoint)
        {
            return null;
        }

        public Point locationToScreen(Core.Client.Geometry.IMapPoint mapPoint)
        {
            return new Point();
        }

        public int syncObjects()
        {
            return 0;
        }

        public async Task loadPredefinedLayers(string DestnationPath)
        {
            await Load3DScene(DestnationPath);
        }

        public void objSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {

        }



        public void Update()
        {
        }
        //{"layerName":"iS3Project/Geology/Borehole","ID":"13","isSelected":true,"infos":null,"type":25}
        public void ReceiveMessageListener(object sender, MessageArgs e)
        {
            try
            {
                UnityEvent myEvent = JsonConvert.DeserializeObject<UnityEvent>(e.message);
                UnityEventType type = myEvent.type;
                switch (type)
                {
                    case UnityEventType.SelectObjEvent:

                        SelectObjEvent _event4 =
                            JsonConvert.DeserializeObject<SelectObjEvent>(e.message);
                        dealWithSelection(_event4);
                        break;
                    default: break;
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }
        public void dealWithSelection(SelectObjEvent _event)
        {
            try
            {
                string layerName = _event.layerName;
                string id = _event.ID;
                DGObjects objs = Globals.project.Get3dRelatedObjs(layerName).FirstOrDefault();
                DGObject obj = new DGObject() { ID = int.Parse(id),parent=objs };
                if (obj != null && ObjSelectionChangedHandler != null)
                {
                    ObjSelectionChangedEvent args = new ObjSelectionChangedEvent();
                    if (_event.isSelected)
                    {
                        args.addObjs = new Dictionary<string, List<DGObject>>();
                        List<DGObject> _objs = new List<DGObject>() { obj };
                        args.addObjs.Add(objs.definition.Name, _objs);
                    }
                    else
                    {
                        args.removeObjs = new Dictionary<string, List<DGObject>>();
                        List<DGObject> _objs = new List<DGObject>() { obj };
                        args.addObjs.Add(objs.definition.Name, _objs);
                    }
                    ObjSelectionChangedHandler(this, args);
                }
            }
            catch (Exception ex)
            {

            }
        }
        //public ObservableCollection<Pos> DeepCopy(ObservableCollection<Pos> newList)
        //{
        //    ObservableCollection<Pos> oldList = new ObservableCollection<Pos>();
        //    foreach (Pos p in newList)
        //    {
        //        oldList.Add(new Pos()
        //        {
        //            px = p.px,
        //            py = p.py,
        //            pz = p.pz,
        //            rx = p.rx,
        //            ry = p.ry,
        //            rz = p.rz,
        //            rw = p.rw,
        //        });
        //    }
        //    return oldList;
        //}
        public delegate void DeleFunc();
        public void Func()
        {
            //objSelectionChangedTrigger(this, args0);
        }
        public void Func1()
        {
            //ObjView objView = new ObjView();
            //List<FrameworkElement> list = myObj.chartViews(new List<DGObject>() { myObj }, 800, 450);
            //if ((list != null) && (list.Count > 0))

            //{
            //    objView.holder.Children.Add(list[0]);
            //    objView.Show();

            //}
            Document doc = new Document();
            doc.Width = 300;
            doc.Height = 200;
            doc.Show();
        }

        public void ExcuteCommand(string command)
        {
            tcp.SendMessage(command);
        }

        public void load()
        {
            throw new NotImplementedException();
        }

        public async Task initialzeView()
        {
            string filename = Runtime.dataPath + "//" + Globals.project.projectID + "//" + eMap.LocalTileFileNameStr + ".exe";
            await Load3DScene(filename);
        }

        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {

        }

        public async Task Init()
        {
            return;
        }

        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {

        }

        DGObject myObj;
        //显示三维进度
        //public void TestProgress()
        //{
        //    ProgressEvent ev = new ProgressEvent(UnityEventType.ProgressEvent)
        //    {
        //        list = new List<string>()
        //    {
        //        "ZK1+490,ZK4+300",
        //        "YK1+440,YK4+300",
        //       "ZK4+300,ZK4+975.7",
        //        "YK4+300,YK5+192.3",
        //        "BXK0+000,BXK1+650",
        //        "ZK9+766.4,ZK10+000",
        //        "YK9+672.8,YK10+000",
        //        "LXK0+000,LXK2+000",
        //        "ZK10+000,ZK12+995",
        //        "YK10+000,YK12+960"
        //    }
        //    };
        //    IView3D view3d = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as IView3D;
        //    view3d.ExcuteCommand(JsonConvert.SerializeObject(ev));
        //}
        ////显示三维进度tip
        //public void TestProgressTip()
        //{
        //    ProgressTipEvent ev = new ProgressTipEvent(UnityEventType.ProgressTipEvent)
        //    {
        //        mList = new List<string>()
        //    {
        //        "YK5+192.5",
        //        "YK9+672.8",
        //       "ZK9+766.4",
        //        "ZK4+975.7",
        //        "BXK1+650"
        //    }
        //    };
        //    IView3D view3d = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as IView3D;
        //    view3d.ExcuteCommand(JsonConvert.SerializeObject(ev));
        //}
    }
    public class MessageArgs
    {
        public string message { get; set; }
    }
    }
    
