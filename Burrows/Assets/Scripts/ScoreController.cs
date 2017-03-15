using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text score;
	public Text result;
	public Text life;
	private int count;
	public int lifecount;
	private StateController state;
	// Use this for initialization
	void Start () {
		count = 0;
		life.text = "Life: " + lifecount.ToString ();

		state = GameObject.Find ("GameState").GetComponent<StateController>();

	}
	
	// Update is called once per frame
	void Update () {
		if (state.end) {
			//change scene
			Debug.Log("END");
			UnityEngine.SceneManagement.SceneManager.LoadScene ("score_scene");
			PlayerPrefs.SetInt ("score", count);
			PlayerPrefs.Save ();
		}
	}

	void FixedUpdate() {
		
	}

	public void addScore() {
		count++;
		score.text = "Score: " + count.ToString ();
	}

	public void reduceLife() {
		lifecount--;
		if (lifecount == 0) {
			result.text = "Game over";
			life.text = "Life: 0";
		}
		else if (lifecount > 0)
			life.text = "Life: " + lifecount.ToString ();
	}

	public int getScore() {
		return count;	
	}
}
