using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemcachedInfo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //红 X  红 L  红 XL 红 XXL
        //黑 X  黑 XL
        //绿 L  绿 K
        private void Form2_Load(object sender, EventArgs e)
        {
            List<ProductEE> list = new List<ProductEE>();
            list.Add(new ProductEE(1, 111, "红", "X", false, true));
            list.Add(new ProductEE(2, 111, "红", "L", false, true));
            list.Add(new ProductEE(3, 111, "红", "XL", false, true));
            list.Add(new ProductEE(4, 111, "黑", "X", false, true));
            list.Add(new ProductEE(5, 111, "黑", "XL", false, true));
            list.Add(new ProductEE(6, 111, "绿", "L", false, true));
            list.Add(new ProductEE(6, 111, "红", "XXL", false, true));
            list.Add(new ProductEE(6, 111, "绿", "K", false, true));

            if(list.Count > 0)//存在 颜色 或 颜色+尺码
            {

            }

            //颜色所有
            List<ProductEE> listQYS = new List<ProductEE>();//最终返回
            var qQYS = (from p in list group p by p.Group1Value into g select new { Group1Value = g.Key, GroupNumber = g.Max(p => p.GroupNumber) }).ToList();
            if(qQYS.Count > 0)
            {
                foreach(var qYS in qQYS)
                {
                    ProductEE pYS = new ProductEE();
                    pYS.GroupNumber = qYS.GroupNumber;
                    pYS.Group1Value = qYS.Group1Value;
                    pYS.isCheck = false;
                    pYS.isShow = true;
                    listQYS.Add(pYS);
                }
            }
            //尺码所有
            List<ProductEE> listQCM = new List<ProductEE>();//最终返回
            var qQCM = (from p in list group p by p.Group2Value into g select new { Group2Value = g.Key, GroupNumber = g.Max(p => p.GroupNumber) }).ToList();
            if (qQCM.Count > 0)
            {
                foreach (var qCM in qQCM)
                {
                    ProductEE pCM = new ProductEE();
                    pCM.GroupNumber = qCM.GroupNumber;
                    pCM.Group2Value = qCM.Group2Value;
                    pCM.isCheck = false;
                    pCM.isShow = false;
                    listQCM.Add(pCM);
                }
            }

            //访问数据库获取到 颜色 + 尺码
            //A传入商品编号 -> 获取准确的 颜色 + 尺码
            int aaGNumber = 111;
            string aaYS = "黑";
            string aaCM = "X";
            //var aCYS = (from p in listQYS where p.GroupNumber == aaGNumber && p.Group1Value == aaYS.Trim() select p).ToList();
            //if (aCYS.Count > 0)
            //{
            //    foreach(var aYS in aCYS)
            //    {
            //        aYS.isCheck = true;
            //        break;
            //    }
            //}
            //var aCCM = (from p in list where p.GroupNumber == aaGNumber && p.Group1Value == aaYS.Trim() select new { p.GroupNumber, p.Group2Value }).ToList();
            //if(aCCM.Count > 0)
            //{
            //    foreach(var aCM in aCCM)
            //    {
            //        var mCCM = (from p in listQCM where p.GroupNumber == aaGNumber && p.Group2Value == aCM.Group2Value.Trim() select p).ToList();
            //        if (mCCM.Count > 0)
            //        {
            //            foreach (var mCM in mCCM)
            //            {
            //                if(aaCM == mCM.Group2Value)
            //                {
            //                    mCM.isCheck = true;
            //                }
            //                mCM.isShow = true;
            //                break;
            //            }
            //        }
            //    }
            //}

            //B传入颜色 + ？尺码
            aaGNumber = 111;
            aaYS = "黑";
            aaCM = "L";
            //var bCData = (from p in list where p.GroupNumber == aaGNumber && p.Group1Value == aaYS && p.Group2Value == aaCM select p.Group2Value).ToList();
            //if (bCData.Count <= 0)//判断GN + YS + CM 是否存在
            //{
            //    var bbCData = (from p in list where p.GroupNumber == aaGNumber && p.Group1Value == aaYS select p.Group2Value).ToList();
            //    if (bbCData.Count > 0)
            //    {
            //        foreach (var m in bbCData)
            //        {
            //            aaCM = m.ToString();//X
            //            break;
            //        }
            //    }
            //}
            ////访问数据库查询
            //var bCYS = (from p in listQYS where p.GroupNumber == aaGNumber && p.Group1Value == aaYS.Trim() select p).ToList();
            //if (bCYS.Count > 0)
            //{
            //    foreach (var bYS in bCYS)
            //    {
            //        bYS.isCheck = true;
            //        break;
            //    }
            //}
            //var bCCM = (from p in list where p.GroupNumber == aaGNumber && p.Group1Value == aaYS.Trim() select new { p.GroupNumber, p.Group2Value }).ToList();
            //if (bCCM.Count > 0)
            //{
            //    foreach (var bCM in bCCM)
            //    {
            //        var mCCM = (from p in listQCM where p.GroupNumber == aaGNumber && p.Group2Value == bCM.Group2Value.Trim() select p).ToList();
            //        if (mCCM.Count > 0)
            //        {
            //            foreach (var mCM in mCCM)
            //            {
            //                if (aaCM == mCM.Group2Value)
            //                {
            //                    mCM.isCheck = true;
            //                }
            //                mCM.isShow = true;
            //                break;
            //            }
            //        }
            //    }
            //}

            //C传入尺码 + ？颜色
            aaGNumber = 111;
            aaYS = "黑";
            aaCM = "K";
            var cCData = (from p in list where p.GroupNumber == aaGNumber && p.Group1Value == aaYS && p.Group2Value == aaCM select p.Group1Value).ToList();
            if (cCData.Count <= 0)//判断GN + CM + YS 是否存在
            {
                var ccCData = (from p in list where p.GroupNumber == aaGNumber && p.Group2Value == aaCM select p.Group1Value).ToList();
                if (ccCData.Count > 0)
                {
                    foreach (var m in ccCData)
                    {
                        aaYS = m.ToString();//红
                        break;
                    }
                }
            }
            //访问数据库查询
            var cCYS = (from p in listQYS where p.GroupNumber == aaGNumber && p.Group1Value == aaYS.Trim() select p).ToList();
            if (cCYS.Count > 0)
            {
                foreach (var cYS in cCYS)
                {
                    cYS.isCheck = true;
                    break;
                }
            }
            var cCCM = (from p in list where p.GroupNumber == aaGNumber && p.Group1Value == aaYS.Trim() select new { p.GroupNumber, p.Group2Value }).ToList();
            if (cCCM.Count > 0)
            {
                foreach (var cCM in cCCM)
                {
                    var mCCM = (from p in listQCM where p.GroupNumber == aaGNumber && p.Group2Value == cCM.Group2Value.Trim() select p).ToList();
                    if (mCCM.Count > 0)
                    {
                        foreach (var mCM in mCCM)
                        {
                            if (aaCM == mCM.Group2Value)
                            {
                                mCM.isCheck = true;
                            }
                            mCM.isShow = true;
                            break;
                        }
                    }
                }
            }


            int kk = 0;

        }
    }

    public class ProductEE
    {
        public int ProductSysNo;
        public int GroupNumber;
        public string Group1Value;
        public string Group2Value;
        public bool isCheck;
        public bool isShow;

        public ProductEE()
        {
        }

        public ProductEE(int ProductSysNo, int GroupNumber, string Group1Value, string Group2Value, bool isCheck, bool isShow)
        {
            this.ProductSysNo = ProductSysNo;
            this.GroupNumber = GroupNumber;
            this.Group1Value = Group1Value;
            this.Group2Value = Group2Value;
            this.isCheck = isCheck;
            this.isShow = isShow;
        }
    }
}
