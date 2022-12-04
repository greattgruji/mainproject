using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace fareforall
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(@System.Configuration.ConfigurationManager.AppSettings["isSSL"]) && isLocalhost() && Request.Url.ToString().IndexOf("test.") == -1)
            {
                //if (Request.Url.Authority.StartsWith("www") == false)
                //{
                //    var url = string.Format("{0}://www.{1}{2}", Request.Url.Scheme, Request.Url.Authority, Request.Url.PathAndQuery);
                //    Response.RedirectPermanent(url, true);
                //}
                //string path = HttpContext.Current.Request.Url.AbsolutePath;
                if (HttpContext.Current.Request.IsSecureConnection == false)
                {
                    Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.RawUrl);
                }
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Core.FlightUtility.LoadMasterData();
        }
        protected bool isLocalhost()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            if (VisitorsIPAddr == "" || VisitorsIPAddr == "127.0.0.1" || VisitorsIPAddr == "::1")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
