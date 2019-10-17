using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    /// <summary>
    /// common runtime global environment 
    /// 
    /// </summary>
    public static class Globals
    {
        public static IS3RuntimeControl iS3Core { get; set; }
        public static string token { get; set; }
        public static string projectcode { get; set; }
        public static IMainFrame mainFrame { get; set; }
        public static Project project { get; set; }
        public static System.Windows.Application application { get; set; }
        public static int mainthreadID { get; set; }
        public static bool isThreadUnsafe()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;
            if (Globals.mainthreadID != threadID)
                return true;
            else
                return false;
        }
        public static List<Tuple<string, string>> tunnelSectionList = new List<Tuple<string, string>>();
        public static List<string> tunnelPosList = new List<string>();
        public static List<string> tunnelPosList2 = new List<string>();
    }
}
