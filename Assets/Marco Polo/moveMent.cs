using UnityEngine;
using System.Collections;

public class moveMent : MonoBehaviour {

	private Animation anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {
		InputMovement ();
	}

	private void InputMovement()
	{
		if (Input.GetKey (KeyCode.W)) {
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + Vector3.forward * 10 * Time.deltaTime);
			anim.Play ("flyNormal");
		
		}
		if (Input.GetKey(KeyCode.S))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * 10 * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * 10 * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * 10 * Time.deltaTime);
	}
}
