using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text score;
	public Text statetxt;
	public Text life;
	private int count;
	public int hp;
	private StateController state;
	// Use this for initialization
	void Start () {
		count = 0;
		life.text = "Life: " + hp.ToString ();

		state = GameObject.Find ("GameState").GetComponent<StateController>();
	}
	// Use this for initialization
	
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
		count += 10;
		score.text = "Score: " + count.ToString ();
	}

	public void reduceLife() {
		hp--;
		if (hp <= 0) {
			life.text = "Life: 0";
			state.end = true;
		} else {
			Debug.Log ("Health Down");
			life.text = "Life: " + hp.ToString ();
		}
	}

	public int getScore() {
		return count;	
	}
}
