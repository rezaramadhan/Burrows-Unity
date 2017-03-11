using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchController : MonoBehaviour {
	public ScoreController control;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
		}
	}

	void hatchContact (GameObject obj) {
		if (obj.CompareTag ("Good")) {
			Rigidbody rb;
			rb = obj.GetComponent<Rigidbody> ();
			rb.AddForce (new Vector3 (0, 5, 0), ForceMode.Impulse);
			control.addScore ();
		} else {
			control.reduceScore ();
		}
	}
}
