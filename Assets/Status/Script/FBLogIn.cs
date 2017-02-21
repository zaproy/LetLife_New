using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FBLogIn : MonoBehaviour {

	public GameObject loggedInUI;
	public GameObject notLoggedInUI;
	public Image profilePic;
	void Awake(){
		if (!FB.IsInitialized) {
			FB.Init (InitCallBack);
		}
	}

	void InitCallBack(){
		Debug.Log ("FB Initialized");
	}

	public void Login(){
		if (!FB.IsLoggedIn) {
			FB.LogInWithReadPermissions (new List<string>{ "user_friends" }, LogInCallBack);
		}
	}

	void LogInCallBack(ILoginResult result){
		if (result.Error == null) {
			Debug.Log ("Is Log In");
			ShowUI ();
		} else {
			Debug.Log ("Error" + result.Error);
		}
	}

	void ShowUI(){
		if (FB.IsLoggedIn) {
			loggedInUI.SetActive (true);
			notLoggedInUI.SetActive (false);
			FB.API ("me/picture?width=100&height=100", HttpMethod.GET, PictureCallBack);
			FB.API ("/me?fields=first_name", HttpMethod.GET, NameCallBack);
		} else {
			loggedInUI.SetActive (false);
			notLoggedInUI.SetActive (true);
		}
	}

	void PictureCallBack(IGraphResult result){
		Texture2D Image = result.Texture;
		//loggedInUI.transform.FindChild ("ProfilePicture").GetComponent<Image> ().sprite = Sprite.Create (Image, new Rect (0, 0, 100, 100), new Vector2 (0.5f, 0.5f));
		profilePic.sprite = Sprite.Create (Image, new Rect (0, 0, 100, 100), new Vector2 (0.5f, 0.5f));
	}

	void NameCallBack(IGraphResult result){
		IDictionary<string,object> profile = result.ResultDictionary;
		loggedInUI.transform.FindChild ("Name").GetComponent<Text> ().text = "Hello " + profile ["first_name"];
		
	}

	public void LogOut(){
		FB.LogOut ();
		ShowUI ();
	}
}
