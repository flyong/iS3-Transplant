using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Diagnostics;
using iS3.Core.Client;

namespace iS3_DataManager.Service
{
    public  class DataFileService
    {
        string destnationfolder;
        string objectname;
        int objectid;
        public List<string> filenames;
        public DataFileService(string objectname, int objectid)
        {
            this.objectid = objectid;
            this.objectname = objectname;
            destnationfolder = Runtime.dataPath + "\\YN\\" + objectname + "\\";
        }

        public async void Uploadfile(object sender, RoutedEventArgs e)
        {
            await UploadfileAsync();
        }
        private async Task UploadfileAsync()
        {

            string resultFile,result;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Count(); i++)
                {
                    resultFile = System.IO.Path.GetFileName(openFileDialog1.FileNames[i]);
                    string filename = objectname+objectid.ToString()+ "_" + resultFile;
                    result = await FileService.UpLoad(openFileDialog1.FileNames[i], filename, "YN");
                    MessageBox.Show(result);
                }

            }
        }
        public async void Downloadfile(object sender, RoutedEventArgs e)
        {
            
            filenames = new List<string>();
            string url= ServiceConfig.BaseURL + string.Format(ServiceConfig.filenamelistFormat, "YN", objectname, objectid.ToString());
            filenames = await CommonRepo.Getappendixnames(url);
            DownloadList downloadfilewindow = new DownloadList(this);
            downloadfilewindow.Show();

            //await DownloadfileAsync();
        }
        public  async Task DownloadfileAsync()
        {

            if (!Directory.Exists(destnationfolder))
            {
                System.IO.Directory.CreateDirectory(destnationfolder);
            }

            
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
