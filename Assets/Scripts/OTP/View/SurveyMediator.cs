using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;

public class SurveyMediator : Mediator {

	[Inject]
	public SurveyView SurveyView { get; set;}

	[Inject]
	public OTPRequestSignal OTPRequestSignal{ get; set;}

    [Inject]
    public OTPSuccessfulySentSignal OTPSuccessfulySentSignal { get; set; }
    [Inject]
    public SurveyDataSubmitSignal SurveyDataSubmitSignal { get; set; }

    [Inject]
    public SurveyDataSuccessfulResponseSignal SurveyDataSuccessfulResponseSignal { get; set; }

    [Inject]
    public UserDetails UserDetails { get; set; }
    public override void OnRegister ()
	{
		SurveyView.Initialize ();
		SurveyView.OnOTPSendClickSignal.AddListener (OnOTPSendClicked);
        SurveyView.OnOTPSubmitSignal.AddListener(OnOTPEntered);
        OTPSuccessfulySentSignal.AddListener(OnOTPSuccessfulySent);
        SurveyView.OnSurveyDataSubmitSignal.AddListener(OnSubmitSurveyData);
        SurveyDataSuccessfulResponseSignal.AddListener(OnFeedBackCompleted);

    }

    public override void OnRemove ()
	{
		SurveyView.OnOTPSendClickSignal.RemoveListener (OnOTPSendClicked);
        OTPSuccessfulySentSignal.RemoveListener(OnOTPSuccessfulySent);
        SurveyView.OnOTPSubmitSignal.RemoveListener(OnOTPEntered);
        SurveyView.OnSurveyDataSubmitSignal.RemoveListener(OnSubmitSurveyData);
        SurveyDataSuccessfulResponseSignal.RemoveListener(OnFeedBackCompleted);


    }
    public int otpnumber = 0;
    public void OnOTPSendClicked(string mobileNo)
	{
        System.Random sdf = new System.Random();
        otpnumber = sdf.Next(111111,999999);
        OTPRequestSignal.Dispatch (mobileNo, otpnumber);
	}

    private void OnOTPSuccessfulySent(OTPResponse response)
    {
        if (response.Result == "success")
        {
            SurveyView.EnterOTPPanel.SetActive(true);
        }
    }
    private void OnOTPEntered(string number)
    {
        if(otpnumber == Int32.Parse(number))
        {
            SurveyView.EnterOTPPanel.SetActive(false);
            SurveyView.SubmitButton.enabled = true;
        }
    }

    private void OnSubmitSurveyData(SurveyData data)
    {
        data.memberId = UserDetails.memberId;
        data.sarea = UserDetails.surveyarea;
        data.sareacode = UserDetails.psecode;
        data.psename = UserDetails.username;
        data.location = UserDetails.location;
        data.psecity = UserDetails.psecity;
        
        SurveyDataSubmitSignal.Dispatch(data);
    }
    public void OnFeedBackCompleted()
    {
        SurveyView.FeedBackcompleted.SetActive(true);
    }
}
