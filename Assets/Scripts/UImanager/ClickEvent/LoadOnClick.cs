using UnityEngine;
using System.Collections;


/**
* LoadScene loads a specific scene when a click event happens
*/
public class LoadOnClick : MonoBehaviour
{

    //public AudioClip clickSound;
    //private AudioSource source;

    void Start()
    {
        //source = GetComponent<AudioSource>();
        //source.clip = clickSound;
		Time.timeScale = 1f;
    }

    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        //source.clip = clickSound;
        //source.Play();
        Application.LoadLevel(level);
		Time.timeScale = 1f;
    }
}
