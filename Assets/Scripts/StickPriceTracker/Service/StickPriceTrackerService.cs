using UnityEngine;
using System.Collections;
using System.Net;
using System;
using Newtonsoft.Json;

public class StickPriceTrackerService : IStickPriceTrackerService {


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
			Debug.Log(response.Result.ToString());

		}
		catch(Exception exc)         
		{             
			Debug.Log(exc.ToString());            
		}
	}

}
