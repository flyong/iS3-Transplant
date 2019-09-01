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
using System.Data;

using iS3.Core;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Core.Client.ViewModel;
using System.Reflection;
using System.Collections;

namespace iS3.Client.Controls
{
    /// <summary>
    /// Interaction logic for ObjectView.xaml
    /// </summary>

    public enum ObjectViewType { ChartView, TableView, TextView };

    public partial class ObjectView : UserControl, IViewHolder
    {
        Dictionary<string, IEnumerable<DGObject>> _saved;
        TabControl _tabControlSaved;

        protected IView _view;
        public EventHandler<ObjSelectionChangedEvent> objSelectionChangedTrigger;
        public DGObjects _objs;

        public IView view { get { return _view; } }
        public void settitle(string st)
        {

        }
        public void setruler(List<string> m1, List<string> m2, List<string> sc, string rulername)
        {

        }
        public void setruler(double x, double y)
        {

        }
        public iS3Legned legend { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ObjectView()
        {
            InitializeComponent();

            //_view = new IS3ViewNormal(this);
            //_view.DGObjectsSelectionChangedTriggerInner += DGObjectsSelectionChangedListener;
            //objSelectionChangedTrigger += view.objSelectionChangedListenerInner;
            //view.objSelectionChangedTriggerInner += objSelectionChangedListener;

            setViewType(ObjectViewType.ChartView);

            SizeChanged += ObjectView_SizeChanged;
        }

        private void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {

        }

        void ObjectView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_saved != null)
                refreshChartViewAsync(_saved);
        }
        // see IS3DataGrid for more details
        private void DGObjectDataGrid_AutoGeneratingColumn(object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Graphics" ||
                e.PropertyName == "Attributes" ||
                e.PropertyName == "IsSelected" ||
                e.PropertyName == "OBJECTID" ||
                e.PropertyName == "SHAPE" ||
                e.PropertyName == "Shape" ||
                e.PropertyName == "SHAPE_Length" ||
                e.PropertyName == "Shape_Length" ||
                e.PropertyName == "SHAPE_Area" ||
                e.PropertyName == "Shape_Area"
                )
            {
                e.Cancel = true;
                return;
            }
            else
            {
                DGObjectMeta _meta = _objs.definition.Metas.FirstOrDefault(x => x.PropertyName == e.PropertyName);
                string _name = null;
                if (null != _meta)
                    _name = _meta.ChsName;
                if (null != _name)
                    e.Column.Header = _name;
                else
                    e.Cancel = true;

                return;
            }
        }

        public void setViewType(ObjectViewType type)
        {
            if (type == ObjectViewType.ChartView)
            {
                chartViewGrid.Visibility = System.Windows.Visibility.Visible;
                tableViewGrid.Visibility = System.Windows.Visibility.Collapsed;
                textViewGrid.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (type == ObjectViewType.TableView)
            {
                chartViewGrid.Visibility = System.Windows.Visibility.Collapsed;
                tableViewGrid.Visibility = System.Windows.Visibility.Visible;
                textViewGrid.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (type == ObjectViewType.TextView)
            {
                chartViewGrid.Visibility = System.Windows.Visibility.Collapsed;
                tableViewGrid.Visibility = System.Windows.Visibility.Collapsed;
                textViewGrid.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void chartViewButton_Click(object sender, RoutedEventArgs e)
        {
            setViewType(ObjectViewType.ChartView);
        }
        private void tableViewButton_Click(object sender, RoutedEventArgs e)
        {
            setViewType(ObjectViewType.TableView);
        }
        private void textViewButton_Click(object sender, RoutedEventArgs e)
        {
            setViewType(ObjectViewType.TextView);
        }
        private void largeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (_saved == null || _saved.Count != 1)
                return;
            IEnumerable<DGObject> objs = _saved.Values.First();
            string names = string.Empty;
            DGObject firstObj = objs.First();
            foreach (DGObject obj in objs)
                names += obj.name + ",";

            Window window = new Window();
            window.Width = SystemParameters.PrimaryScreenWidth / 2;
            window.Height = SystemParameters.PrimaryScreenHeight / 2;
            //window.Owner = App.Current.MainWindow;
            window.WindowState = WindowState.Maximized;
            window.Title = "Monitoring data chart: " + names;
            window.SizeChanged += async (o, args) =>
            {
                //List<FrameworkElement> chartViews = await firstObj.chartViews(objs,
                //    window.ActualWidth, window.ActualHeight - 40.0);

                //TabControl tabControl = new TabControl();
                //foreach (var chart in chartViews)
                //{
                //    TabItem item = new TabItem();
                //    item.Header = chart.Name;
                //    tabControl.Items.Add(item);
                //    item.Content = chart;
                //}

                //if (_tabControlSaved == null)
                //    tabControl.SelectedIndex = chartViewHolder.SelectedIndex;
                //else
                //    tabControl.SelectedIndex = _tabControlSaved.SelectedIndex;
                //_tabControlSaved = tabControl;  // save it to temporary var

                //Grid grid = new Grid();
                //grid.Children.Add(tabControl);
                //window.Content = grid;
            };
            window.Show();
        }
        public async Task GetDetailObj(ObjSelectionChangedEvent e)
        {
            try
            {
                Dictionary<string, IEnumerable<DGObject>> selectedObjsDict = new Dictionary<string, IEnumerable<DGObject>>();
                // process added objs
                if (e.addObjs != null)
                {
                    foreach (string key in e.addObjs.Keys)
                    {
                        IEnumerable<DGObject> objs = e.addObjs[key];
                        List<DGObject> objlist = objs.ToList();
                        DGObjects dGObjects = Globals.project.objsDefIndex[key];

                        List<DGObject> detailObjList = new List<DGObject>();
                        foreach (DGObject _obj in objlist)
                        {
                            DGObject obj = await RepositoryForClient.RetrieveObj(_obj); 
                            detailObjList.Add(obj);
                        }
                        selectedObjsDict[key] = detailObjList.AsEnumerable();
                    }
                }
                _saved = selectedObjsDict;

                refreshTextView(selectedObjsDict);
                refreshTableView(selectedObjsDict);
                refreshChartViewAsync(selectedObjsDict);
                // //------------------------
            }
            catch (Exception ex)
            {

            }


        }
        // Summary:
        //     Object selection event listener.
        public void objSelectionChangedListener(object sender,
            ObjSelectionChangedEvent e)
        {
            // // get current selected objects
            // //----------------------------
            GetDetailObj(e);
        }

        void refreshTextView(
            Dictionary<string, IEnumerable<DGObject>> selectedObjsDict)
        {
            try
            {
                textViewHolder.Children.Clear();

                TextBlock text = new TextBlock();
                text.Text = "Object selections:";
                text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                textViewHolder.Children.Add(text);

                foreach (string key in selectedObjsDict.Keys)
                {
                    TextBlock block = new TextBlock();
                    block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    block.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    block.Text = string.Format(" Layer {0}: {1} selected.", key,
                        selectedObjsDict[key].Count());
                    textViewHolder.Children.Add(block);
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        void refreshTableView(
            Dictionary<string, IEnumerable<DGObject>> selectedObjsDict)
        {
            try
            {
                // If more than 1 type objects are selected, can't display it.
                if (selectedObjsDict.Count != 1)
                {
                    tableViewNA.Visibility = System.Windows.Visibility.Visible;
                    tableView.Visibility = System.Windows.Visibility.Collapsed;
                    if (selectedObjsDict.Count == 0)
                        tableViewNA.Text = "No object selected.";
                    else
                        tableViewNA.Text = "N.A. for current selections.";
                    return;
                }

                // If no object are selected, just return.
                IEnumerable<DGObject> objs = selectedObjsDict.Values.First();
                if (objs.Count() == 0)
                {
                    tableViewNA.Visibility = System.Windows.Visibility.Visible;
                    tableView.Visibility = System.Windows.Visibility.Collapsed;
                    tableViewNA.Text = "No object selected.";
                    return;
                }
                tableViewNA.Text = "No Chart View For Selected Obj!";
                // We can display the selected objects in datagrids
                tableViewNA.Visibility = System.Windows.Visibility.Collapsed;
                tableView.Visibility = System.Windows.Visibility.Visible;

                DGObjects dGObjects = objs.FirstOrDefault().parent;
                _objs = dGObjects;
                string domain = dGObjects.parent.name;
                string objtype = dGObjects.definition.Type;

                //获取对应属性数据
                iS3Property property = new iS3Property();
                Type objType = iS3Property.GetType(dGObjects.parent.name, dGObjects.definition.Type);
                Type _t = property.GetType();
                MethodInfo mi = _t.GetMethod("Convert").MakeGenericMethod(objType);
                tableView.ItemsSource = mi.Invoke(property, new object[] { objs }) as IEnumerable;
            }
            catch (Exception ex)
            {

            }
        }

        async Task refreshChartViewAsync(
            Dictionary<string, IEnumerable<DGObject>> selectedObjsDict)
        {
            try
            {
                Globals.application.Dispatcher.Invoke((Action)(() =>
                {
                    // If more than 1 type objects are selected, can't display it.
                    if (selectedObjsDict.Count != 1)
                    {
                        chartViewNA.Visibility = System.Windows.Visibility.Visible;
                        chartViewHolder.Visibility = System.Windows.Visibility.Collapsed;
                        if (selectedObjsDict.Count == 0)
                            chartViewNA.Text = "No object selected.";
                        else
                            chartViewNA.Text = "N.A. for current selections.";
                        return;
                    }

                    // If no object are selected, just return.
                    IEnumerable<DGObject> objs = selectedObjsDict.Values.First();
                    if (objs.Count() == 0)
                    {
                        chartViewNA.Visibility = System.Windows.Visibility.Visible;
                        chartViewHolder.Visibility = System.Windows.Visibility.Collapsed;
                        chartViewNA.Text = "No object selected.";
                        return;
                    }

                    // if no enough space then return
                    if (objectViewGrid.ActualWidth < 10 ||
                        objectViewGrid.ActualHeight < 60)
                        return;

                    DGObject obj = objs.First();
                    //
                    Extensions extensions = DllImport.domainExtension[obj.parent.parent.name];
                    DGObjectViewConfig dw = extensions.treeItems().Where(x => x.objType == obj.parent.definition.Type).FirstOrDefault();
                    
                    if (dw == null)
                    {
                        return;
                    }
                    IDGObjectView view = dw.func();
                    if (view == null)
                    {
                        chartViewHolder.Visibility = System.Windows.Visibility.Collapsed;
                        return;
                    }
                    UserControl view_control = view as UserControl;
                    view_control.Height = objectViewGrid.ActualHeight;
                    view_control.Width = objectViewGrid.ActualWidth;
                    view.SetObjContent(obj);

                    int count = chartViewHolder.Children.Count;
                    for (int i=count-1;i>=0; i--)
                    {
                        UIElement child = chartViewHolder.Children[i];
                        if (child!=(view3d as UIElement))
                        {
                            chartViewHolder.Children.Remove(child);
                        }

                    }

                    chartViewHolder.Visibility = System.Windows.Visibility.Visible;

                    EngineeringMap emap = view.SetIt(obj);
                    if (emap == null)
                    {
                        view3d.Visibility = Visibility.Collapsed;
                        chartViewHolder.Children.Add(view as UserControl);
                    }
                    else
                    {
                        view3d.Visibility = Visibility.Visible;
                        view3d.Set(Globals.project, emap);
                        view3d.view.initialzeView();
                    }
                    return;
                }));
            }
            catch (Exception ex)
            {

            }
           
            //
            //List<FrameworkElement> chartViews = await obj.chartViews(objs,
            //    objectViewGrid.ActualWidth, objectViewGrid.ActualHeight - 40.0);
            //if (chartViews == null)
            //{
            //    chartViewNA.Visibility = System.Windows.Visibility.Visible;
            //    chartViewHolder.Visibility = System.Windows.Visibility.Collapsed;
            //    chartViewNA.Text = "Not available for selected object.";
            //    return;
            //}

            //// We can display the selected objects in datagrids
            //chartViewNA.Visibility = System.Windows.Visibility.Collapsed;
            //chartViewHolder.Visibility = System.Windows.Visibility.Visible;
            //int lastSelected = chartViewHolder.SelectedIndex;
            //chartViewHolder.Items.Clear();

            //foreach (var chart in chartViews)
            //{
            //    TabItem item = new TabItem();
            //    item.Header = chart.Name;
            //    chartViewHolder.Items.Add(item);

            //    //ScrollViewer scrollViewer = new ScrollViewer();
            //    //scrollViewer.HorizontalScrollBarVisibility = 
            //    //    ScrollBarVisibility.Auto;
            //    //scrollViewer.VerticalScrollBarVisibility = 
            //    //    ScrollBarVisibility.Auto;

            //    //item.Content = scrollViewer;
            //    //scrollViewer.Content = chart;

            //    item.Content = chart;
            //}

            //// resume last select index if possible
            //if (lastSelected == -1)
            //    chartViewHolder.SelectedIndex = 0;
            //else if (lastSelected < chartViews.Count)
            //    chartViewHolder.SelectedIndex = lastSelected;

            //if (chartViewHolder.SelectedIndex == -1)
            //    chartViewHolder.SelectedIndex = 0;
        }

        public void setCoord(string coord)
        {

        }

        public void setLegendShow(bool state)
        {
            throw new NotImplementedException();
        }

        public void addLegend(iS3Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public void removeLegend(string labelName)
        {
            throw new NotImplementedException();
        }

        public void clearLegend()
        {
            throw new NotImplementedException();
        }

        public void setlegend(iS3Legned legend)
        {
            throw new NotImplementedException();
        }
    }
}
