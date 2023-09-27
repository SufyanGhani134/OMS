using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Project.Business_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack) 
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

       
        

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Object> GetAllMovies()
        {
            try
            {
                BL movieBL = new BL();
                List<Movie> movies = movieBL.GetAllMovies();
                List<Object> response = new List<Object>();
                foreach (Movie movie in movies)
                {
                    response.Add((Object)movie);
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static int GetCartId(int userID)
        {
            try
            {
                BL cartBL = new BL();
                int cartID = cartBL.GetCartId(userID);
                return cartID;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [WebMethod]
        public static string AddCartItem(CartItem cartItem)
        {
            try
            {
                BL cartBL = new BL();
                string response = cartBL.AddCartItem(cartItem);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddCartItem due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [WebMethod]
        public static string AddSearchHistory(int userID, List<string> genres)
        {
            try
            {
                BL suggestionBL = new BL();
                string response = suggestionBL.AddSearchHistory(userID, genres);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddSearch due to "
                   + exception.Message, exception.InnerException);
            }
        }

        
    }
}