using UnityEngine;
using System.Collections;
using System;
using System.Net;
using Newtonsoft.Json;

public class SurveyDataService : ISurveyDataService
{

    [Inject]
    public SurveyDataSuccessfulResponseSignal SurveyDataSuccessfulResponseSignal { get; set; }

    public void OnSurveyDataSubmitRequest(string json)
    {
        Uri URI = new Uri("http://partner-solutions.in/survey/WebServices/playerfruity.php");
        WebClient wc = new WebClient();
        wc.Headers["Content-Type"] = "application/json";
        wc.Headers["Accept"] = "application/json";
        wc.UploadStringCompleted += new UploadStringCompletedEventHandler(OnStickPriceTrackerResponse);
        wc.UploadStringAsync(URI, "POST", json);
    }


    public void OnStickPriceTrackerResponse(object sender, UploadStringCompletedEventArgs response)
    {
        try
        {
            if (response != null)
            {
                    Debug.Log(response.Result);
                SurveyDataResponse dataResponse = JsonConvert.DeserializeObject<SurveyDataResponse>(response.Result);
                if (dataResponse.result == "success")
                {
                    SurveyDataSuccessfulResponseSignal.Dispatch();
                }
            }

        }
        catch (Exception exc)
        {
            Debug.Log(exc.ToString());
        }
    }

}
