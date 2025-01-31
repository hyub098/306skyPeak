﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class GetAchievements : MonoBehaviour {
    //public Text guiText;
    private string secretKey = "mySecretKey"; // Key stored on the server

    //nine images of achievements                                         
    public Image a_image;
    public Image b_image;
    public Image c_image;
    public Image d_image;
    public Image e_image;
    public Image f_image;
    public Image g_image;
    public Image h_image;
    public Image i_image;

    // Use this for initialization
    void Start () {
        Color temp = a_image.color;
        temp.a = 0.1f;
        a_image.color = temp;
        Color temp2 = b_image.color;
        temp2.a = 0.1f;
        b_image.color = temp;
        Color temp3 = c_image.color;
        temp3.a = 0.1f;
        c_image.color = temp;
        Color temp4 = d_image.color;
        temp4.a = 0.1f;
        d_image.color = temp4;
        Color temp5 = e_image.color;
        temp5.a = 0.1f;
        e_image.color = temp5;
        Color temp6 = f_image.color;
        temp6.a = 0.1f;
        f_image.color = temp6;
        Color temp7 = g_image.color;
        temp7.a = 0.1f;
        g_image.color = temp7;
        Color temp8 = h_image.color;
        temp8.a = 0.1f;
        h_image.color = temp8;
        Color temp9 = i_image.color;
        temp9.a = 0.1f;
        i_image.color = temp9;
        var usernameField = gameObject.GetComponent<InputField>();
        usernameField.onEndEdit.AddListener(SubmitScore);
    }

    // Get the user name and gets achivements from the database
    private void SubmitScore(string name)
    {
        StartCoroutine(GetUserAchievements(name));
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

    // Get the achievemnts from the MySQL DB and change achievement images alpha value depending on whether achievement was obtained.
    IEnumerator GetUserAchievements(string user)
    {
 
        var highscoreURL = "http://306skypeak.site90.net/dispPersonalAchievements.php?";

        string hash = Md5Sum(user + secretKey);
        string post_url = highscoreURL + "user=" + WWW.EscapeURL(user) + "&hash=" + hash;

        WWW hs_get = new WWW(post_url);
        yield return hs_get;
        

        Regex rgx = new Regex("[^a-zA-Z0-9 & - , < ']");
        string str = hs_get.text.ToString();
        str = rgx.Replace(str, "");
        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {   
            //returned string of achievements from db is separated by comma 
            //store achievemnts in list       
            List<string> achievements = extractString(str).Split(',').ToList<string>();
            foreach (string s in achievements)
            {
				if (s.Equals("learningToFly"))
                {
                    Color temp = a_image.color;
                    temp.a = 1.0f;
                    a_image.color = temp;
                }
				if (s.Equals("aintNoMountainHighEnough"))
                {
                    Color temp = b_image.color;
                    temp.a = 1.0f;
                    b_image.color = temp;
                }
				if (s.Equals("stormyWeather"))
                {
                    Color temp = c_image.color;
                    temp.a = 1.0f;
                    c_image.color = temp;
                }
				if (s.Equals("runThroughTheJungle"))
                {
                    Color temp = d_image.color;
                    temp.a = 1.0f;
                    d_image.color = temp;
				}
				if (s.Equals("mountainKing"))
                {
                    Color temp = e_image.color;
                    temp.a = 1.0f;
                    e_image.color = temp;
				}
				if (s.Equals("midnightCity"))
                {
                    Color temp = f_image.color;
                    temp.a = 1.0f;
                    f_image.color = temp;
                }
				if (s.Equals("underPressure"))
                {
                    Color temp = g_image.color;
                    temp.a = 1.0f;
                    g_image.color = temp;
                }
				if (s.Equals("dontStopBelieving"))
                {
                    Color temp = h_image.color;
                    temp.a = 1.0f;
                    h_image.color = temp;
                }
				if (s.Equals("livinOnAPrayer"))
                {
                    Color temp = i_image.color;
                    temp.a = 1.0f;
                    i_image.color = temp;
                }
            }

            Debug.Log(extractString(str));
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
