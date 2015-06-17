using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlAL_HelpProvider:DataAccessObject
{
	public SqlAL_HelpProvider()
    {
    }


    public bool DeleteAL_Help(int aL_HelpID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AL_DeleteAL_Help", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AL_HelpID", SqlDbType.Int).Value = aL_HelpID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<AL_Help> GetAllAL_Helps()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AL_GetAllAL_Helps", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAL_HelpsFromReader(reader);
        }
    }
    public List<AL_Help> GetAL_HelpsFromReader(IDataReader reader)
    {
        List<AL_Help> aL_Helps = new List<AL_Help>();

        while (reader.Read())
        {
            aL_Helps.Add(GetAL_HelpFromReader(reader));
        }
        return aL_Helps;
    }

    public AL_Help GetAL_HelpFromReader(IDataReader reader)
    {
        try
        {
            AL_Help aL_Help = new AL_Help
                (
                    (int)reader["AL_HelpID"],
                    (int)reader["HelpTypeID"],
                    reader["Question"].ToString(),
                    reader["Answer"].ToString()
                );
            try
            {
                aL_Help.HelpTypeName = reader["HelpTypeName"].ToString();
            }
            catch (Exception ex)
            {
               
            }

             return aL_Help;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public AL_Help GetAL_HelpByID(int aL_HelpID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AL_GetAL_HelpByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AL_HelpID", SqlDbType.Int).Value = aL_HelpID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAL_HelpFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAL_Help(AL_Help aL_Help)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AL_InsertAL_Help", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AL_HelpID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HelpTypeID", SqlDbType.Int).Value = aL_Help.HelpTypeID;
            cmd.Parameters.Add("@Question", SqlDbType.NText).Value = aL_Help.Question;
            cmd.Parameters.Add("@Answer", SqlDbType.NText).Value = aL_Help.Answer;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AL_HelpID"].Value;
        }
    }

    public bool UpdateAL_Help(AL_Help aL_Help)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AL_UpdateAL_Help", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AL_HelpID", SqlDbType.Int).Value = aL_Help.AL_HelpID;
            cmd.Parameters.Add("@HelpTypeID", SqlDbType.Int).Value = aL_Help.HelpTypeID;
            cmd.Parameters.Add("@Question", SqlDbType.NText).Value = aL_Help.Question;
            cmd.Parameters.Add("@Answer", SqlDbType.NText).Value = aL_Help.Answer;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
