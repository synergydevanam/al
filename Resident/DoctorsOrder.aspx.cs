﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Resident_ADLRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ResidentID"] != null)
            {
                laodResitentInfo();
                loadGrid();
                loadDoctorsOrderDate();
                showDocument();
                txtOrderDate.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            string dirUrl = "ResidentFile";
            string dirPath = Server.MapPath(dirUrl);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fileName = Path.GetFileName(uplFile.PostedFile.FileName);

            if (fileName.Split('.')[1].Contains("php")
                ||
                fileName.Split('.')[1].Contains("aspx")
                ||
                fileName.Split('.')[1].Contains("asp")
                )
            {

                Label1.Text = "Wrong File!!";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
                return;
            }
            else
            {
                Label1.Visible = false;
                Label1.Text = "Update Successfully";
                Label1.ForeColor = System.Drawing.Color.Green;
            }

            getFileName file = new getFileName(fileName, dirPath);
            string fileUrl = dirUrl + "/" + file.FileName;//Path.GetFileName(uplFile.PostedFile.FileName);
            string filePath = Server.MapPath(fileUrl);
            uplFile.PostedFile.SaveAs(filePath);

            var clientId = int.Parse(Request.QueryString["residentID"]);

            Document dm = new Document();
            dm.ClientID = clientId;
            dm.Details = txDocumentDetails.Text;
            dm.FileName = dirUrl + "/" + file.FileName;

            string sql = @"
INSERT INTO [AL_DoctorOrderDocument]
           ([ResidentID]
           ,[Details]
           ,[FileName])
     VALUES
           (" + Request.QueryString["residentID"] + ",'" + dm.Details + @"','" + dm.FileName + @"');
";
            CommonManager.SQLExec(sql);
            txDocumentDetails.Text = "";
            showDocument();

        }
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        DocumentManager.DeleteDocument(int.Parse(linkButton.CommandArgument));
        String sql = @"
Delete FROM AL_DoctorOrderDocument
    WHERE [DocumentID]  = " + linkButton.CommandArgument + @" ;
