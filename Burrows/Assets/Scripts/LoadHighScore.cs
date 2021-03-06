using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighScore : MonoBehaviour {
	public Text highscoreText;

	private string username;
	private HighscoreManager highscoreManager;

	// Use this for initialization
	void Start () {
		username = PlayerPrefs.GetString ("username");

		highscoreManager = gameObject.AddComponent<HighscoreManager>();
		highscoreManager.setUsername (username);	
		Debug.Log ("get");
		highscoreManager.getHighscore(setHighscoreText);
	}

	void setHighscoreText() {
		int highscore = highscoreManager.highscore;

		highscoreText.text = highscore.ToString ();
	}
}
