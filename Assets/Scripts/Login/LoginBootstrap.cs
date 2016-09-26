using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace Golive.MMO.BlueDust.City
{
	public class LoginBootstrap : ContextView
	{
		private void Awake()
		{
			context = new LoginContext(this);
		}
	}
}