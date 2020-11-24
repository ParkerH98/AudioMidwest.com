﻿using System;
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
    public partial class accountCreation : System.Web.UI.Page
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

        protected void btnCreateAcct_Click(object sender, EventArgs e)
        {
            //creates db connection string
            string strConnection = ConfigurationManager.ConnectionStrings["F20_ksphagueConnectionString"].ToString();

            using(SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                sqlConnection.Open();
                
                SqlCommand InsertCmd = new SqlCommand("spInsertCredentials", sqlConnection);
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
                InsertCmd.Parameters.AddWithValue("@RecoveryEmail", tboxAccountRecoveryEmail.Text);
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