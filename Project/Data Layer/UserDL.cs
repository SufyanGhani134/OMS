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
        public string CreateUser(User user)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("CreateUser", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstName", user.firstName);
                    command.Parameters.AddWithValue("@lastName", user.lastName);
                    command.Parameters.AddWithValue("@dob", user.dob);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.Add("@PKID", SqlDbType.Int, 32);
                    command.Parameters["@PKID"].Direction = ParameterDirection.Output;
                    Cart newCart = new Cart();
                    newCart.userID = Convert.ToInt32(command.Parameters["@PKID"].Value);
                    newCart.totalCost = 0;
                    newCart.generatedDate = DateTime.Now;
                    DL newCartDL = new DL();
                    newCartDL.AddCart(newCart);

                    con.Open();
                    command.ExecuteNonQuery();
                    response = Convert.ToString(command.Parameters["@PKID"].Value);
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in CreateUser in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public bool UserLogIn(string email, string password)
        {
            try
            {
                bool response = true;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UserValidation", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters["@isValidUser"].Direction = ParameterDirection.Output;


                    con.Open();
                    command.ExecuteNonQuery();
                    response = (bool)command.Parameters["@isValidUser"].Value;
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserLogIn in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }
    }
}