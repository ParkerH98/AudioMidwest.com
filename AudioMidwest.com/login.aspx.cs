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

        }

        protected void btnValidator_Click(object sender, EventArgs e)
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

                SqlParameter LoginPassword = new SqlParameter("@Password", tboxPassword.Text);
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
                    
                }
                else
                {

                }

            }


        }
    }
}