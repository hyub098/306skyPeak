using UnityEngine;
using System.Collections;


/**
* LoadScene loads a specific scene when a click event happens
*/
public class LoadOnClick : MonoBehaviour
{

    public GameObject loadingImage;

    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
		Time.timeScale = 1f;
    }
}
