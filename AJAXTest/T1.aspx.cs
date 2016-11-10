using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJAXTest
{
    public partial class T1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession=true)]
        public static string TLBTest(string Action, string FF)
        {
            return Action + "_" + FF + "_" + DateTime.Now;
        }
    }
}