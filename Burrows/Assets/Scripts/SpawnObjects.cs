using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour {
	public GameObject good;
	public GameObject bad;
	private StateController state;
	public float zpos;
	public float spawnrate;
	private int i;

	public Text result;
	// Use this for initialization
	void Start () {
		i = 0;
		//Instantiate (good, new Vector3(0,0,zpos), Quaternion.identity);
		//Instantiate (bad, new Vector3(-3,0,zpos), Quaternion.identity);
		//Instantiate (good, new Vector3(3,0,zpos), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		state = GameObject.Find ("GameState").GetComponent<StateController>();
		if (i == 0 && state.start) {
			StartCoroutine ("spawnItems", spawnrate);
			i = 1;
		}
	}

	private IEnumerator spawnItems(float delay) {
		int rand;
		GameObject spawn;

		while (!state.end) {
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
