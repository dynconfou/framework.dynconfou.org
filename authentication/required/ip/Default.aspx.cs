﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

public partial class authentication_required_ip_Default : System.Web.UI.Page
{
    protected string thisPageURL = HttpContext.Current.Request.Url.ToString();
    protected string requestURL, requestIP, requestClient;
    private NameValueCollection iFormData = HttpContext.Current.Request.Form;
    private NameValueCollection iData = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

    /* requestInit objects */
    reQuestTrackerAPI obReQuestTrackerAPI = new reQuestTrackerAPI();
    reQuestTrackerData obReQuestTrackerData = new reQuestTrackerData();
    reQuestTrackerStatic obReQuestTrackerStatic = new reQuestTrackerStatic();

    SortedDictionary<string, string> obReQuestTrackerValue = new SortedDictionary<string, string>();

    /* authentication required object */
    authenticationRequiredStatic obAuthenticationRequiredStatic = new authenticationRequiredStatic();
    authenticationRequiredAPI obAuthenticationRequiredAPI = new authenticationRequiredAPI();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (iData.Count == 0 && iFormData.Count != 0)
        {
            iData = iFormData;
        }

        /* requestor init */
        obReQuestTrackerAPI.getInitData(HttpContext.Current, obReQuestTrackerData);

        /* set default working values */
        requestURL = obReQuestTrackerData.reQuestURL;
        requestIP = obReQuestTrackerData.reQuestIP;
        requestClient = obReQuestTrackerData.reQuestClient;

        /* if rGUID missing - invalid request - return to sender */
        if (iData["rGuid"] == null)
        {
            /* log invalid request - block IP */
            logInvalidRequestBlockIP(obAuthenticationRequiredStatic.ipRGuidNullIPBlocked);
            /* log return to sender */
            logReturnToSender(obAuthenticationRequiredStatic.ipRGuidNull);
            /* return to sender */
            obAuthenticationRequiredAPI.reTurnToSender(requestIP);
        }
        else if (requestURL == "na")
        {
            /* log invalid request - block IP */
            logInvalidRequestBlockIP(obAuthenticationRequiredStatic.ipRequestURLNAIPBlocked);
            /* log return to sender */
            logReturnToSender(obAuthenticationRequiredStatic.ipRequestURLNA);
            /* return to sender */
            obAuthenticationRequiredAPI.reTurnToSender(requestIP);
        }
        /* if verified rGUID exist - valid request - process finale */
        else if (iData["rGuid"].ToString().Length == 36)
        {
            /* validate reQuestGUID */
            obReQuestTrackerData.reQuestGUID = iData["rGuid"].ToString();
            obReQuestTrackerAPI.validateReQuestTracker(obReQuestTrackerData);
            if (obReQuestTrackerData.reQuestValid == obReQuestTrackerStatic.reQuestValid)
            {
                logValidError(obAuthenticationRequiredStatic.ipRGuidValid);
                form1.Visible = true;
            }
            else
            {
                /* log invalid request - block IP */
                logInvalidRequestBlockIP(obAuthenticationRequiredStatic.ipRGuidInvalidIPBlocked);
                /* log return to sender */
                logReturnToSender(obAuthenticationRequiredStatic.ipRGuidInvalid);
                /* return to sender */
                obAuthenticationRequiredAPI.reTurnToSender(requestIP);
            }
        }
        else
        {
            /* log invalid request - block IP */
            logInvalidRequestBlockIP(obAuthenticationRequiredStatic.ipRGuidInvalidFormatIPBlocked);
            /* log return to sender */
            logReturnToSender(obAuthenticationRequiredStatic.ipRGuidInvalidFormat);
            /* return to sender */
            obAuthenticationRequiredAPI.reTurnToSender(requestIP);
        }
    }

    public void logInvalidRequestBlockIP(string iTrackerName)
    {
        /* ipAddress objects */
        ipAddressAPI obIPAddressAPI = new ipAddressAPI();
        ipAddressData obIPAddressData = new ipAddressData();
        /* set ipAddress object data */
        obIPAddressData.ipAddress = requestIP;
        obIPAddressData.ipAddressAuthorization = obIPAddressData.authDeny;
        /* addupdate IP address */
        obIPAddressAPI.addUpdateIPAddress(obIPAddressData);

        /* setup logging data */
        obReQuestTrackerValue.Clear();
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestURL, requestURL);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestIP, requestIP);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestClient, requestClient);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestDateTime, DateTime.Now.ToString());

        /* setup addReQuestTracker */
        //obReQuestTrackerData.reQuestGUID = string.Empty;        
        obReQuestTrackerData.trackerName = iTrackerName;
        obReQuestTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obReQuestTrackerValue);
        obReQuestTrackerData.trackerCategory = obReQuestTrackerStatic.frameworkRequestIPAddressAuthDenied;
        obReQuestTrackerData.reQuestURL = requestURL;
        obReQuestTrackerData.reQuestClient = requestClient;
        obReQuestTrackerData.reQuestIP = requestIP;
        //obReQuestTrackerData.reQuestAction = "";
        obReQuestTrackerData.siteURL = thisPageURL;

        obReQuestTrackerAPI.addReQuestTracker(obReQuestTrackerData);
    }

    private void logValidError(string iTrackerName)
    {
        /* setup logging data */
        obReQuestTrackerValue.Clear();
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestURL, requestURL);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestIP, requestIP);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestClient, requestClient);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestDateTime, DateTime.Now.ToString());

        /* setup addReQuestTracker */
        //obReQuestTrackerData.reQuestGUID = string.Empty;        
        obReQuestTrackerData.trackerName = iTrackerName;
        obReQuestTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obReQuestTrackerValue);
        obReQuestTrackerData.trackerCategory = obReQuestTrackerStatic.frameworkRequestIPAddressAuthDenied;
        obReQuestTrackerData.reQuestURL = requestURL;
        obReQuestTrackerData.reQuestClient = requestClient;
        obReQuestTrackerData.reQuestIP = requestIP;
        //obReQuestTrackerData.reQuestAction = "";
        obReQuestTrackerData.siteURL = thisPageURL;

        obReQuestTrackerAPI.addReQuestTracker(obReQuestTrackerData);
    }

    private void logReturnToSender(string iTrackerName)
    {
        /* setup logging data */
        obReQuestTrackerValue.Clear();
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestURL, requestURL);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestIP, requestIP);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestClient, requestClient);
        obReQuestTrackerValue.Add(obReQuestTrackerStatic.reQuestDateTime, DateTime.Now.ToString());

        /* setup addReQuestTracker */
        //obReQuestTrackerData.reQuestGUID = string.Empty;
        obReQuestTrackerData.trackerName = iTrackerName;
        obReQuestTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obReQuestTrackerValue);
        obReQuestTrackerData.trackerCategory = obReQuestTrackerStatic.returnToSender;
        obReQuestTrackerData.reQuestURL = requestURL;
        obReQuestTrackerData.reQuestClient = requestClient;
        obReQuestTrackerData.reQuestIP = requestIP;
        obReQuestTrackerData.reQuestAction = "http://" + requestIP + "?ReturnToSender=InvalidRequest";
        obReQuestTrackerData.siteURL = thisPageURL;

        obReQuestTrackerAPI.addReQuestTracker(obReQuestTrackerData);
    }

}