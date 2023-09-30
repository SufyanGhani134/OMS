﻿using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Project.Business_Layer;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {

                if (Session["loggedUser"] != null)
                {
                    Page.Master.FindControl("signUpBtn").Visible = false;
                    Page.Master.FindControl("logInBtn").Visible = false;
                    Page.Master.FindControl("logOutBtn").Visible = true;
                }
                else
                {
                    Response.Redirect("/Home");
                }
            }
            else
            {
                if(removeItemID.Value != "")
                {
                    int removeID = Convert.ToInt32(removeItemID.Value);
                    CartItem item = new CartItem();
                    string response = item.RemoveCartItem(removeID);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                      "AlertMsg('" + response + "');", true);
                }
                
            }
            
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Object> GetCartItems(int cartID)
        {
            try
            {
                BL cartBL = new BL();
                List<CartItem> cartItems = cartBL.GetCartItems(cartID);
                List<Object> response = new List<Object>();
                foreach (CartItem item in cartItems)
                {
                    response.Add((Object)item);
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in LogInPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [WebMethod]
        public static string UpdateCart(int cartID, float totalCost)
        {
            try
            {
                BL cartBL = new BL();
                string response = cartBL.UpdateCart(cartID, totalCost);

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in LogInPage due to "
                   + exception.Message, exception.InnerException);
            }
        }

        
        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            List<int> checkedIDs = JsonConvert.DeserializeObject<List<int>>(checkedItems.Value);
            float UpdatedTotalCost = float.Parse(updatedTotalCost.Value);
            int UpdatedCartID = Convert.ToInt32(updatedCartID.Value);
            CartItem cartItem = new CartItem();
            cartItem.UpdateCartItems(checkedIDs);
            Cart cart = new Cart();
            cart.UpdateCart(UpdatedCartID, UpdatedTotalCost);
            total.Text = UpdatedTotalCost.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                  "DisplayReceipt();", true);
        }

    }
}