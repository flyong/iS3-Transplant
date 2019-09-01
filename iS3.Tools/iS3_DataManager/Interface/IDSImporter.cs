using iS3_DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3_DataManager.Interface
{
    //*
    // The Common Interface for DataStandard importer, such as import from dll,json, and so on
    //
    public interface IDSImporter
    {
        StandardDef Import(string StandardName);
    }
}
