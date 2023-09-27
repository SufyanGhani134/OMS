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
            int isLoggedIn = Convert.ToInt32(HttpContext.Current.Session["IsLoggedIn"]);
            string currentUrl = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            string[] userIDArr = currentUrl.Split(new char[] { '/' });
            if (userIDArr.Length > 4)
            {
                int userID = Convert.ToInt32(userIDArr[4]);
                if (userID != isLoggedIn)
                {
                    Response.Redirect("/Home");
                }
                else
                {
                    Page.Master.FindControl("signUpBtn").Visible = false;
                    Page.Master.FindControl("logInBtn").Visible = false;
                    Page.Master.FindControl("logOutBtn").Visible = true;

                }
            }
            else
            {
                Response.Redirect("/Home");
            }
        }
    }
}