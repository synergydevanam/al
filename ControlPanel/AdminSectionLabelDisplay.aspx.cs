using System;
using System.Collections;
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

public partial class AdminSectionLabelDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showSectionLabelGrid();
        }
    }
    
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        showSectionLabelData(id);
        hfID.Value = id.ToString();
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = SectionLabelManager.DeleteSectionLabel(Convert.ToInt32(linkButton.CommandArgument));
        showSectionLabelGrid();
    }

    private void showSectionLabelGrid()
    {
        gvSectionLabel.DataSource = SectionLabelManager.GetAllSectionLabels();
        gvSectionLabel.DataBind();
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
        showSectionLabelGrid();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SectionLabel tempSectionLabel = new SectionLabel();        
        tempSectionLabel.SectionNo = Int32.Parse(txtSectionNo.Text);
        tempSectionLabel.LabelText = txtLabelText.Text;
        tempSectionLabel.ExtraField1 = txtExtraField1.Text;
        tempSectionLabel.ExtraField2 = txtExtraField2.Text;
        tempSectionLabel.ExtraField3 = txtExtraField3.Text;
        tempSectionLabel.ExtraField4 = txtExtraField4.Text;
        tempSectionLabel.ExtraField5 = txtExtraField5.Text;
        if (hfID.Value != "0")
        {
            tempSectionLabel.SectionLabelID = int.Parse(hfID.Value);
            SectionLabelManager.UpdateSectionLabel(tempSectionLabel);
        }
        else
        {
            SectionLabelManager.InsertSectionLabel(tempSectionLabel);
        } 
        showSectionLabelGrid();
        Clear_Click();
    }
    private void Clear_Click()
    {
        txtSectionNo.Text = "";
        txtLabelText.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
        hfID.Value = "0";
    }
    private void showSectionLabelData(int id)
    {
        SectionLabel sectionLabel = new SectionLabel();
        sectionLabel = SectionLabelManager.GetSectionLabelByID(id);

        txtSectionNo.Text = sectionLabel.SectionNo.ToString();
        txtLabelText.Text = sectionLabel.LabelText;
        txtExtraField1.Text = sectionLabel.ExtraField1;
        txtExtraField2.Text = sectionLabel.ExtraField2;
        txtExtraField3.Text = sectionLabel.ExtraField3;
        txtExtraField4.Text = sectionLabel.ExtraField4;
        txtExtraField5.Text = sectionLabel.ExtraField5;
    }
    protected void btnCleanData_Click(object sender, EventArgs e)
    {
        Clear_Click();
    }
}
