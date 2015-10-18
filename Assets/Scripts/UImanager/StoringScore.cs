using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoringScore : MonoBehaviour {
	
	private string secretKey = "mySecretKey";
	private int level;
	int score = 0;
	string achievement = "win";
	
	private MailCount mailCount;
	
	
	// Add Listener to the text field to get user's name
	void Start () {
		var usernameField = gameObject.GetComponent<InputField>();
		usernameField.onEndEdit.AddListener(SubmitScore);

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
	
	
	// Get the user name and score and submit it to the database
	private void SubmitScore(string name) {
		// Store the player's score
		if (level == 1) {
			score = PlayerPrefs.GetInt ("park");
			
		} else if (level == 2) {
			score = PlayerPrefs.GetInt ("mountain");
			
		} else if (level == 3) {
			score =  PlayerPrefs.GetInt ("city");
		}
		
		StartCoroutine(PostScores(name, score));

		if (MailCount.timeMountain) {
			StartCoroutine (PostAchievement (name, "mountainKing"));
		}

		if (MailCount.city3Lives) {
			StartCoroutine (PostAchievement (name, "stormyWeather"));
		}

		if (MailCount.closeOne) {
			StartCoroutine (PostAchievement (name, "livinOnAPrayer"));
		}

		if (MailCount.mountain3Live) {
			StartCoroutine (PostAchievement (name, "aintNoMountainHighEnough"));
		}

		if (MailCount.park3Lives) {
			StartCoroutine (PostAchievement (name, "learningToFly"));
		}

		if (MailCount.timeCity) {
			StartCoroutine (PostAchievement (name, "midnightCity"));
		}

		if (MailCount.timePark) {
			StartCoroutine (PostAchievement (name, "runThroughTheJungle"));
		} 

		if (Collision.pressure) {
			StartCoroutine (PostAchievement (name, "underPressure"));
		} 

		if (Collision.wipeout) {
			StartCoroutine (PostAchievement (name, "dontStopBelieving"));
		} 
	}
	
	//Helper function to store in the database
	public string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
	
	// Posting score to the database
	IEnumerator PostScores(string name, int score)
	{
		var addScoreURL = "http://306skypeak.site90.net/addPark.php?";
		
		if (level == 1) {
			addScoreURL = "http://306skypeak.site90.net/addPark.php?";
		} else if (level == 2) {
			Debug.Log("adding to mountain");
			addScoreURL = "http://306skypeak.site90.net/addMountain.php?";
		} else if (level == 3) {
			addScoreURL = "http://306skypeak.site90.net/addCity.php?";
		}
		
		
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(name + score + secretKey);
		
		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
		
		Debug.Log(post_url);
		
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	
	IEnumerator PostAchievement(string user, string achievement)
	{
		var addAchievementURL = "http://306skypeak.site90.net/addAchievment.php?";
		
		
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash2 = Md5Sum(user + achievement + secretKey);
		
		string post_url2 = addAchievementURL + "user=" + WWW.EscapeURL(user) + "&achievement=" + achievement + "&hash=" + hash2;
		
		Debug.Log(post_url2);
		
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post2 = new WWW(post_url2);
		yield return hs_post2; // Wait until the download is done
		
		
		if (hs_post2.error != null)
		{
			print("There was an error posting the high score: " + hs_post2.error);
		}
	}
}
