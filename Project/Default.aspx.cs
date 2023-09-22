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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Object> GetSearchMovies(string title)
        {
            try
            {
                BL cartBL = new BL();
                List<Movie> movies = cartBL.GetSearchMovies(title);
                List<Object> response = new List<Object>();
                foreach (Movie item in movies)
                {
                    response.Add((Object)item);
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in LogInPage due to "
                   + exception.Message, exception.InnerException);
            }
        }


    }
}