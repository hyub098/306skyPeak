using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	int incrementTime = 1;
	float incrementBy = 1;
	float counter = 0;
	int minute = 0;
	int second = 0;
	float time = 0;
	
	public string timerFormatted;
	public Time timerText;

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
		//timerText.text = "Time: " + timerFormatted;
	}
}
