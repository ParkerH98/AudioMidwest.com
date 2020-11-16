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

                SqlParameter ProductIdInput = new SqlParameter("@ProductID", hidSpeakerFocal.Value);
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