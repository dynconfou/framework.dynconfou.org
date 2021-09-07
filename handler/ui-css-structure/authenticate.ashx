<%@ WebHandler Language="C#" Class="authenticate" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

public class authenticate : IHttpHandler {

    protected string thisPageURL = HttpContext.Current.Request.Url.ToString();
    private NameValueCollection iFormData = HttpContext.Current.Request.Form;
    private NameValueCollection iData = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

    /* return:authorized response */
    protected String fileName = "TextFile.txt";
    protected String upath = "App_Code/script/ui-css-structure/production";

    /* site authorization */
    protected string siteAuthorization = "ui-css-structure";

    /* requestInit objects */
    requestInitAPI requestInitAPI = new requestInitAPI();
    requestInitData requestInitData = new requestInitData();

    /* anyTracker objects */
    anyTrackerData obAnyTrackerData = new anyTrackerData();
    anyTrackerAPI obAnyTrackerAPI = new anyTrackerAPI();
    SortedDictionary<string, string> obTrackerValue = new SortedDictionary<string, string>();

    /* agent objects */
    agentAPI obAgentAPI = new agentAPI();
    agentData obAgentData = new agentData();

    /* ipAddress objects */
    ipAddressAPI obIPAddressAPI = new ipAddressAPI();
    ipAddressData obIPAddressData = new ipAddressData();

    /* setup authentication */
    authenticationAPI authAPI = new authenticationAPI();
    authenticationData authData = new authenticationData();

    /* headerInfoData object */
    headerInfoData obHeaderInfoData = new headerInfoData();

    public void ProcessRequest (HttpContext context) {

        /* setup requestInit */
        requestInitAPI.getInitData(HttpContext.Current, requestInitData);

        if (iData.Count == 0 && iFormData.Count != 0)
        {
            iData = iFormData;
        }

        /*---------------------------------------------------------------------------------------*/

        /* LOG: INITIAL REQUEST - begin */

        /* setup logging data */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, requestInitData.requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, requestInitData.requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, requestInitData.requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = thisPageURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
        obAnyTrackerData.trackerCategory = obAnyTrackerData.uiCSSStructureRequestFailed;
        obAnyTrackerAPI.addTracker(obAnyTrackerData);

        /* LOG: INITIAL REQUEST - end */

        /*---------------------------------------------------------------------------------------*/

        /* VALIDATE: AGENT - begin */

        /* setup agent data */
        obAgentData.agentName = requestInitData.requestClient;
        obAgentData.agentAuthorization = "";
        foreach (string denyAgents in obAgentData.denyList) {
            if (requestInitData.requestClient.Contains(denyAgents)){
                /* block ip */
                obAgentData.agentAuthorization = obAgentData.authDeny;
            }
        }

        /* add agent data */
        obAgentAPI.addAgent(obAgentData);

        /* VALIDATE: AGENT - end */

        /*---------------------------------------------------------------------------------------*/

        /* VALIDATE: IP - begin */

        /* setup ipAddress data */
        obIPAddressData.ipAddress = requestInitData.requestIP;
        obIPAddressData.ipAddressAuthorization = "";
        foreach (string denyAgents in obAgentData.denyList) {
            if (requestInitData.requestClient.Contains(denyAgents)){
                /* block ip */
                obIPAddressData.ipAddressAuthorization = obIPAddressData.authDeny;
            }
        }

        /* add ipAddress data */
        obIPAddressAPI.addIPAddress(obIPAddressData);

        /* VALIDATE: IP - end */

        /*---------------------------------------------------------------------------------------*/

        /* VALIDATE: REQUEST - begin */

        if (requestInitData.requestURL == "na") {
            /* block ip */
            obIPAddressData.ipAddressAuthorization = obIPAddressData.authDeny;
            obIPAddressAPI.updateIPAddress(obIPAddressData);
        }

        /* VALIDATE: REQUEST - end */

        /*---------------------------------------------------------------------------------------*/

        /* VALIDATE: AUTHORIZATION - begin */

        authData.siteURL = requestInitData.requestURL;
        authData.siteAuthorization = siteAuthorization;
        authAPI.validateAuthorization(authData);

        /* VALIDATE: AUTHORIZATION - end */

        /*---------------------------------------------------------------------------------------*/

        /* RESPONSE: begin */
        SortedDictionary<string, string> responseData = new SortedDictionary<string, string>();
        if (obAgentData.agentAuthorization == obAgentData.authDeny)
        {
            responseData.Clear();
            responseData.Add("response", "Agent");
            returnFail(responseData);
        }
        else if (obIPAddressData.ipAddressAuthorization == obIPAddressData.authDeny)
        {
            responseData.Clear();
            responseData.Add("response", "IP Address");
            returnFail(responseData);
        }
        else if (requestInitData.requestURL == "na")
        {
            responseData.Clear();
            responseData.Add("response", "Request");
            returnFail(responseData);
        }
        else if (authData.siteAuthenticated == "false")
        {
            responseData.Clear();
            responseData.Add("response", "Authentication");
            returnFail(responseData);
        }
        else {
            responseData.Clear();
            responseData.Add("response", "Success");
            returnSuccess(responseData);
        }
        /* RESPONSE: end*/

        /* Original Response : Begin */
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        /* Original Response : End */
    }

    private void returnSuccess(object iData) {

        /* setup logging data */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, requestInitData.requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, requestInitData.requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, requestInitData.requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = thisPageURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
        obAnyTrackerData.trackerCategory = obAnyTrackerData.uiCSSStructureRequestSuccess;
        obAnyTrackerAPI.addTracker(obAnyTrackerData);

        /*---------------------------------------------------------------------------------------*/

        /* add header values */
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestIP, requestInitData.requestIP);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestAgent, requestInitData.requestClient);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestURL, requestInitData.requestURL);
        HttpContext.Current.Response.AddHeader(obAnyTrackerData.uiCSSStructureRequestSuccess, requestInitData.requestURL);

        /* setup response */
        HttpContext.Current.Response.ContentType = "text/css";
        string contents = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/"+upath) + "//" +fileName);

        HttpContext.Current.Response.Write(
            "/* " + 
            "\r\n" + "Authorized: " + requestInitData.requestURL + 
            "\r\n" + "*/" +
            "\r\n" +
            "\r\n" + "/* " +
            "\r\n" + "IP: " + requestInitData.requestIP +
            "\r\n" + "Client: " + requestInitData.requestClient +
            "\r\n" + "Delivered: " + DateTime.Now +
            "\r\n" + "*/" +
            "\r\n" +
            "\r\n" + contents);
        /* context.Response.WriteFile(context.Server.MapPath("~/"+upath) + "//" +fileName); */
    }

    private void returnFail(SortedDictionary<string,string> iData) {

        /* setup logging data */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, requestInitData.requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, requestInitData.requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, requestInitData.requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = thisPageURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
        obAnyTrackerData.trackerCategory = obAnyTrackerData.uiCSSStructureRequestFailed;
        obAnyTrackerAPI.addTracker(obAnyTrackerData);

        /*---------------------------------------------------------------------------------------*/

        /* add header values */
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestIP, requestInitData.requestIP);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestAgent, requestInitData.requestClient);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestURL, requestInitData.requestURL);
        HttpContext.Current.Response.AddHeader(obAnyTrackerData.uiCSSStructureRequestFailed, requestInitData.requestURL);

        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(iData["response"].ToString());
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}