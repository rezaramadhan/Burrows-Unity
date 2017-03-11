using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class HighscoreManager : MonoBehaviour {
	private string loc;
	public int highscore;
	private string username;

	private int exp;
	private int money;

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

	private IEnumerator waitforResultHighscore(WWW www, System.Action onComplete) {
		yield return www;

		if (www.error == null) {
			highscore = Int32.Parse(www.text);
			onComplete ();
		} else {
			Debug.Log("Error!" + www.error);
		}
	}

	public void storeGameResult(int score) {
		string url = loc + ".json";
		WWW request = new WWW (url);
		StartCoroutine (waitforRequestUser (request, score));
	}

	private IEnumerator waitforRequestUser(WWW www, int score) {
		yield return www;

		if (www.error == null) {
			string data = www.text;
			User u = new User ();
			u = JsonUtility.FromJson<User> (data);
			Debug.Log (u.toString ());

			u.exp += score;
			u.money += score * 5;

			if (score > highscore)
				highscore = score;

			postNewHighscore(u.exp, u.money, highscore);
		} else {
			Debug.Log("Error!" + www.error);
		}
	}

	private void postNewHighscore(int newexp, int newmoney, int newhighscore) {
		StartCoroutine (uploadNewValue ("exp", newexp));
		StartCoroutine (uploadNewValue ("money", newmoney));
		StartCoroutine (uploadNewValue ("highscore", newhighscore));
	}

	private IEnumerator uploadNewValue(string key, int value) {
		string url = loc + "/" + key + ".json";
		Debug.Log ("URL " + url);
		byte[] data = System.Text.Encoding.ASCII.GetBytes (value.ToString());
		UnityWebRequest req = UnityWebRequest.Put (url, data);

		yield return req.Send();

		if (req.isError) {
			Debug.Log ("ERROR! " + req.error);
		} else {
			Debug.Log ("SUCCESS! " + req.responseCode);
		}
	}
}
