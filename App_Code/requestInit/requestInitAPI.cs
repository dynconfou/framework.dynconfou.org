using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for requestInit
/// </summary>
public class requestInitAPI
{
    /* anyTracker objects */
    anyTrackerData obAnyTrackerData = new anyTrackerData();
    anyTrackerAPI obAnyTrackerAPI = new anyTrackerAPI();
    SortedDictionary<string, string> obTrackerValue = new SortedDictionary<string, string>();

    public requestInitAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void getInitData(HttpContext iCurrent, requestInitData iData)
    {
        if (iCurrent.Request.UrlReferrer != null)
        {
            iData.requestURL = iCurrent.Request.UrlReferrer.ToString();
        }
        else { iData.requestURL = "na"; }
        if (iCurrent.Request.ServerVariables["REMOTE_ADDR"] != null)
        {
            iData.requestIP = iCurrent.Request.ServerVariables["REMOTE_ADDR"];
        }
        else { iData.requestIP = "na"; }
        if (iCurrent.Request.UserAgent != null)
        {
            iData.requestClient = iCurrent.Request.UserAgent.ToString();
        }
        else { iData.requestClient = "na"; }
    }

    public void logInitRequest(requestInitData iData)
    {
        /* setup logging data */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, iData.requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, iData.requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, iData.requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = iData.siteURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
        obAnyTrackerData.trackerCategory = obAnyTrackerData.apiRequestFrameworkInit;
        obAnyTrackerAPI.addTracker(obAnyTrackerData);
    }

    public void logSuccessRequest(requestInitData iData) {
        /* setup logging data */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, iData.requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, iData.requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, iData.requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = iData.siteURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
        obAnyTrackerData.trackerCategory = obAnyTrackerData.uiComsRequestSuccess;
        obAnyTrackerAPI.addTracker(obAnyTrackerData);
    }

    public void initRequest(HttpContext iCurrent, requestInitData iData)
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

        string sp_Use = "spRequestInit";

        SqlCommand SqlSP = new SqlCommand(sp_Use);
        SqlSP.Connection = ConnString;
        SqlSP.CommandType = CommandType.StoredProcedure;
        SqlSP.Parameters.AddWithValue("@agentName", iData.requestClient);
        SqlSP.Parameters.AddWithValue("@agentAuthorization", string.Empty);
        SqlSP.Parameters.AddWithValue("@ipAddress", iData.requestIP);
        SqlSP.Parameters.AddWithValue("@ipAuthorization", string.Empty);
        SqlSP.Parameters.AddWithValue("@siteURL", iData.siteURL);
        SqlSP.Parameters.AddWithValue("@authType", iData.authType);

        ConnString.Open();

        SqlDataAdapter sda = new SqlDataAdapter(SqlSP);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables.Count > 0)
        {
            DataRow thisdr = ds.Tables[0].Rows[0];
            iData.requestClientAction = thisdr["agentAction"].ToString();
            iData.requestClientAuthorization = thisdr["AgentAuthorization"].ToString();
            iData.requestIPAction = thisdr["ipAction"].ToString();
            iData.requestIPAuthorization = thisdr["ipAuthorization"].ToString();
            iData.siteAuthorization = thisdr["siteAuthorization"].ToString();
        }
        else
        {
            iData.siteAuthorization = "false";
        }

        ConnString.Close();
        ConnString.Dispose();
        ds.Dispose();

        /* processRequest */
        processRequest(iCurrent, iData);
    }

    public void processRequest(HttpContext iCurrent, requestInitData iData)
    {

        /* setup logging data */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, iData.requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, iData.requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, iData.requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = iData.siteURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);

        if (iData.requestClientAction == iData.requestDeny)
        {
            /* finish logging */
            obAnyTrackerData.trackerCategory = obAnyTrackerData.apiRequestAgentAuthRequired;
            obAnyTrackerAPI.addTracker(obAnyTrackerData);

            /* redirect */
            HttpContext.Current.Response.Redirect(siteSettings.authRequiredAgent);
        }
        else if (iData.requestIPAction == iData.requestDeny)
        {
            /* finish logging */
            obAnyTrackerData.trackerCategory = obAnyTrackerData.apiRequestIPAddressAuthRequired;
            obAnyTrackerAPI.addTracker(obAnyTrackerData);

            /* redirect */
            HttpContext.Current.Response.Redirect(siteSettings.authRequiredIP);
        }
        else if (iData.siteAuthorization == "false")
        {
            /* finish logging */
            obAnyTrackerData.trackerCategory = obAnyTrackerData.apiRequestURLAuthRequired;
            obAnyTrackerAPI.addTracker(obAnyTrackerData);

            /* redirect */
            HttpContext.Current.Response.Redirect(siteSettings.authRequiredURL);
        }
    }
}