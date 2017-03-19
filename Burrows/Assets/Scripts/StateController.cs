using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour {
	public bool start;
	public bool end;
	public Text result;
	public AudioSource bgm;
	// Use this for initialization
	void Start () {
		Debug.Log ("test");
		start = true;
		end = false;
		bgm.loop = true;

		bgm.volume = 0.07f;
		bgm.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (end == true) {
			start = false;
			bgm.Stop ();
		}
	}
}
