using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	private Rigidbody rb;
	private Animation anim;
	private bool collision;
	// Use this for initialization
	void Start () {

		Debug.Log ("Collision script added to: " + gameObject.name);

		collision = false;
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		collision = true;

		if (other.gameObject.CompareTag ("Terrain")) {
			anim.Play("falling");
			Debug.Log ("Fall now");
		}

	}
}
