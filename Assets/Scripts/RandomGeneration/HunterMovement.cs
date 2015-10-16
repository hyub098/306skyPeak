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
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
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
		float newX = UnityEngine.Random.Range (0, 20);
		float newZ = UnityEngine.Random.Range (0, 20);

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
		shoot = true;
		anim.Play ("Lumbering");
		yield return new WaitForSeconds(5f);

		shoot = false;
		anim.Play ("Walk");

	}
}
