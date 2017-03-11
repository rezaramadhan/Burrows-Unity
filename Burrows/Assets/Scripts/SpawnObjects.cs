using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
	public GameObject test;
	public float zpos;
	// Use this for initialization
	void Start () {
		Instantiate (test, new Vector3(0,0,zpos), Quaternion.identity);
		Instantiate (test, new Vector3(-3,0,zpos), Quaternion.identity);
		Instantiate (test, new Vector3(3,0,zpos), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
