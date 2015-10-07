using UnityEngine;
using System.Collections;

// This class is for move the random generated stones to a random generated place
public class randomFalling : MonoBehaviour {
	int flyCount;
    public AudioClip stoneSound;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        source.clip = stoneSound;
    }
	
	// Update is called once per frame
	void Update () {

		// After a period of time, move the object to a random place
		flyCount++;
		if (flyCount > 1000) {
			transform.position=new Vector3(100+500*Random.value, 400,800*Random.value );
            source.Play();
            flyCount =0;
		}
		
		
		
	}
}
