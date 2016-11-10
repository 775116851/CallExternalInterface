using DataSync360.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheInfo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //http://www.cnblogs.com/fish-li/archive/2011/12/27/2304063.html
        //Client:C_GUID  C_GUID_LIST
        //Server:M_GUID
        MemcacheDictionary<string> md = new MemcacheDictionary<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (string.IsNullOrEmpty(md.Get("M_GUID")))//服务端缓存
                {
                    md.Set("M_GUID", Guid.NewGuid().ToString(), TimeSpan.FromDays(1));
                }
                labClient.Text = Convert.ToString(Cache["C_GUID"]);
                labServer.Text = md.Get("M_GUID");

                ////绝对过期
                //Cache.Insert("FKK", "3344", null, DateTime.UtcNow.AddMinutes(0.3), System.Web.Caching.Cache.NoSlidingExpiration);
                ////滑动过期
                //Cache.Insert("FKK", "5566", null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(0.3));
                //缓冲清除优先级
                //Cache.Insert("FKK", "1sd5", null, DateTime.UtcNow.AddMinutes(0.3), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
                //string path = HttpContext.Current.Server.MapPath("~/Web.config");
                //CacheDependency dep = new CacheDependency(path);
                //Cache.Insert("FKK", "467", dep);
            }
        }

        //查询
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(Cache["FKK"]);
            return;
            string C_GUIDKey = Convert.ToString(Cache["C_GUID"]);
            Hashtable ht = new Hashtable();
            Dictionary<string, DataTable> dcs = GetAreaDs(C_GUIDKey, ht);
            foreach (string sKey in dcs.Keys)
            {
                if (sKey == C_GUIDKey)//相同取客户端缓存List
                {
                    DetailsView1.DataSource = Cache["C_GUID_LIST"];
                }
                else
                {
                    DataTable dts = dcs[sKey];
                    Cache.Insert("C_GUID", sKey);
                    Cache.Insert("C_GUID_LIST", dts);
                    DetailsView1.DataSource = Cache["C_GUID_LIST"];
                    DetailsView1.DataBind();
                }
            }

            labClient.Text = Convert.ToString(Cache["C_GUID"]);
            labServer.Text = md.Get("M_GUID");
        }

        private Dictionary<string, DataTable> GetAreaDs(string key, Hashtable ht)
        {
            Dictionary<string, DataTable> dc = new Dictionary<string, DataTable>();
            string M_GUIDKey = md.Get("M_GUID");
            if (string.IsNullOrEmpty(M_GUIDKey))//服务端缓存为空
            {
                NewM_GUID();
                DataTable dt = GetAreaDataTable(ht);
                M_GUIDKey = md.Get("M_GUID");
                dc.Add(M_GUIDKey, dt);
                return dc;
            }
            else if (string.IsNullOrEmpty(key) || M_GUIDKey != key)//客户端缓存为空 或 客户端和服务端缓存不一致
            {
                DataTable dt = GetAreaDataTable(ht);
                dc.Add(M_GUIDKey, dt);
                return dc;
            }
            else //客户端和服务器端缓存一致
            {
                dc.Add(M_GUIDKey, null);
            }
            return dc;
        }

        private void NewM_GUID()
        {
            md.Set("M_GUID", Guid.NewGuid().ToString(), TimeSpan.FromDays(1));
        }

        private DataTable GetAreaDataTable(Hashtable ht)
        {
            string sql = "SELECT * FROM dbo.Area";//SysNo,AreaID,ProvinceName,CityName,DistrictName,ZoneName
            DataSet ds = SqlHelper.ExecuteDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            return ds.Tables[0];
        }

        //修改
        protected void Button2_Click(object sender, EventArgs e)
        {
            string C_GUIDKey = Convert.ToString(Cache["C_GUID"]);
            Hashtable ht = new Hashtable();
            Dictionary<string, DataTable> dcs = UpdateAreaDs(C_GUIDKey, ht, new object());
            foreach (string sKey in dcs.Keys)
            {
                if (sKey == C_GUIDKey)//相同取客户端缓存List
                {
                    DetailsView1.DataSource = Cache["C_GUID_LIST"];
                    DetailsView1.DataBind();
                }
                else
                {
                    DataTable dts = dcs[sKey];
                    Cache.Insert("C_GUID", sKey);
                    Cache.Insert("C_GUID_LIST", dts);
                    DetailsView1.DataSource = Cache["C_GUID_LIST"];
                    DetailsView1.DataBind();
                }
            }

            labClient.Text = Convert.ToString(Cache["C_GUID"]);
            labServer.Text = md.Get("M_GUID");
        }

        private Dictionary<string, DataTable> UpdateAreaDs(string key, Hashtable ht, object areaObj)
        {
            Dictionary<string, DataTable> dc = new Dictionary<string, DataTable>();
            //先更新或插入区域数据

            //再操作缓存
            string M_GUIDKey = string.Empty;
            NewM_GUID();
            DataTable dt = GetAreaDataTable(ht);
            M_GUIDKey = md.Get("M_GUID");
            dc.Add(M_GUIDKey, dt);
            return dc;
        }
    }
}