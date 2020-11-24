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