using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;
using allinpay.O2O.Cmn;

namespace AreaUI.Model
{
    [System.Runtime.Serialization.DataContract]
    [Serializable]
    public class V_CategoryEntity : IComparable<V_CategoryEntity>
    {
        public V_CategoryEntity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _CategoryID;
        private int _C1SysNo;
        private int _C2SysNo;
        private string _C1Name;
        private string _C2Name;
        private string _C3Name;
        private int _Status;
        private int _SortNo;
        private int _LastUpdateUser;
        private DateTime _LastUpdateTime;
        private string _OuterNo;
        private int _Category_360_SysNo;
        private string _Category_360_APIName;
        private string _Category_360_APINameEnd;
        private int _CategoryType;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string CategoryID
        {
            set { _CategoryID = value; }
            get { return _CategoryID; }
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
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public int SortNo
        {
            set { _SortNo = value; }
            get { return _SortNo; }
        }

        [DataMember]
        public int LastUpdateUser
        {
            set { _LastUpdateUser = value; }
            get { return _LastUpdateUser; }
        }

        [DataMember]
        public DateTime LastUpdateTime
        {
            set { _LastUpdateTime = value; }
            get { return _LastUpdateTime; }
        }

        [DataMember]
        public string OuterNo
        {
            set { _OuterNo = value; }
            get { return _OuterNo; }
        }

        [DataMember]
        public int Category_360_SysNo
        {
            set { _Category_360_SysNo = value; }
            get { return _Category_360_SysNo; }
        }

        [DataMember]
        public string Category_360_APIName
        {
            set { _Category_360_APIName = value; }
            get { return _Category_360_APIName; }
        }

        [DataMember]
        public string Category_360_APINameEnd
        {
            set { _Category_360_APINameEnd = value; }
            get { return _Category_360_APINameEnd; }
        }

        [DataMember]
        public int CategoryType
        {
            set { _CategoryType = value; }
            get { return _CategoryType; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CategoryID = AppConst.StringNull;
            C1SysNo = AppConst.IntNull;
            C2SysNo = AppConst.IntNull;
            C1Name = AppConst.StringNull;
            C2Name = AppConst.StringNull;
            C3Name = AppConst.StringNull;
            Status = AppConst.IntNull;
            SortNo = AppConst.IntNull;
            LastUpdateUser = AppConst.IntNull;
            LastUpdateTime = AppConst.DateTimeNull;
            OuterNo = AppConst.StringNull;
            Category_360_SysNo = AppConst.IntNull;
            Category_360_APIName = AppConst.StringNull;
            Category_360_APINameEnd = AppConst.StringNull;
            CategoryType = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(V_CategoryEntity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}