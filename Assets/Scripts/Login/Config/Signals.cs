using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;
using System.Net;

public class LoginResponseSignal : Signal<LoginResult> {

}

public class LoginRequestSignal : Signal<LoginData> {

}
public class SetAgentInfoSignal : Signal<UserDetails>
{
}

public class OTPRequestSignal : Signal<string>
{
}

public class StickPriceTrackerDataSubmitSignal : Signal<StickPriceTrackerData>
{
}
