using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

/// <summary>
/// Summary description for authenticationAPI
/// </summary>
public class authenticationAPI
{
    public authenticationAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void validateAuthorization(authenticationData iData)
    {
        SqlConnection ConnString = new SqlConnection();

        if (siteSettings.apiEnvy == siteSettings.development)
        {
            //using development connection
            ConnString.ConnectionString = siteSettings.apiDevDBConnection;
        }
        else
        {
            //using production connectin
            ConnString.ConnectionString = siteSettings.apiLiveDBConnection;
        }

        string sp_Use = "spValidateAuthentication";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@siteurl", iData.siteURL);
        SqlSP.Parameters.AddWithValue("@authtype", iData.siteAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            DataRow thisdr = ds.Tables[0].Rows[0];
            iData.siteAuthenticated = thisdr["authenticated"].ToString();
        }
        else
        {
            iData.siteAuthenticated = "false";
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }
}