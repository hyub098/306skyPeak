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

    public AudioClip windSound;
    public AudioClip wingSound;
    private AudioSource source;
    private int count=0;
    private int count2 = 0;

    // Use this for initialization
    void Start () {
		moveDistance = new Vector3(0,0,0);
		currentSpd = 0;
		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
        source = GetComponent<AudioSource>();


    }
	
	// Update is called once per frame
	void Update () {

		//Lock max speed
		currentSpd = Mathf.Clamp (currentSpd, 0, maxSpd);

		//camera position adjust
		Vector3 moveCamtTo = transform.position - transform.forward * 0.5f + Vector3.up * 0.3f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamtTo * (1.0f - bias);
		
		Camera.main.transform.LookAt (transform.position + transform.forward * 0.01f);


		//check if owl started
		beforeStart ();
			
	 	//Check if game started
		if (start) {
			constrain ();
		}

		//move owl
		move ();
		
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


	//Stop owl going below ground level
	void constrain(){
		if (transform.position.y <= 0.1f) {
			transform.position = new Vector3(transform.position.x,0.1f,transform.position.z);
			//remove rigid body force
			rb.velocity = Vector3.zero;
			rb.useGravity = false;

		
			anim.Play("idleFloor1");

		}
	}


	// Check if game started
	void beforeStart(){
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

            //move the plane
            moveDistance = transform.forward * Time.deltaTime * currentSpd;
            transform.position += moveDistance;

            //remove rigid body force
            rb.velocity = Vector3.zero;
            rb.useGravity = false;


            //animation clip
            if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 61) {
                anim.Play("glideNormal");
                count2++;
                if (count2 == 300)
                {
                    source.clip = windSound;
                    source.Play();
                    count2 = 0;
                }
            } else if (transform.eulerAngles.x > 299 && transform.eulerAngles.x < 361) {
                anim.Play("flyNormal");
                count++;
                if (count == 100)
                {
                    source.clip = wingSound;
                    source.Play();

                    count = 0;
                }
			}
		} else {

			//Re-adjust owl if space is not pressed
			currentSpd = 0;
			if(start){
                //Calculate angle to re-adjust
                float desiredZAngle = 0;
				float desiredXAngle = 330;
				if(transform.eulerAngles.z > 180){desiredZAngle = 360;} else {desiredZAngle = 0;}
				if(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 60){desiredXAngle = -30;}
				if(transform.position.y > 2){
					anim.Play("idleFloor2");
				}

				//turn on gravity to allow falling
				rb.useGravity = true;

				//change rotation of owl
				transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x,desiredXAngle,Time.deltaTime),
				                                      transform.eulerAngles.y,
				                                      Mathf.Lerp(transform.eulerAngles.z,desiredZAngle,Time.deltaTime));
				
			}
		}

		//Change rotation of owl base on user input
		if (Rotation ()) {
			//rotate the plane from input
			transform.Rotate (-v,h*1.2f, -h*0.6f);
		}


	}

	
	
}