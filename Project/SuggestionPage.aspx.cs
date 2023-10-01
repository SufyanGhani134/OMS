using Project.Business_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class SuggestionPage : System.Web.UI.Page
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
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Object> GetSuggestMovies(int userID)
        {
            Movie movieObj = new Movie();
            List<Movie> movies = movieObj.GetSuggestMovies(userID);
            List<Object> response = new List<Object>();
            foreach (Movie movie in movies)
            {
                response.Add((Object)movie);
            }
            return response;
        }
    }
}