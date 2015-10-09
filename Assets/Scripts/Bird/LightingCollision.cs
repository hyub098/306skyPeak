using UnityEngine;
using System.Collections;

public class LightingCollision : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject other){
		Debug.Log ("Collide with Particle!");
		Time.timeScale = 0f;
	}
}
