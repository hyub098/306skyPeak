using UnityEngine;
using System.Collections;


/**
* LoadScene loads a specific scene when a click event happens
*/
public class LoadOnClick : MonoBehaviour
{

    void Start()
    {
		Time.timeScale = 1f;
    }

    // load a specific scene due to the number of level
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
		Time.timeScale = 1f;
    }
}
