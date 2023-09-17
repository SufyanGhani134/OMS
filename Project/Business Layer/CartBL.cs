using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Business_Layer
{
    public partial class BL
    {
        public string UpdateCart(Cart cart)
        {
            try
            {
                string response = DL.AddCart(cart);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateCart in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public void AddCartItem(CartItem cartItem)
        {
            try
            {
                DL.AddCartItem(cartItem);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddCartItem in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public void UpdateCartItem(int cartItemID)
        {
            try
            {
                DL.UpdateCartItem(cartItemID);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateCartItem in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void RemoveCartItem(int cartItemID)
        {
            try
            {
                DL.RemoveCartItem(cartItemID);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in RemoveCartItem in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public List<CartItem> GetCartItems(int cartID)
        {
            try
            {
                DataTable cartItemsTable = new DataTable();
                List<CartItem> cartItems = new List<CartItem>();
                cartItemsTable = DL.GetCartItems(cartID);

                if (cartItemsTable != null && cartItemsTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in cartItemsTable.Rows)
                    {
                        CartItem cartItem = new CartItem();
                        cartItem.title = dataRow["title"].ToString();
                        cartItem.poster = dataRow["poster"].ToString();
                        cartItem.unitCost = Convert.ToInt32(dataRow["unitCost"]);
                        cartItem.generatedDate = Convert.ToDateTime(dataRow["generatedDate"]);
                        cartItem.isCheck = (bool)dataRow["isCheck"];
                        cartItems.Add(cartItem);
                    }
                }
                return cartItems;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetCartItems in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}