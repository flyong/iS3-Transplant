using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client.Service
{
    public static class ServiceConfig
    {
        public static bool NeedCache = false;
        //
        //public static string IP = "192.168.10.23";
        //public static string IP = "139.196.73.142";
        public static string IP = "localhost";
        public static string PortNum = "51529";
       // public static string PortNum = "8093";
        public static string BaseURL { get { return string.Format("http://{0}:{1}/", IP, PortNum); } }

        public static string loginURL { get { return "api/Project/login"; } }
        public static string signoutURL { get { return "api/Project/signout"; } }
        public static string datasourcetypeURL { get { return "api/Project/datasourcetype"; } }
        public static string datasourceinfoURL { get

            { return "api/Project/datasourceinfo"; } }
        public static string projectlistURL { get { return "api/project/projectlist"; } }
        public static string projectinfoFormat { get { return "api/project/projectinfo?project={0}"; } }
        public static string projectdomainFormat { get { return "api/project/domain?project={0}"; } }
        public static string fileFromat { get { return "api/file/{0}?file={1}"; } }
        public static string filenamelistFormat { get { return "api/file/{0}?DgobjectType={1}&ID={2}"; } }

        //gis
        public static string projectemapFormat { get { return "api/project/emap?project={0}"; } }

        public static string projecttreeFormat { get { return "api/project/tree?project={0}&domain={1}"; } }
        public static string projecttreeAddFormat { get { return "api/project/tree?project={0}&domain={1}&objtype={2}&objid={3}&parentID={4}"; } }
        public static string projectobjectdefinitionFormat { get { return "api/project/objectdefinition?project={0}&domain={1}"; } }

        public static string DGObjectRootFormat { get { return "api/{0}/{1}?project={2}"; } }
        /// <summary>
        /// 0-domain,1-objtype,2-project,3-objsid,4-filter
        /// </summary>
        public static string DGObjectsFormat { get { return "api/{0}/{1}?project={2}&objsid={3}&filter={4}"; } }
        /// <summary>
        /// 0-domain,-objtype,2-project,3-id
        /// </summary>
        public static string DGObjectFormat { get { return "api/{0}/{1}?project={2}&id={3}"; } }

    }
}
