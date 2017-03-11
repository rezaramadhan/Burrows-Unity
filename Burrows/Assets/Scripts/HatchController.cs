using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchController : MonoBehaviour {
	public Text state;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void hatchContact (GameObject obj) {
		if (obj.CompareTag ("Good")) {
			Rigidbody rb;
			rb = obj.GetComponent<Rigidbody> ();
			rb.AddForce (new Vector3 (0, 5, 0), ForceMode.Impulse);
			gameObject.SendMessageUpwards ("addScore");
		} else {

		}
	}
}
