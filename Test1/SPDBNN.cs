using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Windows.Forms;
//using ff.PPP;
//using WebApplication1;

namespace Test1
{
    public partial class SPDBNN : Form
    {
        public SPDBNN()
        {
            InitializeComponent();
        }

        private void SPDBNN_Load(object sender, EventArgs e)
        {
            InitControl();

            string key = "yszxysy7012iemdlodoejebw";
            string iv = "12345678";
            string data = "31010919850730353X";
            string ff = Des3EncodeCBC(key, iv, data);

            string kk = Des3EncodeECB(key, data);

            int m = 0;

        }

        private void InitControl()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Key");
            dataTable.Columns.Add("Value");
            DataRow dataRow = dataTable.NewRow();
            dataRow["Key"] = "02";
            dataRow["Value"] = "ios";
            dataTable.Rows.Add(dataRow);
            dataRow = dataTable.NewRow();
            dataRow["Key"] = "01";
            dataRow["Value"] = "android";
            dataTable.Rows.Add(dataRow);
            this.cboDevice.DataSource = dataTable;
            this.cboDevice.DisplayMember = "Value";
            this.cboDevice.ValueMember = "Key";
            this.cboDevice.SelectedValue = "01";

            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("Key");
            dataTable2.Columns.Add("Value");
            DataRow dataRow2 = dataTable2.NewRow();
            dataRow2["Key"] = "1";
            dataRow2["Value"] = "每日优惠";
            dataTable2.Rows.Add(dataRow2);
            dataRow2 = dataTable2.NewRow();
            dataRow2["Key"] = "2";
            dataRow2["Value"] = "小浦商城";
            dataTable2.Rows.Add(dataRow2);
            dataRow2 = dataTable2.NewRow();
            dataRow2["Key"] = "3";
            dataRow2["Value"] = "现金礼券";
            dataTable2.Rows.Add(dataRow2);
            this.cboType.DataSource = dataTable2;
            this.cboType.DisplayMember = "Value";
            this.cboType.ValueMember = "Key";
            this.cboType.SelectedValue = "3";

