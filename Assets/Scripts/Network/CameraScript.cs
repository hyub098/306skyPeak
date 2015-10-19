using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	//Check if the camera belongs to the character
	public bool isMine=false;
	
	// Update is called once per frame
	void Update () {
		if(isMine){
			//activate self camera
			gameObject.GetComponent<Camera>().enabled = true;
		}

	}
}
