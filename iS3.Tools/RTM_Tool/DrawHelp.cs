using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Construction;
using iS3.Core.Client.Geometry;
using iS3.Core.Client.Graphics;
using System.Windows.Media;
using iS3.Construction.Model;
using iS3.Structure.Model;
using System.IO;
using Newtonsoft.Json;

using iS3.ArcGIS.Graphics;
using iS3.ArcGIS.Geometry;
namespace RTM_Tool
{
    public class Axispoint
    {
        //轴线点坐标
        public decimal pointx;
        public decimal pointy;
        public decimal pointz;
        //轴线点桩号
        public string mileage;
        public Axispoint()
        {

        }

        public Axispoint(decimal x, decimal y, decimal z, string m)
        {
            pointx = x;
            pointy = y;
            pointz = z;
            mileage = m;
        }

    }
    public class Pile
    {
        //桩号区间头尾里程
        public decimal startpile, endpile;
        //桩号点里程
        public decimal pilepoint;
        //标段
        public string sectionnumber;
        //桩号类型，区间或点
        public Piletype piletype;
        public Tunnelpart tunnelpart;
    }
    public enum Tunnelpart { left = 1, right = 2, s2inclinedshaft = 3, s3inclinedshaft = 4 }
    public enum Piletype { point = 1, interval = 2 };
    public class DrawObjects
    {
        public Project _prj { get; set; }
        public IMainFrame mainFrame { get; set; }
        public IView2D _inputView { get; set; }
        public IView2D _inputView_left { get; set; }
        public Domain _constructionDoamin { get; set; }
        public DGObjects _gprfDGObjects { get; set; }

        //坐标系
        public ISpatialReference isp { get; set; }
        //线样式
        public ISimpleLineSymbol sym_line { get; set; }
        //填充样式
        public ISimpleFillSymbol sym_fill3 { get; set; }
        public ISimpleFillSymbol sym_fill4 { get; set; }
        public ISimpleFillSymbol sym_fill5 { get; set; }
        public ISimpleFillSymbol sym_fill { get; set; }

        //渲染样式
        public ISimpleRenderer renderer { get; set; }
        public List<Axispoint> axispoints { get; set; }
        public List<Axispoint> s2inclinedpoints { get; set; }
        public List<Axispoint> s3inclinedpoints { get; set; }
        static string[] splitchar = { "YK", "ZK", "BXK", "LXK" };
        public List<Pile> lefttunnel, righttunnel, s2inclinedshaft, s3inclinedshaft;
        List<string> tunnelfacelist;

        #region 3d
        public static List<Tuple<string, string>> tunnelSectionList = new List<Tuple<string, string>>();
        public static List<string> tunnelPosList = new List<string>();
        #endregion
        public DrawObjects()
        {
            axispoints = new List<Axispoint>();     //存放隧道主洞轴线点
            s2inclinedpoints = new List<Axispoint>()
            { new Axispoint(2908.0M,0.0M,2351.8M,"BXK1+700"),
                new Axispoint(3078.0M,0.0M,2334.8M,"BXK0+000") };//存放S2标段斜井2个轴线点

            s3inclinedpoints = new List<Axispoint>()
            { new Axispoint(3588.8M,0.0M,2331.0M,"LXK0+000"),
                new Axispoint(3775.0M,0.0M,2350M,"LXK1+870") };//存放S3标段斜井2个轴线点
            Loadcsvfile();
            Loadpilefile();
        }

        public List<T> Transfer<T>(List<DGObject> objList) where T : class, new()
        {
            List<T> list = new List<T>();
            foreach (DGObject _obj in objList)
            {
                list.Add(_obj as T);
            }
            return list;
        }