            DataTable dataTable3 = new DataTable();
            dataTable3.Columns.Add("Key");
            dataTable3.Columns.Add("Value");
            DataRow dataRow3 = dataTable3.NewRow();
            dataRow3["Key"] = "2";
            dataRow3["Value"] = "微信";
            dataTable3.Rows.Add(dataRow3);
            dataRow3 = dataTable3.NewRow();
            dataRow3["Key"] = "1";
            dataRow3["Value"] = "APP";
            dataTable3.Rows.Add(dataRow3);
            this.cboChannelType.DataSource = dataTable3;
            this.cboChannelType.DisplayMember = "Value";
            this.cboChannelType.ValueMember = "Key";
            this.cboChannelType.SelectedValue = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtParams.Text.Trim()) || string.IsNullOrEmpty(this.txtAppDesKey.Text.Trim()) || string.IsNullOrEmpty(this.txtApp3DesKey.Text.Trim()))
            {
                MessageBox.Show("请先输入必要参数");
            }
            else
            {
                string empty = string.Empty;
                string text = this.ReturnSign(ref empty);
                this.txtValues.Text = text;
                if (!string.IsNullOrEmpty(empty))
                {
                    if (text == empty.ToUpper())
                    {
                        MessageBox.Show("原始验签通过");
                    }
                    else
                    {
                        MessageBox.Show("原始验签不通过");
                    }
                }
            }
        }

        public string ReturnSign(ref string YSign)
        {
            string m3DesKey = txtApp3DesKey.Text.Trim();
            string[] array = this.txtParams.Text.Trim().Split(new char[] { '?', '&' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (array != null && array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    dictionary.Add(array[i].Split(new char[] { '=' })[0].Trim(), array[i].Substring(array[i].IndexOf('=', 0) + 1).Trim());
                    if (array[i].Split(new char[] { '=' })[0].Trim() == "sign")
                    {
                        YSign = array[i].Substring(array[i].IndexOf('=', 0) + 1).Trim();
                    }
                }
            }
            IOrderedEnumerable<KeyValuePair<string, string>> orderedEnumerable =
                from t in dictionary
                orderby t.Key
                select t;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (KeyValuePair<string, string> current in orderedEnumerable)
            {
                //if (current.Key.Trim().ToLower() == "userid" || current.Key.Trim().ToLower() == "mobile" || current.Key.Trim().ToLower() == "channel" || current.Key.Trim().ToLower() == "timestamp")
                //{
                //    stringBuilder.Append(current.Value.Trim());
                //}
                if (current.Key.Trim().ToLower() != "sign")
                {
                    if (current.Key.Trim().ToLower() == "cardno" || current.Key.Trim().ToLower() == "certno")
                    {
                        if (!string.IsNullOrEmpty(current.Value.Trim()))
                        {
                            stringBuilder.Append(RetDecodeCBC(current.Value.Trim(), m3DesKey));
                        }
                        else
                        {
                            stringBuilder.Append(current.Value.Trim());
                        }
                    }
                    else if (current.Key.Trim().ToLower() == "city")
                    {
                        if (!string.IsNullOrEmpty(current.Value.Trim()))
                        {
                            stringBuilder.Append(HttpUtility.UrlEncode(current.Value.Trim()));
                        }
                        else
                        {
                            stringBuilder.Append(current.Value.Trim());
                        }
                    }
                    else
                    {
                        stringBuilder.Append(current.Value.Trim());
                    }
                }
            }
            stringBuilder.Append("&").Append(this.txtAppDesKey.Text.Trim());
            return FormsAuthentication.HashPasswordForStoringInConfigFile(stringBuilder.ToString(), "md5").ToUpper();
        }

        //新版算法
        public string ReturnSignNew(ref string YSign)
        {
            string[] array = this.txtParams.Text.Trim().Split(new char[] { '?', '&' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (array != null && array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    dictionary.Add(array[i].Split(new char[] { '=' })[0].Trim(), array[i].Substring(array[i].IndexOf('=', 0) + 1).Trim());
                    if (array[i].Split(new char[] { '=' })[0].Trim() == "sign")
                    {
                        YSign = array[i].Substring(array[i].IndexOf('=', 0) + 1).Trim();
                    }
                }
            }
            IOrderedEnumerable<KeyValuePair<string, string>> orderedEnumerable =
                from t in dictionary
                orderby t.Key
                select t;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (KeyValuePair<string, string> current in orderedEnumerable)
            {
                //if (current.Key.Trim().ToLower() == "userid" || current.Key.Trim().ToLower() == "mobile" || current.Key.Trim().ToLower() == "channel" || current.Key.Trim().ToLower() == "timestamp")
                //{
                //stringBuilder.Append(current.Value.Trim());
                //}
                if (current.Key.Trim().ToLower() != "sign")
                {
                    stringBuilder.Append(current.Value.Trim());
                }
            }
            stringBuilder.Append("&").Append(this.txtAppDesKey.Text.Trim());
            return FormsAuthentication.HashPasswordForStoringInConfigFile(stringBuilder.ToString(), "md5").ToUpper();
        }

        private void txtValues_Click(object sender, EventArgs e)
        {
            this.txtValues.SelectAll();
        }

        //APP生成
        private void btnSC_Click(object sender, EventArgs e)
        {
            string text = "?channel={0}&userId={1}&cardNo={2}&mobile={3}&os={4}&version={5}&certType={6}&" +
                        "certNo={7}&city={8}&lng={9}&lat={10}&timestamp={11}&sign=($$$)";
            string mChannel = txtchannel.Text.Trim();
            string mUserId = txtUserId.Text.Trim();
            string mCardNo = txtCardNo.Text.Trim();
            string mMobile = txtMobile.Text.Trim();
            string mOs = Convert.ToString(cboDevice.SelectedValue);
            string mVersion = txtVersion.Text.Trim();
            string mCertType = txtCertType.Text.Trim();
            string mCertNo = txtCertNo.Text.Trim();
            string mCity = txtCity.Text.Trim();
            string mLng = txtLng.Text.Trim();
            string mLat = txtLat.Text.Trim();
            string mTimestamp = txtTimestamp.Text.Trim();
            if (string.IsNullOrEmpty(mTimestamp))
            {
                mTimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            string textA = string.Format(text, new object[] { mChannel, mUserId, mCardNo, mMobile, mOs, mVersion, mCertType, mCertNo, mCity, mLng, mLat, mTimestamp });
            //string text = "?timestamp={0}&userId={1}&mobile={2}&channel={3}&sign=($$$)&mtype={4}";
            //string text2 = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string text3 = this.txtUserId.Text.Trim();
            //string text4 = this.txtMobile.Text.Trim();
            //string text5 = Convert.ToString(this.cboDevice.Text);
            //string text6 = Convert.ToString(this.cboType.SelectedValue);
            //text = string.Format(text, new object[]{text2,text3,text4,text5,text6});
            this.txtParams.Text = textA;
            string empty = string.Empty;
            string newValue = this.ReturnSignNew(ref empty);
            string newParams = textA.Replace("($$$)", newValue);
            this.txtParams.Text = newParams;
            string m3DesKey = txtApp3DesKey.Text.Trim();
            mCardNo = RetEncodeCBC(mCardNo, m3DesKey);
            if (!string.IsNullOrEmpty(mCardNo))
            {
                mCardNo = HttpUtility.UrlEncode(mCardNo);
            }
            mCertNo = RetEncodeCBC(mCertNo, m3DesKey);
            if (!string.IsNullOrEmpty(mCertNo))
            {
                mCertNo = HttpUtility.UrlEncode(mCertNo);
            }
            if (!string.IsNullOrEmpty(mCity))
            {
                mCity = HttpUtility.UrlEncode(mCity);
            }
            string textB = string.Format(text, new object[] { mChannel, mUserId, mCardNo, mMobile, mOs, mVersion, mCertType, mCertNo, mCity, mLng, mLat, mTimestamp });
            string newValues = textB.Replace("($$$)", newValue);
            this.txtValues.Text = newValues;
        }

        //微信生成
        private void btnWXSC_Click(object sender, EventArgs e)
        {
            #region 3DES_32位 加密
            //string text = "?openID={0}&cardNo={1}&certNo={2}";
            //string mOpenID = txtOpenID.Text.Trim();
            //string mCardNo = txtCardNo.Text.Trim();
            ////string mMobile = txtMobile.Text.Trim();
            //string mCertNo = txtCertNo.Text.Trim();
            //string textA = string.Format(text, new object[] { mOpenID, mCardNo, mCertNo });
            //this.txtParams.Text = textA;
            //string m3DesKey = txtApp3DesKey.Text.Trim();
            //mCardNo = RetEncodeCBC(mCardNo, m3DesKey);
            //if (!string.IsNullOrEmpty(mCardNo))
            //{
            //    mCardNo = HttpUtility.UrlEncode(mCardNo);
            //}
            //mCertNo = RetEncodeCBC(mCertNo, m3DesKey);
            //if (!string.IsNullOrEmpty(mCertNo))
            //{
            //    mCertNo = HttpUtility.UrlEncode(mCertNo);
            //}
            //string textB = string.Format(text, new object[] { mOpenID, mCardNo, mCertNo });
            //this.txtValues.Text = textB;
            #endregion

            #region 3DES_24位 加密
            string text = "?Oi={0}&iN={1}";
            string mOpenID = txtOpenID.Text.Trim();
            //string mCardNo = txtCardNo.Text.Trim();
            //string mMobile = txtMobile.Text.Trim();
            string mCertNo = txtCertNo.Text.Trim();
            string textA = string.Format(text, new object[] { mOpenID, mCertNo });
            this.txtParams.Text = textA;
            string m3DesKey = txtWX3DesKey.Text.Trim();
            mOpenID = RetEncodeCBCWX(mOpenID, m3DesKey);
            //if (!string.IsNullOrEmpty(mOpenID))
            //{
            //    mOpenID = HttpUtility.UrlEncode(mOpenID);
            //}
            mCertNo = RetEncodeCBCWX(mCertNo, m3DesKey);
            //if (!string.IsNullOrEmpty(mCertNo))
            //{
            //    mCertNo = HttpUtility.UrlEncode(mCertNo);
            //}
            string textB = string.Format(text, new object[] { mOpenID, mCertNo });
            this.txtValues.Text = textB;
            #endregion
        }

        //二级商户生成
        private void btnEJSC_Click(object sender, EventArgs e)
        {
            string text = "?channel={0}&userid={1}&cardNo={2}&telePhone={3}&certNo={4}&openID={5}&channelType={6}&sign=($$$)";
            string mChannel = txtchannel.Text.Trim();
            string mUserId = txtUserId.Text.Trim();
            string mCardNo = txtCardNo.Text.Trim();
            string mMobile = txtMobile.Text.Trim();
            string mCertNo = txtCertNo.Text.Trim();
            string mOpenID = txtOpenID.Text.Trim();
            string mChannelType = Convert.ToString(cboChannelType.SelectedValue);
            string textA = string.Format(text, new object[] { mChannel, mUserId, mCardNo, mMobile, mCertNo, mOpenID, mChannelType });
            this.txtParams.Text = textA;
            string empty = string.Empty;
            string newValue = this.ReturnSignNew(ref empty);
            string newParams = textA.Replace("($$$)", newValue);
            this.txtParams.Text = newParams;
            string m3DesKey = txtApp3DesKey.Text.Trim();
            mCardNo = RetEncodeCBC(mCardNo, m3DesKey);
            //if (!string.IsNullOrEmpty(mCardNo))
            //{
            //    mCardNo = HttpUtility.UrlEncode(mCardNo);
            //}
            mCertNo = RetEncodeCBC(mCertNo, m3DesKey);
            //if (!string.IsNullOrEmpty(mCertNo))
            //{
            //    mCertNo = HttpUtility.UrlEncode(mCertNo);
            //}
            string textB = string.Format(text, new object[] { mChannel, mUserId, mCardNo, mMobile, mCertNo, mOpenID, mChannelType });
            string newValues = textB.Replace("($$$)", newValue);
            this.txtValues.Text = newValues;
        }

        //3DES_CBC 加密
        private void btnAA_Click(object sender, EventArgs e)
        {
            string des3Str = A.Text.Trim();
            try
            {
                string tValue = RetEncodeCBC(des3Str, B.Text.Trim());
                C.Text = tValue;
                CEncode.Text = HttpUtility.UrlEncode(tValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
        }

        //3DES_CBC 解密
        private void btnAAA_Click(object sender, EventArgs e)
        {
            string des3EncodeStr = A.Text.Trim();
            try
            {
                string tValue = RetDecodeCBC(des3EncodeStr, B.Text.Trim());
                C.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC解密报错，解密串：{0};错误信息：{1};错误详情：{2}", des3EncodeStr, ex.Message, ex));
            }
        }

        //3DES_ECB 加密
        private void btnBB_Click(object sender, EventArgs e)
        {
            string des3Str = A.Text.Trim();
            try
            {
                string tValue = RetEncodeECB(des3Str, B.Text.Trim());
                C.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
        }

        //3DES_ECB 解密
        private void btnBBB_Click(object sender, EventArgs e)
        {
            string des3EncodeStr = A.Text.Trim();
            try
            {
                string tValue = RetDecodeECB(des3EncodeStr, B.Text.Trim());
                C.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB解密报错，解密串：{0};错误信息：{1};错误详情：{2}", des3EncodeStr, ex.Message, ex));
            }
        }

        //3DES_CBC 解密 经过Encode
        private void button2_Click(object sender, EventArgs e)
        {
            string des3EncodeStr = A.Text.Trim();
            try
            {
                string tValue = RetDecodeCBC(HttpUtility.UrlDecode(des3EncodeStr), B.Text.Trim());
                C.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBCE解密报错，解密串：{0};错误信息：{1};错误详情：{2}", des3EncodeStr, ex.Message, ex));
            }
        }

        //3DES_CBC 微信加密
        private void btnWXEn_Click(object sender, EventArgs e)
        {
            //ECB模式 24位
            //TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            //DES.Key = ASCIIEncoding.ASCII.GetBytes(txtWXKey.Text.Trim());
            //DES.Mode = CipherMode.ECB;
            //ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            //byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(txtWXOld.Text.Trim());
            //txtWXNew.Text = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

            //http://www.dongcoder.com/detail-81440.html
            //3
            //String desKey = txtWXKey.Text.Trim();//"1dcrm4goRY8KODsgV1PPuHLB";//24位密钥
            //String desIv = "12345678";//"QCsJ2SKR"; ///8位向量
            //SymmetricAlgorithm sa;
            //ICryptoTransform ct;
            //MemoryStream ms;
            //CryptoStream cs;
            //byte[] byt;
            //sa = new TripleDESCryptoServiceProvider();
            //sa.Key = Encoding.UTF8.GetBytes(desKey);
            //sa.IV = Encoding.UTF8.GetBytes(desIv);
            //ct = sa.CreateEncryptor();
            //byt = Encoding.UTF8.GetBytes(txtWXOld.Text.Trim());
            //ms = new MemoryStream();
            //cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            //cs.Write(byt, 0, byt.Length);
            //cs.FlushFinalBlock();
            //cs.Close();
            //txtWXNew.Text = Convert.ToBase64String(ms.ToArray());

            string des3Str = txtWXOld.Text.Trim();
            try
            {
                string tValue = RetEncodeCBCWX(des3Str, txtWXKey.Text.Trim());
                txtWXNew.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错微信，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
        }

        //3DES_CBC 微信解密
        private void btnWXDe_Click(object sender, EventArgs e)
        {
            //ECB模式 24位
            //TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            //DES.Key = ASCIIEncoding.ASCII.GetBytes(txtWXKey.Text.Trim());
            //DES.Mode = CipherMode.ECB;
            //DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            //ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            //string result = "";
            //try
            //{
            //    byte[] Buffer = Convert.FromBase64String(txtWXOld.Text.Trim());
            //    result = ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            //}
            //catch (Exception ex)
            //{

            //}
            //txtWXNew.Text = result;

            //System.Text.Encoding utf8 = System.Text.Encoding.UTF8; 
            //byte[] key = Convert.FromBase64String(txtWXKey.Text.Trim());
            //byte[] iv = new byte[] { 1,2,3,4,5,6,7,8,9,0 }; //new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
            //byte[] data = utf8.GetBytes(txtWXOld.Text.Trim());  
            //// Create a new MemoryStream using the passed   
            //// array of encrypted data.  
            //MemoryStream msDecrypt = new MemoryStream(data);
            //TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            //tdsp.Mode = CipherMode.CBC;
            //tdsp.Padding = PaddingMode.PKCS7;
            //// Create a CryptoStream using the MemoryStream   
            //// and the passed key and initialization vector (IV).  
            //CryptoStream csDecrypt = new CryptoStream(msDecrypt,
            //    tdsp.CreateDecryptor(key, iv),
            //    CryptoStreamMode.Read);
            //// Create buffer to hold the decrypted data.  
            //byte[] fromEncrypt = new byte[data.Length];
            //// Read the decrypted data out of the crypto stream  
            //// and place it into the temporary buffer.  
            //csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            ////Convert the buffer into a string and return it.  
            //txtWXNew.Text = System.Text.Encoding.UTF8.GetString(fromEncrypt);  

            //3
            //String desKey = txtWXKey.Text.Trim();//"1dcrm4goRY8KODsgV1PPuHLB";//24位密钥
            //String desIv = "12345678";// "QCsJ2SKR"; ///8位向量
            //SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            //mCSP.Key = Encoding.UTF8.GetBytes(desKey);
            //mCSP.IV = Encoding.UTF8.GetBytes(desIv);
            //ICryptoTransform ct;
            //MemoryStream ms;
            //CryptoStream cs;
            //byte[] byt;
            //ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            //byt = Convert.FromBase64String(txtWXOld.Text.Trim());
            //ms = new MemoryStream();
            //cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            //cs.Write(byt, 0, byt.Length);
            //cs.FlushFinalBlock();
            //cs.Close();
            //txtWXNew.Text = Encoding.UTF8.GetString(ms.ToArray());

            string des3EncodeStr = txtWXOld.Text.Trim();
            try
            {
                string tValue = RetDecodeCBCWX(des3EncodeStr, txtWXKey.Text.Trim());
                txtWXNew.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC解密报错微信，解密串：{0};错误信息：{1};错误详情：{2}", des3EncodeStr, ex.Message, ex));
            }
        }

        //3DES_ECB 加密(24位密钥 APP收银台掉单使用)
        private void button3_Click(object sender, EventArgs e)
        {
            string des3Str = txtE.Text.Trim();
            try
            {
                string tValue = Encrypt3DES(des3Str, txtK.Text.Trim());
                txtF.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB加密报错APP，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
        }

        //3DES_ECB 解密(24位密钥 APP收银台掉单使用)
        private void button4_Click(object sender, EventArgs e)
        {
            string des3Str = txtE.Text.Trim();
            try
            {
                string tValue = Decrypt3DES(des3Str, txtK.Text.Trim());
                txtF.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB解密报错APP，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
        }

        //3DES_ECB 加密(32位密钥 APP浦发新登录加密)  
        private void button5_Click(object sender, EventArgs e)
        {
            string des3Str = txtLE.Text.Trim();
            try
            {
                string tValue = RetLoginEncodeECB(des3Str, txtLK.Text.Trim());
                txtLV.Text = tValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB加密报错APP，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }

            ////加密
            //System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
            ////key为abcdefghijklmnopqrstuvwx的Base64编码  
            //byte[] key = utf8.GetBytes(txtLK.Text.Trim().Substring(0, 24));
            //byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
            //byte[] data = utf8.GetBytes(txtLE.Text.Trim());
            ////System.Console.WriteLine( "ECB模式:" );  

            //byte[] str1 = Des3Util.Des3EncodeECB(key, iv, data);
            //string en = Convert.ToBase64String(str1);
            //string fj = HttpUtility.UrlEncode(en);
            //txtLV.Text = fj;
        }

        //3DES_ECB 解密(32位密钥 APP浦发新登录解密) 
        private void button6_Click(object sender, EventArgs e)
        {
            //解密
            try
            {
                string des3Str = txtLE.Text.Trim();
                try
                {
                    string tValue = RetLoginDecodeECB(des3Str, txtLK.Text.Trim());
                    txtLV.Text = tValue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("方法3DES_ECB解密报错APP，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
                }

                //try
                //{
                //    System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //    //key为abcdefghijklmnopqrstuvwx的Base64编码  
                //    byte[] key = utf8.GetBytes(txtLK.Text.Trim().Substring(0, 24));
                //    byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                //    //byte[] data = utf8.GetBytes(des3EncodeStr);
                //    //System.Console.WriteLine( "ECB模式:" );  
                //    //byte[] str1 = Des3.Des3EncodeECB( key, iv, data );
                //    //string en = Convert.ToBase64String(str1);
                //    byte[] data = Convert.FromBase64String(HttpUtility.UrlDecode(HttpUtility.UrlDecode(txtLE.Text.Trim())));
                //    //byte[] data = utf8.GetBytes(txtLE.Text.Trim());
                //    //byte[] data = Convert.FromBase64String(HttpUtility.UrlEncode(HttpUtility.UrlEncode(HttpUtility.UrlDecode(txtLE.Text.Trim()))));
                //    byte[] str2 = Des3Util.Des3DecodeECB(key, iv, data);
                //    string ff = utf8.GetString(str2);
                //    txtLV.Text = ff;
                //}
                //catch (Exception ex)
                //{
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB解密报错，解密串：{0};错误信息：{1};错误详情：{2}", txtLE.Text.Trim(), ex.Message, ex));
            }
        }

        //APP登录生成
        private void button7_Click(object sender, EventArgs e)
        {
            string text = "?channel={0}&userid={1}&cardNo={2}&telePhone={3}&os={4}&version={5}&certType={6}&" +
                        "certNo={7}&city={8}&lng={9}&lat={10}&timestamp={11}&sign=($$$)";
            string mChannel = txtchannel.Text.Trim();
            string mUserId = txtUserId.Text.Trim();
            string mCardNo = txtCardNo.Text.Trim();
            string mMobile = txtMobile.Text.Trim();
            string mOs = Convert.ToString(cboDevice.SelectedValue);
            string mVersion = txtVersion.Text.Trim();
            string mCertType = txtCertType.Text.Trim();
            string mCertNo = txtCertNo.Text.Trim();
            string mCity = txtCity.Text.Trim();
            string mLng = txtLng.Text.Trim();
            string mLat = txtLat.Text.Trim();
            string mTimestamp = txtTimestamp.Text.Trim();
            if (string.IsNullOrEmpty(mTimestamp))
            {
                mTimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            string textA = string.Format(text, new object[] { mChannel, mUserId, mCardNo, mMobile, mOs, mVersion, mCertType, mCertNo, mCity, mLng, mLat, mTimestamp });
            //string text = "?timestamp={0}&userId={1}&mobile={2}&channel={3}&sign=($$$)&mtype={4}";
            //string text2 = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string text3 = this.txtUserId.Text.Trim();
            //string text4 = this.txtMobile.Text.Trim();
            //string text5 = Convert.ToString(this.cboDevice.Text);
            //string text6 = Convert.ToString(this.cboType.SelectedValue);
            //text = string.Format(text, new object[]{text2,text3,text4,text5,text6});
            this.txtParams.Text = textA;
            string empty = string.Empty;
            string newValue = this.ReturnSignNew(ref empty);
            string newParams = textA.Replace("($$$)", newValue);
            this.txtParams.Text = newParams;
            string m3DesKey = txtAPPLK.Text.Trim();
            mCardNo = RetLoginEncodeECB(mCardNo, m3DesKey);
            if (!string.IsNullOrEmpty(mCardNo))
            {
                mCardNo = HttpUtility.UrlEncode(mCardNo);
            }
            mCertNo = RetLoginEncodeECB(mCertNo, m3DesKey);
            if (!string.IsNullOrEmpty(mCertNo))
            {
                mCertNo = HttpUtility.UrlEncode(mCertNo);
            }
            mMobile = RetLoginEncodeECB(mMobile, m3DesKey);
            if (!string.IsNullOrEmpty(mMobile))
            {
                mMobile = HttpUtility.UrlEncode(mMobile);
            }
            if (!string.IsNullOrEmpty(mCity))
            {
                mCity = HttpUtility.UrlEncode(mCity);
            }
            string textB = string.Format(text, new object[] { mChannel, mUserId, mCardNo, mMobile, mOs, mVersion, mCertType, mCertNo, mCity, mLng, mLat, mTimestamp });
            string newValues = textB.Replace("($$$)", newValue);
            this.txtValues.Text = newValues;
        }


        //3DES_CBC 加密(32位密钥 APP使用)
        private string RetEncodeCBC(string des3Str, string des3Key)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //key为abcdefghijklmnopqrstuvwx的Base64编码  
                byte[] key = Convert.FromBase64String(des3Key);
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                byte[] data = utf8.GetBytes(des3Str);
                //System.Console.WriteLine("CBC模式:");
                byte[] str3 = Des3Util.Des3EncodeCBC(key, iv, data);  //
                string en = Convert.ToBase64String(str3);
                return HttpUtility.UrlEncode(en);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
            return "";
        }

        //3DES_CBC 解密(32位密钥 APP使用)
        private string RetDecodeCBC(string des3Str, string des3Key)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //key为abcdefghijklmnopqrstuvwx的Base64编码  
                byte[] key = Convert.FromBase64String(des3Key);//YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                //byte[] data = utf8.GetBytes(des3EncodeStr);
                //System.Console.WriteLine("CBC模式:");
                //byte[] str3 = Des3.Des3EncodeCBC(key, iv, data);  //
                //string en = Convert.ToBase64String(str3);
                byte[] data = Convert.FromBase64String(HttpUtility.UrlDecode(des3Str));
                //byte[] data = Convert.FromBase64String(des3Str);
                byte[] str4 = Des3Util.Des3DecodeCBC(key, iv, data);
                return utf8.GetString(str4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC解密报错，解密串：{0};错误信息：{1};错误详情：{2}", des3Key, ex.Message, ex));
            }
            return "";
        }

        //3DES_ECB 加密(32位密钥 APP使用)
        private string RetEncodeECB(string des3Str, string des3Key)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //key为abcdefghijklmnopqrstuvwx的Base64编码  
                byte[] key = Convert.FromBase64String(des3Key);
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                byte[] data = utf8.GetBytes(des3Str);
                //System.Console.WriteLine( "ECB模式:" );  
                byte[] str1 = Des3Util.Des3EncodeECB(key, iv, data);
                string en = Convert.ToBase64String(str1);
                return HttpUtility.UrlEncode(en);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
            return "";
        }

        //3DES_ECB 解密(32位密钥 APP使用)
        private string RetDecodeECB(string des3Str, string des3Key)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //key为abcdefghijklmnopqrstuvwx的Base64编码  
                byte[] key = Convert.FromBase64String(des3Key);
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                //byte[] data = utf8.GetBytes(des3EncodeStr);
                //System.Console.WriteLine( "ECB模式:" );  
                //byte[] str1 = Des3.Des3EncodeECB( key, iv, data );
                //string en = Convert.ToBase64String(str1);
                byte[] data = Convert.FromBase64String(HttpUtility.UrlDecode(des3Str));
                byte[] str2 = Des3Util.Des3DecodeECB(key, iv, data);
                return utf8.GetString(str2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB解密报错，解密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
            return "";
        }

        //3DES_CBC 加密(24位密钥 微信使用)
        private string RetEncodeCBCWX(string des3Str, string des3Key)
        {
            try
            {
                //String desKey = txtWXKey.Text.Trim();//"1dcrm4goRY8KODsgV1PPuHLB";//24位密钥
                String desIv = "12345678";//"QCsJ2SKR"; ///8位向量
                SymmetricAlgorithm sa;
                ICryptoTransform ct;
                MemoryStream ms;
                CryptoStream cs;
                byte[] byt;
                sa = new TripleDESCryptoServiceProvider();
                sa.Key = Encoding.UTF8.GetBytes(des3Key);
                sa.IV = Encoding.UTF8.GetBytes(desIv);
                ct = sa.CreateEncryptor();
                byt = Encoding.UTF8.GetBytes(des3Str);
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错微信，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
            return "";
        }

        //3DES_CBC 解密(24位密钥 微信使用)
        private string RetDecodeCBCWX(string des3Str, string des3Key)
        {
            try
            {
                //String desKey = txtWXKey.Text.Trim();//"1dcrm4goRY8KODsgV1PPuHLB";//24位密钥
                String desIv = "12345678";// "QCsJ2SKR"; ///8位向量
                SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
                mCSP.Key = Encoding.UTF8.GetBytes(des3Key);
                mCSP.IV = Encoding.UTF8.GetBytes(desIv);
                ICryptoTransform ct;
                MemoryStream ms;
                CryptoStream cs;
                byte[] byt;
                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                byt = Convert.FromBase64String(des3Str);
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC解密报错微信，解密串：{0};错误信息：{1};错误详情：{2}", des3Key, ex.Message, ex));
            }
            return "";
        }

        //3DES_ECB 加密(24位密钥 APP收银台掉单使用)
        public string Encrypt3DES(string a_strString, string a_strKey)
        {
            //TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            //DES.Key = ASCIIEncoding.ASCII.GetBytes(a_strKey);
            //DES.Mode = CipherMode.ECB;

            //ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            //byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(a_strString);
            //return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = Encoding.UTF8.GetBytes(a_strKey);
            DES.Mode = CipherMode.ECB;

            ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            byte[] Buffer = Encoding.UTF8.GetBytes(a_strString);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        //3DES_ECB 解密(24位密钥 APP收银台掉单使用)
        public string Decrypt3DES(string a_strString, string a_strKey)
        {
            //TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            //DES.Key = ASCIIEncoding.ASCII.GetBytes(a_strKey);
            //DES.Mode = CipherMode.ECB;
            //DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            //ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            //string result = "";
            //try
            //{
            //    byte[] Buffer = Convert.FromBase64String(a_strString);
            //    result = ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            //}
            //catch (Exception e)
            //{

            //}
            //return result;

            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = Encoding.UTF8.GetBytes(a_strKey);
            DES.Mode = CipherMode.ECB;
            DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(a_strString);
                result = Encoding.UTF8.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception e)
            {

            }
            return result;
        }

        //3DES_ECB 加密(32位密钥 APP登录使用)
        private string RetLoginEncodeECB(string des3Str, string des3Key)
        {
            try
            {
                //加密
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //key为abcdefghijklmnopqrstuvwx的Base64编码  
                byte[] key = utf8.GetBytes(des3Key.Substring(0, 24));
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                byte[] data = utf8.GetBytes(des3Str);
                //System.Console.WriteLine( "ECB模式:" );  

                byte[] str1 = Des3Util.Des3EncodeECB(key, iv, data);
                string en = Convert.ToBase64String(str1);
                return HttpUtility.UrlEncode(en);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_CBC加密报错，加密串：{0};错误信息：{1};错误详情：{2}", des3Str, ex.Message, ex));
            }
            return "";
        }

        //3DES_CBC 解密(32位密钥 APP使用)
        private string RetLoginDecodeECB(string des3Str, string des3Key)
        {
            try
            {
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //key为abcdefghijklmnopqrstuvwx的Base64编码  
                byte[] key = utf8.GetBytes(des3Key.Substring(0, 24));
                byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用  
                //byte[] data = utf8.GetBytes(des3EncodeStr);
                //System.Console.WriteLine( "ECB模式:" );  
                //byte[] str1 = Des3.Des3EncodeECB( key, iv, data );
                //string en = Convert.ToBase64String(str1);
                byte[] data = null;
                try
                {
                    data = Convert.FromBase64String(HttpUtility.UrlDecode(HttpUtility.UrlDecode(des3Str)));
                }
                catch (Exception)
                {
                    try
                    {
                        data = Convert.FromBase64String(HttpUtility.UrlDecode(des3Str));
                    }
                    catch (Exception)
                    {
                        data = Convert.FromBase64String(des3Str);
                    }
                }
                byte[] str2 = Des3Util.Des3DecodeECB(key, iv, data);
                return utf8.GetString(str2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("方法3DES_ECB解密报错，解密串：{0};错误信息：{1};错误详情：{2}", des3Key, ex.Message, ex));
            }
            return "";
        }

        //下面都是测试的，无用的。

        #region CBC模式**

        #region 扩展方法

        /// <summary>
        /// 3DES 加密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <param name="isRetBase64">true:返回base64,false:返回Utf8</param>
        /// <returns></returns>
        public static string Des3EncodeCBC(string key, string iv, string data)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Encoding.UTF8.GetBytes(data);

            rtnValue = Des3EncodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Convert.ToBase64String(rtnValue);

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeCBC(string key, string iv, string dataEnBase64)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Convert.FromBase64String(dataEnBase64);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeCBC(string key, string iv, byte[] dataArr)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        #endregion

        #region 原加解密方法


        /// <summary>
        /// DES3 CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            //复制于MSDN

            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// DES3 CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion

        #endregion


        #region ECB模式

        #region 不提供Iv(扩展方法)

        private static string ivDefault = "12345678";

        /// <summary>
        /// 3DES 加密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <param name="isRetBase64">true:返回base64,false:返回Utf8</param>
        /// <returns></returns>
        public static string Des3EncodeECB(string key, string data)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(ivDefault);
            byte[] dataArr = Encoding.UTF8.GetBytes(data);

            rtnValue = Des3EncodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Convert.ToBase64String(rtnValue);

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, string dataEnBase64)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(ivDefault);
            byte[] dataArr = Convert.FromBase64String(dataEnBase64);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, byte[] dataArr)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(ivDefault);

            rtnValue = Des3DecodeECB(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }
        #endregion

        #region 提供Iv(扩展方法)


        /// <summary>
        /// 3DES 加密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <param name="isRetBase64">true:返回base64,false:返回Utf8</param>
        /// <returns></returns>
        public static string Des3EncodeECB(string key, string iv, string data)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Encoding.UTF8.GetBytes(data);

            rtnValue = Des3EncodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Convert.ToBase64String(rtnValue);

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, string iv, string dataEnBase64)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);
            byte[] dataArr = Convert.FromBase64String(dataEnBase64);

            rtnValue = Des3DecodeCBC(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        /// <summary>
        /// 3DES 解密(字符串参数和返回值)
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="data">明文</param>
        /// <returns></returns>
        public static string Des3DecodeECB(string key, string iv, byte[] dataArr)
        {
            string rtnResult = string.Empty;
            byte[] rtnValue = null;
            byte[] keyArr = Encoding.UTF8.GetBytes(key);
            byte[] ivArr = Encoding.UTF8.GetBytes(iv);

            rtnValue = Des3DecodeECB(keyArr, ivArr, dataArr);

            rtnResult = Encoding.UTF8.GetString(rtnValue).TrimEnd('\0');    // 去除多余空字符

            return rtnResult;
        }

        #endregion

        #region 原加解密方法


        /// <summary>
        /// DES3 ECB模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        /// <summary>
        /// DES3 ECB模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion







        #endregion




        //public byte[] Des3EncodeECBX(byte[] key, byte[] iv, byte[] data)
        //{
        //    try
        //    {
        //        // Create a MemoryStream.  
        //        MemoryStream mStream = new MemoryStream();
        //        TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
        //        tdsp.Mode = CipherMode.ECB;
        //        tdsp.Padding = PaddingMode.PKCS7;
        //        // Create a CryptoStream using the MemoryStream   
        //        // and the passed key and initialization vector (IV).  
        //        CryptoStream cStream = new CryptoStream(mStream,
        //            tdsp.CreateEncryptor(key, iv),
        //            CryptoStreamMode.Write);
        //        // Write the byte array to the crypto stream and flush it.  
        //        cStream.Write(data, 0, data.Length);
        //        cStream.FlushFinalBlock();
        //        // Get an array of bytes from the   
        //        // MemoryStream that holds the   
        //        // encrypted data.  
        //        byte[] ret = mStream.ToArray();
        //        // Close the streams.  
        //        cStream.Close();
        //        mStream.Close();
        //        // Return the encrypted buffer.  
        //        return ret;
        //    }
        //    catch (CryptographicException e)
        //    {
        //        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        //        return null;
        //    }
        //}












    }
}
