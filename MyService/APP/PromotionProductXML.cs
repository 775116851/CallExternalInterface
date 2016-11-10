using allinpay.O2O.Cmn;
using MyService.ebThread;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace MyService.APP
{
    public class PromotionProductXML : EBThread
    {
        //private ILog _log = log4net.LogManager.GetLogger(typeof(PromotionProductXML));
        public override void run()
        {
            while (true)
            {
                try
                {
                    try
                    {
                        //string UploadFilePath = @"\\192.168.101.193\pic";
                        //string FarDeskPwd = @"123456";
                        //string FarDeskUser = @"allinpay\luzh";
                        //System.Diagnostics.Process.Start("net.exe", @"use " + AppConfig.UploadFilePath + " " + AppConfig.FarDeskPwd + " /user:" + AppConfig.FarDeskUser);
                        //System.Diagnostics.Process.Start("net.exe", @"use " + UploadFilePath + " " + FarDeskPwd + " /user:" + FarDeskUser);
                        //System.Diagnostics.Process.Start("net.exe", @"use \\192.168.101.193\pic 123456 /user:allinpay\luzh");
                        //EventLog.WriteEntry("A", "到这了");
                        SaveXML();
                        //EventLog.WriteEntry("D", "到这了");
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("M", ex.Message);
                    }
                    Thread.Sleep(12000);      //挂起五分钟再执行  120000
                }
                catch (Exception ee)
                {
                }
            }

        }

        public void SaveXML()
        {
            XmlDocument xd = new XmlDocument();//表示XML文档  

            XmlDeclaration xde;
            xde = xd.CreateXmlDeclaration("1.0", "utf-8", null);
            xd.AppendChild(xde);
            XmlElement xedata = xd.CreateElement("data");
            xd.AppendChild(xedata);
            //XmlNode root = xd.SelectSingleNode("data");
            bind(xd, xedata, "time", DateTime.Now.ToString());//新增服务测试
            bind(xd, xedata, "apiversion", "4.0");//新增
            bind(xd, xedata, "site_name", "测试团");
            XmlElement xeGoodsData = xd.CreateElement("goodsdata");
            //开始for循环A goods
            XmlElement xeGoods = xd.CreateElement("goods");
            xeGoods.SetAttribute("id", "1");
            bind(xd, xeGoods, "pid", "3779");
            bind(xd, xeGoods, "feature", "新疆阿克苏6星级红枣");//非必填
            bind(xd, xeGoods, "city_name", "全国");
            bind(xd, xeGoods, "site_url", "http://t.dqccc.com");
            bind(xd, xeGoods, "title", "仅19元抢购新疆阿克苏6星级红枣");
            bind(xd, xeGoods, "short_title", "仅19元抢购新疆阿克苏6星级红枣");//新增
            bind(xd, xeGoods, "bigimg_url", "http://t.dqccc.com/bendi/detail.aspx?pagename=hongzao001");//新增
            bind(xd, xeGoods, "goods_url", "http://t.dqccc.com/bendi/detail.aspx?pagename=hongzao001");
            bind(xd, xeGoods, "desc", "仅19元，抢购原价68元新疆阿克苏6星级红枣500g/袋一袋。红枣大枣新疆原产地直销，超高性价比。买两袋全国包邮。");
            bind(xd, xeGoods, "class", "网上购物");
            bind(xd, xeGoods, "end_class", "水果生鲜");
            bind(xd, xeGoods, "destination", "");
            bind(xd, xeGoods, "img_url", "http://image.dqccc.com/tetetuan/2013/12/19/201312191153234747131.jpg");
            XmlElement xePins = xd.CreateElement("pins");//非必填
            //开始for循环B pins
            bind(xd, xePins, "pin", "http://image.dqccc.com/tetetuan/pin/2013/12/19/201312191402257872832.jpg");
            bind(xd, xePins, "pin", "http://image.dqccc.com/tetetuan/pin2/2013/12/19/201312191402259903450.jpg");
            //结束for循环B pins
            xeGoods.AppendChild(xePins);
            bind(xd, xeGoods, "original_price", "68.00");
            bind(xd, xeGoods, "sale_price", "19.00");
            bind(xd, xeGoods, "sale_rate", "2.8");
            bind(xd, xeGoods, "sales_num", "1263");
            bind(xd, xeGoods, "start_time", "20131219000000");
            bind(xd, xeGoods, "close_time", "20140330235959");
            bind(xd, xeGoods, "merchant_name", "杨刚有限公司");
            bind(xd, xeGoods, "merchant_tel", "15596443415");
            XmlElement xeMerchants = xd.CreateElement("merchants");
            //开始for循环C merchant
            XmlElement xeMerchant = xd.CreateElement("merchant");
            bind(xd, xeMerchant, "name", "杨刚有限公司");
            bind(xd, xeMerchant, "brand_name", "");
            bind(xd, xeMerchant, "addr", "新疆");
            bind(xd, xeMerchant, "tel", "15596443415");
            bind(xd, xeMerchant, "reservation", "0");//新增
            bind(xd, xeMerchant, "area", "白云路");
            bind(xd, xeMerchant, "lng", "126.63770727987");
            bind(xd, xeMerchant, "lat", "45.611746712731");
            bind(xd, xeMerchant, "open_time", "");//非必填
            bind(xd, xeMerchant, "traffic_info", "");//非必填
            bind(xd, xeMerchant, "dpid", "0");
            xeMerchants.AppendChild(xeMerchant);
            //结束for循环C merchant
            xeGoods.AppendChild(xeMerchants);
            //cinemaid 不知如何填写
            bind(xd, xeGoods, "spend_start_time", "20131219000000");
            bind(xd, xeGoods, "spend_close_time", "20140330235959");
            bind(xd, xeGoods, "merchant_addr", "新疆");//无
            bind(xd, xeGoods, "hot_area", "白云路");//无
            bind(xd, xeGoods, "longitude", "126.63770727987");//无
            bind(xd, xeGoods, "latitude", "45.611746712731");//无
            XmlElement xeTip = xd.CreateElement("tip");
            xeTip.AppendChild(xd.CreateCDataSection(@"1.全国两袋包邮，一袋邮费10元（港澳台、西藏、云南、海南、内蒙古、宁夏等偏远乡镇不发货，请勿购买），购买时请仔细填写
                收货地址、姓名、电话、购买数量等信息； 2.团购成功后，1-2个工作日发货。受天气、交通状况以及其他不可预见因素的影响，难免出现个别订单送达速度过慢等情况，敬请谅
                解； 3.购买须知：请仔细填好产品的详细收货地址，姓名和电话，以便及时送达。 4.请您本人签收，商品送达请当场仔细检查验收，如商品配送有误，数量缺失，商品破损等问题，
                请当面及时向配送人员提出并拒收，商家会尽快为您安排调换，签收后入发现上述问题，概不提供退换； 5.由于显示器不同存在色差，本次团购商品包装及颜色请以收到的实物为准；"));
            xeGoods.AppendChild(xeTip);

            xeGoodsData.AppendChild(xeGoods);//goods终节点
            xedata.AppendChild(xeGoodsData);//goodsdata终节点
            //xd.Save(@"F:\TestProject\AirportAlliance\AirportAlliance\360APIT\360TG.xml");
            //xd.Save(AppDomain.CurrentDomain.BaseDirectory + "360APIT/360TG.xml");
            //xd.Save(Server.MapPath("360APIT/360TG.xml"));

            //if (!Directory.Exists(@"\\192.168.101.193\pic\360APIT"))
            //{
            //    Directory.CreateDirectory(@"\\192.168.101.193\pic\360APIT");
            //}
            //string fileAbsPath = @"\\192.168.101.193\pic\360APIT\" + "360TG.xml";
            //xd.Save(fileAbsPath);
            //xd.Save(@"\\192.168.101.193\pic\360TG.xml");

            //XmlElement xeDesc = xd.CreateElement("desc");
            //xeDesc.InnerText = "仅19元，抢购原价68元新疆阿克苏6星级红枣500g/袋一袋。红枣大枣新疆原产地直销，超高性价比。买两袋全国包邮。";
            //xeGoods.AppendChild(xeDesc);
            //XmlElement xe1 = xd.CreateElement("Tree");
            //xe1.SetAttribute("id", "1");
            //xe1.InnerText = "类型1";
            //root.AppendChild(xe1);
            //EventLog.WriteEntry("B", "到这了");
            string fileAbsPath = AppDomain.CurrentDomain.BaseDirectory + "360API/" + "APITG.XML";
            xd.Save(fileAbsPath);
            //EventLog.WriteEntry("C", "到这了");

            //SFTPHelper SFTP = new SFTPHelper("192.168.102.188", "test", "111222");
            //SFTP.Connect();
            //if (SFTP.Connected)
            //{
            //    SFTP.Put(fileAbsPath, "APITG.XML");
            //}
            //SFTP.Disconnect();
        }

        public void bind(XmlDocument xd, XmlElement xeGoods, string param, string value)
        {
            XmlElement xeDesc = xd.CreateElement(param);
            if (!string.IsNullOrEmpty(value))
            {
                xeDesc.InnerText = value;
            }
            xeGoods.AppendChild(xeDesc);
        }
    }
}
