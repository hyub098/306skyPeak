using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	int minX = -150; //left boundary 
	int maxX = 150; //right boundary 
	int minY = -150; // up boundary 
	int maxY = 150; // down boundary
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		outofbounds ();
	}

	void outofbounds() { 
		if (transform.position.x < minX) { transform.position=new Vector3(80,140,200); } 
		if (transform.position.x > maxX) { transform.position=new Vector3(80,140,200); }
		if (transform.position.y < minY) { transform.position=new Vector3(80,140,200); }
		if (transform.position.y > maxY) { transform.position=new Vector3(80,140,200); }
	}
}
