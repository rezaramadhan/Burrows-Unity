using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTutorialController : MonoBehaviour {
	public StateTutorialController stateController;
	public GameObject[] goodItems;
	public GameObject[] badItems;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("state " + stateController.state);
		if (stateController.state == "spawnGood") {	
			Debug.Log ("spawnGood");
			stateController.state = "spawningGood";
			StartCoroutine (spawnItem (goodItems [stateController.itemIdx], stateController.itemIdx * 3 - 3));
		} else if (stateController.state == "spawnBad") {
			stateController.state = "spawningBad";
			StartCoroutine (spawnItem (badItems [stateController.itemIdx], stateController.itemIdx * 3 - 3));
		}
	}

	private IEnumerator spawnItem (GameObject item, int position) {
		Debug.Log ("Spawning");
		Instantiate (item, new Vector3 (position, 0, 5), Quaternion.identity);

		yield return new WaitForSecondsRealtime (0.27f);
		Debug.Log("timescale " +Time.timeScale);
		while (Time.timeScale >= 0.02f) {
//			Debug.Log (Time.timeScale);
			Time.timeScale *= 7f / 8f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			yield return new WaitForSecondsRealtime (0.1f);
		}

		Debug.Log ("Outofloop");
		yield return new WaitForSecondsRealtime (0.01f);
	}

}
