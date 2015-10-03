using UnityEngine;
using System.Collections;


public class Score : MonoBehaviour {

	public bool lost;
	public GameObject pauseMenuCanvus;
	public Text scoreText;
	
	// Update is called once per frame
	void Update () {
		
		if (lost) {
			pauseMenuCanvus.SetActive (true);
			Time.timeScale = 0f; //Stops the game
			dispScore();

			
		} else {
			pauseMenuCanvus.SetActive (false);
			Time.timeScale = 1f;
		}
		
		if (Input.GetKeyDown (KeyCode.Delete)) {
			lost = !lost;
		}
		
	}

	public void dispScore() {
		scoreText.text = "";

	}

	public void calcScore() {
		
	}

}
