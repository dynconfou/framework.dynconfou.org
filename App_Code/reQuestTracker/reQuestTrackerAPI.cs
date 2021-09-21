using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for reQuestTrackerAPI
/// </summary>
public class reQuestTrackerAPI
{
    /* reQuestTracker objects */
    //reQuestTrackerData obReQuestTrackerData = new reQuestTrackerData();
    reQuestTrackerStatic obRequestTrackerStatic = new reQuestTrackerStatic();
    SortedDictionary<string, string> obReQuestTrackerValue = new SortedDictionary<string, string>();

    public reQuestTrackerAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void getInitData(HttpContext iCurrent, reQuestTrackerData iData)
    {
        if (iCurrent.Request.UrlReferrer != null)
        {
            iData.reQuestURL = iCurrent.Request.UrlReferrer.ToString();
        }
        else { iData.reQuestURL = "na"; }
        if (iCurrent.Request.ServerVariables["REMOTE_ADDR"] != null)
        {
            iData.reQuestIP = iCurrent.Request.ServerVariables["REMOTE_ADDR"];
        }
        else { iData.reQuestIP = "na"; }
        if (iCurrent.Request.UserAgent != null)
        {
            iData.reQuestClient = iCurrent.Request.UserAgent.ToString();
        }
        else { iData.reQuestClient = "na"; }
    }

    public void addReQuestTracker(reQuestTrackerData iData)
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

