using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
namespace iS3.Client.Controls
{
    public class rulerextent
    {
        public double XMin { get; set; }

        public double XMax { get; set; }

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
    public class Ruler : FrameworkElement
    {
        #region Fields
        private double SegmentHeight;
        public List<string> mileage_start, mileage_end, show_content;
        public int show_number;
        private readonly Pen p = new Pen(Brushes.Black, 1.0);
        private readonly Pen ThinPen = new Pen(Brushes.Black, 0.5);
        private readonly Pen BorderPen = new Pen(Brushes.Gray, 1.0);
        private readonly Pen RedPen = new Pen(Brushes.Red, 2.0);
        #endregion

        #region Properties
        #region Length
        /// <summary>
        /// Gets or sets the length of the ruler. If the <see cref="AutoSize"/> property is set to false (default) this
        /// is a fixed length. Otherwise the length is calculated based on the actual width of the ruler.
        /// </summary>
        public double Length
        {
            get
            {
                if (this.AutoSize)
                {
                    return (double)(Unit == Unit.Cm ? DipHelper.DipToCm(this.ActualWidth) : DipHelper.DipToInch(this.ActualWidth)) / this.Zoom;
                }
                else
                {
                    return (double)GetValue(LengthProperty);
                }
            }
            set
            {
                SetValue(LengthProperty, value);
            }
        }

