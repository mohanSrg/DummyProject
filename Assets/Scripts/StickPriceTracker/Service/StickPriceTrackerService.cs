using UnityEngine;
using System.Collections;
using System.Net;
using System;
using Newtonsoft.Json;

public class StickPriceTrackerService : IStickPriceTrackerService {

    [Inject]
    public StickPriceTrackerSuccessfullySResponseSignal StickPriceTrackerSuccessfullySResponse { get; set; }

    public void OnStickPriceTrackerDataSubmitRequest (string json)
	{
		Uri URI = new Uri("http://partner-solutions.in/survey/WebServices/stickpricetricker_webservices.php");
		WebClient wc = new WebClient();
		wc.Headers["Content-Type"] = "application/json";
		wc.Headers["Accept"] = "application/json";
		wc.UploadStringCompleted += new UploadStringCompletedEventHandler(OnStickPriceTrackerResponse);
		wc.UploadStringAsync(URI,"POST", json);    
	}


	public void OnStickPriceTrackerResponse(object sender, UploadStringCompletedEventArgs response)
	{  
		try            
		{          
			if(response.Result != null)
            {
                StickPriceTrackerResponse responseData = JsonConvert.DeserializeObject<StickPriceTrackerResponse>(response.Result);
                Debug.Log(response.Result);
                if(responseData.result == "success")
                {
                    StickPriceTrackerSuccessfullySResponse.Dispatch();
                }
            }

		}
		catch(Exception exc)         
		{             
			Debug.Log(exc.ToString());            
		}
	}

}