        string sp_Use = "dbo.addReQuestTracker";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@trackerGUID", iData.reQuestGUID);
        SqlSP.Parameters.AddWithValue("@trackername", iData.trackerName);
        SqlSP.Parameters.AddWithValue("@trackervalue", iData.trackerValue);
        SqlSP.Parameters.AddWithValue("@trackercategory", iData.trackerCategory);
        SqlSP.Parameters.AddWithValue("@reQuestURL", iData.reQuestURL);
        SqlSP.Parameters.AddWithValue("@reQuestAgent", iData.reQuestClient);
        SqlSP.Parameters.AddWithValue("@reQuestIP", iData.reQuestIP);
        SqlSP.Parameters.AddWithValue("@reQuestAction", iData.reQuestAction);
        SqlSP.Parameters.AddWithValue("@siteURL", iData.siteURL);
        SqlSP.Parameters.AddWithValue("@siteAUTH", iData.siteAUTH);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            DataRow thisdr = ds.Tables[0].Rows[0];
            iData.reQuestGUID = thisdr["reQuestGUID"].ToString();
        }
        else
        {
            iData.reQuestGUID = null;
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();
    }

    public void logInitRequest(reQuestTrackerData iData)
    {
        /* reQuestTrackerData object */
        reQuestTrackerData oData = new reQuestTrackerData();

        /* setup logging data */
        obReQuestTrackerValue.Clear();
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestURL, iData.reQuestURL);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestIP, iData.reQuestIP);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestClient, iData.reQuestClient);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestDateTime, DateTime.Now.ToString());

        /* add logging data */
        oData.trackerName = iData.trackerName;
        oData.trackerValue = new JavaScriptSerializer().Serialize(obReQuestTrackerValue);
        oData.trackerCategory = iData.trackerCategory;
        oData.reQuestURL = iData.reQuestURL;
        oData.reQuestClient = iData.reQuestClient;
        oData.reQuestIP = iData.reQuestIP;
        oData.siteURL = iData.siteURL;
        oData.siteAUTH = iData.siteAUTH;
        addReQuestTracker(oData);
        iData.reQuestGUID = oData.reQuestGUID;
    }

    public void finalizeRequest(reQuestTrackerData iData) {

        /* reQuestTrackerData object */
        reQuestTrackerData oData = new reQuestTrackerData();

        /* setup logging data */
        obReQuestTrackerValue.Clear();
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestURL, iData.reQuestURL);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestIP, iData.reQuestIP);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestClient, iData.reQuestClient);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestDateTime, DateTime.Now.ToString());

        /* add logging data */
        oData.trackerName = iData.trackerName;
        oData.trackerValue = new JavaScriptSerializer().Serialize(obReQuestTrackerValue);
        oData.trackerCategory = iData.trackerCategory;
        oData.reQuestURL = iData.reQuestURL;
        oData.reQuestClient = iData.reQuestClient;
        oData.reQuestIP = iData.reQuestIP;
        oData.siteURL = iData.siteURL;
        oData.siteAUTH = iData.siteAUTH;
        oData.reQuestGUID = iData.reQuestGUID;
        oData.reQuestAction = iData.reQuestAction;
        addReQuestTracker(oData);
        
    }

    public void initRequest(HttpContext iCurrent, reQuestTrackerData iData)
    {
        /* log init request */
        logInitRequest(iData);

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

        string sp_Use = "spRequestTrackerInit";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@trackerGUID", iData.reQuestGUID);
        SqlSP.Parameters.AddWithValue("@requestURL", iData.reQuestURL);
        SqlSP.Parameters.AddWithValue("@agentName", iData.reQuestClient);
        SqlSP.Parameters.AddWithValue("@agentAuthorization", string.Empty);
        SqlSP.Parameters.AddWithValue("@ipAddress", iData.reQuestIP);
        SqlSP.Parameters.AddWithValue("@ipAuthorization", string.Empty);
        SqlSP.Parameters.AddWithValue("@siteURL", iData.siteURL);
        SqlSP.Parameters.AddWithValue("@siteAUTH", iData.siteAUTH);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            DataRow thisdr = ds.Tables[0].Rows[0];
            iData.dbClientAction = thisdr["agentAction"].ToString();
            iData.dbClientAuthorization = thisdr["AgentAuthorization"].ToString();
            iData.dbIPAction = thisdr["ipAction"].ToString();
            iData.dbIPAuthorization = thisdr["ipAuthorization"].ToString();
            iData.dbSiteAuthorization = thisdr["siteAuthorization"].ToString();
        }
        else
        {
            iData.dbSiteAuthorization = "false";
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();

        /* processRequest */
        processRequest(iCurrent, iData);
    }

    public void processRequest(HttpContext iCurrent, reQuestTrackerData iData)
    {
        ///* reQuestTrackerData object */
        //reQuestTrackerData oData = new reQuestTrackerData();

        /* setup logging data */
        obReQuestTrackerValue.Clear();
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestURL, iData.reQuestURL);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestIP, iData.reQuestIP);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestClient, iData.reQuestClient);
        obReQuestTrackerValue.Add(obRequestTrackerStatic.reQuestDateTime, DateTime.Now.ToString());

        /* add logging data */
        iData.trackerName = iData.siteURL;
        iData.trackerValue = new JavaScriptSerializer().Serialize(obReQuestTrackerValue);

        if (iData.dbClientAction == obRequestTrackerStatic.reQuestDeny)
        {
            /* finish logging */
            iData.trackerCategory = obRequestTrackerStatic.frameworkRequestAgentAuthRequired;
            iData.reQuestAction = siteSettings.authRequiredAgent;
            addReQuestTracker(iData);

            /* redirect */
            HttpContext.Current.Response.Redirect(siteSettings.authRequiredAgent);
        }
        else if (iData.dbIPAction == obRequestTrackerStatic.reQuestDeny)
        {
            /* finish logging */
            iData.trackerCategory = obRequestTrackerStatic.frameworkRequestIPAddressAuthRequired;
            iData.reQuestAction = siteSettings.authRequiredIP;
            addReQuestTracker(iData);

            /* redirect */
            HttpContext.Current.Response.Redirect(siteSettings.authRequiredIP);
        }
        else if (iData.dbSiteAuthorization == "false")
        {
            /* finish logging */
            iData.trackerCategory = obRequestTrackerStatic.frameworkRequestURLAuthRequired;
            iData.reQuestAction = siteSettings.authRequiredURL;
            addReQuestTracker(iData);

            /* redirect */
            HttpContext.Current.Response.Redirect(siteSettings.authRequiredURL);
        }
    }
}