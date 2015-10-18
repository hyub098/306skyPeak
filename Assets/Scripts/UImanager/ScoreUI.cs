using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class ScoreUI : MonoBehaviour
{
	//public Text guiText;
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

	//public Canvas park;
	//public Canvas city;
	//public Canvas mountain;
	
	
	private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server

	void Start()
	{

		StartCoroutine(GetScores());
		
	}




    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
	{

		var highscoreURL = "http://306skypeak.site90.net/dispPark.php";
        /*
		if (park.enabled) {
			highscoreURL = "http://306skypeak.site90.net/dispPark.php";

		} else if (mountain.enabled) {
			highscoreURL = "http://306skypeak.site90.net/dispMountain.php";

		} else if (city.enabled) {
			highscoreURL = "http://306skypeak.site90.net/dispCity.php";

		}*/

			
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;

		Debug.Log(hs_get);
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			
			Regex rgx = new Regex("[^a-zA-Z0-9 & - , <]");
			string str = hs_get.text.ToString();
			Debug.Log(str);
			str = rgx.Replace(str, "");
			
			List<string> results = extractString(str).Split(',').ToList<string>();

			if (results.Count > 1){
				firstNameText.text = results[0];
				firstScoreText.text = results[1];
			}

			if (results.Count > 3){
				secondtNameText.text = results[2];
				secondScoreText.text = results[3];
			}

			if (results.Count > 5){
				thirdNameText.text = results[4];
				thirdScoreText.text = results[5];
			}

			if (results.Count > 7){
				fourthNameText.text = results[6];
				fourthScoreText.text = results[7];
			}

			if (results.Count > 9){
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