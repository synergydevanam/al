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

public partial class AdminMedicineTimenDateInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadMedicationTime();
            if (Request.QueryString["medicineTimenDateID"] != null)
            {
                int medicineTimenDateID = Int32.Parse(Request.QueryString["medicineTimenDateID"]);
                if (medicineTimenDateID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showMedicineTimenDateData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        MedicineTimenDate medicineTimenDate = new MedicineTimenDate();

        medicineTimenDate.MedicationTimeID = Int32.Parse(ddlMedicationTime.SelectedValue);
        medicineTimenDate.MedicineDate = txtMedicineDate.Text;
        int resutl = MedicineTimenDateManager.InsertMedicineTimenDate(medicineTimenDate);
        Response.Redirect("AdminMedicineTimenDateDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        MedicineTimenDate medicineTimenDate = new MedicineTimenDate();
        medicineTimenDate = MedicineTimenDateManager.GetMedicineTimenDateByID(Int32.Parse(Request.QueryString["medicineTimenDateID"]));
        MedicineTimenDate tempMedicineTimenDate = new MedicineTimenDate();
        tempMedicineTimenDate.MedicineTimenDateID = medicineTimenDate.MedicineTimenDateID;

        tempMedicineTimenDate.MedicationTimeID = Int32.Parse(ddlMedicationTime.SelectedValue);
        tempMedicineTimenDate.MedicineDate = txtMedicineDate.Text;
        bool result = MedicineTimenDateManager.UpdateMedicineTimenDate(tempMedicineTimenDate);
        Response.Redirect("AdminMedicineTimenDateDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlMedicationTime.SelectedIndex = 0;
        txtMedicineDate.Text = "";
    }
    private void showMedicineTimenDateData()
    {
        MedicineTimenDate medicineTimenDate = new MedicineTimenDate();
        medicineTimenDate = MedicineTimenDateManager.GetMedicineTimenDateByID(Int32.Parse(Request.QueryString["medicineTimenDateID"]));

        ddlMedicationTime.SelectedValue = medicineTimenDate.MedicationTimeID.ToString();
        txtMedicineDate.Text = medicineTimenDate.MedicineDate;
    }
    private void loadMedicationTime()
    {
        ListItem li = new ListItem("Select MedicationTime...", "0");
        ddlMedicationTime.Items.Add(li);

        List<MedicationTime> medicationTimes = new List<MedicationTime>();
        medicationTimes = MedicationTimeManager.GetAllMedicationTimes();
        foreach (MedicationTime medicationTime in medicationTimes)
        {
            ListItem item = new ListItem(medicationTime.MedicationTimeName.ToString(), medicationTime.MedicationTimeID.ToString());
            ddlMedicationTime.Items.Add(item);
        }
    }
}
