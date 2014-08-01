using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Data_Functions;
using System.Data;



namespace WebClientApplication
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            string screenname = "";
            DataTransferFunction accesme = new DataTransferFunction();
            screenname = accesme.authentication(Login1.UserName, Login1.Password);
            if (screenname != "")
            {

                FormsAuthentication.RedirectFromLoginPage(screenname, Login1.RememberMeSet);
            }
            else
            {
                Login1.FailureText = "Username and/or password is incorrect.";
            }
        }
    }
}