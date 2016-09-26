using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class StickPriceTrackerCommand : Command {

	[Inject]
	public StickPriceTrackerData StickPriceTrackerData{ get; set;}

	[Inject]
	public IStickPriceTrackerService StickPriceTrackerService { get; set;}

	public override void Execute ()
	{
		Retain ();
		string json = JsonUtility.ToJson (StickPriceTrackerData);
		StickPriceTrackerService.OnStickPriceTrackerDataSubmitRequest (json);
		Release ();
	}
}
