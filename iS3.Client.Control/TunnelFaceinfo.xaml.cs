using System.Windows;
using System.Windows.Controls;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Client;
using System.Collections.Generic;
using System;
using iS3.Draw;
using System.Reflection;
using System.Windows.Data;
using System.ComponentModel;
using iS3.Core.Client.Service;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace iS3.Client.Controls
{
    /// <summary>
    /// TunnelFaceinfo.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class TunnelFaceinfo : Window
    {
        public TunnelFaceinfo()
        {
            InitializeComponent();
            Loaded += TunnelFaceinfo_Loaded;
        }



        private void TunnelFaceinfo_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //服务端读取及存储地址由服务端DataPath定义，目前为C:/filedata/YN
        //掌子面文件命名规则："掌子面_K?+???"

        private void Uploadfile(object sender, RoutedEventArgs e)
        {
            UploadfileAsync();
        }
        private async Task UploadfileAsync()
        {

            string resultFile;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                resultFile = openFileDialog1.FileName;
                // string filename = resultFile.Substring(resultFile.LastIndexOf('\\') + 1);
                //string pathname = resultFile.Substring(0, resultFile.LastIndexOf('\\') + 1);
                string result = await FileService.UpLoad(resultFile, "YN");
                System.Windows.Forms.MessageBox.Show(result);
                //this.Close();
            }
        }

        private void Downloadfile(object sender, RoutedEventArgs e)
        {
            DownloadfileAsync();
        }
        private  async  Task DownloadfileAsync()
        {
            string destnationfolder = myLabl.Content.ToString();
            if (!Directory.Exists(destnationfolder))
            {
                System.Windows.Forms.MessageBox.Show("请选择下载到本机的文件夹！");
                return;
            }
            int p1, p2;
            if ((!int.TryParse(pile1.Text, out p1)) || (!int.TryParse(pile2.Text, out p2)))
            {
                System.Windows.Forms.MessageBox.Show("桩号输入错误，请输入数字！");
                return;
            }
            string filename = "掌子面_K" + pile1.Text + "+" + pile2.Text + ".jpg";
            string result = await FileService.DownLoad(destnationfolder, "YN", filename);
            System.Windows.Forms.MessageBox.Show(result);
        }



        private void DestnationFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;

            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                myLabl.Content = dialog.SelectedPath;
            }
        }


    }
}