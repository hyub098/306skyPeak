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
		if (!added) {
			initializeArray();
			dest = posArray[0];
			added = true;
		}



		if (checkArrive ()) {
			chooseDest();

		} 
		Debug.Log (dest);
		moveTornado ();
			





//			new Vector3( Mathf.Lerp (transform.position.x, dest.x, Time.deltaTime),transform.position.y,Mathf.Lerp(transform.position.z,dest.z,Time.deltaTime));

	}

	void initializeArray(){
	
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
		int index = UnityEngine.Random.Range (0, 4);
//		Debug.Log (index);
		dest = posArray [index];


	}

	bool checkArrive(){
		if (Vector3.Distance (transform.position, dest) < 5) {
			return true;
		}
		return false;
	}

	void moveTornado(){
		transform.position = Vector3.Lerp (transform.position, dest, 0.01f);
	}
}
