using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;

namespace iS3UnityLib.Model.ObjModel
{
    /// <summary>
    /// 三维模型状态类
    /// </summary>
    public class UnityObjStateModel
    {
        #region params
        /// <summary>
        /// 对象是够被激活
        /// </summary>
        private bool _isActive;
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }

        /// <summary>
        /// 对象是否被加载到场景中，针对可零件化对象
        /// </summary>
        private bool _hasLoaded;
        public bool HasLoaded { get { return _hasLoaded; } set { _hasLoaded = value; } }

        /// <summary>
        /// 对象是否处于被选中状态
        /// </summary>
        private bool _isSelected;
        public bool IsSelected { get { return _isSelected; }set { _isSelected = value; } }

        /// <summary>
        /// 对象是否可见
        /// </summary>
        private bool _isVisible;
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; } }
        #endregion
        public UnityObjStateModel(bool aIsActive, bool aHasLoaded, bool aIsVisible, bool aIsSelected)
        {
            IsActive = aIsActive;
            HasLoaded = aHasLoaded;
            IsVisible = aIsActive;
            IsSelected = aIsSelected;
        }
    }
}