using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class SPDBYQ : Form
    {
        public SPDBYQ()
        {
            InitializeComponent();
        }

        //验签
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtParams.Text.Trim()) || string.IsNullOrEmpty(txtAppDesKey.Text.Trim()))
            {
                MessageBox.Show("请先输入必要参数");
                return;
            }
            string YSign = string.Empty;//原加密后的串码
            string[] arr = txtParams.Text.Trim().Split(new char[]{'?','&'},StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> argus = new Dictionary<string, string>();
            if (arr != null && arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    argus.Add(arr[i].Split('=')[0].Trim(), arr[i].Substring(arr[i].IndexOf('=', 0) + 1).Trim());
                    if (arr[i].Split('=')[0].Trim() == "sign")
                    {
                        YSign = arr[i].Substring(arr[i].IndexOf('=', 0) + 1).Trim();
                    }
                }
            }
            //排正序
            var result = from t in argus orderby t.Key select t;
            StringBuilder signSB = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> t in result)
            {
                //if (t.Key.Trim().ToLower() != "sign" && t.Value.Trim() != "")//&& t.Key.Trim().ToLower() != "mtype"
                //{
                //    signSB.Append(t.Value.Trim());
                //}
                //if (sb.ToString() != "")
                //{
                //    sb.Append("&");
                //}
                //sb.Append(t.Key).Append("=").Append(HttpUtility.UrlEncode(t.Value.Trim()));
                if (t.Key.Trim().ToLower() == "userid" || t.Key.Trim().ToLower() == "mobile" || t.Key.Trim().ToLower() == "channel" || t.Key.Trim().ToLower() == "timestamp")
                {
                    signSB.Append(t.Value.Trim());
                }
            }
            signSB.Append("&").Append(txtAppDesKey.Text.Trim());
            string sSign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signSB.ToString(), "md5").ToUpper();
            txtValues.Text = sSign;
            if (!string.IsNullOrEmpty(YSign))
            {
                if (sSign == YSign.ToUpper())
                {
                    MessageBox.Show("原始验签通过");
                }
                else
                {
                    MessageBox.Show("原始验签不通过");
                }
            }
        }

        private void txtValues_Click(object sender, EventArgs e)
        {
            txtValues.SelectAll();
        }
    }
}
