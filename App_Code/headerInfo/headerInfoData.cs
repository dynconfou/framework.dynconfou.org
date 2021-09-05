using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for headerInfoData
/// </summary>
public class headerInfoData
{
    public headerInfoData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string requestIP = "api-request-ip";
    private string RequestIP
    {
        get { return requestIP; }
        set { requestIP = value; }
    }

    public string requestAgent = "api-request-agent";
    private string RequestAgent
    {
        get { return requestAgent; }
        set { requestAgent = value; }
    }

    public string requestURL = "api-request-url";
    private string RequestURL
    {
        get { return requestURL; }
        set { requestURL = value; }
    }
}