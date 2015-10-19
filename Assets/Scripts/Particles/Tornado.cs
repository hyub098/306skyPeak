using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour {

	public GameObject player;

	private FlyMovement flymovement;
	private Rigidbody rb;
	private float realtime;
	private float time;
	private bool collide = false;


	// Use this for initialization
	void Start () {

		time = 0;
		realtime = 0;
		flymovement = player.GetComponent<FlyMovement> ();
		rb = player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {


		//enable owl's control from player after 2 sec
		realtime = Time.deltaTime + realtime;
		if (realtime - time > 2 && collide) {
		
			flymovement.enabled = true;
			rb.velocity = Vector3.zero;
			collide = !collide;
		}

		checkNear ();
	}


	//If near tornado, create collision
	void checkNear(){


		//throw owl away if it comes near
		if (Vector3.Distance (player.transform.position, transform.position) < 8) {
			flymovement.enabled = false;
			collide = true;
			time = realtime;
			
			rb.AddForce (200f, -20.0f*Time.deltaTime,2000f, ForceMode.Force);
		}
	}
}
