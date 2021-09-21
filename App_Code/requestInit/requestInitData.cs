using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for requestInitData
/// </summary>
public class requestInitData
{
    public requestInitData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string requestURL;
    private string RequestURL
    {
        get { return requestURL; }
        set { requestURL = value; }
    }

    public string requestIP;
    private string RequestIP
    {
        get { return requestIP; }
        set { requestIP = value; }
    }

    public string requestIPAuthorization;
    private string RequestIPAuthorization
    {
        get { return requestIPAuthorization; }
        set { requestIPAuthorization = value; }
    }

    public string requestIPAction;
    private string RequestIPAction
    {
        get { return requestIPAction; }
        set { requestIPAction = value; }
    }

    public string requestClient;
    private string RequestClient
    {
        get { return requestClient; }
        set { requestClient = value; }
    }

    public string requestClientAuthorization;
    private string RequestClientAuthorization
    {
        get { return requestClientAuthorization; }
        set { requestClientAuthorization = value; }
    }

    public string requestClientAction;
    private string RequestClientAction
    {
        get { return requestClientAction; }
        set { requestClientAction = value; }
    }

    public string siteURL;
    private string SiteURL
    {
        get { return siteURL; }
        set { siteURL = value; }
    }

    public string authType;
    private string AuthType
    {
        get { return authType; }
        set { authType = value; }
    }

    public string siteAuthorization;
    private string SiteAuthorization
    {
        get { return siteAuthorization; }
        set { siteAuthorization = value; }
    }

    public string requestDeny = "deny";
    private string RequestDeny
    {
        get { return requestDeny; }
        set { requestDeny = value; }
    }

    public string requestAllow = "allow";
    private string RequestAllow
    {
        get { return requestAllow; }
        set { requestAllow = value; }
    }
}