using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for agentAPI
/// </summary>
public class agentAPI
{
    public agentAPI()
    {
        //
        // TODO: Add constructor logic here
        //
        /*
            AGENTS - by default not allowed - requires 'allow' authorization
        */
    }

    public void updateAgent(agentData iData) {
        
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

        string sp_Use = "spUpdateAgent";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@aguid", iData.aGuid);
        SqlSP.Parameters.AddWithValue("@agentAuthorization", iData.agentAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.agentAction = thisdr["action"].ToString();
            if (iData.agentAction == "exist")
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
            iData.agentAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }

    public void validateAgent(agentData iData) {

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

        string sp_Use = "spValidateAgent";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@agentName", iData.agentName);
        SqlSP.Parameters.AddWithValue("@agentAuthorization", iData.agentAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.aGuid = thisdr["aguid"].ToString();
            iData.agentAction = thisdr["authenticated"].ToString();
            iData.agentAuthorization = thisdr["agentAuthorization"].ToString();            
            if (iData.agentAction == "true")
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
            iData.agentAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }

    public void addAgent(agentData iData)
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

        string sp_Use = "spAddAgent";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@agentName", iData.agentName);
        SqlSP.Parameters.AddWithValue("@agentAuthorization", iData.agentAuthorization);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            iData.returnData = ds.Tables[0];
            DataRow thisdr = iData.returnData.Rows[0];
            iData.aGuid = thisdr["aguid"].ToString();
            iData.agentAction = thisdr["action"].ToString();
            iData.agentAuthorization = thisdr["agentAuthorization"].ToString();
            if (iData.agentAction == "exist")
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
            iData.agentAction = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }
}