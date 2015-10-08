using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	int minX = -600; //left boundary 
	int maxX = 600; //right boundary 
	int minY = -100; // up boundary 
	int maxY = 600; // down boundary
	int maxZ =600;// front boundary
	int minZ =-600; //back boundary
	private Rigidbody rb;
	bool ispushing=false;

    public AudioClip hitSound;
    private AudioSource source;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		outofbounds ();
	}
	
	void outofbounds() { 
		//set the x,y,z position to limit if out of bounds
		if (rb.transform.position.x < minX) {
			transform.position=new Vector3 (minX, transform.position.y, transform.position.z);
            source.clip = hitSound;
            source.Play();

        } else if (rb.transform.position.x > maxX) {
			transform.position=new Vector3 (maxX, transform.position.y, transform.position.z);
            source.clip = hitSound;
            source.Play();


        } else if (rb.transform.position.z < minZ) {
			transform.position=new Vector3 (transform.position.x, transform.position.y, minZ);
            source.clip = hitSound;
            source.Play();


        } else if (rb.transform.position.z > maxZ) {
			transform.position=new Vector3 (transform.position.x, transform.position.y,maxZ);
            source.clip = hitSound;
            source.Play();

        } else if (rb.transform.position.y < minY) {
			transform.position=new Vector3 (transform.position.x, minY, transform.position.z);
            source.clip = hitSound;
            source.Play();

        } else if (rb.transform.position.y > maxY) { 
			transform.position=new Vector3 (transform.position.x, maxY, transform.position.z);
            source.clip = hitSound;
            source.Play();

        } 
			
	}
}