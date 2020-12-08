using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace AudioMidwest.com
{
    public partial class accountCreation : System.Web.UI.Page
    {
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
        }

        protected void btnCreateAcct_Click(object sender, EventArgs e)
        {
            //creates db connection string
            string strConnection = ConfigurationManager.ConnectionStrings["F20_ksphagueConnectionString"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                try
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

                    Session["CreateAccountMsg"] = "Your account has successfully been created. Please login.";
                    Response.Redirect("~/login.aspx");
                }
                catch (SqlException ex)
                {

                    if (ex.Number == 2627)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "The email address " + tboxEmail.Text + " already exists in our records. Please enter a different email or sign in.";
                    }

                }
                catch (Exception ex)
                {


                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;


                }
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
    }
}