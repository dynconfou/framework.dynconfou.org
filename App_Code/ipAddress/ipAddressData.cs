using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ipAddressData
/// </summary>
public class ipAddressData
{
    public ipAddressData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string ipGuid;
    private string IpGuid
    {
        get { return ipGuid; }
        set { ipGuid = value; }
    }

    public string ipAddress;
    private string IpAddress
    {
        get { return ipAddress; }
        set { ipAddress = value; }
    }

    public string ipAddressAuthorization;
    private string IpAddressAuthorization
    {
        get { return ipAddressAuthorization; }
        set { ipAddressAuthorization = value; }
    }

    public string ipAddressAction;
    private string IpAddressAction
    {
        get { return ipAddressAction; }
        set { ipAddressAction = value; }
    }

    public DateTime dateCreated;
    private DateTime DateCreated
    {
        get { return dateCreated; }
        set { dateCreated = value; }
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

    public string authAllow = "allow";
    private string AuthAllow
    {
        get { return authAllow; }
        set { authAllow = value; }
    }

    public string authDeny = "deny";
    private string AuthDeny
    {
        get { return authDeny; }
        set { authDeny = value; }
    }
}