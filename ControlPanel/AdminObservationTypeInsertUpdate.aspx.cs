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

public partial class AdminObservationTypeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["observationTypeID"] != null)
            {
                int observationTypeID = Int32.Parse(Request.QueryString["observationTypeID"]);
                if (observationTypeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showObservationTypeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObservationType observationType = new ObservationType();

        observationType.ObservationTypeName = txtObservationTypeName.Text;
        int resutl = ObservationTypeManager.InsertObservationType(observationType);
        Response.Redirect("AdminObservationTypeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ObservationType observationType = new ObservationType();
        observationType = ObservationTypeManager.GetObservationTypeByID(Int32.Parse(Request.QueryString["observationTypeID"]));
        ObservationType tempObservationType = new ObservationType();
        tempObservationType.ObservationTypeID = observationType.ObservationTypeID;

        tempObservationType.ObservationTypeName = txtObservationTypeName.Text;
        bool result = ObservationTypeManager.UpdateObservationType(tempObservationType);
        Response.Redirect("AdminObservationTypeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtObservationTypeName.Text = "";
    }
    private void showObservationTypeData()
    {
        ObservationType observationType = new ObservationType();
        observationType = ObservationTypeManager.GetObservationTypeByID(Int32.Parse(Request.QueryString["observationTypeID"]));

        txtObservationTypeName.Text = observationType.ObservationTypeName;
    }
}
