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
		myList.Add(new Vector3(32,10 +UnityEngine.Random.value*15, 65 ));
		myList.Add(new Vector3(50,10 +UnityEngine.Random.value*15, 67 ));
		myList.Add(new Vector3(75,10 +UnityEngine.Random.value*15, 36 ));
		myList.Add(new Vector3(15,10 +UnityEngine.Random.value*15, 67 ));
		
		myList.Add(new Vector3(75,10 +UnityEngine.Random.value*15, 21 ));
		myList.Add(new Vector3(32,10 +UnityEngine.Random.value*15, 31 ));
		myList.Add(new Vector3(56,10 +UnityEngine.Random.value*15, 76 ));

		myList.Add(new Vector3(30,10 +UnityEngine.Random.value*15, 48 ));
		myList.Add(new Vector3(9,10 +UnityEngine.Random.value*15, 50 ));
		myList.Add(new Vector3(71,10 +UnityEngine.Random.value*15, 62 ));
		myList.Add(new Vector3(15,10 +UnityEngine.Random.value*15, 32 ));
		myList.Add(new Vector3(81,10 +UnityEngine.Random.value*15, 20 ));
		myList.Add(new Vector3(10,10 +UnityEngine.Random.value*15, 68 ));
		myList.Add(new Vector3(17,10+UnityEngine.Random.value*15, 88 ));

		myList.Add(new Vector3(53,10+UnityEngine.Random.value*15, 88 ));
		myList.Add(new Vector3(86,10+UnityEngine.Random.value*15, 80 ));
		myList.Add(new Vector3(34,10 +UnityEngine.Random.value*15, 34 ));
		myList.Add(new Vector3(45,10 +UnityEngine.Random.value*15, 44 ));
		myList.Add(new Vector3(62,10 +UnityEngine.Random.value*15, 54 ));
		myList.Add(new Vector3(17,10 +UnityEngine.Random.value*15, 16 ));
		
		int number = Mathf.RoundToInt(UnityEngine.Random.value*20);
		transform.position=myList[number];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}