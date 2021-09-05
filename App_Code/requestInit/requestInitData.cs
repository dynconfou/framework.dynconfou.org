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

    public string requestClient;
    private string RequestClient
    {
        get { return requestClient; }
        set { requestClient = value; }
    }


}