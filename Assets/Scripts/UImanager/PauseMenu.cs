using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	private Canvas canvas;


	void Start(){
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {


		//Pause on Escape
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvas.enabled = !canvas.enabled;
			Pause();
		}

	}

	//Changes time scale
	void Pause(){
		if (Time.timeScale == 1f) {
			Time.timeScale = 0f; //Stops the game
		} else {
			Time.timeScale = 1f; //Resume game
		}

	}



}
