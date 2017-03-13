using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehavior : MonoBehaviour {
	public Rigidbody rb;
	public float x;
	public float y;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce (new Vector3 (0, y, x),ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
