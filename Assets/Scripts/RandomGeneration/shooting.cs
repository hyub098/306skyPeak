using UnityEngine;
using System.Collections;
// This class is for shooting arrow
public class shooting : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	private int count;
	private Vector3 vector;
    public AudioClip shootSound;
    private AudioSource source;
    // Use this for initialization
    void Start()
    {
        count = 0;
        source = GetComponent<AudioSource>();
        source.clip = shootSound;
    }

    // Update is called once per frame
    void Update ()
	{
			// Shoot an arrow every 1 seconds
			if (count > 100) {
            // Create the arrow and add a force to it
            //source.Play();
            Rigidbody instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody;
			instantiatedProjectile.gameObject.transform.Rotate(-90f,0.0f,0.0f);
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
			//Destroy the arrow after 10 seconds
			Destroy (instantiatedProjectile.gameObject, 10);
			count=0;
		}
		count++;
	}
}
