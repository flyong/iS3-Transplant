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
    /// TPZL_Show.xaml 的交互逻辑
    /// </summary>
    public partial class TPZL_Show : UserControl, IDGObjectView
    {
        TPZL _model;
        string destnationfolder;
        List<string> filenames;
        public TPZL_Show()
        {
            InitializeComponent();
            destnationfolder = Runtime.dataPath + "\\YN\\TPZL";
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
            _model = new TPZL();
            _model = model as TPZL;
            return null;
        }

        //文件名规则 TPZL_YK1+303-YK1+400_1.jpg
        private async void Uploadfile(object sender, RoutedEventArgs e)
        {
            await UploadfileAsync();
        }
        private async Task UploadfileAsync()
        {

            string resultFile;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Count(); i++)
                {
                    resultFile = openFileDialog1.FileNames[i];
                    string filename = "TPZL_" + _model.TPZL_ZHQJ + "_" + i.ToString() + ".jpg";
                    string result = await FileService.UpLoad(resultFile, filename, "YN");

                }
                // string filename = resultFile.Substring(resultFile.LastIndexOf('\\') + 1);
                //string pathname = resultFile.Substring(0, resultFile.LastIndexOf('\\') + 1);

                //this.Close();
            }
        }

        private async void Downloadfile(object sender, RoutedEventArgs e)
        {
           await DownloadfileAsync();
        }

        private async Task DownloadfileAsync()
        {

            if (!Directory.Exists(destnationfolder))
            {
                System.Windows.Forms.MessageBox.Show("请检查Data\\YN\\TPZL文件夹是否存在！");
                return;
            }

            filenames = new List<string>();
            for (int i = 0; i <= 20; i++)
            {
                string filename = "TPZL_" + _model.TPZL_ZHQJ + "_" + i.ToString() + ".jpg";
                string completename = destnationfolder + "\\" + filename;
                if (File.Exists(completename))
                {
                    filenames.Add(completename);
                    continue;
                }
                string result = await FileService.DownLoad(destnationfolder, "YN", filename);
                if (File.Exists(completename))
                    filenames.Add(completename);
                else
                    break;
            }
            if (filenames.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("无相关照片！");
                return;
            }
            if (filenames.Count == 1)
            {
                Process.Start(filenames[0]);
            }
            else
                Process.Start(destnationfolder);
            return;
        }
    }
}
