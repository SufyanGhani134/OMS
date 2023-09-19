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
        //public Cart userCart;

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
    }
}