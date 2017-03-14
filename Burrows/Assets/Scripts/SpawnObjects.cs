using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour {
	public GameObject good;
	public GameObject bad;
	public GameObject[] items;
	private StateController state;
	public float zpos;
	public float spawnrate;
	private int i;
	//private int j;
	private int idx;
	private float elapsed;

	public Text result;
	// Use this for initialization
	void Start () {
		i = 0;
		//j = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//start game if start state
		state = GameObject.Find ("GameState").GetComponent<StateController>();
		if (i == 0 && state.start) {
			//spawning items
			StartCoroutine ("spawnItems", spawnrate);
			i = 1;
			elapsed = Time.time;
		}
	}

	private IEnumerator spawnItems(float delay) {
		int itr = 0;
		int j = 1;
		int k = 1;

		//looping until game over
		do {
			do {
				j = ((int)Random.Range (1, 4));
			} while (j == k);
			idx = (int)Random.Range (0, items.Length);
			Instantiate (items [idx], new Vector3 ((j - 2) * 3, 0, zpos), Quaternion.identity);
//
//			for (int i = -3; i <= 3; i = i + 3) {
//				rand = (int)Random.Range (1, 100);
//				if (rand % 2 == 1)
//					spawn = good;
//				else
//					spawn = bad;
//				Instantiate (spawn, new Vector3 (i, 0, zpos), Quaternion.identity);
//			}
			yield return new WaitForSeconds (delay);
			//difficulty ramps up every 10 seconds; default is easy
			//final difficulty after 60 seconds
			if (itr == 0 && Time.time >= elapsed + 10f) { //medium
				delay = delay / 2;
				itr++;
			}
			if (itr == 1 && Time.time >= elapsed + 20f) { //hard
				delay = delay / 2;
				itr++;
			}
			if (itr == 2 && Time.time >= elapsed + 30f) { //expert
				delay = delay / 2;
				itr++;
			}
			if (itr == 3 && Time.time >= elapsed + 40f) { //insane; double item spawn
				k = ((int)Random.Range (1, 4));
				idx = (int)Random.Range (0, items.Length);
				Instantiate (items [idx], new Vector3 ((k - 2) * 3, 0, zpos), Quaternion.identity);
				itr++;
			}
			if (itr == 4 && Time.time >= elapsed + 60f) { //hell; triple item spawn max speed - good luck
				do {
					idx = (int)Random.Range (0, items.Length);
					Instantiate (items [idx], new Vector3 (-3, 0, zpos), Quaternion.identity);
					idx = (int)Random.Range (0, items.Length);
					Instantiate (items [idx], new Vector3 (0, 0, zpos), Quaternion.identity);
					idx = (int)Random.Range (0, items.Length);
					Instantiate (items [idx], new Vector3 (3, 0, zpos), Quaternion.identity);
					yield return new WaitForSeconds (0.2f);
				} while (!state.end);
			}
		} while (!state.end);
	}
}
