using Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Cart
    {
        public int cartID { get; set; }

        public int userID { get; set; }
        public List<Movie> product { get; set; }
        public float totalCost { get; set; }
        public DateTime generatedDate { get; set; }

        public int GetCartId(int userID)
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

        public string UpdateCart(int cartID, float totalCost)
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

        public List<CartItem> GetCartItems(int cartID)
        {
            try
            {
                BL cartBL = new BL();
                List<CartItem> cartItems = cartBL.GetCartItems(cartID);

                return cartItems;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in Cart Class due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}