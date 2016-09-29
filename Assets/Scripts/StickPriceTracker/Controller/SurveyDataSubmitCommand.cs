using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class SurveyDataSubmitCommand : Command {

    [Inject]
    public SurveyData SurveyData { get; set; }

    [Inject]
    public ISurveyDataService SurveyDataService { get; set; }

    public override void Execute()
    {
        Retain();
        string json = JsonUtility.ToJson(SurveyData);
        SurveyDataService.OnSurveyDataSubmitRequest(json);
        Release();
    }
}
