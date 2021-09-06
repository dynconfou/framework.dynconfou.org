﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for anyTrackerData
/// </summary>
public class anyTrackerData
{
    public anyTrackerData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string trackerName;
    private string TrackerName
    {
        get { return trackerName; }
        set { trackerName = value; }
    }

    public string trackerValue;
    private string TrackerValue
    {
        get { return trackerValue; }
        set { trackerValue = value; }
    }

    public string trackerCategory;
    private string TrackerCategory
    {
        get { return trackerCategory; }
        set { trackerCategory = value; }
    }

    public string trackerResponse;
    private string TrackerResponse
    {
        get { return trackerResponse; }
        set { trackerResponse = value; }
    }

    public DateTime dateCreated;
    private DateTime DateCreated
    {
        get { return dateCreated; }
        set { dateCreated = value; }
    }

    public DateTime dateUpdated;
    private DateTime DateUpdated
    {
        get { return dateUpdated; }
        set { dateUpdated = value; }
    }

    public Int16 createdHoursAgo;
    private Int16 CreatedHoursAgo
    {
        get { return createdHoursAgo; }
        set { createdHoursAgo = value; }
    }
    public Int16 updatedHoursAgo;
    private Int16 UpdatedHoursAgo
    {
        get { return updatedHoursAgo; }
        set { updatedHoursAgo = value; }
    }


    public DataTable returnData;
    private DataTable ReturnData
    {
        get { return returnData; }
        set { returnData = value; }
    }

    public string dbMessage;
    private string DbMessage
    {
        get { return dbMessage; }
        set { dbMessage = value; }
    }

    public string requestURL = "requestURL";
    private string RequestURL {
        get { return requestURL; }
        set { requestURL = value; }
    }

    public string requestIP = "requestIP";
    private string RequestIP
    {
        get { return requestIP; }
        set { requestIP = value; }
    }

    public string requestClient = "requestClient";
    private string RequestClient
    {
        get { return requestClient; }
        set { requestClient = value; }
    }

    public string requestDateTime = "requestDateTime";
    private string RequestDateTime
    {
        get { return requestDateTime; }
        set { requestDateTime = value; }
    }

    public string uiFrameworkRequestInit = "ui-framework-request-init";
    private string UiFrameworkRequestInit
    {
        get { return uiFrameworkRequestInit; }
        set { uiFrameworkRequestInit = value; }
    }

    public string uiFrameworkRequestSuccess = "ui-framework-request-success";
    private string UiFrameworkRequestSuccess
    {
        get { return uiFrameworkRequestSuccess; }
        set { uiFrameworkRequestSuccess = value; }
    }

    public string uiFrameworkRequestFailed = "ui-framework-request-failed";
    private string UiFrameworkRequestFailed
    {
        get { return uiFrameworkRequestFailed; }
        set { uiFrameworkRequestFailed = value; }
    }

    public string uiComsRequestInit = "ui-coms-request-init";
    private string uUiComsRequestInit
    {
        get { return uiComsRequestInit; }
        set { uiComsRequestInit = value; }
    }

    public string uiComsRequestSuccess = "ui-coms-request-success";
    private string UiComsRequestSuccess
    {
        get { return uiComsRequestSuccess; }
        set { uiComsRequestSuccess = value; }
    }

    public string uiComsRequestFailed = "ui-coms-request-failed";
    private string UiComsRequestFailed
    {
        get { return uiComsRequestFailed; }
        set { uiComsRequestFailed = value; }
    }

    public string uiThemeRequestInit = "ui-theme-request-init";
    private string UiThemeRequestInit
    {
        get { return uiThemeRequestInit; }
        set { uiThemeRequestInit = value; }
    }

    public string uiThemeRequestSuccess = "ui-theme-request-success";
    private string UiThemeRequestSuccess
    {
        get { return uiThemeRequestSuccess; }
        set { uiThemeRequestSuccess = value; }
    }

