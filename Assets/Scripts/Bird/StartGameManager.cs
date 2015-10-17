using UnityEngine;
using System.Collections;

public class StartGameManager : MonoBehaviour {

	private FlyMovement flymovement;
	private MailCount mailcount;
	private Collision collision;
	private Rigidbody rb;
	private Animation anim;
	private float time;

	public Canvas gameOver;
	public Canvas mountainHelp;
	public Camera radarCam;
	private Radar radar;
	private bool started;

	// Use this for initialization
	void Start () {
		flymovement = GetComponent<FlyMovement> ();
		mailcount = GetComponent<MailCount> ();
		collision = GetComponent< Collision> ();
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
		radar = radarCam.GetComponent<Radar> ();
		started = false;
		beforeStart ();

	}
	
	// Update is called once per frame
	void Update () {

		//Dont start until space is pressed
		if (Input.GetKey ("space") && !started) {
			Debug.Log ("Game start");
			startGame ();
	
		}
		if (!started) {
			time = time + (Time.deltaTime) * 1;
			if (time > 3) {
				playRestClip ();
				time = 0;
			}
		}
	}

	void startGame(){
		flymovement.enabled = true;
		mailcount.enabled = true;
		collision.enabled = true;
		mountainHelp.enabled = false;
		rb.useGravity = true;
		radar.enabled = true;
		started = true;
	}

	void beforeStart(){
		flymovement.enabled = false;
		gameOver.enabled = false;
		radar.enabled = false;

//		mailcount.enabled = false;
		collision.enabled = false;
		rb.useGravity = false;
	}


	
	//Play different animation randomly
	void playRestClip(){
		int clipNum = Random.Range (0, 2);
		if (clipNum == 0) {
			anim.Play ("idleFloor1");
		} else if (clipNum == 1) {
			anim.Play ("idleFloor2");
		} else {
			anim.Play ("idleFloor3");
		}
	}
}
