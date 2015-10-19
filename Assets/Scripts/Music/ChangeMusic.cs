using UnityEngine;
using System.Collections;

/**
* ChangeMusic controls the welcome background music to continue playing in the map scene, profile scene
* , score scene and achievement info scene and stop playing when a certain level of game is played.
*/
public class ChangeMusic : MonoBehaviour {

    //the welcome background music
    public AudioClip level1Music;

    private AudioSource source;

    private int count = 0;



    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // check the level and when the level is traning, park, mountain, city and multiplayer,
    // the music will be stoped. 
    void OnLevelWasLoaded(int level)
    {

        count = count + 1;
        // play the music again when the map scene is loaded
        if(level==1 && count != 1)
        {
            source.clip = level1Music;
            source.Play();
        }
          if (level == 2 )
         {
           source.Stop();
        }
        if (level == 3)
        {
            source.Stop();
        }
        if (level == 4)
        {
            source.Stop();
        }
        if (level == 5)
        {
            source.Stop();
        }
        if (level == 6)
        {
            source.Stop();

        }

    }
}
