using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//This calss is for random generation
public class parkRandom : MonoBehaviour {
	public List<Vector3> myList = new List<Vector3>();
	
	// Use this for initialization
	void Start () {
		// Generate the object in a certain area
		//transform.position=new Vector3(100+500*Random.value, 400,800*Random.value );
		myList.Add(new Vector3(32,4 +UnityEngine.Random.value*15, 65 ));
		myList.Add(new Vector3(50,4 +UnityEngine.Random.value*15, 52 ));
		myList.Add(new Vector3(36,4 +UnityEngine.Random.value*15, 42 ));
		myList.Add(new Vector3(43,4 +UnityEngine.Random.value*15, 10 ));


		myList.Add(new Vector3(75,6 +UnityEngine.Random.value*15, 15 ));
		myList.Add(new Vector3(9,6 +UnityEngine.Random.value*15, 50 ));
		myList.Add(new Vector3(31,10 +UnityEngine.Random.value*15, 22 ));
		myList.Add(new Vector3(11,10 +UnityEngine.Random.value*15, 35 ));
		myList.Add(new Vector3(75,15 +UnityEngine.Random.value*15, 68 ));

		myList.Add(new Vector3(53,10+UnityEngine.Random.value*15, 78 ));
		myList.Add(new Vector3(75,15+UnityEngine.Random.value*15, 72 ));
		myList.Add(new Vector3(33,15 +UnityEngine.Random.value*15, 15 ));
		myList.Add(new Vector3(18,4 +UnityEngine.Random.value*15, 55 ));
		myList.Add(new Vector3(23,15 +UnityEngine.Random.value*15, 67 ));
		myList.Add(new Vector3(7,4 +UnityEngine.Random.value*15, 6 ));
		
		int number = Mathf.RoundToInt(UnityEngine.Random.value*15);
		transform.position=myList[number];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}