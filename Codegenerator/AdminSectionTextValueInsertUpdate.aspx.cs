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

public partial class AdminSectionTextValueInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCarePlanDateTime();
            if (Request.QueryString["sectionTextValueID"] != null)
            {
                int sectionTextValueID = Int32.Parse(Request.QueryString["sectionTextValueID"]);
                if (sectionTextValueID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSectionTextValueData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SectionTextValue sectionTextValue = new SectionTextValue();

        sectionTextValue.CarePlanDateTimeID = Int32.Parse(ddlCarePlanDateTime.SelectedValue);
        sectionTextValue.Section_2 = txtSection_2.Text;
        sectionTextValue.Section_3 = txtSection_3.Text;
        sectionTextValue.Section_6 = txtSection_6.Text;
        sectionTextValue.Section_7 = txtSection_7.Text;
        sectionTextValue.AddedBy = Int32.Parse(txtAddedBy.Text);
        sectionTextValue.AddedDate = DateTime.Now;
        sectionTextValue.UpdatedBy = Int32.Parse(txtUpdatedBy.Text);
        sectionTextValue.UpdatedDate = txtUpdatedDate.Text;
        int resutl = SectionTextValueManager.InsertSectionTextValue(sectionTextValue);
        Response.Redirect("AdminSectionTextValueDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SectionTextValue sectionTextValue = new SectionTextValue();
        sectionTextValue = SectionTextValueManager.GetSectionTextValueByID(Int32.Parse(Request.QueryString["sectionTextValueID"]));
        SectionTextValue tempSectionTextValue = new SectionTextValue();
        tempSectionTextValue.SectionTextValueID = sectionTextValue.SectionTextValueID;

        tempSectionTextValue.CarePlanDateTimeID = Int32.Parse(ddlCarePlanDateTime.SelectedValue);
        tempSectionTextValue.Section_2 = txtSection_2.Text;
        tempSectionTextValue.Section_3 = txtSection_3.Text;
        tempSectionTextValue.Section_6 = txtSection_6.Text;
        tempSectionTextValue.Section_7 = txtSection_7.Text;
        tempSectionTextValue.AddedBy = Int32.Parse(txtAddedBy.Text);
        tempSectionTextValue.AddedDate = DateTime.Now;
        tempSectionTextValue.UpdatedBy = Int32.Parse(txtUpdatedBy.Text);
        tempSectionTextValue.UpdatedDate = txtUpdatedDate.Text;
        bool result = SectionTextValueManager.UpdateSectionTextValue(tempSectionTextValue);
        Response.Redirect("AdminSectionTextValueDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlCarePlanDateTime.SelectedIndex = 0;
        txtSection_2.Text = "";
        txtSection_3.Text = "";
        txtSection_6.Text = "";
        txtSection_7.Text = "";
        txtAddedBy.Text = "";
        txtUpdatedBy.Text = "";
        txtUpdatedDate.Text = "";
    }
    private void showSectionTextValueData()
    {
        SectionTextValue sectionTextValue = new SectionTextValue();
        sectionTextValue = SectionTextValueManager.GetSectionTextValueByID(Int32.Parse(Request.QueryString["sectionTextValueID"]));

        ddlCarePlanDateTime.SelectedValue = sectionTextValue.CarePlanDateTimeID.ToString();
        txtSection_2.Text = sectionTextValue.Section_2;
        txtSection_3.Text = sectionTextValue.Section_3;
        txtSection_6.Text = sectionTextValue.Section_6;
        txtSection_7.Text = sectionTextValue.Section_7;
        txtAddedBy.Text = sectionTextValue.AddedBy.ToString();
        txtUpdatedBy.Text = sectionTextValue.UpdatedBy.ToString();
        txtUpdatedDate.Text = sectionTextValue.UpdatedDate;
    }
    private void loadCarePlanDateTime()
    {
        ListItem li = new ListItem("Select CarePlanDateTime...", "0");
        ddlCarePlanDateTime.Items.Add(li);

        List<CarePlanDateTime> carePlanDateTimes = new List<CarePlanDateTime>();
        carePlanDateTimes = CarePlanDateTimeManager.GetAllCarePlanDateTimes();
        foreach (CarePlanDateTime carePlanDateTime in carePlanDateTimes)
        {
            ListItem item = new ListItem(carePlanDateTime.CarePlanDateTimeName.ToString(), carePlanDateTime.CarePlanDateTimeID.ToString());
            ddlCarePlanDateTime.Items.Add(item);
        }
    }
}
