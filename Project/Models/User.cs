using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class User
    {
        private int userID;
        public string firstName;
        public string lastName;
        public DateTime dob;
        private string email;
        private string password;
        private string status;
        public Cart cart;

        public User() 
        {
            this.cart = new Cart();
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public int UserLogIn(string email, string password)
        {
            try
            {
                BL userBL = new BL();
                int response = userBL.UserLogIn(email, password);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UserLogIn due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public User GetUser(int UserID)
        {
            try
            {
                BL userBL = new BL();
                User loggedUser = userBL.GetUser(UserID);

                return loggedUser;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetUser due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string SignUp(User user)
        {

            try
            {
                BL userBL = new BL();
                string response = userBL.InsertUser(user);

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in SignUp due to "
                   + exception.Message, exception.InnerException);
            }

        }

        public string AddSearchHistory(int userID, List<string> genres)
        {
            try
            {
                BL suggestionBL = new BL();
                string response = suggestionBL.AddSearchHistory(userID, genres);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddSearch due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}