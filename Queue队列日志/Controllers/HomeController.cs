using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Queue队列日志.Controllers
{
    public class HomeController : Controller
    {
        protected ILog _log = log4net.LogManager.GetLogger(typeof(HomeController));
        //
        // GET: /Home/

        public ActionResult Index()
        {
            _log.Info("测试啊");
            return View();
        }

    }
}
