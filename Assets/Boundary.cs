using UnityEngine;
using System.Collections;
public enum Direction
{
	minX, maxX, minY, maxY,minZ,maxZ,normal
}
public class Boundary : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (new Vector3 (0, 0,-10));
		rb.AddForce (new Vector3 (0, 0,10));
		outofbounds ();
	}

	void outofbounds() { 

			if (rb.transform.position.x < minX) {
			rb.AddForce (new Vector3 (10, 0, 0));
			ispushing = true;
		} else if (rb.transform.position.x > maxX) {
			rb.AddForce (new Vector3 (-10, 0, 0));
			d = Direction.maxX;
			ispushing = true;
		} else if (rb.transform.position.z < minZ) {
			rb.AddForce (new Vector3 (0, 0, 10));
			d = Direction.minZ;
			ispushing = true;
		} else if (rb.transform.position.z > maxZ) {
			rb.AddForce (new Vector3 (0, 0, -10));
			Debug.Log ("reach maxZ");
			d = Direction.maxZ;
			ispushing = true;
		} else if (rb.transform.position.y < minY) {
			rb.AddForce (new Vector3 (0, 10, 0));
			d = Direction.minY;
			ispushing = true;
		} else if (rb.transform.position.y > maxY) { 
			rb.AddForce (new Vector3 (0, -10, 0)); 
			d = Direction.maxY;
			ispushing = true;
		} else {
			if(ispushing){
				ispushing=false;
				rb.velocity = Vector3.zero;
			}
		}


}
}
