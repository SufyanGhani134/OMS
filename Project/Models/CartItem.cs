using Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class CartItem
    {
        public int itemId { get; set; }

        private int cartID { get; set; }
        public string title { get; set; }
        public string poster { get; set; }
        public string generatedDate { get; set; }
        public int unitCost { get; set; }
        public bool isCheck { get; set; }

        public int CartID
        {
            get { return cartID; }
            set { cartID = value; }
        }

        public string AddCartItem(CartItem cartItem)
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
                   + " is encountered in CartItem Class due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}