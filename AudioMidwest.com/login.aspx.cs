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

            if (Session["logMsg"] != null)
            {
                lblMessage.Text = Session["logMsg"].ToString();
                Session["logMsg"] = null;
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

        protected void btnCreateAccoount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/accountCreation.aspx");
        }
    }
}