using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text score;
	public Text result;
	public Text life;
	private int count;
	public int hp;
	// Use this for initialization
	void Start () {
		count = 0;
		life.text = "Life: " + hp.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		
	}

	public void addScore() {
		count += 10;
		score.text = "Score: " + count.ToString ();
	}

	public void reduceLife() {
		hp--;
		if (hp == 0) {
			result.text = "Game over";
			life.text = "Life: 0";
		}
		else if (hp > 0)
			life.text = "Life: " + hp.ToString ();
	}

	public int getScore() {
		return count;
	}
}
