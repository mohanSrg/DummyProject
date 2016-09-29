using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using ITCProject;

public class LoginContext : SignalContext {

	public LoginContext(ContextView contextView) : base(contextView)
	{

	}

	protected override void mapBindings()
	{
		mediationBinder.Bind<LoginView> ().To<LoginMediator> ();
		injectionBinder.Bind<LoginResponseSignal> ().ToSingleton();
		injectionBinder.Bind<ILoginService> ().To<LoginService> ();
		commandBinder.Bind<LoginRequestSignal> ().To<LoginCommand> ();
        injectionBinder.Bind<UserDetails>().ToSingleton();

		//stick price tracker
		mediationBinder.Bind<StickPriceTrackerView>().To<StickPriceTrackerMediator>();
		injectionBinder.Bind<SetAgentInfoSignal>().ToSingleton();
		commandBinder.Bind<StickPriceTrackerDataSubmitSignal> ().To<StickPriceTrackerCommand> ();
		injectionBinder.Bind<IStickPriceTrackerService> ().To<StickPriceTrackerService> ();
        injectionBinder.Bind<StickPriceTrackerSuccessfullySResponseSignal>().ToSingleton();

		mediationBinder.Bind<SurveyView> ().To<SurveyMediator> ();
        injectionBinder.Bind<ISurveyDataService>().To<SurveyDataService>();
        injectionBinder.Bind<SurveyDataSuccessfulResponseSignal>().ToSingleton();
        commandBinder.Bind<SurveyDataSubmitSignal>().To<SurveyDataSubmitCommand>();
            

        injectionBinder.Bind<IOTPServiceInterface> ().To<OTPService> ();
        injectionBinder.Bind<OTPSuccessfulySentSignal>().ToSingleton();
		commandBinder.Bind<OTPRequestSignal> ().To<OTPCommand> ();
	}
}
