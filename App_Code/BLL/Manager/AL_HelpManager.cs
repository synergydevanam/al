using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class AL_HelpManager
{
	public AL_HelpManager()
	{
	}

    public static List<AL_Help> GetAllAL_Helps()
    {
        List<AL_Help> aL_Helps = new List<AL_Help>();
        SqlAL_HelpProvider sqlAL_HelpProvider = new SqlAL_HelpProvider();
        aL_Helps = sqlAL_HelpProvider.GetAllAL_Helps();
        return aL_Helps;
    }


    public static AL_Help GetAL_HelpByID(int id)
    {
        AL_Help aL_Help = new AL_Help();
        SqlAL_HelpProvider sqlAL_HelpProvider = new SqlAL_HelpProvider();
        aL_Help = sqlAL_HelpProvider.GetAL_HelpByID(id);
        return aL_Help;
    }


    public static int InsertAL_Help(AL_Help aL_Help)
    {
        SqlAL_HelpProvider sqlAL_HelpProvider = new SqlAL_HelpProvider();
        return sqlAL_HelpProvider.InsertAL_Help(aL_Help);
    }


    public static bool UpdateAL_Help(AL_Help aL_Help)
    {
        SqlAL_HelpProvider sqlAL_HelpProvider = new SqlAL_HelpProvider();
        return sqlAL_HelpProvider.UpdateAL_Help(aL_Help);
    }

    public static bool DeleteAL_Help(int aL_HelpID)
    {
        SqlAL_HelpProvider sqlAL_HelpProvider = new SqlAL_HelpProvider();
        return sqlAL_HelpProvider.DeleteAL_Help(aL_HelpID);
    }
}