        //根据里程号返回标段号
        public static string getrightSectionnumber(decimal t)
        {
            DrawObjects _newobj = new DrawObjects();
            foreach (Pile obj in _newobj.righttunnel)
            {
                if ((obj.startpile <= t) && (obj.endpile >= t))
                {
                    return obj.sectionnumber;
                }
            }
            return null;
        }
        //读取轴线点坐标及里程
        public void Loadpilefile()
        {
            try
            {
                string exeLocation = System.IO.Directory.GetCurrentDirectory();
                string csvDestnationPath = "c:\\LaoYingData\\draw";
                if (!Directory.Exists(csvDestnationPath))
                    return;
                csvDestnationPath = csvDestnationPath + "\\pile.csv";
                StreamReader sr = new StreamReader(csvDestnationPath, Encoding.Default);
                string line;
                lefttunnel = new List<Pile>();
                righttunnel = new List<Pile>();
                s2inclinedshaft = new List<Pile>();
                s3inclinedshaft = new List<Pile>();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0) continue;
                    string[] str = line.Split(',');
                    Pile _pile = getSectionPos(str[1]);
                    _pile.sectionnumber = str[0];
                    switch (_pile.tunnelpart)
                    {
                        case Tunnelpart.left:
                            lefttunnel.Add(_pile);
                            break;
                        case Tunnelpart.right:
                            righttunnel.Add(_pile);
                            break;
                        case Tunnelpart.s2inclinedshaft:
                            s2inclinedshaft.Add(_pile);
                            break;
                        case Tunnelpart.s3inclinedshaft:
                            s3inclinedshaft.Add(_pile);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        public Axispoint GetXJPointBasedOnMileage(decimal mileage, string xjpart)
        {
            decimal t1, t2, tx, ty, tz;
            Axispoint _point;
            if (xjpart == "S2")
            {
                t1 = getSectionPos(s2inclinedpoints[0].mileage).pilepoint;
                t2 = getSectionPos(s2inclinedpoints[1].mileage).pilepoint;
                tx = (mileage - t1) / (t2 - t1) * (s2inclinedpoints[1].pointx - s2inclinedpoints[0].pointx) + s2inclinedpoints[0].pointx;
                ty = 0;
                tz = (mileage - t1) / (t2 - t1) * (s2inclinedpoints[1].pointz - s2inclinedpoints[0].pointz) + s2inclinedpoints[0].pointz;
                _point = new Axispoint(tx, ty, tz, "Caculate Point");
            }
            else
            {
                t1 = getSectionPos(s3inclinedpoints[0].mileage).pilepoint;
                t2 = getSectionPos(s3inclinedpoints[1].mileage).pilepoint;
                tx = (mileage - t1) / (t2 - t1) * (s3inclinedpoints[1].pointx - s3inclinedpoints[0].pointx) + s3inclinedpoints[0].pointx;
                ty = 0;
                tz = (mileage - t1) / (t2 - t1) * (s3inclinedpoints[1].pointz - s3inclinedpoints[0].pointz) + s3inclinedpoints[0].pointz;
                _point = new Axispoint(tx, ty, tz, "Caculate Point");
            }
            return _point;
        }
        //绘制右幅超前地质 预报

        public void DrawGRPF()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("TFSI", "超前地质预报");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("TFSI", "超前地质预报");

                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.Green, SimpleLineStyle.Solid, 1.0);
                sym_fill = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Green, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);
                //获取需要绘制的数据对象 Construction -GRPF
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "TFSI").FirstOrDefault();
                //获取GPRF数据对象列表
                //List<GPRF> objList = _gprfDGObjects.objContainer.Cast<GPRF>().ToList();
                List<TFSI> objList = Transfer<TFSI>(_gprfDGObjects.objContainer);

                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合
                foreach (TFSI obj in objList)
                {
                    string mileage = obj.TFSI_MILE;

                    Pile res = getSectionPos(mileage);
                    if ((res == null) || (res.piletype != Piletype.interval))
                    {
                        continue;
                    }
                    Axispoint spoint = null;
                    Axispoint epoint = null;

                    if ((res.tunnelpart == Tunnelpart.right) || (res.tunnelpart == Tunnelpart.left))
                    {
                        spoint = GetPointBasedOnMileage(res.startpile);
                        epoint = GetPointBasedOnMileage(res.endpile);
                    }
                    if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                    {
                        spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                        epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                    }
                    if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                    {
                        spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                        epoint = GetXJPointBasedOnMileage(res.endpile, "S3");

                    }
                    if ((spoint == null) || (epoint == null)) continue;

                    if (res.tunnelpart == Tunnelpart.right)
                    {
                        IPointCollection pp = CalculatePoints(spoint, epoint);
                        IGraphic polygon =
                            Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                        polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        igc.Add(polygon);              //添加到图元集合
                    }
                    if (res.tunnelpart == Tunnelpart.left)
                    {
                        IPointCollection pp = CalculatePoints(spoint, epoint);
                        IGraphic polygon =
                            Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                        polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        igc_left.Add(polygon);              //添加到图元集合
                    }

                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);    //添加到图层
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {

            }

        }
        //绘制右幅沿桩衬砌类型
        public void DrawMILI()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("MILI", "沿桩衬砌类型");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("MILI", "沿桩衬砌类型");
                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.Purple, SimpleLineStyle.Solid, 1.0);
                sym_fill3 = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Purple, SimpleFillStyle.Solid, sym_line);
                sym_fill4 = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Cyan, SimpleFillStyle.Solid, sym_line);
                sym_fill5 = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Red, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);
                //获取需要绘制的数据对象 Structure -MILI
                _constructionDoamin = _prj.getDomain("Structure");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "MILI").FirstOrDefault();
                //获取MILI数据对象列表
                //List<MILI> objList = _gprfDGObjects.objContainer.Cast<MILI>().ToList();
                List<MILI> objList = Transfer<MILI>(_gprfDGObjects.objContainer);

                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合

                //设置标尺信息
                List<string> ms_left = new List<string>();
                List<string> me_left = new List<string>();
                List<string> sc_left = new List<string>();
                List<string> ms_right = new List<string>();
                List<string> me_right = new List<string>();
                List<string> sc_right = new List<string>();
                foreach (MILI obj in objList)
                {
                    string mileage1 = obj.MILI_STAR;
                    string mileage2 = obj.MILI_END;
                    Pile res1 = getSectionPos(mileage1);
                    Pile res2 = getSectionPos(mileage2);
                    if ((res1 == null) || (res2 == null))
                    {
                        continue;
                    }
                    if (res1.tunnelpart == Tunnelpart.right)
                    {
                        ms_right.Add(mileage1);
                        me_right.Add(mileage2);
                        sc_right.Add(obj.MILI_LNTY);
                    }
                    //左幅
                    if (res1.tunnelpart == Tunnelpart.left)
                    {
                        ms_left.Add(mileage1);
                        me_left.Add(mileage2);
                        sc_left.Add(obj.MILI_LNTY);
                    }
                }
                _inputView.holder.setruler(ms_right, me_right, sc_right, "MILI");
                _inputView_left.holder.setruler(ms_left, me_left, sc_left, "MILI");

                foreach (MILI obj in objList)
                {
                    string mileage1 = obj.MILI_STAR;
                    string mileage2 = obj.MILI_END;
                    Pile res1 = getSectionPos(mileage1);
                    Pile res2 = getSectionPos(mileage2);
                    if ((res1 == null) || (res2 == null))
                    {
                        continue;
                    }
                    Axispoint spoint = GetPointBasedOnMileage(res1.pilepoint);
                    Axispoint epoint = GetPointBasedOnMileage(res2.pilepoint);
                    if ((spoint == null) || (epoint == null)) continue;

                    //右幅

                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    switch (getLevel((obj as MILI).MILI_LNTY))
                    {
                        case 3:
                            polygon.Symbol = sym_fill3;
                            break;
                        case 4:
                            polygon.Symbol = sym_fill4;
                            break;
                        case 5:
                            polygon.Symbol = sym_fill5;
                            break;
                        default:
                            polygon.Symbol = sym_fill3;
                            break;
                    }
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    if (res1.tunnelpart == Tunnelpart.right)
                    {
                        igc.Add(polygon);              //添加到图元集合
                    }
                    //左幅
                    if (res1.tunnelpart == Tunnelpart.left)
                    {
                        igc_left.Add(polygon);
                    }
                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);    //添加到图层
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联

            }
            catch (Exception ex)
            {
                return;
            }

        }
        public int getLevel(string st)
        {
            if (st.Contains("5"))
                return 5;
            if (st.Contains("4"))
                return 4;
            if (st.Contains("3"))
                return 3;
            return 0;
        }
        //初衬进度
        public void DrawACHE()
        {
            try
            {
                _prj = Globals.project;//获得目前mainframe里正在运行的项目
                mainFrame = Globals.mainFrame;//获得目前正在运行的mainFrame
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;//获取右幅二维视图
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("ACHE", "施工进度");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("ACHE", "施工进度");


                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.Yellow, SimpleLineStyle.Solid, 1.0);
                sym_fill = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Yellow, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);

                //获取需要绘制的数据对象 Construction -ACHE
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                //获取GPRF数据对象列表

                List<ACHE> objList = Transfer<ACHE>(_gprfDGObjects.objContainer);

                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();

                Dictionary<string, DateTime> latesttime = new Dictionary<string, DateTime>();
                DateTime temp2 = new DateTime(2000, 1, 1, 0, 0, 0);
                latesttime.Add("S1", temp2);
                latesttime.Add("S2", temp2);
                latesttime.Add("S3", temp2);
                latesttime.Add("S4", temp2);
                latesttime.Add("S2XJ", temp2);
                latesttime.Add("S3XJ", temp2);

                //寻找最新时间
                foreach (ACHE obj in objList)
                {
                    if (null != obj.PROG_DATE)
                    {
                        string bd = obj.PROG_NAME;
                        if (latesttime[bd] != null)
                        {
                            DateTime temp1 = Convert.ToDateTime(obj.PROG_DATE);
                            if (DateTime.Compare(latesttime[bd], temp1) < 0)
                                latesttime[bd] = temp1;
                        }
                    }

                }

                //绘制右幅初衬进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "右幅"))
                        continue;

                    string mileage = obj.PROG_CCJD;
                   
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S1") || (obj.PROG_NAME == "S2"))
                    {
                        decimal temp = righttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().startpile;
                        spoint = GetPointBasedOnMileage(temp);
                        if (obj.PROG_END.Split('-').Length > 1)
                        {
                            spoint.mileage = obj.PROG_END.Split('-')[0];
                        }
                        epoint = GetPointBasedOnMileage(res.pilepoint);
                        epoint.mileage = mileage;
                    }
                    else
                    {
                        decimal temp = righttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().endpile;
                        spoint = GetPointBasedOnMileage(res.pilepoint);
                        spoint.mileage = mileage;
                        epoint = GetPointBasedOnMileage(temp);
                        if (obj.PROG_END.Split('-').Length > 1)
                        {
                            epoint.mileage = obj.PROG_END.Split('-')[1];
                        }
                    }
                    if ((spoint == null) || (epoint == null)) continue;
                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc.Add(polygon);              //添加到图元集合

                    #region 3d
                    tunnelSectionList.Add(new Tuple<string, string>(spoint.mileage, epoint.mileage));
                    tunnelPosList.Add(mileage);
                    #endregion
                }

                ////左幅
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "左幅"))
                        continue;

                    string mileage = obj.PROG_CCJD;
                   
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S1") || (obj.PROG_NAME == "S2"))
                    {
                        decimal temp = lefttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().startpile;
                        spoint = GetPointBasedOnMileage(temp);
                        if (obj.PROG_END.Split('-').Length > 1)
                        {
                            spoint.mileage = obj.PROG_END.Split('-')[0];
                        }
                        epoint = GetPointBasedOnMileage(res.pilepoint);
                        epoint.mileage = mileage;
                    }
                    else
                    {
                        decimal temp = lefttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().endpile;
                        spoint = GetPointBasedOnMileage(res.pilepoint);
                        spoint.mileage = mileage;
                        epoint = GetPointBasedOnMileage(temp);
                        if (obj.PROG_END.Split('-').Length > 1)
                        {
                            string[] tempp = obj.PROG_END.Split('-');

                            epoint.mileage = obj.PROG_END.Split('-')[1];
                        }
                    }
                    if ((spoint == null) || (epoint == null)) continue;
                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc_left.Add(polygon);              //添加到图元集合


                    #region 3d
                    tunnelSectionList.Add(new Tuple<string, string>(spoint.mileage, epoint.mileage));
                    tunnelPosList.Add(mileage);
                    #endregion
                }
                //绘制斜井初衬进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "斜井"))
                        continue;

                    string mileage = obj.PROG_CCJD;
                   
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                        continue;
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S2XJ"))
                    {
                        spoint = s2inclinedpoints[0];
                        epoint = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                        epoint.mileage = mileage;
                    }
                    else
                    {
                        epoint = s3inclinedpoints[1];

                        spoint = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                        spoint.mileage = mileage;
                    }
                    if ((spoint == null) || (epoint == null)) continue;

                    //这边以绘制单个长方形为例

                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc.Add(polygon);              //添加到图元集合
                    igc_left.Add(polygon);
                    #region 3d
                    tunnelSectionList.Add(new Tuple<string, string>(spoint.mileage, epoint.mileage));
                    tunnelPosList.Add(mileage);
                    #endregion
                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联

                #region 三维绘制进度
                //SetProgressEvent _event = new SetProgressEvent(UnityEventType.SetProgressEvent);
                //_event.TunnelSectionList = new List<TunnelSection>();
                //foreach (var data in tunnelSectionList)
                //{
                //    _event.TunnelSectionList.Add(new TunnelSection() { startM = data.Item1, endM = data.Item2 });
                //}
                //_event.TunnelPointList = tunnelPosList;
                //U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
                //model.ExcuteCommand(JsonConvert.SerializeObject(_event));
                Globals.tunnelPosList = tunnelPosList;
                Globals.tunnelSectionList = tunnelSectionList;
                Globals.tunnelPosList2 = new List<string>();

                //Domain _constructionDoamin2 = _prj.getDomain("Construction");
                //DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "TPSI").FirstOrDefault();
                //foreach (DGObject obj in _gprfDGObjects2.objContainer)
                //{
                //    //TPSI tpsi = obj as TPSI;
                //    if ((tpsi.TPSI_ZHQJ == null) || (tpsi.TPSI_ZHQJ.Length == 0)) { continue; }
                //    bool _state = tpsi.TPSI_ZGJD == "已完成" ? true : false;
                //    Globals.tunnelPosList2.Add(tpsi.TPSI_ZHQJ.Split('-')[0] + "#" + tpsi.ID.ToString() + "#" + _state.ToString());
                //}

                #endregion
            }
            catch (Exception ex)
            {
                
            }

        }
        //施工进度掌子面标记
        public void DrawACHE_ZZM()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IS3GraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("ACHE_ZZM", "施工进度_掌子面") as IS3GraphicsLayer;
                IS3GraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("ACHE_ZZM", "施工进度_掌子面") as IS3GraphicsLayer;

                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                List<ACHE> objList = Transfer<ACHE>(_gprfDGObjects.objContainer);
                IGraphicCollection igc = NewGraphicCollection();  //图元集合

                Dictionary<string, DateTime> latesttime = new Dictionary<string, DateTime>();
                DateTime temp2 = new DateTime(2000, 1, 1, 0, 0, 0);
                latesttime.Add("S1", temp2);
                latesttime.Add("S2", temp2);
                latesttime.Add("S3", temp2);
                latesttime.Add("S4", temp2);
                latesttime.Add("S2XJ", temp2);
                latesttime.Add("S3XJ", temp2);

                //寻找最新时间
                foreach (ACHE obj in objList)
                {
                    if (null != obj.PROG_DATE)
                    {
                        string bd = obj.PROG_NAME;
                        if (latesttime[bd] != null)
                        {
                            DateTime temp1 = Convert.ToDateTime(obj.PROG_DATE);
                            if (DateTime.Compare(latesttime[bd], temp1) < 0)
                                latesttime[bd] = temp1;
                        }
                    }

                }
                
                //右幅掌子面标识
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "右幅"))
                        continue;
                    string mileage = obj.PROG_SGJD;

                    Pile res = getSectionPos(mileage);
                    Axispoint _point = null;
                    if (res == null)
                    {
                        continue;
                    }
                    if (res.piletype == Piletype.interval)
                    {
                        Axispoint spoint = null;
                        Axispoint epoint = null;


                        if (res.tunnelpart == Tunnelpart.right)
                        {
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                        }
                        if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                        {
                            spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                            epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                        }
                        if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                        {
                            spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                            epoint = GetXJPointBasedOnMileage(res.endpile, "S3");
                        }
                        if ((spoint == null) || (epoint == null)) continue;
                        _point = new Axispoint();
                        _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                        _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                        _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                    }
                    if (res.piletype == Piletype.point)
                    {
                        if (res.tunnelpart == Tunnelpart.right)
                            _point = GetPointBasedOnMileage(res.pilepoint);
                        if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                        {
                            _point = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                        }
                        if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                        {
                            _point = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                        }
                    }

                    if (_point == null)
                        continue;
                    IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                    _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/redflag.png"));

                    IS3Graphic g = new IS3Graphic()
                    {
                        Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                        Symbol = _sym
                    };
                    g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    graphicsLayer.Graphics.Add(g);              //添加到图元集合
                }

                //左幅掌子面标识
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "左幅"))
                        continue;
                    string mileage = obj.PROG_SGJD;

                    Pile res = getSectionPos(mileage);
                    Axispoint _point = null;
                    if (res == null)
                    {
                        continue;
                    }
                    if (res.piletype == Piletype.interval)
                    {
                        Axispoint spoint = null;
                        Axispoint epoint = null;


                        if (res.tunnelpart == Tunnelpart.right)
                        {
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                        }
                        if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                        {
                            spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                            epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                        }
                        if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                        {
                            spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                            epoint = GetXJPointBasedOnMileage(res.endpile, "S3");
                        }
                        if ((spoint == null) || (epoint == null)) continue;
                        _point = new Axispoint();
                        _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                        _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                        _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                    }
                    if (res.piletype == Piletype.point)
                    {
                        if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                        {
                            _point = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                        }
                        else if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                        {
                            _point = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                        }
                        else
                        {
                            _point = GetPointBasedOnMileage(res.pilepoint);
                        }
                    }

                    if (_point == null)
                        continue;
                    IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                    _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/redflag.png"));

                    IS3Graphic g = new IS3Graphic()
                    {
                        Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                        Symbol = _sym
                    };
                    g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    graphicsLayer_left.Graphics.Add(g);              //添加到图元集合
                }
                //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {
               
            }

        }

        //二衬进度
        public void DrawACHE_EC()
        {
            try
            {
                _prj = Globals.project;//获得目前mainframe里正在运行的项目
                mainFrame = Globals.mainFrame;//获得目前正在运行的mainFrame
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;//获取右幅二维视图
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("ACHE_EC", "施工进度_二衬");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("ACHE_EC", "施工进度_二衬");

                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.GreenYellow, SimpleLineStyle.Solid, 1.0);
                sym_fill = Runtime.graphicEngine.newSimpleFillSymbol(Colors.GreenYellow, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);

                //获取需要绘制的数据对象 Construction -ACHE
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                //获取GPRF数据对象列表
                List<ACHE> objList = Transfer<ACHE>(_gprfDGObjects.objContainer);

                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合

                Dictionary<string, DateTime> latesttime = new Dictionary<string, DateTime>();
                DateTime temp2 = new DateTime(2000, 1, 1, 0, 0, 0);
                latesttime.Add("S1", temp2);
                latesttime.Add("S2", temp2);
                latesttime.Add("S3", temp2);
                latesttime.Add("S4", temp2);
                latesttime.Add("S2XJ", temp2);
                latesttime.Add("S3XJ", temp2);

                //寻找最新时间
                foreach (ACHE obj in objList)
                {
                    if (null != obj.PROG_DATE)
                    {
                        string bd = obj.PROG_NAME;
                        if (latesttime[bd] != null)
                        {
                            DateTime temp1 = Convert.ToDateTime(obj.PROG_DATE);
                            if (DateTime.Compare(latesttime[bd], temp1) < 0)
                                latesttime[bd] = temp1;
                        }
                    }

                }

                //绘制右幅二衬进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "右幅"))
                        continue;

                    string mileage = obj.PROG_ECJD;

                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S1") || (obj.PROG_NAME == "S2"))
                    {
                        decimal temp = righttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().startpile;
                        spoint = GetPointBasedOnMileage(temp);
                        epoint = GetPointBasedOnMileage(res.pilepoint);
                    }
                    else
                    {
                        decimal temp = righttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().endpile;
                        spoint = GetPointBasedOnMileage(res.pilepoint);
                        epoint = GetPointBasedOnMileage(temp);
                    }
                    if ((spoint == null) || (epoint == null)) continue;
                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc.Add(polygon);              //添加到图元集合
                }
                //绘制左幅二衬进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "左幅"))
                        continue;

                    string mileage = obj.PROG_ECJD;

                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S1") || (obj.PROG_NAME == "S2"))
                    {
                        decimal temp = lefttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().startpile;
                        spoint = GetPointBasedOnMileage(temp);
                        epoint = GetPointBasedOnMileage(res.pilepoint);
                    }
                    else
                    {
                        decimal temp = lefttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().endpile;
                        spoint = GetPointBasedOnMileage(res.pilepoint);
                        epoint = GetPointBasedOnMileage(temp);
                    }
                    if ((spoint == null) || (epoint == null)) continue;
                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc_left.Add(polygon);              //添加到图元集合
                }

                //绘制斜井二衬进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "斜井"))
                        continue;

                    string mileage = obj.PROG_ECJD;
                    
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                        continue;
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S2XJ"))
                    {
                        spoint = s2inclinedpoints[0];
                        epoint = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                    }
                    else
                    {
                        epoint = s3inclinedpoints[1];
                        spoint = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                    }
                    if ((spoint == null) || (epoint == null)) continue;

                    //这边以绘制单个长方形为例

                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc.Add(polygon);              //添加到图元集合
                    igc_left.Add(polygon);

                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);    //添加到图层
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {
                
            }

        }
        //仰拱进度
        public void DrawACHE_YG()
        {
            try
            {
                _prj = Globals.project;//获得目前mainframe里正在运行的项目
                mainFrame = Globals.mainFrame;//获得目前正在运行的mainFrame
                                              //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;

                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("ACHE_YG", "施工进度_仰拱");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("ACHE_YG", "施工进度_仰拱");

                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.Khaki, SimpleLineStyle.Solid, 1.0);
                sym_fill = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Khaki, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);
                //获取需要绘制的数据对象 Construction -ACHE
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                //获取GPRF数据对象列表
                List<ACHE> objList = Transfer<ACHE>(_gprfDGObjects.objContainer);
                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合

                Dictionary<string, DateTime> latesttime = new Dictionary<string, DateTime>();
                DateTime temp2 = new DateTime(2000, 1, 1, 0, 0, 0);
                latesttime.Add("S1", temp2);
                latesttime.Add("S2", temp2);
                latesttime.Add("S3", temp2);
                latesttime.Add("S4", temp2);
                latesttime.Add("S2XJ", temp2);
                latesttime.Add("S3XJ", temp2);

                //寻找最新时间
                foreach (ACHE obj in objList)
                {
                    if (null != obj.PROG_DATE)
                    {
                        string bd = obj.PROG_NAME;
                        if (latesttime[bd] != null)
                        {
                            DateTime temp1 = Convert.ToDateTime(obj.PROG_DATE);
                            if (DateTime.Compare(latesttime[bd], temp1) < 0)
                                latesttime[bd] = temp1;
                        }
                    }

                }

                //绘制右幅仰拱进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "右幅"))
                        continue;

                    string mileage = obj.PROG_YGJD;
                   
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S1") || (obj.PROG_NAME == "S2"))
                    {
                        decimal temp = righttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().startpile;
                        spoint = GetPointBasedOnMileage(temp);
                        epoint = GetPointBasedOnMileage(res.pilepoint);
                    }
                    else
                    {
                        decimal temp = righttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().endpile;
                        spoint = GetPointBasedOnMileage(res.pilepoint);
                        epoint = GetPointBasedOnMileage(temp);
                    }
                    if ((spoint == null) || (epoint == null)) continue;
                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc.Add(polygon);              //添加到图元集合
                }
                //绘制左幅仰拱进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "左幅"))
                        continue;

                    string mileage = obj.PROG_YGJD;
                   
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S1") || (obj.PROG_NAME == "S2"))
                    {
                        decimal temp = lefttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().startpile;
                        spoint = GetPointBasedOnMileage(temp);
                        epoint = GetPointBasedOnMileage(res.pilepoint);
                    }
                    else
                    {
                        decimal temp = lefttunnel.Where(x => x.sectionnumber == obj.PROG_NAME).FirstOrDefault().endpile;
                        spoint = GetPointBasedOnMileage(res.pilepoint);
                        epoint = GetPointBasedOnMileage(temp);
                    }
                    if ((spoint == null) || (epoint == null)) continue;
                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc_left.Add(polygon);              //添加到图元集合
                }

                //绘制斜井仰拱进度
                foreach (ACHE obj in objList)
                {
                    if ((obj.PROG_DATE != latesttime[obj.PROG_NAME]) || (obj.PROG_LORR != "斜井"))
                        continue;

                    string mileage = obj.PROG_YGJD;
                   
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                        continue;
                    Axispoint spoint;
                    Axispoint epoint;
                    if ((obj.PROG_NAME == "S2XJ"))
                    {
                        spoint = s2inclinedpoints[0];
                        epoint = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                    }
                    else
                    {
                        epoint = s3inclinedpoints[1];
                        spoint = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                    }
                    if ((spoint == null) || (epoint == null)) continue;

                    //这边以绘制单个长方形为例

                    IPointCollection pp = CalculatePoints(spoint, epoint);
                    IGraphic polygon =
                        Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                    polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                    igc.Add(polygon);              //添加到图元集合
                    igc_left.Add(polygon);
                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);    //添加到图层
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {
               
            }

        }

        //绘制右幅施工变更

        public void DrawCHAG()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("CHAG", "施工变更");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("CHAG", "施工变更");
                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.HotPink, SimpleLineStyle.Solid, 1.0);
                sym_fill = Runtime.graphicEngine.newSimpleFillSymbol(Colors.HotPink, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "CHAG").FirstOrDefault();
                //List<CHAG> objList = _gprfDGObjects.objContainer.Cast<CHAG>().ToList();
                List<CHAG> objList = Transfer<CHAG>(_gprfDGObjects.objContainer);
                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合
                foreach (CHAG obj in objList)
                {
                    string mileage = obj.CHAG_CHAI;
                    Pile res = getSectionPos(mileage);
                    if (res == null)
                        continue;
                    //右幅
                    if (res.tunnelpart == Tunnelpart.right)
                    {
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            IPointCollection pp = CalculatePoints(spoint, epoint);
                            IGraphic polygon =
                                Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                            polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc.Add(polygon);              //添加到图元集合
                        }
                        if (res.piletype == Piletype.point)
                        {
                            Axispoint _point = null;
                            _point = GetPointBasedOnMileage(res.pilepoint);
                            if (_point == null) continue;
                            IPointCollection pp = CalculatePoints_triangle(_point);
                            var p1 = pp[0];
                            var p2 = pp[1];
                            var p3 = pp[2];
                            IGraphic triangle =
                                Runtime.graphicEngine.newTriangle(p1, p2, p3);   //由点生成多边形
                            triangle.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc.Add(triangle);              //添加到图元集合

                        }
                        continue;
                    }
                    //左幅
                    if (res.tunnelpart == Tunnelpart.left)
                    {
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            IPointCollection pp = CalculatePoints(spoint, epoint);
                            IGraphic polygon =
                                Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                            polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc_left.Add(polygon);              //添加到图元集合
                        }
                        if (res.piletype == Piletype.point)
                        {
                            Axispoint _point = null;
                            _point = GetPointBasedOnMileage(res.pilepoint);
                            if (_point == null) continue;
                            IPointCollection pp = CalculatePoints_triangle(_point);
                            var p1 = pp[0];
                            var p2 = pp[1];
                            var p3 = pp[2];
                            IGraphic triangle =
                                Runtime.graphicEngine.newTriangle(p1, p2, p3);   //由点生成多边形
                            triangle.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc_left.Add(triangle);              //添加到图元集合
                        }
                        continue;
                    }
                    //斜井
                    if (res.piletype == Piletype.interval)
                    {
                        Axispoint spoint = null;
                        Axispoint epoint = null;
                        if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                        {
                            spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                            epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                        }
                        if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                        {
                            spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                            epoint = GetXJPointBasedOnMileage(res.endpile, "S3");
                        }
                        if ((spoint == null) || (epoint == null)) continue;

                        IPointCollection pp = CalculatePoints(spoint, epoint);
                        IGraphic polygon =
                            Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                        polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        igc.Add(polygon);              //添加到图元集合
                        igc_left.Add(polygon);              //添加到图元集合
                    }
                    if (res.piletype == Piletype.point)
                    {
                        Axispoint _point = null;
                        if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                        {
                            _point = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                        }
                        if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                        {
                            _point = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                        }
                        if (_point == null) continue;

                        IPointCollection pp = CalculatePoints_triangle(_point);

                        var p1 = pp[0];
                        var p2 = pp[1];
                        var p3 = pp[2];
                        IGraphic triangle =
                            Runtime.graphicEngine.newTriangle(p1, p2, p3);   //由点生成多边形
                        triangle.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        igc.Add(triangle);              //添加到图元集合
                        igc_left.Add(triangle);              //添加到图元集合
                    }
                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);    //添加到图层
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {
                
            }

        }
        //绘制右幅第三方抽检

        public void DrawTPSI()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IGraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("TPSI", "第三方抽检");
                IGraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("TPSI", "第三方抽检");
                //渲染样式
                sym_line = Runtime.graphicEngine.newSimpleLineSymbol(Colors.Crimson, SimpleLineStyle.Solid, 1.0);
                sym_fill = Runtime.graphicEngine.newSimpleFillSymbol(Colors.Crimson, SimpleFillStyle.Solid, sym_line);
                renderer = Runtime.graphicEngine.newSimpleRenderer(sym_fill);
                graphicsLayer.setRenderer(renderer);
                graphicsLayer_left.setRenderer(renderer);
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "TPSI").FirstOrDefault();
                //List<TPSI> objList = _gprfDGObjects.objContainer.Cast<TPSI>().ToList();
                List<TPSI> objList = Transfer<TPSI>(_gprfDGObjects.objContainer);
                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合
                foreach (TPSI obj in objList)
                {
                    string mileage = obj.TPSI_ZHQJ;

                    Pile res = getSectionPos(mileage);
                    if (res == null)
                    {
                        continue;
                    }
                    //右幅
                    if (res.tunnelpart == Tunnelpart.right)
                    {
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            IPointCollection pp = CalculatePoints(spoint, epoint);
                            IGraphic polygon =
                                Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                            polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc.Add(polygon);              //添加到图元集合
                        }
                        if (res.piletype == Piletype.point)
                        {
                            Axispoint _point = null;
                            _point = GetPointBasedOnMileage(res.pilepoint);
                            if (_point == null) continue;
                            IPointCollection pp = CalculatePoints_triangle(_point);
                            var p1 = pp[0];
                            var p2 = pp[1];
                            var p3 = pp[2];
                            IGraphic triangle =
                                Runtime.graphicEngine.newTriangle(p1, p2, p3);   //由点生成多边形
                            triangle.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc.Add(triangle);              //添加到图元集合
                        }
                    }
                    //左幅
                    else if (res.tunnelpart == Tunnelpart.left)
                    {
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            IPointCollection pp = CalculatePoints(spoint, epoint);
                            IGraphic polygon =
                                Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                            polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc_left.Add(polygon);              //添加到图元集合
                        }
                        if (res.piletype == Piletype.point)
                        {
                            Axispoint _point = null;
                            _point = GetPointBasedOnMileage(res.pilepoint);
                            if (_point == null) continue;
                            IPointCollection pp = CalculatePoints_triangle(_point);
                            var p1 = pp[0];
                            var p2 = pp[1];
                            var p3 = pp[2];
                            IGraphic triangle =
                                Runtime.graphicEngine.newTriangle(p1, p2, p3);   //由点生成多边形
                            triangle.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc_left.Add(triangle);              //添加到图元集合
                        }
                    }
                    else
                    {
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            //斜井
                            if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                            {
                                spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                                epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                            }
                            if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                            {
                                spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                                epoint = GetXJPointBasedOnMileage(res.endpile, "S3");
                            }
                            if ((spoint == null) || (epoint == null)) continue;

                            IPointCollection pp = CalculatePoints(spoint, epoint);
                            IGraphic polygon =
                                Runtime.graphicEngine.newPolygon(pp);   //由点生成多边形
                            polygon.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc.Add(polygon);              //添加到图元集合
                            igc_left.Add(polygon);
                        }
                        if (res.piletype == Piletype.point)
                        {
                            Axispoint _point = null;
                            if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                            {
                                _point = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                            }
                            if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                            {
                                _point = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                            }
                            if (_point == null) continue;
                            IPointCollection pp = CalculatePoints_triangle(_point);
                            var p1 = pp[0];
                            var p2 = pp[1];
                            var p3 = pp[2];
                            IGraphic triangle =
                                Runtime.graphicEngine.newTriangle(p1, p2, p3);   //由点生成多边形
                            triangle.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                            igc.Add(triangle);              //添加到图元集合
                            igc_left.Add(triangle);              //添加到图元集合
                        }
                    }
                }
                graphicsLayer.addGraphics(igc);    //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                graphicsLayer_left.addGraphics(igc_left);    //添加到图层
                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {

            }

        }
        //绘制图片资料图层
        public void DrawTPZL()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IS3GraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("TPZL", "图片资料") as IS3GraphicsLayer;
                IS3GraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("TPZL", "图片资料") as IS3GraphicsLayer;
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "TPZL").FirstOrDefault();
                //List<TPSI> objList = _gprfDGObjects.objContainer.Cast<TPZL>().ToList();
                List<TPZL> objList = Transfer<TPZL>(_gprfDGObjects.objContainer);
                IGraphicCollection igc = NewGraphicCollection();  //图元集合
                IGraphicCollection igc_left = NewGraphicCollection();  //图元集合
                foreach (TPZL obj in objList)
                {
                    string mileage = obj.TPZL_ZHQJ;
                    Pile res = getSectionPos(mileage);

                    //右幅
                    if (res.tunnelpart == Tunnelpart.right)
                    {
                        Axispoint _point = null;
                        if (res == null)
                            continue;
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            _point = new Axispoint();
                            _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                            _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                            _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                        }
                        if (res.piletype == Piletype.point)
                            _point = GetPointBasedOnMileage(res.pilepoint);
                        if (_point == null)
                            continue;
                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/picicon.png"));
                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer.Graphics.Add(g);              //添加到图元集合
                    }
                    //左幅
                    else if (res.tunnelpart == Tunnelpart.left)
                    {
                        Axispoint _point = null;
                        if (res == null)
                            continue;
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            _point = new Axispoint();
                            _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                            _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                            _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                        }
                        if (res.piletype == Piletype.point)
                        {
                            _point = GetPointBasedOnMileage(res.pilepoint);
                        }
                        if (_point == null)
                            continue;
                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/picicon.png"));
                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer_left.Graphics.Add(g);              //添加到图元集合
                    }
                    //斜井
                    else
                    {
                        Axispoint _point = null;
                        if (res == null)
                            continue;
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                            {
                                spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                                epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                            }
                            if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                            {
                                spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                                epoint = GetXJPointBasedOnMileage(res.endpile, "S3");
                            }
                            if ((spoint == null) || (epoint == null)) continue;
                            _point = new Axispoint();
                            _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                            _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                            _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                        }
                        if (res.piletype == Piletype.point)
                        {
                            if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                                _point = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                            if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                                _point = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                        }
                        if (_point == null)
                            continue;
                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/picicon.png"));
                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer.Graphics.Add(g);              //添加到图元集合
                        graphicsLayer_left.Graphics.Add(g);              //添加到图元集合
                    }
                }
                //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {

            }

        }
        //绘制视频资料图层
        public void DrawSPZL()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IS3GraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("SPZL", "视频资料") as IS3GraphicsLayer;
                IS3GraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("SPZL", "视频资料") as IS3GraphicsLayer;
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "SPZL").FirstOrDefault();
                List<SPZL> objList = Transfer<SPZL>(_gprfDGObjects.objContainer);
                foreach (SPZL obj in objList)
                {
                    string mileage = obj.SPZL_ZHQJ;
                    Pile res = getSectionPos(mileage);
                    //右幅
                    if (res.tunnelpart == Tunnelpart.right)
                    {
                        Axispoint _point = null;
                        if (res == null)
                            continue;
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            _point = new Axispoint();
                            _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                            _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                            _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                        }
                        if (res.piletype == Piletype.point)
                            _point = GetPointBasedOnMileage(res.pilepoint);
                        if (_point == null)
                            continue;
                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/videoicon.png"));
                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer.Graphics.Add(g);              //添加到图元集合
                    }
                    //左幅
                    else if (res.tunnelpart == Tunnelpart.left)
                    {
                        Axispoint _point = null;
                        if (res == null)
                            continue;
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            spoint = GetPointBasedOnMileage(res.startpile);
                            epoint = GetPointBasedOnMileage(res.endpile);
                            if ((spoint == null) || (epoint == null)) continue;
                            _point = new Axispoint();
                            _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                            _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                            _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                        }
                        if (res.piletype == Piletype.point)
                        {
                            _point = GetPointBasedOnMileage(res.pilepoint);
                        }
                        if (_point == null)
                            continue;
                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/videoicon.png"));
                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer_left.Graphics.Add(g);              //添加到图元集合
                    }
                    //斜井
                    else
                    {
                        Axispoint _point = null;
                        if (res == null)
                            continue;
                        if (res.piletype == Piletype.interval)
                        {
                            Axispoint spoint = null;
                            Axispoint epoint = null;
                            if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                            {
                                spoint = GetXJPointBasedOnMileage(res.startpile, "S2");
                                epoint = GetXJPointBasedOnMileage(res.endpile, "S2");
                            }
                            if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                            {
                                spoint = GetXJPointBasedOnMileage(res.startpile, "S3");
                                epoint = GetXJPointBasedOnMileage(res.endpile, "S3");
                            }
                            if ((spoint == null) || (epoint == null)) continue;
                            _point = new Axispoint();
                            _point.pointx = (spoint.pointx + epoint.pointx) / 2;
                            _point.pointy = (spoint.pointy + epoint.pointy) / 2;
                            _point.pointz = (spoint.pointz + epoint.pointz) / 2;
                        }
                        if (res.piletype == Piletype.point)
                        {
                            if (res.tunnelpart == Tunnelpart.s2inclinedshaft)
                                _point = GetXJPointBasedOnMileage(res.pilepoint, "S2");
                            if (res.tunnelpart == Tunnelpart.s3inclinedshaft)
                                _point = GetXJPointBasedOnMileage(res.pilepoint, "S3");
                        }
                        if (_point == null)
                            continue;
                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/videoicon.png"));
                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(_point.pointx), Convert.ToDouble(_point.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer.Graphics.Add(g);              //添加到图元集合
                        graphicsLayer_left.Graphics.Add(g);              //添加到图元集合
                    }
                }
                //添加到图层
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {

            }

        }

        //绘制风险标识
        public void RiskIdentification()
        {
            try
            {
                _prj = Globals.project;
                mainFrame = Globals.mainFrame;
                //获取要添加图元的视图view
                _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
                _inputView_left = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
                //获取坐标系
                isp = _inputView.spatialReference;
                //新建一个图层，用于绘制
                IS3GraphicsLayer graphicsLayer = Runtime.graphicEngine.newGraphicsLayer("RiskIdfy", "风险标识") as IS3GraphicsLayer;
                IS3GraphicsLayer graphicsLayer_left = Runtime.graphicEngine.newGraphicsLayer("RiskIdfy", "风险标识") as IS3GraphicsLayer;
                //获取需要绘制的数据对象 Construction -GRPF
                _constructionDoamin = _prj.getDomain("Construction");
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "TFSI").FirstOrDefault();

                //List<GPRF> objList = _gprfDGObjects.objContainer.Cast<GPRF>().ToList();
                List<TFSI> objList = Transfer<TFSI>(_gprfDGObjects.objContainer);
                _gprfDGObjects = _constructionDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
                List<ACHE> ache_objList = Transfer<ACHE>(_gprfDGObjects.objContainer);

                DateTime latesttime = new DateTime(2000, 1, 1, 0, 0, 0);
                //寻找施工进度最新时间
                foreach (ACHE obj in ache_objList)
                {
                    if (null != obj.PROG_DATE)
                    {
                        DateTime temp = Convert.ToDateTime(obj.PROG_DATE);
                        if (DateTime.Compare(latesttime, temp) < 0)
                            latesttime = temp;
                    }

                }
                //获取右幅掌子面坐标
                List<decimal> facelist_cord = new List<decimal>();
                foreach (ACHE obj in ache_objList)
                {
                    if (obj.PROG_DATE == latesttime)
                    {
                        string st = obj.PROG_SGJD;
                        Pile judgepile = DrawObjects.getSectionPos(st);
                        if ((null != judgepile) && (judgepile.tunnelpart == Tunnelpart.right))
                            facelist_cord.Add(judgepile.pilepoint);
                    }
                }
                facelist_cord.Sort();


                foreach (TFSI obj in objList)
                {
                    string _stability = obj.TFSI_RISC;
                    string mileage = obj.TFSI_MILE;
                    if (!_stability.Contains("极差") && !_stability.Contains("大坍塌"))
                        continue;

                    Pile res = getSectionPos(mileage);
                    //右幅
                    if (res.tunnelpart == Tunnelpart.right)
                    {
                        if ((res == null) || (res.piletype != Piletype.interval))
                        {
                            continue;
                        }
                        if ((res.startpile < facelist_cord[0]) || (res.endpile > facelist_cord[1]))
                            continue;

                        Axispoint spoint;
                        Axispoint epoint;
                        spoint = GetPointBasedOnMileage(res.startpile);
                        epoint = GetPointBasedOnMileage(res.endpile);
                        if ((spoint == null) || (epoint == null)) continue;
                        epoint.pointx = (spoint.pointx + epoint.pointx) / 2;
                        epoint.pointy = (spoint.pointy + epoint.pointy) / 2;
                        epoint.pointz = (spoint.pointz + epoint.pointz) / 2;

                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/riskidfy_alert.png"));

                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(epoint.pointx), Convert.ToDouble(epoint.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer.Graphics.Add(g);              //添加到图元集合
                    }
                    //左幅
                    if (res.tunnelpart == Tunnelpart.left)
                    {
                        if ((res == null) || (res.piletype != Piletype.interval))
                        {
                            continue;
                        }
                        if ((res.startpile < facelist_cord[0]) || (res.endpile > facelist_cord[1]))
                            continue;

                        Axispoint spoint;
                        Axispoint epoint;
                        spoint = GetPointBasedOnMileage(res.startpile);
                        epoint = GetPointBasedOnMileage(res.endpile);
                        if ((spoint == null) || (epoint == null)) continue;
                        epoint.pointx = (spoint.pointx + epoint.pointx) / 2;
                        epoint.pointy = (spoint.pointy + epoint.pointy) / 2;
                        epoint.pointz = (spoint.pointz + epoint.pointz) / 2;

                        IS3PictureMarkerSymbol _sym = new IS3PictureMarkerSymbol();
                        _sym.SetSourceAsync(new Uri("pack://application:,,,/RTM_Tool;component/Images/riskidfy_alert.png"));

                        IS3Graphic g = new IS3Graphic()
                        {
                            Geometry = new IS3MapPoint(Convert.ToDouble(epoint.pointx), Convert.ToDouble(epoint.pointz)),
                            Symbol = _sym
                        };
                        g.Attributes["ID"] = obj.ID;  //设置图元的ID属性，用于与数据对象关联，这里应该设置为与绘制的GPRF.id
                        graphicsLayer_left.Graphics.Add(g);              //添加到图元集合
                    }
                }
                _inputView.addLayer(graphicsLayer);        //添加图层到view视图
                graphicsLayer.syncObjects(objList);   //图元和对象列表关联

                _inputView_left.addLayer(graphicsLayer_left);        //添加图层到view视图
                graphicsLayer_left.syncObjects(objList);   //图元和对象列表关联
            }
            catch (Exception ex)
            {

            }

        }
        public IPointCollection CalculatePoints(Axispoint pt1, Axispoint pt2)
        {
            IPointCollection pp = NewPointCollection();
            decimal _thickness = 3;
            double z1 = Convert.ToDouble(pt1.pointz - _thickness / 2);
            double z2 = Convert.ToDouble(pt1.pointz + _thickness / 2);
            double z3 = Convert.ToDouble(pt2.pointz + _thickness / 2);
            double z4 = Convert.ToDouble(pt2.pointz - _thickness / 2);
            double _x1 = Convert.ToDouble(pt1.pointx);
            double _x2 = Convert.ToDouble(pt2.pointx);
            var p1 = Runtime.geometryEngine.newMapPoint(_x1, z1, isp);
            var p2 = Runtime.geometryEngine.newMapPoint(_x1, z2, isp);
            var p3 = Runtime.geometryEngine.newMapPoint(_x2, z3, isp);
            var p4 = Runtime.geometryEngine.newMapPoint(_x2, z4, isp);
            pp.Add(p1);
            pp.Add(p2);
            pp.Add(p3);
            pp.Add(p4);
            return pp;
        }
        public IPointCollection CalculatePoints_triangle(Axispoint pt)
        {
            IPointCollection pp = NewPointCollection();
            decimal _thickness = 3;
            double z1 = Convert.ToDouble(pt.pointz) + Convert.ToDouble(_thickness) / Math.Sqrt(3);
            double z2 = Convert.ToDouble(pt.pointz) - Convert.ToDouble(_thickness) / Math.Sqrt(12);
            double _x1 = Convert.ToDouble(pt.pointx);
            double _x2 = Convert.ToDouble(pt.pointx - _thickness / 2);
            double _x3 = Convert.ToDouble(pt.pointx + _thickness / 2);
            var p1 = Runtime.geometryEngine.newMapPoint(_x1, z1, isp);
            var p2 = Runtime.geometryEngine.newMapPoint(_x2, z2, isp);
            var p3 = Runtime.geometryEngine.newMapPoint(_x3, z2, isp);
            pp.Add(p1);
            pp.Add(p2);
            pp.Add(p3);
            return pp;
        }

        public Axispoint GetPointBasedOnMileage(decimal mileage)
        {
            int i = 0;
            while (i < axispoints.Count - 1)
            {
                decimal t1 = getSectionPos(axispoints[i].mileage).pilepoint;
                decimal t2 = getSectionPos(axispoints[i + 1].mileage).pilepoint;
                if ((t1 <= mileage) && (t2 >= mileage))
                {
                    decimal tx = (mileage - t1) / (t2 - t1) * (axispoints[i + 1].pointx - axispoints[i].pointx) + axispoints[i].pointx;
                    decimal ty = (mileage - t1) / (t2 - t1) * (axispoints[i + 1].pointy - axispoints[i].pointy) + axispoints[i].pointy;
                    decimal tz = (mileage - t1) / (t2 - t1) * (axispoints[i + 1].pointz - axispoints[i].pointz) + axispoints[i].pointz;
                    Axispoint res = new Axispoint(tx, ty, tz, "Caculate Point");
                    return res;
                }

                i++;
            }

            return null;
        }

        //读取轴线点坐标及里程
        public void Loadcsvfile()
        {
            try
            {
                string exeLocation = System.IO.Directory.GetCurrentDirectory();
                string csvDestnationPath = "c:\\LaoYingData\\draw";
                if (!Directory.Exists(csvDestnationPath))
                    return;
                csvDestnationPath = csvDestnationPath + "\\axis.csv";
                StreamReader sr = new StreamReader(csvDestnationPath, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0) continue;
                    string[] str = line.Split(',');
                    decimal x = Convert.ToDecimal(str[1]);
                    decimal y = Convert.ToDecimal(str[2]);
                    decimal z = Convert.ToDecimal(str[3]);
                    string mileage = str[0];
                    Axispoint temp = new Axispoint(x, y, z, mileage);
                    axispoints.Add(temp);
                    //List<decimal> res = getSectionPos(mileage);
                    //Console.WriteLine("{0} {1}  ", res[0], res[1]);
                    //Console.WriteLine("{0}  ", res[0]);
                }
                //Console.ReadLine();
            }
            catch (Exception ex)
            {

            }

        }

        //针对里程桩号分隔符为'-'的里程获取方法
        public static Pile getSectionPos(string sp)
        {
            if ((sp == null) || (!sp.Contains("K"))) return null;
            Pile _pile = new Pile();
            string _tunnelpart = sp.Split('K')[0];
            switch (_tunnelpart)
            {
                case "Y":
                    _pile.tunnelpart = Tunnelpart.right;
                    break;
                case "Z":
                    _pile.tunnelpart = Tunnelpart.left;
                    break;
                case "LX":
                    _pile.tunnelpart = Tunnelpart.s3inclinedshaft;
                    break;
                case "BX":
                    _pile.tunnelpart = Tunnelpart.s2inclinedshaft;
                    break;
                default:
                    _pile.tunnelpart = Tunnelpart.right;
                    break;
            }
            string st1, st2, t1, t2, t3;
            string[] str;
            decimal m1, m2, restemp;
            if (sp.Contains("-"))
            {
                _pile.piletype = Piletype.interval;
                //计算起始桩号
                str = sp.Split('-');
                st1 = str[0];
                st2 = str[1];
                str = st1.Split('+');
                t1 = str[0];
                t2 = str[1];
                str = t1.Split('K');
                t3 = str[1];
                m1 = Convert.ToDecimal(t3);
                m2 = Convert.ToDecimal(t2);
                restemp = m1 * 1000 + m2;
                _pile.startpile = restemp;

                //计算终止桩号
                str = st2.Split('+');
                t1 = str[0];
                t2 = str[1];
                str = t1.Split('K');
                t3 = str[1];
                m1 = Convert.ToDecimal(t3);
                m2 = Convert.ToDecimal(t2);
                restemp = m1 * 1000 + m2;
                _pile.endpile = restemp;
            }
            else
            {
                _pile.piletype = Piletype.point;
                str = sp.Split('+');
                t1 = str[0];
                t2 = str[1];
                str = t1.Split('K');
                t3 = str[1];
                m1 = Convert.ToDecimal(t3);
                m2 = Convert.ToDecimal(t2);
                restemp = m1 * 1000 + m2;
                _pile.pilepoint = restemp;
            }

            return _pile;
        }


        #region helper funtions
        static IMapPoint NewMapPoint(double x, double y)
        {
            return Runtime.geometryEngine.newMapPoint(x, y);
        }
        static IGraphic NewTriangle(IMapPoint p1, IMapPoint p2, IMapPoint p3)
        {
            return Runtime.graphicEngine.newTriangle(p1, p2, p3);
        }
        static IGraphic NewQuadrilateral(IMapPoint p1, IMapPoint p2, IMapPoint p3, IMapPoint p4)
        {
            return Runtime.graphicEngine.newQuadrilateral(p1, p2, p3, p4);
        }
        static IGraphic NewPentagon(IMapPoint p1, IMapPoint p2, IMapPoint p3, IMapPoint p4, IMapPoint p5)
        {
            return Runtime.graphicEngine.newPentagon(p1, p2, p3, p4, p5);
        }
        static IGraphic NewPolygon(IPointCollection part)
        {
            return Runtime.graphicEngine.newPolygon(part);
        }
        static IPointCollection NewPointCollection()
        {
            return Runtime.geometryEngine.newPointCollection();
        }
        static IGraphicCollection NewGraphicCollection()
        {
            return Runtime.graphicEngine.newGraphicCollection();
        }
        static ISymbol GetDefaultFillSymbols(int index)
        {
            return GraphicsUtil.GetDefaultFillSymbols(index);
        }

        #endregion
    }
}
