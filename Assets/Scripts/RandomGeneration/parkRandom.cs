using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//This class is for random generation of scrolss in park 
public class parkRandom : MonoBehaviour {
	public List<Vector3> myList = new List<Vector3>();
	
	// Use this for initialization
	void Start () {
		// Generate the scrolls randomly from these available values
		// Values are chosen keeping in mind that none of them are accessible in the game area
		myList.Add(new Vector3(32,4 +UnityEngine.Random.value*15, 65 ));
		myList.Add(new Vector3(50,4 +UnityEngine.Random.value*15, 52 ));
		myList.Add(new Vector3(36,4 +UnityEngine.Random.value*15, 42 ));
		myList.Add(new Vector3(43,4 +UnityEngine.Random.value*15, 17 ));


		myList.Add(new Vector3(65,6 +UnityEngine.Random.value*15, 15 ));
		myList.Add(new Vector3(9,6 +UnityEngine.Random.value*15, 50 ));
		myList.Add(new Vector3(31,6 +UnityEngine.Random.value*15, 22 ));
		myList.Add(new Vector3(13,6 +UnityEngine.Random.value*15, 35 ));
		myList.Add(new Vector3(75,6 +UnityEngine.Random.value*15, 66 ));

		myList.Add(new Vector3(53,6+UnityEngine.Random.value*15, 78 ));
		myList.Add(new Vector3(67,6+UnityEngine.Random.value*15, 62 ));
		myList.Add(new Vector3(33,6 +UnityEngine.Random.value*15, 25 ));
		myList.Add(new Vector3(18,6 +UnityEngine.Random.value*15, 55 ));
		myList.Add(new Vector3(23,6 +UnityEngine.Random.value*15, 63 ));
		myList.Add(new Vector3(67,6 +UnityEngine.Random.value*15, 32 ));

		// Randomly pick one position from the 15 above
		
		int number = Mathf.RoundToInt(UnityEngine.Random.value*15);
		transform.position=myList[number];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
