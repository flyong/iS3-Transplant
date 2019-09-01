using iS3_DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3_DataManager.Interface
{
    //*
    // The Common Interface for DataStandard exporter, such as exporter to dll,json, and so on
    //
    public interface IDSExporter
    {
        //export dataStandard to ...
        //return the state of export
        bool Export(StandardDef dataStandard,string path=null );
        bool Export(StageDef domain, string path = null);
    }
}
