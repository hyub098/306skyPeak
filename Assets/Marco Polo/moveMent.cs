using UnityEngine;
using System.Collections;

public class moveMent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		InputMovement ();
	}

	private void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * 10 * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * 10 * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * 10 * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * 10 * Time.deltaTime);
	}
}
