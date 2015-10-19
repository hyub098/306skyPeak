using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class CityScoreUI : MonoBehaviour
{
    public Text firstNameText;
    public Text firstScoreText;

    public Text secondtNameText;
    public Text secondScoreText;

    public Text thirdNameText;
    public Text thirdScoreText;

    public Text fourthNameText;
    public Text fourthScoreText;

    public Text fifthtNameText;
    public Text fifthScoreText;



    private string secretKey = "mySecretKey"; 

    void Start()
    {

        StartCoroutine(GetScores());

    }




    // Get the City Level Scores
    IEnumerator GetScores()
    {

        var highscoreURL = "http://306skypeak.site90.net/dispCity.php";


        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        Debug.Log(hs_get);

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {

            // Format the returned scores from DB and php scripts
            Regex rgx = new Regex("[^a-zA-Z0-9 & - , <]");
            string str = hs_get.text.ToString();
            Debug.Log(str);
            str = rgx.Replace(str, "");

            List<string> results = extractString(str).Split(',').ToList<string>();

            // Display the scores
            if (results.Count > 1)
            {
                firstNameText.text = results[0];
                firstScoreText.text = results[1];
            }

            if (results.Count > 3)
            {
                secondtNameText.text = results[2];
                secondScoreText.text = results[3];
            }

            if (results.Count > 5)
            {
                thirdNameText.text = results[4];
                thirdScoreText.text = results[5];
            }

            if (results.Count > 7)
            {
                fourthNameText.text = results[6];
                fourthScoreText.text = results[7];
            }

            if (results.Count > 9)
            {
                Debug.Log(results.Count);
                fifthtNameText.text = results[8];
                fifthScoreText.text = results[9];
            }

            Debug.Log(extractString(str));
        }


    }

    public static string extractString(string s)
    {
        int l = s.IndexOf("<");
        if (l > 0)
        {
            return s.Substring(0, l);
        }
        return "";

    }


}