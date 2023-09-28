using Project.Data_Layer;
using Project.Models;
using Project.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project.Business_Layer
{
    public partial class BL
    {
        public string InsertUser(User user)
        {
            try
            {
                string response = DL.CreateUser(user);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in CreateUser in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public int UserLogIn(string email, string password)
        {
            try
            {
                int response = DL.UserLogIn(email, password);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserLogIn in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public User GetUser(int userID)
        {
            try
            {
                DataTable userTable = new DataTable();
                User user = new User();
                userTable = DL.GetUser(userID);
                if (userTable != null && userTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in userTable.Rows)
                    {
                        user.firstName = dataRow["firstName"].ToString();
                        user.lastName = dataRow["lastName"].ToString();
                        user.dob = Convert.ToDateTime( dataRow["dob"]);
                        user.UserID = userID;
                        if(Convert.ToInt32(dataRow["roleID"]) == 1)
                        {
                            user.Status = "Admin";
                        }
                        else
                        {
                            user.Status = "Customer";
                        }
                    }
                }
                return user;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetUser in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}