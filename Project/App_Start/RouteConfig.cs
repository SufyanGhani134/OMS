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
            routes.MapPageRoute("UserPageRoute", "UserPage/{id}/", "~/UserPage.aspx");
            routes.MapPageRoute("UserHomePageRoute", "UserPage/{id}/Home", "~/UserPage.aspx");
            routes.MapPageRoute("CartPageRoute", "UserPage/{id}/Cart", "~/CartPage.aspx");
            routes.MapPageRoute("HistoryRoute", "UserPage/{id}/History", "~/HistoryPage.aspx");
            routes.MapPageRoute("AdminHomeRoute", "Admin/{id}/Home", "~/AdminPage.aspx");
            routes.MapPageRoute("AdminRoute", "Admin/{id}/", "~/AdminPage.aspx");
            routes.MapPageRoute("AdminCartRoute", "Admin/{id}/Cart", "~/CartPage.aspx");
            routes.MapPageRoute("AdminHistoryRoute", "Admin/{id}/History", "~/CartPage.aspx");





            routes.RouteExistingFiles = false;

            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Off;
            routes.EnableFriendlyUrls(settings);

        }
    }
}
