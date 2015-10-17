using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{

    int score = 0;
	private int level;

    public Text scoreText;

	void Start(){
		level = getLevel();
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

    // Update the score of the player
    void Update()
    {

		if (level == 1) {
			score = PlayerPrefs.GetInt ("park");
			
		} else if (level == 2) {
			score = PlayerPrefs.GetInt ("mountain");
			Debug.Log("current score");
			Debug.Log (score);
			
		} else if (level == 3) {
			score =  PlayerPrefs.GetInt ("city");
		}


        scoreText.text = ""+score;
    }

}
