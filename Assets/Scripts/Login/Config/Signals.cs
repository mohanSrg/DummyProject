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

public class OTPRequestSignal : Signal<string, int>
{
}

public class StickPriceTrackerDataSubmitSignal : Signal<StickPriceTrackerData>
{
}
public class StickPriceTrackerSuccessfullySResponseSignal : Signal { }

public class SurveyDataSubmitSignal : Signal<SurveyData>
{
}

public class SurveyDataSuccessfulResponseSignal : Signal { }

public class OTPSuccessfulySentSignal : Signal<OTPResponse> { }
