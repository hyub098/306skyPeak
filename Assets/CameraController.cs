using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	//	public float distance;
	Vector3 offset;
	//	private float verticalDistance = 5;
	
	
	void Start(){
		//Get the offset from camera to player. 
		
		offset = transform.position - player.transform.position;
		Debug.Log ("offset:" + offset);
		
		
	}
	// Update is called once per frame
	void LateUpdate () {
		
		//Read player's new position, apply offset to get new position for camera
		float newX = player.transform.position.x - offset.x;
		//+ offset.y so move up
		float newY = player.transform.position.y + offset.y;
		// offset.z is NEGATIVE. adding it will become minus and move back
		float newZ = player.transform.position.z + offset.z;
		
		//Update camera position
		transform.position = new Vector3 (newX,newY,newZ);
	}
}