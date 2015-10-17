using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//This calss is for random generation
public class cityRandom : MonoBehaviour {
	public List<Vector3> myList = new List<Vector3>();

	// Use this for initialization
	void Start () {
		// Generate the object in a certain area
		//transform.position=new Vector3(100+500*Random.value, 400,800*Random.value );

		myList.Add(new Vector3(27,4, 21 ));
		myList.Add(new Vector3(50,4, 50 ));
		myList.Add(new Vector3(78,4, 21 ));
		myList.Add(new Vector3(11,4, 7 ));
		myList.Add(new Vector3(70,4, 14 ));
		myList.Add(new Vector3(23,4, 67 ));
		myList.Add(new Vector3(25,4, 43 ));
		myList.Add(new Vector3(89,4, 46 ));
		myList.Add(new Vector3(9,4, 67 ));

		myList.Add(new Vector3(32,4 +UnityEngine.Random.value*4, 65 ));
		myList.Add(new Vector3(50,4 +UnityEngine.Random.value*4, 52 ));
		myList.Add(new Vector3(36,4 +UnityEngine.Random.value*4, 42 ));
		myList.Add(new Vector3(43,4 +UnityEngine.Random.value*4, 10 ));
		
		
		myList.Add(new Vector3(75,6 +UnityEngine.Random.value*4, 15 ));
		myList.Add(new Vector3(9,6 +UnityEngine.Random.value*4, 50 ));
		myList.Add(new Vector3(31,10 +UnityEngine.Random.value*4, 22 ));
		myList.Add(new Vector3(11,10 +UnityEngine.Random.value*4, 35 ));
		myList.Add(new Vector3(75,15 +UnityEngine.Random.value*4, 68 ));
		
		myList.Add(new Vector3(53,10+UnityEngine.Random.value*4, 78 ));
		myList.Add(new Vector3(75,15+UnityEngine.Random.value*4, 72 ));
		myList.Add(new Vector3(33,15 +UnityEngine.Random.value*4, 15 ));
		myList.Add(new Vector3(18,4 +UnityEngine.Random.value*4, 55 ));
		myList.Add(new Vector3(23,15 +UnityEngine.Random.value*4, 67 ));
		myList.Add(new Vector3(7,4 +UnityEngine.Random.value*4, 6 ));
		
		myList.Add(new Vector3(7,4 +UnityEngine.Random.value*4, 6 ));


		int number = Mathf.RoundToInt(UnityEngine.Random.value*25);
		transform.position=myList[number];



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}