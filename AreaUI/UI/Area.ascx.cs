using allinpay.O2O.Cmn;
using AreaUI.DAL;
using AreaUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AreaUI.UI
{
    public partial class Area : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlAreaLevel.Attributes.Add("onchange", "AreaLevelChange" + ddlAreaLevel.ClientID + "(this.value)");
            ddlProvince.Attributes.Add("onchange", "ProvinceChange" + ddlProvince.ClientID + "(this.value)");
            ddlDistrict.Attributes.Add("onchange", "DistrictChange" + ddlDistrict.ClientID + "(this.value)");
            ddlCity.Attributes.Add("onchange", "CityChange" + ddlCity.ClientID + "(this.value)");
            ddlZone.Attributes.Add("onchange", "ZoneChange" + ddlZone.ClientID + "(this.value)");
            if (!IsPostBack)
            {
                BindArea();
            }
        }

        public void BindArea()
        {
            hidAreaSysNo.Value = AppConst.IntNull.ToString();
            if (!IsShowZone)
            {
                ddlZone.Visible = false;
            }
            if (!IsShowDistrict)
            {
                ddlDistrict.Visible = false;
            }
            if(ddlAreaLevel.Items.Count == 0)
            {
                BindAreaLevel();
            }
            if (ddlProvince.Items.Count == 0)
            {
                BindProvince();
            }
            ddlAreaLevel.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlProvince.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlCity.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlDistrict.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlZone.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
        }

        private void BindAreaLevel()
        {
            ddlAreaLevel.Items.Add(new ListItem("省级","1"));
            ddlAreaLevel.Items.Add(new ListItem("市级","2"));
            ddlAreaLevel.Items.Add(new ListItem("区级","3"));
            ddlAreaLevel.Items.Add(new ListItem("商圈","4"));
        }

        private void BindProvince()
        {
            Dictionary<int, AreaEntity> dic = new AreaDac().GetProvinces();
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlProvince.Items.Add(new ListItem(dic.Values.ElementAt(i).ProvinceName, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
        }

        private void BindCity(int provinceSysNo, int citySysNo)
        {
            if (Convert.ToInt32(hidAreaLevelSysNo.Value) <= 1 && hidAreaLevelSysNo.Value != "-9999")
            {
                return;
            }
            ddlCity.Enabled = (Enable && CityEnable);
            Dictionary<int, AreaEntity> dic = new AreaDac().GetCitiesByProvinceSysNo(provinceSysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlCity.Items.Add(new ListItem(dic.Values.ElementAt(i).CityName, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlCity.SelectedValue = citySysNo.ToString();
            hidCitySysNo.Value = citySysNo.ToString();
        }

        private void BindDistrict(int citySysNo, int districtSysNo)
        {
            if (Convert.ToInt32(hidAreaLevelSysNo.Value) <= 2 && hidAreaLevelSysNo.Value != "-9999")
            {
                return;
            }
            ddlDistrict.Enabled = (Enable && DistrictEnable);
            Dictionary<int, AreaEntity> dic = new AreaDac().GetDistrictsByCitySysNo(citySysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlDistrict.Items.Add(new ListItem(dic.Values.ElementAt(i).DistrictName, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlDistrict.SelectedValue = districtSysNo.ToString();
            hidDistrictSysNo.Value = districtSysNo.ToString();
        }

        private void BindZone(int districtSysNo, int zoneSysNo)
        {
            if (Convert.ToInt32(hidAreaLevelSysNo.Value) <= 3 && hidAreaLevelSysNo.Value != "-9999")
            {
                return;
            }
            ddlZone.Enabled = Enable;
            Dictionary<int, AreaEntity> dic = new AreaDac().GetZonesByDistrictSysNo(districtSysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlZone.Items.Add(new ListItem(dic.Values.ElementAt(i).ZoneName, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlZone.SelectedValue = zoneSysNo.ToString();
            hidZoneSysNo.Value = zoneSysNo.ToString();
        }

        private bool _Enable = true;
        public bool Enable
        {
            get { return _Enable; }
            set
            {
                if(value == false)
                {
                    ddlAreaLevel.Enabled = value;
                }
                ddlProvince.Enabled = value;
                _Enable = value;
            }
        }

        private bool _DistrictEnable = true;
        public bool DistrictEnable
        {
            get { return _DistrictEnable; }
            set
            {
                if (value == false)
                {
                    ddlDistrict.Enabled = value;
                    ddlCity.Enabled = value;
                    ddlProvince.Enabled = value;
                    _DistrictEnable = value;
                }
                if (DistrictSysNo != AppConst.IntNull)
                {
                    BindZone(DistrictSysNo, ZoneSysNo);
                }
            }
        }

        private bool _CityEnable = true;
        public bool CityEnable
        {
            get { return _CityEnable; }
            set
            {
                if (value == false)
                {
                    ddlCity.Enabled = value;
                    ddlProvince.Enabled = value;
                    _CityEnable = value;
                }
            }
        }

        private bool _IsShowZone = true;
        /// <summary>
        /// 是否显示商圈
        /// </summary>
        public bool IsShowZone
        {
            set { _IsShowZone = value; }
            get { return _IsShowZone; }
        }

        private bool _IsShowDistrict = true;
        /// <summary>
        /// 是否显示商圈
        /// </summary>
        public bool IsShowDistrict
        {
            set { _IsShowDistrict = value; }
            get { return _IsShowDistrict; }
        }

        public bool _IsAssignCurrent = true;
        /// <summary>
        /// 是否对当前所在层级数据赋值,在添加/保存数据时候使用
        /// </summary>
        public bool IsAssignCurrent
        {
            set { _IsAssignCurrent = value; }
            get { return _IsAssignCurrent; }
        }

        public int AreaSysNo
        {
            get
            {
                return Convert.ToInt32(hidAreaSysNo.Value);
            }
            set
            {
                hidAreaSysNo.Value = value.ToString();
                if (ddlProvince.Items.Count == 0)
                {
                    BindProvince();
                }
                if (value != AppConst.IntNull)
                {
                    AreaEntity model = new AreaDac().GetModel(value);
                    if (model != null)
                    {
                        hidProvinceSysNo.Value = model.ProvinceSysNo.ToString();
                        if (model.DistrictSysNo != AppConst.IntNull)//商圈
                        {
                            ddlProvince.SelectedValue = model.ProvinceSysNo.ToString();
                            BindCity(model.ProvinceSysNo, model.CitySysNo);
                            BindDistrict(model.CitySysNo, model.DistrictSysNo);
                            if (IsAssignCurrent)
                            {
                                BindZone(model.DistrictSysNo, model.SysNo);
                            }
                        }
                        else if (model.CitySysNo != AppConst.IntNull)//县
                        {
                            ddlProvince.SelectedValue = model.ProvinceSysNo.ToString();
                            BindCity(model.ProvinceSysNo, model.CitySysNo);
                            if (IsAssignCurrent)
                            {
                                BindDistrict(model.CitySysNo, model.SysNo);
                                if (CityEnable == false && DistrictEnable == true)
                                {
                                    BindZone(model.SysNo, ZoneSysNo);
                                }
                            }
                        }
                        else if (model.ProvinceSysNo != AppConst.IntNull)//市
                        {
                            ddlProvince.SelectedValue = model.ProvinceSysNo.ToString();
                            if (IsAssignCurrent)
                            {
                                BindCity(model.ProvinceSysNo, model.SysNo);
                            }
                        }
                        else
                        {
                            if (IsAssignCurrent)
                            {
                                ddlProvince.SelectedValue = model.SysNo.ToString();
                            }
                        }
                    }
                }
            }
        }

        public int AreaLevelSysNo
        {
            set
            {
                if (ddlAreaLevel.Items.Count == 0)
                {
                    BindAreaLevel();
                }
                hidAreaLevelSysNo.Value = value.ToString();
                ddlAreaLevel.SelectedValue = value.ToString();
                ddlAreaLevel.Enabled = false;
            }
            get { return Convert.ToInt32(hidAreaLevelSysNo.Value); }
        }

        public int ProvinceSysNo
        {
            set
            {
                hidProvinceSysNo.Value = value.ToString();
                if (CitySysNo == AppConst.IntNull)
                {
                    AreaSysNo = value;
                }
            }
            get { return Convert.ToInt32(hidProvinceSysNo.Value); }
        }

        public int CitySysNo
        {
            set
            {
                hidCitySysNo.Value = value.ToString();
                if (DistrictSysNo == AppConst.IntNull)
                {
                    AreaSysNo = value;
                }
            }
            get { return Convert.ToInt32(hidCitySysNo.Value); }
        }

        public int DistrictSysNo
        {
            set
            {
                hidDistrictSysNo.Value = value.ToString();
                if (ZoneSysNo == AppConst.IntNull)
                {
                    AreaSysNo = value;
                }
            }
            get { return Convert.ToInt32(hidDistrictSysNo.Value); }
        }

        public int ZoneSysNo
        {
            set
            {
                hidZoneSysNo.Value = value.ToString();
                AreaSysNo = value;
            }
            get { return Convert.ToInt32(hidZoneSysNo.Value); }
        }

        private string _onProvinceChange = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,省发生变化时触发的事件
        /// </summary>
        public string onProvinceChange
        {
            set { _onProvinceChange = value; }
            get { return _onProvinceChange; }
        }

        private string _onCityChange = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,市发生变化时触发的事件
        /// </summary>
        public string onCityChange
        {
            set { _onCityChange = value; }
            get { return _onCityChange; }
        }

        private string _onDistrictChange = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,县发生变化时触发的事件
        /// </summary>
        public string onDistrictChange
        {
            set { _onDistrictChange = value; }
            get { return _onDistrictChange; }
        }

        private string _onZoneChange = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,商圈发生变化时触发的事件
        /// </summary>
        public string onZoneChange
        {
            set { _onZoneChange = value; }
            get { return _onZoneChange; }
        }

    }
}