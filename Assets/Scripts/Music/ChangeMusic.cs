using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

    public AudioClip level2Music;
    public AudioClip level1Music;

    private AudioSource source;

    private int count = 0;



    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    //void Update()
    //{
      //  if (_level != 2 && source!=null)
       // {
         //   source.Stop();
        //}
    //}

    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            count = count + 1;
            source.clip = level2Music;
            source.Play();
        }
        else if(count != 0)
        {
            source.clip = level1Music;
            source.Play();
        }

    }
}
