using UnityEngine;
using System.Collections;
using System;
using System.Net;
using strange.extensions.signal.impl;
using Newtonsoft.Json;

public class LoginService : ILoginService {

	[Inject]
	public LoginResponseSignal LoginResponseSignal{ get; set;}

	public void SendLoginRequest(string json)
	{
		Uri URI = new Uri("http://partner-solutions.in/survey/WebServices/login_service.php");
		WebClient wc = new WebClient();
		wc.Headers["Content-Type"] = "application/json";
		wc.Headers["Accept"] = "application/json";
		wc.UploadStringCompleted += new UploadStringCompletedEventHandler(OnLoginResponse);
		wc.UploadStringAsync(URI,"POST", json);    
	}
		

	public void OnLoginResponse(object sender, UploadStringCompletedEventArgs response)
	{  
		try            
		{          
			LoginResult data = JsonConvert.DeserializeObject<LoginResult>(response.Result.ToString());
			Debug.Log(data.result.ToString());
			if(data.result == "success")
			{

				LoginResponseSignal.Dispatch(data); 	
			}
		}
		catch(Exception exc)         
		{             
			Debug.Log(exc.ToString());            
		}
	}
}
