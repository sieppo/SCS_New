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
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Loginadmin_Authenticate(object sender, AuthenticateEventArgs e)
        {

            string screenname = "";
            DataTransferFunction accesme = new DataTransferFunction();
            screenname = accesme.authentication(Loginadmin.UserName, Loginadmin.Password);
            if (screenname != "")
            {
                FormsAuthentication.RedirectFromLoginPage(Loginadmin.UserName, Loginadmin.RememberMeSet);
            }
            else
            {
                Loginadmin.FailureText = "Username and/or password is incorrect.";
            }
        }
    }
}