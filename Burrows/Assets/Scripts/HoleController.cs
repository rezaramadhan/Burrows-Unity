using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleController : MonoBehaviour {
	public ScoreController control;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void holeContact(GameObject obj) {
		if (obj.CompareTag ("Good")) {
			control.addScore ();
		} else {
			control.reduceLife ();
		}
	}
}
