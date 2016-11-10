using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheInfo
{
    public partial class 缓存依赖 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Web.Caching.Cache
            //HttpRuntime.Cache
            if(!IsPostBack)
            {
                ////绝对过期
                //Cache.Insert("FKK", "2234", null, DateTime.UtcNow.AddSeconds(10), System.Web.Caching.Cache.NoSlidingExpiration);
                ////滑动过期
                //Cache.Insert("MKK", "7890", null,System.Web.Caching.Cache.NoAbsoluteExpiration,TimeSpan.FromSeconds(10));

                ////绝对过期
                //Cache.Insert("FKK", "2234", null, DateTime.UtcNow.AddSeconds(10), System.Web.Caching.Cache.NoSlidingExpiration);
                ////滑动过期 缓存依赖(缓冲键)
                //CacheDependency dep = new CacheDependency(null, new string[] { "FKK"});
                //Cache.Insert("MKK", "7890", dep, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10));

                
                ////滑动过期 缓存依赖(文件)
                //CacheDependency dep = new CacheDependency(AppDomain.CurrentDomain.BaseDirectory + "Web.config");
                //Cache.Insert("MKK", "7890", null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(120));

                ////绝对过期 缓存依赖(移除后通知)
                //Cache.Insert("FKK", "2234", null, DateTime.UtcNow.AddSeconds(10), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, Show);

                ////绝对过期 缓存依赖(移除前通知)
                //Cache.Insert("FKK", "2234", null, DateTime.UtcNow.AddSeconds(10), System.Web.Caching.Cache.NoSlidingExpiration,OnShow);
            }
            
        }

        public void Show(string key, object value, CacheItemRemovedReason reason)
        {
            Cache.Insert(key, "新价值" + value);
        }

        public void OnShow(string key, CacheItemUpdateReason reason, out object expensiveObject, out CacheDependency dependency, out DateTime absoluteExpiration, out TimeSpan slidingExpiration)
        {
            expensiveObject = "http://www.cnblogs.com/fish-li/";
            dependency = null;
            absoluteExpiration = Cache.NoAbsoluteExpiration;
            slidingExpiration = Cache.NoSlidingExpiration;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Write(Cache["FKK"] + "__" + Cache["MKK"]);
        }
    }
}