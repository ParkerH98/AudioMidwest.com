using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AudioMidwest.com
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user is signed in, hide/display various navigation links in navbar and footer
            if (Session["currentUser"] != null)
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
    }
}