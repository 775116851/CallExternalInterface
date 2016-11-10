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
    public class AreaEntity : IComparable<AreaEntity>
    {
        public AreaEntity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _AreaID;
        private int _ProvinceSysNo;
        private int _CitySysNo;
        private int _DistrictSysNo;
        private string _ProvinceName;
        private string _CityName;
        private string _DistrictName;
        private string _ZoneName;
        private int _SortNo;
        private int _Status;
        private int _IsMaster;
        private int _IsOnlineShow;
        private int _LastUpdateUser;
        private DateTime _LastUpdateTime;
        private string _POSAreaCode;
        private string _customerSort;
        private int _OldSysNo;
        private int _OldProvinceSysNo;
        private int _OldCitySysNo;
        private int _OldDistrictSysNo;
        private int _Area_360_SysNo;
        private string _Area_360_CityName;
        private string _Area_360_ZoneName;
        private int _Area_RWY_SysNo;
        private int _AreaLevel;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string AreaID
        {
            set { _AreaID = value; }
            get { return _AreaID; }
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
        public int DistrictSysNo
        {
            set { _DistrictSysNo = value; }
            get { return _DistrictSysNo; }
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
        public int SortNo
        {
            set { _SortNo = value; }
            get { return _SortNo; }
        }

        [DataMember]
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public int IsMaster
        {
            set { _IsMaster = value; }
            get { return _IsMaster; }
        }

        [DataMember]
        public int IsOnlineShow
        {
            set { _IsOnlineShow = value; }
            get { return _IsOnlineShow; }
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
        public string POSAreaCode
        {
            set { _POSAreaCode = value; }
            get { return _POSAreaCode; }
        }

        [DataMember]
        public string CustomerSort
        {
            set { _customerSort = value; }
            get { return _customerSort; }
        }

        [DataMember]
        public int OldSysNo
        {
            set { _OldSysNo = value; }
            get { return _OldSysNo; }
        }

        [DataMember]
        public int OldProvinceSysNo
        {
            set { _OldProvinceSysNo = value; }
            get { return _OldProvinceSysNo; }
        }

        [DataMember]
        public int OldCitySysNo
        {
            set { _OldCitySysNo = value; }
            get { return _OldCitySysNo; }
        }

        [DataMember]
        public int OldDistrictSysNo
        {
            set { _OldDistrictSysNo = value; }
            get { return _OldDistrictSysNo; }
        }

        [DataMember]
        public int Area_360_SysNo
        {
            set { _Area_360_SysNo = value; }
            get { return _Area_360_SysNo; }
        }

        [DataMember]
        public string Area_360_CityName
        {
            set { _Area_360_CityName = value; }
            get { return _Area_360_CityName; }
        }

        [DataMember]
        public string Area_360_ZoneName
        {
            set { _Area_360_ZoneName = value; }
            get { return _Area_360_ZoneName; }
        }

        [DataMember]
        public int Area_RWY_SysNo
        {
            set { _Area_RWY_SysNo = value; }
            get { return _Area_RWY_SysNo; }
        }

        [DataMember]
        public int AreaLevel
        {
            set { _AreaLevel = value; }
            get { return _AreaLevel; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            AreaID = AppConst.StringNull;
            ProvinceSysNo = AppConst.IntNull;
            CitySysNo = AppConst.IntNull;
            DistrictSysNo = AppConst.IntNull;
            ProvinceName = AppConst.StringNull;
            CityName = AppConst.StringNull;
            DistrictName = AppConst.StringNull;
            ZoneName = AppConst.StringNull;
            SortNo = AppConst.IntNull;
            Status = AppConst.IntNull;
            IsMaster = AppConst.IntNull;
            IsOnlineShow = AppConst.IntNull;
            LastUpdateUser = AppConst.IntNull;
            LastUpdateTime = AppConst.DateTimeNull;
            POSAreaCode = AppConst.StringNull;
            CustomerSort = AppConst.StringNull;
            OldSysNo = AppConst.IntNull;
            OldProvinceSysNo = AppConst.IntNull;
            OldCitySysNo = AppConst.IntNull;
            OldDistrictSysNo = AppConst.IntNull;
            Area_360_SysNo = AppConst.IntNull;
            Area_360_CityName = AppConst.StringNull;
            Area_360_ZoneName = AppConst.StringNull;
            Area_RWY_SysNo = AppConst.IntNull;
            AreaLevel = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(AreaEntity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}