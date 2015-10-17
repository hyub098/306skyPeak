using UnityEngine;
using System.Collections;

public class EnableHunter : MonoBehaviour {

	public GameObject owl;
	private FlyMovement fly;
	private Axe axe;
	private HunterMovement huntermove;
	// Use this for initialization
	void Start () {
		fly = owl.GetComponent<FlyMovement> ();
		axe = GetComponentInChildren <Axe> ();
		huntermove = GetComponent<HunterMovement> ();

		disable ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fly.enabled) {
			able();
		}
	}

	void disable(){
		axe.enabled = false;
		huntermove.enabled = false;
	}

	void able(){
		axe.enabled = true;
		huntermove.enabled = true;
	}
}
