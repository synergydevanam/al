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

public partial class AdminMedicineInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["medicineID"] != null)
            {
                int medicineID = Int32.Parse(Request.QueryString["medicineID"]);
                if (medicineID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showMedicineData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Medicine medicine = new Medicine();

        medicine.MedicineName = txtMedicineName.Text;
        int resutl = MedicineManager.InsertMedicine(medicine);
        Response.Redirect("AdminMedicineDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Medicine medicine = new Medicine();
        medicine = MedicineManager.GetMedicineByID(Int32.Parse(Request.QueryString["medicineID"]));
        Medicine tempMedicine = new Medicine();
        tempMedicine.MedicineID = medicine.MedicineID;

        tempMedicine.MedicineName = txtMedicineName.Text;
        bool result = MedicineManager.UpdateMedicine(tempMedicine);
        Response.Redirect("AdminMedicineDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMedicineName.Text = "";
    }
    private void showMedicineData()
    {
        Medicine medicine = new Medicine();
        medicine = MedicineManager.GetMedicineByID(Int32.Parse(Request.QueryString["medicineID"]));

        txtMedicineName.Text = medicine.MedicineName;
    }
}
