﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {
	public InputField usernameField;
	public InputField passwordField;
	public Text loginStatusText;

	private string username;
	private string password;
	private HighscoreManager highscoreManager;

	public void test() {
		Debug.Log ("haha");
		highscoreManager = gameObject.AddComponent<HighscoreManager>();
		highscoreManager.setUsername ("rezaramadhan");	
		Debug.Log ("get");
		highscoreManager.getHighscore (changeHighscoreText);
	}

	public void login() {
		username = usernameField.text;
		password = passwordField.text;
		Debug.Log("clicked");

//		string username = "rezaramadhan";
//		string password = "pass";

		string loc = "https://burrows-a36e9.firebaseio.com/user/" + username + "/password.json";

		WWW remoteData = new WWW (loc);	
		StartCoroutine (waitForResponse (remoteData));
	} 

	public void changeHighscoreText() {
		int highscore = highscoreManager.highscore;
		loginStatusText.text = highscore.ToString();
	}

	public IEnumerator waitForResponse(WWW www) {
		yield return www;

		if (www.error == null) {
			Debug.Log("OK " + www.text + "|p " + password);

			string responsePassword = www.text;
			if (responsePassword == "null") {
				failed_login ();
			} else if (responsePassword == "\"" + password + "\"") {
				success_login ();
			} else {
				failed_login ();
			}
		} else {
			Debug.Log("Error!" + www.error);
		}
	}

	private void failed_login() {
		Debug.Log ("FailedToLogin");
		loginStatusText.text = "LOGIN FAILED!";
	}

	private void success_login() {
		Debug.Log ("LoginSuccess");
		loginStatusText.text = "LOGIN SUCCESS!";
	}
}