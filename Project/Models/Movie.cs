using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Movie
    {
        public int movieId { get; set; }

        private int userID { get; set; }
        public string title { get; set; }
        public int ReleaseYear { get; set; }
        public string description { get; set; }
        public List<string> genres { get; set; }

        public string duration { get; set; }

        public float price { get; set; }
        public float ratings { get; set; }
        public string poster { get; set; }

        public List<string> resolutions { get; set; }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


    }
}