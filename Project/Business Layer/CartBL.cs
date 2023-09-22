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
        public int cartID;
        public string UpdateCart(int cartID, float totalCost)
        {
            try
            {
                DL.UpdateCart(cartID, totalCost);
                return "cart updated!!";
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateCart in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public string  AddCartItem(CartItem cartItem)
        {
            try
            {
               string response = DL.AddCartItem(cartItem);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddCartItem in BL due to "
                   + exception.Message, exception.InnerException);

            }
        }

        public void UpdateCartItem(List<int> cartItemIDs)
        {
            try
            {
                foreach (int id in cartItemIDs)
                {
                    DL.UpdateCartItem(id);
                }
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
                        cartItem.CartID = Convert.ToInt32(dataRow["cartID"]);
                        cartItem.itemId =Convert.ToInt32(dataRow["cartItemID"]);
                        cartItem.title = dataRow["title"].ToString();
                        cartItem.poster = dataRow["poster"].ToString();
                        cartItem.unitCost = Convert.ToInt32(dataRow["unitCost"]);
                        cartItem.generatedDate = (dataRow["generatedDate"]).ToString();
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

        public int GetCartId(int userID)
        {
            
            try
            {
                DataTable cartIdTable = new DataTable();
                cartIdTable = DL.GetCartId(userID);

                if (cartIdTable != null && cartIdTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in cartIdTable.Rows)
                    {
                         cartID = Convert.ToInt32(dataRow["cartID"]);
                    }
                }
                return cartID;
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