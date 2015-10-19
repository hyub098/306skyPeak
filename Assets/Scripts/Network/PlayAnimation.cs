using UnityEngine;
using System.Collections;

//The controller for the door animation
public class PlayAnimation : MonoBehaviour {


	public Animation animation;
	public bool openDoor;
	public bool isOpen;
	
	void Start() {
		//initialise th fields
		animation = GetComponent<Animation>();
		isOpen = false;
		openDoor = false;
		}

	void Update(){
		//play the animation according to the current state
		if (!isOpen && openDoor) {
			animation.Play ("open");
			isOpen=true;
		}
		
	}
}
