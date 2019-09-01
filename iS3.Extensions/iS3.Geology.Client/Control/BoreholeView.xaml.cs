using iS3.Core.Client.ViewModel;
using iS3.Core.Model;
using iS3.Geology.Model;
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

namespace iS3.Geology.Client.Control
{
    /// <summary>
    /// BoreholeView.xaml 的交互逻辑
    /// </summary>
    public partial class BoreholeView : UserControl,IDGObjectView
    {
        public BoreholeView()
        {
            InitializeComponent();
            ScaleY = 1.0;
            BH_Width = 20.0;

            Loaded += BoreholeView_Loaded;
        }

        private void BoreholeView_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshView();
        }

        public double ScaleY { get; set; }
        public Borehole Borehole { get; set; }
        public bool IsEmpty { get; set; }
        public double BH_Width { get; set; }

        public void RefreshView()
        {
            LayoutRoot.Children.Clear();

            double width = BH_Width;
            Brush whiteBrush = new SolidColorBrush(Colors.White);
            Brush blueBrush = new SolidColorBrush(Colors.Blue);
            Brush blackBrush = new SolidColorBrush(Colors.Black);
            Brush redBrush = new SolidColorBrush(Colors.Red);

            // Borehole Name
            //
            TextBlock tbName = new TextBlock();
            tbName.Foreground = redBrush;
            tbName.Text = Borehole.Name;
            tbName.FontWeight = FontWeights.Bold;
            Canvas.SetLeft(tbName, 0);
            Canvas.SetTop(tbName, -20);
            LayoutRoot.Children.Add(tbName);

            if (Borehole.BoreholeStratas.Count == 0) return;
            BoreholeStrata bhGeo0 = Borehole.BoreholeStratas[0];
            foreach (BoreholeStrata bhGeo in Borehole.BoreholeStratas)
            {
                double top = (double.Parse( Borehole.TopElevation.ToString()) - bhGeo.Top) * ScaleY;
                double height = (bhGeo.Top - bhGeo.Base) * ScaleY;
                top = Math.Abs(top);
                height = Math.Abs(height);

                // Stratum rectangle
                //
                Rectangle rec = new Rectangle();
                rec.Fill = whiteBrush;
                rec.Stroke = blueBrush;
                rec.Width = width;
                rec.Height = height;
                Canvas.SetTop(rec, top);
                Canvas.SetLeft(rec, 0);

                // Stratum name
                //
                //TextBlock tbStratumName = new TextBlock();
                //tbStratumName.Foreground = blueBrush;
                //if (Strata != null)
                //{
                //    Stratum stratum = Strata[bhGeo.StratumID] as Stratum;
                //    tbStratumName.Text = stratum.name;
                //}
                //else
                //    tbStratumName.Text = bhGeo.StratumID.ToString();
                //Canvas.SetLeft(tbStratumName, width);
                //Canvas.SetTop(tbStratumName, top + height / 2 - 8.0);

                // Stratum base elevation
                //
                TextBlock tbBaseElevation = new TextBlock();
                tbBaseElevation.Foreground = blackBrush;
                tbBaseElevation.Text = bhGeo.Base.ToString("0.00");
                Canvas.SetLeft(tbBaseElevation, width);
                Canvas.SetTop(tbBaseElevation, top + height - 8.0);

                LayoutRoot.Children.Add(rec);
                if (height >= 10.0)
                {
                   // LayoutRoot.Children.Add(tbStratumName);
                    LayoutRoot.Children.Add(tbBaseElevation);
                }

                // Stratum top elevation
                //
                if (bhGeo == bhGeo0)
                {
                    TextBlock tbTopElevation = new TextBlock();
                    tbTopElevation.Foreground = blackBrush;
                    tbTopElevation.Text = bhGeo.Top.ToString("0.00");
                    Canvas.SetLeft(tbTopElevation, width);
                    Canvas.SetTop(tbTopElevation, top - 8.0);
                    LayoutRoot.Children.Add(tbTopElevation);
                }
            }
        }
        #region
        public UserControl ChartView()
        {
            return this;
        }

        public Task SetObjContent(DGObject model)
        {
            this.Borehole = model as Borehole;
            return null;
        }

        public EngineeringMap SetIt(DGObject model)
        {
            this.Borehole = model as Borehole;
            return null;
        }
        #endregion
    }
}
