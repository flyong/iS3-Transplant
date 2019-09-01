using iS3.Core.Client.ViewModel;
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
using iS3.Core.Model;
using iS3.Core.Client.Service;
using System.IO;
using iS3.Construction.Model;
using System.Diagnostics;
using iS3.Core.Client;

namespace iS3.Construction.Client
{
    /// <summary>
    /// ZZM_Show.xaml 的交互逻辑
    /// </summary>
    public partial class ZZM_Show : UserControl, IDGObjectView
    {
        ACHE _model;
        string destnationfolder;
        List<string> filenames;
        public ZZM_Show()
        {
            InitializeComponent();
            destnationfolder = Runtime.dataPath + "\\YN\\ZZM";
            filenames = new List<string>();
        }

        public UserControl ChartView()
        {
            return this;
        }

        public EngineeringMap SetIt(DGObject model)
        {
            return null;
        }

        public Task SetObjContent(DGObject model)
        {
            _model = new ACHE();
            _model = model as ACHE;
            return null;
        }

       
        private async void Uploadfile(object sender, RoutedEventArgs e)
        {
            await UploadfileAsync();
        }
        private async Task UploadfileAsync()
        {

            return;
        }

        private async void Downloadfile(object sender, RoutedEventArgs e)
        {
           await DownloadfileAsync();
        }

        private async Task DownloadfileAsync()
        {

            if (!Directory.Exists(destnationfolder))
            {
                System.IO.Directory.CreateDirectory(destnationfolder);
                
            }

            filenames = new List<string>();
            
            string url = ServiceConfig.BaseURL + string.Format(ServiceConfig.filenamelistFormat, "YN", "ACHE", "46");
            filenames = await CommonRepo.Getappendixnames(url);
            foreach (string filename in filenames)
            {
                string completename = destnationfolder + "\\" + filename;
                if (File.Exists(completename))
                {
                    continue;
                }
                string result = await FileService.DownLoad(destnationfolder, "YN", filename);

            }
            if (filenames.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("无相关附件！");
                return;
            }
            Process.Start(destnationfolder);
            System.Windows.Forms.MessageBox.Show("已为您打开附件文件夹！");
            return;
        }
    }
}
