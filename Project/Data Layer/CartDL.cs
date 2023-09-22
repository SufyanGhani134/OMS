using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Data_Layer
{
    public partial class DL
    {
        public string AddCart(Cart cart)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddCart", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userID", cart.userID);
                    command.Parameters.AddWithValue("@totalCost", cart.totalCost);
                    command.Parameters.AddWithValue("@generatedDate", cart.generatedDate);
                    command.Parameters.Add("@PKID", SqlDbType.Int, 32);
                    command.Parameters["@PKID"].Direction = ParameterDirection.Output;

                    con.Open();
                    command.ExecuteNonQuery();
                    response = Convert.ToString(command.Parameters["@PKID"].Value);
                    con.Close();
                    return response;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddCart in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string AddCartItem(CartItem cartItem)
        {
            string response = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("AddCartItems", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cartID", cartItem.CartID);
                    command.Parameters.AddWithValue("@title", cartItem.title);
                    command.Parameters.AddWithValue("@generatedDate", cartItem.generatedDate);
                    command.Parameters.AddWithValue("@poster", cartItem.poster);
                    command.Parameters.AddWithValue("@isCheck", false);
                    command.Parameters.AddWithValue("@unitCost", cartItem.unitCost);
                    command.Parameters.Add("@PKID", SqlDbType.Int, 32);
                    command.Parameters["@PKID"].Direction = ParameterDirection.Output;

                    con.Open();
                    command.ExecuteNonQuery();
                    if(Convert.ToString(command.Parameters["@PKID"].Value) != null)
                    {
                        response = "Movie Added To Cart Successfully!";
                    }
                    else
                    {
                        response = "Error!";
                    }
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddCartItem in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void UpdateCartItem(int cartItemID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateCartItem", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cartItemID", cartItemID);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateCartItem in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void UpdateCart(int cartID, float totalCost)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateCart", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cartID", cartID);
                    command.Parameters.AddWithValue("@totalCost", totalCost);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateCartItem in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void RemoveCartItem(int cartItemID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("RemoveCartItem", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cartID", cartItemID);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in RemoveCartItem in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public DataTable GetCartItems(int cartID)
        {
            try
            {
                DataTable cartItemsTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetCartItems", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cartID", cartID);


                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(cartItemsTable);
                    con.Close();
                }
                return cartItemsTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetCartItems in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public DataTable GetCartId(int userID)
        {
            try
            {
                DataTable cartIdTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetCartId", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("userID", userID);


                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(cartIdTable);
                    con.Close();
                }
                return cartIdTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetCartItems in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }
    }
}
