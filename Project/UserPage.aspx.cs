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
                if (Session["loggedUser"] != null)
                {
                    Page.Master.FindControl("signUpBtn").Visible = false;
                    Page.Master.FindControl("logInBtn").Visible = false;
                    Page.Master.FindControl("logOutBtn").Visible = true;
                    User loggedUser = (User)Session["loggedUser"];
                    Cart cart = new Cart();
                    int CartId = cart.GetCartId(loggedUser.UserID);
                    List<CartItem> cartItems = cart.GetCartItems(CartId);
                    List<CartItem> unCheckItems = new List<CartItem>();
                    foreach (CartItem item in cartItems)
                    {
                        if (!item.isCheck)
                        {
                            unCheckItems.Add(item);
                        }
                    }
                    int len = unCheckItems.Count;
                    this.Master.CartCount = "(" + len.ToString() + ")";
                }
                else
                {
                    Response.Redirect("/Home");
                }
                
           }
           else
            {
                CartItem item = JsonConvert.DeserializeObject<CartItem>(cartItems.Value);
                if (item != null)
                {
                    User user = new User();
                    User loggedUser = (User)Session["loggedUser"];
                    item.CartID = user.cart.GetCartId(loggedUser.UserID);
                    string response = user.cart.AddToCart(item);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                  "AlertMsg('" + response + "');", true);
                }
            }
        }


        [WebMethod(EnableSession = true)]
        public static int UserLogIn(string Email, string Password)
        {
            User user = new User();
            int response = user.UserLogIn(Email, Password);
            return response;
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Object> GetAllMovies()
        {
             Movie movieObj = new Movie();
             List<Movie> movies = movieObj.GetAllMovies();
             List<Object> response = new List<Object>();
             foreach (Movie movie in movies)
             {
                  response.Add((Object)movie);
             }
             return response;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static int GetCartId(int userID)
        {
              User userObj = new User();
              int cartID = userObj.cart.GetCartId(userID);
              return cartID;
        }


        [WebMethod]
        public static string AddSearchHistory(int userID, List<string> genres)
        {
             User userObj= new User();
             string response = userObj.AddSearchHistory(userID, genres);
             return response;
        }

        
    }
}