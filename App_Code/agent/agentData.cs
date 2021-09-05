using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for agentData
/// </summary>
public class agentData
{
    public agentData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string aGuid;
    private string AGuid
    {
        get { return aGuid; }
        set { aGuid = value; }
    }

    public string agentName;
    private string AgentName
    {
        get { return agentName; }
        set { agentName = value; }
    }

    public string agentAuthorization;
    private string AgentAuthorization
    {
        get { return agentAuthorization; }
        set { agentAuthorization = value; }
    }

    public string agentAction;
    private string AgentAction
    {
        get { return agentAction; }
        set { agentAction = value; }
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
    private string AuthAllow {
        get { return authAllow; }
        set { authAllow = value; }
    }

    public string authDeny = "deny";
    private string AuthDeny
    {
        get { return authDeny; }
        set { authDeny = value; }
    }

    public string[] denyList = { "headless", "bot" };
    private string[] DenyList {
        get { return DenyList; }
        set { denyList = value; }
    }
}