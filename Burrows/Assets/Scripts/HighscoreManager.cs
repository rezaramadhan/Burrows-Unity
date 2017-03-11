using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour {
	private string loc;
	public int highscore;
	private string username;

	public void setUsername(string username) {
		string baseloc = "https://burrows-a36e9.firebaseio.com/user/";
		loc = baseloc + username;
	}

	public void getHighscore(System.Action onComplete) {
		string url = loc + "/highscore.json";
		Debug.Log ("url " + url);
		WWW data = new WWW (url);
		StartCoroutine (waitforResultHighscore (data, onComplete));
	}

	public void postHighscore() {
		
	}

	public IEnumerator waitforResultHighscore(WWW www, System.Action onComplete) {
		yield return www;

		if (www.error == null) {
			highscore = Int32.Parse(www.text);
			onComplete ();
		} else {
			Debug.Log("Error!" + www.error);
		}
	}
}
