using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class AdminPage : System.Web.UI.Page
    {
        public string genre;
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
            }
            else
            {
                Response.Redirect("/Home");
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<string> GetAllGenres()
        {
            try
            {
                BL genreBL = new BL();
                List<string> response = genreBL.GetAllGenres();
                //string response = JsonConvert.SerializeObject(genres);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AdminPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [WebMethod]
        public static string AddMovie(string movie)
        {
            JObject Movie = JObject.Parse(movie);

            Movie newMovie = Movie.ToObject<Movie>();
            try
            {
                BL movieBL = new BL();
                string response = movieBL.AddMovie(newMovie);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AdminPage due to "
                   + exception.Message, exception.InnerException);
            }
        }


    }
}