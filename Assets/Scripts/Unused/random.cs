using UnityEngine;
using System.Collections;
//This calss is for random generation
public class random : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		// Generate the object in a certain area
		transform.position=new Vector3(20+60*Random.value, 50 ,80*Random.value );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}