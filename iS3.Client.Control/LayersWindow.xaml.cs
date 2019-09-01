using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using iS3.Core.Model;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Esri.ArcGISRuntime.Layers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace iS3.Client.Controls
{
    public class LayerItem
    {

        public ThemeLayer themelayer { get; set; }

        public ThemeSection themesection { get; set; }
        public CheckBox checkbox { get; set; }
        public List<LayerItem> childs { get; set; }
        public LayerItem parent { get; set; }

        public LayerItem()
        {
            childs = new List<LayerItem>();
        }
    }
    public class LayerCheckBoxClickArgs : EventArgs
    {
        public LayerItem Item { get; set; }
    }
    public partial class LayersWindow : Window
    {
        public List<LayerItem> layeritems;

        public event EventHandler<LayerCheckBoxClickArgs> OnLayerCheckBoxClick;

        public event EventHandler<LayerCheckBoxClickArgs> OffLayerCheckBoxClick;
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = true;
            this.Hide();
        }
        public LayersWindow(ThemeView themeview, LayerCollection layers)
        {
            InitializeComponent();

            //Initialize the checkboxs based on themesections and themelayers
            layeritems = new List<LayerItem>();
            foreach (ThemeSection themsection in themeview.themesections)
            {
                CheckBox _themebox = themecheckbox(themsection.name);
                this.addCheckbox.Children.Add(_themebox);
                LayerItem _themelayeritem = new LayerItem();
                _themelayeritem.checkbox = _themebox;

                _themelayeritem.themesection = themsection;
                layeritems.Add(_themelayeritem);

                //增加有tpk对应的复选框
                foreach (ThemeLayer themelayer in themsection.themelayers)
                {
                    string st = themelayer.tpkname;
                    if (st.Contains("无tpk"))
                        st = st.Split('-')[0];
                    CheckBox _layerbox = layerbox(st);
                    this.addCheckbox.Children.Add(_layerbox);
                    LayerItem _layeritem = new LayerItem();
                    _layeritem.checkbox = _layerbox;

                    _layeritem.themelayer = themelayer;
                    _layeritem.parent = _themelayeritem;
                    layeritems.Add(_layeritem);
                    _themelayeritem.childs.Add(_layeritem);
                }

            }

         
        }

        public void checkedthemebox(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            LayerItem _layeritem = layeritems.FirstOrDefault(x => x.checkbox == checkBox);
            LayerCheckBoxClickArgs args = new LayerCheckBoxClickArgs();
            args.Item = _layeritem;
            if (OnLayerCheckBoxClick != null)
                OnLayerCheckBoxClick(this, args);

            foreach (LayerItem lt in _layeritem.childs)
            {
                lt.checkbox.IsChecked = true;
            }

        }
        public void uncheckedthemebox(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)(sender);
            LayerItem _layeritem = layeritems.FirstOrDefault(x => x.checkbox == checkBox);
            LayerCheckBoxClickArgs args = new LayerCheckBoxClickArgs();
            args.Item = _layeritem;
            if (OffLayerCheckBoxClick != null)
                OffLayerCheckBoxClick(this, args);

            foreach (LayerItem lt in _layeritem.childs)
            {   
                lt.checkbox.IsChecked = false;
            }

        }

        public void checkedlayerbox(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            LayerItem _layeritem = layeritems.FirstOrDefault(x => x.checkbox == checkBox);
            LayerCheckBoxClickArgs args = new LayerCheckBoxClickArgs();
            args.Item = _layeritem;
            if (OnLayerCheckBoxClick != null)
                OnLayerCheckBoxClick(this, args);

            _layeritem.parent.checkbox.Checked -= checkedthemebox;
            _layeritem.parent.checkbox.IsChecked = true;
            args.Item = layeritems.FirstOrDefault(x => x.checkbox == _layeritem.parent.checkbox);
            if (OnLayerCheckBoxClick != null)
                OnLayerCheckBoxClick(this, args);
            _layeritem.parent.checkbox.Checked += checkedthemebox;

        }
        public void uncheckedlayerbox(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)(sender);
            LayerItem _layeritem = layeritems.FirstOrDefault(x => x.checkbox == checkBox);
            LayerCheckBoxClickArgs args = new LayerCheckBoxClickArgs();
            args.Item = _layeritem;
            if (OffLayerCheckBoxClick != null)
                OffLayerCheckBoxClick(this, args);


            if (_layeritem.parent.childs.FirstOrDefault(x => x.checkbox.IsChecked == true) == null)
            {
                _layeritem.parent.checkbox.IsChecked = false;
            }

        }

        public CheckBox themecheckbox(string name)
        {
            CheckBox rootbox = new CheckBox();
            rootbox.Content = name;
            Thickness thick = new Thickness(5, 0, 5, 0);
            rootbox.Margin = thick;

            //  rootbox.Checked += new RoutedEventHandler(checkedthemebox);
            //  rootbox.Unchecked += new RoutedEventHandler(uncheckedthemebox);
            rootbox.Checked += checkedthemebox;
            rootbox.Unchecked += uncheckedthemebox;
            return rootbox;
        }
        public CheckBox layerbox(string name)
        {
            CheckBox normalbox = new CheckBox();
            normalbox.Content = name;
            Thickness thick = new Thickness(20, 0, 0, 0);
            normalbox.Margin = thick;
            normalbox.Checked += checkedlayerbox;
            normalbox.Unchecked += uncheckedlayerbox;
            return normalbox;
        }


    }
}
