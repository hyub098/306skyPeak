using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPersonalHSMountain : MonoBehaviour
{
    private string secretKey = "mySecretKey"; // Key stored on the server
    public Text guiText;
    // Use this for initialization
    void Start()
    {
        var usernameField = gameObject.GetComponent<UnityEngine.UI.InputField>();
        usernameField.onEndEdit.AddListener(SubmitScore);
    }

    // Get the user name and gets Mountain HS from the database
    private void SubmitScore(string name)
    {
        StartCoroutine(GetScores(name));
    }

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

    // Get the scores from the MySQL DB to display in a GUIText.
    IEnumerator GetScores(string name)
    {

        var highscoreURL = "http://306skypeak.site90.net/dispPersonalMountainHS.php?";
        string hash = Md5Sum(name + secretKey);
        string post_url = highscoreURL + "name=" + WWW.EscapeURL(name) + "&hash=" + hash;

        WWW hs_get = new WWW(post_url);
        yield return hs_get;


        Debug.Log(hs_get);

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            guiText.text = extractString(hs_get.text); // this is a GUIText that will display the scores in game.
            Debug.Log(extractString(hs_get.text));
        }
    }
    //Extract only the data from the Database
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
