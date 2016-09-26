using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class SurveyMediator : Mediator {

	[Inject]
	public SurveyView SurveyView { get; set;}

	[Inject]
	public OTPRequestSignal OTPRequestSignal{ get; set;}
	public override void OnRegister ()
	{
		SurveyView.Initialize ();
		SurveyView.OnOTPSendClickSignal.AddListener (OnOTPSendClicked);
	}

	public override void OnRemove ()
	{
		SurveyView.OnOTPSendClickSignal.RemoveListener (OnOTPSendClicked);
	}

	public void OnOTPSendClicked(string mobileNo)
	{
		OTPRequestSignal.Dispatch (mobileNo);
	}
}
