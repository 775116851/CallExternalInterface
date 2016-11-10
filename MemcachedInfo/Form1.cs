using DataSync360.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemcachedInfo
{
    public partial class Form1 : Form
    {
        //Client:C_GUID  C_GUID_LIST
        //Server:M_GUID
        public Form1()
        {
            InitializeComponent();
        }
        MemcacheDictionary<string> md = new MemcacheDictionary<string>();
        MemcacheDictionary<DataTable> mdTable = new MemcacheDictionary<DataTable>();
        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(md.Get("M_GUID")))//服务端缓存
            {
                md.Set("M_GUID", Guid.NewGuid().ToString(),TimeSpan.FromDays(1));
            }
            labClient.Text = md.Get("C_GUID");
            labServer.Text = md.Get("M_GUID");
        }

        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            string C_GUIDKey = md.Get("C_GUID");
            Hashtable ht = new Hashtable();
            Dictionary<string, DataTable> dcs = GetAreaDs(C_GUIDKey, ht);
            foreach(string sKey in dcs.Keys)
            {
                if (sKey == C_GUIDKey)//相同取客户端缓存List
                {
                    dataGridView1.DataSource = mdTable.Get("C_GUID_LIST");
                }
                else
                {
                    DataTable dts = dcs[sKey];
                    md.Set("C_GUID", sKey, TimeSpan.FromDays(1));
                    mdTable.Set("C_GUID_LIST", dts, TimeSpan.FromDays(1));
                    dataGridView1.DataSource = mdTable.Get("C_GUID_LIST");
                }
            }

            labClient.Text = md.Get("C_GUID");
            labServer.Text = md.Get("M_GUID");
        }

        private Dictionary<string,DataTable> GetAreaDs(string key,Hashtable ht)
        {
            Dictionary<string, DataTable> dc = new Dictionary<string, DataTable>();
            string M_GUIDKey = md.Get("M_GUID");
            if(string.IsNullOrEmpty(M_GUIDKey))//服务端缓存为空
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
            string sql = "SELECT SysNo,AreaID,ProvinceName,CityName,DistrictName,ZoneName FROM dbo.Area";
            DataSet ds = SqlHelper.ExecuteDataSet(sql);
            if(ds == null)
            {
                return null;
            }
            return ds.Tables[0];
        }

        //修改
        private void button2_Click(object sender, EventArgs e)
        {
            string C_GUIDKey = md.Get("C_GUID");
            Hashtable ht = new Hashtable();
            Dictionary<string, DataTable> dcs = UpdateAreaDs(C_GUIDKey, ht,new object());
            foreach (string sKey in dcs.Keys)
            {
                if (sKey == C_GUIDKey)//相同取客户端缓存List
                {
                    dataGridView1.DataSource = mdTable.Get("C_GUID_LIST");
                }
                else
                {
                    DataTable dts = dcs[sKey];
                    md.Set("C_GUID", sKey, TimeSpan.FromDays(1));
                    mdTable.Set("C_GUID_LIST", dts, TimeSpan.FromDays(1));
                    dataGridView1.DataSource = mdTable.Get("C_GUID_LIST");
                }
            }

            labClient.Text = md.Get("C_GUID");
            labServer.Text = md.Get("M_GUID");
        }

        private Dictionary<string, DataTable> UpdateAreaDs(string key,Hashtable ht,object areaObj)
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
