using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlyMovement : MonoBehaviour {
	
	public float maxSpd;
	private float currentSpd;

	private Rigidbody rb;
	private Animation anim;
	private Vector3 moveDistance;
	private bool start = false;

	private float time;
	

	// Use this for initialization
	void Start () {
		Debug.Log ("plane pilot script added to: " + gameObject.name);
		moveDistance = new Vector3(0,0,0);
		currentSpd = 0;
		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		currentSpd = Mathf.Clamp (currentSpd, 0, maxSpd);
		constrain ();
		//camera position adjust
		Vector3 moveCamtTo = transform.position - transform.forward * 5.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamtTo * (1.0f - bias);
		
		Camera.main.transform.LookAt (transform.position + transform.forward * 1.0f);
		
		
		//Get input from both axis
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");

		//start when player rise
		if (transform.position.y != 1 && !start) {
			rb.useGravity = false;
			anim.Play ("flyNormal");
			start = true;
		} else {
			time = time + (Time.deltaTime) * 1 ;
			if(time > 3){
				playRestClip();
				time = 0;
			}
		}

		//Speed up with space
		if (Input.GetKey ("space")) {

			//Increase speed slowly to max
			currentSpd = Mathf.Lerp(currentSpd,maxSpd,Time.deltaTime);
			Debug.Log("CurrentSpd:"+currentSpd);

			//move the plane
			moveDistance = transform.forward * Time.deltaTime * currentSpd;
			transform.position += moveDistance;

			//remove rigid body force
			rb.velocity = Vector3.zero;
			rb.useGravity = false;

			//animation clip
			anim.Play ("flyNormal");

			
		} else {

			currentSpd = 0;
			if(start){
				float desiredZAngle = 0;
				float desiredXAngle = 330;
				if(transform.eulerAngles.z > 180){desiredZAngle = 360;} else {desiredZAngle = 0;}
				if(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 60){desiredXAngle = -30;}
				anim.Play("flyPrey");
				rb.useGravity = true;
					transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x,desiredXAngle,Time.deltaTime),
				                                      transform.eulerAngles.y,
				                                      Mathf.Lerp(transform.eulerAngles.z,desiredZAngle,Time.deltaTime));

				                }
		}

		if (Rotation ()) {
			//rotate the plane from input
			transform.Rotate (-v,h, -h/2);
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

	void constrain(){
		if (transform.position.y <= 0) {
			transform.position = new Vector3(transform.position.x,0,transform.position.z);
		}
	}

	
	
}