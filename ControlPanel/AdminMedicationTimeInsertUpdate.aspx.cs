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

public partial class AdminMedicationTimeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadMedicine();
            loadResident();
            if (Request.QueryString["medicationTimeID"] != null)
            {
                int medicationTimeID = Int32.Parse(Request.QueryString["medicationTimeID"]);
                if (medicationTimeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showMedicationTimeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        MedicationTime medicationTime = new MedicationTime();

        medicationTime.TakingTime = txtTakingTime.Text;
        medicationTime.MedicineID = Int32.Parse(ddlMedicine.SelectedValue);
        medicationTime.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        medicationTime.Quantity = txtQuantity.Text;
        medicationTime.Quality = txtQuality.Text;
        medicationTime.Frequency = txtFrequency.Text;
        medicationTime.ExtraField1 = txtExtraField1.Text;
        medicationTime.ExtraField2 = txtExtraField2.Text;
        medicationTime.AddedBy = Int32.Parse(txtAddedBy.Text);
        medicationTime.AddedDate = DateTime.Now;
        medicationTime.UpdateBy = Int32.Parse(txtUpdateBy.Text);
        medicationTime.UpdateDate = txtUpdateDate.Text;
        int resutl = MedicationTimeManager.InsertMedicationTime(medicationTime);
        Response.Redirect("AdminMedicationTimeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        MedicationTime medicationTime = new MedicationTime();
        medicationTime = MedicationTimeManager.GetMedicationTimeByID(Int32.Parse(Request.QueryString["medicationTimeID"]));
        MedicationTime tempMedicationTime = new MedicationTime();
        tempMedicationTime.MedicationTimeID = medicationTime.MedicationTimeID;

        tempMedicationTime.TakingTime = txtTakingTime.Text;
        tempMedicationTime.MedicineID = Int32.Parse(ddlMedicine.SelectedValue);
        tempMedicationTime.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        tempMedicationTime.Quantity = txtQuantity.Text;
        tempMedicationTime.Quality = txtQuality.Text;
        tempMedicationTime.Frequency = txtFrequency.Text;
        tempMedicationTime.ExtraField1 = txtExtraField1.Text;
        tempMedicationTime.ExtraField2 = txtExtraField2.Text;
        tempMedicationTime.AddedBy = Int32.Parse(txtAddedBy.Text);
        tempMedicationTime.AddedDate = DateTime.Now;
        tempMedicationTime.UpdateBy = Int32.Parse(txtUpdateBy.Text);
        tempMedicationTime.UpdateDate = txtUpdateDate.Text;
        bool result = MedicationTimeManager.UpdateMedicationTime(tempMedicationTime);
        Response.Redirect("AdminMedicationTimeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtTakingTime.Text = "";
        ddlMedicine.SelectedIndex = 0;
        ddlResident.SelectedIndex = 0;
        txtQuantity.Text = "";
        txtQuality.Text = "";
        txtFrequency.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtAddedBy.Text = "";
        txtUpdateBy.Text = "";
        txtUpdateDate.Text = "";
    }
    private void showMedicationTimeData()
    {
        MedicationTime medicationTime = new MedicationTime();
        medicationTime = MedicationTimeManager.GetMedicationTimeByID(Int32.Parse(Request.QueryString["medicationTimeID"]));

        txtTakingTime.Text = medicationTime.TakingTime;
        ddlMedicine.SelectedValue = medicationTime.MedicineID.ToString();
        ddlResident.SelectedValue = medicationTime.ResidentID.ToString();
        txtQuantity.Text = medicationTime.Quantity;
        txtQuality.Text = medicationTime.Quality;
        txtFrequency.Text = medicationTime.Frequency;
        txtExtraField1.Text = medicationTime.ExtraField1;
        txtExtraField2.Text = medicationTime.ExtraField2;
        txtAddedBy.Text = medicationTime.AddedBy.ToString();
        txtUpdateBy.Text = medicationTime.UpdateBy.ToString();
        txtUpdateDate.Text = medicationTime.UpdateDate;
    }
    private void loadMedicine()
    {
        ListItem li = new ListItem("Select Medicine...", "0");
        ddlMedicine.Items.Add(li);

        List<Medicine> medicines = new List<Medicine>();
        medicines = MedicineManager.GetAllMedicines();
        foreach (Medicine medicine in medicines)
        {
            ListItem item = new ListItem(medicine.MedicineName.ToString(), medicine.MedicineID.ToString());
            ddlMedicine.Items.Add(item);
        }
    }
    private void loadResident()
    {
        ListItem li = new ListItem("Select Resident...", "0");
        ddlResident.Items.Add(li);

        List<Resident> residents = new List<Resident>();
        residents = ResidentManager.GetAllResidents();
        foreach (Resident resident in residents)
        {
            ListItem item = new ListItem(resident.ResidentName.ToString(), resident.ResidentID.ToString());
            ddlResident.Items.Add(item);
        }
    }
}
