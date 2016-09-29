using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using System;

public class LoginCommand : Command {

	[Inject]
	public ILoginService LoginService { get; set;}

    [Inject]
    public SetAgentInfoSignal SetAgentInfoSignal { get; set; }

    [Inject]
	public LoginData LoginData{ get; set;}

    [Inject]
    public UserDetails UserDetails { get; set; }

    public override void Execute ()
	{
		Retain ();
        SetAgentInfoSignal.AddListener(SetAgentDetails);

        string json = JsonUtility.ToJson (LoginData);
		LoginService.SendLoginRequest (json);
		Release ();
	}

    private void SetAgentDetails(UserDetails details)
    {
        UserDetails = details;
    }
}
