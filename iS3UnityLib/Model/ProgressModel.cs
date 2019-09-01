using UnityEngine;
using System.Collections;
using System;
using Newtonsoft.Json;


namespace iS3UnityLib.Model.ObjModel
{
    /// <summary>
    /// 用于管理Unity内对象的状态
    /// </summary>
    public class ProgressModel
    {
        public string CoordinateSystem;
        public string CoordinateAxis;
        public string CalculateType;
        public float total;
        public float lastProgress;
        public float nowProgress;
    }

}
