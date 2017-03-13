﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchController : MonoBehaviour {
	public ScoreController control;
	private float idletime; // time of idle 
	private bool istate;
	// Use this for initialization
	void Start () {
		istate = false;
	}
	
	// Update is called once per frame
	/// <summary>
	/// if player is idling (not opening any hatches) for 5 seconds, 
	/// 1 life will be taken away for each 5 seconds
	/// </summary>
	void Update () { 
		if (Input.GetKeyDown ("j")) {
			if (this.transform.GetChild (0).gameObject.activeSelf) {
				this.transform.GetChild (0).gameObject.SetActive (false);
				this.transform.parent.GetChild (0).GetChild (0).gameObject.SetActive (true);
			} else {
				this.transform.GetChild (0).gameObject.SetActive (true);
				this.transform.parent.GetChild (0).GetChild (0).gameObject.SetActive (false);
			}
		} else if (Input.GetKeyDown ("k")) {
			if (this.transform.GetChild (1).gameObject.activeSelf) {
				this.transform.GetChild (1).gameObject.SetActive (false);
				this.transform.parent.GetChild (0).GetChild (1).gameObject.SetActive (true);
			} else {
				this.transform.GetChild (1).gameObject.SetActive (true);
				this.transform.parent.GetChild (0).GetChild (1).gameObject.SetActive (false);
			}
		} else if (Input.GetKeyDown ("l")) {
			if (this.transform.GetChild (2).gameObject.activeSelf) {
				this.transform.GetChild (2).gameObject.SetActive (false);
				this.transform.parent.GetChild (0).GetChild (2).gameObject.SetActive (true);
			} else {
				this.transform.GetChild (2).gameObject.SetActive (true);
				this.transform.parent.GetChild (0).GetChild (2).gameObject.SetActive (false);
			}
		} else { //if no input is pressed and all hatches are closed (idle)
			if (!this.transform.parent.GetChild (0).GetChild (0).gameObject.activeSelf &&
			    !this.transform.parent.GetChild (0).GetChild (1).gameObject.activeSelf &&
			    !this.transform.parent.GetChild (0).GetChild (2).gameObject.activeSelf) {
				//checks if this is the first caught instance of idling
				if (!istate) { 
					//initiate idle time count
					idletime = Time.time;
					istate = true;
				} else { //check if idle time >= 5 seconds
					if (Time.time >= idletime + 5f) {
						//reduce life & reset idle time count
						control.reduceLife ();
						idletime = Time.time;
					}
				}
			} else {
				//one or more hatches are open; reset idle state
				istate = false;
			}
		}
	}

	void hatchContact (GameObject obj) {
		Rigidbody rb;
		rb = obj.GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (0, 5, 0), ForceMode.Impulse);
		if (obj.CompareTag ("Bad")) {
			//control.addScore ();
		} else {
			//control.reduceScore ();
		}
	}
}
