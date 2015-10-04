using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	private int count;
	private Vector3 vector;

	void Start(){
		count = 0;
	
	}

	// Update is called once per frame
	void Update ()
	{

			if (count > 100) {

			Rigidbody instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody;
			instantiatedProjectile.gameObject.transform.Rotate(-90f,0.0f,0.0f);
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
			Destroy (instantiatedProjectile.gameObject, 3);
			count=0;
		}
		count++;
	}
}
