using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	//public GameObject pauseMenuCanvus;
	private Canvas canvas;


	void Start(){
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {



			canvas.enabled = !canvas.enabled;

			Pause();
		}



//		if (isPaused) {
//			pauseMenuCanvus.SetActive (true);
//
//
//		} else {
//			pauseMenuCanvus.SetActive (false);
//			Time.timeScale = 1f;
//		}



	}

//	public void OnClick(){
//		canvas.enabled = !canvas.enabled;
//		Pause ();
//		Debug.Log
//			("Pressed");
//	}


	void Pause(){
		if (Time.timeScale == 1f) {
	
			Time.timeScale = 0f; //Stops the game
		} else {
			Time.timeScale = 1f; //Resume game
		}

	}



}
