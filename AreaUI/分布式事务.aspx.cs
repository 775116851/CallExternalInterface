using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using allinpay.O2O.Cmn;
using AreaUI.Common;

namespace AreaUI
{
    public partial class FBSSW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sqlIPP = "SELECT * FROM dbo.Area_RWY";
            //DataSet dsIPP = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, sqlIPP);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 分布式事物步骤 WIN8 --> WINXP
            //http://wenku.baidu.com/link?url=J3LRKQDDcxZ7k1Q3pjCfo4a832es8qh6gv2bB2bbz8ciLoNudJ7qzYBDLkTq61wCPU5O96HD8N2vsE9f722XFi84oGmYFI68ieClK4TGSuG
            //1.客户端和服务器端设置启动MSDTC 全允许不验证 启用XA事物
            //2.修改客户端和服务器端hosts 
            //192.168.1.113   lxf-bdd69ebff22
            //192.168.191.1   lxf
            #endregion
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                string sqlIPP = "SELECT * FROM dbo.Area_RWY";
                DataSet dsIPP = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, sqlIPP);
                string sqlO2O2 = "SELECT * FROM dbo.Area_360";
                DataSet dsO2O2 = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sqlO2O2);
                scope.Complete();
            }

        }
    }
}