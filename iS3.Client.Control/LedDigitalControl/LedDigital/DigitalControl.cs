using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using iS3.Client.Controls.LedDigitalControl.LedDigital.Segments;
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

namespace iS3.Client.Controls.LedDigitalControl.LedDigital
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:LedDigital"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:LedDigital;assembly=LedDigital"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:LEDControl/>
    ///
    /// </summary>
    public class DigitalControl : ContentControl
    {
        #region Fields

        private DigitalParam dp;
        private readonly Dictionary<string, Segment> digitalSegmentDict = new Dictionary<string, Segment>()
        {
            {"TopSegment", null },
            {"UpRightSegment", null },
            {"DownRightSegment", null },
            {"BottomSegment", null},
            {"DownLeftSegment", null },
            {"UpLeftSegment", null},
            {"MiddleSegment", null },
            {"UpColonSegment",  null},
            {"DownColonSegment", null },
            {"DotSegment", null }
        };

        private Grid rootGrid;
        private DigitalData dd;

        #endregion

        #region Dependency properties

        /// <summary>
        /// Dependency property to Get/Set the current value 
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(DigitalControl),
            new PropertyMetadata(null, new PropertyChangedCallback(DigitalControl.OnValuePropertyChanged)));

        /// <summary>
        /// 依赖属性-LED显示颜色
        /// </summary>
        public static readonly DependencyProperty LEDColorProperty =
            DependencyProperty.Register("LEDColor", typeof(Color), typeof(DigitalControl),
            new PropertyMetadata(Colors.Red, new PropertyChangedCallback(DigitalControl.OnLEDColorPropertyChange)));

        /// <summary>
        /// LED高度
        /// </summary>
        public static readonly DependencyProperty LEDHeightProperty =
            DependencyProperty.Register("LEDHeight", typeof(double), typeof(DigitalControl),
                new PropertyMetadata(40.0, new PropertyChangedCallback(DigitalControl.OnSizePropertyChanged)));

        /// <summary>
        /// LED的宽度
        /// </summary>
        public static readonly DependencyProperty LEDWidthProperty =
            DependencyProperty.Register("LEDWidth", typeof(double), typeof(DigitalControl),
                new PropertyMetadata(20.0, new PropertyChangedCallback(DigitalControl.OnSizePropertyChanged)));

        /// <summary>
        /// LED字体的粗细
        /// </summary>
        public static readonly DependencyProperty LEDThicknessProperty =
            DependencyProperty.Register("LEDThickness", typeof(double), typeof(DigitalControl),
                new PropertyMetadata(5.0, new PropertyChangedCallback(DigitalControl.OnSizePropertyChanged)));

        /// <summary>
        /// Segment间的距离
        /// </summary>
        public static readonly DependencyProperty SegmentIntervalProperty =
            DependencyProperty.Register("SegmentInterval", typeof(double), typeof(DigitalControl),
                new PropertyMetadata(2.0, new PropertyChangedCallback(DigitalControl.OnSizePropertyChanged)));

        /// <summary>
        /// segment两端的截断长度
        /// </summary>
        public static readonly DependencyProperty BevelWidthProperty =
            DependencyProperty.Register("BevelWidth", typeof(double), typeof(DigitalControl),
                new PropertyMetadata(2.0, new PropertyChangedCallback(DigitalControl.OnSizePropertyChanged)));

        #endregion

        #region Wrapper properties

        /// <summary>
        /// Gets/Sets the current value
        /// </summary>
        public string Value
        {
            get
            {
                return (string)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置LED颜色
        /// </summary>
        public Color LEDColor
        {
            get
            {
                return (Color)GetValue(LEDColorProperty);
            }
            set
            {
                SetValue(LEDColorProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置LED高度
        /// </summary>
        public double LEDHeight
        {
            get
            {
                return (double)GetValue(LEDHeightProperty);
            }
            set
            {
                SetValue(LEDHeightProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置LED宽度
        /// </summary>
        public double LEDWidth
        {
            get
            {
                return (double)GetValue(LEDWidthProperty);
            }
            set
            {
                SetValue(LEDWidthProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置LED字体粗细
        /// </summary>
        public double LEDThickness
        {
            get
            {
                return (double)GetValue(LEDThicknessProperty);
            }
            set
            {
                SetValue(LEDThicknessProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置LED segment间距
        /// </summary>
        public double SegmentInterval
        {
            get
            {
                return (double)GetValue(SegmentIntervalProperty);
            }
            set
            {
                SetValue(SegmentIntervalProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置LED截断宽度
        /// </summary>
        public double BevelWidth
        {
            get
            {
                return (double)GetValue(BevelWidthProperty);
            }
            set
            {
                SetValue(BevelWidthProperty, value);
            }
        }

        #endregion

        #region Constructor

        static DigitalControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalControl), new FrameworkPropertyMetadata(typeof(DigitalControl)));
        }

        #endregion

        #region Property Changed Callbacks

        /// <summary>
        /// 控件属性值发生变化时调用的方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property.Name == "Height")
            {
                LEDHeight = (double)e.NewValue;
            }
            else if (e.Property.Name == "Width")
            {
                LEDWidth = (double)e.NewValue - LEDThickness;
            }
        }

        /// <summary>
        /// 当前值发生变化时候调用的方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DigitalControl led = d as DigitalControl;
            if (led.dd != null)
            {
                led.dd.DisplayDigital(led.Value);
            }
        }

        /// <summary>
        /// LED颜色发生变化时调用的方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnLEDColorPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DigitalControl led = d as DigitalControl;
            led.SetAllSegmentsColor(led.dd, led.LEDColor);
        }

        /// <summary>
        /// 当led形状参数发生变化时调用的方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DigitalControl led = d as DigitalControl;

            //获取根布局
            Grid rootGrid = led.GetTemplateChild("gdRoot") as Grid;
            if(rootGrid == null)
            {
                return;
            }

            //清除原图形
            if (led.rootGrid != null)
            {
                led.rootGrid.Children.Clear();
            }

            //画新数字图形
            //初始化Segments的点集digitalSegmentDict
            led.SetSegmentsData();
            //画数字
            led.dd = led.DrawSegments(led.digitalSegmentDict, led.LEDColor);
            //将线段添加到容器
            led.AddSegmentsToPanel(led.dd);

            led.dd.DisplayDigital(led.Value);
        }

        #endregion

        #region Method

        /// <summary>
        /// 调用模板时的方法
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //获取根布局
            rootGrid = GetTemplateChild("gdRoot") as Grid;

            //初始化Segments的点集digitalSegmentDict
            SetSegmentsData();
            //画数字
            dd = DrawSegments(digitalSegmentDict, LEDColor);

            //将线段添加到容器
            AddSegmentsToPanel(dd);

            dd.DisplayDigital(Value);
        }

        /// <summary>
        /// 初始化Segments的点集
        /// </summary>
        private void SetSegmentsData()
        {
            dp = new DigitalParam();
            dp.BevelWidth = BevelWidth;
            dp.SegmentInterval = SegmentInterval;
            dp.SegmentThickness = LEDThickness;
            dp.DigitalHeight = LEDHeight;
            dp.DigitalWidth = LEDWidth;

            digitalSegmentDict["TopSegment"] = new TopSegment(dp);
            digitalSegmentDict["UpRightSegment"] = new UpRightSegment(dp);
            digitalSegmentDict["DownRightSegment"] = new DownRightSegment(dp);
            digitalSegmentDict["BottomSegment"] = new BottomSegment(dp);
            digitalSegmentDict["DownLeftSegment"] = new DownLeftSegment(dp);
            digitalSegmentDict["UpLeftSegment"] = new UpLeftSegment(dp);
            digitalSegmentDict["MiddleSegment"] = new MiddleSegment(dp);
            digitalSegmentDict["UpColonSegment"] = new UpColonSegment(dp);
            digitalSegmentDict["DownColonSegment"] = new DownColonSegment(dp);
            digitalSegmentDict["DotSegment"] = new DotSegment(dp);
        }

        /// <summary>
        /// 将数字片段添加到显示容器
        /// </summary>
        /// <param name="dd"></param>
        private void AddSegmentsToPanel(DigitalData dd)
        {
            foreach (System.Reflection.PropertyInfo p in dd.GetType().GetProperties())
            {
                Path segment = p.GetValue(dd, null) as Path;
                rootGrid.Children.Add(segment);
            }
        }

        #region Draw Methods

        /// <summary>
        /// 画所有图形
        /// </summary>
        /// <param name="clr"></param>
        private DigitalData DrawSegments(Dictionary<string, Segment> dgtSegmentDict, Color clr)
        {
            DigitalData digitalData = new DigitalData();

            foreach (System.Reflection.PropertyInfo p in digitalData.GetType().GetProperties())
            {
                p.SetValue(digitalData, DrawSegment(dgtSegmentDict[p.Name].Points, clr), null);
            }

            return digitalData;
        }

        /// <summary>
        /// 画数字线段
        /// </summary>
        /// <param name="points">线段点集合</param>
        /// <param name="clr"></param>
        /// <returns></returns>
        private Path DrawSegment(List<Point> points, Color clr)
        {
            Path segment = null;
            if (points.Count > 1)
            {
                segment = DrawLine(points, clr);
            }
            else if (points.Count == 1)
            {
                segment = DrawEllipse(points[0], LEDThickness / 2, clr);
            }

            return segment;
        }

        /// <summary>
        /// 画直线段
        /// </summary>
        /// <param name="points"></param>
        /// <param name="clr"></param>
        /// <returns></returns>
        private static Path DrawLine(List<Point> points, Color clr)
        {
            PathSegmentCollection segments = new PathSegmentCollection();
            for (int i = 1; i < points.Count; i++)
            {
                segments.Add(new LineSegment(points[i], true));
            }

            Path segment = new Path()
            {
                StrokeLineJoin = PenLineJoin.Round,
                Stroke = new SolidColorBrush(clr),
                Fill = new SolidColorBrush(clr),
                Opacity = 0.05,
                StrokeThickness = 0.25,
                Data = new PathGeometry()
                {
                    Figures = new PathFigureCollection()
                    {
                        new PathFigure(){IsClosed = true, IsFilled = true, StartPoint = points[0], Segments = segments}
                    }
                }
            };
            return segment;
        }

        /// <summary>
        /// 画圆点
        /// </summary>
        /// <param name="p"></param>
        /// <param name="radius"></param>
        /// <param name="clr"></param>
        /// <returns></returns>
        private Path DrawEllipse(Point p, double radius, Color clr)
        {
            Color strokecolor;
            if (clr == Colors.Transparent)
            {
                strokecolor = clr;
            }
            else
            {
                strokecolor = Colors.White;
            }

            Path segment = new Path()
            {
                StrokeLineJoin = PenLineJoin.Round,
                Stroke = new SolidColorBrush(strokecolor),

                Fill = new SolidColorBrush(clr),
                Opacity = 0.05,
                StrokeThickness = 0.25,
                Data = new EllipseGeometry(p, radius, radius)
            };
            
            return segment;
        }

        #endregion

        /// <summary>
        /// 设置所有segment的颜色
        /// </summary>
        /// <param name="color"></param>
        private void SetAllSegmentsColor(DigitalData dd, Color color)
        {
            if (dd != null)
            {
                foreach (System.Reflection.PropertyInfo p in dd.GetType().GetProperties())
                {
                    Path segment = p.GetValue(dd, null) as Path;
                    SetSegmentColor(segment, color);
                }
            }
        }

        /// <summary>
        /// 设置指定segment颜色
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="color"></param>
        private void SetSegmentColor(Path segment, Color color)
        {
            segment.Fill = new SolidColorBrush(color);
        }

        #endregion
    }
}
