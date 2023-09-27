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
                    bool isUser = emailValidation(user.Email);
                    if(!isUser)
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


                        con.Open();
                        command.ExecuteNonQuery();
                        response = Convert.ToString(command.Parameters["@PKID"].Value);
                        con.Close();

                        Cart newCart = new Cart();
                        newCart.userID = Convert.ToInt32(response);
                        newCart.totalCost = 0;
                        newCart.generatedDate = DateTime.Now;
                        DL newCartDL = new DL();
                        newCartDL.AddCart(newCart);
                    }
                    else
                    {
                        response = "User Already Exists!";
                    }

                    
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

        public bool emailValidation(string email)
        {
            try
            {
                bool response;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    SqlCommand command = new SqlCommand("EmailValidation", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.Add("@isUser", SqlDbType.Bit);
                    command.Parameters["@isUser"].Direction = ParameterDirection.Output;


                    con.Open();
                    command.ExecuteNonQuery();
                    response = Convert.ToBoolean(command.Parameters["@isUser"].Value);
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in emailValidation in DL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public int UserLogIn(string email, string password)
        {
            try
            {
                int response;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UserValidation", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.Add("@isValidUser", SqlDbType.Int, 32);
                    command.Parameters["@isValidUser"].Direction = ParameterDirection.Output;


                    con.Open();
                    command.ExecuteNonQuery();
                    response = Convert.ToInt32(command.Parameters["@isValidUser"].Value);
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

        public DataTable GetUser(int userID)
        {
            try
            {
                DataTable userTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetUser", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userID", userID);

                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(userTable);
                    con.Close();
                }
                return userTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetUser in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }
    }
}