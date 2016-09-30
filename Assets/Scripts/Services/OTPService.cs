﻿using UnityEngine;
using System.Collections;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;

using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

public class OTPService : IOTPServiceInterface {

	[Inject]
	public LoginResponseSignal LoginResponseSignal{ get; set;}

    [Inject]
    public OTPSuccessfulySentSignal OTPSuccessfulySentSignal { get; set; }

    public void SendOTPToMobileNumber(string mobileno, int OTPNumber)
	{
		string to = "LM-FEDBCK";
		string Body = "One Time Password for Mobile Validation is "+ OTPNumber +". Please share your OTP number with our Agent";
		
		Dictionary<string, string> postValues = new Dictionary<string, string> ();
		postValues.Add ("From", mobileno);
		postValues.Add ("To", to);
		postValues.Add ("Body", Body);

		//String postString = "";

//		foreach (KeyValuePair<string, string> postValue in postValues) {
//			postString += postValue.Key + "=" +  Uri.EscapeDataString(postValue.Value) + "&";
//		}
//		postString = postString.TrimEnd ('&');
		/*
		 * Allow self signed certificates and such
		 */
		ServicePointManager.ServerCertificateValidationCallback = delegate {
			return true;
		};
		string smsURL = "https://twilix.exotel.in/v1/Accounts/razorfish/Sms/send?From=LM-FEDBCK&To="+mobileno+"&Body="+Body;
		string sid = "razorfish";
		string token = "f40958d07c4094015e5b8972468055d5b1d0ee6d";
		HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create (smsURL);
		objRequest.Credentials = new NetworkCredential (sid, token);
		objRequest.Method = "POST";
		//objRequest.ContentLength = postString.Length;
		objRequest.ContentType = "application/x-www-form-urlencoded";
		// post data is sent as a stream                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		StreamWriter opWriter = null;
		opWriter = new StreamWriter (objRequest.GetRequestStream ());
		//opWriter.Write (postString);
		opWriter.Close ();

		// returned values are returned as a stream, then read into a string                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
		HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse ();
		string postResponse = null;
		using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream())) {
			postResponse = responseStream.ReadToEnd ();
			responseStream.Close ();
		}

        OnOTPResponse(postResponse);
	}


	public void OnOTPResponse(string response)
	{
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(response);
        string json = JsonConvert.SerializeXmlNode(doc);
        Debug.Log(json);
        if(response != null)
        {
            OTPResponse responseData = JsonConvert.DeserializeObject<OTPResponse>(json);
            Debug.Log(responseData.TwilioResponse.SMSMessage.Status);
            OTPSuccessfulySentSignal.Dispatch(responseData);
        }
	}
}
