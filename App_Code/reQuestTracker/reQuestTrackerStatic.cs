using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for reQuestTrackerStatic
/// </summary>
public class reQuestTrackerStatic
{
    public reQuestTrackerStatic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string reQuestURL = "reQuestURL";
    public string reQuestIP = "reQuestIP";
    public string reQuestClient = "ReQuestClient";
    public string reQuestDateTime = "ReQuestDateTime";
    public string reQuestDeny = "deny";
    public string reQuestAllow = "allow";
    public string reQuestValid = "valid";
    public string frameworkRequestURLAuthRequired = "framework-request-url-authorization-required";
    public string frameworkRequestIPAddressAuthRequired = "framework-request-ipaddress-authorization-required";
    public string frameworkRequestAgentAuthRequired = "framework-request-agent-authorization-required";
    public string frameworkRequestURLAuthDenied = "framework-request-url-authorization-denied";
    public string frameworkRequestIPAddressAuthDenied = "framework-request-ipaddress-authorization-denied";
    public string frameworkRequestAgentAuthDenied = "framework-request-agent-authorization-denied";
    

    public string frameworkRequestInit = "framework-request-init";
    private string FrameworkRequestInit
    {
        get { return frameworkRequestInit; }
        set { frameworkRequestInit = value; }
    }
    public string frameworkRequestSuccess = "framework-request-success";
    private string FrameworkRequestSuccess
    {
        get { return frameworkRequestSuccess; }
        set { frameworkRequestSuccess = value; }
    }
    /* standard|internal use */
    public string authenticateUIComs = "authenticate-ui-coms";
    public string authenticateUICSS = "authenticate-ui-css";
    public string authenticateUICSSStructure = "authenticate-ui-css-structure";
    public string authenticateUICSSTheme = "authenticate-ui-css-theme";
    public string authenticateUIURLs = "authenticate-ui-urls";
    public string authenticateUIFramework = "authenticate-ui-framework";
    public string authenticateUIModalScript = "authenticate-ui-modal-script";
    public string authenticateUIModalTemplate = "authenticate-ui-modal-template";
    /* integration use */
    public string authenticateUICSSIntegration = "authenticate-ui-css-integration";
    public string authenticateUICSSStructureIntegration = "authenticate-ui-css-structure-integration";
    public string authenticateUICSSThemeIntegration = "authenticate-ui-css-theme-integration";
    /* return to sender */
    public string returnToSender = "return-to-sender";
}