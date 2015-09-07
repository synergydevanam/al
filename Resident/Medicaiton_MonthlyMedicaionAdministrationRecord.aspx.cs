using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadMedicine();
            if (Request.QueryString["ResidentID"] != null)
            {
                a_Report.HRef = "Medication_MonthlyPrint.aspx?Title=Monthly medication Report&ResidentID=" + Request.QueryString["ResidentID"];
                laodResitentInfo();
                loadMedicineTimenDateDate();
            }
            loadGrid();

        }
    }

    private void loadMedicine()
    {
        ddlMedicine.Items.Clear();
        ListItem li = new ListItem("New Medicine", "0");
        ddlMedicine.Items.Add(li);

        List<Medicine> medicines = new List<Medicine>();
        medicines = MedicineManager.GetAllMedicines();
        foreach (Medicine medicine in medicines)
        {
            bool isDuplicate=false;
            foreach (ListItem itemddl in ddlMedicine.Items)
            {
                if (itemddl.Text == medicine.MedicineName)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                ListItem item = new ListItem(medicine.MedicineName.ToString(), medicine.MedicineID.ToString());
                ddlMedicine.Items.Add(item);
            }
        }
    }

    private void loadMedicineTimenDateDate()
    {
        ddlExistingRecord.Items.Clear();

        ListItem li = new ListItem("New Record", "0");
        ddlExistingRecord.Items.Add(li);

        DataSet ds = MedicineTimenDateManager.GetAllMedicineTimenDatesDistinctDateByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        foreach (DataRow assessmentnCareDate in ds.Tables[0].Rows)
        {
            ListItem item = new ListItem(DateTime.Parse(assessmentnCareDate["MedicineDate"].ToString()).ToString("yyyy-MM-dd hh:mm tt"), DateTime.Parse(assessmentnCareDate["MedicineDate"].ToString()).ToString("yyyy-MM-dd hh:mm tt"));
            ddlExistingRecord.Items.Add(item);
        }
    }

    private void laodResitentInfo()
    {
        try
        {
            
        }
        catch (Exception ex)
        { }
    }

    private void loadGrid()
    {
        DataSet ds = new DataSet();
        if (ddlShowStaus.SelectedValue == "All")
        {
            ds = MedicationTimeManager.GetAllMedicationTimesByResident(int.Parse(Request.QueryString["ResidentID"]));
        }
        else
        {
            ds = MedicationTimeManager.GetAllMedicationTimesByResidentByStatus(int.Parse(Request.QueryString["ResidentID"]), ddlShowStaus.SelectedValue);
        }

        gvMedicaiton.DataSource = ds.Tables[0];
        gvMedicaiton.DataBind();
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
        if (ddlExistingRecord.SelectedValue != "0")
        {
            string DateRange = " and MedicineDate >= '" + DateTime.Parse(ddlExistingRecord.SelectedValue) + "' and MedicineDate <= '" + DateTime.Parse(ddlExistingRecord.SelectedValue).AddMinutes(1) + "'";
            MedicineTimenDateManager.DeleteMedicineTimenDateByResidentID(int.Parse(Request.QueryString["ResidentID"]), DateRange);
        }
        foreach (GridViewRow gvr in gvMedicaiton.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                TextBox txtComment = (TextBox)gvr.FindControl("txtComment");
                MedicineTimenDate medicineTimenDate = new MedicineTimenDate();

                medicineTimenDate.MedicationTimeID = Int32.Parse(chkSelect.ValidationGroup);
                medicineTimenDate.MedicineDate = ddlExistingRecord.SelectedValue == "0" ? DateTime.Now : DateTime.Parse(ddlExistingRecord.SelectedValue);
                medicineTimenDate.ExtraField1 = txtComment.Text;
                medicineTimenDate.ExtraField2 = getLogin().LoginID.ToString();
                medicineTimenDate.ExtraField3 = getLogin().ExtraField4;
                MedicineTimenDateManager.InsertMedicineTimenDate(medicineTimenDate);
            }
        }

        lblMsg.Visible = true;
        lblNewMedicationAddedSuccessfully.Visible = false;


        loadMedicineTimenDateDate();
        foreach (GridViewRow gvr in gvMedicaiton.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            chkSelect.Checked = false;
        }
    }

    private string getChiledIds()
    {
        

        return "";
    }

    private string getCommentsByParentIDs()
    {
        string CommentsByParentIDs = "";
        
        return CommentsByParentIDs;
    }
    protected void ddlExistingRecord_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSelectData();
        if (ddlExistingRecord.SelectedIndex != 0)
        {
            btnSave.Visible = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("btnSave", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
        }
        else
        {
            btnSave.Visible = true;
        }
    }

    private void loadSelectData()
    {
        List<MedicineTimenDate> allMedicineTimenDate = new List<MedicineTimenDate>();
        if (ddlExistingRecord.SelectedValue != "0")
        {
            string searchString = " and MedicineDate >= '" + DateTime.Parse(ddlExistingRecord.SelectedValue) + "' and MedicineDate <= '" + DateTime.Parse(ddlExistingRecord.SelectedValue).AddMinutes(1) + "'";
            allMedicineTimenDate = MedicineTimenDateManager.GetAllMedicineTimenDatesDistinctDateByResidentIDnDate(int.Parse(Request.QueryString["ResidentID"]), searchString);
        }

        foreach (GridViewRow gvr in gvMedicaiton.Rows)
          {
              CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
              TextBox txtComment = (TextBox)gvr.FindControl("txtComment");
              Label lblSavedBy = (Label)gvr.FindControl("lblSavedBy");

              chkSelect.Checked = false;
              lblSavedBy.Text = "";
              txtComment.Text = "";
              foreach (MedicineTimenDate item in allMedicineTimenDate)
              {
                  if (chkSelect.ValidationGroup==item.MedicationTimeID.ToString())
                  {
                      chkSelect.Checked = true;
                      txtComment.Text = item.ExtraField1;
                      lblSavedBy.Text = item.ExtraField3;
                  } 
              }
          }   
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtNewMedicine.Text != "")
        {
            Medicine medicine = new Medicine();

            medicine.MedicineName = txtNewMedicine.Text;
            medicine.MedicineID = MedicineManager.InsertMedicine(medicine);
            loadMedicine();
            ddlMedicine.SelectedValue = medicine.MedicineID.ToString();
        }
        if (hfMedicationTimeID.Value == "0")
        {
            //if (!txtTakingTime.Text.Contains(","))
            //{
            //    txtTakingTime.Text = txtTakingTime.Text + ",";
            //}

            //foreach (string item in txtTakingTime.Text.Split(','))
            //{
            //    if (item != "")
            //    {
                    MedicationTime medicationTime = new MedicationTime();

                    medicationTime.TakingTime = chkPRN.Checked ? "PRN" : txtTakingTime.Text;
                    medicationTime.MedicineID = Int32.Parse(ddlMedicine.SelectedValue);
                    medicationTime.ResidentID = Int32.Parse(Request.QueryString["ResidentID"]);
                    medicationTime.Quantity = txtQuantity.Text;
                    medicationTime.Quality = txtQuality.Text;
                    medicationTime.Frequency = txtFrequency.Text;
                    medicationTime.ExtraField1 = txtEXNo.Text;
                    medicationTime.ExtraField2 = ddlRouteOfAdmin.SelectedValue;
                    medicationTime.ExtraField3 = txtAmount.Text;
                    medicationTime.ExtraField4 = txtpharmacyName.Text;
                    medicationTime.ExtraField5 = chkAddDischargeRecord.Checked.ToString();
                    medicationTime.ExtraField6 = ddlStatus.SelectedValue;
                    medicationTime.ExtraField7 = txtDateExpires.Text;
                    medicationTime.ExtraField8 = "";
                    medicationTime.ExtraField9 = "";
                    medicationTime.ExtraField10 = "";
                    medicationTime.AddedBy = getLogin().LoginID;
                    medicationTime.AddedDate = DateTime.Now;
                    medicationTime.UpdateBy = getLogin().LoginID;
                    medicationTime.UpdateDate = DateTime.Now;
                    int resutl = MedicationTimeManager.InsertMedicationTime(medicationTime);
                    lblNewMedicationAddedSuccessfully.Text = "Added Successfully";

            //    }
            //}
        }
        else
        {
            MedicationTime medicationTime = new MedicationTime();
            medicationTime.MedicationTimeID= int.Parse(hfMedicationTimeID.Value);
            medicationTime.TakingTime = chkPRN.Checked ? "PRN" : txtTakingTime.Text;
            medicationTime.MedicineID = Int32.Parse(ddlMedicine.SelectedValue);
            medicationTime.ResidentID = Int32.Parse(Request.QueryString["ResidentID"]);
            medicationTime.Quantity = txtQuantity.Text;
            medicationTime.Quality = txtQuality.Text;
            medicationTime.Frequency = txtFrequency.Text;
            medicationTime.ExtraField1 = txtEXNo.Text;
            medicationTime.ExtraField2 = ddlRouteOfAdmin.SelectedValue;
            medicationTime.ExtraField3 = txtAmount.Text;
            medicationTime.ExtraField4 = txtpharmacyName.Text;
            medicationTime.ExtraField5 = chkAddDischargeRecord.Checked.ToString();
            medicationTime.ExtraField6 = ddlStatus.SelectedValue;
            medicationTime.ExtraField7 = txtDateExpires.Text;
            medicationTime.ExtraField8 = "";
            medicationTime.ExtraField9 = "";
            medicationTime.ExtraField10 = "";
            medicationTime.AddedBy = getLogin().LoginID;
            medicationTime.AddedDate = DateTime.Now;
            medicationTime.UpdateBy = getLogin().LoginID;
            medicationTime.UpdateDate = DateTime.Now;

            MedicationTimeManager.UpdateMedicationTime(medicationTime);
            hfMedicationTimeID.Value = "0";
            lblNewMedicationAddedSuccessfully.Text = "Update Successfully";
        }

        lblMsg.Visible = false;
        lblNewMedicationAddedSuccessfully.Visible = true;
        //ddlMedicine.SelectedValue = "0";
        //txtTakingTime.Text = "";
        //txtQuality.Text = "";
        //txtQuantity.Text = "";
        //txtFrequency.Text = "";
        
        loadGrid();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //if (ddlPrintOption.SelectedValue == "1")
        //{
        //    Response.Redirect("Medication_DischargeMedicaitonLealeaseRecordPrint.aspx?ResidentID=" + Request.QueryString["ResidentID"] + "&Title=DISCHARGE MEDICATION RELEASE RECORD&PrintOption=" + ddlPrintOption.SelectedValue);
        //}
        //else
        //{
            Response.Redirect("Medication_AdmissionMedicaitonProfilePrint.aspx?ResidentID=" + Request.QueryString["ResidentID"] + "&Title=ADMISSION MEDICATION PROFILE&PrintOption=" + ddlPrintOption.SelectedValue+"&MedicationList="+ddlMedicationList.SelectedValue);
        //}
    }

    protected void lbEdit_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        MedicationTime medicationTime= MedicationTimeManager.GetMedicationTimeByID(id);
        hfMedicationTimeID.Value = medicationTime.MedicationTimeID.ToString();
        txtTakingTime.Text = medicationTime.TakingTime == "PRN" ? "" : medicationTime.TakingTime;
        chkPRN.Checked = medicationTime.TakingTime == "PRN" ? true : false;
        string medicationName = MedicineManager.GetMedicineByID(medicationTime.MedicineID).MedicineName;
        int medicaitonID = 0;
        foreach (ListItem item in ddlMedicine.Items)
        {
            if (item.Text == medicationName)
            {
                medicaitonID = int.Parse(item.Value);
            }
        }

        ddlMedicine.SelectedValue = medicaitonID.ToString();
        
        
        txtQuantity.Text= medicationTime.Quantity;
        txtQuality.Text= medicationTime.Quality;
        txtFrequency.Text = medicationTime.Frequency;
        txtEXNo.Text =medicationTime.ExtraField1  ;
        ddlRouteOfAdmin.SelectedValue =medicationTime.ExtraField2 ;
        txtAmount.Text=medicationTime.ExtraField3;
        txtpharmacyName.Text=medicationTime.ExtraField4;
        ddlStatus.SelectedValue = medicationTime.ExtraField6 != null ? medicationTime.ExtraField6 : "Active";
        //chkAddDischargeRecord.Checked=bool.Parse(medicationTime.ExtraField5);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        MedicationTimeManager.DeleteMedicationTime(id);
        loadGrid();
    }
    protected void ddlShowStaus_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadGrid();
    }
}