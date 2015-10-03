using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	private int count;

	void Start(){
		count = 0;
	
	}

	// Update is called once per frame
	void Update ()
	{
			if (count > 20) {
			Rigidbody instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody;
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
			//Destroy (instantiatedProjectile, 3);
			count=0;
		}
		count++;
	}
}
