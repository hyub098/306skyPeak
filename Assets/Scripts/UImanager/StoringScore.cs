using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoringScore : MonoBehaviour {

	private string secretKey = "mySecretKey";
	int score = 0;

	// Add Listener to the text field to get user's name
	void Start () {
		var usernameField = gameObject.GetComponent<InputField>();
		usernameField.onEndEdit.AddListener(SubmitScore);
	}
	
	// Get the user name and score and submit it to the database
	private void SubmitScore(string name) {
		score = PlayerPrefs.GetInt("highscore", score);
		StartCoroutine(PostScores(name, score));
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
		
		var addScoreURL = "http://306skypeak.site90.net/addscore.php?";
		
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
}
