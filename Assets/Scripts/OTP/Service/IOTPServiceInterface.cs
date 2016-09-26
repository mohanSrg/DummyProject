using UnityEngine;
using System.Collections;
using System.Net;

public interface IOTPServiceInterface 
{
	void SendOTPToMobileNumber(string mobileNo);
	void OnOTPResponse(object sender, UploadStringCompletedEventArgs response);
}
