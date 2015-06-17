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

public partial class AdminSectionLabelValueInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSectionLabel();
            if (Request.QueryString["sectionLabelValueID"] != null)
            {
                int sectionLabelValueID = Int32.Parse(Request.QueryString["sectionLabelValueID"]);
                if (sectionLabelValueID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSectionLabelValueData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SectionLabelValue sectionLabelValue = new SectionLabelValue();

        sectionLabelValue.SectionLabelID = Int32.Parse(ddlSectionLabel.SelectedValue);
        sectionLabelValue.AddedBy = Int32.Parse(txtAddedBy.Text);
        sectionLabelValue.AddedDate = DateTime.Now;
        sectionLabelValue.Value = txtValue.Text;
        sectionLabelValue.ExtraField1 = txtExtraField1.Text;
        sectionLabelValue.ExtraField2 = txtExtraField2.Text;
        int resutl = SectionLabelValueManager.InsertSectionLabelValue(sectionLabelValue);
        Response.Redirect("AdminSectionLabelValueDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SectionLabelValue sectionLabelValue = new SectionLabelValue();
        sectionLabelValue = SectionLabelValueManager.GetSectionLabelValueByID(Int32.Parse(Request.QueryString["sectionLabelValueID"]));
        SectionLabelValue tempSectionLabelValue = new SectionLabelValue();
        tempSectionLabelValue.SectionLabelValueID = sectionLabelValue.SectionLabelValueID;

        tempSectionLabelValue.SectionLabelID = Int32.Parse(ddlSectionLabel.SelectedValue);
        tempSectionLabelValue.AddedBy = Int32.Parse(txtAddedBy.Text);
        tempSectionLabelValue.AddedDate = DateTime.Now;
        tempSectionLabelValue.Value = txtValue.Text;
        tempSectionLabelValue.ExtraField1 = txtExtraField1.Text;
        tempSectionLabelValue.ExtraField2 = txtExtraField2.Text;
        bool result = SectionLabelValueManager.UpdateSectionLabelValue(tempSectionLabelValue);
        Response.Redirect("AdminSectionLabelValueDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlSectionLabel.SelectedIndex = 0;
        txtAddedBy.Text = "";
        txtValue.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
    }
    private void showSectionLabelValueData()
    {
        SectionLabelValue sectionLabelValue = new SectionLabelValue();
        sectionLabelValue = SectionLabelValueManager.GetSectionLabelValueByID(Int32.Parse(Request.QueryString["sectionLabelValueID"]));

        ddlSectionLabel.SelectedValue = sectionLabelValue.SectionLabelID.ToString();
        txtAddedBy.Text = sectionLabelValue.AddedBy.ToString();
        txtValue.Text = sectionLabelValue.Value;
        txtExtraField1.Text = sectionLabelValue.ExtraField1;
        txtExtraField2.Text = sectionLabelValue.ExtraField2;
    }
    private void loadSectionLabel()
    {
        ListItem li = new ListItem("Select SectionLabel...", "0");
        ddlSectionLabel.Items.Add(li);

        List<SectionLabel> sectionLabels = new List<SectionLabel>();
        sectionLabels = SectionLabelManager.GetAllSectionLabels();
        foreach (SectionLabel sectionLabel in sectionLabels)
        {
            ListItem item = new ListItem(sectionLabel.SectionLabelName.ToString(), sectionLabel.SectionLabelID.ToString());
            ddlSectionLabel.Items.Add(item);
        }
    }
}
