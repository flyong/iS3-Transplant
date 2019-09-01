using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.Geometry;

using iS3.Core;
using iS3.Client.Controls;
using iS3.Core.Client;
using iS3.Core.Model;
using System.IO;

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
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl, IViewHolder
    {
        protected IS3View2D _view;
        protected LayersWindow _layersWindow;
        public ThemeView profilethemeview;
        public List<string> profilethemelist;
        public string defaulttheme;
        public char partchar;
        public EngineeringMap _emap;


        public Dictionary<string, string> LayerToGeofile;
      
        public Dictionary<string, Ruler> customrulers;
        public void setruler(List<string> m1, List<string> m2, List<string> sc, string rulername)
        {
           
            if (customrulers.ContainsKey(rulername))
            {
                customrulers[rulername].mileage_end = m2;
                customrulers[rulername].mileage_start = m1;
                customrulers[rulername].show_content =sc;
            }

        }
        public void setruler(double x, double y)
        {
            //主标尺系统
            double mainchip = DipHelper.GetRulerMileage(x);

            //显示隧道主洞桩号
            hruler.Chip = mainchip;
            int i = (int)Math.Round(mainchip);
            string st = i.ToString();
            string st1 = st.Substring(0, st.Length - 3);
            if ((st1 == null) || (st1 == ""))
                st1 = "0";
            string st2 = st.Substring(st.Length - 3);
            if (partchar == '左')
                st = "ZK" + st1 + "+" + st2;
            else
                st = "YK" + st1 + "+" + st2;
            MapCoordsZH.Text = "桩号：" + st;
            //显示沿桩衬砌
            mili_ruler.Chip = mainchip;

            //显示高程信息
            double heightchip = DipHelper.GetRulerAltitude(y);
            vruler.Chip = heightchip;
            st = Math.Round(heightchip).ToString();
            MapCoordsGC.Text = "高程：" + st + "米";

            //显示斜井桩号
            int pile = DipHelper.GetRulerXJMileage(Convert.ToInt32(x));
            xjruler.Chip = x;
            string temp;
            if (x < 3250)
                temp = "BX";
            else
                temp = "LX";

            if (pile >= 0)
            {
                st = pile.ToString().PadLeft(4, '0');
                st2 = st.Substring(st.Length - 3);
                st = temp + "K" + st[0] + "+" + st2;
                MapCoordsXJ.Text = "斜井桩号：" + st;
            }
        }
        public void settitle(string st)
        {
            Profile_Header.Text = st;
        }
        public void setCoord(string coord)
        {

            //  MapCoordsXJ.Text = coord;
        }
        public void Themeinit()
        {
            if (partchar == '左')
            {
                defaulttheme = "老营隧道左幅施工进度图";
                profilethemeview = new ThemeView("左幅剖面图");
                profilethemelist = new List<string>() { "老营隧道左幅施工进度图", "老营隧道左幅地质剖面图", "老营隧道左幅衬砌结构图", "老营隧道左幅物探图" };
            }
            else
            {
                defaulttheme = "老营隧道右幅施工进度图";
                profilethemeview = new ThemeView("右幅剖面图");
                profilethemelist = new List<string>() { "老营隧道右幅施工进度图", "老营隧道右幅地质剖面图", "老营隧道右幅衬砌结构图", "老营隧道右幅物探图" };
            }
            LayerToGeofile = new Dictionary<string, string>();
            Loadcsvfile();
        }
        public void Loadcsvfile()
        {
            try
            {
                string exeLocation = System.IO.Directory.GetCurrentDirectory();
                string csvDestnationPath = "c:\\LaoYingData\\theme";

                if (!Directory.Exists(csvDestnationPath))
                    return;
                //第一列是TPK文件，第二列是geodatabse文件，第三列是图层名
                //加载剖面主题图信息
                foreach (string fp in profilethemelist)
                {
                    ThemeSection _themesection = new ThemeSection();
                    _themesection.name = fp;

                    string exeDestnationPath = csvDestnationPath + "\\" + fp + ".csv";
                    StreamReader sr = new StreamReader(exeDestnationPath, Encoding.Default);
                    String line;
                    ThemeLayer themelayer = new ThemeLayer();
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Length == 0) continue;
                        string[] str = line.Split(',');
                        if ((str[0] != null) && (str[0] != ""))
                        {
                            ThemeLayer _themelayer = _themesection.themelayers.FirstOrDefault(x => x.tpkname == str[0]);
                            if (_themelayer == null)
                            {
                                _themelayer = new ThemeLayer();
                                _themelayer.tpkname = str[0];
                                if ((str[2] != null) && (str[2] != ""))
                                    _themelayer.layernames.Add(str[2]);
                                _themesection.themelayers.Add(_themelayer);
                            }
                            else
                            {
                                if ((str[2] != null) && (str[2] != ""))
                                    _themelayer.layernames.Add(str[2]);
                            }
                            if (str[0].Contains("无tpk"))
                                _themesection.layernames.Add(str[2]);
                        }

                        //Add a new relationship between a geofile and a layer
                        if ((str[2] != null) && (str[2] != "") && (str[1] != "") && (null != str[1]))
                        {
                            if (!LayerToGeofile.ContainsKey(str[2]))
                                LayerToGeofile.Add(str[2], str[1]);
                        }


                    }
                    profilethemeview.themesections.Add(_themesection);
                }

            }
            catch (Exception ex)
            {
            }
        }
        public IView view
        {
            get { return _view; }
        }

        public ProfileView(Project prj, EngineeringMap eMap)
        {
            InitializeComponent();

            if (eMap.MapID.Contains('右'))
                partchar = '右';
            else
                partchar = '左';
            Themeinit();
            _view = new IS3ProfileView(this, MyMapView);
            _view.prj = prj;
            _view.eMap = eMap;

            _view.LayerToGeofile = LayerToGeofile;
            MyProgressBar.DataContext = _view;

            GotFocus += ProfileView_GotFocus;
            Globals.mainFrame.viewLoaded += initlayerwindow;
            customrulers = new Dictionary<string, Ruler>();
            initMainruler();
           
            MyMapView.ExtentChanged += MyMapView_ExtentChanged;


          

        }

        void initlayerwindow(object sender, EventArgs e)
        {
            _layersWindow = new LayersWindow(profilethemeview, _view.map.Layers);
            //_layersWindow.Owner = App.Current.MainWindow;
            _layersWindow.Title = _view.eMap.MapID + ":图层";

            // Two ways to use delegate
            //_layersWindow.Closed += delegate { _layersWindow = null; };
            //_layersWindow.Closed += delegate(object o, EventArgs args) { _layersWindow = null; };

            // Use lamda function
            //_layersWindow.Closed += (o, args) =>
            //{
            //    _layersWindow = null;
            //};

            _layersWindow.OffLayerCheckBoxClick += (o, args) =>
            {
                if (args.Item.themelayer != null)
                {
                    ThemeLayer _tl = args.Item.themelayer;
                    foreach (string st in _tl.layernames)
                    {
                        Layer layer = _view.map.Layers.FirstOrDefault(x => x.ID == st);
                        if (layer != null)
                            layer.IsVisible = false;
                    }
                    Layer _layer = _view.map.Layers.FirstOrDefault(x => x.ID == _tl.tpkname + ".tpk");
                    if (_layer != null)
                        _layer.IsVisible = false;
                }
                else if (args.Item.themesection != null)
                {
                    ThemeSection _ts = args.Item.themesection;
                    foreach (string st in _ts.layernames)
                    {
                        Layer layer = _view.map.Layers.FirstOrDefault(x => x.ID == st);
                        if (layer != null)
                            layer.IsVisible = false;
                    }
                }
            };
            _layersWindow.OnLayerCheckBoxClick += (o, args) =>
            {
                if (args.Item.themelayer != null)
                {
                    ThemeLayer _tl = args.Item.themelayer;
                    foreach (string st in _tl.layernames)
                    {
                        Layer layer = _view.map.Layers.FirstOrDefault(x => x.ID == st);
                        if (layer != null)
                            layer.IsVisible = true;
                    }
                    Layer _layer = _view.map.Layers.FirstOrDefault(x => x.ID == _tl.tpkname + ".tpk");
                    if (_layer != null)
                        _layer.IsVisible = true;
                }
            };
            _view._layerswindow = _layersWindow;
            _view.profilethemeview = profilethemeview;
            initshowlayer();

            // Globals.mainFrame.viewLoaded+=initshowlayer;
            Globals.mainFrame.viewLoaded -= initlayerwindow;
        }
        void initshowlayer()
        {
            //Initialize the states of checkboxes      
            List<string> dynamiclayerlist = new List<string>() { "ACHE", "ACHE_EC", "ACHE_YG", "ACHE_ZZM" };
            _view.Opendynamiclayers(dynamiclayerlist, "施工进度");
        }
        Ruler hruler { get; set; }
        Ruler mili_ruler { get; set; }
        
        void initMainruler()
        {
            //隧道里程桩号标尺
            hruler = new Ruler() { Unit = Controls.Unit.Cm, Width = double.NaN, Marks = "Horizontal", Zoom = 1.0D, AutoSize = true };
            Main_ruler.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(hruler, 0);
            Main_ruler.Children.Add(hruler);

            TextBlock _name = new TextBlock();
            _name.Text = "里程\n桩号";
            _name.HorizontalAlignment = HorizontalAlignment.Center;
            _name.TextWrapping = TextWrapping.Wrap;
            Ruler_names.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(_name, 0);
            Ruler_names.Children.Add(_name);
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1.0);
            Grid.SetRow(border, 0);
            Ruler_names.Children.Add(border);


            //设计衬砌类型
            mili_ruler = new Ruler() { Unit = Controls.Unit.Cm, Width = double.NaN, Marks = "MILI", Zoom = 1.0D, AutoSize = true };
            Main_ruler.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(mili_ruler, 1);
            Main_ruler.Children.Add(mili_ruler);
            customrulers["MILI"] = mili_ruler;
            _name = new TextBlock();
            _name.Text = "设计衬砌类型";
            _name.TextWrapping = TextWrapping.Wrap;
            Ruler_names.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(_name, 1);
            Ruler_names.Children.Add(_name);
            border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1.0);
            Grid.SetRow(border, 1);
            Ruler_names.Children.Add(border);

        }

        void ProfileView_GotFocus(object sender, RoutedEventArgs e)
        {
            // _mainFrame.activeView = _view;
        }

        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            _view.panToSelected();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            _view.selectByRect();
        }

        private void LayersButton_Click(object sender, RoutedEventArgs e)
        {
            if (_layersWindow != null)
            {
                _layersWindow.Show();
                return;
            }
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            //if (DrawStrip.Visibility == Visibility.Visible)
            //    DrawStrip.Visibility = Visibility.Collapsed;
            //else if (DrawStrip.Visibility == Visibility.Collapsed)
            //    DrawStrip.Visibility = Visibility.Visible;
        }

        #region  legend
        private iS3Legned legend { get; set; }
        public virtual void setLegendShow(bool state)
        {
            if (state == true)
            {
                Legend.Visibility = Visibility.Visible;
            }
            else
            {
                Legend.Visibility = Visibility.Hidden;
            }
        }

        public virtual void addLegend(iS3Symbol symbol)
        {
            if (legend != null)
            {
                legend.iS3SymbolList.Add(symbol);
            }
            else
            {
                legend = new iS3Legned();
            }
            update();
        }
        public virtual void removeLegend(string labelName)
        {
            if (legend != null)
            {
                foreach (iS3Symbol symbol in legend.iS3SymbolList)
                {
                    if (symbol.label == labelName)
                    {
                        legend.iS3SymbolList.Remove(symbol);
                        break;
                    }
                }
                update();
            }
        }

        public virtual void clearLegend()
        {
            LegendTitle.Text = "图例";
            Container.Children.Clear();
        }
        public void update()
        {
            clearLegend();
            LegendTitle.Text = legend.legndTitle;
            Legend.Height = 30 + 20 + 30 * legend.iS3SymbolList.Count;
            for (int i = 0; i < legend.iS3SymbolList.Count; i++)
            {
                iS3Symbol symbol = legend.iS3SymbolList[i];
                //图形
                DrawRectangle(10, 10 + 30 * i, symbol);
            }
        }

        public void setlegend(iS3Legned _legend)
        {
            legend = _legend;
            clearLegend();
            LegendTitle.Text = legend.legndTitle;
            Legend.Height = 30 + 20 + 30 * legend.iS3SymbolList.Count;
            for (int i = 0; i < legend.iS3SymbolList.Count; i++)
            {
                iS3Symbol symbol = legend.iS3SymbolList[i];
                switch (symbol.symbolType)
                {
                    case SymbolType.Rectangle:
                        DrawRectangle(10, 10 + 30 * i, symbol);
                        break;
                    case SymbolType.Triangle:
                        DrawTriangle(10, 10 + 30 * i, symbol);
                        break;
                    case SymbolType.Circle:
                        DrawCircle(10, 10 + 30 * i, symbol);
                        break;
                    case SymbolType.Icon:
                        DrawIcon(10, 10 + 30 * i, symbol);
                        break;
                    default: break;
                }
            }
        }
        public void DrawIcon(double left, double top, iS3Symbol symbol)
        {
            string imageFilesPath = Directory.GetCurrentDirectory() + "\\images\\" + symbol.refPath;

            Image simpleImage = new Image();
            simpleImage.Width = 15;

            // Create source.
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri(imageFilesPath, UriKind.Absolute);
            bi.EndInit();
            // Set the image source.
            simpleImage.Source = bi;

            Canvas.SetLeft(simpleImage, left);
            Canvas.SetTop(simpleImage, top);
            Container.Children.Add(simpleImage);

            TextBlock textBlock = new TextBlock();

            textBlock.Text = symbol.label;

            textBlock.Foreground = new SolidColorBrush(Colors.Black);

            Canvas.SetLeft(textBlock, left + 30);

            Canvas.SetTop(textBlock, top);

            Container.Children.Add(textBlock);
        }
        public void DrawCircle(double left, double top, iS3Symbol symbol)
        {
            Color fill = (Color)ColorConverter.ConvertFromString(symbol.colorName);
            var myPolygon = new System.Windows.Shapes.Ellipse();
            myPolygon.Width = 15;
            myPolygon.Height = 15;
            myPolygon.Stroke = new SolidColorBrush(Colors.Gray);
            myPolygon.StrokeThickness = 1;
            myPolygon.Fill = new SolidColorBrush(fill);
            Canvas.SetLeft(myPolygon, left);
            Canvas.SetTop(myPolygon, top);
            Container.Children.Add(myPolygon);

            TextBlock textBlock = new TextBlock();

            textBlock.Text = symbol.label;

            textBlock.Foreground = new SolidColorBrush(Colors.Black);

            Canvas.SetLeft(textBlock, left + 30);

            Canvas.SetTop(textBlock, top);

            Container.Children.Add(textBlock);
        }
        public void DrawTriangle(double left, double top, iS3Symbol symbol)
        {
            Color fill = (Color)ColorConverter.ConvertFromString(symbol.colorName);
            var myPolygon = new System.Windows.Shapes.Polygon();
            var p1 = new Point(left + 7.5, top);
            var p2 = new Point(left, top + 15);
            var p3 = new Point(left + 15, top + 15);
            var points = new Point[] { p1, p2, p3 };
            myPolygon.Points = new System.Windows.Media.PointCollection(points);
            myPolygon.Stroke = new SolidColorBrush(Colors.Gray);
            myPolygon.StrokeThickness = 1;
            myPolygon.Fill = new SolidColorBrush(fill);
            Container.Children.Add(myPolygon);

            TextBlock textBlock = new TextBlock();

            textBlock.Text = symbol.label;

            textBlock.Foreground = new SolidColorBrush(Colors.Black);

            Canvas.SetLeft(textBlock, left + 30);

            Canvas.SetTop(textBlock, top);

            Container.Children.Add(textBlock);
        }
        public void DrawRectangle(double left, double top, iS3Symbol symbol)
        {
            Color fill = (Color)ColorConverter.ConvertFromString(symbol.colorName);
            var myPolygon = new System.Windows.Shapes.Polygon();
            var lefttop = new Point(left, top);
            var righttop = new Point(left, top + 15);
            var rightbottom = new Point(left + 15, top + 15);
            var leftbottom = new Point(left + 15, top);
            var points = new Point[] { lefttop, righttop, rightbottom, leftbottom };
            myPolygon.Points = new System.Windows.Media.PointCollection(points);
            myPolygon.Stroke = new SolidColorBrush(Colors.Gray);
            myPolygon.StrokeThickness = 1;
            myPolygon.Fill = new SolidColorBrush(fill);
            Container.Children.Add(myPolygon);

            TextBlock textBlock = new TextBlock();

            textBlock.Text = symbol.label;

            textBlock.Foreground = new SolidColorBrush(Colors.Black);

            Canvas.SetLeft(textBlock, left + 30);

            Canvas.SetTop(textBlock, top);

            Container.Children.Add(textBlock);
        }
        async void MyMapView_ExtentChanged(object sender, EventArgs e)
        {

            Envelope init_extent =
            new Envelope(double.Parse(_view.eMap.XMin.ToString()), double.Parse(_view.eMap.YMin.ToString()), double.Parse(_view.eMap.XMax.ToString()), double.Parse(_view.eMap.YMax.ToString()));

            if (MyMapView.Extent.YMax > Convert.ToDouble(_view.eMap.YMax) + 100)
            {
                MyMapView.SetView(init_extent);
                return;
            }
            if (MyMapView.Extent.XMax > Convert.ToDouble(_view.eMap.XMax) + 50)
            {
                MyMapView.SetView(init_extent);
                return;
            }
            if (MyMapView.Extent.XMin < Convert.ToDouble(_view.eMap.XMin) - 50)
            {
                MyMapView.SetView(init_extent);
                return;
            }
            if (MyMapView.Extent.YMin < Convert.ToDouble(_view.eMap.YMin) - 100)
            {
                MyMapView.SetView(init_extent);
                return;
            }
            //标尺
            rulerextent _initrulerx = new rulerextent() { XMax = MyMapView.Extent.XMax, XMin = MyMapView.Extent.XMin };
            hruler.RulerExtent = _initrulerx;
            xjruler.RulerExtent = _initrulerx;
            mili_ruler.RulerExtent = _initrulerx;
            rulerextent _initrulery = new rulerextent() { XMax = MyMapView.Extent.YMax, XMin = MyMapView.Extent.YMin };
            vruler.RulerExtent = _initrulery;
        }
        #endregion
    }

}
