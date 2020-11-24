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
    public partial class products : System.Web.UI.Page
    {
        private Product selectedProduct;

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

        protected void btnSpeakerFocal_Click(object sender, EventArgs e)
        {
            Session["shopping"] = "true";
            selectedProduct = GetSelectedProduct(Convert.ToInt32(hidSpeakerFocal.Value));

            if (IsValid)
            {
                //get cart from session state
                CartItemList shoppingCart = CartItemList.GetCart();
                CartItem cartItem = shoppingCart[selectedProduct.ProductID];

                //check if cart is empty & either increase quantity or add to cart
                if (cartItem == null)
                {
                    //add to cart
                    shoppingCart.AddItem(selectedProduct, Convert.ToInt32(tboxSpeakerFocal.Text));
                }
                else
                {
                    //product was already in the cart
                    cartItem.AddQuantity(Convert.ToInt32(tboxSpeakerFocal.Text));
                }
            }

            Response.Redirect("~/cart.aspx");
        }

        private Product GetSelectedProduct(int productID)
        {
            //creates db connection string
            string strConnection = ConfigurationManager.ConnectionStrings["F20_ksphagueConnectionString"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {

                // creates connection to db and selects stored procedure to use
                SqlDataAdapter sqlDA = new SqlDataAdapter("spSelectProductByID", sqlConnection);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;


                //parameters for sp

                SqlParameter ProductIdInput = new SqlParameter("@ProductID", productID);
                ProductIdInput.Direction = ParameterDirection.Input;
                ProductIdInput.DbType = DbType.Int32;
                sqlDA.SelectCommand.Parameters.Add(ProductIdInput);

                //create dataset to hold results of stored procedure
                DataSet ds = new DataSet();

                //executes SQL Data Adapter
                sqlDA.Fill(ds);


                Product p = new Product();
                //if successful
                if (ds.Tables[0].Rows.Count > 0)
                {
                    p.ProductID = ds.Tables[0].Rows[0]["ProductID"].ToString();
                    p.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    p.UnitPrice = Decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                    p.ShortDesc = ds.Tables[0].Rows[0]["ShortDesc"].ToString();
                    p.LongDesc = ds.Tables[0].Rows[0]["LongDesc"].ToString();

                    int temp = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductAvailability"]);
                    if (temp == 1) p.ProductAvailability = true;
                    else p.ProductAvailability = false;

                    p.ProductInventoryQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductInventoryQuantity"]);
                    p.ProductCategory = ds.Tables[0].Rows[0]["ProductCategory"].ToString();

                }

                return p;
            }
        }

        protected void btnGoToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/cart.aspx");
        }

        protected void btnSpeakerKicker_Click(object sender, EventArgs e)
        {
            Session["shopping"] = "true";
            selectedProduct = GetSelectedProduct(Convert.ToInt32(hidSpeakerKicker.Value));

            if (IsValid)
            {
                //get cart from session state
                CartItemList shoppingCart = CartItemList.GetCart();
                CartItem cartItem = shoppingCart[selectedProduct.ProductID];

                //check if cart is empty & either increase quantity or add to cart
                if (cartItem == null)
                {
                    //add to cart
                    shoppingCart.AddItem(selectedProduct, Convert.ToInt32(tboxSpeakerKicker.Text));
                }
                else
                {
                    //product was already in the cart
                    cartItem.AddQuantity(Convert.ToInt32(tboxSpeakerKicker.Text));
                }
            }

            Response.Redirect("~/cart.aspx");
        }

        protected void btnSpeakerPhoenix_Click(object sender, EventArgs e)
        {
            Session["shopping"] = "true";
            selectedProduct = GetSelectedProduct(Convert.ToInt32(hidSpeakerPhoenix.Value));

            if (IsValid)
            {
                //get cart from session state
                CartItemList shoppingCart = CartItemList.GetCart();
                CartItem cartItem = shoppingCart[selectedProduct.ProductID];

                //check if cart is empty & either increase quantity or add to cart
                if (cartItem == null)
                {
                    //add to cart
                    shoppingCart.AddItem(selectedProduct, Convert.ToInt32(tboxSpeakerPhoenix.Text));
                }
                else
                {
                    //product was already in the cart
                    cartItem.AddQuantity(Convert.ToInt32(tboxSpeakerPhoenix.Text));
                }
            }

            Response.Redirect("~/cart.aspx");
        }

        protected void btnAmpSound_Click(object sender, EventArgs e)
        {
            Session["shopping"] = "true";
            selectedProduct = GetSelectedProduct(Convert.ToInt32(hidAmpSound.Value));

            if (IsValid)
            {
                //get cart from session state
                CartItemList shoppingCart = CartItemList.GetCart();
                CartItem cartItem = shoppingCart[selectedProduct.ProductID];

                //check if cart is empty & either increase quantity or add to cart
                if (cartItem == null)
                {
                    //add to cart
                    shoppingCart.AddItem(selectedProduct, Convert.ToInt32(tboxAmpSound.Text));
                }
                else
                {
                    //product was already in the cart
                    cartItem.AddQuantity(Convert.ToInt32(tboxAmpSound.Text));
                }
            }

            Response.Redirect("~/cart.aspx");
        }

        protected void btnAmpKicker_Click(object sender, EventArgs e)
        {
            Session["shopping"] = "true";
            selectedProduct = GetSelectedProduct(Convert.ToInt32(hidAmpKicker.Value));

            if (IsValid)
            {
                //get cart from session state
                CartItemList shoppingCart = CartItemList.GetCart();
                CartItem cartItem = shoppingCart[selectedProduct.ProductID];

                //check if cart is empty & either increase quantity or add to cart
                if (cartItem == null)
                {
                    //add to cart
                    shoppingCart.AddItem(selectedProduct, Convert.ToInt32(tboxAmpKicker.Text));
                }
                else
                {
                    //product was already in the cart
                    cartItem.AddQuantity(Convert.ToInt32(tboxAmpKicker.Text));
                }
            }

            Response.Redirect("~/cart.aspx");
        }

        protected void btnAmpPhoenix_Click(object sender, EventArgs e)
        {
            Session["shopping"] = "true";
            selectedProduct = GetSelectedProduct(Convert.ToInt32(hidAmpPhoenix.Value));

            if (IsValid)
            {
                //get cart from session state
                CartItemList shoppingCart = CartItemList.GetCart();
                CartItem cartItem = shoppingCart[selectedProduct.ProductID];

                //check if cart is empty & either increase quantity or add to cart
                if (cartItem == null)
                {
                    //add to cart
                    shoppingCart.AddItem(selectedProduct, Convert.ToInt32(tboxAmpPhoenix.Text));
                }
                else
                {
                    //product was already in the cart
                    cartItem.AddQuantity(Convert.ToInt32(tboxAmpPhoenix.Text));
                }
            }

            Response.Redirect("~/cart.aspx");
        }
    }
}