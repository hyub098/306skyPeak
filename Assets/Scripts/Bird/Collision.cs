using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collision : MonoBehaviour {
	private Rigidbody rb;
	private Animation anim;
	private bool collision;
	public Text healthText;
	private int life;

	// Use this for initialization
	void Start () {

		Debug.Log ("Collision script added to: " + gameObject.name);

		collision = false;
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
		life = 3;

	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "life:" + life;
	}

	void OnTriggerEnter(Collider other){
		collision = true;

		if (other.gameObject.CompareTag ("Terrain")) {
			anim.Play ("falling");
			Debug.Log ("Fall now");
			life--;
		} 
	}
}
