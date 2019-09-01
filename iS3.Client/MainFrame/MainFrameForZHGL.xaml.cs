using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Data;
using iS3.Core;
using iS3.Python;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Core.Client.Service;
using iS3.Client.Controls;
using iS3.Unity.Webplayer;
using iS3.Unity.EXE;
using Telerik.Windows.Controls;
using System.Text;

namespace iS3.Client
{
    //************************  Notice  **********************************
    //** This file is part of iS3
    //**
    //** Copyright (c) 2015 Tongji University iS3 Team. All rights reserved.
    //**
    //** This library is free software; you can redistribute it and/or
    //** modify it under the terms of the GNU Lesser General Public
    //** License as published by the Free Software Foundation; either
    //** version 3 of the License, or (at your option) any later version.
    //**
    //** This library is distributed in the hope that it will be useful,
    //** but WITHOUT ANY WARRANTY; without even the implied warranty of
    //** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    //** Lesser General Public License for more details.
    //**
    //** In addition, as a special exception,  that plugins developed for iS3,
    //** are allowed to remain closed sourced and can be distributed under any license .
    //** These rights are included in the file LGPL_EXCEPTION.txt in this package.
    //**
    //**************************************************************************

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainFrameForZHGL : UserControl, IMainFrame
    {
        #region params
        List<IView> _views = new List<IView>();
        ProfileView _profileview;
        IView _activeView = null;
        Project _prj;
        public string filtercontent { get; set; }
        #endregion
        #region IMainFrame interfaces

        public event EventHandler<ObjSelectionChangedEvent> objSelectionChangedTrigger;
        public event EventHandler projectLoaded;
        public event EventHandler viewLoaded;

        public event EventHandler<DGObjectsSelectionChangedEvent> dGObjectsSelectionChangedTrigger;

        public Project prj
        {
            get { return _prj; }
            set { _prj = value; }
        }
        public IEnumerable<IView> views
        {
            get { return _views; }
        }
        public IView activeView { get; set; }
        #endregion
        List<IViewHolder> viewHolders = new List<IViewHolder>();

        public string ProjectID
        {
            get { return projectID; }
        }
        //public List<IExteralUI> exteralUIs { get; set; }
        public string projectID { get; set; }


        public MainFrameForZHGL()
        {
            InitializeComponent();

            Loaded += MainFrame_Loaded;
            Unloaded += MainFrame_Unloaded;
        }
        public MainFrameForZHGL(string projectID)
        {
            InitializeComponent();

            Loaded += MainFrame_Loaded;
            Unloaded += MainFrame_Unloaded;

        }
        #region load/unload functions
        bool _init = false;
      
        async void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await init();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task init()
        {
            Thread.Sleep(100);
            output("\r\n");
            //await LoadViews();
            //loadDomainPanels();
            loadExtensions();
            loadToolboxes();
            loadPyPlugins();

           
            LoadTools(projectID);
            await LoadProject(projectID);
            //viewHolders.Add(MyDataGrid);
            //dGObjectsSelectionChangedTrigger += MyDataGrid.DGObjectsSelectionChangedListener;

            ComonObjsViewHolder.ObjsViewGeneral.MyIS3DataGrid.objSelectionChangedTrigger += objSelectionChangedListener;
            objSelectionChangedTrigger += ComonObjsViewHolder.ObjsViewGeneral.MyObjectView.objSelectionChangedListener;
            ComonObjsViewHolder.ObjsViewGeneral.MyObjectView.objSelectionChangedTrigger += objSelectionChangedListener;
            dGObjectsSelectionChangedTrigger += ComonObjsViewHolder.DGObjectsSelectionChangedListener;

            //MyDataGrid.objSelectionChangedTrigger += objSelectionChangedListener;

            //foreach (IViewHolder viewholder in viewHolders)
            //{
            //   // viewholder.view.load();

            //    viewholder.view.DGObjectsSelectionChangedHandler += DGObjectsSelectionChangedListener;
            //    dGObjectsSelectionChangedTrigger += viewholder.view.DGObjectsSelectionChangedListener;
            //}
            //await loadByPythonAsync();
            _init = true;
        }
      
        public void LoadTools(string projectID)
        {
            ToolsPanelViewModel model = new ToolsPanelViewModel();
            model.Load(projectID);
            toolsPanelNew.DataContext = model;
        }
        public async Task loadByPythonAsync()
        {
            AddProjectPathToPython();
            if ((projectID != null)
                && (projectID.Length != 0))
            {
                // await LoadProject(projectID + ".xml");
                // loadDomainPanels();
                string statement = string.Format("import {0}", projectID);
                runStatements(statement);
            }
            runStatements("");
        }

        void AddProjectPathToPython()
        {
            //ipcHost.addProjectPath(Runtime.rootPath + "\\Output\\IS3Py");
            //string[] folders = Directory.GetDirectories(Runtime.dataPath);
            //for (int i = 0; i < folders.Count(); i++)
            //{
            //    ipcHost.addProjectPath(folders[i]);
            //}
        }

        public async Task LoadProject(string definitionFile)
        {
            try
            {
                if (definitionFile == null
                               || definitionFile.Length == 0)
                    return;
                _prj = new Project() { projectID = projectID };
                _prj.projectInfo = await CommonRepo.GetProjectInfo(_prj.projectID);
                _prj.domains = await CommonRepo.GetDomains(_prj.projectID);
                _prj.emaps = await CommonRepo.GetEMaps(_prj.projectID);
                Globals.project = _prj;
                foreach (Domain domain in _prj.domains)
                {
                    try
                    {
                        domain.objectsDefinitions = await CommonRepo.GetObjectsDefinition(_prj.projectID, domain.name);
                        domain.DGObjectsList = new List<DGObjects>();
                        foreach (ObjectsDefinition definition in domain.objectsDefinitions)
                        {
                            if ((definition.Layer3DName == null) || (definition.Layer3DName == ""))
                            {
                                definition.Layer3DName = definition.Domain + "/" + definition.Type;
                            }
                            DGObjects objs = new DGObjects() { parent = domain, definition = definition, };
                            domain.DGObjectsList.Add(objs);
                            objs.objContainer = await RepositoryForClient.RetrieveObjs(objs);
                            _prj.objsDefIndex[definition.Name] = objs;
                        }
                    }
                    catch (Exception ex)
                    {
                      //  MessageBox.Show(ex.ToString());
                    }

                }

                loadDomainPanels();
                await LoadViews();


                if (projectLoaded != null)
                    projectLoaded(this, EventArgs.Empty);

                ViewHolder.SelectedIndex = 1;
            }
            catch (Exception ex)
            {

            }

        }

        int count;
        public async Task LoadViews()
        {
            if (_prj == null)
                return;

            // Initialize predefined docs and views
            ////
            count = 0;
            foreach (EngineeringMap eMap in _prj.emaps)
            {
                if (eMap.MapType == EngineeringMapType.FootPrintMap)
                    continue;

                IView view = await addView(eMap, false);
                //默认不开平面图
                count++;

                if (eMap.MapType == EngineeringMapType.GeneralProfileMap)
                    _activeView = view;
            }

            if (viewLoaded != null)
                viewLoaded(this, EventArgs.Empty);


        }
        public Dictionary<string, string> DomainChsTemp = new Dictionary<string, string>();
        public async void loadDomainPanels()
        {
            if (_prj == null)
                return;
            List<string> domainList = new List<string>() { "Geology", "Environment", "Structure", "Construction", "Monitoring" };

            DomainChsTemp["Geology"] = "地理地质";
            DomainChsTemp["Environment"] = "周边环境";
            DomainChsTemp["Structure"] = "设计";
            DomainChsTemp["Construction"] = "施工";
            DomainChsTemp["Monitoring"] = "监测";
            DomainChsTemp["Progress"] = "进度";
            // Initialize domain tree panels.
            //按照顺序添加对象树
            for (int i = 0; i < domainList.Count; i++)
            {
                Domain domain = _prj.domains.Where(x => x.name == domainList[i]).FirstOrDefault();
                if (domain == null) continue;
                RadPane layout = new RadDocumentPane() { CanUserClose = false, IsPinned = false, };
                layout.Name = domain.name;
                layout.Header = DomainChsTemp.ContainsKey(domain.name) ? DomainChsTemp[domain.name] : domain.name;
                DomainTreeHolder.Items.Add(layout);

                TreePanel treePanel = new TreePanel(domain.name);
                await treePanel.initialzeView();
                (treePanel as IView).DGObjectsSelectionChangedHandler += DGObjectsSelectionChangedListener;
                layout.Content = treePanel;
            }
            DomainTreeHolder.SelectedIndex = 0;
        }
        DGObjects _lastDGObjects;

        U3DViewModel viewModel3d = null;
        Unity.EXE.U3DView my3dView = null;
        RadPane temp2 = null;
        public async Task<IView> addView(EngineeringMap eMap, bool canClose)
        {
            try
            {
                RadPane layout = new RadDocumentPane() { CanUserClose = true };
                layout.Name = eMap.MapID;
                layout.Header = eMap.MapID;
                ViewHolder.Items.Add(layout);
                //ViewHolder.SelectedIndex = count;
                IView view = null;
                if (eMap.MapType == EngineeringMapType.FootPrintMap)
                {
                    PlanView planView = new PlanView(_prj, eMap);
                    view = planView.view;
                    // Load predefined layers
                    await view.initialzeView();
                    layout.Content = planView;
                }
                else if (eMap.MapType == EngineeringMapType.GeneralProfileMap)
                {
                    ProfileView profileView = new ProfileView(_prj, eMap);
                    view = profileView.view;
                    // Load predefined layers
                    await view.initialzeView();
                    _profileview = profileView;
                    layout.Content = profileView;
                }
                else if (eMap.MapType == EngineeringMapType.Map3D)
                {
                    if (eMap.LocalTileFileNameStr.EndsWith(".unity3d"))
                    {
                        Unity.Webplayer.U3DView u3dView = new Unity.Webplayer.U3DView(_prj, eMap);

                        view = u3dView.view;
                        viewModel3d = view as U3DViewModel;
                        // Load predefined layers
                        await view.initialzeView();
                        layout.Content = u3dView;
                    }
                    else
                    {
                        Unity.EXE.U3DView u3dView = new Unity.EXE.U3DView(_prj, eMap);
                        my3dView = u3dView;
                        temp2 = layout;
                        //layout.Content = u3dView;
                        temp.Child = u3dView;
                        //temp.Child = u3dView;
                        view = u3dView.panel.view;
                        viewModel3d = view as U3DViewModel;
                        // Load predefined layers
                        await view.initialzeView();

                    }
                }

                //// view is both a trigger and listener of object selection changed event
                view.ObjSelectionChangedHandler += this.objSelectionChangedListener;
                this.objSelectionChangedTrigger += view.ObjSelectionChangedListener;

                // Sync view graphics with data
                view.syncObjects();

                _views.Add(view);
                return view;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion
        #region common event
        // Summary:
        //     Object selection event listener (function).
        //     It will broadcast the event to views and datagrid.
        public void objSelectionChangedListener(object sender,
            ObjSelectionChangedEvent e)
        {
            if (objSelectionChangedTrigger != null)
                objSelectionChangedTrigger(sender, e);
        }
        // object _lastDGObjectSelectionChangedSender = null;
        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {
            if (sender == null) return;
            e.oldObjs = _lastDGObjects;
            _lastDGObjects = e.newObjs;
            if (dGObjectsSelectionChangedTrigger != null)
            {
                dGObjectsSelectionChangedTrigger(this, e);
            }
        }
        #endregion

        #region loadPlugin
        // Summary:
        //     Load extensions which are located in the bin\extensions\ directory.
        public void loadExtensions()
        {
            // DllImport.LoadExtension();
        }
        public void loadToolboxes()
        {
            //IToolsPanel ToolsPanel = new ToolsPanel();
            //ToolsHolder.Content = ToolsPanel;
            ////初始化拓展工具
            //ToolsPanel.init(DllImport.loadToolboxes());
        }
        // Summary:
        //     load python plugins
        // Remarks:
        //     Python scripts located in bin\PyPlugins will be executed automatically.
        public void loadPyPlugins()
        {
            Assembly exeAssembly = Assembly.GetExecutingAssembly();
            string exeLocation = exeAssembly.Location;
            string exePath = Path.GetDirectoryName(exeLocation);
            string pyPluginsPath = exePath + "\\PyPlugins";

            if (!Directory.Exists(pyPluginsPath))
                return;

            PyManager pyMan = new PyManager();
            pyMan.loadPlugins(pyPluginsPath);
        }
        #endregion

        #region python 
        // Summary:
        //     Write a string to console.
        // Remarks:
        //     This function will 'halt' python input.
        //     Call RunStatements("") to return to python prompt.
        public void output(string str)
        {
            //ipcHost.write(str);
        }

        // Summary:
        //     Run statements in python console.
        // Remarks:
        //     A run statements helps return to python prompt.
        public void runStatements(string statements)
        {
            // ipcHost.runStatements(statements);
        }

        private void Python_Click(object sender, RoutedEventArgs e)
        {
            //string pyPath = Runtime.rootPath;
            //pyPath = pyPath + "\\IS3Py";

            //System.Windows.Forms.OpenFileDialog dlg =
            //    new System.Windows.Forms.OpenFileDialog();
            //dlg.InitialDirectory = pyPath;
            //dlg.Filter = "Python scripts (*.py)|*.py";
            //dlg.DefaultExt = "py";

            //System.Windows.Forms.DialogResult result = dlg.ShowDialog();
            //if (result == System.Windows.Forms.DialogResult.OK)
            //{
            //    runPythonScripts(dlg.FileName);
            //}
        }

        // Summary:
        //     Run python scripts
        // Remarks:
        //     The scripts runned here is in the main UI thread, 
        //     which is different from scripts inputted in the Python
        //     Console window. In the case of Python Console window,
        //     the script is runned in another thread. Therefore,
        //     there is no restriction on calls to main UI thread here.
        // Known bugs:
        //     Script call to IS3View.addGdbLayer will hang the program.
        //     This problem doesn't exist in scripts runned from console window.
        public void runPythonScripts(string file)
        {
            PyManager pyMan = new PyManager();
            pyMan.run(file);
        }
        #endregion

        #region remove
        //public IView activeView
        //{
        //    get { return _activeView; }
        //    set
        //    {
        //        _activeView = value;
        //        //LayoutContent doc = FindLayoutContentByID(value.eMap.MapID);
        //        //if (doc != null && doc.IsSelected == false)
        //        //    doc.IsSelected = true;
        //    }
        //}
        //Tree _lastSelectedTree;

        ////  ProgressBarWindow _pbw;
        ////  List<IS3Tree> _treePanels = new List<IS3Tree>();
        //async Task FindDetail()
        //{
        //    //List<int> addedObjs = new List<int>();
        //    //List<int> removedObjs = new List<int>();

        //    //DGObject selectOne = MyDataGrid.DGObjectDataGrid.SelectedItem as DGObject;
        //    //DGObjectRepository repository = DGObjectRepository.Instance(
        //    //                  Globals.project.projDef.ID, nowTree.RefDomainName, nowTree.Name);
        //    //DGObject obj = await repository.Retrieve(selectOne.id);
        //    //addedObjs.Add(obj);
        //    //if (lastOne != null)
        //    //{
        //    //    removedObjs.Add(lastOne);
        //    //}
        //    //lastOne = selectOne;
        //    //layerName = Globals.project[nowTree.RefDomainName].GetDef(nowTree.Name).FirstOrDefault().GISLayerName;

        //    //if (objSelectionChangedTrigger != null)
        //    //{
        //    //    Dictionary<string, IEnumerable<int>> addedObjsDict = null;
        //    //    Dictionary<string, IEnumerable<int>> removedObjsDict = null;
        //    //    if (addedObjs.Count > 0)
        //    //    {
        //    //        addedObjsDict = new Dictionary<string, IEnumerable<int>>();
        //    //        addedObjsDict[layerName] = addedObjs;
        //    //    }
        //    //    if (removedObjs.Count > 0)
        //    //    {
        //    //        removedObjsDict = new Dictionary<string, IEnumerable<DGObject>>();
        //    //        removedObjsDict[layerName] = removedObjs;
        //    //    }
        //    //    ObjSelectionChangedEventArgs args =
        //    //        new ObjSelectionChangedEventArgs();
        //    //    args.addedObjs = addedObjsDict;
        //    //    args.removedObjs = removedObjsDict;
        //    //    objSelectionChangedListener(this, args);
        //    //}
        //}
        //void treePanel_OnTreeSelected(object sender, Tree tree)
        //{

        //    if (tree == null)
        //        MyDataGrid.DGObjectDataGrid.ItemsSource = null;
        //   // MyDataGrid.DGObjectDataGrid.ItemsSource = tree.ObjectsView;
        //    _lastSelectedTree = tree;

        //    GetData(tree);

        //}

        //public  async Task GetData(Tree tree)
        //{
        //    DGObjectRepository repository = DGObjectRepository.Instance(
        //         Globals.project.projDef.ID, tree.RefDomainName, tree.Name);
        //    layerName = Globals.project[tree.RefDomainName].GetDef(tree.Name).FirstOrDefault().GISLayerName;
        //    List<DGObject> objList = await repository.GetAllAsync();
        //    foreach (IView view in views)
        //    {
        //        int count=view.syncObjects(layerName, objList);
        //    }

        //    MyDataGrid.DGObjectDataGrid.ItemsSource = objList;
        //    nowTree = tree;
        //}

        //void DGObjectDataGrid_SelectionChanged(object sender,
        //   SelectionChangedEventArgs e)
        //{
        //    // Handles selection changed event triggered by user input only.
        //    // Selection changed event will also be triggered in 
        //    // situations like DGObjectDataGrid.ItemsSource = IEnumerable<>,
        //    // but we don't want to handle the event in such conditions.
        //    // This can be differentiated by the IsKeyboardFocusWithin property.
        //    if (MyDataGrid.IsKeyboardFocusWithin == false
        //        || _isEscTriggered)
        //        return;

        //    // Trigger a ObjSelectionChangedEvent event
        //    // 
        //    //FindDetail();
        //}
        //public ProgressBarWindow ProgressBarWindow
        //{
        //    get { return _pbw; }
        //}
        //public IView GetView(string mapID)
        //{
        //    return _views.Find(i => i.eMap.MapID == mapID);
        //}
        void Manager_Loaded(object sender, RoutedEventArgs e)
        {
            //bool fileExist = File.Exists(_configFile);

            //if (fileExist)
            //{
            //    //Be careful with the XmlLayoutSerizlizer.Deserialize(DockingManager),
            //    // the children inside it will be reconstructed.
            //    // The original children will be disregarded.
            //    // If a name is put on a child, the child will not work properly any more.
            //    // You must search inside the reconstructed DockingManager to find the proper one.
            //    // Call FindLayoutContentByID() to find the LayoutContent.
            //    //--------------------------------------------
            //    //DockingManager manager = sender as DockingManager;
            //    //XmlLayoutSerializer instance =
            //    //    new XmlLayoutSerializer(manager);
            //    //instance.Deserialize(_configFile);

            //    //// Because LayoutDocument are regenerated,
            //    //// we need to re-attach the Closed() method to each LayoutDocument.
            //    //foreach (IView view in _views)
            //    //{
            //    //    LayoutContent content = FindLayoutContentByID(view.eMap.MapID);
            //    //    LayoutDocument layoutDoc = content as LayoutDocument;
            //    //    if (layoutDoc != null)
            //    //        layoutDoc.Closed += LayoutDoc_Closed;
            //    //}
            //}

        }
        void MainFrame_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        //


        void Manager_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        //public void ShowProgressWindow(string message)
        //{
        //    _pbw = new ProgressBarWindow();
        //    _pbw.Message.Text = message;
        //    _pbw.Owner = _app.MainWindow;
        //    _pbw.ShowDialog();
        //}

        //public void HideProgressWindow()
        //{
        //    _pbw.Close();
        //}
        bool _isEscTriggered = false;
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (_prj != null)
                {
                    foreach (IView view in views.Where(x => x.baseType == ViewBaseType.D2))
                    {
                        IView2D view2D = view as IView2D;
                        if (view2D.layers != null)
                        {
                            foreach (var layer in view2D.layers)
                                layer.highlightAll(false);
                        }
                    }
                }
            }
            else if (e.Key == Key.Delete)
            {
                //RemoveDrawingObjects();
            }
            else if (e.Key == Key.N &&
                System.Windows.Input.Keyboard.Modifiers == ModifierKeys.Control)
            {
                // Ctrl+N
            }
            base.OnKeyUp(e);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //Application app = App.Current;
            //IS3MainWindow mw = app.MainWindow as IS3MainWindow;
            //mw.SwitchToProjectListPage();
        }

        public void Close()
        {
            foreach (var view in _views)
            {
                view.onClose();
            }
        }

        #endregion
        public bool map3DState = false;
        private void ViewHolder_SelectionChanged(object sender, RadSelectionChangedEventArgs e)
        {
            if (((sender as RadPaneGroup).SelectedItem as RadDocumentPane) == null)
                return;
            if (((sender as RadPaneGroup).SelectedItem as RadDocumentPane).Name == "Map3D")
            {
                if ((temp2 != null) && (my3dView != null))
                {
                    if (!map3DState)
                    {
                        temp.Child = null;
                        temp2.Content = my3dView;
                        map3DState = true;
                    }
                }
            }
            else
            {
                if ((temp != null) && (my3dView != null))
                {
                    if (map3DState)
                    {
                        temp2.Content = null;
                        temp.Child = my3dView;
                        map3DState = false;
                    }

                }
            }
            if (((sender as RadPaneGroup).SelectedItem as RadDocumentPane).Name == "右幅剖面图")
            {
                Domain _constructionDoamin2 = _prj.getDomain("Construction");
                DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                if (_lastDGObjects == null)
                    _lastDGObjects = _gprfDGObjects2;
                ComonObjsViewHolder.viewholderindex = 0;
                DGObjectsSelectionChangedListener(this, new DGObjectsSelectionChangedEvent() { newObjs = _lastDGObjects });
            }
            if (((sender as RadPaneGroup).SelectedItem as RadDocumentPane).Name == "左幅剖面图")
            {
                Domain _constructionDoamin2 = _prj.getDomain("Construction");
                DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                if (_lastDGObjects == null)
                    _lastDGObjects = _gprfDGObjects2;
                ComonObjsViewHolder.viewholderindex = 1;
                DGObjectsSelectionChangedListener(this, new DGObjectsSelectionChangedEvent() { newObjs = _lastDGObjects });
            }
        }
    }

}