        /// <summary>
        /// Identifies the Length dependency property.
        /// </summary>
        public static readonly DependencyProperty LengthProperty =
             DependencyProperty.Register(
                  "Length",
                  typeof(double),
                  typeof(Ruler),
                  new FrameworkPropertyMetadata(30D, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region AutoSize
        /// <summary>
        /// Gets or sets the AutoSize behavior of the ruler.
        /// false (default): the lenght of the ruler results from the <see cref="Length"/> property. If the window size is changed, e.g. wider
        ///						than the rulers length, free space is shown at the end of the ruler. No rescaling is done.
        /// true				 : the length of the ruler is always adjusted to its actual width. This ensures that the ruler is shown
        ///						for the actual width of the window.
        /// </summary>
        public bool AutoSize
        {
            get
            {
                return (bool)GetValue(AutoSizeProperty);
            }
            set
            {
                SetValue(AutoSizeProperty, value);
                this.InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the AutoSize dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoSizeProperty =
             DependencyProperty.Register(
                  "AutoSize",
                  typeof(bool),
                  typeof(Ruler),
                  new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Zoom
        /// <summary>
        /// Gets or sets the zoom factor for the ruler. The default value is 1.0. 
        /// </summary>
        public double Zoom
        {
            get
            {
                return (double)GetValue(ZoomProperty);
            }
            set
            {
                SetValue(ZoomProperty, value);
                this.InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the Zoom dependency property.
        /// </summary>
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(Ruler),
            new FrameworkPropertyMetadata((double)1.0,
                FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region Chip

        /// <summary>
        /// Chip Dependency Property
        /// </summary>
        public static readonly DependencyProperty ChipProperty =
             DependencyProperty.Register("Chip", typeof(double), typeof(Ruler),
                  new FrameworkPropertyMetadata((double)-1000, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Sets the location of the chip in the units of the ruler.
        /// So, to set the chip to 10 in cm units the chip needs to be set to 10.
        /// Use the <see cref="DipHelper"/> class for conversions.
        /// </summary>
        public double Chip
        {
            get { return (double)GetValue(ChipProperty); }
            set { SetValue(ChipProperty, value); }
        }
        #endregion

        #region CountShift

        /// <summary>
        /// CountShift Dependency Property
        /// </summary>
        public static readonly DependencyProperty CountShiftProperty =
             DependencyProperty.Register("CountShift", typeof(int), typeof(Ruler),
                  new FrameworkPropertyMetadata(0,
                        FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// By default the counting of inches or cm starts at zero, this property allows you to shift
        /// the counting.
        /// </summary>
        public int CountShift
        {
            get { return (int)GetValue(CountShiftProperty); }
            set { SetValue(CountShiftProperty, value); }
        }

        #endregion

        #region Marks

        /// <summary>
        /// Marks Dependency Property
        /// </summary>
        public static readonly DependencyProperty MarksProperty =
             DependencyProperty.Register("Marks", typeof(string), typeof(Ruler),
                  new FrameworkPropertyMetadata("Horizontal",
                         FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets where the marks are shown in the ruler.
        /// </summary>
        public string Marks
        {
            get { return (string)GetValue(MarksProperty); }
            set { SetValue(MarksProperty, value); }
        }

        public static readonly DependencyProperty RulerExtentProperty =
             DependencyProperty.Register("RulerExtent", typeof(rulerextent), typeof(Ruler),
                  new FrameworkPropertyMetadata(new rulerextent() { XMax = 2987.0, XMin = 2687.0 },
                         FrameworkPropertyMetadataOptions.AffectsRender));
        public rulerextent RulerExtent
        {
            get { return (rulerextent)GetValue(RulerExtentProperty); }
            set { SetValue(RulerExtentProperty, value); this.InvalidateVisual(); }
        }

        #endregion


        #region Unit
        /// <summary>
        /// Gets or sets the unit of the ruler.
        /// Default value is Unit.Cm.
        /// </summary>
        public Unit Unit
        {
            get { return (Unit)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        /// <summary>
        /// Identifies the Unit dependency property.
        /// </summary>
        public static readonly DependencyProperty UnitProperty =
             DependencyProperty.Register(
                  "Unit",
                  typeof(Unit),
                  typeof(Ruler),
                  new FrameworkPropertyMetadata(Unit.Cm, FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #endregion

        #region Constructor
        static Ruler()
        {
            HeightProperty.OverrideMetadata(typeof(Ruler), new FrameworkPropertyMetadata(30.0, FrameworkPropertyMetadataOptions.AffectsRender));
        }
        public Ruler()
        {
            SegmentHeight = this.Height - 10;
            mileage_end = new List<string>();
            mileage_start = new List<string>();
            show_content = new List<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Participates in rendering operations.
        /// </summary>
        /// <param name="drawingContext">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            try
            {
                base.OnRender(drawingContext);
                double xDest = (Unit == Unit.Cm ? DipHelper.CmToDip(Length) : DipHelper.InchToDip(Length)) * this.Zoom;
                drawingContext.DrawRectangle(null, BorderPen, new Rect(new Point(0.0, 0.0), new Point(xDest, Height)));
                //桩号
                if (Marks == "Horizontal")
                {

                    double startpile = DipHelper.GetRulerMileage(RulerExtent.XMin);
                    double endpile = DipHelper.GetRulerMileage(RulerExtent.XMax);
                    double fontwidth = DipHelper.PtToDip(6) * 3;

                    double chip = (Chip - startpile) / (endpile - startpile) * xDest;
                    drawingContext.DrawLine(RedPen, new Point(chip, 0), new Point(chip, Height));

                    int s1 = (int)Math.Truncate(startpile) + 1;
                    int s2 = (int)Math.Truncate(endpile);
                    for (int i = s1; i <= s2; i++)
                    {
                        if ((i < 1000) || (i > 13500))
                            continue;
                        string st = i.ToString();
                        string st1 = st.Substring(0, st.Length - 3);
                        if ((st1 == null) || (st1 == ""))
                            st1 = "0";
                        string st2 = st.Substring(st.Length - 3);
                        st = "K" + st1 + "+" + st2;
                        double d = (Convert.ToDouble(i) - startpile) / (endpile - startpile) * xDest;
                        double deltad = (100.0) / (endpile - startpile) * xDest;
                        if (i % 1000 == 0)
                        {
                            drawingContext.DrawLine(p, new Point(d, 0), new Point(d, SegmentHeight));
                            FormattedText ft = new FormattedText(
                               st, CultureInfo.CurrentCulture,
                                FlowDirection.LeftToRight,
                                new Typeface("Arial"),
                                DipHelper.PtToDip(6),
                                Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            continue;
                        }
                        if (i % 500 == 0)
                        {
                            drawingContext.DrawLine(p, new Point(d, 0), new Point(d, SegmentHeight * 2.0 / 3.0));
                            FormattedText ft = new FormattedText(st2, CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Arial"),
                                        DipHelper.PtToDip(6),
                                        Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            continue;
                        }
                        if (i % 100 == 0)
                        {
                            drawingContext.DrawLine(ThinPen, new Point(d, 0), new Point(d, SegmentHeight / 3.0));
                            if (deltad >= fontwidth)
                            {
                                FormattedText ft = new FormattedText(st2, CultureInfo.CurrentCulture,
                                       FlowDirection.LeftToRight,
                                       new Typeface("Arial"),
                                       DipHelper.PtToDip(6),
                                       Brushes.DimGray);
                                ft.SetFontWeight(FontWeights.Regular);
                                ft.TextAlignment = TextAlignment.Center;
                                drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            }
                            continue;
                        }
                    }
                }
                if (Marks == "MILI")
                {
                    double startpile = DipHelper.GetRulerMileage(RulerExtent.XMin);
                    double endpile = DipHelper.GetRulerMileage(RulerExtent.XMax);
                    double fontwidth = DipHelper.PtToDip(6) * 3;

                    double chip = (Chip - startpile) / (endpile - startpile) * xDest;
                    drawingContext.DrawLine(RedPen, new Point(chip, 0), new Point(chip, Height));
                    show_number = mileage_start.Count;
                    for (int i = 0; i <= show_number - 1; i++)
                    {
                        Pile p_a = DipHelper.getSectionPos(mileage_start[i]);
                        Pile p_b = DipHelper.getSectionPos(mileage_end[i]);
                        string st = show_content[i];
                        double p1 = Convert.ToDouble(p_a.pilepoint);
                        double p2 = Convert.ToDouble(p_b.pilepoint);
                        if (p1 < startpile)
                            p1 = startpile;
                        if (p2 > endpile)                               
                            p2 = endpile;
                        double d1 = (p1 - startpile) / (endpile - startpile) * xDest;
                        double d2 = (p2 - startpile) / (endpile - startpile) * xDest;
                        if ((d1 < 0) || (d2 < 0))
                            continue;
                        if ((d1 > xDest) || (d2 > xDest))
                            continue;
                        double deltad = Math.Abs(p2 - p1) / (endpile - startpile) * xDest;
                        drawingContext.DrawLine(p, new Point(d1, 0), new Point(d1, SegmentHeight/2));
                        drawingContext.DrawLine(p, new Point(d2, 0), new Point(d2, SegmentHeight/2));
                        if (deltad >= fontwidth)
                        {
                            FormattedText ft = new FormattedText(
                           st, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight,
                            new Typeface("Arial"),
                            DipHelper.PtToDip(6),
                            Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point((d1 + d2) / 2, Height - ft.Height));
                        }
                    }
                }

                if (Marks == "Vertical")
                {
                    double startheight = DipHelper.GetRulerAltitude(RulerExtent.XMin);
                    double endheight = DipHelper.GetRulerAltitude(RulerExtent.XMax);
                    double fontwidth = DipHelper.PtToDip(6) * 3;

                    double chip = (Chip - startheight) / (endheight - startheight) * xDest;
                    drawingContext.DrawLine(RedPen, new Point(chip, 0), new Point(chip, Height));

                    int s1 = (int)Math.Truncate(startheight) + 1;
                    int s2 = (int)Math.Truncate(endheight);
                    for (int i = s1; i <= s2; i++)
                    {
                        if ((i < 1300) || (i > 5000))
                            continue;
                        string st = i.ToString();
                        double d = (Convert.ToDouble(i) - startheight) / (endheight - startheight) * xDest;
                        double deltad = (100.0) / (endheight - startheight) * xDest;
                        if (i % 1000 == 0)
                        {
                            drawingContext.DrawLine(p, new Point(d, 0), new Point(d, SegmentHeight));
                            FormattedText ft = new FormattedText(
                               st, CultureInfo.CurrentCulture,
                                FlowDirection.LeftToRight,
                                new Typeface("Arial"),
                                DipHelper.PtToDip(6),
                                Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            continue;
                        }
                        if (i % 500 == 0)
                        {
                            drawingContext.DrawLine(p, new Point(d, 0), new Point(d, SegmentHeight * 2.0 / 3.0));
                            FormattedText ft = new FormattedText(st, CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Arial"),
                                        DipHelper.PtToDip(6),
                                        Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            continue;
                        }
                        if (i % 100 == 0)
                        {
                            drawingContext.DrawLine(ThinPen, new Point(d, 0), new Point(d, SegmentHeight / 3.0));
                            if (deltad >= fontwidth)
                            {
                                FormattedText ft = new FormattedText(st, CultureInfo.CurrentCulture,
                                       FlowDirection.LeftToRight,
                                       new Typeface("Arial"),
                                       DipHelper.PtToDip(6),
                                       Brushes.DimGray);
                                ft.SetFontWeight(FontWeights.Regular);
                                ft.TextAlignment = TextAlignment.Center;
                                drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            }
                            continue;
                        }
                    }
                }
                if (Marks == "XJ")
                {
                    double startheight = RulerExtent.XMin;
                    double endheight = RulerExtent.XMax;
                    double fontwidth = DipHelper.PtToDip(6) * 3;

                    double chip = (Chip - startheight) / (endheight - startheight) * xDest;
                    drawingContext.DrawLine(RedPen, new Point(chip, 0), new Point(chip, Height));

                    int s1 = (int)Math.Truncate(startheight) + 1;
                    int s2 = (int)Math.Truncate(endheight);
                    for (int i = s1; i <= s2; i++)
                    {
                        int pile = DipHelper.GetRulerXJMileage(i);
                        if (pile < 0)
                            continue;
                        string st = pile.ToString().PadLeft(4, '0');
                        string st2 = st.Substring(st.Length - 3);
                        st = "K" + st[0] + "+" + st2;
                        double d = (Convert.ToDouble(i) - startheight) / (endheight - startheight) * xDest;
                        double deltad = (10.0) / (endheight - startheight) * xDest;
                        if ((pile % 1000 == 0) || (pile == 1900))
                        {
                            drawingContext.DrawLine(p, new Point(d, 0), new Point(d, SegmentHeight));
                            FormattedText ft = new FormattedText(
                               st, CultureInfo.CurrentCulture,
                                FlowDirection.LeftToRight,
                                new Typeface("Arial"),
                                DipHelper.PtToDip(6),
                                Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            continue;
                        }
                        if (pile % 500 == 0)
                        {
                            drawingContext.DrawLine(p, new Point(d, 0), new Point(d, SegmentHeight * 2.0 / 3.0));
                            FormattedText ft = new FormattedText(st2, CultureInfo.CurrentCulture,
                                        FlowDirection.LeftToRight,
                                        new Typeface("Arial"),
                                        DipHelper.PtToDip(6),
                                        Brushes.DimGray);
                            ft.SetFontWeight(FontWeights.Regular);
                            ft.TextAlignment = TextAlignment.Center;
                            drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            continue;
                        }
                        if (pile % 100 == 0)
                        {
                            drawingContext.DrawLine(ThinPen, new Point(d, 0), new Point(d, SegmentHeight / 3.0));
                            if (deltad >= fontwidth)
                            {
                                FormattedText ft = new FormattedText(st2, CultureInfo.CurrentCulture,
                                       FlowDirection.LeftToRight,
                                       new Typeface("Arial"),
                                       DipHelper.PtToDip(6),
                                       Brushes.DimGray);
                                ft.SetFontWeight(FontWeights.Regular);
                                ft.TextAlignment = TextAlignment.Center;
                                drawingContext.DrawText(ft, new Point(d, Height - ft.Height));
                            }
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }

        /// <summary>
        /// Measures an instance during the first layout pass prior to arranging it.
        /// </summary>
        /// <param name="availableSize">A maximum Size to not exceed.</param>
        /// <returns>The maximum Size for the instance.</returns>
        //protected override Size MeasureOverride(Size availableSize)
        //{
        //    Size desiredSize;
        //    if (Unit == Unit.Cm)
        //    {
        //        desiredSize = new Size(DipHelper.CmToDip(Length), Height);
        //    }
        //    else
        //    {
        //        desiredSize = new Size(DipHelper.InchToDip(Length), Height);
        //    }
        //    return desiredSize;
        //}
        #endregion
    }

    /// <summary>
    /// The unit type of the ruler.
    /// </summary>
    public enum Unit
    {
        /// <summary>
        /// the unit is Centimeter.
        /// </summary>
        Cm,

        /// <summary>
        /// The unit is Inch.
        /// </summary>
        Inch
    };


    /// <summary>
    /// A helper class for DIP (Device Independent Pixels) conversion and scaling operations.
    /// </summary>
    public static class DipHelper
    {
        /// <summary>
        /// Converts millimeters to DIP (Device Independant Pixels).
        /// </summary>
        /// <param name="mm">A millimeter value.</param>
        /// <returns>A DIP value.</returns>
        public static double MmToDip(double mm)
        {
            return CmToDip(mm / 10.0);
        }

        /// <summary>
        /// Converts centimeters to DIP (Device Independant Pixels).
        /// </summary>
        /// <param name="cm">A centimeter value.</param>
        /// <returns>A DIP value.</returns>
        public static double CmToDip(double cm)
        {
            return (cm * 96.0 / 2.54);
        }

        /// <summary>
        /// Converts inches to DIP (Device Independant Pixels).
        /// </summary>
        /// <param name="inch">An inch value.</param>
        /// <returns>A DIP value.</returns>
        public static double InchToDip(double inch)
        {
            return (inch * 96.0);
        }
        public static double DipToInch(double dip)
        {
            return dip / 96D;
        }

        /// <summary>
        /// Converts font points to DIP (Device Independant Pixels).
        /// </summary>
        /// <param name="pt">A font point value.</param>
        /// <returns>A DIP value.</returns>
        public static double PtToDip(double pt)
        {
            return (pt * 96.0 / 72.0);
        }

        /// <summary>
        /// Converts DIP (Device Independant Pixels) to centimeters.
        /// </summary>
        /// <param name="dip">A DIP value.</param>
        /// <returns>A centimeter value.</returns>
        public static double DipToCm(double dip)
        {
            return (dip * 2.54 / 96.0);
        }

        /// <summary>
        /// Converts DIP (Device Independant Pixels) to millimeters.
        /// </summary>
        /// <param name="dip">A DIP value.</param>
        /// <returns>A millimeter value.</returns>
        public static double DipToMm(double dip)
        {
            return DipToCm(dip) * 10.0;
        }

        /// <summary>
        /// Gets the system DPI scale factor (compared to 96 dpi).
        /// From http://blogs.msdn.com/jaimer/archive/2007/03/07/getting-system-dpi-in-wpf-app.aspx
        /// Should not be called before the Loaded event (else XamlException mat throw)
        /// </summary>
        /// <returns>A Point object containing the X- and Y- scale factor.</returns>
        private static Point GetSystemDpiFactor()
        {
            PresentationSource source = PresentationSource.FromVisual(Application.Current.MainWindow);
            Matrix m = source.CompositionTarget.TransformToDevice;
            return new Point(m.M11, m.M22);
        }

        private const double DpiBase = 96.0;

        /// <summary>
        /// Gets the system configured DPI.
        /// </summary>
        /// <returns>A Point object containing the X- and Y- DPI.</returns>
        public static Point GetSystemDpi()
        {
            Point sysDpiFactor = GetSystemDpiFactor();
            return new Point(
                 sysDpiFactor.X * DpiBase,
                 sysDpiFactor.Y * DpiBase);
        }

        /// <summary>
        /// Gets the physical pixel density (DPI) of the screen.
        /// </summary>
        /// <param name="diagonalScreenSize">Size - in inch - of the diagonal of the screen.</param>
        /// <returns>A Point object containing the X- and Y- DPI.</returns>
        public static Point GetPhysicalDpi(double diagonalScreenSize)
        {
            Point sysDpiFactor = GetSystemDpiFactor();
            double pixelScreenWidth = SystemParameters.PrimaryScreenWidth * sysDpiFactor.X;
            double pixelScreenHeight = SystemParameters.PrimaryScreenHeight * sysDpiFactor.Y;
            double formatRate = pixelScreenWidth / pixelScreenHeight;

            double inchHeight = diagonalScreenSize / Math.Sqrt(formatRate * formatRate + 1.0);
            double inchWidth = formatRate * inchHeight;

            double xDpi = Math.Round(pixelScreenWidth / inchWidth);
            double yDpi = Math.Round(pixelScreenHeight / inchHeight);

            return new Point(xDpi, yDpi);
        }

        /// <summary>
        /// Converts a DPI into a scale factor (compared to system DPI).
        /// </summary>
        /// <param name="dpi">A Point object containing the X- and Y- DPI to convert.</param>
        /// <returns>A Point object containing the X- and Y- scale factor.</returns>
        public static Point DpiToScaleFactor(Point dpi)
        {
            Point sysDpi = GetSystemDpi();
            return new Point(
                 dpi.X / sysDpi.X,
                 dpi.Y / sysDpi.Y);
        }

        /// <summary>
        /// Gets the scale factor to apply to a WPF application
        /// so that 96 DIP always equals 1 inch on the screen (whatever the system DPI).
        /// </summary>
        /// <param name="diagonalScreenSize">Size - in inch - of the diagonal of the screen</param>
        /// <returns>A Point object containing the X- and Y- scale factor.</returns>
        public static Point GetScreenIndependentScaleFactor(double diagonalScreenSize)
        {
            return DpiToScaleFactor(GetPhysicalDpi(diagonalScreenSize));
        }
        public static double GetRulerMileage(double mileage)
        {
            double _m = 1440.0;
            double _base = 2757.42;
            double res = _m + (mileage - _base) * 10;
            return res;
        }
        public static double GetRulerAltitude(double altitude)
        {
            double _m = 2065.0;
            double _base = 2359.22;
            double res = _m + (altitude - _base) * 10;
            return res;
        }
        public static int GetRulerXJMileage(int mileage)
        {
            int m1 = 3588;
            int m2 = 3079;
            int res = -1;
            res = (mileage - m1) * 10;
            if ((res >= 0) && (res <= 1900))
                return res;
            res = (m2 - mileage) * 10;
            if ((res >= 0) && (res <= 1900))
                return res;
            return -1;
        }
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
    }
}
