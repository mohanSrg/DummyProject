using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class SurveyView : View {
	public InputField MobileNumber;

	internal Signal<string> OnOTPSendClickSignal;
	public void Initialize()
	{
		OnOTPSendClickSignal = new Signal<string> ();
	}

	public void OnOTPButtonClick()
	{
		string phno = MobileNumber.text.ToString();
		OnOTPSendClickSignal.Dispatch (phno);
	}
}
