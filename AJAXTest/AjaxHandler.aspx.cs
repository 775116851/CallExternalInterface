using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJAXTest
{
    public partial class AjaxHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = HttpContext.Current.Request["Action"] as string;
            string Message = string.Empty;
            switch (Action)
            {
                case "TLA":
                    Message = TLATest();
                    break;
            }
            Response.Clear();
            Response.Write(Message);
            Response.End();
        }

        public string TLATest()
        {
            string sMessage = string.Empty;
            string FF = Convert.ToString(Request["FF"]);
            sMessage = FF + "_" + DateTime.Now; 
            return sMessage;
        }
    }
}