using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_AdminDisplayFormRights : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            // FormRightsManager.LoadFormRightsPage(gvFormRights, rptPager, 1, ddlPageSize);
            LoadUsers();
            var userId = ddlUsers.SelectedItem.Value;

            loadUserRight(userId);
        }
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        FormRightsManager.LoadFormRightsPage(gvFormRights, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        FormRightsManager.LoadFormRightsPage(gvFormRights, rptPager, pageIndex, ddlPageSize);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminFormRights.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminFormRights.aspx?ID=" + id);
    }

    public void LoadUsers()
    {

        ddlUsers.DataValueField = "ProviderUserKey";
        ddlUsers.DataTextField = "UserName";
        ddlUsers.DataSource = Membership.GetAllUsers();
        ddlUsers.DataBind();
        //   ddlUsers.Items.Insert(0, new ListItem("Select User >>", "0"));
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = FormRightsManager.DeleteFormRights(Convert.ToInt32(linkButton.CommandArgument));
        FormRightsManager.LoadFormRightsPage(gvFormRights, rptPager, 1, ddlPageSize);
    }
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        var username = ddlUsers.SelectedValue.ToString();
        loadUserRight(username);

    }

    private void loadUserRight(string username)
    {
        if (username != "0")
        {
            DataSet ds = FormRightsManager.GetFormByUserID(username);
            if (ds.Tables[0] != null)
            {
                gvFormRights.DataSource = ds;
                gvFormRights.DataBind();
            }
            else
            {
                gvFormRights.DataSource = ds;
                gvFormRights.DataBind();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        var userID = ddlUsers.SelectedValue.ToString();
        foreach (GridViewRow row in gvFormRights.Rows)
        {
            var lblFormID = (Label)row.FindControl("lblFormID");
            var chkInsertRight = (CheckBox)row.FindControl("chkInsertRight");
            var chkUpdateRight = (CheckBox)row.FindControl("chkUpdateRight");
            var chkDeleteRight = (CheckBox)row.FindControl("chkDeleteRight");
            var chkSelectRight = (CheckBox)row.FindControl("chkSelectRight");

            FormRights fright = new FormRights();

            fright.UserID = userID;
            fright.FormID = int.Parse(lblFormID.Text);
            fright.SelectRight = chkSelectRight.Checked == true ? true : false;
            fright.InsertRight = chkInsertRight.Checked == true ? true : false;
            fright.UpdateRight = chkUpdateRight.Checked == true ? true : false;
            fright.DeleteRight = chkDeleteRight.Checked == true ? true : false;
            bool result = FormRightsManager.UpdateFormRights(fright);



            if (userID != "0")
                gvFormRights.DataSource = FormRightsManager.GetFormByUserID(userID);
            gvFormRights.DataBind();
        }
    }
    protected void btnCheckInsert_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkInsertRight");
            chkSelect.Checked = true;


        }
    }
    protected void btnUpdateRight_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkUpdateRight");
            chkSelect.Checked = true;


        }
    }
    protected void btnDeleteRight_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkDeleteRight");
            chkSelect.Checked = true;


        }
    }
    protected void btnSelectRight_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelectRight");
            chkSelect.Checked = true;


        }
    }
    protected void btnUnCheckInsert_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkInsertRight");
            chkSelect.Checked = false;


        }
    }
    protected void btnUnUpdateRight_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkUpdateRight");
            chkSelect.Checked = false;


        }
    }
    protected void btnUnDeleteRight_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkDeleteRight");
            chkSelect.Checked = false;


        }
    }
    protected void btnUnSelectRight_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvFormRights.Rows)
        {

            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelectRight");
            chkSelect.Checked = false;


        }
    }
}

