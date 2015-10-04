using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	int incrementTime = 1;
	float incrementBy = 1;
	float counter = 0;
	public int minute = 0;
	public int second = 0;
	int totalTime;
	float factorScore;
	int score;
	float time = 0;
	
	public string timerFormatted;
	public Text timerText;
	public Text scoreText;

	// Use this for initialization
	void Start () {

		SetTimerText();
	}
	
	// Update is called once per frame
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
	
	}

	void SetTimerText()
	{
		timerText.text = timerFormatted;
	}

	void calcScore() {

		totalTime = (minute * 60) + second;
		factorScore = 1 / totalTime;
		score = (int)factorScore * 100000;
	}

	public int getMin() {
		return minute;
	}

	public int getSec() {
		return second;
	}
}
