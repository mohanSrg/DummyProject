using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class LoginView : View {

	public InputField UserName;
	public InputField Password;
	public GameObject LoginPanel;
	public GameObject StickPriceTrackerPanel;

	internal Signal<string, string> LoginClickedSignal;
	public void Initialize()
	{
		LoginClickedSignal = new Signal<string, string> ();
		Password.inputType = InputField.InputType.Password;
	}

	public void OnLoginClick()
	{
		string uname = UserName.text.ToString();
		string pwd = Password.text.ToString ();

		LoginClickedSignal.Dispatch (uname, pwd);
	}

    public void OnFeedBackCompletedOkClicked()
    {
        Application.Quit();
    }

}
