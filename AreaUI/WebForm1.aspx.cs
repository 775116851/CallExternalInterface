using AreaUI.DAL;
using AreaUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AreaUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable newDt = new DataTable();
                //DataColumn dcKey = new DataColumn("key");
                //DataColumn dcValue = new DataColumn("value");
                //newDt.Columns.Add(dcKey);
                //newDt.Columns.Add(dcValue);

                //Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetAutoCityList("");
                //if (dic != null && dic.Count > 0)
                //{
                //    for (int i = 0; i < dic.Count; i++)
                //    {
                //        DataRow drTemp = newDt.NewRow();
                //        drTemp["key"] = dic.Values.ElementAt(i).SysNo.ToString();
                //        drTemp["value"] = dic.Values.ElementAt(i).CityName.ToString();
                //        newDt.Rows.Add(drTemp);
                //    }
                //}

                //ucArea360.DataSource = newDt;
                //ucArea360.DataBind();
            }

            //ucArea360.AreaSysNo = 15746;// 15787;//15792;
        }

        protected void btnZH_Click(object sender, EventArgs e)
        {
            string str = txtY.Text.Trim();
            string str2 = HttpUtility.HtmlDecode(str);
            string regStr = "<[^>]*>";
            string str3 = Regex.Replace(str2, regStr, "");
            string str4 = Regex.Replace(str3, "\\s*", "");
            txtM.Text = str4;
        }
    }
}