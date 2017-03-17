using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreHandler : MonoBehaviour {
	public Text scoreText;
	public Button playButton;
	public Button toMenuButton;
	public GameObject[] loadingitems;

	private HighscoreManager highscoreManager;
	private string username;
	private int putDataCounter;


	// Use this for initialization
	void Start () {
		putDataCounter = 0;

		int score = PlayerPrefs.GetInt ("score");
//		int score = 75;
		scoreText.text = score.ToString();
		username = PlayerPrefs.GetString ("username");

		highscoreManager = gameObject.AddComponent<HighscoreManager>();
		highscoreManager.setUsername (username);	
		Debug.Log ("get");
		highscoreManager.getHighscore (null);
		highscoreManager.storeGameResult(score, incrementDataCounter);
	}

	void incrementDataCounter() {
		putDataCounter++;
	}

	// Update is called once per frame
	void Update () {
		if (putDataCounter >= 3) {
			enableButton ();
		}	
	}

	void enableButton() {
		foreach (GameObject item in loadingitems) {
			item.SetActive (false);
		}

		playButton.gameObject.SetActive(true);
		toMenuButton.gameObject.SetActive(true);
		putDataCounter = 0;
	}
}