";

       CommonManager.SQLExec(sql);
        DeleteFileFromFolder(linkButton.ToolTip.Split('/')[1]);
        showDocument();
    }

    public void DeleteFileFromFolder(string StrFilename)
    {

        try
        {
            string strPhysicalFolder = Server.MapPath("..\\Resident\\ResidentFile\\");
            string strFileFullPath = strPhysicalFolder + StrFilename;

            if (System.IO.File.Exists(strFileFullPath))
            {
                System.IO.File.Delete(strFileFullPath);
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void showDocument()
    {
        String sql = @"
SELECT * FROM AL_DoctorOrderDocument
    WHERE [ResidentID]  = " + Request.QueryString["ResidentID"] + @" ;
";

        gvDocument.DataSource = CommonManager.SQLExec(sql).Tables[0] ;
        gvDocument.DataBind();
    }

    private void loadDoctorsOrderDate()
    {
        ddlExistingRecord.Items.Clear();
        ListItem li = new ListItem("New Record", "0");
        ddlExistingRecord.Items.Add(li);

        List<DoctorsOrder> assessmentnCareDates = new List<DoctorsOrder>();
        assessmentnCareDates = DoctorsOrderManager.GetAllDoctorsOrdersByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        foreach (DoctorsOrder assessmentnCareDate in assessmentnCareDates)
        {
            ListItem item = new ListItem(assessmentnCareDate.OrderDate.ToString("yyyy-MM-dd hh:mm tt"), assessmentnCareDate.DoctorsOrderID.ToString());
            ddlExistingRecord.Items.Add(item);
        }
    }

    private void laodResitentInfo()
    {
        Resident resident = ResidentManager.GetResidentByID(int.Parse(Request.QueryString["ResidentID"]));
        
        txtPhysician.Text = resident.AttendingPhysician;
    }

    private void loadGrid()
    {
        loadDoctorsOrderDate();
        //gvDoctorsOrder.DataSource = DoctorsOrderManager.GetAllDoctorsOrdersByResidentID(int.Parse(Request.QueryString["ResidentID"]));
        //gvDoctorsOrder.DataBind();
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
        DoctorsOrder doctorsOrder = new DoctorsOrder();

        doctorsOrder.ClinicalFindings = txtClinicalFindings.Text;
        doctorsOrder.Orders = txtOrder.Text;
        doctorsOrder.ResidentID = Int32.Parse(Request.QueryString["ResidentID"]);
        doctorsOrder.OrderDate = DateTime.Parse(txtOrderDate.Text);
        doctorsOrder.AddeBy = getLogin().LoginID;
        doctorsOrder.AddedDate = DateTime.Now;
        doctorsOrder.UpdatedBy = getLogin().LoginID;
        doctorsOrder.UpdatedDate = DateTime.Now;
        doctorsOrder.ExtraField1 = txtPhysician.Text;
        doctorsOrder.ExtraField2 = txtMRno.Text;
        doctorsOrder.ExtraField3 = getStaffNotified();
        doctorsOrder.ExtraField4 = "";
        doctorsOrder.ExtraField5 = "";
        if (ddlExistingRecord.SelectedIndex == 0)
        {
            int resutl = DoctorsOrderManager.InsertDoctorsOrder(doctorsOrder);
        }
        else
        {
            doctorsOrder.DoctorsOrderID = int.Parse(ddlExistingRecord.SelectedValue);
            DoctorsOrderManager.UpdateDoctorsOrder(doctorsOrder);
        }

        loadGrid();
    }

    private string getStaffNotified()
    { 
        string staffNotified="";

        /*
         <asp:CheckBox ID="chkSN" runat="server" Text="SN"/>
        <asp:CheckBox ID="chkHHA" runat="server" Text="HHA"/>
        <asp:CheckBox ID="chkPT" runat="server" Text="PT"/>
        <asp:CheckBox ID="chkMSW" runat="server" Text="MSW"/>
        <asp:CheckBox ID="chkPATIENT" runat="server" Text="PATIENT"/>
        <br />
        <asp:CheckBox ID="chkOthers" runat="server" Text="OTHER:"/>
        <asp:TextBox ID="txtStaffNotifiedOthers" runat="server" Width="70%" >
        </asp:TextBox>
         */
        if (chkSN.Checked) staffNotified += "SN";
        if (chkHHA.Checked) staffNotified += ", HHA";
        if (chkPT.Checked) staffNotified += ", PT";
        if (chkMSW.Checked) staffNotified += ", MSW";
        if (chkPATIENT.Checked) staffNotified += ", PATIENT";
        if (txtStaffNotifiedOthers.Text!="") staffNotified += ", "+txtStaffNotifiedOthers.Text;

        return staffNotified;
    }

    private void cleanFields()
    {
        txtClinicalFindings.Text ="";
        txtOrder.Text = "";
        txtOrderDate.Text = DateTime.Today.ToString("MM/dd/yyyy hh:mm tt");
        txtMRno.Text = "";

        chkSN.Checked = false;
        chkHHA.Checked = false;
        chkPT.Checked = false;
        chkMSW.Checked = false;
        chkPATIENT.Checked = false;
        chkOthers.Checked = false;
        txtStaffNotifiedOthers.Text = ""; 
    }
     protected void ddlExistingRecord_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSelectData();
        
        a_Print.Visible = true;
        if (ddlExistingRecord.SelectedIndex == 0)
        {
            a_Print.Visible = false;
        }
        a_Print.HRef = "DoctorsOrderPrint.aspx?Title=Doctor's Order&DoctorsOrderID=" + ddlExistingRecord.SelectedValue + "&ResidentID=" + Request.QueryString["ResidentID"];
        
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
         DoctorsOrder doctorsOrder = DoctorsOrderManager.GetDoctorsOrderByID(int.Parse(ddlExistingRecord.SelectedValue));
         txtClinicalFindings.Text=doctorsOrder.ClinicalFindings;
         txtOrder.Text=doctorsOrder.Orders;
         txtOrderDate.Text = doctorsOrder.OrderDate.ToString("MM/dd/yyyy hh:mm tt");
         txtPhysician.Text=doctorsOrder.ExtraField1;
         txtMRno.Text = doctorsOrder.ExtraField2;
         LoadStaffNotified(doctorsOrder.ExtraField3);
     }

     private void LoadStaffNotified(string StaffNotified)
     {
         foreach (string item in StaffNotified.Split(','))
         {
             if (item == "SN") chkSN.Checked = true;
             else if (item == "HHA") chkHHA.Checked = true;
             else if (item == "PT") chkPT.Checked = true;
             else if (item == "MSW") chkMSW.Checked = true;
             else if (item == "PATIENT") chkPATIENT.Checked = true;
             else { chkOthers.Checked = true; txtStaffNotifiedOthers.Text = item; }
         }
     }
}