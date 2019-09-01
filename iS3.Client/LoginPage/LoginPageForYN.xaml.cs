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

using iS3.Core;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using iS3.Core.Client;
using iS3.Core.Client.Service;
using iS3.Core.Model;
using iS3.Client.Controls;
using System.Globalization;

namespace iS3.Client
{
    /// <summary>
    /// UserLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPageForYN : UserControl, ILogin
    {
        //private XDocument xml = XDocument.Load(Runtime.configurationPath);

        public event EventHandler<ResultData> UserLoginFinished;
        public UserViewModel userloader;


        public LoginPageForYN()
        {
            InitializeComponent();


            //读取xml配置到界面
            //InitialLogin();
            LoadUsers("YN");
        }
        public void LoadUsers(string projectID)
        {
            userloader = new UserViewModel();
            userloader.Load(projectID);
          
        }
        private void config_Click(object sender, RoutedEventArgs e)
        {
            configgrid.Visibility = Visibility.Visible;
            logingrid.Visibility = Visibility.Hidden;
        }

        #region 按钮事件
        async void DoLoadTask()
        {
            ProgressTips progress_window = new ProgressTips();
            progress_window.Show();
            await Task.Run(() =>
            {
                //progress_window.Show();
                progress_window.btnProcess_Click();
            });
        }
        //登陆验证
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            ServiceConfig.IP = txtBoxIP.Text.ToString();
            ServiceConfig.PortNum = txtBoxPort.Text.ToString();

            ResultData resultData = await CommonRepo.GetLoginResult(txtBoxName.Text, txtBoxName2.Text);
            Runtime.Username = txtBoxName.Text;
            Runtime.Password = txtBoxName2.Text;
            Runtime.filtercontent = "Account or Password is wrong!";
            foreach (Useraccount _account in userloader.Users)
            {
                if ((_account.Username == Runtime.Username) && (_account.Password==Runtime.Password))
                {
                    Runtime.filtercontent = _account.filtercontent;
                }
            }
            if (Runtime.filtercontent== "Account or Password is wrong!")
            {
                MessageBox.Show(Runtime.filtercontent);
                return;
            }
            if (UserLoginFinished != null)
            {
                DoLoadTask();
                UserLoginFinished(this, null);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            txtBoxPort.Text = "";
            txtBoxIP.Text = "";
            configgrid.Visibility = Visibility.Hidden;
            logingrid.Visibility = Visibility.Visible;
        }
        private void txtBoxName2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void txtBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
        #endregion

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            configgrid.Visibility = Visibility.Hidden;
            logingrid.Visibility = Visibility.Visible;
        }
    }
  
}
