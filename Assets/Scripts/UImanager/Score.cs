using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{



    int score = 0;


    public Text scoreText;



    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+PlayerPrefs.GetInt("highscore", score);
    }

}
