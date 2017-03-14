using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour {
	public Rigidbody rb;
	public float x;
	public float y;
	private Vector3 rotationVector;
	private float maxRotation = 216f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//item rotation
		float vx = Random.Range (-1 * maxRotation, maxRotation);
		float vy = Random.Range (-1 * maxRotation, maxRotation);
		float vz = Random.Range (-1 * maxRotation, maxRotation);
		rotationVector = new Vector3(vx, vy, vz);
		Debug.Log (rotationVector);
		rb.AddForce (new Vector3 (0, y, x),ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotationVector * Time.deltaTime);
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
