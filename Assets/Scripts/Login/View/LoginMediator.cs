using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System.Net;
using UnityEngine.SceneManagement;

public class LoginMediator : Mediator {

	[Inject]
	public LoginView LoginView{ get; set;}

	[Inject]
	public LoginResponseSignal LoginResponseSignal{ get; set;}

	[Inject]
	public LoginRequestSignal LoginRequestSignal{ get; set;}

	[Inject]
	public SetAgentInfoSignal SetAgentInfoSignal{ get; set;}

	public override void OnRegister ()
	{
		LoginView.Initialize ();
		LoginView.LoginClickedSignal.AddListener (OnLoginClick);
		LoginResponseSignal.AddListener (OnLoginResponse);
	}

	public override void OnRemove ()
	{
		LoginView.LoginClickedSignal.RemoveListener (OnLoginClick);
		LoginResponseSignal.RemoveListener (OnLoginResponse);
	}

	public void OnLoginClick(string uname, string pwd)
	{
		LoginData data = new LoginData ();
		data.memberId = uname;
		data.password = pwd;

		LoginRequestSignal.Dispatch (data);

	}

	public UserDetails Details;
	public void OnLoginResponse(LoginResult response)
	{
		LoginResultStatus = response.result;
		Details = response.user;
	}
	public string LoginResultStatus = "";

	public void Update()
	{
		if (LoginResultStatus == "success") 
		{
			//UnityEngine.SceneManagement.SceneManager.LoadScene("SurveyScene");
			LoginView.LoginPanel.SetActive(false);
			LoginView.StickPriceTrackerPanel.SetActive (true);
			SetAgentInfoSignal.Dispatch (Details);
		}
	}

}
