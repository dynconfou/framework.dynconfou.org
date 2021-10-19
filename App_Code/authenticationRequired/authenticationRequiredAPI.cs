using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for authenticationRequiredAPI
/// </summary>
public class authenticationRequiredAPI
{
    public authenticationRequiredAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void reTurnToSender(string iRequestIP)
    {
        /* if un-verified rGUID provided - invalid request - return to sender for notification or processing - visibility to the client */
        //HttpContext.Current.Response.Redirect("http://" + iRequestIP + "?ReturnToSender=InvalidRequest");
    }
}