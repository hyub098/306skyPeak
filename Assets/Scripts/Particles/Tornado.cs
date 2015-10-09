using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour {

	public GameObject player;

	private FlyMovement flymovement;

	// Use this for initialization
	void Start () {
		flymovement = player.GetComponent<FlyMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, new Vector3 (-35f, 14.2f, -2.7f)) < 1) {
			flymovement.enabled = true;
		}
	}

	void OnParticleCollision(GameObject other){
		Debug.Log ("Collide with Particle!");

		flymovement.enabled = false;
		player.transform.position = new Vector3 (Mathf.Lerp(player.transform.position.x,-35f,Time.deltaTime), 
		                                         Mathf.Lerp(player.transform.position.y,14.2f,Time.deltaTime),
		                                         Mathf.Lerp(player.transform.position.z, -2.7f, Time.deltaTime) );

	}
}
