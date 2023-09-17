using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
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
                cart.Visible = true;
            }
        }
        protected void LoggingBtn_Click(object sender, EventArgs e)
        {
            email = Email.Text;
            password = Password.Text;
            Response.Write($"<script>console.log('{email.ToString()}', '{password.ToString()}')</script>");
            logOutBtn.Visible = true;
            Response.Redirect("UserPage");
        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage");
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home");
        }
    }
}