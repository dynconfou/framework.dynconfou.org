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
    protected String upath = "App_Code/script/ui-coms/production";

    /* site authorization */
    protected string siteAuthorization = "ui-coms";

    /* requestInit objects */
    requestInitAPI obRequestInitAPI = new requestInitAPI();
    requestInitData obRequestInitData = new requestInitData();

    /* headerInfoData object */
    headerInfoData obHeaderInfoData = new headerInfoData();

    public void ProcessRequest (HttpContext context) {

        /* setup requestInit */
        obRequestInitAPI.getInitData(HttpContext.Current, obRequestInitData);

        if (iData.Count == 0 && iFormData.Count != 0)
        {
            iData = iFormData;
        }

        /* auth init data */
        obRequestInitData.siteURL = thisPageURL;
        obRequestInitData.authType = siteAuthorization;

        /* log initial request */
        obRequestInitAPI.initRequest(HttpContext.Current, obRequestInitData);

        /* add header values */
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestIP, obRequestInitData.requestIP);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestAgent, obRequestInitData.requestClient);
        HttpContext.Current.Response.AddHeader(obHeaderInfoData.requestURL, obRequestInitData.requestURL);
        HttpContext.Current.Response.AddHeader((new anyTrackerData()).uiComsRequestSuccess, obRequestInitData.requestURL);

        /* setup response */
        HttpContext.Current.Response.ContentType = "text/javascript";
        string contents = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/"+upath) + "//" +fileName);

        HttpContext.Current.Response.Write(
            "/* " +
            "\r\n" + "Authorized: " + obRequestInitData.requestURL +
            "\r\n" + "*/" +
            "\r\n" +
            "\r\n" + "/* " +
            "\r\n" + "IP: " + obRequestInitData.requestIP +
            "\r\n" + "Client: " + obRequestInitData.requestClient +
            "\r\n" + "Delivered: " + DateTime.Now +
            "\r\n" + "*/" +
            "\r\n" +
            "\r\n" + contents);
        /* context.Response.WriteFile(context.Server.MapPath("~/"+upath) + "//" +fileName); */

        /* log success request */
        obRequestInitAPI.logSuccessRequest(obRequestInitData);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}