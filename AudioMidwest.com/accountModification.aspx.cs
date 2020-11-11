using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AudioMidwest.com
{
    public partial class accountModification : System.Web.UI.Page
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
                    tboxPhoneNumber.Text = currentUser.PhoneNumber;
                    tboxEmail.Text = currentUser.Username;
                    tboxPassword.Text = currentUser.UserPassword;
                }
            }
        }

        protected void btnUpdateAcct_Click(object sender, EventArgs e)
        {
            //creates db connection string
            string strConnection = ConfigurationManager.ConnectionStrings["F20_ksphagueConnectionString"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                sqlConnection.Open();

                SqlCommand InsertCmd = new SqlCommand("spUpdateAccount", sqlConnection);
                InsertCmd.CommandType = CommandType.StoredProcedure;

                //input variables for each attribute in user table
                InsertCmd.Parameters.AddWithValue("@FirstName", tboxFirstName.Text);
                InsertCmd.Parameters.AddWithValue("@LastName", tboxLastName.Text);
                InsertCmd.Parameters.AddWithValue("@PrimaryAddress", tboxPrimaryAddress.Text);
                InsertCmd.Parameters.AddWithValue("@SecondaryAddress", tboxSecondaryAddress.Text);
                InsertCmd.Parameters.AddWithValue("@City", tboxCity.Text);
                InsertCmd.Parameters.AddWithValue("@StateID", ddlStates.SelectedValue);
                InsertCmd.Parameters.AddWithValue("@Zipcode", tboxZip.Text);
                InsertCmd.Parameters.AddWithValue("@UserName", tboxEmail.Text);
                InsertCmd.Parameters.AddWithValue("@UserPassword", tboxPassword.Text);
                InsertCmd.Parameters.AddWithValue("@PhoneNumber", tboxPhoneNumber.Text);

                InsertCmd.ExecuteNonQuery();
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