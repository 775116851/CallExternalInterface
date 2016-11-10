using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DataSyncRWY
{
    public partial class LinqTest : Form
    {
        public LinqTest()
        {
            InitializeComponent();
        }

        private void LinqTest_Load(object sender, EventArgs e)
        {
            List<OrderPromotion> list = new List<OrderPromotion>();
            list.Add(new OrderPromotion(1, "AAA", 1));
            list.Add(new OrderPromotion(2, "DDW", 1));
            list.Add(new OrderPromotion(3, "12D", 1));
            list.Add(new OrderPromotion(1, "AAA", 1));
            list.Add(new OrderPromotion(4, "LLL", 1));
            list.Add(new OrderPromotion(1, "AAA", 1));
            list.Add(new OrderPromotion(2, "DDW", 1));
            list.Add(new OrderPromotion(5, "335", 1));
            list.Add(new OrderPromotion(1, "BBB", 1));
            list.Add(new OrderPromotion(2, "CCC", 1));

            int lastSL = 0;
            string productIDList = string.Empty;
            string sqlList = string.Empty;
            string allProductID = string.Empty;
            string allOrderSysNo = string.Empty;
            

            var qOne = (from p in list group p by p.ProductID into g orderby g.Sum(p => p.SL) descending select new { ProductID = g.Key, SL = g.Sum(p => p.SL), OrderSysNo = g.Max(p => p.OrderSysNo) }).ToList();
            if (qOne.Count > 0)
            {
                productIDList = string.Empty;
                lastSL = qOne.Last().SL;
                foreach(var m in qOne)
                {
                    productIDList += m.ProductID + ',';
                }
                productIDList = productIDList.Remove(productIDList.Length-1, 1);
                allProductID = productIDList;
                sqlList += "Update OrderCode Set SL=SL-" + lastSL + " Where ProductID in ( " + productIDList + " );";
            }

            while(lastSL > 0)
            {
                var qTwo = (from p in qOne where p.SL - lastSL > 0 orderby p.SL - lastSL descending select new { p.ProductID, SL = (p.SL - lastSL), p.OrderSysNo }).ToList();
                if (qTwo.Count > 0)
                {
                    productIDList = string.Empty;
                    lastSL = qTwo.Last().SL;
                    foreach (var m in qTwo)
                    {
                        productIDList += m.ProductID + ',';
                    }
                    productIDList = productIDList.Remove(productIDList.Length - 1, 1);
                    sqlList += "Update OrderCode Set SL=SL-" + lastSL + " Where ProductID in ( " + productIDList + " );";
                    qOne = qTwo;
                }
                else
                {
                    lastSL = 0;
                }
            }
            

            //var qTwo = (from p in qOne where p.SL - lastSL > 0 orderby p.SL - lastSL descending select new { p.ProductID,SL =(p.SL - lastSL),p.OrderSysNo}).ToList();
            //if(qTwo.Count > 0)
            //{
            //    productIDList = string.Empty;
            //    lastSL = qTwo.Last().SL;
            //    foreach (var m in qTwo)
            //    {
            //        productIDList += m.ProductID + ',';
            //    }
            //    productIDList = productIDList.Remove(productIDList.Length-1, 1);
            //    sqlList += "Update OrderCode Set SL=SL-" + lastSL + " Where ProductID in ( " + productIDList + " );";
            //}
            

            //var qThree = (from p in qTwo where p.SL - lastSL > 0 orderby p.SL - lastSL descending select new { p.ProductID, SL =(p.SL - lastSL), p.OrderSysNo }).ToList();
            //if(qThree.Count > 0)
            //{
            //    productIDList = string.Empty;
            //    lastSL = qThree.Last().SL;
            //    foreach (var m in qThree)
            //    {
            //        productIDList += m.ProductID + ',';
            //    }
            //    productIDList = productIDList.Remove(productIDList.Length - 1, 1);
            //    sqlList += "Update OrderCode Set SL=SL-" + lastSL + " Where ProductID in ( " + productIDList + " );";
            //}



            //var qFour = (from p in qThree where p.SL - lastSL > 0 orderby p.SL - lastSL descending select new { p.ProductID, SL = (p.SL - lastSL), p.OrderSysNo }).ToList();
            //if(qFour.Count > 0)
            //{
            //    productIDList = string.Empty;
            //    lastSL = qFour.Last().SL;
            //    foreach (var m in qFour)
            //    {
            //        productIDList += m.ProductID + ',';
            //    }
            //    productIDList = productIDList.Remove(productIDList.Length - 1, 1);
            //    sqlList += "Update OrderCode Set SL=SL-" + lastSL + " Where ProductID in ( " + productIDList + " );";
            //}

            //更新券状态
            string sSQL2List = "Update OrderCode a Set a.Status = (select case when sl < 0 then 1 else 0 end from ordercode b where b.sysno = a.sysno) where ProductID in ( " + allProductID + " ) "; ;

            //全部订单号
            var oOne = (from p in list group p by p.OrderSysNo into g select g.Key).ToList();
            if (oOne.Count > 0)
            {
                foreach (var m in oOne)
                {
                    allOrderSysNo += m.ToString() + ',';
                }
                allOrderSysNo = allOrderSysNo.Remove(allOrderSysNo.Length - 1, 1);
                string sSQL3List = "Update ....";
            }

            //var qone = from f in q where f.SL > 1 select f;

            //int kkk = 

            //var jji = q.All(p => p.ProductID != null).ToString();
            //DataTable dtA = LINQToDataTable(q);
            //foreach(var a in q)
            //{
                
            //}
            //var j = from jj in dtA.AsEnumerable() where jj.Field<int>("totalSL") > 1 select jj;


        }

        //将IEnumerable<T>类型的集合转换为DataTable类型 
        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {   //定义要返回的DataTable对象
            DataTable dtReturn = new DataTable();
            // 保存列集合的属性信息数组
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;//安全性检查
            //循环遍历集合，使用反射获取类型的属性信息
            foreach (T rec in varlist)
            {
                //使用反射获取T类型的属性信息，返回一个PropertyInfo类型的集合
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    //循环PropertyInfo数组
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;//得到属性的类型
                        //如果属性为泛型类型
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {   //获取泛型类型的参数
                            colType = colType.GetGenericArguments()[0];
                        }
                        //将类型的属性名称与属性类型作为DataTable的列数据
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                //新建一个用于添加到DataTable中的DataRow对象
                DataRow dr = dtReturn.NewRow();
                //循环遍历属性集合
                foreach (PropertyInfo pi in oProps)
                {   //为DataRow中的指定列赋值
                    dr[pi.Name] = pi.GetValue(rec, null) == null ?
                        DBNull.Value : pi.GetValue(rec, null);
                }
                //将具有结果值的DataRow添加到DataTable集合中
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;//返回DataTable对象
        }
    }


    public class OrderPromotion
    {
        public OrderPromotion(int OrderSysNo, string ProductID, int SL)
        {
            this.OrderSysNo = OrderSysNo;
            this.ProductID = ProductID;
            this.SL = SL;
        }
        public int OrderSysNo;
        public string ProductID;
        public int SL;
    }
}
