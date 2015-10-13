using UnityEngine;
using System.Collections;


public enum BirdState
{
	Idle = 0,
	fly = 1,
	fall = 2,

}

public class MoveMent : MonoBehaviour {

	private Animation anim;
	public BirdState _characterState;
	public bool isControllable = false;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {

		UpdateAnimation ();

		if (isControllable) {
			InputMovement ();
		}
	}

	private void InputMovement()
	{
		if (Input.GetKey (KeyCode.W)) {
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + Vector3.forward * 10 * Time.deltaTime);
			//anim.Play ("flyNormal");
			_characterState = BirdState.fly;
		
		}
		if (Input.GetKey (KeyCode.S)) {
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position - Vector3.forward * 10 * Time.deltaTime);
			//anim.Play("idleFloor2");
			_characterState = BirdState.fall;
		
		}
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + Vector3.right * 10 * Time.deltaTime);
		
		}
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position - Vector3.right * 10 * Time.deltaTime);
		
		}


	}

	private void UpdateAnimation(){

		if (_characterState == BirdState.Idle) {
			anim.Play("idleFloor2");
		
		}

		if (_characterState == BirdState.fly) {
			
			anim.Play ("flyNormal");
		}
		
		if (_characterState == BirdState.fall) {
			
			anim.Play ("falling");
		}
	}
}
