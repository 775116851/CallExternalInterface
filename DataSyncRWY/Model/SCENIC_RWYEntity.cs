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
    public class SCENIC_RWYEntity : IComparable<SCENIC_RWYEntity>
    {
        public SCENIC_RWYEntity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _ScenicId;
        private string _Name;
        private string _ShortName;
        private string _TicketType;
        private string _Star;
        private string _OpenTime;
        private string _BestTravelTime;
        private string _Notice;
        private string _Description;
        private string _ImgUrl;
        private string _Status;
        private string _Contact;
        private string _Addr;
        private string _Latitude;
        private string _Longitude;
        private string _ProvinceName;
        private string _CityName;
        private string _Transportation;
        private string _IsRealName;
        private string _StartDateFlag;
        private string _IdCardNeeded;
        private string _ScenicDesc;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string ScenicId
        {
            set { _ScenicId = value; }
            get { return _ScenicId; }
        }

        [DataMember]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        [DataMember]
        public string ShortName
        {
            set { _ShortName = value; }
            get { return _ShortName; }
        }

        [DataMember]
        public string TicketType
        {
            set { _TicketType = value; }
            get { return _TicketType; }
        }

        [DataMember]
        public string Star
        {
            set { _Star = value; }
            get { return _Star; }
        }

        [DataMember]
        public string OpenTime
        {
            set { _OpenTime = value; }
            get { return _OpenTime; }
        }

        [DataMember]
        public string BestTravelTime
        {
            set { _BestTravelTime = value; }
            get { return _BestTravelTime; }
        }

        [DataMember]
        public string Notice
        {
            set { _Notice = value; }
            get { return _Notice; }
        }

        [DataMember]
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        [DataMember]
        public string ImgUrl
        {
            set { _ImgUrl = value; }
            get { return _ImgUrl; }
        }

        [DataMember]
        public string Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public string Contact
        {
            set { _Contact = value; }
            get { return _Contact; }
        }

        [DataMember]
        public string Addr
        {
            set { _Addr = value; }
            get { return _Addr; }
        }

        [DataMember]
        public string Latitude
        {
            set { _Latitude = value; }
            get { return _Latitude; }
        }

        [DataMember]
        public string Longitude
        {
            set { _Longitude = value; }
            get { return _Longitude; }
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
        public string Transportation
        {
            set { _Transportation = value; }
            get { return _Transportation; }
        }

        [DataMember]
        public string IsRealName
        {
            set { _IsRealName = value; }
            get { return _IsRealName; }
        }

        [DataMember]
        public string StartDateFlag
        {
            set { _StartDateFlag = value; }
            get { return _StartDateFlag; }
        }

        [DataMember]
        public string IdCardNeeded
        {
            set { _IdCardNeeded = value; }
            get { return _IdCardNeeded; }
        }

        [DataMember]
        public string ScenicDesc
        {
            set { _ScenicDesc = value; }
            get { return _ScenicDesc; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            ScenicId = AppConst.StringNull;
            Name = AppConst.StringNull;
            ShortName = AppConst.StringNull;
            TicketType = AppConst.StringNull;
            Star = AppConst.StringNull;
            OpenTime = AppConst.StringNull;
            BestTravelTime = AppConst.StringNull;
            Notice = AppConst.StringNull;
            Description = AppConst.StringNull;
            ImgUrl = AppConst.StringNull;
            Status = AppConst.StringNull;
            Contact = AppConst.StringNull;
            Addr = AppConst.StringNull;
            Latitude = AppConst.StringNull;
            Longitude = AppConst.StringNull;
            ProvinceName = AppConst.StringNull;
            CityName = AppConst.StringNull;
            Transportation = AppConst.StringNull;
            IsRealName = AppConst.StringNull;
            StartDateFlag = AppConst.StringNull;
            IdCardNeeded = AppConst.StringNull;
            ScenicDesc = AppConst.StringNull;
        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SCENIC_RWYEntity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}
