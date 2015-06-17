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

public partial class AdminAL_HelpInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadHelpType();
            if (Request.QueryString["aL_HelpID"] != null)
            {
                int aL_HelpID = Int32.Parse(Request.QueryString["aL_HelpID"]);
                if (aL_HelpID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAL_HelpData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AL_Help aL_Help = new AL_Help();

        aL_Help.HelpTypeID = Int32.Parse(ddlHelpType.SelectedValue);
        aL_Help.Question = txtQuestion.Text;
        aL_Help.Answer = txtAnswer.Value;
        int resutl = AL_HelpManager.InsertAL_Help(aL_Help);
        Response.Redirect("AdminAL_HelpDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AL_Help aL_Help = new AL_Help();
        aL_Help = AL_HelpManager.GetAL_HelpByID(Int32.Parse(Request.QueryString["aL_HelpID"]));
        AL_Help tempAL_Help = new AL_Help();
        tempAL_Help.AL_HelpID = aL_Help.AL_HelpID;

        tempAL_Help.HelpTypeID = Int32.Parse(ddlHelpType.SelectedValue);
        tempAL_Help.Question = txtQuestion.Text;
        tempAL_Help.Answer = txtAnswer.Value;
        bool result = AL_HelpManager.UpdateAL_Help(tempAL_Help);
        Response.Redirect("AdminAL_HelpDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlHelpType.SelectedIndex = 0;
        txtQuestion.Text = "";
        txtAnswer.Value = "";
    }
    private void showAL_HelpData()
    {
        AL_Help aL_Help = new AL_Help();
        aL_Help = AL_HelpManager.GetAL_HelpByID(Int32.Parse(Request.QueryString["aL_HelpID"]));

        ddlHelpType.SelectedValue = aL_Help.HelpTypeID.ToString();
        txtQuestion.Text = aL_Help.Question;
        txtAnswer.Value = aL_Help.Answer;
    }
    private void loadHelpType()
    {
        ListItem li = new ListItem("Select HelpType...", "0");
        ddlHelpType.Items.Add(li);

        List<AL_HelpType> helpTypes = new List<AL_HelpType>();
        helpTypes = AL_HelpTypeManager.GetAllAL_HelpTypes();
        foreach (AL_HelpType helpType in helpTypes)
        {
            ListItem item = new ListItem(helpType.HelpTypeName.ToString(), helpType.AL_HelpTypeID.ToString());
            ddlHelpType.Items.Add(item);
        }
    }
}
