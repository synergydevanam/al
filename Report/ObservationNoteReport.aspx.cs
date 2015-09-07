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
            txtDateFrom.Text = DateTime.Today.AddDays(-7).ToString("MM/dd/yyyy");
            txtDateTo.Text = DateTime.Today.ToString("MM/dd/yyyy");
            loadGrid();
        }
    }

   

    private void laodResitentInfo()
    {
        
    }


    private void loadGrid()
    {
        string sql = @"
Update [AL_Property] set PropertyName= CAST(Address as nvarchar)

 SELECT [ObservationNoteID]
      ,[Note]
      ,AL_ObservationNote.[ResidentID]
      ,[AddeBy]
      ,[AddedDate]
      ,AL_ObservationNote.[ExtraField1]
      ,AL_ObservationNote.[ExtraField2]
      ,ObservationType.ObservationTypeName as ExtraField3
      ,AL_ObservationNote.[ExtraField4]
      ,AL_ObservationNote.[ExtraField5] 
      ,AL_Resident.Name
      ,AL_Property.PropertyName
      FROM AL_ObservationNote
      inner join ObservationType on CAST(ObservationType.ObservationTypeID as nvarchar(256)) = AL_ObservationNote.ExtraField2
      inner join AL_Resident on AL_Resident.ResidentID=AL_ObservationNote.ResidentID
      inner join AL_Property on AL_Resident.ExtraField1=AL_Property.PropertyID
where AL_Property.PropertyID in (0" + (getLogin().ExtraField3 == "" ? "" : "," + getLogin().ExtraField3) + ") and AddedDate between '" + DateTime.Parse(txtDateFrom.Text).ToString("yyyy-MM-dd") + @"' and '" + DateTime.Parse(txtDateTo.Text).AddDays(+1).ToString("yyyy-MM-dd") + @"'
    order by 
AL_Property.PropertyName asc,
AL_Resident.Name asc,[AddedDate] desc
";
        DataSet ds = DatabaseManager.ExecSQL(sql);
        string html = @"<table cellspacing='0' border='1' style='width: 100%; border-collapse: collapse;'>
        <tbody>";
        string lastPropertyName = "";
        string ResidentID = "";
        int serial = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (lastPropertyName != dr["PropertyName"].ToString())
            {
                lastPropertyName = dr["PropertyName"].ToString();
                html += "<tr style='background-color:#6FACDF;font-size:20px;'><td colspan='6'>Property: " + dr["PropertyName"].ToString() + @"</td></tr>";
            }

            if (ResidentID != dr["ResidentID"].ToString())
            {
                ResidentID = dr["ResidentID"].ToString();
                html += "<tr><td colspan='6'>" + dr["Name"].ToString() + @"</td></tr>
<tr>
                <th scope='col'>
                    No
                </th>
                <th scope='col'>
                    Date
                </th>
                <th scope='col'>
                    Time
                </th>
                <th scope='col'>
                    Made By
                </th>
                <th scope='col'>
                    Type
                </th>
                <th scope='col'>
                    Observation / Comment
                </th>
            </tr>
";
                serial = 0;
            }

            html += @"
<tr>
                <td>
                    "+(++serial)+@"
                </td>
                <td>
                    " + DateTime.Parse(dr["AddedDate"].ToString()).ToString("MM/dd/yyyy") + @"
                </td>
                <td>
                    " + DateTime.Parse(dr["AddedDate"].ToString()).ToString("hh:mm tt") + @"
                </td>
                <td>
                    " + dr["ExtraField1"].ToString() + @"
                </td>
                <td>
                    " + dr["ExtraField3"].ToString() + @"
                </td>
                <td style='width: 500px;'>
                    " + dr["Note"].ToString() + @"
                </td>
            </tr>
";

        }

        html += @"</tbody>
    </table>";
            //gvObservationNote.DataSource = ds.Tables[0];
            //gvObservationNote.DataBind();
        lblPrint.Text = html;  
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

    
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadGrid();
    }
}