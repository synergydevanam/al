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

public class SqlAL_HelpTypeProvider:DataAccessObject
{
	public SqlAL_HelpTypeProvider()
    {
    }


    public bool DeleteAL_HelpType(int aL_HelpTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AL_DeleteAL_HelpType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AL_HelpTypeID", SqlDbType.Int).Value = aL_HelpTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<AL_HelpType> GetAllAL_HelpTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AL_GetAllAL_HelpTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAL_HelpTypesFromReader(reader);
        }
    }
    public List<AL_HelpType> GetAL_HelpTypesFromReader(IDataReader reader)
    {
        List<AL_HelpType> aL_HelpTypes = new List<AL_HelpType>();

        while (reader.Read())
        {
            aL_HelpTypes.Add(GetAL_HelpTypeFromReader(reader));
        }
        return aL_HelpTypes;
    }

    public AL_HelpType GetAL_HelpTypeFromReader(IDataReader reader)
    {
        try
        {
            AL_HelpType aL_HelpType = new AL_HelpType
                (
                    (int)reader["AL_HelpTypeID"],
                    reader["HelpTypeName"].ToString()
                );
             return aL_HelpType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public AL_HelpType GetAL_HelpTypeByID(int aL_HelpTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AL_GetAL_HelpTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AL_HelpTypeID", SqlDbType.Int).Value = aL_HelpTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAL_HelpTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAL_HelpType(AL_HelpType aL_HelpType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AL_InsertAL_HelpType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AL_HelpTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HelpTypeName", SqlDbType.NVarChar).Value = aL_HelpType.HelpTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AL_HelpTypeID"].Value;
        }
    }

    public bool UpdateAL_HelpType(AL_HelpType aL_HelpType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AL_UpdateAL_HelpType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AL_HelpTypeID", SqlDbType.Int).Value = aL_HelpType.AL_HelpTypeID;
            cmd.Parameters.Add("@HelpTypeName", SqlDbType.NVarChar).Value = aL_HelpType.HelpTypeName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
