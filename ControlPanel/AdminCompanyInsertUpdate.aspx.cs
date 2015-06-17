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

public partial class AdminCompanyInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["companyID"] != null)
            {
                int companyID = Int32.Parse(Request.QueryString["companyID"]);
                if (companyID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCompanyData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Company company = new Company();

        company.CompanyName = txtCompanyName.Text;
        int resutl = CompanyManager.InsertCompany(company);
        Response.Redirect("AdminCompanyDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Company company = new Company();
        company = CompanyManager.GetCompanyByID(Int32.Parse(Request.QueryString["companyID"]));
        Company tempCompany = new Company();
        tempCompany.CompanyID = company.CompanyID;

        tempCompany.CompanyName = txtCompanyName.Text;
        bool result = CompanyManager.UpdateCompany(tempCompany);
        Response.Redirect("AdminCompanyDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCompanyName.Text = "";
    }
    private void showCompanyData()
    {
        Company company = new Company();
        company = CompanyManager.GetCompanyByID(Int32.Parse(Request.QueryString["companyID"]));

        txtCompanyName.Text = company.CompanyName;
    }
}
