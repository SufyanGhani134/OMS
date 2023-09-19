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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string SignUp(string user)
        {
            JObject User = JObject.Parse(user);
            User newUser = User.ToObject<User>();

            try {
                BL userBL = new BL();
                string response = userBL.InsertUser(newUser);

                return response;
            }catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in SignUPPage due to "
                   + exception.Message, exception.InnerException);
            }
             
        }
        
    }
}