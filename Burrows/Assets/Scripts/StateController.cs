using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour {
	public bool start;
	public bool end;
	public Text result;
	// Use this for initialization
	void Start () {
		Debug.Log ("test");
		start = true;
		end = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (result.text.Length > 0) {
			start = false;
			end = true;
		}
	}
}
