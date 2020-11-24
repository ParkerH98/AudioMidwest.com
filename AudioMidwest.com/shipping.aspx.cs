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
    public partial class shipping : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["currentUser"];

            //creates db connection string
            string strConnection = ConfigurationManager.ConnectionStrings["F20_ksphagueConnectionString"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand InsertCmd = new SqlCommand("spInsertMyOrder", sqlConnection);
                InsertCmd.CommandType = CommandType.StoredProcedure;

                //input variables for each attribute in user table
                InsertCmd.Parameters.AddWithValue("@AccountNumber", currentUser.UserID);
                InsertCmd.Parameters.AddWithValue("@CustomerFirstName", tboxFirstName.Text);
                InsertCmd.Parameters.AddWithValue("@CustomerLastName", tboxLastName.Text);
                InsertCmd.Parameters.AddWithValue("@ShippingAddress", tboxPrimaryAddress.Text);
                InsertCmd.Parameters.AddWithValue("@ShippingCity", tboxCity.Text);
                InsertCmd.Parameters.AddWithValue("@ShippingState", ddlStates.SelectedValue);
                InsertCmd.Parameters.AddWithValue("@ShippingZip", tboxZip.Text);

                //create an output parameter to get an OH ID
                SqlParameter OHIDOutput = new SqlParameter("@OrderNumber", SqlDbType.Int);
                OHIDOutput.Direction = ParameterDirection.Output;
                InsertCmd.Parameters.Add(OHIDOutput);


                //call method to insert item from cart into database
                InsertCmd.Parameters.Add("@OrderItems", SqlDbType.Structured).Value = GetCartItemData();

                try
                {
                    sqlConnection.Open();
                    InsertCmd.ExecuteNonQuery();

                    Session["OrderID"] = OHIDOutput.Value.ToString();
                    Session["shopping"] = null;
                    Response.Redirect("~/thankYou.aspx");
                }
                catch (Exception ex)
                {

                    //show error message
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private DataTable GetCartItemData()
        {
            CartItemList cart = CartItemList.GetCart();

            //instantiate our data table
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("ProductQuantity", typeof(int));
            dt.Columns.Add("UnitPrice", typeof(int));

            //loop through cart and add each to table
            for (int i = 0; i < cart.Count; i++)
            {
                dt.Rows.Add(cart[i].Product.ProductID, cart[i].Quantity, cart[i].Product.UnitPrice);
            }
            return dt;
        }
    }
}