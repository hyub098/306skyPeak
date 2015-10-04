using UnityEngine;
using System.Collections;
public enum Direction
{
	minX, maxX, minY, maxY,minZ,maxZ,normal
}
public class Boundary : MonoBehaviour {
	int minX = -600; //left boundary 
	int maxX = 600; //right boundary 
	int minY = -600; // up boundary 
	int maxY = 600; // down boundary
	int maxZ =600;
	int minZ =-600;
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
		outofbounds ();
	}
	
	void outofbounds() { 
		
		if (rb.transform.position.x < minX) {
			transform.position=new Vector3 (minX, transform.position.y, transform.position.z);
			ispushing = true;
		} else if (rb.transform.position.x > maxX) {
			transform.position=new Vector3 (maxX, transform.position.y, transform.position.z);
			d = Direction.maxX;
			ispushing = true;
		} else if (rb.transform.position.z < minZ) {
			transform.position=new Vector3 (transform.position.x, transform.position.y, minZ);
			d = Direction.minZ;
			ispushing = true;
		} else if (rb.transform.position.z > maxZ) {
			transform.position=new Vector3 (transform.position.x, transform.position.y,maxZ);
			Debug.Log ("reach maxZ");
			d = Direction.maxZ;
			ispushing = true;
		} else if (rb.transform.position.y < minY) {
			transform.position=new Vector3 (transform.position.x, minY, transform.position.z);
			d = Direction.minY;
			ispushing = true;
		} else if (rb.transform.position.y > maxY) { 
			transform.position=new Vector3 (transform.position.x, maxY, transform.position.z);
			d = Direction.maxY;
			ispushing = true;
		} else {
			if(ispushing){
				ispushing=false;
				//rb.velocity = Vector3.zero;
			}
		}
		
		
	}
}