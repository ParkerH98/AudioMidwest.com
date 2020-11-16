using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AudioMidwest.com
{
    public partial class shipping : System.Web.UI.Page
    {
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

            if (!IsPostBack)
            {
                if (Session["currentUser"] != null)
                {
                    User currentUser = (User)Session["currentUser"];
                    tboxFirstName.Text = currentUser.FirstName;
                    tboxLastName.Text = currentUser.LastName;
                    tboxPrimaryAddress.Text = currentUser.PrimaryAddress;
                    tboxSecondaryAddress.Text = currentUser.SecondaryAddress;
                    tboxCity.Text = currentUser.City;
                    ddlStates.SelectedValue = currentUser.StateID.ToString();
                    tboxZip.Text = currentUser.Zipcode;
                }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["shopping"] = null;
            Response.Redirect("~/thankYou.aspx");
        }
    }
}