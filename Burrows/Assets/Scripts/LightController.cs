using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
	private Light torch;
	// Use this for initialization
	void Start () {
		torch = GetComponent<Light> ();
		StartCoroutine ("torchGlow");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator torchGlow() {
		while (true) {
			yield return new WaitForSeconds (5);
			torch.intensity = 2;
			yield return new WaitForSeconds (1);
			torch.intensity = 1;
		}
	}
}
