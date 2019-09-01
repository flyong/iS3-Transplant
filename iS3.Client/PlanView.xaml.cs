﻿using System;
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
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Client.Controls;

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
    /// Interaction logic for PlanView.xaml
    /// </summary>
    public partial class PlanView : UserControl, IViewHolder
    {
        //protected MainFrame _mainFrame;
        protected IS3View2D _view;
        protected LayersWindow _layersWindow;
        public void setruler(List<string> m1, List<string> m2, List<string> sc, string rulername)
        {

        }
        public void setruler(double x, double y)
        {

        }
        public void settitle(string st)
        {

        }
        public void setCoord(string coord)
        {
            MapCoordsTB.Text = coord;
        }

        public IView view
        {
            get { return _view; }
        }

        public PlanView(Project prj, EngineeringMap eMap)
        {
            InitializeComponent();
            _view = new IS3View2D(this, MyMapView);
            _view.prj = prj;
            _view.eMap = eMap;
            MyProgressBar.DataContext = _view;

            GotFocus += PlanView_GotFocus;
            //MyDrawToolControl.drawToolClickEventHandler += _view.drawToolsClickEventListener;
            //MyDrawToolControl.drawToolClickEventHandler += (o, e) =>
            //{
            //    if (e.stopDraw)
            //        DrawStrip.Visibility = Visibility.Collapsed;
            //};
        }

        void PlanView_GotFocus(object sender, RoutedEventArgs e)
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
            
          
          //  _layersWindow = new LayersWindow(_view.PlanThemeDict,_view.map.Layers);

            _layersWindow.Title = _view.eMap.MapID + ":Layers";

            
            _layersWindow.Closed += (o, args) =>
            {
                _layersWindow = null;
            };
           

            //_layersWindow.Show();
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            //if (DrawStrip.Visibility == Visibility.Visible)
            //    DrawStrip.Visibility = Visibility.Collapsed;
            //else if (DrawStrip.Visibility == Visibility.Collapsed)
            //    DrawStrip.Visibility = Visibility.Visible;
        }

        private void RotateButton_Click(object sender, RoutedEventArgs e)
        {
            if (mapRotationControl.Visibility == Visibility.Visible)
                mapRotationControl.Visibility = Visibility.Collapsed;
            else if (mapRotationControl.Visibility == Visibility.Collapsed)
                mapRotationControl.Visibility = Visibility.Visible;
        }

        private void rotationSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            MyMapView.SetRotation(e.NewValue);
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

        }
        public virtual void removeLegend(string labelName)
        {

        }

        public virtual void clearLegend()
        {

        }

        public void setlegend(iS3Legned legend)
        {
            
        }
        #endregion
    }
}
