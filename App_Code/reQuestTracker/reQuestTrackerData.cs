using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for reQuestTrackerData
/// </summary>
public class reQuestTrackerData
{
    public reQuestTrackerData()
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

    public string reQuestURL;
    private string ReQuestURL
    {
        get { return reQuestURL; }
        set { reQuestURL = value; }
    }

    public string reQuestIP;
    private string ReQuestIP
    {
        get { return reQuestIP; }
        set { reQuestIP = value; }
    }

    public string reQuestClient;
    private string ReQuestClient
    {
        get { return reQuestClient; }
        set { reQuestClient = value; }
    }

    public string reQuestDateTime;
    private string ReQuestDateTime
    {
        get { return reQuestDateTime; }
        set { reQuestDateTime = value; }
    }

    public string siteURL;
    private string SiteURL
    {
        get { return siteURL; }
        set { siteURL = value; }
    }

    public string siteAUTH;
    private string SiteAUTH
    {
        get { return siteAUTH; }
        set { siteAUTH = value; }
    }

    public string reQuestGUID;
    private string ReQuestGUID
    {
        get { return reQuestGUID; }
        set { reQuestGUID = value; }
    }

    public string reQuestAction;
    private string ReQuestAction
    {
        get { return reQuestAction; }
        set { reQuestAction = value; }
    }

    public string dbClientAction;
    private string DbClientAction
    {
        get { return dbClientAction; }
        set { dbClientAction = value; }
    }

    public string dbClientAuthorization;
    private string DbClientAuthorization
    {
        get { return dbClientAuthorization; }
        set { dbClientAuthorization = value; }
    }

    public string dbIPAction;
    private string DbIPAction
    {
        get { return dbIPAction; }
        set { dbIPAction = value; }
    }

    public string dbIPAuthorization;
    private string DbIPAuthorization
    {
        get { return dbIPAuthorization; }
        set { dbIPAuthorization = value; }
    }

    public string dbSiteAuthorization;
    private string DbSiteAuthorization
    {
        get { return dbSiteAuthorization; }
        set { dbSiteAuthorization = value; }
    }
}