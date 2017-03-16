using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {

	public void backToMenu() {
		Debug.Log ("TOMENU");
		SceneManager.LoadScene ("main_scene");
	}

	public void toPlay() {
		SceneManager.LoadScene ("game_core");
	}

	public void toHighscore() {
		SceneManager.LoadScene ("highscore_scene");
	}

	public void toCredit() {
		SceneManager.LoadScene ("credit_scene");
	}

	public void toLogin() {
		SceneManager.LoadScene ("login_scene\t");
	}
}
