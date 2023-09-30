using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class HistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggedUser"] != null)
                {
                    Page.Master.FindControl("signUpBtn").Visible = false;
                    Page.Master.FindControl("logInBtn").Visible = false;
                    Page.Master.FindControl("logOutBtn").Visible = true;
                }
                else
                {
                    Response.Redirect("/Home");
                }
            }
        }
    }
}