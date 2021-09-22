using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class authentication_required_ip_Default : System.Web.UI.Page
{
    protected string thisPageURL = HttpContext.Current.Request.Url.ToString();
    protected string requestURL, requestIP, requestClient;
    /* logging event */
    anyTrackerData obAnyTrackerData = new anyTrackerData();
    anyTrackerAPI obAnyTrackerAPI = new anyTrackerAPI();
    SortedDictionary<string, string> obTrackerValue = new SortedDictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        /* requestor init */
        requestInitAPI requestInitAPI = new requestInitAPI();
        requestInitData requestInitData = new requestInitData();
        requestInitAPI.getInitData(HttpContext.Current, requestInitData);

        /* agent objects */
        agentAPI obAgentAPI = new agentAPI();
        agentData obAgentData = new agentData();

        /* ipAddress objects */
        ipAddressAPI obIPAddressAPI = new ipAddressAPI();
        ipAddressData obIPAddressData = new ipAddressData();

        requestURL = requestInitData.requestURL;
        requestIP = requestInitData.requestIP;
        requestClient = requestInitData.requestClient;

        /* setup logging value */
        obTrackerValue.Clear();
        obTrackerValue.Add(obAnyTrackerData.requestURL, requestURL);
        obTrackerValue.Add(obAnyTrackerData.requestIP, requestIP);
        obTrackerValue.Add(obAnyTrackerData.requestClient, requestClient);
        obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

        /* add logging data */
        obAnyTrackerData.trackerName = thisPageURL;
        obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
        obAnyTrackerData.trackerCategory = obAnyTrackerData.apiRequestDeniedURL;
        obAnyTrackerAPI.addTracker(obAnyTrackerData);

        /* setup agent data */
        obAgentData.agentName = requestClient;
        obAgentData.agentAuthorization = "";
        if (requestClient.Contains("headless"))
        {
            obAgentData.agentAuthorization = obAgentData.authDeny;
        }
        /* add agent data */
        obAgentAPI.addAgent(obAgentData);

        /* setup ipAddress data */
        obIPAddressData.ipAddress = requestIP;
        obIPAddressData.ipAddressAuthorization = "";
        if (requestClient.Contains("headless"))
        {
            obIPAddressData.ipAddressAuthorization = obIPAddressData.authDeny;
        }
        /* add ipAddress data */
        obIPAddressAPI.addIPAddress(obIPAddressData);

        /* setup agent authorization */
        obAgentData.agentName = requestClient;
        obAgentData.agentAuthorization = obAgentData.authAllow;

        /* validate agent data */
        obAgentAPI.validateAgent(obAgentData);

        /* check agent status: deny ip if agent status equals deny */
        if (obAgentData.agentAuthorization == obAgentData.authDeny && obIPAddressData.ipAddressAuthorization != obIPAddressData.authDeny)
        {
            /* setup ipAddress:deny authorization */
            /*
            obIPAddressData.ipGuid - already set from addIPAddress 
            */
            obIPAddressData.ipAddressAuthorization = obIPAddressData.authDeny;

            /* validate agent data */
            obIPAddressAPI.updateIPAddress(obIPAddressData);

            /* setup logging value */
            obTrackerValue.Clear();
            obTrackerValue.Add(obAnyTrackerData.requestURL, requestURL);
            obTrackerValue.Add(obAnyTrackerData.requestIP, requestIP);
            obTrackerValue.Add(obAnyTrackerData.requestClient, requestClient);
            obTrackerValue.Add(obAnyTrackerData.requestDateTime, DateTime.Now.ToString());

            /* add logging data */
            obAnyTrackerData.trackerName = thisPageURL;
            obAnyTrackerData.trackerValue = new JavaScriptSerializer().Serialize(obTrackerValue);
            obAnyTrackerData.trackerCategory = obAnyTrackerData.ipSetDeniedAgentDenied;
            obAnyTrackerAPI.addTracker(obAnyTrackerData);
        }
    }
}