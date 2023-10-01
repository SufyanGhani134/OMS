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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Page.Request.Params.Get("__EVENTTARGET") == "LogBtn")
            {
                    string email = Email.Text;
                    string password = Password.Text;
                    User user = new User();
                    int response = user.UserLogIn(email, password);
                    User loggedUser = user.GetUser(response);
                    Session["loggedUser"] = loggedUser;
                    if (loggedUser.Status == "Admin")
                    {
                        Response.Redirect("/Admin/" + response + "/Home");
                    }
                    else
                    {
                        Response.Redirect("/UserPage/" + response + "/Home");
                    }
                            
            }
        }
        public string CartCount
        {
            get
            {
                return totalItems.Text;
            }
            set
            {
                totalItems.Text = value;
            }
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
    }
}