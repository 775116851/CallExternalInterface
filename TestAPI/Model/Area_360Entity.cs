using System;
using System.Collections.Generic;
using System.Text;
using allinpay.O2O.Cmn;
using System.Runtime.Serialization;

namespace TestAPI.Model
{
    [System.Runtime.Serialization.DataContract]
    [Serializable]
    public class Area_360Entity : IComparable<Area_360Entity>
    {
        public Area_360Entity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CitySysNo;
        private int _DistrictSysNo;
        private string _Code;
        private string _CityName;
        private string _DistrictName;
        private string _ZoneName;
        private int _Classid;
        private int _Hatrank;
        private int _Status;
        private DateTime _LastUpdateTime;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int CitySysNo
        {
            set { _CitySysNo = value; }
            get { return _CitySysNo; }
        }

        [DataMember]
        public int DistrictSysNo
        {
            set { _DistrictSysNo = value; }
            get { return _DistrictSysNo; }
        }

        [DataMember]
        public string Code
        {
            set { _Code = value; }
            get { return _Code; }
        }

        [DataMember]
        public string CityName
        {
            set { _CityName = value; }
            get { return _CityName; }
        }

        [DataMember]
        public string DistrictName
        {
            set { _DistrictName = value; }
            get { return _DistrictName; }
        }

        [DataMember]
        public string ZoneName
        {
            set { _ZoneName = value; }
            get { return _ZoneName; }
        }

        [DataMember]
        public int Classid
        {
            set { _Classid = value; }
            get { return _Classid; }
        }

        [DataMember]
        public int Hatrank
        {
            set { _Hatrank = value; }
            get { return _Hatrank; }
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
            CitySysNo = AppConst.IntNull;
            DistrictSysNo = AppConst.IntNull;
            Code = AppConst.StringNull;
            CityName = AppConst.StringNull;
            DistrictName = AppConst.StringNull;
            ZoneName = AppConst.StringNull;
            Classid = AppConst.IntNull;
            Hatrank = AppConst.IntNull;
            Status = AppConst.IntNull;
            LastUpdateTime = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(Area_360Entity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}