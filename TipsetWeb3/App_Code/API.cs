using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for API
/// </summary>
public class API
{
    string pageContent;
    string accesskey = "?accesskey=b827149e-ce78-41ab-a3b0-ea3cadd40961";
    string pagerequest = "https://api.www.svenskaspel.se/external/draw/";
    string productName = "stryktipset/draws";

    public Rootobject games;

    public API()
    {

    }

    public void GetApiData(bool isEuropatipset)
    {
        // Get game data from SvenskaSpel

        if (isEuropatipset)
        {
            productName = "europatipset/draws";
        }
        else
        {
            productName = "stryktipset/draws";
        }

        string fullAPIpath = pagerequest + productName + accesskey;
        bool apiSuccess = true;

        try
        {
            WebRequest request = WebRequest.Create(@fullAPIpath);
            WebResponse response;
            Stream data;

            response = request.GetResponse();
            data = response.GetResponseStream();

            using (StreamReader sr = new StreamReader(data))
            {
                pageContent = sr.ReadToEnd();
            }
        }
        catch (Exception ex)
        {

            //MessageBox.Show("API failed" + Environment.NewLine + ex.Message);
            apiSuccess = false;
        }

        if (apiSuccess)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            games = jsonSerializer.Deserialize<Rootobject>(pageContent);
        }
    }
}

public class Rootobject
{
    public object error { get; set; }
    public Requestinfo requestInfo { get; set; }
    public string requestId { get; set; }
    public string deviceId { get; set; }
    public object session { get; set; }
    public object sessionUser { get; set; }
    public object clientInfo { get; set; }
    public Draw[] draws { get; set; }
}

public class Requestinfo
{
    public int elapsedTime { get; set; }
    public int apiVersion { get; set; }
}

public class Draw
{
    public string drawComment { get; set; }
    public Event[] events { get; set; }
    public string productName { get; set; }
    public int productId { get; set; }
    public int drawNumber { get; set; }
    public DateTime openTime { get; set; }
    public DateTime closeTime { get; set; }
    public string turnover { get; set; }
}

public class Event
{
    public int eventNumber { get; set; }
    public string description { get; set; }
    public string participantType { get; set; }
    public Odds odds { get; set; }
    public Distribution distribution { get; set; }
    public Newspaperadvice newspaperAdvice { get; set; }
}

public class Odds
{
    public string home { get; set; }
    public string draw { get; set; }
    public string away { get; set; }
}

public class Distribution
{
    public string home { get; set; }
    public string draw { get; set; }
    public string away { get; set; }
}

public class Newspaperadvice
{
    public string home { get; set; }
    public string draw { get; set; }
    public string away { get; set; }
}