using allinpay.O2O.Cmn;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestAPI.DAL;
using TestAPI.Model;

namespace TestAPI
{
    public partial class Tuan_Area : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string PostByHttpRequest(string str,string url)
        {
            //ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
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

        //360城市数据
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sMessage = PostByHttpRequest("", "http://tuan.360.cn/api/open_citys.php?format=json");
            JsonData jd = JsonMapper.ToObject(sMessage);
            for (int i = 0; i < jd.Count;i++ )
            {
                JsonData jdZM = jd[i];
                for (int j = 0; j < jdZM.Count;j++ )
                {
                    JsonData jdItem = jdZM[j];
                    string cityName = Convert.ToString(jdItem["name"]);
                    string cityCode = Convert.ToString(jdItem["code"]);
                    string cityHotrank = Convert.ToString(jdItem["hotrank"]);
                    //插入城市数据
                    Area_360Entity Ctae = new Area_360Entity();
                    Ctae.Code = cityCode;
                    Ctae.CityName = cityName;
                    Ctae.Hatrank = Convert.ToInt32(cityHotrank);
                    Ctae.Status = 0;
                    Ctae.LastUpdateTime = DateTime.Now;
                    int CsysNo = new Area_360Dac().Add(Ctae);

                }
            }
            Response.Write("成功");
        }

        //360区县商圈
        protected void Button2_Click(object sender, EventArgs e)
        {
            string sURL = "http://tuan.360.cn/api/open_locality.php?city=" + "nan_jing" + "&format=json";
            string sMessage = PostByHttpRequest("", sURL);
            JsonData jd = JsonMapper.ToObject(sMessage);
            for (int i = 0; i < jd.Count;i++ )
            {
                JsonData jdItem = jd[i];
                string districtClassid = Convert.ToString(jdItem["classid"]);
                string districtName = Convert.ToString(jdItem["name"]);
                //插入区县数据
                Area_360Entity Dtae = new Area_360Entity();
                Dtae.CitySysNo = 184;
                Dtae.Code = "nan_jing";
                Dtae.CityName = "南京";
                Dtae.DistrictName = districtName;
                Dtae.Classid = Convert.ToInt32(districtClassid);
                Dtae.Status = 0;
                Dtae.LastUpdateTime = DateTime.Now;
                int DSysNo = new Area_360Dac().Add(Dtae);
                JsonData jdSons = jdItem[2];
                for (int j = 0; j < jdSons.Count; j++)
                {
                    JsonData jdSon = jdSons[j];
                    string zoneClassid = Convert.ToString(jdSon["classid"]);
                    string zoneName = Convert.ToString(jdSon["name"]);
                    //插入商圈数据
                    Area_360Entity Ztae = new Area_360Entity();
                    Ztae.CitySysNo = 184;
                    Ztae.DistrictSysNo = DSysNo;
                    Ztae.Code = "nan_jing";
                    Ztae.CityName = "南京";
                    Ztae.DistrictName = districtName;
                    Ztae.ZoneName = zoneName;
                    Ztae.Classid = Convert.ToInt32(zoneClassid);
                    Ztae.Status = 0;
                    Ztae.LastUpdateTime = DateTime.Now;
                    int ZSysNo = new Area_360Dac().Add(Ztae);
                }
            }
            Response.Write("成功");
        }

        //360分类数据
        protected void Button3_Click(object sender, EventArgs e)
        {
            string sMessage = PostByHttpRequest("", "http://api.tuan.360.cn/open_category.php?format=json");
            JsonData jd = JsonMapper.ToObject(sMessage);
            int status = 0;
            DateTime lasthUpdateTime = DateTime.Now;
            for (int i = 0; i < jd.Count;i++ )
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
                int C1SysNo = new Category_360Dac().Add(tceC1);
                if(jdItem.Count > 7)
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
                        int C2SysNo = new Category_360Dac().Add(tceC2);
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
                                int C3SysNo = new Category_360Dac().Add(tceC3);
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
            Response.Write("成功");
        }

        public Category_360Entity ReturnCategory(JsonData jsonData,int level)
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
            if(level == 1)
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

        //360区域数据整体导入
        protected void Button4_Click(object sender, EventArgs e)
        {
            string sMessageC = PostByHttpRequest("", "http://tuan.360.cn/api/open_citys.php?format=json");
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
                    int CsysNo = new Area_360Dac().Add(Ctae);
                    //下面是区县商圈数据
                    string sURL = "";
                    string sMessageD = "";
                    try
                    {
                        sURL = "http://tuan.360.cn/api/open_locality.php?city=" + cityCode + "&format=json";
                        sMessageD = PostByHttpRequest("", sURL);
                    }
                    catch (Exception ex)
                    {
                        sURL = "http://tuan.360.cn/api/open_locality.php?city=" + cityCode + "&format=json";
                        sMessageD = PostByHttpRequest("", sURL);
                    }
                    if(sMessageD.Trim() == "false")
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
                            DSysNo = new Area_360Dac().Add(Dtae);
                            if (DCount == 2)
                            {
                                continue;
                            }
                        }
                        if (jdDItem.Count <= DCount-1)
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
                            int ZSysNo = new Area_360Dac().Add(Ztae);
                        }
                    }
                }
            }
            Response.Write("成功");
        }
    }
}