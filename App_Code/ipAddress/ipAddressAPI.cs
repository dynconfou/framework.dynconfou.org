using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ipAddressAPI
/// </summary>
public class ipAddressAPI
{
    public ipAddressAPI()
    {
        //
        // TODO: Add constructor logic here
        //
        /*
            IP ADDRESS - by default allowed - requires 'deny' authorization
        */
    }

    public void addUpdateIPAddress(ipAddressData iData) {
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

        string sp_Use = "spAddUpdateIPAddress";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@ipAddress", iData.ipAddress);
        SqlSP.Parameters.AddWithValue("@ipAuthorization", iData.ipAddressAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.ipGuid = thisdr["ipguid"].ToString();
            iData.ipAddressAction = thisdr["action"].ToString();
            iData.ipAddressAuthorization = thisdr["ipAuthorization"].ToString();
            DataColumnCollection dcc = iData.returnData.Columns;
            if (dcc.Contains("msg"))
            {
                iData.dbMessage = iData.returnData.Rows[0]["msg"].ToString();
            }
        }
        else
        {
            iData.ipAddressAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }

    public void updateIPAddress(ipAddressData iData)
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

        string sp_Use = "spUpdateIPAddressAuthentication";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@ipGuid", iData.ipGuid);
        SqlSP.Parameters.AddWithValue("@ipAuthorization", iData.ipAddressAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.ipAddressAction = thisdr["action"].ToString();            
            DataColumnCollection dcc = iData.returnData.Columns;
            if (dcc.Contains("msg"))
            {
                iData.dbMessage = iData.returnData.Rows[0]["msg"].ToString();
            }
        }
        else
        {
            iData.ipAddressAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }

    public void validateIPAddress(ipAddressData iData)
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

        string sp_Use = "spValidateIPAddress";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@ipAddress", iData.ipAddress);
        SqlSP.Parameters.AddWithValue("@ipAuthorization", iData.ipAddressAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.ipGuid = thisdr["ipguid"].ToString();
            iData.ipAddressAction = thisdr["authenticated"].ToString();
            iData.ipAddressAuthorization = thisdr["ipAuthorization"].ToString();
            if (iData.ipAddressAction == "true")
            {
                //iData.dateCreated = Convert.ToDateTime(thisdr["datecreated"]);
                //iData.dateUpdated = Convert.ToDateTime(thisdr["dateupdated"]);
                //iData.createdHoursAgo = Convert.ToInt16(thisdr["createdhoursago"]);
                //iData.updatedHoursAgo = Convert.ToInt16(thisdr["updatedhoursago"]);
            }
            DataColumnCollection dcc = iData.returnData.Columns;
            if (dcc.Contains("msg"))
            {
                iData.dbMessage = iData.returnData.Rows[0]["msg"].ToString();
            }
        }
        else
        {
            iData.ipAddressAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }

    public void addIPAddress(ipAddressData iData)
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

        string sp_Use = "spAddIPAddress";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@ipAddress", iData.ipAddress);
        SqlSP.Parameters.AddWithValue("@ipAuthorization", iData.ipAddressAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.ipGuid = thisdr["ipguid"].ToString();
            iData.ipAddressAction = thisdr["action"].ToString();            
            iData.ipAddressAuthorization = thisdr["ipAuthorization"].ToString();
            if (iData.ipAddressAction == "exist")
            {
                //iData.dateCreated = Convert.ToDateTime(thisdr["datecreated"]);
                //iData.dateUpdated = Convert.ToDateTime(thisdr["dateupdated"]);
                //iData.createdHoursAgo = Convert.ToInt16(thisdr["createdhoursago"]);
                //iData.updatedHoursAgo = Convert.ToInt16(thisdr["updatedhoursago"]);
            }
            DataColumnCollection dcc = iData.returnData.Columns;
            if (dcc.Contains("msg"))
            {
                iData.dbMessage = iData.returnData.Rows[0]["msg"].ToString();
            }
        }
        else
        {
            iData.ipAddressAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }
}