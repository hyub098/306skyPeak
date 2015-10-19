using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HunterMovement : MonoBehaviour {

	private Vector3 dest = new Vector3();
	private bool shoot = false;
	private float time = 0;
	private float shootingTime = 0;
	private Animation anim;
	private Axe axe;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		axe = GetComponentInChildren<Axe> ();
		axe.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		time = time + Time.deltaTime;

		//Check if arrive destination, if so, change a new destination and look at that direction
		if (checkArrive ()) {
			newDest();
			transform.LookAt(dest);
		} 

		//if shooting, stop walking, do shoot animation
		if ((int)time % 10 == 0) {

			StartCoroutine(shootTime());
		}

		//if not shooting, walk
		if (!shoot) {
			transform.position = Vector3.Lerp (transform.position, dest, 0.01f);
		}

	}

	//Create new destination
	void newDest(){

		//randomly choose new destination
		float newX = UnityEngine.Random.Range (0, 60);
		float newZ = UnityEngine.Random.Range (0, 60);

		dest = new Vector3 (newX, 1, newZ);
	}

	//check if arrive
	bool checkArrive(){
	
		if (Vector3.Distance (transform.position, dest) < 1) {
			return true;
		}
		return false;
	}


	//Count the time needed to shoot
	IEnumerator shootTime(){
		//do the throw animation
		shoot = true;
		anim.Play ("Lumbering");
		//call AXE to create and throw axe
		axe.enabled = true;

		//play idle animation and wait
		anim.PlayQueued ("Idle");
		yield return new WaitForSeconds(8f);
		//disable AXE and destroy axe
		axe.enabled = false;
		shoot = false;

		//start walking again
		anim.Play ("Walk");

	}
}
