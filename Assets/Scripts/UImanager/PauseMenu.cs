using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	private Canvas canvas;

	// Disable the pause menu at the beginnig
	void Start(){
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}


	void Update () {
		//Pause on Escape
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvas.enabled = !canvas.enabled;
			Pause();
		}
	}

	// Change time scale when pausing
	void Pause(){
		if (Time.timeScale == 1f) {
			Time.timeScale = 0f; //Stops the game
		} else {
			Time.timeScale = 1f; //Resume game
		}

	}



}
