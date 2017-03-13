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
	private int idx;

	public Text result;
	// Use this for initialization
	void Start () {
		i = 0;
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
			i = ((int)Random.Range (1, 3));
			idx = (int)Random.Range (0, items.Length);
			Instantiate (items[idx], new Vector3 ((i - 1) * 3, 0, zpos), Quaternion.identity);
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
		}
	}
}
