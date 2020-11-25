using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


namespace AudioMidwest.com
{
    public partial class contact : System.Web.UI.Page
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

            lblEmailMsg.Visible = false;

            if (Request.Cookies["FirstName"] != null)
            {
                tboxFirstName.Text = Request.Cookies["FirstName"].Value;
                tboxLastName.Text = Request.Cookies["LastName"].Value.ToString();
                tboxEmail.Text = Request.Cookies["Email"].Value.ToString();
                tboxPhoneNumber.Text = Request.Cookies["PhoneNumber"].Value.ToString();
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

        protected void btnCreateAcct_Click(object sender, EventArgs e)
        {
            string emailFirst = tboxFirstName.Text;
            string emailMessage = tboxMessage.Text;
            string emailSenderEmail = tboxEmail.Text;
            string toEmail = "parkerhague@gmail.com";

            MailAddress fromAddress = new MailAddress(toEmail);
            MailAddress toAddress = new MailAddress(toEmail);

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(toEmail, "Ph4058220384");

            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);

            mailMessage.Subject = "Comment on AudioMidwest.com from " + tboxFirstName.Text + " " + tboxLastName.Text + ".";
            mailMessage.Body = emailMessage;
            smtp.Send(mailMessage);

            tboxFirstName.Text = "";
            tboxLastName.Text = "";
            tboxPhoneNumber.Text = "";
            tboxEmail.Text = "";
            tboxMessage.Text = "";

            lblEmailMsg.Visible = true;
        }
    }
}