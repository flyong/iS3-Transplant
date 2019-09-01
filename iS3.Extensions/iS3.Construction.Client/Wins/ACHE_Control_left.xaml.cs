using iS3.Core.Client;
using iS3.Core.Model;
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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using iS3.Construction.Model;
using RTM_Tool;
namespace iS3.Construction.Client.Wins
{
    /// <summary>
    /// ACHE_Control.xaml 的交互逻辑
    /// </summary>
    public partial class ACHE_Control_left : UserControl, IObjsControl
    {
        public string temp;
        public string filepic;
        public int _width, _height, _length;
        //S1~S4标实际进度比例
        public float[] ccdegree, ecdegree, ygdegree;
        public float[] ccdegree_plan, ecdegree_plan, ygdegree_plan;
        public float[,] plandegree;
        Pile ccres, ecres, ygres;
        public Project _prj { get; set; }
        public IMainFrame mainFrame { get; set; }
        public Domain _currentDoamin { get; set; }
        public DGObjects _getDGObjects { get; set; }
        public List<ACHE> ache_objList { get; set; }
        public List<SCHE> sche_objList { get; set; }
        public List<string> ache_colors;
        public string pilebackcolor;

        public ACHE_Control_left(List<DGObject> objs)
        {
            InitializeComponent();
            Loaded += ACHE_Control_Loaded;

            //new iS3Symbol() { colorName = "Yellow", label = "初衬", symbolType = SymbolType.Rectangle },
            //new iS3Symbol() { colorName = "GreenYellow", label = "二衬", symbolType = SymbolType.Rectangle },
            //new iS3Symbol() { colorName = "Khaki", label = "仰拱", symbolType = SymbolType.Rectangle },


        }
        public List<T> Transfer<T>(List<DGObject> objList) where T : class
        {
            List<T> list = new List<T>();
            foreach (DGObject _obj in objList)
            {
                list.Add(_obj as T);
            }
            return list;
        }

        private void ACHE_Control_Loaded(object sender, RoutedEventArgs e)
        {
            _prj = Globals.project;
            mainFrame = Globals.mainFrame;
            _currentDoamin = _prj.getDomain("Construction");
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
            ache_objList = Transfer<ACHE>(_getDGObjects.objContainer);
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "SCHE").FirstOrDefault();
            sche_objList = Transfer<SCHE>(_getDGObjects.objContainer);
            DateTime latesttime = new DateTime(2000, 1, 1, 0, 0, 0);
            //寻找最新时间
            foreach (ACHE obj in ache_objList)
            {
                if (null != obj.PROG_DATE)
                {
                    DateTime temp = Convert.ToDateTime(obj.PROG_DATE);
                    if (DateTime.Compare(latesttime, temp) < 0)
                        latesttime = temp;
                }

            }
            //计算各个实际进度比例
            ccdegree = new float[4];
            ecdegree = new float[4];
            ygdegree = new float[4];
            foreach (ACHE obj in ache_objList)
            {
                if ((obj.PROG_DATE != latesttime) || (obj.PROG_LORR != "左幅"))
                    continue;
                ccres = DrawObjects.getSectionPos(obj.PROG_CCJD);
                ecres = DrawObjects.getSectionPos(obj.PROG_ECJD);
                ygres = DrawObjects.getSectionPos(obj.PROG_YGJD);
                switch (obj.PROG_NAME)
                {
                    case ("S1"):
                        if (ccres == null)
                            ccdegree[0] = 0;
                        else
                            ccdegree[0] = Convert.ToSingle(ccres.pilepoint - 1440) / (4300 - 1440);
                        if (ecres == null)
                            ecdegree[0] = 0;
                        else
                            ecdegree[0] = Convert.ToSingle(ecres.pilepoint - 1440) / (4300 - 1440);
                        if (ygres == null)
                            ygdegree[0] = 0;
                        else
                            ygdegree[0] = Convert.ToSingle(ygres.pilepoint - 1440) / (4300 - 1440);
                        break;
                    case ("S2"):
                        if (ccres == null)
                            ccdegree[1] = 0;
                        else
                            ccdegree[1] = Convert.ToSingle(ccres.pilepoint - 4300) / (7200 - 4300);
                        if (ecres == null)
                            ecdegree[1] = 0;
                        else
                            ecdegree[1] = Convert.ToSingle(ecres.pilepoint - 4300) / (7200 - 4300);
                        if (ygres == null)
                            ygdegree[1] = 0;
                        else
                            ygdegree[1] = Convert.ToSingle(ygres.pilepoint - 4300) / (7200 - 4300);
                        break;
                    case ("S3"):
                        if (ccres == null)
                            ccdegree[2] = 0;
                        else
                            ccdegree[2] = Convert.ToSingle(ccres.pilepoint - 10000) / (7200 - 10000);
                        if (ecres == null)
                            ecdegree[2] = 0;
                        else
                            ecdegree[2] = Convert.ToSingle(ecres.pilepoint - 10000) / (7200 - 10000);
                        if (ygres == null)
                            ygdegree[2] = 0;
                        else
                            ygdegree[2] = Convert.ToSingle(ygres.pilepoint - 10000) / (7200 - 10000);
                        break;
                    case ("S4"):
                        if (ccres == null)
                            ccdegree[3] = 0;
                        else
                            ccdegree[3] = Convert.ToSingle(ccres.pilepoint - 12995) / (10000 - 12995);
                        if (ecres == null)
                            ecdegree[3] = 0;
                        else
                            ecdegree[3] = Convert.ToSingle(ecres.pilepoint - 12995) / (10000 - 12995);
                        if (ygres == null)
                            ygdegree[3] = 0;
                        else
                            ygdegree[3] = Convert.ToSingle(ygres.pilepoint - 12995) / (10000 - 12995);
                        break;
                    default:
                        return;
                }

            }

