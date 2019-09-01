using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Markup;
using System.Diagnostics;

using System.Reflection;

using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Symbology;

using iS3.Core;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Controls;
using System.Data.SqlClient;
using System.Xml.Linq;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Client.Controls;
using iS3.Core.Client.Service;
using System.Threading;

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

    public partial class ProjectListPageForZHGL : UserControl, IProjectList
    {
        public ProjectListPageForZHGL()
        {
            InitializeComponent();

            ProjectTitle.Text = "";

            //初始化地图内容
            initMap();

            //初始化图标
            InitializePictureMarkerSymbol();

            //初始化右键菜单
            initialContextMenu();
            AddContextMenu();
        }
        #region IProjectList 接口
        public event EventHandler<Project> ProjectViewTriggle;
        public ProjectList myProjectList { get; set; }
        #endregion
        #region 右键菜单
        Graphic _selectGraphic;
        ContextMenu aMenu;
        void initialContextMenu()
        {
            aMenu = new ContextMenu();
            MenuItem ViewMenu = new MenuItem();
            ViewMenu.Header = "进入项目";
            ViewMenu.Click += ViewMenu_Click;
            aMenu.Items.Add(ViewMenu);
        }
        void AddContextMenu()
        {
            MyMapView.ContextMenu = aMenu;
        }
        void RemoveContextMenu()
        {
            MyMapView.ContextMenu = null;
        }
        FileDownLoadWin fileDownLoadWin;

        async void DoLoadTask()
        {
            ProgressTips progress_window = new ProgressTips();
            progress_window.Show();
            await Task.Run(() =>
            {
                //progress_window.Show();
                progress_window.btnProcess_Click();
            });
        }

        //右键项目，进入项目详情页
        private void ViewMenu_Click(object sender, RoutedEventArgs e)
        {
            string _projectID = _selectGraphic.Attributes["ID"] as string;
            {
                DoLoadTask();
                ProjectViewTriggle(this, new Project() { projectID = _projectID, });

            }
            
        }
        public void ProjectViewListener(object sender, Project project)
        {
            fileDownLoadWin.Dispatcher.Invoke(new Action(() => { fileDownLoadWin.Close(); }));
            if (ProjectViewTriggle != null)
            {
                ProjectViewTriggle(this, project);
            }
        }
        public List<string> fileList = new List<string>();


        #endregion
        #region GIS Map Operation

        //平常状态图标
        PictureMarkerSymbol _MarkerSymbol_Normal;
        //选中状态图标
        PictureMarkerSymbol _MarkerSymbol_Select;
        private SpatialReference _srEMap;
        private bool _isHitTesting;
        //初始化地图事件
        void initMap()
        {
            _srEMap = Map.SpatialReference;

            MyMapView.Loaded += MyMapView_Loaded;
            MyMapView.MouseMove += MyMapView_MouseMove;
            MyMapView.MouseLeftButtonDown += MyMapView_MouseLeftButtonDown;
            MyMapView.MouseRightButtonDown += MyMapView_MouseRightButtonDown;
            MyMapView.NavigationCompleted += MyMapView_NavigationCompleted;
            MyMapView.ExtentChanged += MyMapView_ExtentChanged;
            _isHitTesting = true;
        }
        //初始化地图图标
        private async void InitializePictureMarkerSymbol()
        {
            _MarkerSymbol_Normal = LayoutRoot.Resources["DefaultMarkerSymbol"]
                as PictureMarkerSymbol;
            _MarkerSymbol_Select = LayoutRoot.Resources["DefaultMarkerSymbol2"]
                as PictureMarkerSymbol;
            try
            {
                await _MarkerSymbol_Normal.SetSourceAsync(
                new Uri("pack://application:,,,/iS3.Client.Controls;component/Images/pin_red.png"));
                await _MarkerSymbol_Select.SetSourceAsync(
                    new Uri("pack://application:,,,/iS3.Client.Controls;component/Images/pin_red.png"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        async void MyMapView_Loaded(object sender, RoutedEventArgs e)
        {
            if (myProjectList == null)
            {
                await LoadProjectList();
            }
        }
        List<ProjectList> projectLists;
        public async Task LoadProjectList()
        {
            List<ProjectList> _projectLists;
            _projectLists = await CommonRepo.GetProjectList();
            projectLists = new List<ProjectList>();
            projectLists.Add(_projectLists.Find(x => x.CODE.Equals("YN")));
            projectBox.ItemsSource = projectLists;
            gLayer = Map.Layers["ProjectGraphicsLayer"] as GraphicsLayer;
            gLayer.Graphics.Clear();
            AddProjectsToMap(gLayer);
        }
        private void AddProjectsToMap(GraphicsLayer gLayer)
        {
            foreach (ProjectList loc in projectLists)
            {
                Graphic g = new Graphic()
                {
                    Geometry = new MapPoint(double.Parse(loc.X.ToString()), double.Parse(loc.Y.ToString())),
                    Symbol = _MarkerSymbol_Normal,
                };
                g.Attributes["ID"] = loc.CODE;
                g.Attributes["ProjectName"] = loc.ProjectTitle;

                gLayer.Graphics.Add(g);
            }
        }
        GraphicsLayer gLayer;

        public void setCoord(MapPoint mapPoint)
        {
            string format = "X = {0}, Y = {1}";
            string coord = string.Format(format,
                Math.Round(mapPoint.X, 2), Math.Round(mapPoint.Y, 2));
            MapCoordsTB.Text = coord;
        }
        MapPoint screenPoint2MapPoint(Point screenPoint)
        {
            MapPoint mapPoint = MyMapView.ScreenToLocation(screenPoint);
            if (mapPoint == null)
                return null;
            if (MyMapView.WrapAround)
                mapPoint = GeometryEngine.NormalizeCentralMeridian(mapPoint) as MapPoint;
            if (_srEMap != null)
            {
                // transform the map point to user defined spatial reference coordinate system
                Esri.ArcGISRuntime.Geometry.Geometry g = GeometryEngine.Project(mapPoint, _srEMap);
                mapPoint = g as MapPoint;
            }
            return mapPoint;
        }
        private void projectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string selectID = myProjectList.Locations[projectBox.SelectedIndex].ID;
            //foreach (Graphic g in gLayer.Graphics)
            //{
            //    if (g.Attributes["ID"].ToString() == selectID)
            //    {
            //        g.Symbol = _MarkerSymbol_Select;
            //    }
            //    else
            //    {
            //        g.Symbol = _MarkerSymbol_Normal;
            //    }
            //}

        }
        #endregion
        #region  GIS 事件

        void MyMapView_NavigationCompleted(object sender, EventArgs e)
        {
            MyMapView.NavigationCompleted -= MyMapView_NavigationCompleted;
            _isHitTesting = false;
        }

        async void MyMapView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isHitTesting)
                return;

            try
            {

                _isHitTesting = true;

                Point screenPoint = e.GetPosition(MyMapView);

                //设置鼠标当前坐标
                MapPoint mapPoint = screenPoint2MapPoint(screenPoint);
                if (mapPoint == null)
                    return;
                setCoord(mapPoint);


                Graphic graphic = await ProjectGraphicsLayer.HitTestAsync(MyMapView, screenPoint);
                if (graphic != null)
                {
                    mapTip.DataContext = graphic;
                    mapTip.Visibility = System.Windows.Visibility.Visible;
                    ProjectTitle.Text = (string)graphic.Attributes["ID"];
                }
                else
                {
                    mapTip.Visibility = System.Windows.Visibility.Collapsed;
                    ProjectTitle.Text = "";
                }
            }
            catch
            {
                mapTip.Visibility = System.Windows.Visibility.Collapsed;
                ProjectTitle.Text = "";

            }
            finally
            {
                _isHitTesting = false;
            }
        }
        async void MyMapView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                RemoveContextMenu();
                //MyMapView.ContextMenu.Visibility = Visibility.Collapsed;

                _isHitTesting = true;

                Point screenPoint = e.GetPosition(MyMapView);
                Graphic graphic = await ProjectGraphicsLayer.HitTestAsync(MyMapView, screenPoint);
                if (graphic != null)
                {
                    _selectGraphic = graphic;
                    AddContextMenu();
                }
            }
            catch
            {
            }
            finally
            {
                _isHitTesting = false;
            }

        }

        async void MyMapView_ExtentChanged(object sender, EventArgs e)
        {
            try
            {
                double temp = MyMapView.Extent.XMax;
            }
            catch
            {
            }
            finally
            {
                _isHitTesting = false;
            }

        }

        async void MyMapView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AddContextMenu();
                // MyMapView.ContextMenu.Visibility = Visibility.Collapsed;

                _isHitTesting = true;

                Point screenPoint = e.GetPosition(MyMapView);
                Graphic graphic = await ProjectGraphicsLayer.HitTestAsync(MyMapView, screenPoint);
                if (graphic != null)
                {
                    _selectGraphic = graphic;
                    foreach (Graphic g in gLayer.Graphics)
                    {
                        g.Symbol = _MarkerSymbol_Normal;
                    }
                    _selectGraphic.Symbol = _MarkerSymbol_Select;
                    //for (int i = 0; i < myProjectList.Locations.Count; i++)
                    //{
                    //    if (myProjectList.Locations[i].ID.ToString() == graphic.Attributes["ID"].ToString())
                    //    {
                    //        projectBox.SelectedIndex = i;
                    //        break;
                    //    }
                    //}
                }
            }
            catch
            {
            }
            finally
            {
                _isHitTesting = false;
            }
        }
        #endregion
    }
}