    public string uiThemeRequestFailed = "ui-theme-request-failed";
    private string UiThemeRequestFailed
    {
        get { return uiThemeRequestFailed; }
        set { uiThemeRequestFailed = value; }
    }

    public string uiUrlsRequestInit = "ui-urls-request-init";
    private string UiUrlsRequestInit
    {
        get { return uiUrlsRequestInit; }
        set { uiUrlsRequestInit = value; }
    }

    public string uiUrlsRequestSuccess = "ui-urls-request-success";
    private string UiUrlsRequestSuccess
    {
        get { return uiUrlsRequestSuccess; }
        set { uiUrlsRequestSuccess = value; }
    }

    public string uiUrlsRequestFailed = "ui-urls-request-failed";
    private string UiUrlsRequestFailed
    {
        get { return uiUrlsRequestFailed; }
        set { uiUrlsRequestFailed = value; }
    }

    public string apiRequestInit = "api-request-init";
    private string ApiRequestInit
    {
        get { return apiRequestInit; }
        set { apiRequestInit = value; }
    }

    public string apiRequestURLAuthRequired = "api-request-url-authorization-required";
    private string ApiRequestURLAuthRequired
    {
        get { return apiRequestURLAuthRequired; }
        set { apiRequestURLAuthRequired = value; }
    }

    public string apiRequestAgentAuthRequired = "api-request-agent-authorization-required";
    private string ApiRequestAgentAuthRequired
    {
        get { return apiRequestAgentAuthRequired; }
        set { apiRequestAgentAuthRequired = value; }
    }

    public string apiRequestIPAddressAuthRequired = "api-request-ipaddress-authorization-required";
    private string ApiRequestIPAddressAuthRequired
    {
        get { return apiRequestIPAddressAuthRequired; }
        set { apiRequestIPAddressAuthRequired = value; }
    }

    public string apiRequestSuccess = "api-request-success";
    private string ApiRequestSuccess
    {
        get { return apiRequestSuccess; }
        set { apiRequestSuccess = value; }
    }

    public string apiRequestFrameworkInit = "api-framework-request-init";
    private string ApiRequestFrameworkInit
    {
        get { return apiRequestFrameworkInit; }
        set { apiRequestFrameworkInit = value; }
    }

    public string apiRequestFrameworkAuthRequired = "api-framework-request-authentication-required";
    private string ApiRequestFrameworkAuthRequired
    {
        get { return apiRequestFrameworkAuthRequired; }
        set { apiRequestFrameworkAuthRequired = value; }
    }

    public string apiRequestFrameworkSuccess = "api-framework-request-success";
    private string ApiRequestFrameworkSuccess
    {
        get { return apiRequestFrameworkSuccess; }
        set { apiRequestFrameworkSuccess = value; }
    }

    public string apiRequestDeniedAgent = "api-request-denied-agent";
    private string ApiRequestDeniedAgent
    {
        get { return apiRequestDeniedAgent; }
        set { apiRequestDeniedAgent = value; }
    }

    public string apiRequestDeniedIP = "api-request-denied-ip";
    private string ApiRequestDeniedIP
    {
        get { return apiRequestDeniedIP; }
        set { apiRequestDeniedIP = value; }
    }

    public string apiRequestDeniedURL = "api-request-denied-url";
    private string ApiRequestDeniedURL
    {
        get { return apiRequestDeniedURL; }
        set { apiRequestDeniedURL = value; }
    }

    public string ipSetDeniedAgentDenied = "ip-set-denied-agent-denied";
    private string IpSetDeniedAgentDenied
    {
        get { return ipSetDeniedAgentDenied; }
        set { ipSetDeniedAgentDenied = value; }
    }

    public string apiRequestDeniedOops = "api-request-denied-oops";
    private string ApiRequestDeniedOpps {
        get { return apiRequestDeniedOops; }
        set { apiRequestDeniedOops = value; }
    }
}