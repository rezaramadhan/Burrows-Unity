using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextController : MonoBehaviour {
	public Text tutorialText;
	public StateTutorialController stateController;
	public GameObject menuButton;
	public GameObject playButton;
	// Use this for initialization
	void Start () {
		StartCoroutine (startTutorial());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator startTutorial() {
		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "In this game you will help to collect\n healthy food and discard unhealthy food";

		yield return new WaitForSecondsRealtime(4.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "You can close the hatch to your Burrows by\n pressing J, K, or L";

		yield return new WaitForSecondsRealtime(3.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "Wait, do you know what is a healthy food?";

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "Let me help you!";

		////////////////////

		yield return new WaitForSecondsRealtime (2f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "This is a Broccoli";

		yield return new WaitForSecondsRealtime (0.2f);
		stateController.state = "spawnGood";
		stateController.itemIdx = 0;

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "It's healthy, let this fall to the Burrows!";

		yield return new WaitForSecondsRealtime (2f);
		StartCoroutine (stopSlowMotion ());


		////////////////////

		yield return new WaitForSecondsRealtime (3f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "This is a Soda Can";

		yield return new WaitForSecondsRealtime (0.2f);
		stateController.state = "spawnBad";
		stateController.itemIdx = 2;

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "There's too much sugar in it, \ndon't ever eat this one!";

		yield return new WaitForSecondsRealtime (2f);
		StartCoroutine (stopSlowMotion ());

		////////////////////

		yield return new WaitForSecondsRealtime (3f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "This is a Soda Bottle";

		yield return new WaitForSecondsRealtime (0.2f);
		stateController.state = "spawnBad";
		stateController.itemIdx = 1;

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "It's a soda, in a bottle :(";

		yield return new WaitForSecondsRealtime (2f);
		StartCoroutine (stopSlowMotion ());

		////////////////////

		yield return new WaitForSecondsRealtime (3f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "This is a Carrot";

		yield return new WaitForSecondsRealtime (0.2f);
		stateController.state = "spawnGood";
		stateController.itemIdx = 2;

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "You know it's good for your eyes, right?";

		yield return new WaitForSecondsRealtime (2f);
		StartCoroutine (stopSlowMotion ());

		////////////////////

		yield return new WaitForSecondsRealtime (3f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "This is a Spray Bottle";

		yield return new WaitForSecondsRealtime (0.2f);
		stateController.state = "spawnBad";
		stateController.itemIdx = 0;

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "Wait, is this one even a food?";

		yield return new WaitForSecondsRealtime (2f);
		StartCoroutine (stopSlowMotion ());

		////////////////////

		yield return new WaitForSecondsRealtime (3f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "This is an Apple";

		yield return new WaitForSecondsRealtime (0.2f);
		stateController.state = "spawnGood";
		stateController.itemIdx = 1;

		yield return new WaitForSecondsRealtime(2.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "You know the rules;\n An apple a day keeps the doctor away!";

		yield return new WaitForSecondsRealtime (2f);
		StartCoroutine (stopSlowMotion ());

		////////
		yield return new WaitForSecondsRealtime (3f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "...";

		yield return new WaitForSecondsRealtime (1.5f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "Well, that's it";

		yield return new WaitForSecondsRealtime (2f);
		tutorialText.text = "";

		yield return new WaitForSecondsRealtime(0.5f);
		tutorialText.text = "See you on the real game!";

		yield return new WaitForSecondsRealtime (1f);
		menuButton.SetActive (true);
		playButton.SetActive (true);
	}
		
	private IEnumerator stopSlowMotion() {
		while (Time.timeScale <= 1f) {
//			Debug.Log (Time.timeScale);
			Time.timeScale *= 8f / 6f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			yield return new WaitForSecondsRealtime (0.1f);
		}
	}
}
