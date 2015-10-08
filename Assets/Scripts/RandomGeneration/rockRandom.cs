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
		
		myList.Add(new Vector3(27,4, 67 ));
		myList.Add(new Vector3(50,4, 67 ));
		myList.Add(new Vector3(78,4, 67 ));
		myList.Add(new Vector3(11,4, 67 ));
		myList.Add(new Vector3(70,4, 67 ));
		myList.Add(new Vector3(23,4, 67 ));
		myList.Add(new Vector3(25,4, 67 ));
		myList.Add(new Vector3(89,4, 67 ));
		myList.Add(new Vector3(9,4, 67 ));
		myList.Add(new Vector3(57+UnityEngine.Random.value*3,4, 67 ));
		
		int number = Mathf.RoundToInt(UnityEngine.Random.value*10);
		transform.position=myList[number];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}