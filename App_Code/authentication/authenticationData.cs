using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for authenticationData
/// </summary>
public class authenticationData
{
    public authenticationData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string aGuid;
    private string PaGuid
    {
        get { return aGuid; }
        set { aGuid = value; }
    }

    public string siteURL;
    private string SiteURL
    {
        get { return siteURL; }
        set { siteURL = value; }
    }

    public string siteAuthorization;
    private string SiteAuthorization
    {
        get { return siteAuthorization; }
        set { siteAuthorization = value; }
    }

    public string siteInfo;
    private string SiteInfo
    {
        get { return siteInfo; }
        set { siteInfo = value; }
    }

    public string siteAuthenticated;
    private string SiteAuthenticated
    {
        get { return siteAuthenticated; }
        set { siteAuthenticated = value; }
    }

    public string userAgent;
    private string UserAgent
    {
        get { return userAgent; }
        set { userAgent = value; }
    }

    public string action;
    private string Action
    {
        get { return action; }
        set { action = value; }
    }
}