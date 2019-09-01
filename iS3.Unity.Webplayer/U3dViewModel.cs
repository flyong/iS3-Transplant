using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using iS3.Core;
using iS3.Core.Client;
using iS3.Core.Client.Geometry;
using iS3.Core.Client.Graphics;
using iS3.Core.Model;
using iS3.Unity.Webplayer.UnityCore;

namespace iS3.Unity.Webplayer
{
    public class U3dViewModel : IView
    {
        
        #region IView interface
        public ViewType type { get { return ViewType.General3DView; } }
        public IEnumerable<IGraphicsLayer> layers { get { return null; } }
        public IGraphicsLayer drawingLayer { get { return null; } }
        public ISpatialReference spatialReference { get { return null; } }

        public Project prj { get; set; }

        public string name { get; set; }

        public EngineeringMap eMap { get; set; }

        public UserControl parent => throw new NotImplementedException();

        public ViewBaseType baseType => throw new NotImplementedException();

        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }
        public EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get; set; }
        public IViewHolder holder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void onClose() { }

        public void highlightObject(DGObject obj, bool on = true)
        {
            if (obj == null || obj.parent == null)
                return;

            SetObjSelectStateMessage message = new SetObjSelectStateMessage();
            message.path = obj.parent.definition.Layer3DName + "/" + obj.ID;
            message.iSSelected = on;
            ExcuteCommand(message);
        }
        public void highlightObjects(IEnumerable<DGObject> objs, bool on = true)
        {
            if (objs == null)
                return;
            foreach (DGObject obj in objs)
                highlightObject(obj, on);
        }
        public void highlightObjects(IEnumerable<DGObject> objs,
            string layerID, bool on = true)
        { }
        public void highlightAll(bool on = true) { }

        public IMapPoint screenToLocation(System.Windows.Point screenPoint)
        { return null; }
        public System.Windows.Point locationToScreen(IMapPoint mapPoint)
        { return new System.Windows.Point(); }

        public void addSeletableLayer(string layerID) { }
        public void removeSelectableLayer(string layerID) { }

        public void zoomTo(IGeometry geom) { }

        public void addLayer(IGraphicsLayer layer) { }
        public IGraphicsLayer getLayer(string layerID)
        {
            return null;
        }
        public IGraphicsLayer removeLayer(string layerID)
        {
            return null;
        }

        public void addLocalTiledLayer(string DestnationPath, string id) { }
        public Task<IGraphicsLayer> addGdbLayer(Core.Model.LayerDef layerDef,
            string dbFile, int start = 0, int maxFeatures = 0)
        {
            return null;
        }

        public Task<IGraphicsLayer> addShpLayer(Core.Model.LayerDef layerDef,
            string shpFile, int start = 0, int maxFeatures = 0)
        {
            return null;
        }


        public int syncObjects()
        {
            return 0;
        }
        public async Task loadPredefinedLayers()
        {
            Load3DScene();
        }
        public void objSelectionChangedListener(object sender,
            ObjSelectionChangedEvent e)
        {
            if (sender == this)
                return;

            if (e.addObjs != null)
            {
                foreach (string layerID in e.addObjs.Keys)
                    highlightObjects(e.addObjs[layerID], true);

            }
            if (e.removeObjs != null)
            {
                foreach (string layerID in e.removeObjs.Keys)
                    highlightObjects(e.removeObjs[layerID], false);
            }
        }
        public event EventHandler<ObjSelectionChangedEvent>
            objSelectionChangedTrigger;
        public event EventHandler<DrawingGraphicsChangedEventArgs>
            drawingGraphicsChangedTrigger;
        //public event EventHandler<DGObjectsSelectionChangedEventArgs> DGObjectsSelectionChangedTriggerOuter;
        //public event EventHandler<ObjSelectionChangedEventArgs> objSelectionChangedTriggerOuter;
        //public event EventHandler<DGObjectsSelectionChangedEventArgs> DGObjectsSelectionChangedTriggerInner;
        //public event EventHandler<ObjSelectionChangedEventArgs> objSelectionChangedTriggerInner;
        #endregion

        public EventHandler<UnityLayer> UnityLayerHandler;
        U3DPlayerAxLib.U3DPlayerControl _u3dPlayerControl;

        public U3dViewModel(UserControl parent,
            U3DPlayerAxLib.U3DPlayerControl u3dPlayerControl)
        {
            _u3dPlayerControl = u3dPlayerControl;
        }
        public bool IsValidFileName(string filename)
        {

            if (filename == null || filename.Count() == 0)
                return false;
            else
                return true;
        }
        public EventHandler<IS3ToUnityArgs> sendMessageEventHandler;
        public EventHandler<UnityToIS3Args> receiveMessageHandler;

        public async Task Load3DScene()
        {
            //// check file exists
            string DestnationPath = Runtime.dataPath + "\\"+Globals.project.projectID+"\\"
                + eMap.LocalTileFileNames.FirstOrDefault();
            if (File.Exists(DestnationPath))
            {
                _u3dPlayerControl.LoadScence(DestnationPath);
            }
            else
            {
                _u3dPlayerControl.LoadScence(Runtime.dataPath + "\\" + Globals.project.projectID + "\\Default.unity3d");
            }
            _u3dPlayerControl.UnityCall += new U3DPlayerAxLib.U3DPlayerControl.ExternalCallHandler(_u3dPlayerControl_UnityCall);
            receiveMessageHandler += new EventHandler<UnityToIS3Args>(ReceiveMessageListener);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _u3dPlayerControl_UnityCall(object sender, AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_OnExternalCallEvent e)
        {
            try
            {
                string message = e.value;
                string[] list = message.Split('"');
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].StartsWith("@"))
                    {
                       iS3UnityMessage myMessage = UnityMessageConverter.DeSerializeMessage(list[i]);
                        switch (myMessage.type)
                        {
                            case MessageType.SendUnityLayer:
                                SendUnityLayerMessage _message0 = myMessage as SendUnityLayerMessage;
                                if (UnityLayerHandler != null)
                                {
                                    UnityLayerHandler(this, _message0.MyUnityLayer);
                                }
                                break;
                            case MessageType.SetObjSelectState:
                                SetObjSelectStateMessage _message = myMessage as SetObjSelectStateMessage;
                                string _path = _message.path;
                                int id = int.Parse(_path.Split('/')[_path.Split('/').Length - 1]);
                                string layer3d = _path.Substring(0, _path.Length - 1 - (id).ToString().Length);
                                bool isSelected = _message.iSSelected;
                                foreach (DGObjects objs in prj.Get3dRelatedObjs(layer3d))
                                {
                                    ShowSelect(objs, id, isSelected);
                                }
                                break;
                            case MessageType.SetObjShowState:
                                break;
                            default: break;
                        }
                    }
                }
            }
            catch { }

        }

        DGObject lastOne = null;
        public async Task ShowSelect(DGObjects objs, int id, bool isselected)
        {
            try
            {
                List<DGObject> addedObjs = new List<DGObject>();
                List<DGObject> removedObjs = new List<DGObject>();
                DGObject obj = await RepositoryForClient.RetrieveObj(objs.objContainer.Where(x => x.ID == id).FirstOrDefault());
                addedObjs.Add(obj);
                if (lastOne != null)
                {
                    removedObjs.Add(lastOne);
                }
                lastOne = obj;
                string layerName = objs.definition.Name;

                if (ObjSelectionChangedHandler != null)
                {
                    Dictionary<string, List<DGObject>> addedObjsDict = null;
                    Dictionary<string, List<DGObject>> removedObjsDict = null;
                    if (addedObjs.Count > 0)
                    {
                        addedObjsDict = new Dictionary<string, List<DGObject>>();
                        addedObjsDict[layerName] = addedObjs;
                    }
                    if (removedObjs.Count > 0)
                    {
                        removedObjsDict = new Dictionary<string, List<DGObject>>();
                        removedObjsDict[layerName] = removedObjs;
                    }
                    ObjSelectionChangedEvent args =
                        new ObjSelectionChangedEvent();
                    args.addObjs = addedObjsDict;
                    args.removeObjs = removedObjsDict;
                    if (ObjSelectionChangedHandler != null)
                    {
                        ObjSelectionChangedHandler(this, args);
                    }
                }
            }
            catch (Exception ex)
            {

            }

}
        private void ReceiveMessageListener(object sender, UnityToIS3Args args)
        {
            //switch (args.methodType)
            //{
            //    case UnityToIS3Method.LoadComplete: break;
            //    case UnityToIS3Method.Select:
            //        SelectObjByName(args.info);
            //        break;
            //    default: break;
            //}
        }
        public void ExcuteCommand(iS3UnityMessage message)
        {
            ExcuteCommand(UnityMessageConverter.SerializeMessage(message));
        }
        public void ExcuteCommand(string command)
        {
            _u3dPlayerControl.SendMessage("Main Camera", "ReceiveMessage", command);
        }
        #region  receive function
     
        #endregion
        #region send function
        public string TurnObjToName(DGObject obj)
        {
            string result = obj.name;
            result = obj.parent.definition.Type + "+" + result;
            result = obj.parent.parent.name + "+" + result;
            result = Globals.project.projectInfo.ID + "+" + result;
            return result;
        }

        public void load()
        {
            throw new NotImplementedException();
        }

        public async Task initializeView()
        {
           Load3DScene();
        }

        public async Task initialzeView()
        {
           await  Load3DScene();
        }

        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {

        }
        public Task Init()
        {
                return null;
            }

        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {
           
        }



        //public void objSelectionChangedListenerOuter(object sender, ObjSelectionChangedEventArgs e)
        //{
        //    if (e.addedObjs != null)
        //    {
        //        foreach (string layerID in e.addedObjs.Keys)
        //            highlightObjects(e.addedObjs[layerID], true);

        //    }
        //    if (e.removedObjs != null)
        //    {
        //        foreach (string layerID in e.removedObjs.Keys)
        //            highlightObjects(e.removedObjs[layerID], false);
        //    }
        //}

        //public void DGObjectsSelectionChangedListenerInner(object sender, DGObjectsSelectionChangedEventArgs e)
        //{

        //}

        //public void objSelectionChangedListenerInner(object sender, ObjSelectionChangedEventArgs e)
        //{

        //}
        #endregion
    }
    #region 方法枚举
    public enum IS3ToUnityMethod
    {
        SetObjShowByName,
        SetObjShowByType,
        SetObjSelectByName,
        SetObjSelectByType,
        SetAllObjSelectState,
        SetObjPosByName,
        SetObjPosByType,
        MoveObjPosByName,
        MoveObjPosByType,
        QueryPosByName
    }
    public enum UnityToIS3Method
    {
        LoadComplete,
        Select,
    }
    #endregion
    #region 事件定义
    /// <summary>
    /// Reveive Message From Unity Event
    /// </summary>
    public class UnityToIS3Args : EventArgs
    {
        public UnityToIS3Method methodType;
        public string info;
    }
    /// <summary>
    /// unity success load
    /// </summary>
    public class IS3ToUnityArgs : EventArgs
    {
        public string obj { get; set; }
        public IS3ToUnityMethod method { get; set; }
        public string para { get; set; }
    }
    #endregion
}
