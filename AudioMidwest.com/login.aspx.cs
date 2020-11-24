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
    public partial class login : System.Web.UI.Page
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

            if (Session["logMsg"] != null)
            {
                lblMessage.Text = Session["logMsg"].ToString();
                Session["logMsg"] = null;
            }

            if (Session["CreateAccountMsg"] != null)
            {
                lblMessage.Text = Session["CreateAccountMsg"].ToString();
                Session["CreateAccountMsg"] = null;
            }

            if (!IsPostBack)
            {
                if (Session["SignOutMsg"] != null)
                {
                    lblMessage.Text = Session["SignOutMsg"].ToString();
                    Session["SignOutMsg"] = null;

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //creates db connection string
            string strConnection = ConfigurationManager.ConnectionStrings["F20_ksphagueConnectionString"].ToString();

            using( SqlConnection sqlConnection = new SqlConnection(strConnection))
            {

                // creates connection to db and selects stored procedure to use
                SqlDataAdapter sqlDA = new SqlDataAdapter("spSelectUserByCredentials", sqlConnection);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;


                //parameters for sp

                SqlParameter LoginUsername = new SqlParameter("@Username", tboxUserName.Text);
                LoginUsername.Direction = ParameterDirection.Input;
                LoginUsername.DbType = DbType.String;
                sqlDA.SelectCommand.Parameters.Add(LoginUsername);

                SqlParameter LoginPassword = new SqlParameter("@UserPassword", tboxPassword.Text);
                LoginPassword.Direction = ParameterDirection.Input;
                LoginPassword.DbType = DbType.String;
                sqlDA.SelectCommand.Parameters.Add(LoginPassword);

                //create dataset to hold results of stored procedure
                DataSet ds = new DataSet();

                //executes SQL Data Adapter
                sqlDA.Fill(ds);

                //if successful
                if (ds.Tables[0].Rows.Count > 0)
                {
                    User currentUser = new User();
                    currentUser.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                    currentUser.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    currentUser.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    currentUser.PrimaryAddress = ds.Tables[0].Rows[0]["PrimaryAddress"].ToString();
                    currentUser.SecondaryAddress = ds.Tables[0].Rows[0]["SecondaryAddress"].ToString();
                    currentUser.City = ds.Tables[0].Rows[0]["City"].ToString();
                    currentUser.StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
                    currentUser.Zipcode = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                    currentUser.PhoneNumber = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    currentUser.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                    currentUser.UserPassword = ds.Tables[0].Rows[0]["UserPassword"].ToString();
                    currentUser.RecoveryEmail = ds.Tables[0].Rows[0]["RecoveryEmail"].ToString();

                    Session["currentUser"] = currentUser;

                    HttpCookie cookieCurrentUser = new HttpCookie("currentUser");
                    cookieCurrentUser.Value = currentUser.UserID.ToString();
                    cookieCurrentUser.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUser);

                    HttpCookie cookieCurrentUserFirstName = new HttpCookie("FirstName");
                    cookieCurrentUserFirstName.Value = currentUser.FirstName;
                    cookieCurrentUserFirstName.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserFirstName);

                    HttpCookie cookieCurrentUserLastName = new HttpCookie("LastName");
                    cookieCurrentUserLastName.Value = currentUser.LastName;
                    cookieCurrentUserLastName.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserLastName);

                    HttpCookie cookieCurrentUserPrimaryAddress = new HttpCookie("PrimaryAddress");
                    cookieCurrentUserPrimaryAddress.Value = currentUser.PrimaryAddress;
                    cookieCurrentUserPrimaryAddress.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserPrimaryAddress);

                    HttpCookie cookieCurrentUserSecondaryAddress = new HttpCookie("SecondaryAddress");
                    cookieCurrentUserSecondaryAddress.Value = currentUser.SecondaryAddress;
                    cookieCurrentUserSecondaryAddress.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserSecondaryAddress);

                    HttpCookie cookieCurrentUserCity = new HttpCookie("City");
                    cookieCurrentUserCity.Value = currentUser.City;
                    cookieCurrentUserCity.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserCity);

                    HttpCookie cookieCurrentUserStateID = new HttpCookie("StateID");
                    cookieCurrentUserStateID.Value = currentUser.StateID.ToString();
                    cookieCurrentUserStateID.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserStateID);

                    HttpCookie cookieCurrentUserZip = new HttpCookie("Zip");
                    cookieCurrentUserZip.Value = currentUser.Zipcode;
                    cookieCurrentUserZip.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserZip);

                    HttpCookie cookieCurrentUserPhoneNumber = new HttpCookie("PhoneNumber");
                    cookieCurrentUserPhoneNumber.Value = currentUser.PhoneNumber;
                    cookieCurrentUserPhoneNumber.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserPhoneNumber);

                    HttpCookie cookieCurrentUserEmail = new HttpCookie("Email");
                    cookieCurrentUserEmail.Value = currentUser.Username;
                    cookieCurrentUserEmail.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserEmail);

                    HttpCookie cookieCurrentUserRecoveryEmail = new HttpCookie("RecoveryEmail");
                    cookieCurrentUserRecoveryEmail.Value = currentUser.RecoveryEmail;
                    cookieCurrentUserRecoveryEmail.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserRecoveryEmail);

                    HttpCookie cookieCurrentUserPassword = new HttpCookie("UserPassword");
                    cookieCurrentUserPassword.Value = currentUser.UserPassword;
                    cookieCurrentUserPassword.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookieCurrentUserPassword);

                    // if logged in go to shipping
                    // else go to home like normal

                    Session["loggedIn"] = "true";
                    Session["visited"] = "false";

                    if (Session["shopping"] != null) {

                        if (Session["shopping"].ToString() == "true")
                        {
                            Response.Redirect("~/shipping.aspx");
                        }
                    }
                    
                    else
                    {
                        Response.Redirect("~/home.aspx");
                    }
                }
                else
                {

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

        protected void btnCreateAccoount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/accountCreation.aspx");
        }
    }
}