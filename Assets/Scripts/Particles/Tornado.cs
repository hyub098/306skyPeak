﻿using UnityEngine;
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

		realtime = Time.deltaTime + realtime;
		if (realtime - time > 3 && collide) {
		
			flymovement.enabled = true;
			rb.velocity = Vector3.zero;
			collide = !collide;
		}

		checkNear ();
	}


	//If near tornado, create collision
	void checkNear(){
		if (Vector3.Distance (player.transform.position, transform.position) < 8) {
			flymovement.enabled = false;
			collide = true;
			time = realtime;
			
			rb.AddForce (5000.0f, 200.0f, 3000.0f, ForceMode.Force);
		}
	}
}