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

public partial class AdminDoctorsOrderInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadResident();
            if (Request.QueryString["doctorsOrderID"] != null)
            {
                int doctorsOrderID = Int32.Parse(Request.QueryString["doctorsOrderID"]);
                if (doctorsOrderID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showDoctorsOrderData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DoctorsOrder doctorsOrder = new DoctorsOrder();

        doctorsOrder.ClinicalFindings = txtClinicalFindings.Text;
        doctorsOrder.Orders = txtOrders.Text;
        doctorsOrder.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        doctorsOrder.OrderDate = txtOrderDate.Text;
        doctorsOrder.AddeBy = Int32.Parse(txtAddeBy.Text);
        doctorsOrder.AddedDate = DateTime.Now;
        doctorsOrder.UpdatedBy = Int32.Parse(txtUpdatedBy.Text);
        doctorsOrder.UpdatedDate = txtUpdatedDate.Text;
        doctorsOrder.ExtraField1 = txtExtraField1.Text;
        doctorsOrder.ExtraField2 = txtExtraField2.Text;
        doctorsOrder.ExtraField3 = txtExtraField3.Text;
        doctorsOrder.ExtraField4 = txtExtraField4.Text;
        doctorsOrder.ExtraField5 = txtExtraField5.Text;
        int resutl = DoctorsOrderManager.InsertDoctorsOrder(doctorsOrder);
        Response.Redirect("AdminDoctorsOrderDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DoctorsOrder doctorsOrder = new DoctorsOrder();
        doctorsOrder = DoctorsOrderManager.GetDoctorsOrderByID(Int32.Parse(Request.QueryString["doctorsOrderID"]));
        DoctorsOrder tempDoctorsOrder = new DoctorsOrder();
        tempDoctorsOrder.DoctorsOrderID = doctorsOrder.DoctorsOrderID;

        tempDoctorsOrder.ClinicalFindings = txtClinicalFindings.Text;
        tempDoctorsOrder.Orders = txtOrders.Text;
        tempDoctorsOrder.ResidentID = Int32.Parse(ddlResident.SelectedValue);
        tempDoctorsOrder.OrderDate = txtOrderDate.Text;
        tempDoctorsOrder.AddeBy = Int32.Parse(txtAddeBy.Text);
        tempDoctorsOrder.AddedDate = DateTime.Now;
        tempDoctorsOrder.UpdatedBy = Int32.Parse(txtUpdatedBy.Text);
        tempDoctorsOrder.UpdatedDate = txtUpdatedDate.Text;
        tempDoctorsOrder.ExtraField1 = txtExtraField1.Text;
        tempDoctorsOrder.ExtraField2 = txtExtraField2.Text;
        tempDoctorsOrder.ExtraField3 = txtExtraField3.Text;
        tempDoctorsOrder.ExtraField4 = txtExtraField4.Text;
        tempDoctorsOrder.ExtraField5 = txtExtraField5.Text;
        bool result = DoctorsOrderManager.UpdateDoctorsOrder(tempDoctorsOrder);
        Response.Redirect("AdminDoctorsOrderDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtClinicalFindings.Text = "";
        txtOrders.Text = "";
        ddlResident.SelectedIndex = 0;
        txtOrderDate.Text = "";
        txtAddeBy.Text = "";
        txtUpdatedBy.Text = "";
        txtUpdatedDate.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
    }
    private void showDoctorsOrderData()
    {
        DoctorsOrder doctorsOrder = new DoctorsOrder();
        doctorsOrder = DoctorsOrderManager.GetDoctorsOrderByID(Int32.Parse(Request.QueryString["doctorsOrderID"]));

        txtClinicalFindings.Text = doctorsOrder.ClinicalFindings;
        txtOrders.Text = doctorsOrder.Orders;
        ddlResident.SelectedValue = doctorsOrder.ResidentID.ToString();
        txtOrderDate.Text = doctorsOrder.OrderDate;
        txtAddeBy.Text = doctorsOrder.AddeBy.ToString();
        txtUpdatedBy.Text = doctorsOrder.UpdatedBy.ToString();
        txtUpdatedDate.Text = doctorsOrder.UpdatedDate;
        txtExtraField1.Text = doctorsOrder.ExtraField1;
        txtExtraField2.Text = doctorsOrder.ExtraField2;
        txtExtraField3.Text = doctorsOrder.ExtraField3;
        txtExtraField4.Text = doctorsOrder.ExtraField4;
        txtExtraField5.Text = doctorsOrder.ExtraField5;
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
