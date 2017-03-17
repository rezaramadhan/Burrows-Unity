using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingRotationManager : MonoBehaviour {
	private float x;
	private float y;
	private float z;
	private Vector3 zeroPoint;
	private float maxrotate;

	// Use this for initialization
	void Start () {
		maxrotate = 100;
		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y + 0.6f;
		z = gameObject.transform.position.z;
		zeroPoint = new Vector3 (x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
//		transform.RotateAround (zeroPoint, rotationVector * Time.deltaTime);
		transform.RotateAround(zeroPoint, Vector3.up, maxrotate*Time.deltaTime);
		transform.RotateAround(zeroPoint, Vector3.left, maxrotate*Time.deltaTime);
//		transform.RotateAround(zeroPoint, Vector3.forward, maxrotate*Time.deltaTime);
	}
}
