using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebClientApplication
{
    public partial class adminheader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                theDiv.Visible = false;
            }
            else
            {
                theDiv.Visible = true;
            }

        }

        protected void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}