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

public partial class AdminSectionLabelInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["sectionLabelID"] != null)
            {
                int sectionLabelID = Int32.Parse(Request.QueryString["sectionLabelID"]);
                if (sectionLabelID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSectionLabelData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SectionLabel sectionLabel = new SectionLabel();

        sectionLabel.SectionNo = Int32.Parse(txtSectionNo.Text);
        sectionLabel.LabelText = txtLabelText.Text;
        sectionLabel.ExtraField1 = txtExtraField1.Text;
        sectionLabel.ExtraField2 = txtExtraField2.Text;
        sectionLabel.ExtraField3 = txtExtraField3.Text;
        sectionLabel.ExtraField4 = txtExtraField4.Text;
        sectionLabel.ExtraField5 = txtExtraField5.Text;
        int resutl = SectionLabelManager.InsertSectionLabel(sectionLabel);
        Response.Redirect("AdminSectionLabelDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SectionLabel sectionLabel = new SectionLabel();
        sectionLabel = SectionLabelManager.GetSectionLabelByID(Int32.Parse(Request.QueryString["sectionLabelID"]));
        SectionLabel tempSectionLabel = new SectionLabel();
        tempSectionLabel.SectionLabelID = sectionLabel.SectionLabelID;

        tempSectionLabel.SectionNo = Int32.Parse(txtSectionNo.Text);
        tempSectionLabel.LabelText = txtLabelText.Text;
        tempSectionLabel.ExtraField1 = txtExtraField1.Text;
        tempSectionLabel.ExtraField2 = txtExtraField2.Text;
        tempSectionLabel.ExtraField3 = txtExtraField3.Text;
        tempSectionLabel.ExtraField4 = txtExtraField4.Text;
        tempSectionLabel.ExtraField5 = txtExtraField5.Text;
        bool result = SectionLabelManager.UpdateSectionLabel(tempSectionLabel);
        Response.Redirect("AdminSectionLabelDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSectionNo.Text = "";
        txtLabelText.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showSectionLabelData()
    {
        SectionLabel sectionLabel = new SectionLabel();
        sectionLabel = SectionLabelManager.GetSectionLabelByID(Int32.Parse(Request.QueryString["sectionLabelID"]));

        txtSectionNo.Text = sectionLabel.SectionNo.ToString();
        txtLabelText.Text = sectionLabel.LabelText;
        txtExtraField1.Text = sectionLabel.ExtraField1;
        txtExtraField2.Text = sectionLabel.ExtraField2;
        txtExtraField3.Text = sectionLabel.ExtraField3;
        txtExtraField4.Text = sectionLabel.ExtraField4;
        txtExtraField5.Text = sectionLabel.ExtraField5;
    }
}