            plandegree = new float[5, 4];
            //计算计划进度比例
            foreach (SCHE obj in sche_objList)
            {
                if ((obj.PROG_DATE != latesttime) || (obj.PROG_LORR != "左幅"))
                    continue;
                ccres = DrawObjects.getSectionPos(obj.PROG_CCJD);
                ecres = DrawObjects.getSectionPos(obj.PROG_ECJD);
                ygres = DrawObjects.getSectionPos(obj.PROG_YGJD);
                switch (obj.PROG_NAME)
                {
                    case ("S1"):
                        if (ccres == null)
                            plandegree[1, 1] = 0;
                        else
                            plandegree[1, 1] = Convert.ToSingle(ccres.pilepoint - 1440) / (4300 - 1440);
                        if (ecres == null)
                            plandegree[1, 2] = 0;
                        else
                            plandegree[1, 2] = Convert.ToSingle(ecres.pilepoint - 1440) / (4300 - 1440);
                        if (ygres == null)
                            plandegree[1, 3] = 0;
                        else
                            plandegree[1, 3] = Convert.ToSingle(ygres.pilepoint - 1440) / (4300 - 1440);
                        break;
                    case ("S2"):
                        if (ccres == null)
                            plandegree[2, 1] = 0;
                        else
                            plandegree[2, 1] = Convert.ToSingle(ccres.pilepoint - 4300) / (7200 - 4300);
                        if (ecres == null)
                            plandegree[2, 2] = 0;
                        else
                            plandegree[2, 2] = Convert.ToSingle(ecres.pilepoint - 4300) / (7200 - 4300);
                        if (ygres == null)
                            plandegree[2, 3] = 0;
                        else
                            plandegree[2, 3] = Convert.ToSingle(ygres.pilepoint - 4300) / (7200 - 4300);
                        break;
                    case ("S3"):
                        if (ccres == null)
                            plandegree[3, 1] = 0;
                        else
                            plandegree[3, 1] = Convert.ToSingle(ccres.pilepoint - 10000) / (7200 - 10000);
                        if (ecres == null)
                            plandegree[3, 2] = 0;
                        else
                            plandegree[3, 2] = Convert.ToSingle(ecres.pilepoint - 10000) / (7200 - 10000);
                        if (ygres == null)
                            plandegree[3, 3] = 0;
                        else
                            plandegree[3, 3] = Convert.ToSingle(ygres.pilepoint - 10000) / (7200 - 10000);
                        break;
                    case ("S4"):
                        if (ccres == null)
                            plandegree[4, 1] = 0;
                        else
                            plandegree[4, 1] = Convert.ToSingle(ccres.pilepoint - 12995) / (10000 - 12995);
                        if (ecres == null)
                            plandegree[4, 2] = 0;
                        else
                            plandegree[4, 2] = Convert.ToSingle(ecres.pilepoint - 12995) / (10000 - 12995);
                        if (ygres == null)
                            plandegree[4, 3] = 0;
                        else
                            plandegree[4, 3] = Convert.ToSingle(ygres.pilepoint - 12995) / (10000 - 12995);
                        break;
                    default:
                        return;
                }

            }

