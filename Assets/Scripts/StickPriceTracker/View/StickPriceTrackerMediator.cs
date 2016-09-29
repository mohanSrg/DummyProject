using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using System;

public class StickPriceTrackerMediator : Mediator{

	[Inject]
	public SetAgentInfoSignal SetAgentInfoSignal{ get; set;}

	[Inject]
	public StickPriceTrackerView StickPriceTrackerView{ get; set;}

	[Inject]
	public StickPriceTrackerDataSubmitSignal StickPriceTrackerDataSubmitSignal{ get; set;}

    [Inject]
    public StickPriceTrackerSuccessfullySResponseSignal StickPriceTrackerSuccessfullySResponse { get; set; }
    public override void OnRegister ()
	{
		StickPriceTrackerView.Initialize ();
		StickPriceTrackerView.OnStickPriceTrackerSubmitClickedSignal.AddListener (OnStickPriceTrackerSubmit);
		SetAgentInfoSignal.AddListener (SetAgentData);
        StickPriceTrackerSuccessfullySResponse.AddListener(OnStickPriceTrackerSuccessfullySResponse);          
    }

    public override void OnRemove ()
	{
        StickPriceTrackerView.OnStickPriceTrackerSubmitClickedSignal.RemoveListener(OnStickPriceTrackerSubmit);
        SetAgentInfoSignal.RemoveListener (SetAgentData);
        StickPriceTrackerSuccessfullySResponse.RemoveListener(OnStickPriceTrackerSuccessfullySResponse);
    }
    public string memberid;

    public void SetAgentData(UserDetails details)
	{
        StickPriceTrackerView.HeaderDetailsPanel.SetActive(true);
        StickPriceTrackerView.LoginId.text = string.Format("Login Id : {0}",details.memberId);
		StickPriceTrackerView.SurveyorName.GetComponentInChildren<Text>().text= details.psename;
		StickPriceTrackerView.SurveyorName.interactable = false;
        
        memberid = details.memberId;
	}

	public void OnStickPriceTrackerSubmit(StickPriceTrackerData data)
	{
        data.memid = memberid;
        data.date = System.DateTime.Now.Date.ToString();        
        data.time = System.DateTime.Now.TimeOfDay.ToString();
        StickPriceTrackerDataSubmitSignal.Dispatch (data);
	}

    private void OnStickPriceTrackerSuccessfullySResponse()
    {        
        StickPriceTrackerView.StickPriceTrackerPanel.SetActive(false);
        StickPriceTrackerView.SurveyPagePanel.SetActive(true);
    }

}
