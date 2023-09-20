using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Project
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("DefaultRoute", "", "~/Default.aspx");
            routes.MapPageRoute("SignUpPageRoute", "SignUpPage", "~/SignUpPage.aspx");
            routes.MapPageRoute("UserHomePageRoute", "UserPage/{id}/Home", "~/UserPage.aspx");
            routes.MapPageRoute("CartPageRoute", "UserPage/Cart", "~/CartPage.aspx");
            routes.MapPageRoute("AdminHomeRoute", "Admin/{id}/Home", "~/AdminPage.aspx");
            routes.MapPageRoute("AdminRoute", "Admin/{id}", "~/AdminPage.aspx");


            routes.RouteExistingFiles = false;

            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Off;
            routes.EnableFriendlyUrls(settings);

        }
    }
}
