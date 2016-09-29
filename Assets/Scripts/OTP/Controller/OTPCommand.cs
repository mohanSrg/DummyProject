using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class OTPCommand : Command {

	[Inject]
	public IOTPServiceInterface OTPServiceInterface{ get; set;}

	[Inject]
	public string MobileNumber{ get; set;}

    [Inject]
    public int OTPNumber { get; set; }
	public override void Execute ()
	{
		Retain ();
        OTPServiceInterface.SendOTPToMobileNumber (MobileNumber, OTPNumber);        
        Release ();
	}

}
