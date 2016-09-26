using UnityEngine;
using System.Collections;
using System.Net;

public interface ILoginService {

	void SendLoginRequest (string json);
	void OnLoginResponse(object sender, UploadStringCompletedEventArgs e);
}
