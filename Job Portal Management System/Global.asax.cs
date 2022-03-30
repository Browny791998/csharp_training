using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Job_Portal_Management_System
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", "", "~/Views/Post/PostList.aspx");
            routes.MapPageRoute("views/country/countrylist", "views/country/countrylist", "~/Views/Country/CountryList.aspx");
            routes.MapPageRoute("views/country/countrycreate", "views/country/countrycreate", "~/Views/Country/CountryCreate.aspx");
            routes.MapPageRoute("login?", "login", "~/Login.aspx");
        }
    }
}