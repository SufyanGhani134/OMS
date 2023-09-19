using Newtonsoft.Json;
using Project.Business_Layer;
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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string GetAllGenres()
        {
            try
            {
                BL movieBL = new BL();
                List<string> genres = movieBL.GetAllGenres();
                string response = JsonConvert.SerializeObject(genres);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserPage due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}