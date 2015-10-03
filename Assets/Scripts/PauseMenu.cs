using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvus;

	// Update is called once per frame
	void Update () {

		if (isPaused) {
			pauseMenuCanvus.SetActive (true);
			Time.timeScale = 0f; //Stops the game

		} else {
			pauseMenuCanvus.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}

	}

	public void Resume()
	{
		isPaused = false;

	}

}
