using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour {
	public GameObject good;
	public GameObject bad;
	public float zpos;

	public Text result;
	private bool end;
	// Use this for initialization
	void Start () {
		StartCoroutine ("spawnItems",5);
		end = false;
		//Instantiate (good, new Vector3(0,0,zpos), Quaternion.identity);
		//Instantiate (bad, new Vector3(-3,0,zpos), Quaternion.identity);
		//Instantiate (good, new Vector3(3,0,zpos), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (result.text != "")
			end = true;
	}

	private IEnumerator spawnItems(int delay) {
		int rand;
		GameObject spawn;
		while (!end) {
			for (int i = -3; i <= 3; i = i + 3) {
				rand = (int)Random.Range (1, 100);
				if (rand % 2 == 1)
					spawn = good;
				else
					spawn = bad;
				Instantiate (spawn, new Vector3 (i, 0, zpos), Quaternion.identity);
			}
			yield return new WaitForSeconds (delay);
		}
	}
}
