using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BouncyCastles.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Uncomment to set Dutch
        //private void Application_BeginRequest(Object source, EventArgs e)
        //{
        //    HttpApplication application = (HttpApplication)source;
        //    HttpContext context = application.Context;

        //    if (context.Request.UserLanguages != null && Request.UserLanguages.Length > 0)
        //    {               
        //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-nl");
        //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("nl-nl");
        //    }
        //}
    }
}
