using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//This class is for random generation of scrolss in city 
public class cityRandom : MonoBehaviour {
	public List<Vector3> myList = new List<Vector3>();
	
	// Use this for initialization
	void Start () {
		// Generate the scrolls randomly from these available values
		// Values are chosen keeping in mind that none of them are accessible in the game area
		
		myList.Add(new Vector3(27,10 +UnityEngine.Random.value*15, 21 ));
		myList.Add(new Vector3(50,10 +UnityEngine.Random.value*15, 50 ));
		myList.Add(new Vector3(68,10 +UnityEngine.Random.value*15, 21 ));
		myList.Add(new Vector3(11,10 +UnityEngine.Random.value*15, 7 ));
		myList.Add(new Vector3(78,10 +UnityEngine.Random.value*15, 14 ));
		
		
		myList.Add(new Vector3(32,10 +UnityEngine.Random.value*15, 65 ));
		myList.Add(new Vector3(50,10 +UnityEngine.Random.value*15, 67 ));
		myList.Add(new Vector3(65,10 +UnityEngine.Random.value*15, 36 ));
		myList.Add(new Vector3(15,10 +UnityEngine.Random.value*15, 67 ));
		myList.Add(new Vector3(75,10 +UnityEngine.Random.value*15, 21 ));
		
		
		myList.Add(new Vector3(32,10 +UnityEngine.Random.value*15, 31 ));
		myList.Add(new Vector3(56,10 +UnityEngine.Random.value*15, 76 ));
		myList.Add(new Vector3(30,10 +UnityEngine.Random.value*15, 48 ));
		myList.Add(new Vector3(9,10 +UnityEngine.Random.value*15, 50 ));
		myList.Add(new Vector3(71,10 +UnityEngine.Random.value*15, 62 ));
		
		myList.Add(new Vector3(15,10 +UnityEngine.Random.value*15, 32 ));
		myList.Add(new Vector3(55,10 +UnityEngine.Random.value*15, 20 ));
		myList.Add(new Vector3(10,10 +UnityEngine.Random.value*15, 68 ));
		myList.Add(new Vector3(17,10+UnityEngine.Random.value*15, 58 ));
		myList.Add(new Vector3(53,10+UnityEngine.Random.value*15, 35 ));
		
		myList.Add(new Vector3(66,10+UnityEngine.Random.value*15, 44 ));
		myList.Add(new Vector3(34,10 +UnityEngine.Random.value*15, 34 ));
		myList.Add(new Vector3(47,10 +UnityEngine.Random.value*15, 44 ));
		myList.Add(new Vector3(62,10 +UnityEngine.Random.value*15, 54 ));
		myList.Add(new Vector3(17,10 +UnityEngine.Random.value*15, 16 ));

		// Randomly pick one position from the 25 above
		
		int number = Mathf.RoundToInt(UnityEngine.Random.value*25);
		transform.position=myList[number];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
