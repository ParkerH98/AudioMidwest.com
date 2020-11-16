using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AudioMidwest.com
{
    public partial class cart : System.Web.UI.Page
    {
        private CartItemList shoppingCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] != null)
            {
                btnSignOut.Visible = true;
                modifyAcctDD.Visible = true;
                loginDD.Visible = false;
                CreateAcctDD.Visible = false;
            }
            else
            {
                btnSignOut.Visible = false;
                modifyAcctDD.Visible = false;
                loginDD.Visible = true;
                CreateAcctDD.Visible = true;
            }

            shoppingCart = CartItemList.GetCart();

            if (!IsPostBack)
            {
                this.DisplayCart();
            }
        }

        private void DisplayCart()
        {
            //remove all items from listbox
            lboxCartsummary.Items.Clear();

            //loop and add each item to the list
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                lboxCartsummary.Items.Add(shoppingCart[i].Display());
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["SignOutMsg"] = "You have been successfully signed out.";

            User currentUser = (User)Session["currentUser"];
            currentUser.FirstName = null;
            currentUser.LastName = null;
            currentUser.PrimaryAddress = null;
            currentUser.SecondaryAddress = null;
            currentUser.City = null;
            currentUser.StateID = 1;
            currentUser.Zipcode = null;
            currentUser.PhoneNumber = null;
            currentUser.Username = null;
            currentUser.UserPassword = null;
            currentUser.RecoveryEmail = null;
            Session["currentUser"] = null;

            Response.Redirect("~/login.aspx");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/products.aspx");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                //remove item and display cart
                shoppingCart.RemoveAt(lboxCartsummary.SelectedIndex);
                this.DisplayCart();
            }
            else
            {
                //if no item was selected
                //display error message
            }
        }

        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                shoppingCart.Clear();
                lboxCartsummary.Items.Clear();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

            if (Session["currentUser"] != null)
            {
                Response.Redirect("~/shipping.aspx");
            }
            else
            {
                Session["logMsg"] = "Please login before continuing to checkout,";
                Response.Redirect("~/login.aspx");
            }

           
        }
    }
}