using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
//This calss is for random generation
public class rockRandom : MonoBehaviour {
	public List<Vector3> myList = new List<Vector3>();
	
	// Use this for initialization
	void Start () {
		// Generate the object in a certain area
		//transform.position=new Vector3(100+500*Random.value, 400,800*Random.value );
		myList.Add(new Vector3(32,4 +UnityEngine.Random.value*3, 65 ));
		myList.Add(new Vector3(50,4 +UnityEngine.Random.value*3, 67 ));
		myList.Add(new Vector3(85,4 +UnityEngine.Random.value*3, 76 ));
		myList.Add(new Vector3(15,4 +UnityEngine.Random.value*3, 67 ));
		
		myList.Add(new Vector3(75,10 +UnityEngine.Random.value*3, 21 ));
		myList.Add(new Vector3(32,10 +UnityEngine.Random.value*3, 31 ));
		myList.Add(new Vector3(82,10 +UnityEngine.Random.value*3, 76 ));

		myList.Add(new Vector3(92,6 +UnityEngine.Random.value*3, 48 ));
		myList.Add(new Vector3(9,6 +UnityEngine.Random.value*3, 50 ));
		myList.Add(new Vector3(31,10 +UnityEngine.Random.value*3, 52 ));
		myList.Add(new Vector3(25,10 +UnityEngine.Random.value*3, 35 ));
		myList.Add(new Vector3(86,15 +UnityEngine.Random.value*3, 20 ));
		myList.Add(new Vector3(9,15 +UnityEngine.Random.value*3, 68 ));
		myList.Add(new Vector3(17,10+UnityEngine.Random.value*3, 90 ));

		myList.Add(new Vector3(53,10+UnityEngine.Random.value*3, 96 ));
		myList.Add(new Vector3(89,15+UnityEngine.Random.value*3, 80 ));
		myList.Add(new Vector3(96,15 +UnityEngine.Random.value*3, 92 ));
		myList.Add(new Vector3(91,4 +UnityEngine.Random.value*3, 18 ));
		myList.Add(new Vector3(62,15 +UnityEngine.Random.value*3, 54 ));
		myList.Add(new Vector3(7,4 +UnityEngine.Random.value*3, 6 ));
		
		int number = Mathf.RoundToInt(UnityEngine.Random.value*10);
		transform.position=myList[number];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}