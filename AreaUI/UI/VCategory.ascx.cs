using allinpay.O2O.Cmn;
using AreaUI.DAL;
using AreaUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AreaUI.UI
{
    public partial class VCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCategoryType.Attributes.Add("onchange", "CategoryTypeChange" + ddlCategoryType.ClientID + "(this.value)");
            if (!IsPostBack)
            {
                BindCategory();
            }
        }

        public void BindCategory()
        {
            hidCategorySysNo.Value = AppConst.IntNull.ToString();
            if (ddlCategoryType.Items.Count == 0)
            {
                BindCategoryType();
            }
            if (ddlC1.Items.Count == 0)
            {
                if (CategoryTypeSysNo == AppConst.IntNull || CategoryTypeSysNo == 2)
                {
                    hidCategoryType.Value = "2";
                    ddlCategoryType.SelectedValue = "2";
                    BindC1(2);
                }
                else
                {
                    BindC1(1);
                }
            }
            //ddlC1.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            //ddlC2.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            //ddlC3.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
        }

        private void BindC1(int categoryType)
        {
            ddlC1.Items.Clear();
            ddlC2.Items.Clear();
            ddlC3.Items.Clear();
            ddlC1.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlC2.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            ddlC3.Items.Insert(0, new ListItem(AppConst.AllSelectString, AppConst.IntNull.ToString()));
            Dictionary<int, V_CategoryEntity> dic = new V_CategoryDac().GetC1List(categoryType);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlC1.Items.Add(new ListItem(dic.Values.ElementAt(i).C1Name, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
        }

        private void BindC2(int c1SysNo, int c2SysNo)
        {
            ddlC2.Enabled = ddlC1.Enabled;
            Dictionary<int, V_CategoryEntity> dic = new V_CategoryDac().GetC2ListByC1SysNo(c1SysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlC2.Items.Add(new ListItem(dic.Values.ElementAt(i).C2Name, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlC2.SelectedValue = c2SysNo.ToString();
        }

        private void BindC3(int c2SysNo, int c3SysNo)
        {
            ddlC3.Enabled = ddlC2.Enabled;
            Dictionary<int, V_CategoryEntity> dic = new V_CategoryDac().GetC3ListByC2SysNo(c2SysNo);
            if (dic != null && dic.Count != 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    ddlC3.Items.Add(new ListItem(dic.Values.ElementAt(i).C3Name, dic.Values.ElementAt(i).SysNo.ToString()));
                }
            }
            ddlC3.SelectedValue = c3SysNo.ToString();
            hidC3SysNo.Value = c3SysNo.ToString();
        }

        public bool Enable
        {
            get { return ddlC1.Enabled; }
            set { ddlC1.Enabled = value; }
        }

        public bool _IsAssignCurrent = true;
        /// <summary>
        /// 是否对当前所在层级数据赋值,在添加/保存数据时候使用
        /// </summary>
        public bool IsAssignCurrent
        {
            set { _IsAssignCurrent = value; }
            get { return _IsAssignCurrent; }
        }

        public int CategorySysNo
        {
            get
            {
                return Convert.ToInt32(hidCategorySysNo.Value);
            }
            //set 
            //{
            //    hidCategorySysNo.Value = value.ToString();
            //    if (ddlC1.Items.Count == 0)
            //    {
            //        BindC1();
            //    }
            //    if (value != AppConst.IntNull)
            //    {
            //        V_CategoryEntity model = VCategoryManager.GetInstance().GetCategoryBySysNo(value);
            //        if (model != null)
            //        {
            //            hidC1SysNo.Value = model.C1SysNo.ToString();
            //            hidC2SysNo.Value = model.C2SysNo.ToString();  
            //            if (model.C2SysNo != AppConst.IntNull)//三级大类
            //            {
            //                ddlC1.SelectedValue = model.C1SysNo.ToString();
            //                BindC2(model.C1SysNo,model.C2SysNo);
            //                if (IsAssignCurrent)
            //                {
            //                    BindC3(model.C2SysNo,model.SysNo);
            //                }
            //            }
            //            else if (model.C1SysNo != AppConst.IntNull)//二级大类
            //            {
            //                ddlC1.SelectedValue = model.C1SysNo.ToString();
            //                if (IsAssignCurrent)
            //                {
            //                    BindC2(model.C1SysNo,model.SysNo);
            //                }
            //            }
            //            else
            //            {
            //                if (IsAssignCurrent)
            //                {
            //                    ddlC1.SelectedValue = model.SysNo.ToString();
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void BindCategoryType()
        {

            ddlCategoryType.Items.Add(new ListItem("购物类别", "1"));
            ddlCategoryType.Items.Add(new ListItem("活动类别", "2"));
        }

        public int CategoryTypeSysNo
        {
            set
            {
                if (ddlCategoryType.Items.Count == 0)
                {
                    BindCategoryType();
                }
                hidCategoryType.Value = value.ToString();
                ddlCategoryType.SelectedValue = value.ToString();
                ddlCategoryType.Enabled = false;
                BindC1(value);
            }
            get { return Convert.ToInt32(hidCategoryType.Value); }
        }

        public int C1SysNo
        {
            get { return Convert.ToInt32(hidC1SysNo.Value); }
            set { hidC1SysNo.Value = value.ToString(); }
        }

        public int C2SysNo
        {
            get { return Convert.ToInt32(hidC2SysNo.Value); }
            set { hidC2SysNo.Value = value.ToString(); }
        }

        public int C3SysNo
        {
            get { return Convert.ToInt32(hidC3SysNo.Value); }
            set { hidC3SysNo.Value = value.ToString(); }
        }

        private string _onC1Change = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,一级大类发生变化时触发的事件
        /// </summary>
        public string onC1Change
        {
            set { _onC1Change = value; }
            get { return _onC1Change; }
        }

        private string _onC2Change = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,二级大类发生变化时触发的事件
        /// </summary>
        public string onC2Change
        {
            set { _onC2Change = value; }
            get { return _onC2Change; }
        }

        private string _onC3Change = AppConst.StringNull;
        /// <summary>
        /// 客户端脚本,三级大类发生变化时触发的事件
        /// </summary>
        public string onC3Change
        {
            set { _onC3Change = value; }
            get { return _onC3Change; }
        } 
    }
}