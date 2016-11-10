using System;
using System.Collections.Generic;
using System.Text;
using allinpay.O2O.Cmn;
using System.Runtime.Serialization;

namespace TestAPI.Model
{
    [System.Runtime.Serialization.DataContract]
    [Serializable]
    public class Category_360Entity : IComparable<Category_360Entity>
    {
        public Category_360Entity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _Cateid;
        private int _C1SysNo;
        private int _C2SysNo;
        private string _C1Name;
        private string _C2Name;
        private string _C3Name;
        private string _Alias;
        private string _APIName;
        private string _APINameEnd;
        private int _Isred;
        private int _Isnew;
        private int _Minihot;
        private int _Minired;
        private int _Status;
        private DateTime _LastUpdateTime;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int Cateid
        {
            set { _Cateid = value; }
            get { return _Cateid; }
        }

        [DataMember]
        public int C1SysNo
        {
            set { _C1SysNo = value; }
            get { return _C1SysNo; }
        }

        [DataMember]
        public int C2SysNo
        {
            set { _C2SysNo = value; }
            get { return _C2SysNo; }
        }

        [DataMember]
        public string C1Name
        {
            set { _C1Name = value; }
            get { return _C1Name; }
        }

        [DataMember]
        public string C2Name
        {
            set { _C2Name = value; }
            get { return _C2Name; }
        }

        [DataMember]
        public string C3Name
        {
            set { _C3Name = value; }
            get { return _C3Name; }
        }

        [DataMember]
        public string Alias
        {
            set { _Alias = value; }
            get { return _Alias; }
        }

        [DataMember]
        public string APIName
        {
            set { _APIName = value; }
            get { return _APIName; }
        }

        [DataMember]
        public string APINameEnd
        {
            set { _APINameEnd = value; }
            get { return _APINameEnd; }
        }

        [DataMember]
        public int Isred
        {
            set { _Isred = value; }
            get { return _Isred; }
        }

        [DataMember]
        public int Isnew
        {
            set { _Isnew = value; }
            get { return _Isnew; }
        }

        [DataMember]
        public int Minihot
        {
            set { _Minihot = value; }
            get { return _Minihot; }
        }

        [DataMember]
        public int Minired
        {
            set { _Minired = value; }
            get { return _Minired; }
        }

        [DataMember]
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public DateTime LastUpdateTime
        {
            set { _LastUpdateTime = value; }
            get { return _LastUpdateTime; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Cateid = AppConst.IntNull;
            C1SysNo = AppConst.IntNull;
            C2SysNo = AppConst.IntNull;
            C1Name = AppConst.StringNull;
            C2Name = AppConst.StringNull;
            C3Name = AppConst.StringNull;
            Alias = AppConst.StringNull;
            APIName = AppConst.StringNull;
            APINameEnd = AppConst.StringNull;
            Isred = AppConst.IntNull;
            Isnew = AppConst.IntNull;
            Minihot = AppConst.IntNull;
            Minired = AppConst.IntNull;
            Status = AppConst.IntNull;
            LastUpdateTime = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(Category_360Entity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}