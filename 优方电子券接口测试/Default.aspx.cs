using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;
using System.Text; 

namespace 优方电子券接口测试
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string data = "金胖子死了";
            //string KEY_64 = "20111219";
            //string IV_64 = "12345678";
            //string data = "Qsw23T2";
            //string KEY_64 = "23Ro3U9x";
            //string IV_64  = "23Ro3U9x";
            //string m = Encode(data, KEY_64);
            //string n = Decode(m, KEY_64);
            //string sData = Encode(data, KEY_64, IV_64);
            //string sMess = Decode(sData, KEY_64, IV_64);

            txtContent.Text = @"{
     'header': 
    {
        'version': '1.0',
        'transType': 'W386',
        'merchantId': '182000899000001',
        'submitTime': '20131213110537',
        'clientTraceNo': '{BEF4BC9D-7CE5-4E01-A182-218F8081693A}',
        'signMessage': ''
    },
    'body': 
    {
        'shopProdId': '100187',
        'prodId': '100187',
        'prodNumber': '1',
        'phone': '15800495534',
        'orderNo': '13921',
        'timeout': '0',
        'amount': '0'
    }
}";
        }

        //DES加密并Base64
        public string Encode(string data, string KEY_64, string IV_64)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            int i = cryptoProvider.KeySize;

            MemoryStream ms = new MemoryStream();

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);

            sw.Write(data);

            sw.Flush();

            cst.FlushFinalBlock();

            sw.Flush();

            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        //IPP项目方法 DES加密
        public string Encode(string pToEncrypt, string KEY_64)
        {
            string sKey = KEY_64;
            //访问数据加密标准(DES)算法的加密服务提供程序 (CSP) 版本的包装对象
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);//把字符串放到byte数组中

            MemoryStream ms = new MemoryStream();//创建其支持存储区为内存的流　
            //定义将数据流链接到加密转换的流
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //上面已经完成了把加密后的结果放到内存中去

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        //DES解密
        public string Decode(string data, string KEY_64, string IV_64)
        {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;

            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(byEnc);

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cst);

            return sr.ReadToEnd();

        }

        //DES解密
        public string DecodeByte(byte[] byEnc, string KEY_64, string IV_64)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(byEnc);

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cst);

            return sr.ReadToEnd();
        }

        //IPP项目方法 DES解密
        public string Decode(string pToDecrypt, string KEY_64)
        {
            string sKey = KEY_64;
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量，此值重要，不能修改
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //建立StringBuild对象，createDecrypt使用的是流对象，必须把解密后的文本变成流对象
                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception Ex)
            {
                return "";
            }
        }

        //SHA1加密字符串
        public string SHA1(string source)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "SHA1");
        }

        //MD5加密字符串
        public string MD5(string source)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5");
        }

        //IPP项目方法 MD5加密
        public string md5(string str, int code)
        {
            string ret = "";
            if (code == 16) //16位md5加密（取32位加密的9~25字符） 
            {
                ret = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper().Substring(8, 16);
            }
            if (code == 32) //32位加密 
            {
                ret = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
            }
            return ret;
        }

        //开始加密
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string sK1 = txtK1.Text.Trim();
            string sContent = txtContent.Text.Trim();
            string sK2 = txtK2.Text.Trim();
            string sS2 = Encode(sContent, sK1, sK1);
            txtS2.Text = sS2;
            string sS3 = sK2 + sS2;
            txtS3.Text = sS3;
            string sMD5S3 = md5(sS3, 32);
            txtMd5S3.Text = sMD5S3;
            txtM1.Text = sMD5S3.ToLower();
            txtR.Text = txtM1.Text + sS2;

            txtDeContent.Text = txtR.Text;
        }

        //开始解密
        protected void btnDeQuery_Click(object sender, EventArgs e)
        {
            string sK1 = txtDeK1.Text.Trim();
            string sContent = txtDeContent.Text.Trim();
            string sK2 = txtDeK2.Text.Trim();
            string sM1 = sContent.Substring(0, 32);
            string sS2 = sContent.Substring(32);
            txtDeS2.Text = sS2;
            txtDeM1.Text = sM1;
            string sS3 = sK1 + sS2;
            txtDeS3.Text = sS3;
            string sM2 = md5(sS3, 32).ToLower();
            txtDeM2.Text = sM2;
            if (sM1 == sM2)
            {
                lblDeEquest.Text = "TRUE";
            }
            else
            {
                lblDeEquest.Text = "FALSE";
            }
            byte[] sB1 = Convert.FromBase64String(sS2);
            string sR = DecodeByte(sB1, sK1, sK2);
            txtDeR.Text = sR;
        }
    }
}