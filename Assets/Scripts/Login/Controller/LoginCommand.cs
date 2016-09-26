using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class LoginCommand : Command {

	[Inject]
	public ILoginService LoginService { get; set;}

	[Inject]
	public LoginData LoginData{ get; set;}
	public override void Execute ()
	{
		Retain ();
		string json = JsonUtility.ToJson (LoginData);
		LoginService.SendLoginRequest (json);
		Release ();
	}
}
