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
            //if user is signed in, hide/display various navigation links in navbar and footer
            if (Request.Cookies["FirstName"] != null)
            {
                btnSignOut.Visible = true;
                modifyAcctDD.Visible = true;
                loginDD.Visible = false;
                CreateAcctDD.Visible = false;
                footerLogin.Visible = false;
                footerCreateAccount.Visible = false;
                footerAccountmodification.Visible = true;
                footerSignout.Visible = true;
            }
            else
            {
                btnSignOut.Visible = false;
                modifyAcctDD.Visible = false;
                loginDD.Visible = true;
                CreateAcctDD.Visible = true;
                footerLogin.Visible = true;
                footerCreateAccount.Visible = true;
                footerAccountmodification.Visible = false;
                footerSignout.Visible = false;
            }

            shoppingCart = CartItemList.GetCart();

            lblMessage.Visible = false;

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

            HttpCookie cookieCurrentUser = new HttpCookie("currentUser");
            cookieCurrentUser.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUser);

            HttpCookie cookieCurrentUserFirstName = new HttpCookie("FirstName");
            cookieCurrentUserFirstName.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserFirstName);

            HttpCookie cookieCurrentUserLastName = new HttpCookie("LastName");
            cookieCurrentUserLastName.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserLastName);

            HttpCookie cookieCurrentUserPrimaryAddress = new HttpCookie("PrimaryAddress");
            cookieCurrentUserPrimaryAddress.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserPrimaryAddress);

            HttpCookie cookieCurrentUserSecondaryAddress = new HttpCookie("SecondaryAddress");
            cookieCurrentUserSecondaryAddress.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserSecondaryAddress);

            HttpCookie cookieCurrentUserCity = new HttpCookie("City");
            cookieCurrentUserCity.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserCity);

            HttpCookie cookieCurrentUserStateID = new HttpCookie("StateID");
            cookieCurrentUserStateID.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserStateID);

            HttpCookie cookieCurrentUserZip = new HttpCookie("Zip");
            cookieCurrentUserZip.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserZip);

            HttpCookie cookieCurrentUserPhoneNumber = new HttpCookie("PhoneNumber");
            cookieCurrentUserPhoneNumber.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserPhoneNumber);

            HttpCookie cookieCurrentUserEmail = new HttpCookie("Email");
            cookieCurrentUserEmail.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserEmail);

            HttpCookie cookieCurrentUserRecoveryEmail = new HttpCookie("RecoveryEmail");
            cookieCurrentUserRecoveryEmail.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserRecoveryEmail);

            HttpCookie cookieCurrentUserPassword = new HttpCookie("UserPassword");
            cookieCurrentUserPassword.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookieCurrentUserPassword);

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
                lblMessage.Visible = true;
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

            if (shoppingCart.Count > 0)
            {
                if (Request.Cookies["FirstName"] != null)
                {
                    Response.Redirect("~/shipping.aspx");
                }
                else
                {
                    Session["logMsg"] = "Please login before continuing to checkout.";
                    Response.Redirect("~/login.aspx");
                } 
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please select an item before checking out.";
            }
        }
    }
}