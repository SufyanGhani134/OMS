using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class CartItem
    {
        public int itemId { get; set; }

        private int cartID { get; set; }
        public string title { get; set; }
        public string poster { get; set; }
        public string generatedDate { get; set; }
        public int unitCost { get; set; }
        public bool isCheck { get; set; }

        public int CartID
        {
            get { return cartID; }
            set { cartID = value; }
        }
    }
}