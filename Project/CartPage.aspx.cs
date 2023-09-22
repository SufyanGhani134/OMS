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
    public partial class CartPage : System.Web.UI.Page
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
            }
            else
            {
                Response.Redirect("/Home");
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Object> GetCartItems(int cartID)
        {
            try
            {
                BL cartBL = new BL();
                List<CartItem> cartItems = cartBL.GetCartItems(cartID);
                List<Object> response = new List<Object>();
                foreach (CartItem item in cartItems)
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

        [WebMethod]
        public static string UpdateCartItems(List<int> cartItemIDs)
        {
            try
            {
                BL cartBL = new BL();
               cartBL.UpdateCartItem(cartItemIDs);

                return "Received array: " + string.Join(", ", cartItemIDs); 
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in LogInPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [WebMethod]
        public static string UpdateCart(int cartID, float totalCost)
        {
            try
            {
                BL cartBL = new BL();
                string response = cartBL.UpdateCart(cartID, totalCost);

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