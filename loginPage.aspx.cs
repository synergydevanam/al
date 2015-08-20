using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
            if (Request.QueryString["logout"] != null)
            {
                btnLogout_OnClick(this, new EventArgs());
            }
            

            if (Request.QueryString["passwordrecovary"] != null)
            {
                //loginCheck();
                div_Login.Visible = false;
                div_PasswordRecovary.Visible = true;
                btnResetPasswrd.Visible = true;
                btnLogin.Visible = false;
                div_PasswordRecovaryEmail.Visible = true;
                div_RessetPassword.Visible = false;
            }
            else
            {
                div_Login.Visible = true;
                div_PasswordRecovary.Visible = false;
                btnResetPasswrd.Visible = false;
                btnLogin.Visible = true;
                div_PasswordRecovaryEmail.Visible = false;
                div_RessetPassword.Visible = true;
            }
        }
    }
    private void loadLoginPage()
    {
        div_Login.Visible = true;
        div_PasswordRecovary.Visible = false;
        btnResetPasswrd.Visible = false;
        btnLogin.Visible = true;
        div_PasswordRecovaryEmail.Visible = false;
        div_RessetPassword.Visible = true;
        
    }
    private void loginCheck()
    {
        bool isloggedIN = false;
        Login login = new Login();
        if ((Session["Login"] != null))
        {
            try
            {
                login = LoginManager.GetLoginByLoginName(((Login)Session["Login"]).LoginName.ToString());
                if (login != null)
                {
                    Session["Login"] = login;
                    isloggedIN = true;
                }
                else
                {
                    lblMsg.Text = "<br/>You are not registered User.";
                    string errorMessage = "You are not registered User.";
                    String str = "<script> alert('" + errorMessage + "'); </Script>";
                    //Response.Write(str);
                }

            }
            catch (Exception ex)
            {
                lblMsg.Text = "<br/>You are not registered User.";
                string errorMessage = "You are not registered User.";
                String str = "<script> alert('" + errorMessage + "'); </Script>";
                //Response.Write(str);

            }
        }
        if ((Request.Browser.Cookies) && (Request.Cookies["LoginName"] != null))
        {

            HttpCookie aCookie = Request.Cookies["LoginName"];

            login = LoginManager.GetLoginByLoginName(Convert.ToString(Server.HtmlEncode(aCookie.Value)));
            if (login != null)
            {
                Session["Login"] = login;
                isloggedIN = true;
            }
        }

        if (isloggedIN) Response.Redirect(login.ExtraField2 == "" ? "Default.aspx" : login.ExtraField2);
    }

    protected void btnLogin_OnClick(object sender, EventArgs e)
    {
        try
        {
            Login login = LoginManager.GetLoginByLoginName(txtLoginName.Text);
            if (login != null)
            {
                if (login.Password == txtPassword.Text)
                {
                    Session["Login"] = login;
                    if (chkRememberme.Checked)
                    {
                        HttpCookie MyGreatCookie = new HttpCookie("LoginName");
                        MyGreatCookie.Value = login.LoginName.ToString();
                        MyGreatCookie.Expires = DateTime.Now.AddDays(100);
                        Response.Cookies.Add(MyGreatCookie);

                    }

                    if (Session["PreviousPage"] != null)
                    {
                        string tmp = Session["PreviousPage"].ToString();
                        Session.Remove("PreviousPage");
                        Response.Redirect(tmp);
                    }
                    else
                    {
                        Response.Redirect(login.ExtraField2 == "" ? "Default.aspx" : login.ExtraField2);
                    }
                }
                else
                {
                    lblMsg.Text = "<br/>Your Password is not match.";
                    string errorMessage = "Your Password is not match.";
                    String str = "<script> alert('" + errorMessage + "'); </Script>";
                    //Response.Write(str);
                }

            }
            else
            {
                lblMsg.Text = "<br/>You are not registered User.";
                string errorMessage = "You are not registered User.";
                String str = "<script> alert('" + errorMessage + "'); </Script>";
                //Response.Write(str);
            }

        }
        catch (Exception ex)
        {
            string errorMessage = "You are not registered User.";
            lblMsg.Text = errorMessage;
            String str = "<script> alert('" + errorMessage + "'); </Script>";
            //Response.Write(str);

        }
    }

    protected void btnLogout_OnClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["Login"] = null;
        if (Request.Cookies["LoginName"] != null)
        {
            HttpCookie myCookie = new HttpCookie("LoginName");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
       // string str = Request.Url.ToString();
        Response.Redirect("LoginPage.aspx");
    }
    protected void lbtnResetPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("LoginPage.aspx?passwordrecovary=1");
    }
    protected void btnResetPasswrd_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("LoginPage.aspx");
        DataSet ds = CommonManager.SQLExec("select Login_Login.LoginName,Login_Login.Password from Login_Login where Email='" + txtEmail.Text + "'");

        if (ds.Tables[0].Rows.Count != 0)
        {
            if (
                    Sendmail.sendEmail("info@caregivermax.com", "CareGiverMax Admin", txtEmail.Text, "anamuliut@gmail.com", "Password Recovary", "<table border='1'><tr><td>User Name</td><td>" + ds.Tables[0].Rows[0]["LoginName"].ToString() + "</td></tr><tr><td>Password</td><td>" + ds.Tables[0].Rows[0]["Password"].ToString() + "</td></tr></table>")
                )
            {
            showAlartMessage("hanks for the request. Check your email to recover the password. If you do not receive any password within 24 hour, you may have registered with a different email address. Please contact us <a href='mailto:info@caregivermax'>info@caregivermax.com</a> for help.");
            //lblMsg.ForeColor = System.Drawing.Color.Green;
            //btnResetPasswrd.Visible = false;
            loadLoginPage();
            }
        }
        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "You are not registered here please <a href='http://www.caregivermax.com/Register.aspx'>register</a>"; 
        }

    }

    private void showAlartMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
             "err_msg",
             "alert('" + message + "');",
             true);
    }
}