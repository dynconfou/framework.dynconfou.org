using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for anyTrackerAPI
/// </summary>
public class anyTrackerAPI
{
    public anyTrackerAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void addTracker(anyTrackerData iData)
    {
        SqlConnection ConnString = new SqlConnection();

        if (siteSettings.apiEnvy == siteSettings.development)
        {
            //using development connection
            ConnString.ConnectionString = siteSettings.apiDevDBConnection;
        }
        else {
            //using production connectin
            ConnString.ConnectionString = siteSettings.apiLiveDBConnection;
        }        

        string sp_Use = "dbo.addTracker";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@trackername", iData.trackerName);
        SqlSP.Parameters.AddWithValue("@trackervalue", iData.trackerValue);
        SqlSP.Parameters.AddWithValue("@trackercategory", iData.trackerCategory);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            DataRow thisdr = ds.Tables[0].Rows[0];
            iData.trackerResponse = thisdr["response"].ToString();
            if (iData.trackerResponse == "exist")
            {
                iData.dateCreated = Convert.ToDateTime(thisdr["datecreated"]);
                //iData.dateUpdated = Convert.ToDateTime(thisdr["dateupdated"]);
                iData.createdHoursAgo = Convert.ToInt16(thisdr["createdhoursago"]);
                //iData.updatedHoursAgo = Convert.ToInt16(thisdr["updatedhoursago"]);
            }
        }
        else
        {
            iData.trackerResponse = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }
}