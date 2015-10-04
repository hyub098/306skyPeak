using UnityEngine;
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
        calcScore();
	}

	void SetTimerText()
	{
		timerText.text = timerFormatted;
	}

	void calcScore() {
        
		totalTime = (minute * 60) + second;
        if (totalTime < 30)
        {
<<<<<<< HEAD
            score = 1000;
        } else if (totalTime < 120)
        {
            score = 500;

        }
        else if (totalTime < 240)
        {
            score = 250;

        }
        else if (totalTime < 480)
        {
            score = 125;

        }
        else if (totalTime < 960)
        {
            score = 100;

        }
        else if (totalTime < 1200)
        {
            score = 50;

        } else
        {
            score = 10;
        }
        //Debug.Log(totalTime);
        PlayerPrefs.SetInt("highscore", 545);
=======
            score = 100000;
        } else if (totalTime < 60)
        {
            score = 50000;

        }
        else if (totalTime < 120)
        {
            score = 25000;

        }
        else if (totalTime < 240)
        {
            score = 12500;

        }
        else if (totalTime < 480)
        {
            score = 10000;

        }
        else if (totalTime < 960)
        {
            score = 5000;

        } else
        {
            score = 1000;
        }
        //Debug.Log(totalTime);
        PlayerPrefs.SetInt("highscore", score);
>>>>>>> 5f13bb8bdebce434094b9e44e44ab426f50f1439
    }

	public int getMin() {
		return minute;
	}

	public int getSec() {
		return second;
	}
}
