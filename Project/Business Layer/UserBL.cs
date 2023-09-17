using Project.Models;
using System;
using System.Collections.Generic;
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

        public bool UserLogIn(string email, string password)
        {
            try
            {
                bool response = DL.UserLogIn(email, password);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserLogIn in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}