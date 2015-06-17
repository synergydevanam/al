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

public class AL_HelpTypeManager
{
	public AL_HelpTypeManager()
	{
	}

    public static List<AL_HelpType> GetAllAL_HelpTypes()
    {
        List<AL_HelpType> aL_HelpTypes = new List<AL_HelpType>();
        SqlAL_HelpTypeProvider sqlAL_HelpTypeProvider = new SqlAL_HelpTypeProvider();
        aL_HelpTypes = sqlAL_HelpTypeProvider.GetAllAL_HelpTypes();
        return aL_HelpTypes;
    }


    public static AL_HelpType GetAL_HelpTypeByID(int id)
    {
        AL_HelpType aL_HelpType = new AL_HelpType();
        SqlAL_HelpTypeProvider sqlAL_HelpTypeProvider = new SqlAL_HelpTypeProvider();
        aL_HelpType = sqlAL_HelpTypeProvider.GetAL_HelpTypeByID(id);
        return aL_HelpType;
    }


    public static int InsertAL_HelpType(AL_HelpType aL_HelpType)
    {
        SqlAL_HelpTypeProvider sqlAL_HelpTypeProvider = new SqlAL_HelpTypeProvider();
        return sqlAL_HelpTypeProvider.InsertAL_HelpType(aL_HelpType);
    }


    public static bool UpdateAL_HelpType(AL_HelpType aL_HelpType)
    {
        SqlAL_HelpTypeProvider sqlAL_HelpTypeProvider = new SqlAL_HelpTypeProvider();
        return sqlAL_HelpTypeProvider.UpdateAL_HelpType(aL_HelpType);
    }

    public static bool DeleteAL_HelpType(int aL_HelpTypeID)
    {
        SqlAL_HelpTypeProvider sqlAL_HelpTypeProvider = new SqlAL_HelpTypeProvider();
        return sqlAL_HelpTypeProvider.DeleteAL_HelpType(aL_HelpTypeID);
    }
}
