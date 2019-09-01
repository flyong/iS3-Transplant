using iS3.ArcGIS.Geometry;
using iS3.ArcGIS.Graphics;
using iS3.Client.Controls.WpfPageTransitions;
using iS3.Core.Client;
using iS3.Core.Client.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Telerik.Windows.Controls;

namespace iS3.Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        static IS3GraphicEngine _graphicEngine = new IS3GraphicEngine();
        static IS3GeometryEngine _geometryEngine = new IS3GeometryEngine();

        public App()
        {
            Startup += App_Startup;
            Exit += App_Exit;
        }
        void Application_Startup(object sender, StartupEventArgs e)
        {
            StyleManager.ApplicationTheme = new Windows7Theme();
            Globals.iS3Core = new IS3RuntimeControl();

          //  XDocument xml = XDocument.Load(Runtime.configurationPath);
           // string version = xml.Root.Element("Version").Value;
            Globals.iS3Core.SetPageHolder(new IS3MainWindow());
            //Normal Style
             Globals.iS3Core.SetLogin(new LoginPageForYN());


          // Globals.iS3Core.SetProjectList(new ProjectListPageNormal());
            Globals.iS3Core.SetProjectList(new ProjectListPageForZHGL());
           // Globals.iS3Core.SetMainFrame(new MainFrameNormal());

            // Telerik Style
            //Globals.iS3Core.SetLogin(new LoginPageForMon());
            //Globals.iS3Core.SetMainFrame(new MainFrameForMon());
            //Globals.iS3Core.SetProjectList(new ProjectListPageForMon());
            Globals.iS3Core.SetMainFrame(new MainFrameForZHGL());


            //zhgl
            //Globals.iS3Core.SetLogin(new LoginPageForZHGL());

            Globals.iS3Core.SetPageTransition(new PageTransition());
            Globals.iS3Core.MainWindowShow();
            //ServiceConfig.IP = "192.168.10.23";
            //ServiceConfig.PortNum = "8012";
  
            //Globals.iS3Core.myMainFrame.projectID = "YN";
            Globals.iS3Core.SetPageShow(PageType.LoginPage);

            try
            {
                //string exeLocation = Assembly.GetExecutingAssembly().Location;
                //string exePath = System.IO.Path.GetDirectoryName(exeLocation);
                //DirectoryInfo di = System.IO.Directory.GetParent(exePath);
                //string rootPath = di.FullName;
                string rootPath = "C:\\LaoYingData";
                string dataPath = rootPath + "\\Data";
                string tilePath = dataPath + "\\TPKs";
                Runtime.rootPath = rootPath;
                Runtime.dataPath = dataPath;
                Runtime.tilePath = tilePath;
                Runtime.servicePath = rootPath + "\\bin\\Servers";
                Runtime.configurationPath = rootPath + "\\IS3-Configuration\\ServiceConfig.xml";

                //ArcGISRuntime.Initialize();
                Runtime.initializeEngines(_graphicEngine, _geometryEngine);
                Globals.application = this;
                Globals.mainthreadID = Thread.CurrentThread.ManagedThreadId;
                //Globals.iS3Service = ServiceImporter.LoadService(Runtime.servicePath);
                //test();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                // Exit application
                this.Shutdown();
            }
        }
        void App_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                //string exeLocation = Assembly.GetExecutingAssembly().Location;
                //string exePath = System.IO.Path.GetDirectoryName(exeLocation);
                //DirectoryInfo di = System.IO.Directory.GetParent(exePath);
                //string rootPath = di.FullName;
                string rootPath = "C:\\LaoYingData";
                string dataPath = rootPath + "\\Data";
                string tilePath = dataPath + "\\TPKs";
                Runtime.rootPath = rootPath;
                Runtime.dataPath = dataPath;
                Runtime.tilePath = tilePath;
                Runtime.servicePath = rootPath + "\\bin\\Servers";
                Runtime.configurationPath = rootPath + "\\IS3-Configuration\\ServiceConfig.xml";

                //ArcGISRuntime.Initialize();
                Runtime.initializeEngines(_graphicEngine, _geometryEngine);
                Globals.application = this;
                Globals.mainthreadID = Thread.CurrentThread.ManagedThreadId;
                //Globals.iS3Service = ServiceImporter.LoadService(Runtime.servicePath);
                //test();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                // Exit application
                this.Shutdown();
            }
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
        }
    }
}
