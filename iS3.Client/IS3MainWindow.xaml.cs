using iS3.Core.Client;
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
using System.Windows.Shapes;

namespace iS3.Client
{
    /// <summary>
    /// IS3MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IS3MainWindow : Window, IS3PageHolder
    {
        public IS3MainWindow()
        {
            //StyleManager.ApplicationTheme = new VisualStudio2013Theme();
            InitializeComponent();
            Loaded += IS3MainWindow_Loaded;
        }

        private void IS3MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DllImport.LoadExtension();
           // DllImport.LoadTools();



            this.WindowState = WindowState.Maximized;
            //pageTransitionControl.ShowPage(new LoginPageForMon() { IS3MainWindow=this});
            //pageTransitionControl.ShowPage(new ProjectListPage() { IS3MainWindow = this });
        }
        public void Switch(UserControl userControl)
        {
            // pageTransitionControl.ShowPage(userControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  App app = Application.Current as App;
            ////  IS3MainWindow mw = (IS3MainWindow)app.MainWindow;
            //  mw.Close();
            //  System.Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // App app = Application.Current as App;
            //// IS3MainWindow mw = (IS3MainWindow)app.MainWindow;
            // mw.WindowState = WindowState.Minimized;
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            // App app = Application.Current as App;
            //// IS3MainWindow mw = (IS3MainWindow)app.MainWindow;
            // mw.WindowState = WindowState.Maximized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确认关闭", "关闭提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    if (Globals.mainFrame != null)
                    {
                        Globals.mainFrame.Close();
                    }
                    //App app = Application.Current as App;
                    //IS3MainWindow mw = (IS3MainWindow)app.MainWindow;
                    //mw.Close();
                    System.Environment.Exit(0);
                }
                catch { }

            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            //base.OnClosing(e);
            if (System.Windows.Forms.MessageBox.Show("确定是否关闭当前应用程序？", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Globals.mainFrame != null)
                {
                    Globals.mainFrame.Close();
                }
                //App app = Application.Current as App;
                //IS3MainWindow mw = (IS3MainWindow)app.MainWindow;
                //mw.Close();
                System.Environment.Exit(0);
                base.OnClosing(e);  //重写父类的onClosing事件，通过this.closing关闭报错,
            }
            else
            {
                e.Cancel = true;

            }
        }
        public void SetShow()
        {
            this.Show();
        }
        private IPageTransition pageTransition;
        public void SetPageTransition(IPageTransition pageTransition)
        {
            this.pageTransition = pageTransition;
            holder.Children.Add(pageTransition as UserControl);
        }

        public void ShowPage(UserControl userControl)
        {
            pageTransition.ShowPage(userControl);
        }

        public void SwitchToMainFrame(string projectID)
        {

        }

        public void SwitchToProjectListPage()
        {
            throw new NotImplementedException();
        }

        public void LoginFinished(object sender, UserLogin e)
        {
            throw new NotImplementedException();
        }
    }
}
