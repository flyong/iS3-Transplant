using UnityEngine;
using System.Collections;
using System;
using Newtonsoft.Json;


namespace iS3UnityLib.Model.ObjModel
{
    /// <summary>
    /// 用于管理Unity内对象的状态
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class UnityObjModel
    {
        //name
        //fullpath

        #region parameters
    
        //对象Transform
        [JsonIgnore]
        public Transform myTran;
        [JsonIgnore]
        public string myPrefab = "";

        //对象名称
        private string _name;
        public string Name
        {
            get { return _name; }
        }
    

        //对象状态
        [JsonIgnore]
        public UnityObjStateModel myState { get; set; }
        #endregion

        public UnityObjModel(Transform aTran, string aName, bool aIsVisible,bool aIsSelected)
        {
            myTran = aTran;
            _name = aName;
        }
    }

}
