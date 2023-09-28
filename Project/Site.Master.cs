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
            Session["loggedUser"] = null;
            Response.Redirect("/");
        }

        protected void LoggingBtn_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;
            User user = new User();
            int response = user.UserLogIn(email, password);
            if(response != 0) 
            {
                User loggedUser = user.GetUser(response);
                Session["loggedUser"] = loggedUser;
                if(loggedUser.Status == "Admin")
                {
                    Response.Redirect("/Admin/" + response + "/Home");

                }
                else
                {
                    Response.Redirect("/UserPage/" + response + "/Home");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                  "logIn()", true);
            }
        }
    }
}