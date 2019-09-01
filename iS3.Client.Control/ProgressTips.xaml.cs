using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using iS3.Core.Client;

namespace iS3.Client.Controls
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressTips : Window
    {
        public ProgressTips()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

        }
        Thread taskThread;
        public void btnProcess_Click()
        {
            taskThread = new Thread(DoTask);
            taskThread.Start();
                      
        }

        private void DoTask()
        {
            Int64 InputNum = (Int64)100;
            for (Int64 i = 0; i < InputNum; i++)
            {
                Thread.Sleep(300);
                this.Dispatcher.Invoke((Action)delegate ()
                {
                    this.progressBar.Value = i;
                    this.textBox.Text = i.ToString()+"%";
                });
            }
            MessageBox.Show("所有数据均已加载！", "info");
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                this.Close();
            });
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("取消加载成功！", "info");
            if (Globals.mainFrame != null)
            {
                Globals.mainFrame.Close();
            }
            //App app = Application.Current as App;
            //IS3MainWindow mw = (IS3MainWindow)app.MainWindow;
            //mw.Close();
            System.Environment.Exit(0);

        }
    }
}
