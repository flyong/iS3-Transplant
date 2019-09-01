using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using iS3.Core.Client;

namespace iS3.Client.Controls
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public class FTP
    {
        public FileDownLoadWin fileDownLoadWin;
        string ip = "139.196.73.142";
        string name = "ts";
        string password = "ts65986858";
        string projectid;
        private int ftpport = 21;

        private NetworkCredential networkCredential;

        private string ftpUristring = null;
        private string currentDir = "/";

        public EventHandler<FileState> FileStateHandler;
        public FTP(string _projectid)
        {
            projectid = _projectid;
            ftpUristring = "ftp://" + ip;
            networkCredential = new NetworkCredential(name, password);
        }
        public Dictionary<string, int> GetFileList()
        {
            string uri = string.Empty;
            if (currentDir == "/")
            {
                uri = ftpUristring;
            }
            else
            {
                uri = ftpUristring + currentDir;
            }
            uri += "/" + projectid;
            string[] urifield = uri.Split(' ');
            uri = urifield[0];
            FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.ListDirectoryDetails);

            FtpWebResponse response = GetFtpResponse(request);
            if (response == null)
            {
                return null;
            }
            //读取网络流数据
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);

            string s = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            response.Close();

            //处理并显示文件目录列表
            string[] ftpdir = s.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < ftpdir.Length; i++)
            {
                try
                {
                    string line = ftpdir[i];
                    if (line.EndsWith(".")) continue;
                    string[] _strs = line.Split(' ');
                    List<string> strs = new List<string>();
                    for (int j = 0; j < _strs.Count(); j++)
                    {
                        if (_strs[j] != "") strs.Add(_strs[j]);
                    }
                    string filename = strs[strs.Count - 1];
                    int length = int.Parse(strs[strs.Count - 5]);
                    dic.Add(filename, length);
                }
                catch (Exception ex)
                {

                }
            }
            return dic;
        }

        string GetSaveFilePath(string filename)
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
        public int tot;
        public bool Download(FileState fileState)
        {
            tot = 0;
            float all = fileState.getTot();
            string DestnationPath = GetSaveFilePath(fileState.Filename);
            try
            {
                string uri = string.Empty;
                if (currentDir == "/")
                {
                    uri = ftpUristring;
                }
                else
                {
                    uri = ftpUristring + currentDir;
                }
                uri += "/" + projectid + "/" + fileState.Filename;
                FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.DownloadFile);
                FtpWebResponse response = GetFtpResponse(request);
                if (response == null)
                {
                    //AddInfo("服务器未响应...");
                    return false;
                }

                Stream responseStream = response.GetResponseStream();
                FileStream filestream = File.Create(DestnationPath);
                int buflength = 8196;
                byte[] buffer = new byte[buflength];

                int bytesRead = 1;
                while (bytesRead != 0)
                {
                    bytesRead = responseStream.Read(buffer, 0, buflength);
                    filestream.Write(buffer, 0, bytesRead);
                    tot += bytesRead;
                    fileState.DownloadState = String.Format("{0:F1}", tot * 100.0f / all) + "%";
                }

                responseStream.Close();
                filestream.Close();
                return true;
            }
            catch (WebException ex)
            {
                return true;
            }
        }


        //创建FTP请求
        private FtpWebRequest CreateFtpWebRequest(string uri, string requestMethod)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(uri);
            request.Credentials = networkCredential;
            request.KeepAlive = true;
            request.UseBinary = true;
            request.Method = requestMethod;
            return request;
        }

        //获取FTP响应
        private FtpWebResponse GetFtpResponse(FtpWebRequest request)
        {
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
                //AddInfo(response.BannerMessage.TrimEnd());//220 Microsoft FTP Service
                //AddInfo(response.WelcomeMessage);//230 User logged in.
                return response;
            }
            catch (Exception err)
            {
                // AddInfo("Error     ：" + err.Message);
                return null;
            }
        }
        #region 对文件的操作模块实现

        private string GetUriString(string filename)
        {
            string uri = string.Empty;
            if (currentDir.EndsWith("/"))
            {
                uri = ftpUristring + currentDir + filename;    //根目录下
            }
            else
            {
                uri = ftpUristring + currentDir + "/" + filename;
            }

            return uri;
        }
        // 从服务器上下载文件到本地事件
        private void btndownload_Click(object sender, RoutedEventArgs e)
        {
            //string fileName = GetSelectedFile();
            string fileName = "";
            if (fileName.Length == 0)
            {
                MessageBox.Show("请选择要下载的文件！", "提示");
                return;
            }

            // 选择保存文件的位置
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "所有文件(*.*)|(*.*)";
            if (saveFileDialog.ShowDialog() != true)
            {
                return;
            }

            string DestnationPath = saveFileDialog.FileName;
            try
            {
                string uri = GetUriString(fileName);
                FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.DownloadFile);
                FtpWebResponse response = GetFtpResponse(request);
                //AddInfo("Retr请求    ：" + uri + "   " + WebRequestMethods.Ftp.DownloadFile + "\r\n");
                //AddInfo("Retr连接成功：" + response.StatusDescription.TrimEnd());//125 Data connection already open; Transfer starting.

                if (response == null)
                {
                    //AddInfo("服务器未响应...");
                    return;
                }

                Stream responseStream = response.GetResponseStream();
                FileStream filestream = File.Create(DestnationPath);
                int buflength = 8196;
                byte[] buffer = new byte[buflength];
                //AddInfo("Retr获取数据：...........");

                int bytesRead = 1;
                while (bytesRead != 0)
                {
                    bytesRead = responseStream.Read(buffer, 0, buflength);
                    filestream.Write(buffer, 0, bytesRead);
                }

                responseStream.Close();
                filestream.Close();
                //AddInfo("Retr传输完成：。\r\n____________________________________________________________________\r\n\r\n");

                MessageBox.Show("下载完成！");
            }
            catch (WebException ex)
            {
                //AddInfo("发生错误，返回状态为：" + ex.Status);
                MessageBox.Show(ex.Message, "下载失败");
            }
        }

        //// 上传文件到服务器事件
        //private void btnUpload_Click(object sender, RoutedEventArgs e)
        //{
        //    // 选择要上传的文件
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.FileName = openFileDialog.FileNames.ToString();
        //    openFileDialog.Filter = "所有文件(*.*)|*.*";
        //    if (openFileDialog.ShowDialog() != true)
        //    {
        //        return;
        //    }
        //    FileInfo fileinfo = new FileInfo(openFileDialog.FileName);


        //    try
        //    {
        //        FileStream filestream = fileinfo.OpenRead(); ;



        //        string uri = GetUriString(fileinfo.Name);
        //        FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.UploadFile);
        //        request.ContentLength = fileinfo.Length;
        //        Stream requestStream = request.GetRequestStream();



        //        int buflength = 8196;
        //        byte[] buffer = new byte[buflength];

        //        int contenlength = filestream.Read(buffer, 0, buflength);
        //        while (contenlength != 0)
        //        {
        //            requestStream.Write(buffer, 0, contenlength);
        //            contenlength = filestream.Read(buffer, 0, buflength);
        //        }

        //        requestStream.Close();
        //        filestream.Close();




        //        FtpWebResponse response = GetFtpResponse(request);
        //        AddInfo("Stor请求    ：" + uri + "   " + WebRequestMethods.Ftp.UploadFile + "\r\n");


        //        if (response == null)
        //        {
        //            lstbxFtpState.Items.Add("服务器未响应...");
        //            lstbxFtpState.TabIndex = lstbxFtpState.Items.Count - 1;
        //            return;
        //        }

        //        AddInfo($"Stor上传完成：{response.StatusDescription}_________________________________\r\n\r\n");
        //        MessageBox.Show("上传成功！");

        //        // 上传成功后，立即刷新服务器目录列表
        //        ShowFtpFileAndDirectory();
        //    }
        //    catch (WebException ex)
        //    {
        //        lstbxFtpState.Items.Add("上传发生错误，返回信息为：" + ex.Status);
        //        lstbxFtpState.TabIndex = lstbxFtpState.Items.Count - 1;
        //        MessageBox.Show(ex.Message, "上传失败");
        //    }
        //}


        #endregion




        #region ListBox写入记录
        //private delegate void AddInfoDelegate(string str);
        //private void AddInfo(string str)
        //{
        //    AddInfoDelegate d = new AddInfoDelegate(AddInfoForDelegate);
        //    this.Dispatcher.Invoke(d, str);
        //}
        //private void AddInfoForDelegate(string str)
        //{
        //    lstbxFtpState.Items.Add(DateTime.Now.ToString("HH:mm:ss") + "  " + str);
        //    lstbxFtpState.ScrollIntoView(lstbxFtpState.Items[lstbxFtpState.Items.Count - 1]);
        //}


        #endregion



        //private void chkbxAnonymous_Click(object sender, RoutedEventArgs e)
        //{
        //    // 实名方式登录
        //    // 此时需要输入用户名和密码
        //    if (chkbxAnonymous.IsChecked == false)
        //    {
        //        tbxUsername.IsEnabled = true;
        //        tbxUsername.Text = "ftpAdmin";
        //        tbxPassword.IsEnabled = true;
        //        tbxPassword.Text = "65986858";
        //    }
        //    // 匿名方式
        //    else
        //    {
        //        tbxUsername.Text = "anonymous";
        //        tbxUsername.IsEnabled = false;
        //        tbxPassword.Text = "";
        //        tbxPassword.IsEnabled = false;
        //    }

        //}

        private void tbx_SelectAll(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectAll();
        }

    }
}
