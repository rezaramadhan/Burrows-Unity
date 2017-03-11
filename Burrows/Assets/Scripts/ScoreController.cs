using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text score;
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		
	}

	public void addScore() {
		count++;
		score.text = "Score: " + count.ToString ();
	}

	public void reduceScore() {
		count--;
		score.text = "Score: " + count.ToString ();
	}
}
