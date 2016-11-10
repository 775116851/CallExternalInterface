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
    public class TICKET_RWYEntity : IComparable<TICKET_RWYEntity>
    {
        public TICKET_RWYEntity()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _TicketId;
        private string _Name;
        private string _ScenicId;
        private string _Status;
        private string _Description;
        private string _EndOfTime;
        private string _Notice;
        private string _OrderAdvanceHours;
        private string _OrderAdvanceDays;
        private string _OrderBeforeHour;
        private string _OrderBeforeMin;
        private string _MaxOrderAdvanceDays;
        private string _RefundAdvanceHours;
        private string _UseAdvanceHours;
        private string _AdditionalInfo;
        private string _EffectiveDate;
        private string _ValidWeeks;
        private string _ValidDates;
        private string _InvalidDates;
        private string _IsInvtLimit;
        private string _MaxOrderNum;
        private string _MinOrderNum;
        private string _ImgUrl;
        private string _SalePrice;
        private string _SuggestPrice;
        private string _MarketPrice;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string TicketId
        {
            set { _TicketId = value; }
            get { return _TicketId; }
        }

        [DataMember]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        [DataMember]
        public string ScenicId
        {
            set { _ScenicId = value; }
            get { return _ScenicId; }
        }

        [DataMember]
        public string Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        [DataMember]
        public string EndOfTime
        {
            set { _EndOfTime = value; }
            get { return _EndOfTime; }
        }

        [DataMember]
        public string Notice
        {
            set { _Notice = value; }
            get { return _Notice; }
        }

        [DataMember]
        public string OrderAdvanceHours
        {
            set { _OrderAdvanceHours = value; }
            get { return _OrderAdvanceHours; }
        }

        [DataMember]
        public string OrderAdvanceDays
        {
            set { _OrderAdvanceDays = value; }
            get { return _OrderAdvanceDays; }
        }

        [DataMember]
        public string OrderBeforeHour
        {
            set { _OrderBeforeHour = value; }
            get { return _OrderBeforeHour; }
        }

        [DataMember]
        public string OrderBeforeMin
        {
            set { _OrderBeforeMin = value; }
            get { return _OrderBeforeMin; }
        }

        [DataMember]
        public string MaxOrderAdvanceDays
        {
            set { _MaxOrderAdvanceDays = value; }
            get { return _MaxOrderAdvanceDays; }
        }

        [DataMember]
        public string RefundAdvanceHours
        {
            set { _RefundAdvanceHours = value; }
            get { return _RefundAdvanceHours; }
        }

        [DataMember]
        public string UseAdvanceHours
        {
            set { _UseAdvanceHours = value; }
            get { return _UseAdvanceHours; }
        }

        [DataMember]
        public string AdditionalInfo
        {
            set { _AdditionalInfo = value; }
            get { return _AdditionalInfo; }
        }

        [DataMember]
        public string EffectiveDate
        {
            set { _EffectiveDate = value; }
            get { return _EffectiveDate; }
        }

        [DataMember]
        public string ValidWeeks
        {
            set { _ValidWeeks = value; }
            get { return _ValidWeeks; }
        }

        [DataMember]
        public string ValidDates
        {
            set { _ValidDates = value; }
            get { return _ValidDates; }
        }

        [DataMember]
        public string InvalidDates
        {
            set { _InvalidDates = value; }
            get { return _InvalidDates; }
        }

        [DataMember]
        public string IsInvtLimit
        {
            set { _IsInvtLimit = value; }
            get { return _IsInvtLimit; }
        }

        [DataMember]
        public string MaxOrderNum
        {
            set { _MaxOrderNum = value; }
            get { return _MaxOrderNum; }
        }

        [DataMember]
        public string MinOrderNum
        {
            set { _MinOrderNum = value; }
            get { return _MinOrderNum; }
        }

        [DataMember]
        public string ImgUrl
        {
            set { _ImgUrl = value; }
            get { return _ImgUrl; }
        }

        [DataMember]
        public string SalePrice
        {
            set { _SalePrice = value; }
            get { return _SalePrice; }
        }

        [DataMember]
        public string SuggestPrice
        {
            set { _SuggestPrice = value; }
            get { return _SuggestPrice; }
        }

        [DataMember]
        public string MarketPrice
        {
            set { _MarketPrice = value; }
            get { return _MarketPrice; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            TicketId = AppConst.StringNull;
            Name = AppConst.StringNull;
            ScenicId = AppConst.StringNull;
            Status = AppConst.StringNull;
            Description = AppConst.StringNull;
            EndOfTime = AppConst.StringNull;
            Notice = AppConst.StringNull;
            OrderAdvanceHours = AppConst.StringNull;
            OrderAdvanceDays = AppConst.StringNull;
            OrderBeforeHour = AppConst.StringNull;
            OrderBeforeMin = AppConst.StringNull;
            MaxOrderAdvanceDays = AppConst.StringNull;
            RefundAdvanceHours = AppConst.StringNull;
            UseAdvanceHours = AppConst.StringNull;
            AdditionalInfo = AppConst.StringNull;
            EffectiveDate = AppConst.StringNull;
            ValidWeeks = AppConst.StringNull;
            ValidDates = AppConst.StringNull;
            InvalidDates = AppConst.StringNull;
            IsInvtLimit = AppConst.StringNull;
            MaxOrderNum = AppConst.StringNull;
            MinOrderNum = AppConst.StringNull;
            ImgUrl = AppConst.StringNull;
            SalePrice = AppConst.StringNull;
            SuggestPrice = AppConst.StringNull;
            MarketPrice = AppConst.StringNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(TICKET_RWYEntity other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}
