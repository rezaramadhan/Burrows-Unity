using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreHandler : MonoBehaviour {
	public Text scoreText;
	private HighscoreManager highscoreManager;
	private string username;
	// Use this for initialization
	void Start () {
		int score = PlayerPrefs.GetInt ("score");
		scoreText.text = score.ToString();
		username = PlayerPrefs.GetString ("username");

		highscoreManager = gameObject.AddComponent<HighscoreManager>();
		highscoreManager.setUsername (username);	
		Debug.Log ("get");
		highscoreManager.getHighscore (null);
		highscoreManager.storeGameResult(score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
