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

public partial class AdminCarePlanDateTimeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["carePlanDateTimeID"] != null)
            {
                int carePlanDateTimeID = Int32.Parse(Request.QueryString["carePlanDateTimeID"]);
                if (carePlanDateTimeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCarePlanDateTimeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CarePlanDateTime carePlanDateTime = new CarePlanDateTime();

        carePlanDateTime.CarePlanDateTimeValue = txtCarePlanDateTimeValue.Text;
        int resutl = CarePlanDateTimeManager.InsertCarePlanDateTime(carePlanDateTime);
        Response.Redirect("AdminCarePlanDateTimeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        CarePlanDateTime carePlanDateTime = new CarePlanDateTime();
        carePlanDateTime = CarePlanDateTimeManager.GetCarePlanDateTimeByID(Int32.Parse(Request.QueryString["carePlanDateTimeID"]));
        CarePlanDateTime tempCarePlanDateTime = new CarePlanDateTime();
        tempCarePlanDateTime.CarePlanDateTimeID = carePlanDateTime.CarePlanDateTimeID;

        tempCarePlanDateTime.CarePlanDateTimeValue = txtCarePlanDateTimeValue.Text;
        bool result = CarePlanDateTimeManager.UpdateCarePlanDateTime(tempCarePlanDateTime);
        Response.Redirect("AdminCarePlanDateTimeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCarePlanDateTimeValue.Text = "";
    }
    private void showCarePlanDateTimeData()
    {
        CarePlanDateTime carePlanDateTime = new CarePlanDateTime();
        carePlanDateTime = CarePlanDateTimeManager.GetCarePlanDateTimeByID(Int32.Parse(Request.QueryString["carePlanDateTimeID"]));

        txtCarePlanDateTimeValue.Text = carePlanDateTime.CarePlanDateTimeValue;
    }
}
