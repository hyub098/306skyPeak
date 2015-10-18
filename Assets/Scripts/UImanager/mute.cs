using UnityEngine;
using System.Collections;

public class mute : MonoBehaviour {


    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
     
    }

    public void sound()
    {
        if (!source.playOnAwake)
        {
            source.Play();
            source.playOnAwake = true;
        }
        else
        {
            source.Stop();
            source.playOnAwake = false;
        }
    }
}
