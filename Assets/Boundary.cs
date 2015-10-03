using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
<<<<<<< HEAD
	int minX = -250; //left boundary 
	int maxX = 200; //right boundary 
	int minY = -10; // up boundary 
	int maxY = 2000; // down boundary
	int maxZ =2000;
	int minZ =-2000;
	public Rigidbody rb;
	float strengh=1.0f;
	bool ispushing=false;
	int counter=0;
	Direction d =Direction.normal;
=======
	int minX = -150; //left boundary 
	int maxX = 150; //right boundary 
	int minY = -150; // up boundary 
	int maxY = 150; // down boundary
>>>>>>> 207fccd2c6a592b72dbb50d410b7636ac0baf509
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
