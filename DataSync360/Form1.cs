using allinpay.O2O.Cmn;
using DataSync360.DAL;
using DataSync360.Model;
using LitJson;
using System;
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

namespace DataSync360
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //360分类数据导入
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string sMessage = PostByHttpRequest("", ConfigurationManager.AppSettings["APICategory"]);// ConfigurationManager.AppSettings["APICategory"];
            JsonData jd = JsonMapper.ToObject(sMessage);
            int status = 0;
            DateTime lasthUpdateTime = DateTime.Now;
            for (int i = 0; i < jd.Count; i++)
            {
                JsonData jdItem = jd[i];
                if (Convert.ToString(jdItem["name"]) == "网上购物")
                {
                    continue;
                }
                //string C1cateid = Convert.ToString(jdItem["cateid"]);
                //string C1name = Convert.ToString(jdItem["name"]);
                //string C1alias = Convert.ToString(jdItem["alias"]);
                //string C1isred = Convert.ToString(jdItem["isred"]);
                //string C1isnew = Convert.ToString(jdItem["isnew"]);
                //string C1minihot = Convert.ToString(jdItem["minihot"]);
                //string C1minired = Convert.ToString(jdItem["minired"]);
                Category_360Entity tceC1 = ReturnCategory(jdItem, 1);
                tceC1.Status = status;
                tceC1.LastUpdateTime = lasthUpdateTime;
                //插入一级类别
                int C1SysNo = new Category_360Dac().AddNew(tceC1);
                if (jdItem.Count > 7)
                {
                    JsonData jdSons = jdItem[7];
                    for (int j = 0; j < jdSons.Count; j++)
                    {
                        JsonData jdSon = jdSons[j];
                        //string C2cateid = Convert.ToString(jdSon["cateid"]);
                        //string C2name = Convert.ToString(jdSon["name"]);
                        //string C2alias = Convert.ToString(jdSon["alias"]);
                        //string C2isred = Convert.ToString(jdSon["isred"]);
                        //string C2isnew = Convert.ToString(jdSon["isnew"]);
                        //string C2minihot = Convert.ToString(jdSon["minihot"]);
                        //string C2minired = Convert.ToString(jdSon["minired"]);
                        Category_360Entity tceC2 = ReturnCategory(jdSon, 2);
                        tceC2.C1SysNo = C1SysNo;
                        tceC2.C1Name = tceC1.C1Name;
                        tceC2.APIName = tceC1.APIName;
                        tceC2.Status = status;
                        tceC2.LastUpdateTime = lasthUpdateTime;
                        //插入二级类别
                        int C2SysNo = new Category_360Dac().AddNew(tceC2);
                        if (jdSon.Count > 7)
                        {
                            JsonData jdSonSons = jdSon[7];
                            for (int k = 0; k < jdSonSons.Count; k++)
                            {
                                JsonData jdSonSonsSon = jdSonSons[k];
                                //string C3cateid = Convert.ToString(jdSonSonsSon["cateid"]);
                                //string C3name = Convert.ToString(jdSonSonsSon["name"]);
                                //string C3alias = Convert.ToString(jdSonSonsSon["alias"]);
                                //string C3isred = Convert.ToString(jdSonSonsSon["isred"]);
                                //string C3isnew = Convert.ToString(jdSonSonsSon["isnew"]);
                                //string C3minihot = Convert.ToString(jdSonSonsSon["minihot"]);
                                //string C3minired = Convert.ToString(jdSonSonsSon["minired"]);
                                Category_360Entity tceC3 = ReturnCategory(jdSonSonsSon, 3);
                                tceC3.C1SysNo = C1SysNo;
                                tceC3.C1Name = tceC1.C1Name;
                                tceC3.APIName = tceC1.APIName;
                                tceC3.C2SysNo = C2SysNo;
                                tceC3.C2Name = tceC2.C2Name;
                                tceC3.Status = 0;
                                tceC3.LastUpdateTime = lasthUpdateTime;
                                //插入三级类别
                                int C3SysNo = new Category_360Dac().AddNew(tceC3);
                                //if (jdSonSonsSon.Count > 7)//不要购物 不要四级
                                //{
                                //    JsonData jdSonSonsSonSons = jdSonSonsSon[7];
                                //    for (int z = 0; z < jdSonSonsSonSons.Count; z++)
                                //    {
                                //        JsonData jdSonSonsSonSonsSon = jdSonSonsSonSons[z];
                                //        Category_360Entity tceC4 = ReturnCategory(jdSonSonsSonSonsSon, 4);
                                //        tceC4.C1SysNo = C1SysNo;
                                //        tceC4.C1Name = tceC1.C1Name;
                                //        tceC4.APIName = tceC1.APIName;
                                //        tceC4.C2SysNo = C2SysNo;
                                //        tceC4.C2Name = tceC2.C2Name;
                                //        tceC4.C3SysNo = C3SysNo;
                                //        tceC4.C3Name = tceC3.C3Name;
                                //        //插入四级类别
                                //        int C4SysNo = new Category_360Dac().Add(tceC4);
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("导入成功！");
        }

        //360区域数据导入
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string sMessageC = PostByHttpRequest("", ConfigurationManager.AppSettings["APICity"]);
            JsonData jdC = JsonMapper.ToObject(sMessageC);
            DateTime lasthUpdateTime = DateTime.Now;
            for (int i = 0; i < jdC.Count; i++)
            {
                JsonData jdCZM = jdC[i];
                for (int j = 0; j < jdCZM.Count; j++)
                {
                    JsonData jdCItem = jdCZM[j];
                    string cityName = Convert.ToString(jdCItem["name"]);
                    string cityCode = Convert.ToString(jdCItem["code"]);
                    string cityHotrank = Convert.ToString(jdCItem["hotrank"]);
                    //插入城市数据
                    Area_360Entity Ctae = new Area_360Entity();
                    Ctae.Code = cityCode;
                    Ctae.CityName = cityName;
                    Ctae.Hatrank = Convert.ToInt32(cityHotrank);
                    Ctae.Status = 0;
                    Ctae.LastUpdateTime = lasthUpdateTime;
                    int CsysNo = new Area_360Dac().AddNew(Ctae);
                    //下面是区县商圈数据
                    string sURL = "";
                    string sMessageD = "";
                    try
                    {
                        //
                        sURL = string.Format(ConfigurationManager.AppSettings["APIQXSQ"].Replace('#','&'), cityCode);//"http://tuan.360.cn/api/open_locality.php?city=" + cityCode + "&format=json"
                        sMessageD = PostByHttpRequest("", sURL);
                    }
                    catch (Exception ex)
                    {
                        sURL = string.Format(ConfigurationManager.AppSettings["APIQXSQ"].Replace('#', '&'), cityCode);//"http://tuan.360.cn/api/open_locality.php?city=" + cityCode + "&format=json"
                        sMessageD = PostByHttpRequest("", sURL);
                    }
                    if (sMessageD.Trim() == "false")
                    {
                        continue;
                    }
                    JsonData jdD = JsonMapper.ToObject(sMessageD);
                    for (int M = 0; M < jdD.Count; M++)
                    {
                        JsonData jdDItem = jdD[M];
                        int DCount = jdDItem.Count;
                        int DSysNo = AppConst.IntNull;
                        string districtClassid = AppConst.StringNull;
                        string districtName = AppConst.StringNull;
                        if (DCount >= 2)
                        {
                            districtClassid = Convert.ToString(jdDItem["classid"]);
                            districtName = Convert.ToString(jdDItem["name"]);
                            //插入区县数据
                            Area_360Entity Dtae = new Area_360Entity();
                            Dtae.CitySysNo = CsysNo;
                            Dtae.Code = cityCode;
                            Dtae.CityName = cityName;
                            Dtae.DistrictName = districtName;
                            Dtae.Classid = Convert.ToInt32(districtClassid);
                            Dtae.Status = 0;
                            Dtae.LastUpdateTime = lasthUpdateTime;
                            DSysNo = new Area_360Dac().AddNew(Dtae);
                            if (DCount == 2)
                            {
                                continue;
                            }
                        }
                        if (jdDItem.Count <= DCount - 1)
                        {
                            continue;
                        }
                        JsonData jdZSons = jdDItem[DCount - 1];
                        for (int N = 0; N < jdZSons.Count; N++)
                        {
                            JsonData jdZSon = jdZSons[N];
                            string zoneClassid = Convert.ToString(jdZSon["classid"]);
                            string zoneName = Convert.ToString(jdZSon["name"]);
                            //插入商圈数据
                            Area_360Entity Ztae = new Area_360Entity();
                            Ztae.CitySysNo = CsysNo;
                            Ztae.DistrictSysNo = DSysNo;
                            Ztae.Code = cityCode;
                            Ztae.CityName = cityName;
                            Ztae.DistrictName = districtName;
                            Ztae.ZoneName = zoneName;
                            Ztae.Classid = Convert.ToInt32(zoneClassid);
                            Ztae.Status = 0;
                            Ztae.LastUpdateTime = lasthUpdateTime;
                            int ZSysNo = new Area_360Dac().AddNew(Ztae);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("导入成功！");
        }

        public string PostByHttpRequest(string str, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
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

        public Category_360Entity ReturnCategory(JsonData jsonData, int level)
        {
            Category_360Entity Entity = new Category_360Entity();
            string cateid = Convert.ToString(jsonData["cateid"]);
            string name = Convert.ToString(jsonData["name"]);
            string alias = Convert.ToString(jsonData["alias"]);
            string isred = Convert.ToString(jsonData["isred"]);
            string isnew = Convert.ToString(jsonData["isnew"]);
            string minihot = Convert.ToString(jsonData["minihot"]);
            string minired = Convert.ToString(jsonData["minired"]);
            Entity.Cateid = Convert.ToInt32(cateid);
            Entity.Alias = alias;
            Entity.Isred = Convert.ToInt32(isred);
            Entity.Isnew = Convert.ToInt32(isnew);
            Entity.Minihot = Convert.ToInt32(minihot);
            Entity.Minired = Convert.ToInt32(minired);
            if (level == 1)
            {
                if (!string.IsNullOrEmpty(alias))
                {
                    Entity.C1Name = alias;
                }
                else
                {
                    Entity.C1Name = name;
                }
                Entity.APIName = name;
            }
            else if (level == 2)
            {
                Entity.C2Name = name;
            }
            else if (level == 3)
            {
                Entity.C3Name = name;
            }
            //else//不要购物不要四级
            //{
            //    Entity.C4Name = name;
            //}
            Entity.APINameEnd = name;
            return Entity;
        }
    }
}
