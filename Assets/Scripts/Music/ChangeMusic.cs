using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

    //public AudioClip level2Music;
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

        count = count + 1;
        if(level==1 && count != 1)
        {
            source.clip = level1Music;
            source.Play();
        }
          if (level == 2 )
         {
           source.Stop();
        }

    }
}
