using Newtonsoft.Json.Linq;
using Project.Business_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        public bool isValid;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Master.FindControl("signUpBtn").Visible = false;
        }


        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.firstName = fname.Text;   
            user.lastName = lname.Text;
            user.dob = Convert.ToDateTime(dob.Text);
            user.Email = email.Text;
            user.Password = password.Text;

            string response = user.SignUp(user);
            if (response == "User Already Exists!")
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                  "ShowAlert('" + isValid + "');", true);
        }
    }
}