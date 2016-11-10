using allinpay.O2O.Cmn;
using AreaUI.DAL;
using AreaUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AreaUI.UI
{
    public partial class Area360 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCity.Attributes.Add("onchange", "CityChange" + txtCity.ClientID + "()");//onblur
            ddlADistrict.Attributes.Add("onchange", "DistrictChange" + ddlADistrict.ClientID + "(this.value)");
            ddlAZone.Attributes.Add("onchange", "ZoneChange" + ddlAZone.ClientID + "(this.value)");
            if (!IsPostBack)
            {
                BindArea();
            }
        }

        public void BindArea()
        {
            if (string.IsNullOrEmpty(hidArray.Value))
            {
                BindCity();
            }
            ddlADistrict.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlAZone.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
        }

        #region 方法
        /// <summary>
        /// 绑定数据
        /// </summary>
        public override void DataBind()
        {
            if (DataSource != null && DataSource.Rows.Count > 0)
            {
                StringBuilder jsonData = DataTableToJSON(DataSource, true);
                string jsonDataFormat = jsonData.ToString();
                hidArray.Value = jsonDataFormat;
            }
        }
        #endregion

        #region 属性

        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable DataSource
        {
            get
            {
                return ViewState["DataSource"] == null ? null : (DataTable)ViewState["DataSource"];
            }
            set
            {
                ViewState["DataSource"] = value;
            }
        }

        /// <summary>
        /// 在触发autoComplete前用户至少需要输入的字符数.Default: 1，如果设为0，在输入框内双击或者删除输入框内内容时显示
        /// </summary>
        public int MinChars
        {
            get
            {
                return ViewState["MinChars"] == null ? 0 : Convert.ToInt32(ViewState["MinChars"]);
            }
            set
            {
                ViewState["MinChars"] = value;
            }
        }
        /// <summary>
        /// 表头描述
        /// </summary>
        public string Caption
        {
            get
            {
                return ViewState["Caption"] == null ? "请输入查询值，使用↑↓可以选择" : ViewState["Caption"].ToString();
            }
            set { ViewState["Caption"] = value; }
        }
        /// <summary>
        /// 弹出层宽
        /// </summary>
        public Unit DivWidth
        {
            get
            {
                return txtCity.Width;
            }
            set
            {
                txtCity.Width = value;
            }
        }
        /// <summary>
        /// 滚动条
        /// </summary>
        public bool Scroll
        {
            get
            {
                return Convert.ToBoolean(ViewState["Scroll"]);
            }
            set
            {
                ViewState["Scroll"] = value;
            }
        }
        /// <summary>
        ///  选中值
        /// </summary>
        public string SelectValue
        {
            get
            {
                return hidACityCode.Value;
            }
            set
            {

                hidACityCode.Value = value;
                if (value == "")
                {
                    txtCity.Text = "";
                }
                else
                {
                    if (DataSource != null && DataSource.Rows.Count > 0)
                    {
                        foreach (DataRow dr in DataSource.Rows)
                        {
                            if (dr["key"].ToString() == value)
                            {
                                txtCity.Text = dr["value"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private bool _Enable = true;
        public bool Enable
        {
            get { return _Enable; }
            set
            {
                txtCity.Enabled = value;
                _Enable = value;
            }
        }
        #endregion

        #region 工具
        /// <summary>
        /// 将数据表转换成JSON类型串
        /// </summary>
        /// <param name="dt">要转换的数据表</param>
        /// <param name="dispose">数据表转换结束后是否dispose掉</param>
        /// <returns></returns>
        public static StringBuilder DataTableToJSON(DataTable dt, bool dt_dispose)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");

            //数据表字段名和类型数组
            string[] dt_field = new string[dt.Columns.Count];
            int i = 0;
            string formatStr = "{{";
            string fieldtype = "";
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                dt_field[i] = dc.Caption.Trim();
                formatStr += dc.Caption.ToString().Trim() + ":";
                fieldtype = dc.DataType.ToString().Trim().ToLower();
                if (fieldtype.IndexOf("int") > 0 || fieldtype.IndexOf("deci") > 0 ||
                    fieldtype.IndexOf("floa") > 0 || fieldtype.IndexOf("doub") > 0 ||
                    fieldtype.IndexOf("bool") > 0)
                {
                    formatStr += "'" + "{" + i + "}" + "'";
                }
                else
                {
                    formatStr += "'" + "{" + i + "}" + "'";
                }
                formatStr += ",";
                i++;
            }

            if (formatStr.EndsWith(","))
            {
                formatStr = formatStr.Substring(0, formatStr.Length - 1);//去掉尾部","号
            }
            formatStr += "}},";

            i = 0;
            object[] objectArray = new object[dt_field.Length];
            foreach (System.Data.DataRow dr in dt.Rows)
            {

                foreach (string fieldname in dt_field)
                {   //对 \ , ' 符号进行转换 
                    objectArray[i] = dr[dt_field[i]].ToString().Trim().Replace("\\", "\\\\").Replace("'", "\\'");
                    switch (objectArray[i].ToString())
                    {
                        case "True":
                            {
                                objectArray[i] = "true"; break;
                            }
                        case "False":
                            {
                                objectArray[i] = "false"; break;
                            }
                        default: break;
                    }
                    i++;
                }
                i = 0;
                stringBuilder.Append(string.Format(formatStr, objectArray));
            }
            if (stringBuilder.ToString().EndsWith(","))
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);//去掉尾部","号
            }

            if (dt_dispose)
            {
                dt.Dispose();
            }
            return stringBuilder.Append("]");
        }
        #endregion

        private void BindCity()
        {
            DataTable newDt = new DataTable();
            DataColumn dcKey = new DataColumn("key");
            DataColumn dcValue = new DataColumn("value");
            newDt.Columns.Add(dcKey);
            newDt.Columns.Add(dcValue);

            Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetAutoCityList("");
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    DataRow drTemp = newDt.NewRow();
                    drTemp["key"] = dic.Values.ElementAt(i).SysNo.ToString();
                    drTemp["value"] = dic.Values.ElementAt(i).CityName.ToString();
                    newDt.Rows.Add(drTemp);
                }
            }

            StringBuilder jsonData = DataTableToJSON(newDt, true);
            string jsonDataFormat = jsonData.ToString();
            hidArray.Value = jsonDataFormat;

            //ucArea360.DataSource = newDt;
            //ucArea360.DataBind();
        }

        private void BindADistrict(int citySysNo, int districtSysNo)
        {
            ddlADistrict.Enabled = Enable;
            Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetADistrictsByCitySysNo(citySysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlADistrict.Items.Add(new ListItem(dic.Values.ElementAt(i).DistrictName, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlADistrict.SelectedValue = districtSysNo.ToString();
            hidADistrictSysNo.Value = districtSysNo.ToString();
        }

        private void BindAZone(int districtSysNo, int zoneSysNo)
        {
            ddlAZone.Enabled = Enable;
            Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetAZonesByDistrictSysNo(districtSysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlAZone.Items.Add(new ListItem(dic.Values.ElementAt(i).ZoneName, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlAZone.SelectedValue = zoneSysNo.ToString();
            hidAZoneSysNo.Value = zoneSysNo.ToString();
        }

        public int AreaSysNo
        {
            get { return Convert.ToInt32(hidAAreaSysNo.Value); }
            set
            {
                hidAAreaSysNo.Value = value.ToString();
                if (value != AppConst.IntNull)
                {
                    Area_360Entity model = new Area_360Dac().GetAAreaBySysNo(value);
                    if (model != null)
                    {
                        hidACityCode.Value = model.CitySysNo.ToString();
                        if (model.DistrictSysNo != AppConst.IntNull)//商圈
                        {
                            txtCity.Text = model.CityName;
                            BindADistrict(model.CitySysNo, model.DistrictSysNo);
                            BindAZone(model.DistrictSysNo, model.SysNo);
                        }
                        else if (model.CitySysNo != AppConst.IntNull)//县
                        {
                            txtCity.Text = model.CityName;
                            BindADistrict(model.CitySysNo, model.SysNo);
                        }
                        else
                        {
                            txtCity.Text = model.CityName;
                            hidACityCode.Value = model.SysNo.ToString();
                        }
                    }
                }
            }
        }

        public int CitySysNo
        {
            set
            {
                hidACityCode.Value = value.ToString();
                if (DistrictSysNo == AppConst.IntNull)
                {
                    AreaSysNo = value;
                }
            }
            get { return Convert.ToInt32(hidACityCode.Value); }
        }

        public int DistrictSysNo
        {
            set
            {
                hidADistrictSysNo.Value = value.ToString();
                if (ZoneSysNo == AppConst.IntNull)
                {
                    AreaSysNo = value;
                }
            }
            get { return Convert.ToInt32(hidADistrictSysNo.Value); }
        }

        public int ZoneSysNo
        {
            set
            {
                hidAZoneSysNo.Value = value.ToString();
                AreaSysNo = value;
            }
            get { return Convert.ToInt32(hidAZoneSysNo.Value); }
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