            ache_colors = new List<string>() { "Yellow", "GreenYellow", "Khaki" };
            pilebackcolor = "Gray";

            S1_draw();
            S2_draw();
            S3_draw();
            S4_draw();

        }

        public Bitmap drawpic(string frontcolor, string backcolor, float currentdegree, int length)
        {
            //创建一个bitmap实例
            if (length <= 0)
                return null;
            Bitmap objbitmap = new Bitmap(length, length);
            Graphics objgraphics = Graphics.FromImage(objbitmap);
            //画刷颜色定义
            Random rnd = new Random();
            List<SolidBrush> colors = new List<SolidBrush>();
            System.Drawing.Color fill1 = ColorTranslator.FromHtml(frontcolor);
            System.Drawing.Color fill2 = ColorTranslator.FromHtml(backcolor);
            colors.Add(new SolidBrush(fill1));
            colors.Add(new SolidBrush(fill2));
            Rectangle pierect = new Rectangle(0, 0, length, length);
            //画一个白色背景
            //  objgraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);

            // 两条射线，第一条是从 x 轴沿顺时针方向旋转到扇形区第一个边所测得的角度；第二条是从 startAngle 参数沿顺时针方向旋转到扇形区第二个边所测得的角度
            objgraphics.FillPie((SolidBrush)colors[0], pierect, 0.0F, currentdegree * 360);
            objgraphics.FillPie((SolidBrush)colors[1], pierect, currentdegree * 360, 360 - currentdegree * 360);

            // objbitmap.Save(sp, ImageFormat.Png);
            return objbitmap;
        }


        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }

            return bitmapImage;
        }

        public void S1_draw()
        {
            //初衬进度
            System.Windows.Controls.Image simpleImage = new System.Windows.Controls.Image();
            _width = (int)Container1_cc.ActualWidth;
            _height = (int)Container1_cc.ActualHeight;
            _length = Math.Min(_width, _height);

            Bitmap _temp = drawpic(ache_colors[0], pilebackcolor, ccdegree[0], _length);
            if (_temp == null)
                return;
            BitmapImage bi = BitmapToBitmapImage(_temp);

            // Set the image source.
            simpleImage.Source = bi;
            Canvas.SetLeft(simpleImage, (_width - _length) / 2);
            Canvas.SetTop(simpleImage, (_height - _length) / 2 + 10);
            Container1_cc.Children.Add(simpleImage);
            if (ccdegree[0] < plandegree[1, 1])
            {
                temp = "滞后";
                text1_cc.Foreground=new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text1_cc.Text = (ccdegree[0] * 100).ToString("F1") + "%\n" + temp;

            //二衬进度
            System.Windows.Controls.Image simpleImage2 = new System.Windows.Controls.Image();
            _width = (int)Container1_ec.ActualWidth;
            _height = (int)Container1_ec.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp2 = drawpic(ache_colors[1], pilebackcolor, ecdegree[0], _length);
            BitmapImage bi2 = BitmapToBitmapImage(_temp2);
            // Set the image source.
            simpleImage2.Source = bi2;
            Canvas.SetLeft(simpleImage2, (_width - _length) / 2);
            Canvas.SetTop(simpleImage2, (_height - _length) / 2 + 10);
            Container1_ec.Children.Add(simpleImage2);

            if (ecdegree[0] < plandegree[1, 2])
            {
                temp = "滞后";
                text1_ec.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text1_ec.Text = (ecdegree[0] * 100).ToString("F1") + "%\n" + temp;


            //仰拱进度
            System.Windows.Controls.Image simpleImage3 = new System.Windows.Controls.Image();
            _width = (int)Container1_yg.ActualWidth;
            _height = (int)Container1_yg.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp3 = drawpic(ache_colors[2], pilebackcolor, ygdegree[0], _length);
            BitmapImage bi3 = BitmapToBitmapImage(_temp3);
            // Set the image source.
            simpleImage3.Source = bi3;
            Canvas.SetLeft(simpleImage3, (_width - _length) / 2);
            Canvas.SetTop(simpleImage3, (_height - _length) / 2 + 10);
            Container1_yg.Children.Add(simpleImage3);
            if (ygdegree[0] < plandegree[1, 3])
            {
                temp = "滞后";
                text1_yg.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text1_yg.Text = (ygdegree[0] * 100).ToString("F1") + "%\n"+temp;
        }
        public void S2_draw()
        {
            //初衬进度
            System.Windows.Controls.Image simpleImage = new System.Windows.Controls.Image();
            _width = (int)Container2_cc.ActualWidth;
            _height = (int)Container2_cc.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp = drawpic(ache_colors[0], pilebackcolor, ccdegree[1], _length);
            if (_temp == null)
                return;
            BitmapImage bi = BitmapToBitmapImage(_temp);

            // Set the image source.
            simpleImage.Source = bi;
            Canvas.SetLeft(simpleImage, (_width - _length) / 2);
            Canvas.SetTop(simpleImage, (_height - _length) / 2 + 10);
            Container2_cc.Children.Add(simpleImage);
            if (ccdegree[1] < plandegree[2,1] )
            {
                temp = "滞后";
                text2_cc.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text2_cc.Text = (ccdegree[1] * 100).ToString("F1") + "%\n"+temp;


            //二衬进度
            System.Windows.Controls.Image simpleImage2 = new System.Windows.Controls.Image();
            _width = (int)Container2_ec.ActualWidth;
            _height = (int)Container2_ec.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp2 = drawpic(ache_colors[1], pilebackcolor, ecdegree[1], _length);
            BitmapImage bi2 = BitmapToBitmapImage(_temp2);

            // Set the image source.
            simpleImage2.Source = bi2;
            Canvas.SetLeft(simpleImage2, (_width - _length) / 2);
            Canvas.SetTop(simpleImage2, (_height - _length) / 2 + 10);
            Container2_ec.Children.Add(simpleImage2);
            if (ecdegree[1] < plandegree[2, 2])
            {
                temp = "滞后";
                text2_ec.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text2_ec.Text = (ecdegree[1] * 100).ToString("F1") + "%\n"+temp;


            //仰拱进度
            System.Windows.Controls.Image simpleImage3 = new System.Windows.Controls.Image();
            _width = (int)Container2_yg.ActualWidth;
            _height = (int)Container2_yg.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp3 = drawpic(ache_colors[2], pilebackcolor, ygdegree[1], _length);
            BitmapImage bi3 = BitmapToBitmapImage(_temp3);
            // Set the image source.
            simpleImage3.Source = bi3;
            Canvas.SetLeft(simpleImage3, (_width - _length) / 2);
            Canvas.SetTop(simpleImage3, (_height - _length) / 2 + 10);
            Container2_yg.Children.Add(simpleImage3);
            if (ygdegree[1] < plandegree[2, 3])
            {
                temp = "滞后";
                text2_yg.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text2_yg.Text = (ygdegree[1] * 100).ToString("F1") + "%\n"+temp;
        }
        public void S3_draw()
        {
            //初衬进度
            System.Windows.Controls.Image simpleImage = new System.Windows.Controls.Image();
            _width = (int)Container3_cc.ActualWidth;
            _height = (int)Container3_cc.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp = drawpic(ache_colors[0], pilebackcolor, ccdegree[2], _length);
            if (_temp == null)
                return;
            BitmapImage bi = BitmapToBitmapImage(_temp);
            simpleImage.Source = bi;
            Canvas.SetLeft(simpleImage, (_width - _length) / 2);
            Canvas.SetTop(simpleImage, (_height - _length) / 2 + 10);
            Container3_cc.Children.Add(simpleImage);
            if (ccdegree[2] < plandegree[3, 1])
            {
                temp = "滞后";
                text3_cc.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text3_cc.Text = (ccdegree[2] * 100).ToString("F1") + "%\n"+temp;


            //二衬进度
            System.Windows.Controls.Image simpleImage2 = new System.Windows.Controls.Image();
            _width = (int)Container3_ec.ActualWidth;
            _height = (int)Container3_ec.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp2 = drawpic(ache_colors[1], pilebackcolor, ecdegree[2], _length);
            BitmapImage bi2 = BitmapToBitmapImage(_temp2);
            simpleImage2.Source = bi2;
            Canvas.SetLeft(simpleImage2, (_width - _length) / 2);
            Canvas.SetTop(simpleImage2, (_height - _length) / 2 + 10);
            Container3_ec.Children.Add(simpleImage2);
            if (ecdegree[2] < plandegree[3, 2])
            {
                temp = "滞后";
                text3_ec.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text3_ec.Text = (ecdegree[2] * 100).ToString("F1") + "%\n"+temp;


            //仰拱进度
            System.Windows.Controls.Image simpleImage3 = new System.Windows.Controls.Image();
            _width = (int)Container3_yg.ActualWidth;
            _height = (int)Container3_yg.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp3 = drawpic(ache_colors[2], pilebackcolor, ygdegree[2], _length);
            BitmapImage bi3 = BitmapToBitmapImage(_temp3);
            simpleImage3.Source = bi3;
            Canvas.SetLeft(simpleImage3, (_width - _length) / 2);
            Canvas.SetTop(simpleImage3, (_height - _length) / 2 + 10);
            Container3_yg.Children.Add(simpleImage3);
            if (ygdegree[2] < plandegree[3, 3])
            {
                temp = "滞后";
                text3_yg.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text3_yg.Text = (ygdegree[2] * 100).ToString("F1") + "%\n"+temp;
        }
        public void S4_draw()
        {
            //初衬进度
            System.Windows.Controls.Image simpleImage = new System.Windows.Controls.Image();
            _width = (int)Container4_cc.ActualWidth;
            _height = (int)Container4_cc.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp = drawpic(ache_colors[0], pilebackcolor, ccdegree[3], _length);
            if (_temp == null)
                return;
            BitmapImage bi = BitmapToBitmapImage(_temp);
            simpleImage.Source = bi;
            Canvas.SetLeft(simpleImage, (_width - _length) / 2);
            Canvas.SetTop(simpleImage, (_height - _length) / 2 + 10);
            Container4_cc.Children.Add(simpleImage);
            if (ccdegree[3] < plandegree[4, 1])
            {
                temp = "滞后";
                text4_cc.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text4_cc.Text = (ccdegree[3] * 100).ToString("F1") + "%\n"+temp;


            //二衬进度
            System.Windows.Controls.Image simpleImage2 = new System.Windows.Controls.Image();
            _width = (int)Container4_ec.ActualWidth;
            _height = (int)Container4_ec.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp2 = drawpic(ache_colors[1], pilebackcolor, ecdegree[3], _length);
            BitmapImage bi2 = BitmapToBitmapImage(_temp2);
            simpleImage2.Source = bi2;
            Canvas.SetLeft(simpleImage2, (_width - _length) / 2);
            Canvas.SetTop(simpleImage2, (_height - _length) / 2 + 10);
            Container4_ec.Children.Add(simpleImage2);
            if (ecdegree[3] < plandegree[4, 2])
            {
                temp = "滞后";
                text4_ec.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text4_ec.Text = (ecdegree[3] * 100).ToString("F1") + "%\n"+temp;


            //仰拱进度
            System.Windows.Controls.Image simpleImage3 = new System.Windows.Controls.Image();
            _width = (int)Container4_yg.ActualWidth;
            _height = (int)Container4_yg.ActualHeight;
            _length = Math.Min(_width, _height);
            Bitmap _temp3 = drawpic(ache_colors[2], pilebackcolor, ygdegree[3], _length);
            BitmapImage bi3 = BitmapToBitmapImage(_temp3);

            simpleImage3.Source = bi3;
            Canvas.SetLeft(simpleImage3, (_width - _length) / 2);
            Canvas.SetTop(simpleImage3, (_height - _length) / 2 + 10);
            Container4_yg.Children.Add(simpleImage3);
            if (ygdegree[3] < plandegree[4, 3])
            {
                temp = "滞后";
                text4_yg.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
                temp = "正常";
            text4_yg.Text = (ygdegree[3] * 100).ToString("F1") + "%\n"+temp;

        }
    }
}
