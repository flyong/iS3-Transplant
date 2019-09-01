using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;

using Esri.ArcGISRuntime.Controls;
using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.LocalServices;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Data;

using iS3.Core;
using iS3.Core.Client.Graphics;
using iS3.Core.Client.Geometry;
using iS3.ArcGIS;
using iS3.ArcGIS.Graphics;
using iS3.ArcGIS.Geometry;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Client.Controls;
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
    public class QueryEntitiesArgs : EventArgs
    {
        // Params for query entities by ID
        public IList<DGObject> objs { get; set; }

        // Params for query entities by Geometry
        public Geometry geometry { get; set; }
        public string condition { get; set; }

        public object userState { get; set; }
    }

    public class IS3View2D : IS3ViewBase, IView2D
    {
        public IViewHolder holder { get; set; }

        string _fileNotExist = "File {0} not exist.";

        protected MapView _mapView;     // The ArcGIS MapView
        protected Map _map;             // The ArcGIS Map
        protected MapTip _mapTip;       // Map tip

        //protected MapLegend _mapLegend;   //Map Legend
        protected LocalFeatureService _localFeatureService;
        // To do: add to user defined vars
        protected int _maxRecords = 5000;

        // Summary:
        //     Layer for drawing graphics, i.e., non-DGObject related graphics.
        // Remarks:
        //     (1) Each view has one drawing layer. The layer is intended for
        //         storing user interative drawing graphics, etc.
        //     (2) Graphics on this layer are not related to any DGObject.
        //         Therefore, graphics on this layer have no corresponding 
        //         graphics in other views.
        //     (3) The ID and DisplayName of the layer is '0'.
        protected IS3GraphicsLayer _drawingLayer;
        public IGraphicsLayer drawingLayer { get { return _drawingLayer; } }

        public Map map { get { return _map; } }
        public MapView mapView { get { return _mapView; } }
        public Dictionary<string, string> LayerToGeofile;
        public LayersWindow _layerswindow;
        public ThemeView profilethemeview;

        //#region  legend
        //public iS3Legned legend { get; set; }
        //public virtual void setLegendShow(bool state)
        //{

        //}

        //public virtual void addLegend(iS3Symbol symbol)
        //{

        //}
        //public virtual void removeLegend(string labelName)
        //{

        //}

        //public virtual void clearLegend()
        //{

        //}
        //#endregion

        // Summary:
        //     Drawing graphics added/removed event trigger (delegate).
        public event EventHandler<DrawingGraphicsChangedEventArgs>
            drawingGraphicsChangedTrigger;

        #region IView interface
        public ViewType type { get { return ViewType.General2DView; } }
        public IEnumerable<IGraphicsLayer> layers
        {
            get
            {
                List<IGraphicsLayer> results = new List<IGraphicsLayer>();
                foreach (var layer in _map.Layers)
                {
                    IGraphicsLayer gLayer = layer as IGraphicsLayer;
                    if (gLayer != null)
                        results.Add(gLayer);
                }
                if (results.Count > 0)
                    return results;
                else
                    return null;
            }
        }
        public void Opendynamiclayers(List<string> layers, string section)
        {

            foreach (ThemeSection themesection in profilethemeview.themesections)
            {
                CheckBox _themebox = _layerswindow.layeritems.FirstOrDefault(x => x.themesection == themesection).checkbox;
                _themebox.IsChecked = true;
                _themebox.IsChecked = false;
            }
            _layerswindow.layeritems.FirstOrDefault(x => (x.themesection != null) && (x.themesection.name.Contains(section))).checkbox.IsChecked = true;
            ThemeSection _initsec = profilethemeview.themesections.FirstOrDefault(x => x.name.Contains(section));
            holder.settitle(_initsec.name);
            foreach (string st in _initsec.layernames)
            {
                CheckBox _box = _layerswindow.layeritems.FirstOrDefault(x => (null != x.themelayer) && (x.themelayer.layernames.Contains(st))).checkbox;
                _box.IsChecked = true;
                _box.IsChecked = false;
            }

            foreach (string st in layers)
            {
                try
                {

                    CheckBox _box = _layerswindow.layeritems.FirstOrDefault(x => (null != x.themelayer) && x.themelayer.layernames.Contains(st)).checkbox;
                    _box.IsChecked = true;
                }
                catch (Exception ex)
                {
                   
                }
            }
        }
        public async Task initializeView()
        {
            await loadPredefinedLayers();
            if (eMap.MapType == EngineeringMapType.FootPrintMap)
            {

            }
            if (eMap.MapType == EngineeringMapType.GeneralProfileMap)
            {

            }
        }
        public void onClose() { }

        public void highlightObject(DGObject obj, bool on = true)
        {
            if (obj == null || obj.parent == null)
                return;
            string layerID = obj.parent.definition.GISLayerName;
            IGraphicsLayer gLayer = _map.Layers[layerID] as IGraphicsLayer;
            if (gLayer == null)
                return;
            gLayer.highlightObject(obj, on);
        }
        public void highlightObjects(IEnumerable<DGObject> objs,
            bool on = true)
        {
            if (objs == null)
                return;
            foreach (DGObject obj in objs)
                highlightObject(obj, on);
        }
        public void highlightObjects(IEnumerable<DGObject> objs,
            string layerID, bool on = true)
        {
            if (objs == null)
                return;
            IGraphicsLayer gLayer = _map.Layers[layerID] as IGraphicsLayer;
            if (gLayer == null)
                return;
            gLayer.highlightObject(objs, on);
        }
        public void highlightAll(bool on = true)
        {
            foreach (Layer layer in _map.Layers)
            {
                IGraphicsLayer gLayer = layer as IGraphicsLayer;
                if (gLayer == null)
                    continue;
                gLayer.highlightAll(on);
            }
        }

        public void zoomTo(IGeometry geom)
        {
            _mapView.SetView(geom as Geometry);
        }

        public void addLayer(IGraphicsLayer layer)
        {
            _map.Layers.Add(layer as IS3GraphicsLayer);
        }
        public IGraphicsLayer getLayer(string layerID)
        {
            IS3GraphicsLayer layer = _map.Layers[layerID] as IS3GraphicsLayer;
            return layer;
        }
        public IGraphicsLayer removeLayer(string layerID)
        {
            IS3GraphicsLayer layer = _map.Layers[layerID] as IS3GraphicsLayer;
            _map.Layers.Remove(layer);
            return layer;
        }

        public int syncObjects()
        {
            if (_prj == null)
                return 0;

            int count = 0;

            foreach (Layer layer in _map.Layers)
            {
                List<DGObjects> objsList = _prj.Get2dRelatedObjs(layer.ID);
                if ((objsList == null) || (objsList.Count == 0)) continue;
                IGraphicsLayer myLayer = layer as IGraphicsLayer;
                if (myLayer == null) continue;
                foreach (DGObjects objs in objsList)
                {
                    count += myLayer.syncObjects(objs);
                }
            }
            return count;
        }
        public int syncObjects(string layerID, List<DGObject> objs)
        {
            if (_prj == null)
                return 0;
            int count = 0;
            if (_map.Layers[layerID] != null)
            {
                IGraphicsLayer layer = _map.Layers[layerID] as IGraphicsLayer;
                if (layer != null)
                {
                    count += layer.syncObjects(objs);
                }
            }

            return count;
        }
        #endregion

        // Spatial Reference of EMap:
        //   set to the spatial reference of the first geodatabase feature table
        //
        protected SpatialReference _srEMap;
        // a deep copy of _srEMap, with ISpatialReference interface
        protected IS3SpatialReference _is3_srEMap;
        public ISpatialReference spatialReference
        {
            get
            {
                if (_is3_srEMap != null)
                    return _is3_srEMap;
                else
                {
                    if (_srEMap == null)
                        return null;
                    if (_srEMap.WkText != null)
                        _is3_srEMap = new IS3SpatialReference(_srEMap.WkText);
                    else
                        _is3_srEMap = new IS3SpatialReference(_srEMap.Wkid);
                    return _is3_srEMap;
                }
            }
        }

        public ViewBaseType baseType
        {
            get { return ViewBaseType.D2; }
        }


        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }
        public EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get; set; }


        public IS3View2D(UserControl parent, MapView mapView)
        {
            holder = parent as IViewHolder;

            _parent = parent;
            _mapView = mapView;
            _map = mapView.Map;

            // add default map tip
            _mapTip = new MapTip();
            _mapTip.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            _mapTip.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _mapTip.Visibility = System.Windows.Visibility.Collapsed;
            _mapView.Overlays.Items.Add(_mapTip);


            ////add default map legend
            //_mapLegend = new MapLegend();
            //_mapLegend.HorizontalAlignment= HorizontalAlignment.Right;
            //_mapLegend.VerticalAlignment = VerticalAlignment.Top;
            //_mapLegend.Margin =new Thickness( 10);
            //_mapLegend.Padding =new Thickness( 5);
            ////_mapLegend.Visibility = System.Windows.Visibility.Collapsed;
            //_mapView.Overlays.Items.Add(_mapLegend);
        }

        public List<string> isConstructedlayer;

        public async Task loadPredefinedLayers()
        {
            Project prj = _prj;


            int index = 1;
            foreach (string LocalTileFile in _eMap.LocalTileFileNames)
            {
                // Load local tile layers
                if (isValidFileName(LocalTileFile))
                {
                    string DestnationPath = Runtime.dataPath + "\\TPKs\\"
                        + LocalTileFile;
                    //DestnationPath 离线切片位置,LocalTileFile 图层名字
                    addLocalTiledLayer(DestnationPath, LocalTileFile);
                    index++;

                }
            }

            isConstructedlayer = new List<string>();

            foreach (string LocalGeoDbFileName in _eMap.LocalGeoDbFileNames)
            {
                // Load local tile layers
                if (isValidFileName(LocalGeoDbFileName))
                {
                    string DestnationPath = Runtime.dataPath + "\\" + Globals.project.projectID + "\\" + LocalGeoDbFileName;
                    await addLocalGeoDbFile(DestnationPath, LocalGeoDbFileName);
                }
            }

            Envelope extent =
                new Envelope(double.Parse(_eMap.XMin.ToString()), double.Parse(_eMap.YMin.ToString()), double.Parse(_eMap.XMax.ToString()), double.Parse(_eMap.YMax.ToString()));

            if (_eMap.MapRotation != 0)
                await _mapView.SetRotationAsync(double.Parse(_eMap.MapRotation.ToString()));

            _mapView.SetView(extent);

            //bool x = await _mapView.SetViewAsync(extent);
            //await _mapView.SetRotationAsync(_eMap.MapRotation);
            _mapView.MaxScale = 1.0;        // To do
            //_mapView.MinimumResolution = _eMap.MinimumResolution;
            _mapView.MouseMove += async (o, e) =>
            {
                System.Windows.Point screenPoint = e.GetPosition(_mapView);
                MapPoint mapPoint = screenPoint2MapPoint(screenPoint);
                if (mapPoint == null)
                    return;
                setCoord(mapPoint);
                await showDefaultMapTip(screenPoint, mapPoint);
            };
            _mapView.PreviewMouseLeftButtonDown += async (o, e) =>
            {
                System.Windows.Point screenPoint = e.GetPosition(_mapView);
                bool success = await selectByPoint(screenPoint);
                e.Handled = success;
            };


        }
        MapPoint screenPoint2MapPoint(System.Windows.Point screenPoint)
        {
            MapPoint mapPoint = _mapView.ScreenToLocation(screenPoint);
            if (mapPoint == null)
                return null;
            if (_mapView.WrapAround)
                mapPoint = GeometryEngine.NormalizeCentralMeridian(mapPoint) as MapPoint;
            if (_srEMap != null)
            {
                // transform the map point to user defined spatial reference coordinate system
                Geometry g = GeometryEngine.Project(mapPoint, _srEMap);
                mapPoint = g as MapPoint;
            }
            return mapPoint;
        }
        bool _isHitTesting = false;
        async Task showDefaultMapTip(System.Windows.Point screenPoint, MapPoint mapPoint)
        {
            if (_isHitTesting)
                return;
            try
            {
                _isHitTesting = true;
                DGObject obj = null;
                IS3GraphicsLayer gLayer = null;
                for (int i = _map.Layers.Count - 1; i >= 0; i--)
                {
                    Layer layer = _map.Layers[i];
                    gLayer = layer as IS3GraphicsLayer;
                    if (!isLayerSelectable(gLayer))
                        continue;
                    obj = await gLayer.hitTestAsync(screenPoint, mapView);
                    if (obj != null)
                    {
                        break;
                    }
                }
                //foreach (Layer layer in _map.Layers)
                //{
                //    gLayer = layer as IS3GraphicsLayer;
                //    if (!isLayerSelectable(gLayer))
                //        continue;
                //    obj = await gLayer.hitTestAsync(screenPoint, mapView);
                //    if (obj != null)
                //    {
                //        break;
                //    }
                //}
                if (obj != null)
                {
                    //_mapTip.className.Text = obj.GetType().Name;
                    _mapTip.DataContext = obj;
                    _mapTip.Visibility = System.Windows.Visibility.Visible;
                    MapView.SetViewOverlayAnchor(_mapTip, mapPoint);
                }
                else
                    _mapTip.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch
            {
                _mapTip.Visibility = System.Windows.Visibility.Collapsed;
            }
            finally
            {
                _isHitTesting = false;
            }
        }

        // Summary:
        //     Screen point to map point conversions
        //
        public IMapPoint screenToLocation(System.Windows.Point screenPoint)
        {
            MapPoint mapPoint = screenPoint2MapPoint(screenPoint);
            return new IS3MapPoint(mapPoint);
        }
        public System.Windows.Point locationToScreen(IMapPoint mapPoint)
        {
            return _mapView.LocationToScreen(mapPoint as MapPoint);
        }

        public void addLocalTiledLayer(string DestnationPath, string id)
        {
            if (File.Exists(DestnationPath))
            {
                ArcGISLocalTiledLayer localTiledLayer =
                    new ArcGISLocalTiledLayer(DestnationPath);
                localTiledLayer.ID = id;
                localTiledLayer.DisplayName = id;
                //默认全关
                localTiledLayer.IsVisible = false;
                _map.Layers.Add(localTiledLayer);
            }
            else
            {
                string error = string.Format(_fileNotExist, DestnationPath);
                // ErrorReport.Report(error);
            }
        }

        async Task addLocalMapFile(string DestnationPath)
        {
            if (File.Exists(DestnationPath))
            {
                IsBusy = true;

                _localFeatureService = new LocalFeatureService(DestnationPath, _maxRecords);
                await _localFeatureService.StartAsync();

                IsBusy = false;
                ArcGISDynamicMapServiceLayer dynamicServiceLayer =
                    new ArcGISDynamicMapServiceLayer();
                dynamicServiceLayer.ID = "localMap";
                dynamicServiceLayer.DisplayName = "localMap";
                dynamicServiceLayer.ServiceUri = _localFeatureService.UrlMapService;
                _map.Layers.Add(dynamicServiceLayer);

            }
            else
            {
                string error = string.Format(_fileNotExist, DestnationPath);
                // MessageBox.Show(error);
            }
        }

        async Task addLocalGeoDbFile(string DestnationPath, string geoname)
        {
            if (File.Exists(DestnationPath))
            {
                Geodatabase gdb = await Geodatabase.OpenAsync(DestnationPath);

                foreach (var layerDef in _eMap.LocalGdbLayersDef)
                {
                    if (!isConstructedlayer.Contains(layerDef.Name))
                    {
                        if (LayerToGeofile.ContainsKey(layerDef.Name))
                        {
                            if (LayerToGeofile[layerDef.Name] + ".geodatabase" == geoname)
                            {
                                await addGeodatabaseLayer(layerDef, gdb);
                                isConstructedlayer.Add(layerDef.Name);
                            }
                        }
                    }
                }
            }
        }
        public List<string> PlanThemelist = new List<string>() { "施工进度-平面", "水文地质", "工程地质" };
        // Summary:
        //     Add a layer in a geodatabase (aka. local layer)
        //     The name of the layer and display options are specified in the LocalELayer
        //
        public async Task<IGraphicsLayer> addGeodatabaseLayer(LayerDef layerDef,
            Geodatabase gdb, int start = 0, int maxFeatures = 0)
        {
            try
            {
                if (layerDef == null || gdb == null)
                    return null;

                GeodatabaseFeatureTable table =
                    gdb.FeatureTables.FirstOrDefault(t => t.Name == layerDef.Name);
                if (table == null)
                    return null;

                IS3GraphicsLayer gLayer = await featureTable2GraphicsLayer(
                    table, start, maxFeatures, false);
                if (gLayer == null)
                    return null;

                gLayer.ID = layerDef.Name;
                gLayer.MinScale = table.ServiceInfo.MinScale;
                gLayer.MaxScale = table.ServiceInfo.MaxScale;
                setGraphicLayerDisplayOptions(layerDef, gLayer);


                _map.Layers.Add(gLayer);
                return gLayer;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<IGraphicsLayer> addGdbLayer(LayerDef eLayer,
            string dbFile, int start = 0, int maxFeatures = 0)
        {
            //if (dbFile == null)
            //    dbFile = _eMap.LocalGeoDbFileName;

            //string DestnationPath = _prj.projDef.LocalFilePath + "\\" + dbFile;

            //if (File.Exists(DestnationPath))
            //{
            //    Geodatabase gdb = await Geodatabase.OpenAsync(DestnationPath);
            //    IGraphicsLayer gLayer = await addGeodatabaseLayer(
            //        eLayer, gdb, start, maxFeatures);
            //    return gLayer;
            //}
            return null;
        }

        // Summary:
        //     Add a layer in a shape file
        //     The name of the layer and display options are specified in the LocalELayer
        //
        public async Task<IGraphicsLayer> addShpLayer(LayerDef layerDef,
            string shpFile, int start = 0, int maxFeatures = 0)
        {
            //if (layerDef == null || shpFile == null)
            //    return null;
            //string DestnationPath = _prj.projDef.LocalFilePath + "\\" + shpFile;
            //if (File.Exists(DestnationPath))
            //{
            //    ShapefileTable table = await ShapefileTable.OpenAsync(DestnationPath);
            //    if (table == null)
            //        return null;

            //    IS3GraphicsLayer gLayer = await featureTable2GraphicsLayer(
            //        table, start, maxFeatures, true);
            //    if (gLayer == null)
            //        return null;

            //    gLayer.ID = layerDef.Name;
            //    setGraphicLayerDisplayOptions(layerDef, gLayer);

            //    _map.Layers.Add(gLayer);
            //    return gLayer;
            //}
            return null;
        }

        // Summary:
        //     Load features in a FeatureTable into a GraphicsLayer
        //
        async Task<IS3GraphicsLayer> featureTable2GraphicsLayer(FeatureTable table,
            int start = 0, int maxFeatures = 0, bool isShp = false)
        {
            if (table == null)
                return null;

            if (_srEMap == null)
            {
                // The spatial reference in the first table is used as the project spatial reference.
                // All features on other layers will be projected to the spatial reference.
                _srEMap = table.SpatialReference;
                _map.SpatialReference = table.SpatialReference;
            }

            //// We cannot use the feature layer class because it typically 
            //// has a different SpatialReferece object (coordinate system)
            //// other than the tiled layer (WKID = 3857 or 102100),
            //// and there is no easy way to reproject feature layer
            //// to another coordinate system.
            //// We can only use the feature layer when there is no tiled layer defined,
            //// which is not a usual case.
            //FeatureLayer fLayer = new FeatureLayer(table);
            //fLayer.ID = table.Name;
            //fLayer.DisplayName = table.Name;
            //_map.Layers.Add(fLayer);

            QueryFilter qf = new QueryFilter();
            qf.WhereClause = "1=1";
            IEnumerable<Feature> features = await table.QueryAsync(qf);
            IS3GraphicCollection graphics = new IS3GraphicCollection();

            int index = 0, count = 0;
            foreach (Feature f in features)
            {
                // jump to start position
                if (index++ < start)
                    continue;

                // Note:
                //     In ArcGIS Runtime SDK: User-defined coordinate system
                //     is not allowed when using ShapefileTable.OpenAsync().
                // Workaround:
                //     (1) Do not assign user-defined CS in shape file;
                //     (2) Assign CS dynamically here to _srEMap.
                //
                Geometry geometry = f.Geometry;
                if (isShp == true)
                {
                    geometry = ArcGISMappingUtility.ChangeSpatailReference(geometry, _srEMap);
                    if (geometry == null)
                        continue;
                }

                if (_srEMap != null && isShp == false && geometry.SpatialReference != _srEMap)
                    geometry = GeometryEngine.Project(geometry, _srEMap);

                // import the attributes
                IS3Graphic g = new IS3Graphic(geometry);
                foreach (KeyValuePair<string, object> item in f.Attributes.AsEnumerable())
                    g.Attributes.Add(item);
                graphics.Add(g);

                // Load max featuers
                if (maxFeatures != 0 && count++ == maxFeatures)
                    break;
            }

            IS3GraphicsLayer gLayer = new IS3GraphicsLayer();
            gLayer.DisplayName = table.Name;
            gLayer.GraphicsSource = graphics;
            gLayer.geometryType = (Core.Model.GeometryType)(int)table.GeometryType;

            return gLayer;
        }

        // Summary:
        //     Set the GraphicsLayer display options according to the definition
        //     which is specified in the LocalELayer.
        //     The display options include selection color, renderer, and labelling
        //
        void setGraphicLayerDisplayOptions(LayerDef layerDef, IS3GraphicsLayer gLayer)
        {
            if (layerDef == null || gLayer == null)
                return;

            gLayer.IsVisible = layerDef.IsVisible;

            gLayer.SelectionColor = layerDef.SelectionColor;
            ISymbol symbol = GraphicsUtil.GenerateLayerSymbol(layerDef, gLayer.geometryType);
            gLayer.renderer = Runtime.graphicEngine.newSimpleRenderer(symbol);

            //if (layerDef.RendererDef == null)
            //{
            //   
            //}
            //else
            //{
            //    gLayer.renderer = Runtime.graphicEngine.newRenderer(layerDef.RendererDef);
            //}

            if (layerDef.EnableLabel == true)
            {
                AttributeLabelClass labelClass = generateLayerAttributeLable(layerDef, gLayer.geometryType);
                gLayer.Labeling.LabelClasses.Add(labelClass);
            }
        }

        // Summary:
        //     Generate a default label attributes according to the GeometryType
        //     The default labelling property of a feature is [Name]
        //
        AttributeLabelClass generateDefaultLayerAttributeLable(Core.Model.GeometryType geometryType)
        {
            IS3TextSymbol textSymbol = new IS3TextSymbol();
            textSymbol.Color = System.Windows.Media.Colors.Black;

            AttributeLabelClass labelClass = new AttributeLabelClass();
            labelClass.IsVisible = true;
            labelClass.TextExpression = "[Name]";
            labelClass.Symbol = textSymbol;

            if (geometryType == Core.Model.GeometryType.Polygon)
                labelClass.LabelPlacement = LabelPlacement.PolygonAlwaysHorizontal;

            return labelClass;
        }
        // Summary:
        //     Generate a label attributes according to the definition
        //     which is specified in the LayerDef
        //
        AttributeLabelClass generateLayerAttributeLable(LayerDef layerDef,
            Core.Model.GeometryType geometryType)
        {
            if (layerDef == null)
                return generateDefaultLayerAttributeLable(geometryType);

            IS3SymbolFont font = new IS3SymbolFont(
                layerDef.LabelFontFamily, double.Parse(layerDef.LabelFontSize.ToString()));
            font.FontStyle = layerDef.LabelFontStyle;
            font.FontWeight = layerDef.LabelFontWeight;
            font.TextDecoration = layerDef.LabelTextDecoration;

            IS3TextSymbol textSymbol = new IS3TextSymbol();
            textSymbol.Color = layerDef.LabelColor;
            textSymbol.Font = font;
            textSymbol.BorderLineColor = layerDef.LabelBorderLineColor;
            textSymbol.BorderLineSize = double.Parse(layerDef.LabelBorderLineWidth.ToString());
            textSymbol.BackgroundColor = layerDef.LabelBackgroundColor;

            AttributeLabelClass labelClass = new AttributeLabelClass();
            labelClass.IsVisible = true;
            labelClass.TextExpression = layerDef.LabelTextExpression;
            labelClass.WhereClause = layerDef.LabelWhereClause;
            labelClass.Symbol = textSymbol;

            if (geometryType == Core.Model.GeometryType.Polygon)
                labelClass.LabelPlacement = LabelPlacement.PolygonAlwaysHorizontal;

            return labelClass;
        }

        public virtual void setCoord(MapPoint mapPt)
        {
            string format = "X = {0}, Y = {1}";
            if (eMap.MapType == EngineeringMapType.GeneralProfileMap)
                format = "X = {0}, Z = {1}";

            string coord = string.Format(format,
                Math.Round(mapPt.X, 2), Math.Round(mapPt.Y, 2));
            IViewHolder viewHolder = _parent as IViewHolder;
            if (viewHolder != null)
                viewHolder.setCoord(coord);
        }

        #region query functions
        protected string queryCondition(IList<DGObject> objs)
        {
            string str = "";
            bool bFirst = true;
            foreach (DGObject obj in objs)
            {
                if (obj == null)
                    continue;

                if (bFirst == false)
                {
                    str += " OR ID=" + obj.ID;
                }
                else
                {
                    str = "ID=" + obj.ID;
                    bFirst = false;
                }
            }
            return str;
        }
        //public async Task<QueryResult>
        //    QueryEntitiesByID(QueryEntitiesArgs args, string layerName)
        //{
        //    QueryResult queryResult = null;

        //    // Objs field must be filled
        //    if (_localFeatureService == null || args.Objs == null)
        //        return queryResult;

        //    EngineeringLayer eLayer = _eMap.GetELayerByName(layerName);
        //    if (eLayer == null)
        //        return queryResult;

        //    string url = _localFeatureService.UrlFeatureService
        //        + "/" + eLayer.LocalLayerID;

        //    QueryTask queryTask = new QueryTask(new Uri(url));

        //    Query query = new Query("1=1");
        //    query.OutFields.Add("*");
        //    query.ReturnGeometry = true;
        //    query.OutSpatialReference = _srEMap;
        //    query.Where = QueryCondition(args.Objs);

        //    try
        //    {
        //        IsBusy = true;
        //        queryResult = await queryTask.ExecuteAsync(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    IsBusy = false;
        //    return queryResult;
        //}

        //public async Task<QueryResult>
        //    QueryEntitiesByGeom(QueryEntitiesArgs args, EngineeringLayer layer)
        //{
        //    QueryResult queryResult = null;

        //    if (_localFeatureService == null || layer == null)
        //        return queryResult;

        //    string url = _localFeatureService.UrlFeatureService
        //        + "/" + layer.LocalLayerID;

        //    QueryTask queryTask = new QueryTask(new Uri(url));

        //    Query query = new Query("1=1");
        //    query.OutFields.Add("*");
        //    query.ReturnGeometry = true;
        //    query.OutSpatialReference = _srEMap;
        //    query.Geometry = args.Geometry;
        //    query.Where = args.Condition;

        //    try
        //    {
        //        IsBusy = true;
        //        queryResult = await queryTask.ExecuteAsync(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    IsBusy = false;
        //    return queryResult;
        //}
        #endregion

        #region map pan functions
        public void panToObjects(IEnumerable<DGObject> objs)
        {
            if (objs == null)
                return;
            IGraphicCollection allGraphics = new IS3GraphicCollection();
            foreach (DGObject obj in objs)
            {
                if (obj == null || obj.parent == null)
                    continue;
                string layerID = obj.parent.definition.GISLayerName;
                IGraphicsLayer layer = _map.Layers[layerID] as IGraphicsLayer;
                if (layer == null)
                    continue;
                IGraphicCollection gc = layer.getGraphics(obj);
                if (gc == null)
                    continue;
                allGraphics.Add(gc);
            }
            panToGraphics(allGraphics);
        }
        public void panToGraphic(IGraphic g)
        {
            Geometry ext = g.Geometry.Extent as Geometry;
            MapPoint center = ext.Extent.GetCenter();

            _mapView.SetView(center);
        }
        public void panToGraphics(IGraphicCollection gc)
        {
            IEnvelope env = GraphicsUtil.GetGraphicsEnvelope(gc);
            if (env == null)
                return;
            IMapPoint p = env.GetCenter();
            MapPoint center = p as MapPoint;
            _mapView.SetView(center);
        }
        public void panToSelected()
        {
            IGraphicCollection allGraphics = new IS3GraphicCollection();
            foreach (Layer layer in _map.Layers)
            {
                IGraphicsLayer gLayer = layer as IGraphicsLayer;
                if (gLayer == null)
                    continue;
                allGraphics.Add(gLayer.selectedGraphics);
            }
            panToGraphics(allGraphics);
        }
        #endregion

        public bool isValidFileName(string filename)
        {
            if (filename == null || filename.Count() == 0)
                return false;
            else
                return true;
        }

        #region drawing layer function
        public IEnumerable<Graphic> getSelectedDrawingObjects(
            GraphicsLayer drawingLayer)
        {
            return drawingLayer.SelectedGraphics;
        }
        public IEnumerable<Graphic> removeSelectedDrawingObjects(
            GraphicsLayer drawingLayer)
        {
            if (drawingLayer.SelectedGraphics.Count() == 0)
                return null;

            GraphicCollection gc = new GraphicCollection();
            foreach (Graphic g in drawingLayer.Graphics)
            {
                if (g.IsSelected)
                    gc.Add(g);
            }

            foreach (Graphic g in gc)
                drawingLayer.Graphics.Remove(g);
            return gc;
        }
        #endregion

        public async Task<bool> selectByPoint(System.Windows.Point screenPoint)
        {
            bool success = false;
            DGObject obj = null;
            IS3GraphicsLayer gLayer = null;
            //foreach (Layer layer in _map.Layers)
            //{
            //    gLayer = layer as IS3GraphicsLayer;
            //    if (!isLayerSelectable(gLayer))
            //        continue;
            //    obj = await gLayer.selectObjectByPoint(screenPoint, mapView);
            //    if (obj != null)
            //    {
            //        break;
            //    }
            //}
            for (int i = _map.Layers.Count - 1; i >= 0; i--)
            {
                Layer layer = _map.Layers[i];
                gLayer = layer as IS3GraphicsLayer;
                if (!isLayerSelectable(gLayer))
                    continue;
                obj = await gLayer.selectObjectByPoint(screenPoint, mapView);
                if (obj != null)
                {
                    break;
                }
            }
            if (obj != null && ObjSelectionChangedHandler != null)
            {
                ObjSelectionChangedEvent args = new ObjSelectionChangedEvent();
                args.addObjs = new Dictionary<string, List<DGObject>>();
                List<DGObject> objs = new List<DGObject>();
                objs.Add(obj);
                args.addObjs.Add(obj.parent.definition.Name, objs);
                ObjSelectionChangedHandler(this, args);
                success = true;
            }
            return success;
        }

        public async void selectByRect()
        {
            if (Globals.isThreadUnsafe())
            {
                Globals.application.Dispatcher.Invoke(new Action(() =>
                {
                    selectByRect();
                }));
                return;
            }

            Geometry geom = await _mapView.Editor.RequestShapeAsync(DrawShape.Rectangle);
            if (_srEMap != null)
                geom = GeometryEngine.Project(geom, _srEMap);
            IGeometry rect = IS3GeometryEngine.fromGeometry(geom);

            ObjSelectionChangedEvent args = new ObjSelectionChangedEvent();
            args.addObjs = new Dictionary<string, List<DGObject>>();

            foreach (Layer layer in _map.Layers)
            {
                IGraphicsLayer gLayer = layer as IGraphicsLayer;
                if (!isLayerSelectable(gLayer))
                    continue;
                List<DGObject> objs = gLayer.selectObjectsByRect(rect);
                if (objs.Count > 0)
                    args.addObjs.Add(gLayer.ID, objs);
            }

            if (ObjSelectionChangedHandler != null)
                ObjSelectionChangedHandler(this, args);
        }

        List<string> _selectableLayerIDs = new List<string>();
        public void addSeletableLayer(string layerID)
        {
            if (layerID == null)
                return;
            if (layerID == "_ALL")
            {
                _selectableLayerIDs.Clear();
                return;
            }
            if (!_selectableLayerIDs.Contains(layerID))
                _selectableLayerIDs.Add(layerID);
        }
        public void removeSelectableLayer(string layerID)
        {
            if (layerID == null)
                return;
            if (layerID == "_ALL")
            {
                _selectableLayerIDs.Clear();
                // add an empty item prevents select all
                _selectableLayerIDs.Add("");
                return;
            }
            if (_selectableLayerIDs.Contains(layerID))
                _selectableLayerIDs.Remove(layerID);
            if (_selectableLayerIDs.Count == 0)
                _selectableLayerIDs.Add("");
        }
        public bool isLayerSelectable(IGraphicsLayer gLayer)
        {
            if (gLayer == null)
                return false;
            if (gLayer.IsVisible == false)
                return false;

            if (_selectableLayerIDs.Count == 0)
                return true;
            else if (_selectableLayerIDs.Contains(gLayer.ID))
                return true;
            else
                return false;
        }



        //public async void drawToolsClickEventListener(object sender,
        //    UserControl.DrawToolClickEventArgs args)
        //{
        //    if (args.stopDraw)
        //    {
        //        if (_mapView.Editor.Cancel.CanExecute(null))
        //            _mapView.Editor.Cancel.Execute(null);
        //    }
        //    else
        //    {
        //        await drawGraphics(args.drawShapeType);
        //    }
        //}

        public async Task drawGraphics(DrawShapeType drawShapeType)
        {
            if (Globals.isThreadUnsafe())
            {
                await Globals.application.Dispatcher.Invoke(new Func<Task>(async () =>
                {
                    await drawGraphics(drawShapeType);
                }));
                return;
            }

            // Add a drawing graphics layer
            if (_drawingLayer == null)
            {
                _drawingLayer = new IS3GraphicsLayer();
                _drawingLayer.ID = "0";
                _drawingLayer.DisplayName = "0";
                _map.Layers.Add(_drawingLayer);
            }

            if (_mapView.Editor.IsActive)
                return;

            try
            {
                Geometry geom = await _mapView.Editor.RequestShapeAsync((DrawShape)drawShapeType);
                if (_srEMap != null)
                    geom = GeometryEngine.Project(geom, _srEMap);
                IGeometry iGeom = IS3GeometryEngine.fromGeometry(geom);
                IGraphic g = Runtime.graphicEngine.newGraphic(iGeom);
                GraphicsUtil.AssignDefaultDrawingSymbol(g);

                _drawingLayer.graphics.Add(g);

                // trigger a drawing graphics changed event
                if (drawingGraphicsChangedTrigger != null)
                {
                    DrawingGraphicsChangedEventArgs args =
                        new DrawingGraphicsChangedEventArgs();
                    List<IGraphic> addedItems = new List<IGraphic>();
                    addedItems.Add(g);
                    args.addedItems = addedItems;
                    drawingGraphicsChangedTrigger(this, args);
                }
            }
            catch (TaskCanceledException)
            {
                // Ignore TaskCanceledException - usually happens if the editor gets cancelled or restarted
            }
        }

        public void ExcuteCommand(string command)
        {
        }

        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {

        }

        public void load()
        {

        }

        public void DGObjectsSelectionChangedListenerOuter(object sender, DGObjectsSelectionChangedEvent e)
        {

        }

        public void objSelectionChangedListenerOuter(object sender, ObjSelectionChangedEvent e)
        {
            if (e.addObjs != null)
            {
                foreach (string objdef in e.addObjs.Keys)
                {
                    string layerID = Globals.project.objsDefIndex[objdef].definition.GISLayerName;
                    highlightObjects(e.addObjs[objdef], layerID, true);
                }
            }
            if (e.removeObjs != null)
            {
                foreach (string objdef in e.removeObjs.Keys)
                {
                    string layerID = Globals.project.objsDefIndex[objdef].definition.GISLayerName;
                    highlightObjects(e.removeObjs[objdef], layerID, false);
                }
            }
        }

        public void DGObjectsSelectionChangedListenerInner(object sender, DGObjectsSelectionChangedEvent e)
        {
            //
        }

        public void objSelectionChangedListenerInner(object sender, DGObjectsSelectionChangedEvent e)
        {
            //
        }

        // Summary:
        //     Object selection event listener (function).
        //     It will highlight selected objects and unhighlight
        //     deselected objects.
        public void objSelectionChangedListener(object sender,
            ObjSelectionChangedEvent e)
        {
            if (sender == this)
                return;

            if (e.addObjs != null)
            {
                foreach (string objdef in e.addObjs.Keys)
                {
                    string layerID = Globals.project.objsDefIndex[objdef].definition.GISLayerName;
                    highlightObjects(e.addObjs[layerID], layerID, true);
                }
            }
            if (e.removeObjs != null)
            {
                foreach (string objdef in e.removeObjs.Keys)
                {
                    string layerID = Globals.project.objsDefIndex[objdef].definition.GISLayerName;
                    highlightObjects(e.removeObjs[layerID], layerID, false);
                }
            }
        }

        System.Windows.Point IView2D.locationToScreen(IMapPoint mapPoint)
        {
            throw new NotImplementedException();
        }


        public async Task initialzeView()
        {
            await loadPredefinedLayers();
        }

        public Task Init()
        {
            throw new NotImplementedException();
        }

        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {
            try
            {
                if (e.addObjs != null)
                {
                    foreach (string objdef in e.addObjs.Keys)
                    {
                        string layerID = Globals.project.objsDefIndex[objdef].definition.GISLayerName;
                        //临时，接口没有返回GISLayerName
                        if (layerID == null)
                        {
                            layerID = e.addObjs[objdef].FirstOrDefault().parent.definition.Type;
                        }
                        highlightObjects(e.addObjs[objdef], layerID, true);
                    }
                }
                if (e.removeObjs != null)
                {
                    foreach (string objdef in e.removeObjs.Keys)
                    {
                        string layerID = Globals.project.objsDefIndex[objdef].definition.GISLayerName;
                        if (layerID == null)
                        {
                            layerID = e.addObjs[objdef].FirstOrDefault().parent.definition.Type;
                        }
                        highlightObjects(e.removeObjs[objdef], layerID, false);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }



}
