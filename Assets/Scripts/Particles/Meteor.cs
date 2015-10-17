using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Meteor : MonoBehaviour {

	public Text healthText;
	private int life;

	// Use this for initialization
	void Start () {
		life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "life:" + life;
	}

	void OnParticleCollision(GameObject other){
		Debug.Log ("Collide");
		life --;
	}
}
