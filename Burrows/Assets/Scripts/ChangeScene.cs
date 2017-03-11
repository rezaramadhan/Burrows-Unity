using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {

	public void backToMenu() {
		SceneManager.LoadScene ("main_scene");
	}

	public void toPlay() {
		SceneManager.LoadScene ("play_scene");
	}

	public void toHighscore() {
		SceneManager.LoadScene ("highscore_scene");
	}

	public void toCredit() {
		SceneManager.LoadScene ("credit_scene");
	}
}
