using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class StickPriceTrackerMediator : Mediator{

	[Inject]
	public SetAgentInfoSignal SetAgentInfoSignal{ get; set;}

	[Inject]
	public StickPriceTrackerView StickPriceTrackerView{ get; set;}

	[Inject]
	public StickPriceTrackerDataSubmitSignal StickPriceTrackerDataSubmitSignal{ get; set;}
	public override void OnRegister ()
	{
		StickPriceTrackerView.Initialize ();
		StickPriceTrackerView.OnStickPriceTrackerSubmitClickedSignal.AddListener (OnStickPriceTrackerSubmit);
		SetAgentInfoSignal.AddListener (SetAgentData);

	}

	public override void OnRemove ()
	{
		SetAgentInfoSignal.RemoveListener (SetAgentData);
	}

	public void SetAgentData(UserDetails details)
	{
		StickPriceTrackerView.LoginId.text = string.Format("Login Id : {0}",details.memberId);
		StickPriceTrackerView.SurveyorName.GetComponentInChildren<Text>().text= details.psename;
		StickPriceTrackerView.SurveyorName.interactable = false;
		StickPriceTrackerView.SurveyArea.GetComponentInChildren<Text>().text = details.psecity;
		StickPriceTrackerView.SurveyArea.interactable = false;
	}

	public void OnStickPriceTrackerSubmit(StickPriceTrackerData data)
	{
		StickPriceTrackerDataSubmitSignal.Dispatch (data);
	}
}
