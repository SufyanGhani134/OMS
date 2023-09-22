using Project.Business_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class SiteMaster : MasterPage
    {
        public string email { get; set; }
        public string password { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.EndsWith("Home", StringComparison.InvariantCultureIgnoreCase) ||
                Request.Url.AbsolutePath.Equals("/", StringComparison.InvariantCultureIgnoreCase))
            {
                signUpBtn.Visible = true;
            }
            else
            {
                signUpBtn.Visible = false;
            }

            if (Request.Url.AbsolutePath.EndsWith("UserPage", StringComparison.InvariantCultureIgnoreCase) ||
                Request.Url.AbsolutePath.EndsWith("Admin", StringComparison.InvariantCultureIgnoreCase)
                || Request.Url.AbsolutePath.StartsWith("/UserPage/", StringComparison.InvariantCultureIgnoreCase)
                || Request.Url.AbsolutePath.StartsWith("/Admin/", StringComparison.InvariantCultureIgnoreCase))
            {
                logInBtn.Visible = false;
                logOutBtn.Visible = true;
                signUpBtn.Visible = false;
            }
        }

        


        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage");
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["IsLoggedIn"] = null;
            Response.Redirect("/");
        }

    }
}