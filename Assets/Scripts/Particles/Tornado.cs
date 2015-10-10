using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour {

	public GameObject player;

	private FlyMovement flymovement;
	private Rigidbody rb;
	private float realtime;
	private float time;
	private bool collide = false;


	// Use this for initialization
	void Start () {

		time = 0;
		realtime = 0;
		flymovement = player.GetComponent<FlyMovement> ();
		rb = player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		realtime = Time.deltaTime + realtime;
//		Debug.Log (realtime);
		if (realtime - time > 3 && collide) {
		
			flymovement.enabled = true;
			rb.velocity = Vector3.zero;
			collide = !collide;
		}
	}

	void OnParticleCollision(GameObject other){
		Debug.Log ("Lost control");

		flymovement.enabled = false;
		collide = true;
		time = realtime;

		rb.AddForce (5000.0f, 1000.0f, 3000.0f, ForceMode.Force);

//		player.transform.position = new Vector3 (Mathf.Lerp(player.transform.position.x,-35f,Time.deltaTime), 
//		                                         Mathf.Lerp(player.transform.position.y,14.2f,Time.deltaTime),
//		                                         Mathf.Lerp(player.transform.position.z, -2.7f, Time.deltaTime) );

	}
}
