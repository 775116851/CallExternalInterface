using allinpay.O2O.Cmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DataSyncRWY.Model
{
    [System.Runtime.Serialization.DataContract]
    [Serializable]
    public class Area_RWYEntity : IComparable<Area_RWYEntity>
    {
        public Area_RWYEntity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _ProvinceSysNo;
        private int _CitySysNo;
        private string _RWYCode;
        private string _ProvinceName;
        private string _CityName;
        private string _ZoneName;
        private int _Status;
        private DateTime _LastUpdateTime;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int ProvinceSysNo
        {
            set { _ProvinceSysNo = value; }
            get { return _ProvinceSysNo; }
        }

        [DataMember]
        public int CitySysNo
        {
            set { _CitySysNo = value; }
            get { return _CitySysNo; }
        }

        [DataMember]
        public string RWYCode
        {
            set { _RWYCode = value; }
            get { return _RWYCode; }
        }

        [DataMember]
        public string ProvinceName
        {
            set { _ProvinceName = value; }
            get { return _ProvinceName; }
        }

        [DataMember]
        public string CityName
        {
            set { _CityName = value; }
            get { return _CityName; }
        }

        [DataMember]
        public string ZoneName
        {
            set { _ZoneName = value; }
            get { return _ZoneName; }
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
            ProvinceSysNo = AppConst.IntNull;
            CitySysNo = AppConst.IntNull;
            RWYCode = AppConst.StringNull;
            ProvinceName = AppConst.StringNull;
            CityName = AppConst.StringNull;
            ZoneName = AppConst.StringNull;
            Status = AppConst.IntNull;
            LastUpdateTime = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(Area_RWYEntity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
