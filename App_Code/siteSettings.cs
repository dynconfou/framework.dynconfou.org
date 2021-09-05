using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for siteSettings
/// </summary>
public class siteSettings
{
    //Connection Strings
    public static string apiDevDBConnection = ConfigurationManager.ConnectionStrings["dcf_dev"].ToString();
    public static string apiLiveDBConnection = ConfigurationManager.ConnectionStrings["dcf_live"].ToString();

    //Environment Setup
    public static string apiEnvy = ConfigurationManager.AppSettings["apienvy"].ToString();
    public static string development = "development";
    public static string defaultProtocol = "https://";
    public static string apiURL = (defaultProtocol + "framework.dynconfou.org");
    public static string apiURLDevelopment = (defaultProtocol + "tomorrow-framework.dynconfou.org");
    public static string authRequiredAgent = ConfigurationManager.AppSettings["authenticationRequiredAgent"].ToString();
    public static string authRequiredIP = ConfigurationManager.AppSettings["authenticationRequiredIP"].ToString();
    public static string authRequiredURL = ConfigurationManager.AppSettings["authenticationRequiredURL"].ToString();
}