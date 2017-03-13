using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchChildController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		gameObject.SendMessageUpwards ("hatchContact", col.gameObject);
	}
}
