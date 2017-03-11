using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighscore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("username " + PlayerPrefs.GetString ("username"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
