using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlyMovement : MonoBehaviour {
	
	public float speed;
//	public float moveSpd;
	
//	public Text winText;


	private int count;

	private float rotationX;
	private float rotationZ;
	private Vector3 movement;
	private Rigidbody rb;

	private Animation anim;
	private Vector3 moveDistance;
	private bool start = false;
	private float inputSpd;



//    int incrementTime = 1;
//    float incrementBy = 1;
//    float counter = 0;
//    int minute = 0;
//    int second = 0;
//    float time = 0;

//    public string timerFormatted;
//    public Text timerText;



    // Use this for initialization
    void Start () {
		Debug.Log ("plane pilot script added to: " + gameObject.name);

		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();

     //   SetTimerText();

        //		SetCountText();
    }

    // Update is called once per frame
    void Update () {


//        minute = (int)counter / 60;
//        second = (int)counter % 60;
//        time += Time.deltaTime;
//        while (time > incrementTime)
//        {
//            time -= incrementTime;
//            counter += incrementBy;
//        }
//        timerFormatted = string.Format("{0:00}:{1:00}", minute, second);
//        SetTimerText();

        //camera position adjust
        Vector3 moveCamtTo = transform.position - transform.forward * 5.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamtTo * (1.0f - bias);
		
		Camera.main.transform.LookAt (transform.position + transform.forward * 1.0f);



		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
//		if (Input.GetKeyDown ("up")) {
//			v = 1;
//		} else if (Input.GetKeyDown ("down")) {
//			v = -1;
//		}else{ v=0;}

		if (transform.position.y != 0 && !start) {
			rb.useGravity = false;
			inputSpd = speed;
			anim.Play ("flyNormal");
			start =true;


		}
		//	inputSpd = v * inputSpd;
		if (Input.GetKey ("space")) {

			moveDistance = transform.forward * Time.deltaTime * inputSpd;
			transform.position += moveDistance;
			rb.velocity = Vector3.zero;
			rb.useGravity = false;

		} else {
//			if(moveDistance.magnitude == 0){ moveDistance = Vector3.zero;}
//
//			transform.position += 10*moveDistance/inputSpd; 
//			moveDistance = moveDistance - moveDistance/10;
			if(start){
				rb.useGravity = true;
			}
		}
		//move the plane


//		if (v != 0) {
//			anim.Play("flyNormal");
//			speed = Mathf.Clamp (speed, 1, 20);
//
//			speed = v * speed;
//		}
//
//
//		//move the plane
//		transform.position += transform.forward * Time.deltaTime * speed;
//	
//	//	if (Rotation ()) {
//			//rotate the plane from input
//			transform.Rotate (-Input.GetAxis("Vertical"),0.0f, -Input.GetAxis("Horizontal"));
//	//	}

//		//move the plane
//		transform.position += transform.forward * Time.deltaTime * speed;
//	
//		if (Rotation ()) {
//			//rotate the plane from input
//			transform.Rotate (-Input.GetAxis("Vertical")*2,0.0f, -Input.GetAxis("Horizontal")*3);
//		}


		//speed -= transform.forward.y * Time.deltaTime *  2.0f;
		
	}

	

	/**
	 * Limit rotation to 45 degrees up/down, 50 degreesleft/right
	 * 
	 * Note: Camera shakes when rotation is re-adjusted. Looking for better way to constraint rotation
	 * 
	 */
	bool Rotation()
	{
		bool rotate = true;

		if (transform.eulerAngles.x > 45f && transform.eulerAngles.x < 315f){ 

			rotate = false;

			if(transform.eulerAngles.x < 100){
				transform.eulerAngles = new Vector3(45,transform.eulerAngles.y, transform.eulerAngles.z);
			}
			else{
				transform.eulerAngles = new Vector3(315,transform.eulerAngles.y, transform.eulerAngles.z);
			}

		}

//		if (50f < transform.eulerAngles.z  && transform.eulerAngles.z < 310f){ 
//			rotate = false;
//
//			if(transform.eulerAngles.z < 100){
//				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,45);
//
//			}else{
//				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,310);
//
//			}
//			
//		}

/// Test

		return rotate;
	}
//
//    void SetTimerText()
//    {
//        timerText.text = "Time: " + timerFormatted;
//    }



}
