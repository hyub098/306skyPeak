using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	int minX = -200; //left boundary 
	int maxX = 200; //right boundary 
	int minY = -200; // up boundary 
	int maxY = 200; // down boundary
	int maxZ =200;
	int minZ =-200;
	private Rigidbody rb;
	bool ispushing=false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		outofbounds ();
	}
	
	void outofbounds() { 
		
		if (rb.transform.position.x < minX) {
			transform.position=new Vector3 (minX, transform.position.y, transform.position.z);
		
		} else if (rb.transform.position.x > maxX) {
			transform.position=new Vector3 (maxX, transform.position.y, transform.position.z);


		} else if (rb.transform.position.z < minZ) {
			transform.position=new Vector3 (transform.position.x, transform.position.y, minZ);


		} else if (rb.transform.position.z > maxZ) {
			transform.position=new Vector3 (transform.position.x, transform.position.y,maxZ);

		} else if (rb.transform.position.y < minY) {
			transform.position=new Vector3 (transform.position.x, minY, transform.position.z);

		} else if (rb.transform.position.y > maxY) { 
			transform.position=new Vector3 (transform.position.x, maxY, transform.position.z);

		} 
			
	}
}