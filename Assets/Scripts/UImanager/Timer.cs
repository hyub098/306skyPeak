﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer: MonoBehaviour {

	int incrementTime = 1;
	float incrementBy = 1;
	float counter = 0;
	public int minute = 0;
	public int second = 0;
	int totalTime;
	float factorScore;
	int score =0 ;
	float time = 0;
	
	public string timerFormatted;
	public Text timerText;
	public Text scoreText;

	private int level;

	// Initialize timer to 00:00
	void Start () {

		SetTimerText();
		level = getLevel();
	}
	
	// Update the timer every second
	void Update () {

		minute = (int)counter / 60;
		second = (int)counter % 60;
		time += Time.deltaTime;
		while (time > incrementTime)
		{
			time -= incrementTime;
			counter += incrementBy;
		}

		timerFormatted = string.Format("{0:00}:{1:00}", minute, second);
		SetTimerText();
        calcScore();
	}

	void SetTimerText()
	{
		timerText.text = timerFormatted;
	}

	int getLevel(){
		int level = 0;
		if(Application.loadedLevelName.Equals("Park")){
			level = 1;
		}else if(Application.loadedLevelName.Equals("mountain1")){
			level = 2;
		}else if(Application.loadedLevelName.Equals("city")){
			level = 3;
		}
		return level;
	}

	// Algorithm to calculate the score using the time played
	void calcScore() {
        
		totalTime = (minute * 60) + second;
        //if (totalTime < 30)
        //{
        //  score = 1000;
        //} else if (totalTime < 120)
        //{
        //  score = 500;

        //}
        //else if (totalTime < 240)
        //{
        //  score = 250;

        //}
        //else if (totalTime < 480)
        //{
        //  score = 125;

        //}
        //else if (totalTime < 960)
        //{
        //  score = 100;

        //}
        //else if (totalTime < 1200)
        //{
        //  score = 50;

        //} else
        //{
        //  score = 10;
        //}
        if (totalTime != 0) {
            score = 1000000 / totalTime; 
        }
        
        // Store the player's score
		if (level == 1) {
			PlayerPrefs.SetInt ("park", score);
		} else if (level == 2) {
			PlayerPrefs.SetInt ("mountain", score);
		} else if (level == 3) {
			PlayerPrefs.SetInt ("city", score);
		}

    }

}
