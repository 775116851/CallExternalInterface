using allinpay.O2O.Cmn;
using com.allinpay.ecommerce.ImageHelper.ImageOperator;
using DataSyncRWY.DAL;
using DataSyncRWY.Model;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DataSyncRWY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sUrl = "http://test.zmyou.com/union/api/market/scenic!api.action";
            //string sParam = "u=api_test&p=c4ca4238a0b923820dcc509a6f75849b&body={\"action\":\"GET_PROVINCE\"}&sign=318c3eb16d844c1bbe77f117303a6359";
            //string sMessage = PostByHttpRequest1(sParam, sUrl);

            StringBuilder signSB = new StringBuilder();
            SortedList sl = new SortedList();
            sl.Add("u", "api_test");
            sl.Add("p", "c4ca4238a0b923820dcc509a6f75849b");
            //sl.Add("sign", "318c3eb16d844c1bbe77f117303a6359");
            sl.Add("body", "{\"id\":110100,\"action\":\"GET_DISTRICT\"}");
            signSB.Append(sl["u"]).Append(sl["p"]).Append(sl["body"]).Append("ot7M30XwoGL35IOl");
            string f = Util.GetMD5(signSB.ToString()).ToLower();//3ea9642414849e70a5eea37621444dd2
            string sParam = "u=api_test&p=c4ca4238a0b923820dcc509a6f75849b&body={\"id\":110100,\"action\":\"GET_DISTRICT\"}&sign=" + f;
            string sMessage = PostByHttpRequest(sParam, sUrl);


            //JsonData jd = JsonMapper.ToObject(sMessage);
            //StringBuilder sb = new StringBuilder();
            //StringBuilder signSB = new StringBuilder();
            //SortedList sl = new SortedList();
            //sl.Add("u", "api_test");
            //sl.Add("p", "c4ca4238a0b923820dcc509a6f75849b");
            ////sl.Add("sign", "318c3eb16d844c1bbe77f117303a6359");
            //sl.Add("body", "{\"action\":\"GET_PROVINCE\"}");
            //signSB.Append(sl["u"]).Append(sl["p"]).Append(sl["body"]).Append("ot7M30XwoGL35IOl");
            //string f = Util.GetMD5(signSB.ToString()).ToLower();
            //int i = 0;
            //foreach (string key in sl.Keys)
            //{
            //    if (i == 0)
            //    {
            //        sb.Append(key).Append("=").Append(sl[key].ToString());
            //    }
            //    else
            //    {
            //        sb.Append("&").Append(key).Append("=").Append(sl[key].ToString());
            //    }
            //    i++;
            //}
            //sb.Append("&").Append("body").Append("=").Append("{\"action\":\"GET_PROVINCE\"}");
            
        }

        //区域下载
        private void QYDown_Click(object sender, EventArgs e)
        {
            string sUrl = ConfigurationManager.AppSettings["url"];//"http://test.zmyou.com/union/api/market/scenic!api.action";
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_PROVINCE");
            string sPostData = GetPostData(sParam);
            //string sPostData = GetPostData("{\"action\":\"GET_PROVINCE\"}");
            string sMessage = PostByHttpRequest(sPostData, sUrl);//省
            JsonData jdP = JsonMapper.ToObject(sMessage);
            DateTime lasthUpdateTime = DateTime.Now;
            if (Convert.ToString(jdP[0]) == "ok")
            {
                JsonData jdPROVINCE = JsonMapper.ToObject(jdP[1].ToString());
                foreach (var mPROVINCE in jdPROVINCE)
                {
                    var rP = (System.Collections.Generic.KeyValuePair<string, LitJson.JsonData>)mPROVINCE;
                    string sPKey = rP.Key;
                    string sPValue = Convert.ToString(rP.Value);
                    if (sPKey == "-1")
                    {
                        continue;
                    }
                    Area_RWYEntity pArea = new Area_RWYEntity();
                    pArea.RWYCode = sPKey;
                    pArea.ProvinceName = sPValue;
                    pArea.Status = 0;
                    pArea.LastUpdateTime = lasthUpdateTime;
                    int PsysNo = new Area_RWYDac().AddNew(pArea);
                    sParam.Clear();
                    sParam.Add("provinceId", sPKey);
                    sParam.Add("action", "GET_CITY");
                    sPostData = GetPostData(sParam);//"{\"id\":" + sValues[0] + ",\"action\":\"GET_CITY\"}"
                    sMessage = PostByHttpRequest(sPostData, sUrl);//市
                    JsonData jdC = JsonMapper.ToObject(sMessage);
                    if (Convert.ToString(jdC[0]) == "ok")
                    {
                        JsonData jdCITY = JsonMapper.ToObject(jdC[1].ToString());
                        if (jdCITY.Count <= 0)
                        {
                            continue;
                        }
                        foreach (var mCITY in jdCITY)
                        {
                            var rC = (System.Collections.Generic.KeyValuePair<string, LitJson.JsonData>)mCITY;
                            string sCKey = rC.Key;
                            string sCValue = Convert.ToString(rC.Value);
                            if (sCKey == "-1")
                            {
                                continue;
                            }
                            Area_RWYEntity CArea = new Area_RWYEntity();
                            CArea.ProvinceSysNo = PsysNo;
                            CArea.ProvinceName = sPValue;
                            CArea.RWYCode = sCKey;
                            CArea.CityName = sCValue;
                            CArea.Status = 0;
                            CArea.LastUpdateTime = lasthUpdateTime;
                            int CsysNo = new Area_RWYDac().AddNew(CArea);
                            continue;
                            sParam.Clear();
                            sParam.Add("id", sCKey);
                            sParam.Add("action", "GET_DISTRICT");
                            sPostData = GetPostData(sParam);
                            sMessage = PostByHttpRequest(sPostData, sUrl);//商圈
                            JsonData jdZ = JsonMapper.ToObject(sMessage);
                            if (Convert.ToString(jdZ[0]) == "ok")
                            {
                                JsonData jdZONE = JsonMapper.ToObject(jdZ[1].ToString());
                                if (jdZONE.Count <= 0)
                                {
                                    continue;
                                }
                                foreach (var mZONE in jdZONE)
                                {
                                    var rZ = (System.Collections.Generic.KeyValuePair<string, LitJson.JsonData>)mZONE;
                                    string sZKey = rZ.Key;
                                    string sZValue = Convert.ToString(rZ.Value);
                                    if (sZKey == "-1")
                                    {
                                        continue;
                                    }
                                    Area_RWYEntity ZArea = new Area_RWYEntity();
                                    ZArea.ProvinceSysNo = PsysNo;
                                    ZArea.CitySysNo = CsysNo;
                                    ZArea.RWYCode = sZKey;
                                    ZArea.ProvinceName = sPValue;
                                    ZArea.CityName = sCValue;
                                    ZArea.ZoneName = sZValue;
                                    ZArea.Status = 0;
                                    ZArea.LastUpdateTime = lasthUpdateTime;
                                    int ZsysNo = new Area_RWYDac().AddNew(ZArea);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("数据下载失败 " + jdP[1]);
                return;
            }
            MessageBox.Show("数据下载完成！！");
        }

        public string PostByHttpRequest(string str, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.Accept = "application/x-www-form-urlencoded;charset=utf-8";

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

        //拼接验签 返回最终参数列表
        public string GetPostData(SortedList sParam)//SortedList sParam
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder signSB = new StringBuilder();
            Hashtable sl = new Hashtable();
            sl.Add("u", ConfigurationManager.AppSettings["u"]);
            sl.Add("p", ConfigurationManager.AppSettings["p"]);
            sl.Add("body", GetPostParam(sParam));
            string md5Key = ConfigurationManager.AppSettings["md5Key"];//"ot7M30XwoGL35IOl";
            sb.Append("u").Append("=").Append(sl["u"]).Append("&");
            sb.Append("p").Append("=").Append(sl["p"]).Append("&");
            sb.Append("body").Append("=").Append(sl["body"]);
            signSB.Append(sl["u"]).Append(sl["p"]).Append(sl["body"]).Append(md5Key);
            //"u=api_test&p=c4ca4238a0b923820dcc509a6f75849b&body={\"id\":350000,\"action\":\"GET_CITY\"}&sign=ca0b7cec66c21bf7b8b1efd7ec1a419d";
            return sb.ToString() + "&sign=" + Util.GetMD5(signSB.ToString()).ToLower();
        }

        public string GetPostData(string sPostParam)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder signSB = new StringBuilder();
            Hashtable sl = new Hashtable();
            sl.Add("u", ConfigurationManager.AppSettings["u"]);
            sl.Add("p", ConfigurationManager.AppSettings["p"]);
            sl.Add("body", sPostParam);
            string md5Key = ConfigurationManager.AppSettings["md5Key"];//"ot7M30XwoGL35IOl";
            sb.Append("u").Append("=").Append(sl["u"]).Append("&");
            sb.Append("p").Append("=").Append(sl["p"]).Append("&");
            sb.Append("body").Append("=").Append(sl["body"]);
            signSB.Append(sl["u"]).Append(sl["p"]).Append(sl["body"]).Append(md5Key);
            //"u=api_test&p=c4ca4238a0b923820dcc509a6f75849b&body={\"id\":350000,\"action\":\"GET_CITY\"}&sign=ca0b7cec66c21bf7b8b1efd7ec1a419d";
            return sb.ToString() + "&sign=" + Util.GetMD5(signSB.ToString()).ToLower();
        }

        //拼接Body参数
        public string GetPostParam(SortedList sParam)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            int i = 0;
            foreach (string key in sParam.Keys)
            {
                if(i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("\"").Append(key).Append("\":\"").Append(sParam[key].ToString()).Append("\"");
                i++;
            }
            sb.Append("}");
            return sb.ToString();
        }

        public string GetPostParam(SortedList sParam, string sType)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (string key in sParam.Keys)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                if (sType == "1")
                {
                    sb.Append("\"").Append(key).Append("\":").Append(sParam[key].ToString()).Append("");
                }
                else
                {
                    sb.Append("\"").Append(key).Append("\":\"").Append(sParam[key].ToString()).Append("\"");
                }
                i++;
            }
            return sb.ToString();
        }

        private void btnCS_Click(object sender, EventArgs e)
        {
            txtValues.Text = "";
            string sParams = txtParams.Text.Trim();
            //if(sParams.Length <= 2)
            //{
            //    MessageBox.Show("请输入参数再查询！");
            //    return;
            //}
            //sParams = sParams.Replace("{", "").Replace("}", "").Replace("\"","");
            //string[] sParList = sParams.Split(',');
            //SortedList sParam = new SortedList();
            //foreach(string sp in sParList)
            //{
            //    string[] sKV = sp.Split(':');
            //    sParam.Add(sKV[0], sKV[1]);
            //}

            //SortedList sParam = new SortedList();
            //sParam.Add("action", "GET_SCENIC_LIST");
            //sParam.Add("currentPageNum", "1");
            //sParam.Add("pageSize", "5");
            //sParam.Add("name", "温泉");
            //string sp1 = "{" + GetPostParam(sParam, "0");
            //sParam.Clear();
            //sParam.Add("provinceList", "[\"福建\"]");
            //sParam.Add("typeList", "[\"1\",\"2\"]");
            //sParam.Add("starList", "[\"5\",\"4\"]");
            //sParam.Add("cityList", "[\"厦门\",\"泉州\"]");
            //sp1 = sp1 + "," + GetPostParam(sParam, "1") + "}";
            //string sPostData = GetPostData(sp1);

            string sUrl = ConfigurationManager.AppSettings["url"];
            string sPostData = GetPostData(sParams);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            txtValues.Text = sMessage;
            JsonData jd = JsonMapper.ToObject(sMessage);
            if (Convert.ToString(jd[0]) == "ok")
            {
                string sSign = Util.GetMD5(Convert.ToString(jd[0]) + Convert.ToString(jd[1]) + ConfigurationManager.AppSettings["md5Key"]).ToLower();
                if (sSign == Convert.ToString(jd[2]))
                {
                    MessageBox.Show("回传验证成功！！");
                }
            }
        }

        private void txtValues_DoubleClick(object sender, EventArgs e)
        {
            txtValues.SelectAll();
        }

        public string DictionaryToJson()
        {
            string sUrl = ConfigurationManager.AppSettings["url"];//"http://test.zmyou.com/union/api/market/scenic!api.action";
            Hashtable sParam = new Hashtable();
            sParam.Add("action", "GET_SCENIC_LIST");
            sParam.Add("currentPageNum", 1);
            sParam.Add("pageSize", 5);
            sParam.Add("name", "温泉");
            string sTypeList = "[" + "3" + "," + "2" + "]";
            sParam.Add("typeList", sTypeList);
            //sParam.Add("starList", "[\"5\",\"4\"]");
            //sParam.Add("provinceList", "[\"福建\"]");
            //sParam.Add("cityList", "[\"厦门\",\"泉州\"]");
            string sParams = JsonMapper.ToJson(sParam).Replace("\"[", "[").Replace("]\"", "]");
            string f = "";
            string sPostData = GetPostData(sParams);
            string sMessage = PostByHttpRequest(sPostData, sUrl);//省
            return sMessage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DictionaryToJson();
        }

        //景区门票
        private void button2_Click(object sender, EventArgs e)
        {
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_WITH_TICKET_LIST");
            sParam.Add("currentPageNum", 1);
            sParam.Add("pageSize", 9999999);
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            int i = 0;
            int j = 0;
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("{景点A:[门票1,门票2],景点B:[门票3]}" + Environment.NewLine + "{");
            try
            {
                if (Convert.ToString(jdMessage[0]) == "ok")
                {
                    JsonData jdTotal = JsonMapper.ToObject(jdMessage[1].ToString());
                    JsonData jdPageData = jdTotal[0];//PageData
                    JsonData jdPageInfo = jdTotal[1];//PageInfo
                    foreach (JsonData mScenic in jdPageData)
                    {
                        if(i > 0)
                        {
                            sbJson.Append(",");
                        }
                        i++;
                        if(i == 49)
                        {

                        }
                        string[] sScenic = mScenic.Inst_Object.Keys.ToArray();

                        string ScenicID = Convert.ToString(mScenic["id"]);
                        string ScenicName = Convert.ToString(mScenic["name"]);
                        string ScenicShortName = Convert.ToString(mScenic["shortName"]);
                        string ScenicTicketType = Convert.ToString(mScenic["ticketType"]);
                        string ScenicStar = Convert.ToString(mScenic["star"]);
                        string ScenicOpenTime = Convert.ToString(mScenic["openTime"]);
                        string ScenicBestTravelTime = Convert.ToString(mScenic["bestTravelTime"]);
                        string ScenicNotice = Convert.ToString(mScenic["notice"]);
                        string ScenicB2CNotice = Convert.ToString(mScenic["b2cNotice"]);
                        string ScenicDescription = Convert.ToString(mScenic["description"]);
                        string ImgUrl = Convert.ToString(mScenic["imgUrl"]);
                        string Status = Convert.ToString(mScenic["status"]);
                        string ScenicContact = Convert.ToString(mScenic["contact"]);
                        string ScenicAddr = Convert.ToString(mScenic["addr"]);
                        string ScenicIdCardAccepted = Convert.ToString(mScenic["idCardAccepted"]);
                        string ScenicAgreement = Convert.ToString(mScenic["agreement"]);
                        string ScenicLatitude = string.Empty;
                        if (sScenic.Contains("latitude"))
                        {
                            ScenicLatitude = Convert.ToString(mScenic["latitude"]);
                        }
                        string ScenicLongitude = string.Empty;
                        if (sScenic.Contains("longitude"))
                        {
                            ScenicLongitude = Convert.ToString(mScenic["longitude"]);
                        }
                        string ScenicProvinceName = Convert.ToString(mScenic["provinceName"]);
                        string ScenicCityName = Convert.ToString(mScenic["cityName"]);
                        string ScenicTransportation = Convert.ToString(mScenic["transportation"]);
                        string ScenicIsRealName = Convert.ToString(mScenic["isRealName"]);
                        string ScenicStartDateFlag = Convert.ToString(mScenic["startDateFlag"]);
                        string ScenicIsIDCardNeeded = Convert.ToString(mScenic["idCardNeeded"]);
                        string ScenicPurchaseType = Convert.ToString(mScenic["purchaseType"]);
                        //查询景点图片
                        sParam.Clear();
                        sParam.Add("action", "GET_SCENIC_IMAGE");
                        sParam.Add("id", Convert.ToInt32(ScenicID));//景区ID
                        string sImgBody = JsonMapper.ToJson(sParam);
                        string sImgPostData = GetPostData(sImgBody);
                        string sImgMessage = PostByHttpRequest(sImgPostData, sUrl);
                        JsonData jdImgMessage = JsonMapper.ToObject(sImgMessage);
                        if (Convert.ToString(jdImgMessage[0]) == "ok")
                        {
                            JsonData jdImageList = JsonMapper.ToObject(jdImgMessage[1].ToString());
                            foreach (JsonData sImage in jdImageList)
                            {
                                string sImageUrl = Convert.ToString(sImage);
                                //插入景区图片
                            }
                        }
                        if(i % 5 == 0)
                        {
                            sbJson.Append(Environment.NewLine);
                        }
                        sbJson.Append(ScenicID + ":[");
                        //插入景点 返回VendorSysNo
                        if (sScenic.Contains("ticketList"))//mScenic.Count >= 26
                        {
                            JsonData jdTicketList = mScenic["ticketList"];
                            if (jdTicketList.Count > 0)
                            {
                                
                                foreach (JsonData mTicket in jdTicketList)
                                {
                                    j++;
                                    string[] sTicket = mTicket.Inst_Object.Keys.ToArray();
                                    
                                    string RWYTicketID = Convert.ToString(mTicket["id"]);
                                    string TicketName = Convert.ToString(mTicket["name"]);
                                    string mScenicID = Convert.ToString(mTicket["scenicId"]);
                                    string TicketStatus = Convert.ToString(mTicket["status"]);
                                    string TicketDescription = Convert.ToString(mTicket["description"]);
                                    string TicketEndOfTime = Convert.ToString(mTicket["endOfTime"]);
                                    string TicketNotice = Convert.ToString(mTicket["notice"]);
                                    string TicketOrderAdvanceHours = Convert.ToString(mTicket["orderAdvanceHours"]);
                                    string TicketOrderAdvanceDays = Convert.ToString(mTicket["orderAdvanceDays"]);
                                    string TicketOrderBeforeHour = Convert.ToString(mTicket["orderBeforeHour"]);
                                    string TicketOrderBeforeMin = Convert.ToString(mTicket["orderBeforeMin"]);
                                    string TicketMaxOrderAdvanceDays = Convert.ToString(mTicket["maxOrderAdvanceDays"]);
                                    string TicketRefundAdvanceHours = Convert.ToString(mTicket["refundAdvanceHours"]);
                                    string TicketUseAdvanceHours = Convert.ToString(mTicket["useAdvanceHours"]);
                                    string TicketAdditionaIInfo = string.Empty;
                                    if (sTicket.Contains("additionalInfo"))
                                    {
                                        TicketAdditionaIInfo = Convert.ToString(mTicket["additionalInfo"]);
                                    }
                                    string TicketEffectiveDate = Convert.ToString(mTicket["effectiveDate"]);
                                    string TicketValidWeeks = string.Empty;
                                    if (sTicket.Contains("validWeeks"))
                                    {
                                        TicketValidWeeks = Convert.ToString(mTicket["validWeeks"]);
                                    }
                                    string TicketValidDates = string.Empty;
                                    if (sTicket.Contains("validDates"))
                                    {
                                        TicketValidDates = Convert.ToString(mTicket["validDates"]);
                                    }
                                    string TicketInvalidDates = string.Empty;
                                    if (sTicket.Contains("invalidDates"))
                                    {
                                        TicketInvalidDates = Convert.ToString(mTicket["invalidDates"]);
                                    }
                                    string TicketIsInvtLimit = Convert.ToString(mTicket["isInvtLimit"]);
                                    string TicketMaxOrderNum = Convert.ToString(mTicket["maxOrderNum"]);
                                    string TicketMinOrderNum = Convert.ToString(mTicket["minOrderNum"]);
                                    string TicketPriceType = Convert.ToString(mTicket["priceType"]);
                                    string TicketScenicName = Convert.ToString(mTicket["scenicName"]);
                                    string TicketSalePrice = Convert.ToString(mTicket["salePrice"]);
                                    string TicketSuggestPrice = string.Empty;
                                    if (sTicket.Contains("suggestPrice"))
                                    {
                                        TicketSuggestPrice = Convert.ToString(mTicket["suggestPrice"]);
                                    }
                                    string TicketMarketPrice = Convert.ToString(mTicket["marketPrice"]);
                                    string TicketLimitPrice = Convert.ToString(mTicket["limitPrice"]);
                                    string TicketEbonus = Convert.ToString(mTicket["ebonus"]);
                                    string TicketStartDateFlag = Convert.ToString(mTicket["startDateFlag"]);
                                    string TicketIsRealName = Convert.ToString(mTicket["isRealName"]);
                                    string TicketScenicStatus = Convert.ToString(mTicket["scenicStatus"]);
                                    string TicketIsSaleAlone = Convert.ToString(mTicket["isSaleAlone"]);
                                    string TicketIdCardNeeded = Convert.ToString(mTicket["idCardNeeded"]);
                                    string TicketIdCardAccepted = Convert.ToString(mTicket["idCardAccepted"]);
                                    //查询门票库存
                                    sParam.Clear();
                                    sParam.Add("action", "GET_SCENIC_TICKET_INVT");
                                    sParam.Add("idList", "[" + Convert.ToInt32(RWYTicketID) + "]");//景区门票ID
                                    string sStockBody = JsonMapper.ToJson(sParam).Replace("\"[", "[").Replace("]\"", "]"); ;
                                    string sStockPostData = GetPostData(sStockBody);
                                    string sStockMessage = PostByHttpRequest(sStockPostData, sUrl);
                                    JsonData jdStockMessage = JsonMapper.ToObject(sStockMessage);
                                    if (Convert.ToString(jdStockMessage[0]) == "ok")
                                    {
                                        JsonData jdStockList = JsonMapper.ToObject(jdStockMessage[1].ToString());
                                        foreach (JsonData sStock in jdStockList)
                                        {
                                            string ticketId = Convert.ToString(sStock[0]);
                                            string invtDate = Convert.ToString(sStock[1]);
                                            string qty = Convert.ToString(sStock[2]);
                                            //插入门票库存
                                        }
                                    }
                                    sbJson.Append(RWYTicketID + ",");
                                    //插入门票

                                }
                            }
                        }
                        sbJson.Remove(sbJson.Length - 1, 1);
                        sbJson.Append("]");
                        //string ScenicTicketType = Convert.ToString(mTicket[3]);
                        //var rTicket = (System.Collections.Generic.Dictionary<string,LitJson.JsonData>)mTicket;

                        //string sZKey = rTicket.;
                        //string sZValue = Convert.ToString(rTicket.Value);
                    }
                }
                else
                {
                    MessageBox.Show("数据下载失败！");
                }
                sbJson.Append("}");
                MessageBox.Show("成功！" + i + "/" + j + @" 文件存储到D:\RWY.txt");

                try
                {
                    FileStream fs = new FileStream(@"D:\RWY.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(sbJson.ToString());
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //景区图片
        private void button3_Click(object sender, EventArgs e)
        {
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_IMAGE");
            sParam.Add("id", 204);//景区ID
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            if (Convert.ToString(jdMessage[0]) == "ok")
            {
                JsonData jdImageList = JsonMapper.ToObject(jdMessage[1].ToString());
                foreach (JsonData sImage in jdImageList)
                {
                    string sImageUrl = Convert.ToString(sImage);
                }
            }
            MessageBox.Show("景区图片OK");
        }

        //景区门票库存
        private void button4_Click(object sender, EventArgs e)
        {
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_TICKET_INVT");
            sParam.Add("idList", "[375]");//景区门票ID
            string sBody = JsonMapper.ToJson(sParam).Replace("\"[", "[").Replace("]\"", "]"); ;
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            if (Convert.ToString(jdMessage[0]) == "ok")
            {
                JsonData jdStockList = JsonMapper.ToObject(jdMessage[1].ToString());
                foreach (JsonData sStock in jdStockList)
                {
                    string ticketId = Convert.ToString(sStock[0]);
                    string invtDate = Convert.ToString(sStock[1]);
                    string qty = Convert.ToString(sStock[2]);
                }
            }
            MessageBox.Show("库存OK");
        }

        //景区列表接口
        private void button5_Click(object sender, EventArgs e)
        {
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_LIST");
            sParam.Add("currentPageNum", 1);
            sParam.Add("pageSize", 9999999);
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            int i = 0;
            if (Convert.ToString(jdMessage[0]) == "ok")
            {
                JsonData jdTotal = JsonMapper.ToObject(jdMessage[1].ToString());
                JsonData jdPageData = jdTotal[0];//PageData
                JsonData jdPageInfo = jdTotal[1];//PageInfo
                foreach (JsonData mScenic in jdPageData)
                {
                    i++;
                    string[] sScenic = mScenic.Inst_Object.Keys.ToArray();

                    string ScenicID = Convert.ToString(mScenic["id"]);
                    string ScenicName = Convert.ToString(mScenic["name"]);
                    string ScenicShortName = Convert.ToString(mScenic["shortName"]);
                    string ScenicTicketType = Convert.ToString(mScenic["ticketType"]);
                    string ScenicStar = Convert.ToString(mScenic["star"]);
                    string ScenicOpenTime = Convert.ToString(mScenic["openTime"]);
                    string ScenicBestTravelTime = Convert.ToString(mScenic["bestTravelTime"]);
                    string ScenicNotice = Convert.ToString(mScenic["notice"]);
                    string ScenicB2CNotice = Convert.ToString(mScenic["b2cNotice"]);
                    string ScenicDescription = Convert.ToString(mScenic["description"]);
                    string ImgUrl = Convert.ToString(mScenic["imgUrl"]);
                    string Status = Convert.ToString(mScenic["status"]);
                    string ScenicContact = Convert.ToString(mScenic["contact"]);
                    string ScenicAddr = Convert.ToString(mScenic["addr"]);
                    string ScenicIdCardAccepted = Convert.ToString(mScenic["idCardAccepted"]);
                    string ScenicAgreement = Convert.ToString(mScenic["agreement"]);
                    string ScenicLatitude = string.Empty;
                    if (sScenic.Contains("latitude"))
                    {
                        ScenicLatitude = Convert.ToString(mScenic["latitude"]);
                    }
                    string ScenicLongitude = string.Empty;
                    if (sScenic.Contains("longitude"))
                    {
                        ScenicLongitude = Convert.ToString(mScenic["longitude"]);
                    }
                    string ScenicProvinceName = Convert.ToString(mScenic["provinceName"]);
                    string ScenicCityName = Convert.ToString(mScenic["cityName"]);
                    string ScenicTransportation = Convert.ToString(mScenic["transportation"]);
                    string ScenicIsRealName = Convert.ToString(mScenic["isRealName"]);
                    string ScenicStartDateFlag = Convert.ToString(mScenic["startDateFlag"]);
                    string ScenicIsIDCardNeeded = Convert.ToString(mScenic["idCardNeeded"]);
                    string ScenicPurchaseType = Convert.ToString(mScenic["purchaseType"]);
                }
            }
            MessageBox.Show(string.Format("景区一共{0}条数据",i));


           
        }

        //景区门票列表(不区分状态)
        private void button6_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtJQMPLB.Text.Trim()))
            {
                MessageBox.Show("请输入景区编号");
                txtJQMPLB.Focus();
                return;
            }
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_TICKET_LIST");
            sParam.Add("id", txtJQMPLB.Text.Trim());
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            txtValues.Text = sMessage;
            if (Convert.ToString(jdMessage[0]) == "ok")
            {
                JsonData jdTotal = JsonMapper.ToObject(jdMessage[1].ToString());
                foreach (JsonData mTicket in jdTotal)
                {
                    string[] sTicket = mTicket.Inst_Object.Keys.ToArray();

                    string RWYTicketID = Convert.ToString(mTicket["id"]);
                    string TicketName = Convert.ToString(mTicket["name"]);
                    string mScenicID = Convert.ToString(mTicket["scenicId"]);
                    string TicketStatus = Convert.ToString(mTicket["status"]);
                    string TicketDescription = Convert.ToString(mTicket["description"]);
                    string TicketEndOfTime = Convert.ToString(mTicket["endOfTime"]);
                    string TicketNotice = Convert.ToString(mTicket["notice"]);
                    string TicketOrderAdvanceHours = Convert.ToString(mTicket["orderAdvanceHours"]);
                    string TicketOrderAdvanceDays = Convert.ToString(mTicket["orderAdvanceDays"]);
                    string TicketOrderBeforeHour = Convert.ToString(mTicket["orderBeforeHour"]);
                    string TicketOrderBeforeMin = Convert.ToString(mTicket["orderBeforeMin"]);
                    string TicketMaxOrderAdvanceDays = Convert.ToString(mTicket["maxOrderAdvanceDays"]);
                    string TicketRefundAdvanceHours = Convert.ToString(mTicket["refundAdvanceHours"]);
                    string TicketUseAdvanceHours = Convert.ToString(mTicket["useAdvanceHours"]);
                    string TicketAdditionaIInfo = string.Empty;
                    if (sTicket.Contains("additionalInfo"))
                    {
                        TicketAdditionaIInfo = Convert.ToString(mTicket["additionalInfo"]);
                    }
                    string TicketEffectiveDate = Convert.ToString(mTicket["effectiveDate"]);
                    string TicketValidWeeks = string.Empty;
                    if (sTicket.Contains("validWeeks"))
                    {
                        TicketValidWeeks = Convert.ToString(mTicket["validWeeks"]);
                    }
                    string TicketValidDates = string.Empty;
                    if (sTicket.Contains("validDates"))
                    {
                        TicketValidDates = Convert.ToString(mTicket["validDates"]);
                    }
                    string TicketInvalidDates = string.Empty;
                    if (sTicket.Contains("invalidDates"))
                    {
                        TicketInvalidDates = Convert.ToString(mTicket["invalidDates"]);
                    }
                    string TicketIsInvtLimit = Convert.ToString(mTicket["isInvtLimit"]);
                    string TicketMaxOrderNum = Convert.ToString(mTicket["maxOrderNum"]);
                    string TicketMinOrderNum = Convert.ToString(mTicket["minOrderNum"]);
                    string TicketPriceType = Convert.ToString(mTicket["priceType"]);
                    string TicketScenicName = Convert.ToString(mTicket["scenicName"]);
                    string TicketSalePrice = Convert.ToString(mTicket["salePrice"]);
                    string TicketSuggestPrice = string.Empty;
                    if (sTicket.Contains("suggestPrice"))
                    {
                        TicketSuggestPrice = Convert.ToString(mTicket["suggestPrice"]);
                    }
                    string TicketMarketPrice = Convert.ToString(mTicket["marketPrice"]);
                    //string TicketLimitPrice = Convert.ToString(mTicket["limitPrice"]);
                    //string TicketEbonus = Convert.ToString(mTicket["ebonus"]);
                    //string TicketStartDateFlag = Convert.ToString(mTicket["startDateFlag"]);
                    //string TicketIsRealName = Convert.ToString(mTicket["isRealName"]);
                    //string TicketScenicStatus = Convert.ToString(mTicket["scenicStatus"]);
                    //string TicketIsSaleAlone = Convert.ToString(mTicket["isSaleAlone"]);
                    //string TicketIdCardNeeded = Convert.ToString(mTicket["idCardNeeded"]);
                    //string TicketIdCardAccepted = Convert.ToString(mTicket["idCardAccepted"]);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDYJQJBMLB.Text.Trim()))
            {
                MessageBox.Show("请输入景区编号");
                txtDYJQJBMLB.Focus();
                return;
            }
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_WITH_TICKET");
            sParam.Add("id", txtDYJQJBMLB.Text.Trim());
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            txtValues.Text = sMessage;
            //遍历方法类似 button3_Click 景区门票
        }

        //下载数据
        private void button8_Click(object sender, EventArgs e)
        {
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_WITH_TICKET_LIST");
            sParam.Add("currentPageNum", 1);
            sParam.Add("pageSize", 9999999);
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            int i = 0;
            int j = 0;
            DateTime lastTime = DateTime.Now;
            try
            {
                if (Convert.ToString(jdMessage[0]) == "ok")
                {
                    JsonData jdTotal = JsonMapper.ToObject(jdMessage[1].ToString());
                    JsonData jdPageData = jdTotal[0];//PageData
                    JsonData jdPageInfo = jdTotal[1];//PageInfo
                    foreach (JsonData mScenic in jdPageData)
                    {
                        i++;
                        if (i == 101)
                        {

                        }
                        #region 景区
                        string[] sScenic = mScenic.Inst_Object.Keys.ToArray();
                        string ScenicID = Convert.ToString(mScenic["id"]);
                        string ScenicName = Convert.ToString(mScenic["name"]);
                        string ScenicShortName = Convert.ToString(mScenic["shortName"]);
                        string ScenicTicketType = Convert.ToString(mScenic["ticketType"]);
                        string ScenicStar = Convert.ToString(mScenic["star"]);
                        string ScenicOpenTime = Convert.ToString(mScenic["openTime"]);
                        string ScenicBestTravelTime = Convert.ToString(mScenic["bestTravelTime"]);
                        string ScenicNotice = Convert.ToString(mScenic["notice"]);
                        string ScenicB2CNotice = Convert.ToString(mScenic["b2cNotice"]);
                        string ScenicDescription = Convert.ToString(mScenic["description"]);
                        string ImgUrl = Convert.ToString(mScenic["imgUrl"]);
                        string Status = Convert.ToString(mScenic["status"]);
                        string ScenicContact = Convert.ToString(mScenic["contact"]);
                        string ScenicAddr = Convert.ToString(mScenic["addr"]);
                        string ScenicIdCardAccepted = Convert.ToString(mScenic["idCardAccepted"]);
                        string ScenicAgreement = Convert.ToString(mScenic["agreement"]);
                        string ScenicLatitude = string.Empty;
                        if (sScenic.Contains("latitude"))
                        {
                            ScenicLatitude = Convert.ToString(mScenic["latitude"]);
                        }
                        string ScenicLongitude = string.Empty;
                        if (sScenic.Contains("longitude"))
                        {
                            ScenicLongitude = Convert.ToString(mScenic["longitude"]);
                        }
                        string ScenicProvinceName = Convert.ToString(mScenic["provinceName"]);
                        string ScenicCityName = Convert.ToString(mScenic["cityName"]);
                        string ScenicTransportation = Convert.ToString(mScenic["transportation"]);
                        string ScenicIsRealName = Convert.ToString(mScenic["isRealName"]);
                        string ScenicStartDateFlag = Convert.ToString(mScenic["startDateFlag"]);
                        string ScenicIsIDCardNeeded = Convert.ToString(mScenic["idCardNeeded"]);
                        string ScenicPurchaseType = Convert.ToString(mScenic["purchaseType"]);

                        SCENIC_RWYEntity sRWY = new SCENIC_RWYEntity();
                        sRWY.ScenicId = ScenicID;
                        sRWY.Name = ScenicName;
                        sRWY.ShortName = ScenicShortName;
                        sRWY.TicketType = ScenicTicketType;
                        sRWY.Star = ScenicStar;
                        sRWY.OpenTime = ScenicOpenTime;
                        sRWY.BestTravelTime = ScenicBestTravelTime;
                        sRWY.Notice = ScenicNotice;
                        sRWY.Description = ScenicDescription;
                        sRWY.ImgUrl = ImgUrl;
                        sRWY.Status = Status;
                        sRWY.Contact = ScenicContact;
                        sRWY.Addr = ScenicAddr;
                        sRWY.Latitude = ScenicLatitude;
                        sRWY.Longitude = ScenicLongitude;
                        sRWY.ProvinceName = ScenicProvinceName;
                        sRWY.CityName = ScenicCityName;
                        sRWY.Transportation = ScenicTransportation;
                        sRWY.IsRealName = ScenicIsRealName;
                        sRWY.StartDateFlag = ScenicStartDateFlag;
                        sRWY.IdCardNeeded = ScenicIdCardAccepted;
                        SCENIC_RWYEntity srwye = new SCENIC_RWYDac().GetModelByScenicID(ScenicID);
                        int sSysNo = AppConst.IntNull;
                        if (srwye == null)
                        {
                            sSysNo = new SCENIC_RWYDac().Add(sRWY);
                        }
                        #endregion
                        if (sScenic.Contains("ticketList"))
                        {
                            JsonData jdTicketList = mScenic["ticketList"];
                            if (jdTicketList.Count > 0)
                            {
                                foreach (JsonData mTicket in jdTicketList)
                                {
                                    j++;
                                    if(j == 100)
                                    {

                                    }
                                    #region 门票
                                    string[] sTicket = mTicket.Inst_Object.Keys.ToArray();

                                    string RWYTicketID = Convert.ToString(mTicket["id"]);
                                    string TicketName = Convert.ToString(mTicket["name"]);
                                    string mScenicID = Convert.ToString(mTicket["scenicId"]);
                                    string TicketStatus = Convert.ToString(mTicket["status"]);
                                    string TicketDescription = Convert.ToString(mTicket["description"]);
                                    string TicketEndOfTime = Convert.ToString(mTicket["endOfTime"]);
                                    string TicketNotice = Convert.ToString(mTicket["notice"]);
                                    string TicketOrderAdvanceHours = Convert.ToString(mTicket["orderAdvanceHours"]);
                                    string TicketOrderAdvanceDays = Convert.ToString(mTicket["orderAdvanceDays"]);
                                    string TicketOrderBeforeHour = Convert.ToString(mTicket["orderBeforeHour"]);
                                    string TicketOrderBeforeMin = Convert.ToString(mTicket["orderBeforeMin"]);
                                    string TicketMaxOrderAdvanceDays = Convert.ToString(mTicket["maxOrderAdvanceDays"]);
                                    string TicketRefundAdvanceHours = Convert.ToString(mTicket["refundAdvanceHours"]);
                                    string TicketUseAdvanceHours = Convert.ToString(mTicket["useAdvanceHours"]);
                                    string TicketAdditionaIInfo = string.Empty;
                                    if (sTicket.Contains("additionalInfo"))
                                    {
                                        TicketAdditionaIInfo = Convert.ToString(mTicket["additionalInfo"]);
                                    }
                                    string TicketEffectiveDate = Convert.ToString(mTicket["effectiveDate"]);
                                    string TicketValidWeeks = string.Empty;
                                    if (sTicket.Contains("validWeeks"))
                                    {
                                        TicketValidWeeks = Convert.ToString(mTicket["validWeeks"]);
                                    }
                                    string TicketValidDates = string.Empty;
                                    if (sTicket.Contains("validDates"))
                                    {
                                        TicketValidDates = Convert.ToString(mTicket["validDates"]);
                                    }
                                    string TicketInvalidDates = string.Empty;
                                    if (sTicket.Contains("invalidDates"))
                                    {
                                        TicketInvalidDates = Convert.ToString(mTicket["invalidDates"]);
                                    }
                                    string TicketIsInvtLimit = Convert.ToString(mTicket["isInvtLimit"]);
                                    string TicketMaxOrderNum = Convert.ToString(mTicket["maxOrderNum"]);
                                    string TicketMinOrderNum = Convert.ToString(mTicket["minOrderNum"]);
                                    string TicketPriceType = Convert.ToString(mTicket["priceType"]);
                                    string TicketImgUrl = string.Empty;
                                    if (sTicket.Contains("imgUrl"))
                                    {
                                        TicketImgUrl = Convert.ToString(mTicket["imgUrl"]);
                                    }
                                    string TicketScenicName = Convert.ToString(mTicket["scenicName"]);
                                    string TicketSalePrice = Convert.ToString(mTicket["salePrice"]);
                                    string TicketSuggestPrice = string.Empty;
                                    if (sTicket.Contains("suggestPrice"))
                                    {
                                        TicketSuggestPrice = Convert.ToString(mTicket["suggestPrice"]);
                                    }
                                    string TicketMarketPrice = Convert.ToString(mTicket["marketPrice"]);
                                    string TicketLimitPrice = Convert.ToString(mTicket["limitPrice"]);
                                    string TicketEbonus = Convert.ToString(mTicket["ebonus"]);
                                    string TicketStartDateFlag = Convert.ToString(mTicket["startDateFlag"]);
                                    string TicketIsRealName = Convert.ToString(mTicket["isRealName"]);
                                    string TicketScenicStatus = Convert.ToString(mTicket["scenicStatus"]);
                                    string TicketIsSaleAlone = Convert.ToString(mTicket["isSaleAlone"]);
                                    string TicketIdCardNeeded = Convert.ToString(mTicket["idCardNeeded"]);
                                    string TicketIdCardAccepted = Convert.ToString(mTicket["idCardAccepted"]);
                                    TICKET_RWYEntity tRWY = new TICKET_RWYEntity();
                                    tRWY.TicketId = RWYTicketID;
                                    tRWY.Name = TicketName;
                                    tRWY.ScenicId = ScenicID;
                                    tRWY.Status = TicketStatus;
                                    tRWY.Description = TicketDescription;
                                    tRWY.EndOfTime = TicketEndOfTime;
                                    tRWY.Notice = TicketNotice;
                                    tRWY.OrderAdvanceHours = TicketOrderAdvanceHours;
                                    tRWY.OrderAdvanceDays = TicketOrderAdvanceDays;
                                    tRWY.OrderBeforeHour = TicketOrderBeforeHour;
                                    tRWY.OrderBeforeMin = TicketOrderBeforeMin;
                                    tRWY.MaxOrderAdvanceDays = TicketMaxOrderAdvanceDays;
                                    tRWY.RefundAdvanceHours = TicketRefundAdvanceHours;
                                    tRWY.UseAdvanceHours = TicketUseAdvanceHours;
                                    tRWY.AdditionalInfo = TicketAdditionaIInfo;
                                    tRWY.EffectiveDate = TicketEffectiveDate;
                                    tRWY.ValidWeeks = TicketValidWeeks;
                                    tRWY.ValidDates = TicketValidDates;
                                    tRWY.InvalidDates = TicketInvalidDates;
                                    tRWY.IsInvtLimit = TicketIsInvtLimit;
                                    tRWY.MaxOrderNum = TicketMaxOrderNum;
                                    tRWY.MinOrderNum = TicketMinOrderNum;
                                    tRWY.ImgUrl = TicketImgUrl;
                                    tRWY.SalePrice = TicketSalePrice;
                                    tRWY.SuggestPrice = TicketSuggestPrice;
                                    tRWY.MarketPrice = TicketMarketPrice;
                                    TICKET_RWYEntity trwyt = new TICKET_RWYDac().GetModelByRWYTicketID(RWYTicketID);
                                    if (trwyt == null)
                                    {
                                        int tSysNo = new TICKET_RWYDac().Add(tRWY);
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("X:{0} Y:{1} ",i,j) + ex.Message);
                return;
            }
            MessageBox.Show("完成");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showImage();
            return;
            string fileUrl = "|main|2013-09-23|1379929147505.jpg";
            //string fileString = fileUrl.Replace("|", "\\");
            string fileUrl_300 = @"http://test.zmyou.com/union/display-image?filename=" + fileUrl + "&scale=medium";
            string fileUrl_120 = @"http://test.zmyou.com/union/display-image?filename=" + fileUrl + "&scale=small";
            string newFileName_300 = string.Format("{0}_{1}", Guid.NewGuid(), DateTime.Now.ToString("yyyyMMddHHmmss")) + Path.GetExtension(fileUrl.Replace("|", "\\"));//Path.GetExtension(myFile.FileName);   //新文件名---组成形式：  GUID + 下划线 + 原文件名
            string extensionName = Path.GetExtension(newFileName_300);//扩展名
            string yFileName = Path.GetFileName(newFileName_300);//原文件名
            string newFileUrl_300 = @"D:\Image\" + Path.GetFileNameWithoutExtension(newFileName_300) + extensionName; //yFileName;
            string newFileUrl_150 = @"D:\Image\" + Path.GetFileNameWithoutExtension(newFileName_300) + "(150_150)" + extensionName;
            string newFileUrl_120 = @"D:\Image\" + Path.GetFileNameWithoutExtension(newFileName_300) + "(120_120)" + extensionName;
            if (!Directory.Exists(@"D:\Image"))
            {
                Directory.CreateDirectory(@"D:\Image");
            }
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(fileUrl_300, newFileUrl_300);

            ImageCutter m_ic = new ImageCutter();
            m_ic.ToThumbnailImages(newFileUrl_300, newFileUrl_150, 150, 150);

            myWebClient.DownloadFile(fileUrl_120, newFileUrl_120);
            return;
            string newFileUrl_380 = @"D:\Image\" + yFileName + "(380_280)" + extensionName;
            string newFileUrl_100 = @"D:\Image\" + yFileName + "(100_100)" + extensionName;
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_IMAGE");
            sParam.Add("id", 300042);//景区ID
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            if (Convert.ToString(jdMessage[0]) == "ok")
            {
                JsonData jdImageList = JsonMapper.ToObject(jdMessage[1].ToString());
                foreach (JsonData sImage in jdImageList)
                {
                    string sImageUrl = Convert.ToString(sImage);
                    string fileUrl_380 = @"http://test.zmyou.com/union/display-image?filename=" + sImageUrl + "&scale=medium";
                    string fileUrl_100 = @"http://test.zmyou.com/union/display-image?filename=" + sImageUrl + "&scale=small";
                    extensionName = Path.GetExtension(sImageUrl);//扩展名
                    yFileName = Path.GetFileName(sImageUrl);//原文件名
                    myWebClient.DownloadFile(fileUrl_380, newFileUrl_380);
                    myWebClient.DownloadFile(fileUrl_100, newFileUrl_100);

                }
            }
        }

        private void showImage()
        {
            string bigImgName_300 = "123_20140529230057" + ".jpg";//vendorSysNo.ToString() + "_" + createTime.ToString("yyyyMMddHHmmss") + "(800_600).jpg";
            string fileUrl = "|main|2013-09-23|1379929147505.jpg";
            string fileUrl_300 = @"http://test.zmyou.com/union/display-image?filename=" + fileUrl + "&scale=medium";
            string fileUrl_120 = @"http://test.zmyou.com/union/display-image?filename=" + fileUrl + "&scale=small";
            string extensionName = Path.GetExtension(bigImgName_300);//扩展名
            string yFileName = Path.GetFileNameWithoutExtension(bigImgName_300);//原文件名
            string newFileUrl_300 = @"D:\Image\" + bigImgName_300;
            string newFileUrl_150 = @"D:\Image\" + yFileName + "(150_150)" + extensionName;
            string newFileUrl_120 = @"D:\Image\" + yFileName + "(120_120)" + extensionName;
            if (!Directory.Exists(@"D:\Image"))
            {
                Directory.CreateDirectory(@"D:\Image");
            }
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(fileUrl_300, newFileUrl_300);

            ImageCutter m_ic = new ImageCutter();
            m_ic.ToThumbnailImages(newFileUrl_300, newFileUrl_150, 150, 150);

            myWebClient.DownloadFile(fileUrl_120, newFileUrl_120);

            string newFileUrl_380 = string.Empty;// @"D:\Image\" + yFileName + "(380_280)" + extensionName;
            string newFileUrl_100 = string.Empty;//@"D:\Image\" + yFileName + "(100_100)" + extensionName;
            string sUrl = ConfigurationManager.AppSettings["url"];
            SortedList sParam = new SortedList();
            sParam.Add("action", "GET_SCENIC_IMAGE");
            sParam.Add("id", 300042);//景区ID
            string sBody = JsonMapper.ToJson(sParam);
            string sPostData = GetPostData(sBody);
            string sMessage = PostByHttpRequest(sPostData, sUrl);
            JsonData jdMessage = JsonMapper.ToObject(sMessage);
            if (Convert.ToString(jdMessage[0]) == "ok")
            {
                JsonData jdImageList = JsonMapper.ToObject(jdMessage[1].ToString());
                foreach (JsonData sImage in jdImageList)
                {
                    string sImageUrl = Convert.ToString(sImage);
                    string fileUrl_380 = @"http://test.zmyou.com/union/display-image?filename=" + sImageUrl + "&scale=medium";
                    string fileUrl_100 = @"http://test.zmyou.com/union/display-image?filename=" + sImageUrl + "&scale=small";
                    extensionName = Path.GetExtension(sImageUrl);//扩展名
                    yFileName = Path.GetFileName(sImageUrl);//原文件名
                    string sDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    newFileUrl_380 = @"D:\Image\" + "123_" + sDateTime + "(380_280)" + extensionName;// @"D:\Image\" + yFileName + "(380_280)" + extensionName;
                    newFileUrl_100 = @"D:\Image\" + "123_" + sDateTime + "(100_100)" + extensionName;//@"D:\Image\" + yFileName + "(100_100)" + extensionName;
                    
                    myWebClient.DownloadFile(fileUrl_380, newFileUrl_380);
                    myWebClient.DownloadFile(fileUrl_100, newFileUrl_100);

                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<SCENIC_RWYEntity> list = new SCENIC_RWYDac().GetList();
        }

        //测试
        private void button11_Click(object sender, EventArgs e)
        {
            //string mUrl = @"http://api.kuaidi100.com/api?id=8629367966bebb4d&com=jd&nu=vb06758489975";
            //string mParam = @"";
            //string mMessage = PostData(mParam, mUrl);
            string mMessage = @" {'nu':'VB06758489975','comcontact':'400-603-3600','companytype':'jd','com':'jd','signname':'','condition':'F00','status':'1','codenumber':'VB06758489975','data':[{'time':'2015-09-02 11:32:50','location':'','context':'货物已完成配送，感谢您选择京东配送'},{'time':'2015-09-02 08:06:43','location':'','context':'配送员开始配送，请您准备收货，配送员，程战战，手机号，18721462986'},{'time':'2015-09-02 06:36:51','location':'','context':'货物已分配，等待配送'},{'time':'2015-09-02 06:36:50','location':'','context':'货物已分配，等待配送'},{'time':'2015-09-02 00:28:47','location':'','context':'货物已到达【金杨站】'},{'time':'2015-09-02 00:28:46','location':'','context':'货物已到达【金杨站】'},{'time':'2015-09-01 22:06:21','location':'','context':'货物已完成分拣，离开【上海浦东分拨中心】'},{'time':'2015-09-01 22:06:21','location':'','context':'货物已完成分拣，离开【上海浦东分拨中心】'},{'time':'2015-09-01 22:03:24','location':'','context':'货物已到达【上海浦东分拨中心】'},{'time':'2015-09-01 22:03:24','location':'','context':'货物已到达【上海浦东分拨中心】'},{'time':'2015-09-01 19:49:50','location':'','context':'货物已完成分拣，离开【苏州外单分拣中心】'},{'time':'2015-09-01 19:48:05','location':'','context':'货物已到达【苏州外单分拣中心】'},{'time':'2015-09-01 19:46:50','location':'','context':'货物已到达【苏州外单分拣中心】'},{'time':'2015-09-01 19:46:50','location':'','context':'货物已到达【苏州外单分拣中心】'},{'time':'2015-09-01 15:26:30','location':'','context':'货物已交付京东快递'}],'signedtime':'','state':'3','addressee':'','departure':'','destination':'','message':'ok','ischeck':'1','pickuptime':'','comurl':'http://www.jd-ex.com'} ";
            JObject jo = (JObject)JsonConvert.DeserializeObject(mMessage);
            string status = jo["status"].ToString().Replace("\"", "");//查询结果状态 0：物流单暂无结果， 1：查询成功， 2：接口出现异常，
            if (status == "1")
            {
                string company = jo["com"].ToString().Replace("\"", ""); //快递公司代码
                string packageID = jo["nu"].ToString().Replace("\"", ""); ;     //单号
                string state = jo["state"].ToString().Replace("\"", "").ToLower();//快递单当前的状态 
                string content = "";
                if (jo["data"] != null)
                {
                    int k = (jo["data"]).AsEnumerable().Count();
                    for (int i = k - 1; i > -1; i--)
                    {
                        content += jo["data"][i]["time"].ToString().Replace("\"", "") + "   ";
                        content += jo["data"][i]["context"].ToString().Replace("\"", "") + "<br/>";
                    }
                }
            }
            else
            {
                //调用接口失败，记录日志含请求参数
            }
            return;
            //string state = jo["lastResult"]["state"].ToString().Replace("\"", ""); //状态 
            //string company = jo["lastResult"]["com"].ToString().Replace("\"", ""); //快递公司代码
            //string packageID = jo["lastResult"]["nu"].ToString().Replace("\"", ""); ;     //单号
            //string status = jo["status"].ToString().Replace("\"", "").ToLower();

            string sUrl = ConfigurationManager.AppSettings["tUrl"] + "?keysysno=2150901154458060&expressno=3100048966847";
            //string sParam = "u=api_test&p=c4ca4238a0b923820dcc509a6f75849b&body={\"action\":\"GET_PROVINCE\"}&sign=318c3eb16d844c1bbe77f117303a6359";
            //string sMessage = PostByHttpRequest1(sParam, sUrl);

            //StringBuilder signSB = new StringBuilder();
            //SortedList sl = new SortedList();
            //sl.Add("u", "api_test");
            //sl.Add("p", "c4ca4238a0b923820dcc509a6f75849b");
            ////sl.Add("sign", "318c3eb16d844c1bbe77f117303a6359");
            //sl.Add("body", "{\"id\":110100,\"action\":\"GET_DISTRICT\"}");
            //signSB.Append(sl["u"]).Append(sl["p"]).Append(sl["body"]).Append("ot7M30XwoGL35IOl");
            //string f = Util.GetMD5(signSB.ToString()).ToLower();//3ea9642414849e70a5eea37621444dd2
            //string sParam = "u=api_test&p=c4ca4238a0b923820dcc509a6f75849b&body={\"id\":110100,\"action\":\"GET_DISTRICT\"}&sign=" + f;
            string sParam = @"{ 'sign':'223','param':'{'message':'','status':'shutdown','lastResult':{'message':'ok','state':'3','data':[{'context':'浦东金桥二部 派件已 签收 ,签收人是 拍照签收 查看图片','time':'2013-07-24 11:52:38','ftime':'2013-07-24 11:52:38'},{'context':'浦东金桥二部  新金桥大厦 正在派件','time':'2013-07-24 08:19:51','ftime':'2013-07-24 08:19:51'},{'context':'快件到达 浦东金桥二部 ,正在分捡中,上一站是 上海','time':'2013-07-24 01:14:22','ftime':'2013-07-24 01:14:22'},{'context':'快件离开 上海 ,已发往 浦东金桥二部','time':'2013-07-23 23:48:35','ftime':'2013-07-23 23:48:35'},{'context':'所在包 到达 上海','time':'2013-07-23 23:39:12','ftime':'2013-07-23 23:39:12'},{'context':'快件到达 上海 ,正在分捡中,上一站是 上海','time':'2013-07-23 23:38:23','ftime':'2013-07-23 23:38:23'},{'context':'快件已经在在 天津中转部  装包并发往  上海','time':'2013-07-22 22:04:54','ftime':'2013-07-22 22:04:54'},{'context':'快件离开 天津中转部 ,已发往 上海','time':'2013-07-22 20:03:06','ftime':'2013-07-22 20:03:06'},{'context':'快件已经在在 天津中转部  装包并发往  上海','time':'2013-07-22 20:02:39','ftime':'2013-07-22 20:02:39'},{'context':'快件到达 天津中转部 ,正在分捡中,上一站是 天津东丽南部','time':'2013-07-22 19:56:54','ftime':'2013-07-22 19:56:54'},{'context':'天津东丽南部  淘宝 已收件,进入公司分捡','time':'2013-07-22 18:08:04','ftime':'2013-07-22 18:08:04'},{'context':'天津东丽南部  淘宝 已收件,进入公司分捡','time':'2013-07-22 15:56:12','ftime':'2013-07-22 15:56:12'}],'status':'200','com':'zhongtong','nu':'738000887615','ischeck':'1','condition':'F00'},'billstatus':'check'}' }";
            string sMessage = PostData(sParam, sUrl);


            //JsonData jd = JsonMapper.ToObject(sMessage);
            //StringBuilder sb = new StringBuilder();
            //StringBuilder signSB = new StringBuilder();
            //SortedList sl = new SortedList();
            //sl.Add("u", "api_test");
            //sl.Add("p", "c4ca4238a0b923820dcc509a6f75849b");
            ////sl.Add("sign", "318c3eb16d844c1bbe77f117303a6359");
            //sl.Add("body", "{\"action\":\"GET_PROVINCE\"}");
            //signSB.Append(sl["u"]).Append(sl["p"]).Append(sl["body"]).Append("ot7M30XwoGL35IOl");
            //string f = Util.GetMD5(signSB.ToString()).ToLower();
            //int i = 0;
            //foreach (string key in sl.Keys)
            //{
            //    if (i == 0)
            //    {
            //        sb.Append(key).Append("=").Append(sl[key].ToString());
            //    }
            //    else
            //    {
            //        sb.Append("&").Append(key).Append("=").Append(sl[key].ToString());
            //    }
            //    i++;
            //}
            //sb.Append("&").Append("body").Append("=").Append("{\"action\":\"GET_PROVINCE\"}");
        }

        public string PostData(string param,string url)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(param.Trim());
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url.Trim());
            req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";
            req.ContentType = "application/json";

            req.ContentLength = data.Length;

            System.IO.Stream newStream = req.GetRequestStream();
            //发送数据   
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();  
        }
             
    }
}
