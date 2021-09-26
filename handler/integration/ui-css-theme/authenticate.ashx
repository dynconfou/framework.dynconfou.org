<%@ WebHandler Language="C#" Class="authenticate" %>

using System;
using System.Web;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

public class authenticate : IHttpHandler {

    protected string thisPageURL = HttpContext.Current.Request.Url.ToString();
    private NameValueCollection iFormData = HttpContext.Current.Request.Form;
    private NameValueCollection iData = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

    /* return:authorized response */
    protected String fileName = "TextFile.txt";
    protected String upath = "App_Code/script/integration/ui-css-theme/production";

    /* site authorization */
    protected string siteAuthorization = "ui-css-theme-integration";

    /* requestInit objects */
    reQuestTrackerAPI obReQuestTrackerAPI = new reQuestTrackerAPI();
    reQuestTrackerData obReQuestTrackerData = new reQuestTrackerData();
    reQuestTrackerStatic obReQuestTrackerStatic = new reQuestTrackerStatic();

    /* headerInfoData object */
    headerInfoData obHeaderInfoData = new headerInfoData();

    public void ProcessRequest (HttpContext context) {
        /* setup requestInit */
        obReQuestTrackerAPI.getInitData(HttpContext.Current, obReQuestTrackerData);

        if (iData.Count == 0 && iFormData.Count != 0)
        {
            iData = iFormData;
        }

        /* auth init data */
        obReQuestTrackerData.trackerName = obReQuestTrackerStatic.authenticateUICSSThemeIntegration;
        obReQuestTrackerData.trackerCategory = obReQuestTrackerStatic.frameworkRequestInit;
        obReQuestTrackerData.siteURL = obReQuestTrackerData.reQuestURL;
        obReQuestTrackerData.siteAUTH = siteAuthorization;

        /* log initial request */
        obReQuestTrackerAPI.initRequest(HttpContext.Current, obReQuestTrackerData);

        /* add header values */
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestIP, obReQuestTrackerData.reQuestIP);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestAgent, obReQuestTrackerData.reQuestClient);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestURL, obReQuestTrackerData.reQuestURL);
        //HttpContext.Current.Response.AddHeader((new anyTrackerData()).uiComsRequestSuccess, obRequestInitData.requestURL);

        /* setup response */
        HttpContext.Current.Response.ContentType = "text/css";
        string contents = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/"+upath) + "//" +fileName);        

        HttpContext.Current.Response.Write(
            "/* " +
            "\r\n" + "Authorized: " + obReQuestTrackerData.reQuestURL +
            "\r\n" + "*/" +
            "\r\n" +
            "\r\n" + "/* " +
            "\r\n" + "IP: " + obReQuestTrackerData.reQuestIP +
            "\r\n" + "Client: " + obReQuestTrackerData.reQuestClient +
            "\r\n" + "Delivered: " + DateTime.Now +
            "\r\n" + "*/" +
            "\r\n" +
            "\r\n" + contents);
        /* context.Response.WriteFile(context.Server.MapPath("~/"+upath) + "//" +fileName); */

        /* log success request */
        obReQuestTrackerData.reQuestAction = obReQuestTrackerStatic.frameworkRequestSuccess;
        obReQuestTrackerAPI.finalizeRequest(obReQuestTrackerData);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}