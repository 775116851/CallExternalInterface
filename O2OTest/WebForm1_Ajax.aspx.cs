using allinpay.O2O.Cmn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace O2OTest
{
    public partial class WebForm1_Ajax : System.Web.UI.Page
    {
        protected int PageCount = 0;
        protected int PageSize = 20;
        protected int MaxPages = 0;
        protected int PageIndex = 1;
        protected int BeginIndex = 0;
        protected int EndIndex = 0;
        protected string Begin = "";
        protected string End = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PageIndex"] != null)
            {
                PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
                BindRep1();
            }
        }

        protected void BindRep1()
        {
            Hashtable ht = new Hashtable();
            #region 搜索条件
            //if (Request.Form["ucArea$hidAreaSysNo"] != null && Request.Form["ucArea$hidAreaSysNo"].ToString() != "" && Convert.ToInt32(Request.Form["ucArea$hidAreaSysNo"]) != AppConst.IntNull)
            //{
            //    ht.Add("AreaSysNo", Convert.ToInt32(Request.Form["ucArea$hidAreaSysNo"]).ToString());
            //}
            //if (Request.Form["txtAreaID"] != null && Request.Form["txtAreaID"].ToString() != "")
            //{
            //    ht.Add("AreaID", Request.Form["txtAreaID"].Trim());
            //}
            //if (Request.Form["txtAreaName"] != null && Request.Form["txtAreaName"].ToString() != "")
            //{
            //    ht.Add("AreaName", Request.Form["txtAreaName"].Trim());
            //}
            //if (Request.Form["ddlIsMaster$ddlEnum"] != null && Request.Form["ddlIsMaster$ddlEnum"].ToString() != "" && Convert.ToInt32(Request.Form["ddlIsMaster$ddlEnum"]) != AppConst.IntNull)
            //{
            //    ht.Add("IsMaster", Convert.ToInt32(Request.Form["ddlIsMaster$ddlEnum"]).ToString());
            //}
            //if (Request.Form["ddlStatus$ddlEnum"] != null && Request.Form["ddlStatus$ddlEnum"].ToString() != "" && Convert.ToInt32(Request.Form["ddlStatus$ddlEnum"]) != AppConst.IntNull)
            //{
            //    ht.Add("Status", Convert.ToInt32(Request.Form["ddlStatus$ddlEnum"]).ToString());
            //}
            //if (Request.Form["ddlIsOnlineShow$ddlEnum"] != null && Request.Form["ddlIsOnlineShow$ddlEnum"].ToString() != "" && Convert.ToInt32(Request.Form["ddlIsOnlineShow$ddlEnum"]) != AppConst.IntNull)
            //{
            //    ht.Add("IsOnlineShow", Convert.ToInt32(Request.Form["ddlIsOnlineShow$ddlEnum"]).ToString());
            //}
            #endregion

            DataSet ds = GetDs(PageIndex, PageSize, ht);
            PageCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            BeginIndex = (PageIndex - 1) * PageSize + 1;
            MaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(PageCount) / Convert.ToDouble(PageSize)));
            EndIndex = (PageIndex * PageSize) > PageCount ? PageCount : (PageIndex * PageSize);
            Grv_SPLBMB.DataSource = ds.Tables[0];
            Grv_SPLBMB.DataBind();
        }

        protected DataTable BindSSZ()
        {
            Hashtable ht = new Hashtable();
            ht.Add("CategoryID", 1);
            PagerData pd = PagerData.GetInstance();
            SqlParameterCollection spc = new SqlCommand().Parameters;
            pd.Conn = AppConfig.Conn_O2O2;
            pd.Field = @" SysNo,PropertyName ";
            pd.Table = @" dbo.P_Property ";
            pd.Where = " WHERE 1=1 And Status = '0'";
            pd.SearchWhere = " 1=1 ";
            pd.Order = " ORDER BY SysNo ASC ";
            pd.PageSize = PageSize;
            pd.CurrentPageIndex = PageIndex;
            if (ht != null && ht.Count > 1)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string key in ht.Keys)
                {
                    #region 搜索条件
                    if (key == "PropertyName")
                    {
                        //sb.Append(" and PropertyName ").Append(" LIKE ").Append(Util.ToSqlLikeString(ht[key].ToString()));
                        sb.Append(" and PropertyName LIKE '%'+@PropertyName+'%'  ");
                        spc.Add(new SqlParameter("@PropertyName", ht[key].ToString()));
                    }
                    #endregion
                }
                pd.SearchWhere += sb.ToString();
            }
            pd.Collection = spc;
            DataSet ds = pd.GetPage(PageIndex);

            //下面是商品类别模版存在的所有组
            string sSql = "SELECT DISTINCT a.SysNo,a.GroupDesc FROM dbo.P_Property_Group AS a INNER JOIN dbo.P_CategoryTemplateProperty AS b ON a.SysNo = b.GroupSysNo WHERE b.C3SysNo = @CategoryID ORDER BY a.SysNo ASC";
            SqlParameter[] spp = 
            {
                new SqlParameter("@CategoryID",ht["CategoryID"].ToString()),
            };
            DataSet dsF = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sSql, spp);
            DataTable dts = new DataTable("ddd");
            dts = dsF.Tables[0];
            dts.TableName = "ddd";
            dsF.Tables.Clear();
            ds.Tables.Add(dts);
            return ds.Tables[2];

        }

        public string GetDisplayType(string value)
        {
            string result = "";
            switch (value)
            {
                case "1":
                    result = "属性值";
                    break;
                case "2":
                    result = "属性名+属性值";
                    break;
                case "3":
                    result = "属性值+属性名";
                    break;
            }
            return result;
        }

        public DataSet GetDs(int sPageIndex, int sPageSize,Hashtable ht)
        {
            PagerData pd = PagerData.GetInstance();
            SqlParameterCollection spc = new SqlCommand().Parameters;
            pd.Conn = AppConfig.Conn_O2O2;
            pd.Field = @" a.SysNo,c.PropertyName,d.GroupDesc,a.IsInAdvSearch,a.WebDisplayStyle,a.IsMustInput,a.SortNo,a.GroupSysNo ";
            pd.Table = @" dbo.P_CategoryTemplateProperty AS a 
                        INNER JOIN dbo.P_Category AS b ON a.C3SysNo = b.SysNo AND ISNULL(b.C3Name,'') != ''
                        INNER JOIN dbo.P_Property AS c ON a.PropertySysNo = c.SysNo
                        INNER JOIN dbo.P_Property_Group AS d ON a.GroupSysNo = d.SysNo ";
            pd.Where = " WHERE 1=1 ";
            pd.SearchWhere = " 1=1 ";
            pd.Order = " ORDER BY a.SysNo ASC ";
            pd.PageSize = sPageSize;
            pd.CurrentPageIndex = sPageIndex;
            if (ht != null && ht.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string key in ht.Keys)
                {
                    #region 搜索条件
                    if (key == "CategoryID")
                    {
                        //sb.Append(" and b.SysNo ").Append(" = ").Append(Util.ToSqlString(ht[key].ToString()));
                        sb.Append(" and b.SysNo=@CategoryID  ");
                        spc.Add(new SqlParameter("@CategoryID", ht[key].ToString()));
                    }
                    #endregion
                }
                pd.SearchWhere += sb.ToString();
            }
            pd.Collection = spc;
            DataSet ds = pd.GetPage(PageIndex);
            return ds;
        }

        protected void Grv_SPLBMB_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grv_SPLBMB.EditIndex = -1;
            BindRep1();
        }

        protected void Grv_SPLBMB_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Trim() == "Update")
            {
                string fSysNO = Convert.ToString(e.CommandArgument).Trim();
                if (!string.IsNullOrEmpty(fSysNO))
                {
                    //P_CategoryTemplatePropertyEntity model = new P_CategoryTemplatePropertyEntity();
                    //model.SysNo = Convert.ToInt32(fSysNO);
                    int index = Grv_SPLBMB.EditIndex;
                    GridViewRow row = Grv_SPLBMB.Rows[index];
                    bool cbSS2 = (row.FindControl("cbSS2") as CheckBox).Checked;
                    //if (cbSS2 == true)
                    //{
                    //    model.IsInAdvSearch = 1;
                    //}
                    //else
                    //{
                    //    model.IsInAdvSearch = 0;
                    //}
                    string cblSXZ = (row.FindControl("cblSXZ") as DropDownList).SelectedValue;
                    //model.WebDisplayStyle = Convert.ToInt32(cblSXZ);
                    string cblSSZ = (row.FindControl("cblSSZ") as DropDownList).SelectedValue;
                    //model.GroupSysNo = Convert.ToInt32(cblSSZ);
                    bool cbSZ2 = (row.FindControl("cbSZ2") as CheckBox).Checked;
                    //if (cbSZ2 == true)
                    //{
                    //    model.IsMustInput = 1;
                    //}
                    //else
                    //{
                    //    model.IsMustInput = 0;
                    //}
                    string sorts = (row.FindControl("txtSort2") as TextBox).Text.Trim();
                    if (sorts == "" || !(Util.IsInteger(sorts) && Convert.ToInt32(sorts) > 0))
                    {
                        sorts = "0";
                    }
                    //model.SortNo = Convert.ToInt32(sorts);
                    //if (PCategoryManager.GetInstance().UpdatetPCategoryTemplate(model) > 0)
                    //{
                        Grv_SPLBMB.EditIndex = -1;
                        BindRep1();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('更新失败！')", true);
                    //}

                }
            }
            if (e.CommandName.Trim() == "del")
            {
                string fSysNO = Convert.ToString(e.CommandArgument).Trim();
                if (!string.IsNullOrEmpty(fSysNO))
                {
                    //if (PCategoryManager.GetInstance().DeletePCategoryTemplate(Convert.ToInt32(fSysNO)) > 0)
                    //{
                        Grv_SPLBMB.EditIndex = -1;
                        BindRep1();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('删除失败！')", true);
                    //}
                }
            }
        }

        protected void Grv_SPLBMB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.FindControl("lkbut_del").ToString() == "System.Web.UI.WebControls.LinkButton")
                {
                    System.Web.UI.WebControls.LinkButton lbtn = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("lkbut_del");
                    lbtn.Attributes.Add("onclick", "return confirm('您确定删除吗？')");
                }
            }
            string aa = e.Row.RowState.ToString();
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit || (aa == "Alternate, Edit"))
            {
                DropDownList cblSXZ = (DropDownList)e.Row.FindControl("cblSXZ");
                HtmlInputHidden ipt_CtrlDisplayType = (HtmlInputHidden)e.Row.FindControl("ipt_CtrlDisplayType");
                if (ipt_CtrlDisplayType.Value != "")
                {
                    cblSXZ.SelectedValue = ipt_CtrlDisplayType.Value;
                }

                //所属组
                DropDownList cblSSZ = (DropDownList)e.Row.FindControl("cblSSZ");
                HtmlInputHidden ipt_CtrlDisplaySSZ = (HtmlInputHidden)e.Row.FindControl("ipt_CtrlDisplaySSZ");
                if (ipt_CtrlDisplaySSZ.Value != "")
                {
                    cblSSZ.SelectedValue = ipt_CtrlDisplaySSZ.Value;
                }
            }
        }

        protected void Grv_SPLBMB_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Grv_SPLBMB.EditIndex = e.NewEditIndex;
            ViewState["IsEditing"] = "1";
            BindRep1();
        }

        protected void Grv_SPLBMB_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}