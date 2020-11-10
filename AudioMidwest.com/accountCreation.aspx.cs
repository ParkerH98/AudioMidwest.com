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
    public partial class accountCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}