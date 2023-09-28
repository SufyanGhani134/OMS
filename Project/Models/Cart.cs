using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Cart
    {
        public int cartID { get; set; }

        public int userID { get; set; }
        public List<Movie> product { get; set; }
        public float totalCost { get; set; }
        public DateTime generatedDate { get; set; }

        
    }
}