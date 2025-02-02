﻿using UnityEngine;
using System.Collections;

//Enum for bird state
public enum BirdState
{
	Idle = 0,
	Fly = 1,
	Fall = 2,
	Glide=3,

}


public class MoveMent : MonoBehaviour {

	private Animation anim;
	public BirdState _characterState;
	public bool isControllable = false;
	public bool isFinish=false;
	public float maxSpd;
	private float currentSpd;
	private Rigidbody rb;
	private Vector3 moveDistance;
	private int count2 = 0;


	void OnGUI(){
		//if the player wins the game, display the "congratulation screen"
		if (isFinish) {
            GUILayout.BeginArea(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 500, 300));
            GUILayout.BeginHorizontal();
            GUI.skin.label.fontSize = 60;
            GUILayout.Label("Congratulations!", GUILayout.Width(1000));
            GUILayout.EndHorizontal();
            GUILayout.Space(100);
            GUILayout.BeginHorizontal();
            GUILayout.Label("", GUILayout.Width(150));
            GUI.skin.button.fontSize = 20;
            if (GUILayout.Button("Exit", GUILayout.Width(150)))
            {
				PhotonNetwork.LeaveRoom();
				Application.LoadLevel(Application.loadedLevel);
                Application.LoadLevel(1);
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
    


		}
	}

	// Use this for initialization
	void Start () {
	
		Debug.Log ("plane pilot script added to: " + gameObject.name);
		moveDistance = new Vector3(0,0,0);
		currentSpd = 0;
		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();	
		isFinish = false;
		maxSpd = 10;

	}
	
	// Update is called once per frame
	void Update () {

		//Lock max speed
		currentSpd = Mathf.Clamp (currentSpd, 0, maxSpd);
		Vector3 moveCamtTo = transform.position - transform.forward * 5.0f + Vector3.up * 2.0f;
		float bias = 0.96f;
		gameObject.transform.GetChild(3).transform.position=gameObject.transform.GetChild(3).transform.position* bias + moveCamtTo * (1.0f - bias);
		gameObject.transform.GetChild (3).transform.LookAt (transform.position + transform.forward * 1.0f);
		if (isFinish) {
			//Stops the game
			Time.timeScale = 0f; 
		}
		constrain ();
		UpdateAnimation ();

		if (isControllable) {
			move ();
		}
	}

	//Stop owl going below ground level
	void constrain(){
		if (transform.position.y <= 1f) {
			transform.position = new Vector3(transform.position.x,1f,transform.position.z);
			//remove rigid body force
			rb.velocity = Vector3.zero;
			rb.useGravity = false;
			
			
			anim.Play("idleFloor1");
			
		}
	}


	/**
	 * Limit rotation to 45 degrees up/down, 50 degreesleft/right
	 * 
	 * Note: Camera shakes when rotation is re-adjusted. Looking for better way to constraint rotation
	 * 
	 */
	private bool Rotation()
	{
		bool rotate = true;
		
		if (transform.eulerAngles.x > 60f && transform.eulerAngles.x < 300f){ 
			
			rotate = false;
			
			if(transform.eulerAngles.x < 100){
				transform.eulerAngles = new Vector3(59.9f,transform.eulerAngles.y, transform.eulerAngles.z);
			}
			else{
				transform.eulerAngles = new Vector3(300,transform.eulerAngles.y, transform.eulerAngles.z);
			}
			
		}
		
		return rotate;
	}



	
	//flight control
	void move(){
		//Get input from both axis
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		
		
		//Speed up with space
		if (Input.GetKey("space")) {
			
			//Increase speed slowly to max
			currentSpd = Mathf.Lerp(currentSpd, maxSpd, Time.deltaTime);
			Debug.Log("CurrentSpd:" + currentSpd);
			
			//move the plane
			moveDistance = transform.forward * Time.deltaTime * currentSpd;
			transform.position += moveDistance;
			
			//remove rigid body force
			rb.velocity = Vector3.zero;
			rb.useGravity = false;
			
			
			//animation clip
			if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 61) {
				_characterState = BirdState.Glide;
				maxSpd=20;
				count2++;
				if (count2 == 300)
				{
					count2 = 0;
					maxSpd=10;
				}
			} else if (transform.eulerAngles.x > 299 && transform.eulerAngles.x < 361) {
				_characterState = BirdState.Fly;
				maxSpd=10;
			}
		} else {
			
			//Re-adjust owl if space is not pressed
			currentSpd = 0;
				//Calculate angle to re-adjust
				float desiredZAngle = 0;
				float desiredXAngle = 330;
				if(transform.eulerAngles.z > 180){desiredZAngle = 360;} else {desiredZAngle = 0;}
				if(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 60){desiredXAngle = -30;}
				if(transform.position.y > 2){

					//anim.Play("idleFloor2");
				_characterState = BirdState.Idle;
				}
				
				//turn on gravity to allow falling
				rb.useGravity = true;
				
				//change rotation of owl
				transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x,desiredXAngle,Time.deltaTime),
				                                      transform.eulerAngles.y,
				                                      Mathf.Lerp(transform.eulerAngles.z,desiredZAngle,Time.deltaTime));
				

		}
		
		//Change rotation of owl base on user input
		if (Rotation ()) {
			//rotate the plane from input
			transform.Rotate (-v,h*1.2f, -h*0.6f);
		}
		
		
	}
	//When player reaches the end, set current state to "isfinished"
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag ("Finish")){
		isFinish = true;
		}
	}
	//method for playing animation for different state
	private void UpdateAnimation(){

		if (_characterState == BirdState.Idle) {
			anim.Play("idleFloor1");
		
		}

		if (_characterState == BirdState.Fly) {
			
			anim.Play ("flyNormal");
		}
		
		if (_characterState == BirdState.Fall) {
			
			anim.Play ("falling");
		}

		if (_characterState == BirdState.Glide) {
			
			anim.Play("glideNormal");
		}
	}
}
