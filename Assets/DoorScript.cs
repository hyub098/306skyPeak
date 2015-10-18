using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	public bool myDoor;
	public bool otherDoor;
	public PlayAnimation openDoor;
	// Use this for initialization
	void Start () {
		myDoor = false;
		otherDoor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (myDoor && otherDoor) {
			openDoor.openDoor=true;
		}

	}
}
