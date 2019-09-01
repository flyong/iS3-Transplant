//using UnityEngine;
//using System.Collections.Generic;
//using System;

//namespace iS3UnityLib.Model.ObjModel
//{
//    public class UnityMeshModel
//    {
//        #region params
//        //Mesh name
//        private string _name="gameobject";
//        public string name
//        {
//            get { return _name; }
//            set { _name = value; }
//        }
//        //Mesh Type
//        private UnityMeshType _type;
//        public UnityMeshType type
//        {
//            get { return _type; }
//            set { _type = value; }
//        }

//        private Vector3[] _vectices;
//        public Vector3[] Vectices
//        {
//            get { return _vectices; }
//            set { _vectices = value; }
//        }
//        private int[] _triangeles;
//        public int[] Triangeles
//        {
//            get { return _triangeles; }
//            set { _triangeles = value; }
//        }
//        private Vector3[] _normals;
//        public Vector3[] normals
//        {
//            get { return _normals; }
//            set { _normals = normals; }
//        }
//        private Vector3 _postion;
//        public Vector3 position
//        {
//            get { return _postion; }
//            set { _postion = value; }
//        }
//        private Vector3 _scale;
//        public Vector3 scale
//        {
//            get { return _scale; }
//            set { _scale = value; }
//        }
//        #endregion
//        public UnityMeshModel(Vector3[] _v,int[] _t,UnityMeshType _ty,Vector3[] _n=null)
//        {
//            Vectices = _v;
//            Triangeles = _t;
//            type = _ty;
//            normals = _n;
//        }
//        public UnityMeshModel GetMeshModelForIS3()
//        {
//            return UnityMeshType.ForIS3 == type ? this : UnityMeshHelp.CompressMeshModel(this);                                                                                                                                                                        
//        }
//        public UnityMeshModel GetMeshModelForUnity()
//        {
//            return UnityMeshType.ForUnity == type ? this : UnityMeshHelp.UnCompressMeshModel(this);
//        }
//    }
//    [Serializable]
//    public enum UnityMeshType
//    {
//        ForIS3,
//        ForUnity
//    }

//}


