using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace 枚举导出
{
    public class AppEnum
    {
        #region 快递公司名称及代码
        public enum ExpressCompany : int
        {
            #region 快递公司代码说明
            [Description("AAE")]
            aae = 1,
            [Description("安信达")]
            anxindakuaixi = 2,
            [Description("百福东方")]
            baifudongfang = 3,
            [Description("BHT")]
            bht = 4,
            [Description("邮政包裹挂号信")]
            youzhengguonei = 5,
            [Description("希伊艾斯（CCES）")]
            cces = 6,
            [Description("中国东方（COE）")]
            coe = 7,
            [Description("大田物流")]
            datianwuliu = 8,
            [Description("德邦物流")]
            debangwuliu = 9,
            [Description("DPEX")]
            dpex = 10,
            [Description("DHL")]
            dhl = 11,
            [Description("D速快递")]
            dsukuaidi = 12,
            [Description("EMS")]   //E邮宝 一样
            ems = 13,
            [Description("Fedex")]
            fedex = 14,
            [Description("飞康达物流")]
            feikangda = 15,
            [Description("飞快达")]
            feikuaida = 16,
            [Description("港中能达")]
            ganzhongnengda = 17,
            [Description("广东邮政")]
            guangdongyouzhengwuliu = 18,
            [Description("GLS")]
            gls = 20,
            [Description("百世汇通")]
            huitongkuaidi = 21,
            [Description("恒路物流")]
            hengluwuliu = 22,
            [Description("华夏龙")]
            huaxialongwuliu = 23,
            [Description("京广速递")]
            jinguangsudikuaijian = 25,
            [Description("急先达")]
            jixianda = 26,
            [Description("佳吉物流")]
            jiajiwuliu = 27,
            [Description("佳怡物流")]
            jiayiwuliu = 28,
            [Description("加运美")]
            jiayunmeiwuliu = 29,
            [Description("晋越快递")]
            jinyuekuaidi = 30,


            [Description("快捷速递")]
            kuaijiesudi = 31,
            [Description("联昊通")]
            lianhaowuliu = 32,
            [Description("龙邦物流")]
            longbanwuliu = 33,
            [Description("蓝镖快递")]
            lanbiaokuaidi = 34,
            [Description("联邦快递")]
            lianbangkuaidi = 35,
            [Description("民航快递")]
            minghangkuaidi = 36,
            [Description("如风达快递")]
            rufengda = 37,
            [Description("全晨快递")]
            quanchenkuaidi = 38,
            [Description("全际通")]
            quanjitong = 39,
            [Description("全日通")]
            quanritongkuaidi = 40,
            [Description("全一快递")]
            quanyikuaidi = 41,
            [Description("全峰快递")]
            quanfengkuaidi = 42,
            [Description("申通速递")]   //申通E物流 一样
            shentong = 43,
            [Description("顺丰速递")]
            shunfeng = 44,
            [Description("三态速递")]
            santaisudi = 45,
            [Description("盛辉物流")]
            shenghuiwuliu = 46,
            [Description("速尔物流")]
            suer = 47,
            [Description("盛丰物流")]
            shengfengwuliu = 48,
            [Description("上大物流")]
            shangda = 49,
            [Description("天地华宇")]
            tiandihuayu = 50,
            [Description("天天快递")]
            tiantian = 51,
            [Description("TNT")]
            tnt = 52,
            [Description("UPS")]
            ups = 53,
            [Description("万家物流")]
            wanjiawuliu = 54,
            [Description("万象物流")]
            wanxiangwuliu = 55,
            [Description("新邦物流")]
            xinbangwuliu = 56,
            [Description("信丰物流")]
            xinfengwuliu = 57,
            [Description("星晨急便")]
            xingchengjibian = 58,
            [Description("鑫飞鸿")]
            xinhongyukuaidi = 59,
            [Description("亚风速递")]
            yafengsudi = 60,

            [Description("一邦速递")]
            yibangwuliu = 61,
            [Description("优速物流")]
            youshuwuliu = 62,
            [Description("远成物流")]
            yuanchengwuliu = 63,
            [Description("圆通速递")]
            yuantong = 64,
            [Description("源伟丰快递")]
            yuanweifeng = 65,
            [Description("元智捷诚")]
            yuanzhijiecheng = 66,
            [Description("越丰物流")]
            yuefengwuliu = 67,
            [Description("韵达快运")]
            yunda = 68,
            [Description("源安达")]
            yuananda = 69,
            [Description("原飞航")]
            yuanfeihangwuliu = 70,
            [Description("运通快递")]
            yuntongkuaidi = 71,

            [Description("邮政国际")]
            youzhengguoji = 73,
            [Description("宅急送")]
            zhaijisong = 74,
            [Description("中铁快运")]
            zhongtiewuliu = 75,
            [Description("中通速递")]
            zhongtong = 76,
            [Description("中邮物流")]
            zhongyouwuliu = 77,
            [Description("商家送货")]
            VendorSend = 78,
            #endregion

        }

        public static SortedList GetExpressCompanyName()
        {
            return GetStatus(typeof(ExpressCompany));
        }
        public static string GetExpressCompany(object v)
        {
            return GetDescription(typeof(ExpressCompany), v);
        }

        public static string GetExpressCompanyValue(System.Type t, string name)
        {
            string result = "StringNull";
            Array a = Enum.GetValues(t);

            for (int i = 0; i < a.Length; i++)
            {
                string enumName = a.GetValue(i).ToString();
                string enumKeyName = System.Enum.Parse(t, enumName).ToString();
                int enumKey = (int)System.Enum.Parse(t, enumName);
                string enumDescription = GetDescription(t, enumKey);
                //dr = dt.NewRow();
                if (enumDescription == name)
                {
                    result = enumKeyName;
                    break;
                }
            }
            return result;
        }

        public static string GetExpressURL(string expressCode)
        {
            string result = "http://";
            if (expressCode == AppEnum.ExpressCompany.shentong.ToString())
            {
                result += "www.sto.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.ems.ToString())
            {
                result += "www.11183.com.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.shunfeng.ToString())
            {
                result += "www.sf-express.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.yuantong.ToString())
            {
                result += "www.yto.net.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.zhongtong.ToString())
            {
                result += "www.zto.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.rufengda.ToString())
            {
                result += "www.rufengda.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.yunda.ToString())
            {
                result += "www.yundaex.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.tiantian.ToString())
            {
                result += "www.ttkdex.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.huitongkuaidi.ToString())
            {
                result += "www.htky365.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.suer.ToString())
            {
                result += "www.sure56.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.debangwuliu.ToString())
            {
                result += "www.deppon.com/";
            }
            else if (expressCode == AppEnum.ExpressCompany.zhaijisong.ToString())
            {
                result += "www.zjs.com.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.youzhengguonei.ToString())
            {
                result += "yjcx.chinapost.com.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.coe.ToString())
            {
                result += "www.coe.com.hk/";
            }
            else if (expressCode == AppEnum.ExpressCompany.zhongtiewuliu.ToString())
            {
                result += "www.cre.cn/";
            }
            else if (expressCode == AppEnum.ExpressCompany.ganzhongnengda.ToString())
            {
                result += "www.nd56.com/";
            }
            else
            {
                result += "www.kuaidi100.com/all/";
            }
            return result;

        }

        #endregion

        #region 工具函数
        public static SortedList GetStatus(System.Type t)
        {
            SortedList list = new SortedList();

            Array a = Enum.GetValues(t);
            for (int i = 0; i < a.Length; i++)
            {
                string enumName = a.GetValue(i).ToString();
                int enumKey = (int)System.Enum.Parse(t, enumName);
                string enumDescription = GetDescription(t, enumKey);
                list.Add(enumKey, enumDescription);
            }
            return list;
        }

        private static string GetName(System.Type t, object v)
        {
            try
            {
                return Enum.GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 返回指定枚举类型的指定值的描述
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(System.Type t, object v)
        {
            try
            {
                FieldInfo fi = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 返回指定枚举类型的指定值的描述Name
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        public static string GetDescriptionName(System.Type t, object v)
        {
            try
            {
                FieldInfo fi = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                //return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
                return GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }


        public static string _GetDescription(System.Type t, object v)
        {
            try
            {
                FieldInfo fi = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        public static DataTable GetEnumKeyName(System.Type t)
        {
            SortedList list = new SortedList();
            Array a = Enum.GetValues(t);
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("text", System.Type.GetType("System.String"));
            dt.Columns.Add("value", System.Type.GetType("System.String"));

            for (int i = 0; i < a.Length; i++)
            {
                string enumName = a.GetValue(i).ToString();
                string enumKeyName = System.Enum.Parse(t, enumName).ToString();
                int enumKey = (int)System.Enum.Parse(t, enumName);
                string enumDescription = GetDescription(t, enumKey);
                dr = dt.NewRow();
                dr[0] = enumDescription;
                dr[1] = enumKeyName;
                //ddl.Items.Insert(i + 1, new System.Web.UI.WebControls.ListItem(enumDescription,enumKeyName));
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion
    }
}
