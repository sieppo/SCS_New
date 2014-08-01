using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebClientApplication
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                theDiv.Visible = false;
            }
            else
            {
              Label_Store.Text = this.Page.User.Identity.Name.ToString();
                theDiv.Visible = true;
            }

        }

        protected void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            foreach (var cookie in Request.Cookies.AllKeys)
            {
                Request.Cookies.Remove(cookie);
            }
        //foreach (var cookie in Response.Cookies.AllKeys)
        //{
        //    Response.Cookies.Remove(cookie);
        //}
            Response.Redirect(Request.Url.AbsoluteUri);
        }
            
    }
}