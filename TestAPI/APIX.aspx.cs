using allinpay.O2O.Cmn;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace TestAPI
{
    public partial class APIX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)   
        {   
            return true;   
        }  


        //public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{   // 总是接受  
        //    return true;
        //}

        //查询
        public string GetPostDataForYF()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder signSB = new StringBuilder();
            SortedList sl = new SortedList();
            sl.Add("method", "query_merchant");
            sl.Add("apikey", ConfigurationManager.AppSettings["APIUserOfYYZX"]);
            sl.Add("merchant_code", txtSH.Text.Trim());//"999999999"
            sl.Add("timestamp", DateTime.Now.ToString("yyyyMMddHHmmss"));//DateTime.Now.ToString("yyyyMMddHHmmss")
            sb.Append("{");
            foreach(string key in sl.Keys)
            {
                signSB.Append(key).Append("=").Append(sl[key].ToString());
                //sb.Append("&").Append(key).Append("=").Append(HttpUtility.UrlEncode(sl[key].ToString()));

                //sb.Append("\"").Append(key).Append("\":\"").Append(HttpUtility.UrlEncode(sl[key].ToString())).Append("\",");
                sb.Append("\"").Append(key).Append("\":\"").Append(sl[key].ToString()).Append("\",");
            }

            signSB.Append(ConfigurationManager.AppSettings["APIPwdOfYYZX"]);
            string m = HttpUtility.UrlEncode(signSB.ToString(),Encoding.UTF8).ToUpper();
            string mm = Util.GetMD5(m).ToUpper();//System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(m, "md5");
            sb.Append("\"sign\":\"").Append(HttpUtility.UrlEncode(mm)).Append("\"}");
            return sb.ToString();
        }

        public string GetPostDataForYF2()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder signSB = new StringBuilder();
            SortedList sl = new SortedList();
            sl.Add("method", "set_merchant");
            sl.Add("apikey", ConfigurationManager.AppSettings["APIUserOfYYZX"]);
            sl.Add("merchant_code", "999999998");
            sl.Add("merchant_name", "海底捞");
            sl.Add("contact_tell", "138263574");
            sl.Add("mcc", "5821");
            sl.Add("timestamp", DateTime.Now.ToString("yyyyMMddHHmmss"));
            sb.Append("{");
            foreach (string key in sl.Keys)
            {
                signSB.Append(key).Append("=").Append(sl[key].ToString());
                //sb.Append("\"").Append(key).Append("\":\"").Append(HttpUtility.UrlEncode(sl[key].ToString())).Append("\",");
                sb.Append("\"").Append(key).Append("\":\"").Append(sl[key].ToString()).Append("\",");
            }

            signSB.Append(ConfigurationManager.AppSettings["APIPwdOfYYZX"]);
            string m = HttpUtility.UrlEncode(signSB.ToString(), Encoding.UTF8).ToUpper();
            string mm = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(m, "md5");
            sb.Append("\"sign\":\"").Append(HttpUtility.UrlEncode(mm)).Append("\"}");
            return sb.ToString();
        }

        public string GetPostDataForYF3()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder signSB = new StringBuilder();
            SortedList sl = new SortedList();
            sl.Add("method", "set_merchant");
            sl.Add("apikey", ConfigurationManager.AppSettings["APIUserOfYYZX"]);
            sl.Add("merchant_code", txtSH.Text.Trim());
            sl.Add("merchant_name", "海底捞");
            sl.Add("contact_tell", "138263574");
            sl.Add("mcc", "5821");
            if(!string.IsNullOrEmpty(txtSN.Text.Trim()))
            {
                //sl.Add("sn", txtSN.Text.Trim());
                string[] sList = txtSN.Text.Trim().Split(',');
                Array.Sort(sList);
                StringBuilder sbSN = new StringBuilder();
                foreach (string s in sList)
                {
                    sbSN.Append(s).Append(",");
                }
                sbSN.Remove(sbSN.Length - 1, 1);
                sl.Add("sn", sbSN.ToString());
            }
            sl.Add("timestamp", DateTime.Now.ToString("yyyyMMddHHmmss"));
            sb.Append("{");
            foreach (string key in sl.Keys)
            {
                //sb.Append("\"").Append(key).Append("\":\"").Append(HttpUtility.UrlEncode(sl[key].ToString())).Append("\",");
                if (key == "sn")
                {
                    signSB.Append(key).Append("=");
                    sb.Append("\"").Append(key).Append("\":[");
                    string[] snList = sl[key].ToString().Split(',');
                    for (int i = 0; i < snList.Length;i++ )
                    {
                        signSB.Append(snList[i]);
                        sb.Append("\"").Append(snList[i]).Append("\",");
                    }
                    sb.Remove(sb.Length-1, 1);
                    sb.Append("],");
                }
                else
                {
                    signSB.Append(key).Append("=").Append(sl[key].ToString());
                    sb.Append("\"").Append(key).Append("\":\"").Append(sl[key].ToString()).Append("\",");
                }
            }

            signSB.Append(ConfigurationManager.AppSettings["APIPwdOfYYZX"]);
            string m = HttpUtility.UrlEncode(signSB.ToString(), Encoding.UTF8).ToUpper();
            string mm = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(m, "md5");
            sb.Append("\"sign\":\"").Append(HttpUtility.UrlEncode(mm)).Append("\"}");
            return sb.ToString();
        }

        public string PostByHttpRequest(string str)
        {
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIAddressOfYYZX"]));//http://192.168.101.34:8079/asapi/allinpay/merchant
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.Accept = "application/json;charset=utf-8";

            byte[] bytes = Encoding.UTF8.GetBytes(str);
            request.ContentLength = bytes.Length;
            using (Stream putStream = request.GetRequestStream())
            {
                putStream.Write(bytes, 0, bytes.Length);
            }
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string server = response.Server;
                    return reader.ReadToEnd();
                }
            }
        }

        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string result = PostByHttpRequest(GetPostDataForYF());
            //string result = PostByHttpRequest(GetPostDataForYF2());
            //string result = PostByHttpRequest(GetPostDataForYF3());
            //JsonData jd = JsonMapper.ToObject(result);
            if (string.IsNullOrEmpty(txtSH.Text.Trim()))
            {
                Response.Write("商户号不能为空！");
                return;
            }
            string result = PostByHttpRequest(GetPostDataForYF3());
            txtResult.Text = result;
        }

        //查询
        protected void btnCX_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSH.Text.Trim()))
            {
                Response.Write("商户号不能为空！");
                return;
            }
            string result = PostByHttpRequest(GetPostDataForYF());
            txtResult.Text = result;
        }
    }
}