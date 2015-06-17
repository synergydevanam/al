using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class Admin_AdminUserCreate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }
    }

    private void LoadUser()
    {

        ddlUserList.DataValueField = "ProviderUserKey";
        ddlUserList.DataTextField = "UserName";
        ddlUserList.DataSource = Membership.GetAllUsers();
        ddlUserList.DataBind();
        ddlUserList.Items.Insert(0, new ListItem("Select User >>", "0"));
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string username = txtUserName.Text;
        string password = txtPassword.Text;
        string email = txtEmail.Text;
        string Question = "admin";
        string Answer = "password";
        try
        {
            MembershipCreateStatus status;

            MembershipUser user = Membership.CreateUser(username, password, email, Question, Answer, true, out status);
            switch (status)
            {

                case MembershipCreateStatus.Success:
                    lblMessage.Text = "The user account was successfully created!";

                    SaveProfile(username);
                    break;
                case MembershipCreateStatus.InvalidPassword:

                    lblMessage.Text = "Invalid Password !";


                    break;
                default:
                    lblMessage.Text = "There was an unknown error; the user account was NOT created.";
                    break;

            }
            if (user != null)
            {
                Response.Redirect("~/admin/AdminDisplayFormRights.aspx"); lblMessage.Text = "<span class=\"error_mes\">User Already Exists</span>";

            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = "<span class=\"error_mes\">" + ex.ToString() + "</span>";

        }

    }

    private void SaveProfile(string username)
    {

        ProfileCommon p = (ProfileCommon)ProfileCommon.Create(username, true);

        Profile.FirstName = txtFirstName.Text;
        Profile.LastName = txtLastName.Text;
        Profile.Address = txtAddress.Text;

        Profile.City = txtCity.Text;
        Profile.PostalCode = txtZipcode.Text;
        Profile.State = txtState.Text;
        Profile.Country = "USA";
        Profile.Save();

        MembershipUser myObject = Membership.GetUser(username);
        if (chckCopyPermission.Checked)
        {
            var uName = ddlUserList.SelectedItem.Value;
            DataSet userRight = FormRightsManager.GetFormByUserID(uName);


            foreach (DataRow dr in userRight.Tables[0].Rows)
            {
                var chkInsertRight = bool.Parse(dr["InsertRight"].ToString());
                var chkUpdateRight = bool.Parse(dr["UpdateRight"].ToString());
                var chkDeleteRight = bool.Parse(dr["DeleteRight"].ToString());
                var chkSelectRight = bool.Parse(dr["SelectRight"].ToString());

                var FormID = int.Parse(dr["FormID"].ToString());

                FormRights fright = new FormRights();

                fright.UserID = myObject.ProviderUserKey.ToString();
                fright.FormID = FormID;
                fright.SelectRight = chkSelectRight;
                fright.InsertRight = chkInsertRight;
                fright.UpdateRight = chkUpdateRight;
                fright.DeleteRight = chkDeleteRight;
                bool result = FormRightsManager.UpdateFormRights(fright);


            }

        }
        else
        {
            var chkInsertRight = false;
            var chkUpdateRight = false;
            var chkDeleteRight = false;
            var chkSelectRight = false;

            DataSet formName = FormsManager.GetAllFormss();
            foreach (DataRow dr in formName.Tables[0].Rows)
            {
                FormRights fright = new FormRights();

                fright.UserID = myObject.ProviderUserKey.ToString();
                fright.FormID = int.Parse(dr["FormsID"].ToString()); ;

                fright.SelectRight = chkSelectRight;
                fright.InsertRight = chkInsertRight;
                fright.UpdateRight = chkUpdateRight;
                fright.DeleteRight = chkDeleteRight;
                bool result = FormRightsManager.UpdateFormRights(fright);
            }

        }
    }
    protected void chckCopyPermission_CheckedChanged(object sender, EventArgs e)
    {
        if (chckCopyPermission.Checked == true)
        {
            ddlUserList.Visible = true;
            LoadUser();
        }
        else
        {
            ddlUserList.Visible = false;
        }
    }
}