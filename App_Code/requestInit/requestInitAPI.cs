using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for requestInit
/// </summary>
public class requestInitAPI
{
    public requestInitAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void getInitData(HttpContext iCurrent, requestInitData iData) {
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
}