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
            routes.MapPageRoute("HomeRoute", "Home", "~/Default.aspx");
            routes.MapPageRoute("SignUpPageRoute", "SignUpPage", "~/SignUpPage.aspx");
            routes.MapPageRoute("UserPageRoute", "UserPage", "~/UserPage.aspx");
            routes.MapPageRoute("CartPageRoute", "UserPage/Cart", "~/CartPage.aspx");
            routes.MapPageRoute("AdminRoute", "Admin", "~/AdminPage.aspx");

            routes.RouteExistingFiles = false;
        }
    }
}
