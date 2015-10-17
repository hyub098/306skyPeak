using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class HSController : MonoBehaviour
{
    public Text guiText;
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
                                              //be sure to add a ? to your url
    public Image a_image;
    public Image b_image;
    public Image c_image;
    public Image d_image;
    public Image e_image;
    public Image f_image;
    public Image g_image;
    public Image h_image;
    public Image i_image;

  

    void Start()
    {
        Color temp = a_image.color;
        temp.a = 0.5f;
        a_image.color = temp;
        Color temp2 = b_image.color;
        temp2.a = 0.5f;
        b_image.color = temp;
        Color temp3 = c_image.color;
        temp3.a = 0.5f;
        c_image.color = temp;
        Color temp4 = d_image.color;
        temp4.a = 0.5f;
        d_image.color = temp4;
        Color temp5 = a_image.color;
        temp5.a = 0.5f;
        a_image.color = temp5;
        Color temp6 = b_image.color;
        temp6.a = 0.5f;
        b_image.color = temp6;
        Color temp7 = c_image.color;
        temp7.a = 0.5f;
        c_image.color = temp7;
        Color temp8 = d_image.color;
        temp8.a = 0.5f;
        d_image.color = temp8;
        Color temp9 = d_image.color;
        temp9.a = 0.5f;
        d_image.color = temp9;
        var usernameField = gameObject.GetComponent<InputField>();
        usernameField.onEndEdit.AddListener(SubmitScore);
    }


    // Get the user name and gets achivements from the database
    private void SubmitScore(string name)
    {
        StartCoroutine(GetAchievements(name));
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
    // remember to use StartCoroutine when calling this function!
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

    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        var highscoreURL = "http://306skypeak.site90.net/displayImages.php";
        guiText.text = "Loading Scores";

        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        Debug.Log(hs_get);

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            guiText.text = hs_get.text; // this is a GUIText that will display the scores in game.
            Debug.Log(hs_get.text);
        }
    }

    IEnumerator GetAchievements(string user)
    {
        /*var usersUrl = "http://306skypeak.site90.net/getUsers.php";
        WWW hs_get0 = new WWW(usersUrl);
        yield return hs_get0;
        if (hs_get0.error != null)
        {
            print("There was an error getting the high score: " + hs_get0.error);
        }
        else
        {
            namesText.text = hs_get0.text; // this is a GUIText that will display the scores in game.
            Debug.Log(hs_get0.text);
        }*/


        var highscoreURL = "http://306skypeak.site90.net/dispTest.php?";
        guiText.text = "Loading Scores";
        string hash = Md5Sum(user + secretKey);
        string post_url = highscoreURL + "user=" + WWW.EscapeURL(user) + "&hash=" + hash;

        WWW hs_get = new WWW(post_url);
        yield return hs_get;


        //Debug.Log(post_url);

        Regex rgx = new Regex("[^a-zA-Z0-9 & - , <]");
        string str = hs_get.text.ToString();
        str = rgx.Replace(str, "");
        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            guiText.text = extractString(str); // this is a GUIText that will display the scores in game.
            List<string> achievements = extractString(str).Split(',').ToList<string>();
            foreach (string s in achievements)
            {
                if (s.Equals("Hello"))
                {
                    Color temp = a_image.color;
                    temp.a = 1.0f;
                    a_image.color = temp;
                }
                if (s.Equals("Hello2"))
                {
                    Color temp = b_image.color;
                    temp.a = 1.0f;
                    b_image.color = temp;
                }
                if (s.Equals("Hello3"))
                {
                    Color temp = c_image.color;
                    temp.a = 1.0f;
                    c_image.color = temp;
                }
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