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
        public string password { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
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