using iS3.Core;
using iS3.Core.Client;
using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
namespace iS3.Client.Controls
{
    /// <summary>
    /// FileDownLoadWin.xaml 的交互逻辑
    /// </summary>
    public partial class FileDownLoadWin : Window
    {
        ObservableCollection<FileState> _fileList = new ObservableCollection<FileState>();
        string _projectid;
        public EventHandler<Project> ProjectTriggle;
        System.Threading.Timer timerThr;
        private delegate void SetTBMethodInvoke(object sender);
        public FileDownLoadWin(string projectid)
        {
            InitializeComponent();
            int index = 1;

            _projectid = projectid;

        }
        public void SetTB(object value)
        {
            try
            {
                _fileList[nowindex].DownloadState = ftp.tot.ToString();
            }
            catch { }
        }
        private async void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            ftp.fileDownLoadWin = this;


            //调用方法                
            Thread th = new Thread(StartDownload);
            th.Start(); //启动线程

        }
        public void StartDownload()
        {
            int index = -1;

            while (index < _fileList.Count - 1)
            {
                index++;
                nowindex = index;
                ftp.Download(_fileList[index]);
            }
            Thread.Sleep(2000);
            if (ProjectTriggle != null)
            {
                ProjectTriggle(this, new Project() { projectID = _projectid, });
            }
        }
        public int nowindex;

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        Dictionary<string, int> existFile;
        Dictionary<string, int> NoFile;
        FTP ftp;
        //如果文件不存在，则从服务器下载相应的文件
        public bool CheckFileExistAsync(string projectID)
        {
            ftp = new FTP(projectID);
            Dictionary<string, int> fileDict = ftp.GetFileList();

            existFile = new Dictionary<string, int>();
            NoFile = new Dictionary<string, int>();
            foreach (string filename in fileDict.Keys)
            {
                if (File.Exists(GetFilePath(filename, projectID)))
                {
                    existFile[filename] = fileDict[filename];
                }
                else
                {
                    NoFile[filename] = fileDict[filename];
                }
            }
            int index = 1;
            foreach (string key in NoFile.Keys)
            {
                FileState file = new FileState()
                {
                    ID = index,
                    Filename = key,
                    FileLength = String.Format("{0:F1}", fileDict[key] * 1.0f / 1024 / 1024) + "M",
                    DownloadState = "0.00%"
                };
                file.setTot(fileDict[key]);
                _fileList.Add(file);
                index++;
            }
            DownloadDG.ItemsSource = _fileList;
            if (NoFile.Count == 0) return true;
            else return false;

        }

        string GetFilePath(string filename, string projectid)
        {
            if (filename.ToUpper().EndsWith("TPK"))
            {
                return Runtime.dataPath + "\\TPKs\\" + filename;
            }
            else
            {
                return Runtime.dataPath + "\\" + projectid + "\\" + filename;
            }
        }
    }
    public class FileState : INotifyPropertyChanged
    {
        int tot;
        public int getTot()
        {
            return tot;
        }
        public void setTot(int value)
        {
            tot = value;
        }
        int id;
        string filename;
        string filelength;
        string downloadstate;
        public int ID
        {
            get { return id; }
            set
            {
                if ((PropertyChanged != null) && (id != value))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ID"));
                }
                id = value;
            }
        }
        public string Filename
        {
            get { return filename; }
            set
            {
                if ((PropertyChanged != null) && (filename != value))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Filename"));
                }
                filename = value;
            }
        }
        public string FileLength
        {
            get { return filelength; }
            set
            {
                if ((PropertyChanged != null) && (filelength != value))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FileLength"));
                }
                filelength = value;
            }
        }
        public string DownloadState
        {
            get { return downloadstate; }
            set
            {
                if ((PropertyChanged != null) && (downloadstate != value))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DownloadState"));
                }
                downloadstate = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
