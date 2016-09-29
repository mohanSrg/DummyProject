using UnityEngine;
using System.Collections;
using System.Net;

public interface IOTPServiceInterface 
{
	void SendOTPToMobileNumber(string mobileNo, int OTPNumber);
    void OnOTPResponse(string response);
}
