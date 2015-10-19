using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TornadoMovement : MonoBehaviour {
	private List<Vector3> posArray = new List<Vector3> (); 
	private bool added = false;

//	private Vector3[] posArray = new Vector3[5];
	private Vector3 dest = new Vector3();
	void start(){

	}
	// Update is called once per frame
	void Update () {

		//Add destination points to the list if not added
		if (!added) {
			initializeArray();
			dest = posArray[0];
			added = true;
		}


		//On arrive destination, pick a new destination
		if (checkArrive ()) {
			chooseDest();

		} 

		//move tornado
		Debug.Log (dest);
		moveTornado ();
	}

	void initializeArray(){
	
		//List of potential destinations
		posArray.Add(new Vector3 (43f, 7.7f, 65f));
		posArray.Add(new Vector3 (80f, 7.7f, 88f));
		posArray.Add(new Vector3 (16f, 7.7f, 88f));
		posArray.Add(new Vector3 (10f, 7.7f, 20f));
		posArray.Add(new Vector3 (80f, 7.7f, 15f));
		posArray.Add(new Vector3 (10f, 7.7f, 65f));
		posArray.Add(new Vector3 (86f, 7.7f, 65f));
		posArray.Add(new Vector3 (43f, 7.7f, 91f));
		posArray.Add(new Vector3 (43f, 7.7f, 16f));
		
	}

	void chooseDest(){

		//randomly choose one
		int index = UnityEngine.Random.Range (0, 8);
		dest = posArray [index];


	}

	bool checkArrive(){

		//check if tornado arrive destination
		if (Vector3.Distance (transform.position, dest) < 5) {
			return true;
		}
		return false;
	}

	void moveTornado(){

		//move tornado
		transform.position = Vector3.Lerp (transform.position, dest, 0.01f);
	}
}
