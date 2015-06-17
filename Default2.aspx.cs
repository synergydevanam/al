using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        for (int i = 1; i <=35; i++)
        {
            Label1.Text+= "<br/><img  src='http://www.equranschool.com/qaida-images/"+i.ToString("00")+".jpg' />";
            
        }
    }
}