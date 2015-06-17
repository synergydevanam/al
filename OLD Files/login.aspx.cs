using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (User.Identity.Name != "")
        //{
        //    if (this.Profile.ShoppingCart.Items.Count > 0)
        //        btnOrder.Visible = true;
        //}
        

    }
    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        e.Authenticated = false;
        Login masterLogin = (Login)masterview.FindControl("masterLogin");
        string userName = masterLogin.UserName.ToString();
        string password = masterLogin.Password.ToString();



        if (Membership.ValidateUser(userName, password) && (userName.Equals("admin")))
        {
            masterLogin.DestinationPageUrl = "~/DisplayCustomer.aspx";
            e.Authenticated = true;
            //Context.User.Identity.Name
        }
        else
        {
            if (Membership.ValidateUser(userName, password))
            {

                e.Authenticated = true;
                FormsAuthentication.SetAuthCookie(userName, false);

                //Session.Abandon();
                //FormsAuthentication.SignOut();
                //Response.Redirect("~/Default.aspx");
                // lblMessage.Text = "Invalid User Name and Password";

                //now check the role
              

                // Make sure that the user doesn't already belong to this role 
                if (Roles.IsUserInRole(userName, "admin"))
                {
                    masterLogin.DestinationPageUrl = "~/DisplayCustomer.aspx";
                    Response.Redirect("~/DisplayCustomer.aspx");
                    e.Authenticated = true;
                }
                else if (Roles.IsUserInRole(userName, "contractor"))
                

                masterLogin.DestinationPageUrl = "~/Default.aspx";
                e.Authenticated = true;

            }
            else
            {
                Response.Redirect("~/ForgotPass.aspx");
            }
        }
    }
    protected void btnOassword_Click(object sender, EventArgs e)
    {

    }
}