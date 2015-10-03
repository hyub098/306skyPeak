using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseMenuCanvus;

	// Update is called once per frame
	void Update () {

		if (isPaused) {
			pauseMenuCanvus.SetActive (true);
		} else {
			pauseMenuCanvus.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}

	}

	public void Resume()
	{
		isPaused = false;

	}

	public void LevelSelect(){

	}

	public void Quit(){

	}
}
