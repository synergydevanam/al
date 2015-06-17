using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ResidentID"] != null)
            {
                loadAssessmentnCareDate();
            }
            loadGrid();
            if (Request.QueryString["CarePlanDateTimeID"] != null)
            {
                ddlExistingRecord.SelectedValue = Request.QueryString["CarePlanDateTimeID"];
                loadSelectData();
            }
        }
    }

    private void loadAssessmentnCareDate()
    {
        ListItem li = new ListItem("New Record", "0");
        ddlExistingRecord.Items.Add(li);

        

        List<CarePlanDateTime> carePlanDateTimes = new List<CarePlanDateTime>();
        carePlanDateTimes = CarePlanDateTimeManager.GetAllCarePlanDateTimesByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        foreach (CarePlanDateTime carePlanDateTime in carePlanDateTimes)
        {
            ListItem item = new ListItem(carePlanDateTime.CarePlanDateTimeValue.ToString("yyyy-MM-dd hh:mm tt"), carePlanDateTime.CarePlanDateTimeID.ToString());
            ddlExistingRecord.Items.Add(item);
        }
    }

   

    private void loadGrid()
    {
        
        List<SectionLabel> sectionLabelAll = SectionLabelManager.GetAllSectionLabels();
        List<SectionLabel> sectionLabel_1 = new List<SectionLabel>();
        List<SectionLabel> sectionLabel_4 = new List<SectionLabel>();
        List<SectionLabel> sectionLabel_5 = new List<SectionLabel>();
        List<SectionLabel> sectionLabel_8 = new List<SectionLabel>();
        List<SectionLabel> sectionLabel_9 = new List<SectionLabel>();

        foreach (SectionLabel item in sectionLabelAll)
        {
            if (item.SectionNo == 1)
            {
                sectionLabel_1.Add(item);
            }
            else
                if (item.SectionNo == 4)
                {
                    sectionLabel_4.Add(item);
                }
                else
                    if (item.SectionNo == 5)
                    {
                        sectionLabel_5.Add(item);
                    }
                    else
                        if (item.SectionNo == 8)
                        {
                            sectionLabel_8.Add(item);
                        }
                        else
                            if (item.SectionNo == 9)
                            {
                                sectionLabel_9.Add(item);
                            }
        }

        //Section 1
        gvSection_1.DataSource = sectionLabel_1;
        gvSection_1.DataBind();

        //Section 4
        gvSection_4.DataSource = sectionLabel_4;
        gvSection_4.DataBind();

        //Section 5
        gvSection_5.DataSource = sectionLabel_5;
        gvSection_5.DataBind();

        //Section 8
        gvSection_8.DataSource = sectionLabel_8;
        gvSection_8.DataBind();

        //Section 9
        gvSection_9.DataSource = sectionLabel_9;
        gvSection_9.DataBind();
    }

    private Login getLogin()
    {
        Login login = new Login();
        try
        {
            if (Session["Login"] == null) { Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); }

            login = (Login)Session["Login"];
        }
        catch (Exception ex)
        { }

        return login;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CarePlanDateTime carePlanDateTime = new CarePlanDateTime();

        if (ddlExistingRecord.SelectedIndex == 0)
        {
            carePlanDateTime.ResidentID = int.Parse(Request.QueryString["ResidentID"]);
            carePlanDateTime.CarePlanDateTimeValue = DateTime.Now;
            carePlanDateTime.CarePlanDateTimeID = CarePlanDateTimeManager.InsertCarePlanDateTime(carePlanDateTime);
        }
        else
        { 
            carePlanDateTime.CarePlanDateTimeID =  int.Parse(ddlExistingRecord.SelectedValue);
        }

        //Saving the textbox value those are Section-2,3,6,7
        SectionTextValue sectionTextValue = new SectionTextValue();

        sectionTextValue.CarePlanDateTimeID = carePlanDateTime.CarePlanDateTimeID;
        sectionTextValue.Section_2 = txtSection_2.Text;
        sectionTextValue.Section_3 = txtSection_3.Text;
        sectionTextValue.Section_6 = txtSection_6.Text;
        sectionTextValue.Section_7 = txtSection_7.Text;
        sectionTextValue.AddedBy = getLogin().LoginID;
        sectionTextValue.AddedDate = DateTime.Now;
        sectionTextValue.UpdatedBy = getLogin().LoginID;
        sectionTextValue.UpdatedDate = DateTime.Now;
        sectionTextValue.SectionTextValueID = int.Parse(hfSectionTextValueID.Value);
        if (ddlExistingRecord.SelectedIndex == 0)
        {
            int resutl = SectionTextValueManager.InsertSectionTextValue(sectionTextValue);
        }
        else
        {
            SectionTextValueManager.UpdateSectionTextValue(sectionTextValue);
        }

        if (ddlExistingRecord.SelectedIndex != 0)
        {
            //Delete all the value of selected Date
            SectionLabelValueManager.DeleteSectionLabelValueByCarePlanDateTimeID(carePlanDateTime.CarePlanDateTimeID.ToString());
        }
        //Saving the grid value for Section 1
        foreach (GridViewRow gr in gvSection_1.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            RadioButtonList rbtnlSection = (RadioButtonList)gr.FindControl("rbtnlSection");

            SectionLabelValue sectionLabelValue = new SectionLabelValue();

            sectionLabelValue.SectionLabelID = Int32.Parse(hfSectionLabelID.Value);
            sectionLabelValue.AddedBy = getLogin().LoginID;
            sectionLabelValue.AddedDate = DateTime.Now;
            sectionLabelValue.Value = rbtnlSection.SelectedValue;
            sectionLabelValue.ExtraField1 = carePlanDateTime.CarePlanDateTimeID.ToString();
            sectionLabelValue.ExtraField2 ="";
            int resutl = SectionLabelValueManager.InsertSectionLabelValue(sectionLabelValue);
        }

        //Saving the grid value for Section 4
        foreach (GridViewRow gr in gvSection_4.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");

            SectionLabelValue sectionLabelValue = new SectionLabelValue();

            sectionLabelValue.SectionLabelID = Int32.Parse(hfSectionLabelID.Value);
            sectionLabelValue.AddedBy = getLogin().LoginID;
            sectionLabelValue.AddedDate = DateTime.Now;
            sectionLabelValue.Value = txtValue.Text;
            sectionLabelValue.ExtraField1 = carePlanDateTime.CarePlanDateTimeID.ToString();
            sectionLabelValue.ExtraField2 = "";
            int resutl = SectionLabelValueManager.InsertSectionLabelValue(sectionLabelValue);
        }

        //Saving the grid value for Section 5
        foreach (GridViewRow gr in gvSection_5.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            RadioButtonList rbtnlSection = (RadioButtonList)gr.FindControl("rbtnlSection");

            SectionLabelValue sectionLabelValue = new SectionLabelValue();

            sectionLabelValue.SectionLabelID = Int32.Parse(hfSectionLabelID.Value);
            sectionLabelValue.AddedBy = getLogin().LoginID;
            sectionLabelValue.AddedDate = DateTime.Now;
            sectionLabelValue.Value = rbtnlSection.SelectedValue;
            sectionLabelValue.ExtraField1 = carePlanDateTime.CarePlanDateTimeID.ToString();
            sectionLabelValue.ExtraField2 = "";
            int resutl = SectionLabelValueManager.InsertSectionLabelValue(sectionLabelValue);
        }

        //Saving the grid value for Section 8
        foreach (GridViewRow gr in gvSection_8.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");

            SectionLabelValue sectionLabelValue = new SectionLabelValue();

            sectionLabelValue.SectionLabelID = Int32.Parse(hfSectionLabelID.Value);
            sectionLabelValue.AddedBy = getLogin().LoginID;
            sectionLabelValue.AddedDate = DateTime.Now;
            sectionLabelValue.Value = txtValue.Text;
            sectionLabelValue.ExtraField1 = carePlanDateTime.CarePlanDateTimeID.ToString();
            sectionLabelValue.ExtraField2 = "";
            int resutl = SectionLabelValueManager.InsertSectionLabelValue(sectionLabelValue);
        }

        //Saving the grid value for Section 9
        foreach (GridViewRow gr in gvSection_9.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");

            SectionLabelValue sectionLabelValue = new SectionLabelValue();

            sectionLabelValue.SectionLabelID = Int32.Parse(hfSectionLabelID.Value);
            sectionLabelValue.AddedBy = getLogin().LoginID;
            sectionLabelValue.AddedDate = DateTime.Now;
            sectionLabelValue.Value = txtValue.Text;
            sectionLabelValue.ExtraField1 = carePlanDateTime.CarePlanDateTimeID.ToString();
            sectionLabelValue.ExtraField2 = "";
            int resutl = SectionLabelValueManager.InsertSectionLabelValue(sectionLabelValue);
        }

    }

    protected void ddlExistingRecord_SelectedIndexChanged(object sender, EventArgs e)
    {
        cleanData();
        if (ddlExistingRecord.SelectedIndex != 0)
        {
            loadSelectData();
        }
        //a_Print.Visible = true;
        //if (ddlExistingRecord.SelectedIndex == 0)
        //{
            a_Print.Visible = false;
        //}
        //a_Print.HRef = "AssessmentnCarePrint.aspx?Title=COMPREHENSIVE ASSESSMENT&AssessmentnCareDateIDID=" + ddlExistingRecord.SelectedValue + "&ResidentID=" + Request.QueryString["ResidentID"];
    }
    private void cleanData()
    {
        txtSection_2.Text = "";
        txtSection_3.Text = "";
        txtSection_6.Text = "";
        txtSection_7.Text = "";
        hfSectionTextValueID.Value = "0";
        //Saving the grid value for Section 1
        foreach (GridViewRow gr in gvSection_1.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            RadioButtonList rbtnlSection = (RadioButtonList)gr.FindControl("rbtnlSection");
            rbtnlSection.SelectedIndex = 0;
        }

        //Saving the grid value for Section 4
        foreach (GridViewRow gr in gvSection_4.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");
            txtValue.Text = "";
        }

        //Saving the grid value for Section 5
        foreach (GridViewRow gr in gvSection_5.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            RadioButtonList rbtnlSection = (RadioButtonList)gr.FindControl("rbtnlSection");
            rbtnlSection.SelectedIndex = 0;
        }

        //Saving the grid value for Section 8
        foreach (GridViewRow gr in gvSection_8.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");
            txtValue.Text = "";
        }

        //Saving the grid value for Section 9
        foreach (GridViewRow gr in gvSection_9.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");
            txtValue.Text = "";
        }
    }
    private void loadSelectData()
    {
        
        //load the  text boxs 
        SectionTextValue sectionTextValue= SectionTextValueManager.GetSectionTextValueByCarePlanDateTimeID(int.Parse(ddlExistingRecord.SelectedValue));
        txtSection_2.Text = sectionTextValue.Section_2;
        txtSection_3.Text = sectionTextValue.Section_3;
        txtSection_6.Text = sectionTextValue.Section_6;
        txtSection_7.Text = sectionTextValue.Section_7;
        hfSectionTextValueID.Value = sectionTextValue.SectionTextValueID.ToString();

        List<SectionLabelValue> SectionLabelValue =SectionLabelValueManager.GetAllSectionLabelValuesByCarePlanDateTimeID(int.Parse(ddlExistingRecord.SelectedValue));

        //Saving the grid value for Section 1
        foreach (GridViewRow gr in gvSection_1.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            RadioButtonList rbtnlSection = (RadioButtonList)gr.FindControl("rbtnlSection");

            foreach (SectionLabelValue item in SectionLabelValue)
            {
                if (item.SectionLabelID.ToString() == hfSectionLabelID.Value)
                {
                    rbtnlSection.SelectedValue = item.Value;
                    break;
                }
            }
        }

        //Saving the grid value for Section 4
        foreach (GridViewRow gr in gvSection_4.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");
            foreach (SectionLabelValue item in SectionLabelValue)
            {
                if (item.SectionLabelID.ToString() == hfSectionLabelID.Value)
                {
                    txtValue.Text = item.Value;
                    break;
                }
            }
        }

        //Saving the grid value for Section 5
        foreach (GridViewRow gr in gvSection_5.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            RadioButtonList rbtnlSection = (RadioButtonList)gr.FindControl("rbtnlSection");
            foreach (SectionLabelValue item in SectionLabelValue)
            {
                if (item.SectionLabelID.ToString() == hfSectionLabelID.Value)
                {
                    rbtnlSection.SelectedValue = item.Value;
                    break;
                }
            }
        }

        //Saving the grid value for Section 8
        foreach (GridViewRow gr in gvSection_8.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");
            foreach (SectionLabelValue item in SectionLabelValue)
            {
                if (item.SectionLabelID.ToString() == hfSectionLabelID.Value)
                {
                    txtValue.Text = item.Value;
                    break;
                }
            }
        }

        //Saving the grid value for Section 8
        foreach (GridViewRow gr in gvSection_9.Rows)
        {
            HiddenField hfSectionLabelID = (HiddenField)gr.FindControl("hfSectionLabelID");
            TextBox txtValue = (TextBox)gr.FindControl("txtValue");

            SectionLabelValue sectionLabelValue = new SectionLabelValue();
            foreach (SectionLabelValue item in SectionLabelValue)
            {
                if (item.SectionLabelID.ToString() == hfSectionLabelID.Value)
                {
                    txtValue.Text = item.Value;
                    break;
                }
            }
        }
    }
}