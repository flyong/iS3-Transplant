using iS3.Core.Client.Graphics;
using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public enum ViewType
    {
        None = 0,
        General2DView,
        PlanarView,
        ProfileView,
        CrossSectionView,
        General3DView = 11,
    };
    public enum ViewBaseType
    {
        Normal = 0,
        D2 = 1,
        D3 = 2,
    }
    // Summary:
    //     The drawing mode
    public enum DrawShapeType
    {
        // Summary:
        //     Uses a single click to create a MapPoint.
        Point = 0,
        //
        // Summary:
        //     Draw a shape that returns a Polyline.
        Polyline = 1,
        //
        // Summary:
        //     Draw a shape that returns a Polygon.
        Polygon = 2,
        //
        // Summary:
        //     Draw a shape that returns a map-aligned Envelope.
        Envelope = 3,
        //
        // Summary:
        //     Draw a shape that returns a screen-aligned Polygon.
        Rectangle = 4,
        //
        // Summary:
        //     Draw a free hand Polyline.
        Freehand = 5,
        //
        // Summary:
        //     Draw an arrow shape as a Polygon.
        Arrow = 6,
        //
        // Summary:
        //     Draw a triangle shape as a Polygon.
        Triangle = 7,
        //
        // Summary:
        //     Draw an ellipse as a Polygon.
        Ellipse = 8,
        //
        // Summary:
        //     Draw a circle as a Polygon.
        Circle = 9,
        //
        // Summary:
        //     Draw a single line segment that returns a Polyline.
        LineSegment = 10,
    }
    /// <summary>
    /// iS3 控件公共接口
    /// </summary>
    public interface IView
    {
        
        string name { get; }
        ViewType type { get; }
        ViewBaseType baseType { get; }

        //Init and Close
        void load();
        Task initialzeView();
        void onClose();

        // Highlight/Unhighlight an object or objects on a layer.
        //
        void highlightObject(DGObject obj, bool on = true);
        void highlightObjects(IEnumerable<DGObject> objs, bool on = true);
        void highlightObjects(IEnumerable<DGObject> objs, string layerID,
            bool on = true);
        void highlightAll(bool on = true);

        //// Graphics-Objects Sync
        ////
        int syncObjects();


        EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }
        void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e);
        Task Init();
        EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get; set; }
        void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e);


    }
    public class DGObjectsSelectionChangedEvent
    {
        public DGObjects oldObjs { get; set; }
        public DGObjects newObjs { get; set; }
    }
    public class ObjSelectionChangedEvent
    {
        //事件触发记录列表，防止重复触发
        public List<object> TriggleList = new List<object>();
        /// <summary>
        /// Key:对象组名称 ;value:
        /// </summary>
        public Dictionary<string, List<DGObject>> addObjs { get; set; }
        public Dictionary<string, List<DGObject>> removeObjs { get; set; }
    }
    // Summary:
    //     User drawing graphics changed event args
    public class DrawingGraphicsChangedEventArgs : EventArgs
    {
        public IEnumerable<IGraphic> addedItems;
        public IEnumerable<IGraphic> removedItems;
    }
    // Summary:
    //     View holder class: for plan view and profile view.
    //
    public interface IViewHolder
    {
        void setCoord(string coord);
        void setruler(double x, double y);
        IView view { get; }
        #region  legend

        void setruler(List<string> m1, List<string> m2, List<string> sc,string rulername);
        void setlegend(iS3Legned legend);
        void setLegendShow(bool state);

        void addLegend(iS3Symbol symbol);
        void removeLegend(string labelName);

        void clearLegend();
        #endregion

        void settitle(string st);
    }
}
